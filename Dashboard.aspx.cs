using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace NYUProject.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                if (Session["RetireeID"] != null)
                {
                    int RetireeID = Convert.ToInt32(Session["RetireeID"]);

                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    { 
                        SqlCommand sqlCmd = new SqlCommand("GetRetireeDetails", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@RetireeID", RetireeID);

                        sqlCmd.Connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                        DataSet dataSet = new DataSet();

                        adapter.Fill(dataSet);
                        gvRetirees.DataSource = dataSet.Tables[0];
                        gvRetirees.DataBind();

                        //Address Details
                        gvAddress.DataSource = dataSet.Tables[1];
                        gvAddress.DataBind();

                        //Beneficiary Details
                        gvBene.DataSource = dataSet.Tables[2];
                        gvBene.DataBind();

                        //Bank Details
                        gvBank.DataSource = dataSet.Tables[3];
                        gvBank.DataBind();

                        //Payment Details
                        gvPayment.DataSource = dataSet.Tables[4];
                        gvPayment.DataBind();

                        // Employment
                        gvEmployment.DataSource = dataSet.Tables[5];
                        gvEmployment.DataBind();

                        PopulateAddressGridView();
                        PopulateBeneGridView();
                        
                    }
                }
            
            }
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Address

        public void PopulateAddressGridView()
        {
            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();

            dt = s.Execute("select * from Address where retiree_id = " + Session["RetireeID"]);
            if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
            {

                gvAddress.DataSource = dt;
                gvAddress.DataBind();

            }
            else
            {
                //DataRow retiree = dt.NewRow();
                //retiree["FirstName"] = "";
                //retiree["Lastname"] = "";
                //retiree["Dateofbirth"] = "01/01/1901";
                //retiree["Sex"] = "M";
                DataRow dr = dt.NewRow();
                dr["Addressline1"] = "";
                dr["Addressline2"] = "";
                dr["City"] = "";
                dr["State"] = "";
                dr["Zipcode"] = "";
                dt.Rows.Add(dr);
                gvAddress.DataSource = dt;
                gvAddress.DataBind();
               // gvAddress.Rows[0].Cells.Clear();
                gvAddress.Rows[0].Cells.Add(new TableCell());
                gvAddress.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvAddress.Rows[0].Cells[0].Text = "No rows exist";
                gvAddress.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;



                ;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void gvAddress_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [dbo].[Address] ([Addressline1],[Addressline2],[City],[State] ,[Zipcode],[Retiree_id]) VALUES " +
                                        " (@Addressline1, @Addressline2, @City, @State,  @Zipcode,  @Retiree_id) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Addressline1", (gvAddress.FooterRow.FindControl("txtAddressline1Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Addressline2", (gvAddress.FooterRow.FindControl("txtAddressline2Footer") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@City", (gvAddress.FooterRow.FindControl("txtCityFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@State", (gvAddress.FooterRow.FindControl("txtStateFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Zipcode", (gvAddress.FooterRow.FindControl("txtZipFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Retiree_id", Session["RetireeID"]);
                        sqlCmd.ExecuteNonQuery();
                        PopulateAddressGridView();
                       lblSuccess.Text = "New Record Added";
                       lblError.Text = "";
                    }
                }

               
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }


        }


        protected void gvAddress_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddress.EditIndex = e.NewEditIndex;
            PopulateAddressGridView();
        }

        protected void gvAddress_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddress.EditIndex = -1;
            PopulateAddressGridView();
        }

        protected void gvAddress_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Address SET Addressline1=@Addressline1,Addressline2=@Addressline2,City = @City,State=@State, Zipcode=@Zip WHERE Address_id = @AddressID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Addressline1", (gvAddress.Rows[e.RowIndex].FindControl("txtAddressline1") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Addressline2", (gvAddress.Rows[e.RowIndex].FindControl("txtAddressline1") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@City", (gvAddress.Rows[e.RowIndex].FindControl("txtCity") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@State", (gvAddress.Rows[e.RowIndex].FindControl("txtState") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Zip", (gvAddress.Rows[e.RowIndex].FindControl("txtZip") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@AddressID", Convert.ToInt32(gvAddress.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvAddress.EditIndex = -1;
                    PopulateAddressGridView();
                    lblSuccess.Text = "Selected Record Updated";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void gvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Address where Address_id= @AddressID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@AddressID", Convert.ToInt32(gvAddress.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateAddressGridView();
                    lblSuccess.Text = "Selected Record Deleted";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }


        #endregion


        #region Beneficiaries

        public void PopulateBeneGridView()
        {
            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();

            dt = s.Execute("select * from beneficiary where retiree_id = " + Session["RetireeID"]);
            if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
            {

                gvBene.DataSource = dt;
                gvBene.DataBind();

            }
            else
            {
               
                DataRow dr = dt.NewRow();
                dr["Firstname"] = "";
                dr["Lastname"] = "";               
                dr["Relationship"] = "";
                dt.Rows.Add(dr);
                gvBene.DataSource = dt;
                gvBene.DataBind();
                gvBene.Rows[0].Cells.Add(new TableCell());
                gvBene.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvBene.Rows[0].Cells[0].Text = "No rows exist";
                gvBene.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            }
        }

      



        protected void gvBene_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [dbo].[Beneficiary] ([Firstname],[Lastname],[Relationship],[Retiree_id]) VALUES " +
                                        " (@Firstname, @Lastname, @Relationship, @Retiree_id) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Firstname", (gvBene.FooterRow.FindControl("txtFirstnameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Lastname", (gvBene.FooterRow.FindControl("txtLastnameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Relationship", (gvBene.FooterRow.FindControl("txtRelationshipFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Retiree_id", Session["RetireeID"]);
                        sqlCmd.ExecuteNonQuery();
                        PopulateBeneGridView();
                        lblSuccess.Text = "New Record Added";
                        lblError.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }


        }


        protected void gvBene_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBene.EditIndex = e.NewEditIndex;
            PopulateBeneGridView();
        }

        protected void gvBene_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBene.EditIndex = -1;
            PopulateBeneGridView();
        }

        protected void gvBene_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Beneficiary SET Firstname=@Firstname,Lastname=@Lastname,Relationship = @Relationship WHERE Bene_id = @BeneID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Firstname", (gvBene.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Lastname", (gvBene.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Relationship", (gvBene.Rows[e.RowIndex].FindControl("txtRelationship") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@BeneID", Convert.ToInt32(gvBene.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvBene.EditIndex = -1;
                    PopulateBeneGridView();
                    lblSuccess.Text = "Selected Record Updated";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void gvBene_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Beneficiary where Bene_id= @BeneID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@BeneID", Convert.ToInt32(gvBene.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateBeneGridView();
                    lblSuccess.Text = "Selected Record Deleted";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }


        #endregion

        #region Bank

        public void PopulateBankGridView()
        {
            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();

            dt = s.Execute("select * from Bank where retiree_id = " + Session["RetireeID"]);
            if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
            {

                gvBank.DataSource = dt;
                gvBank.DataBind();

            }
            else
            {

                DataRow dr = dt.NewRow();
                dr["Bankname"] = "";
                dr["Accountno"] = "";
                dr["Routingno"] = "";
                dt.Rows.Add(dr);
                gvBank.DataSource = dt;
                gvBank.DataBind();
                gvBank.Rows[0].Cells.Add(new TableCell());
                gvBank.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvBank.Rows[0].Cells[0].Text = "No rows exist";
                gvBank.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            }
        }





        protected void gvBank_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [dbo].[Bank] ([Bankname],[Accountno],[Routingno],[Retiree_id]) VALUES " +
                                        " (@Bankname, @Accountno, @Routingno, @Retiree_id) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Bankname", (gvBank.FooterRow.FindControl("txtBanknameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Accountno", (gvBank.FooterRow.FindControl("txtAccountnoFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Routingno", (gvBank.FooterRow.FindControl("txtRoutingnoFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Retiree_id", Session["RetireeID"]);
                        sqlCmd.ExecuteNonQuery();
                        PopulateBankGridView();
                        lblSuccess.Text = "New Record Added";
                        lblError.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }


        }


        protected void gvBank_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBank.EditIndex = e.NewEditIndex;
            PopulateBankGridView();
        }

        protected void gvBank_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBank.EditIndex = -1;
            PopulateBankGridView();
        }

        protected void gvBank_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Bank SET Bankname=@Bankname,Accountno=@Accountno,Routingno = @Routingno WHERE Bank_id = @BankID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Bankname", (gvBank.Rows[e.RowIndex].FindControl("txtBankName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Accountno", (gvBank.Rows[e.RowIndex].FindControl("txtAccountno") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Routingno", (gvBank.Rows[e.RowIndex].FindControl("txtRoutingno") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@BankID", Convert.ToInt32(gvBank.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvBank.EditIndex = -1;
                    PopulateBankGridView();
                    lblSuccess.Text = "Selected Record Updated";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void gvBank_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Bank where Bank_id= @BankID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@BankID", Convert.ToInt32(gvBank.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateBankGridView();
                    lblSuccess.Text = "Selected Record Deleted";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }


        #endregion

        #region Payment

        public void PopulatePaymentGridView()
        {
            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();

            dt = s.Execute("select * from RetireePay1 where retiree_id = " + Session["RetireeID"]);
            if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
            {

                gvPayment.DataSource = dt;
                gvPayment.DataBind();

            }
            else
            {

                DataRow dr = dt.NewRow();
                dr["Paymentdate"] = "";
                dr["Grossamount"] = "";
                dr["Netamount"] = "";
                dr["Fedtax"] = "";
                dr["Statetax"] = "";
                dt.Rows.Add(dr);
                gvPayment.DataSource = dt;
                gvPayment.DataBind();
                gvPayment.Rows[0].Cells.Add(new TableCell());
                gvPayment.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvPayment.Rows[0].Cells[0].Text = "No rows exist";
                gvPayment.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            }
        }





        protected void gvPayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [dbo].[Payment] ([Paymentdate],[Grossamount],[Netamount],[Fedtax],[Statetax],[Retiree_id]) VALUES " +
                                        " (@Paymentdate, @Grossamount, @Netamount,@Fedtax,@Statetax, @Retiree_id) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Paymentdate", (gvPayment.FooterRow.FindControl("txtPaymentdateFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Grossamount", (gvPayment.FooterRow.FindControl("txtGrossamountFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Netamount", (gvPayment.FooterRow.FindControl("txtNetamountFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Fedtax", (gvPayment.FooterRow.FindControl("txtFedtaxFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Statetax", (gvPayment.FooterRow.FindControl("txtStatetaxFooter") as TextBox).Text.Trim());

                        sqlCmd.Parameters.AddWithValue("@Retiree_id", Session["RetireeID"]);
                        
                        sqlCmd.ExecuteNonQuery();
                        PopulatePaymentGridView();
                        lblSuccess.Text = "New Record Added";
                        lblError.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }


        }


        protected void gvPayment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPayment.EditIndex = e.NewEditIndex;
            PopulatePaymentGridView();
        }

        protected void gvPayment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPayment.EditIndex = -1;
            PopulatePaymentGridView();
        }

        protected void gvPayment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Payment SET Paymentdate=@Paymentdate,Grossamount=@Grossamount,Netamount = @Netamount, Fedtax=@Fedtax, Statetax = @Statetax WHERE Pay_id = @PayID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Paymentdate", (gvPayment.Rows[e.RowIndex].FindControl("txtPaymentdate") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Grossamount", (gvPayment.Rows[e.RowIndex].FindControl("txtGrossamount") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Netamount", (gvPayment.Rows[e.RowIndex].FindControl("txtNetamount") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Fedtax", (gvPayment.Rows[e.RowIndex].FindControl("txtFedtax") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Statetax", (gvPayment.Rows[e.RowIndex].FindControl("txtStatetax") as TextBox).Text.Trim());

                    sqlCmd.Parameters.AddWithValue("@PayID", Convert.ToInt32(gvPayment.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPayment.EditIndex = -1;
                    PopulatePaymentGridView();
                    lblSuccess.Text = "Selected Record Updated";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void gvPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Payment where Pay_id= @PayID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@PayID", Convert.ToInt32(gvPayment.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulatePaymentGridView();
                    lblSuccess.Text = "Selected Record Deleted";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }


        #endregion

        #region Employment

        public void PopulateEmploymentGridView()
        {
            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();

            dt = s.Execute("select * from Employment where retiree_id = " + Session["RetireeID"]);
            if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
            {

                gvEmployment.DataSource = dt;
                gvEmployment.DataBind();

            }
            else
            {

                DataRow dr = dt.NewRow();
                dr["Employername"] = "";
                dr["Statedate"] = "";
                dr["Enddate"] = "";
                dr["emailaddress"] = "";
                dt.Rows.Add(dr);
                gvEmployment.DataSource = dt;
                gvEmployment.DataBind();
                gvEmployment.Rows[0].Cells.Add(new TableCell());
                gvEmployment.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvEmployment.Rows[0].Cells[0].Text = "No rows exist";
                gvEmployment.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            }
        }





        protected void gvEmployment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [dbo].[Employment] ([Employername],[Startdate],[Enddate],[emailaddress],[Retiree_id]) VALUES " +
                                        " (@Employername, @Statedate, @Enddate,@emailaddress, @Retiree_id) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Employername", (gvEmployment.FooterRow.FindControl("txtEmployerNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Statedate", (gvEmployment.FooterRow.FindControl("txtStartDateFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Enddate", (gvEmployment.FooterRow.FindControl("txtEndDateFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@emailaddress", (gvEmployment.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                       
                        sqlCmd.Parameters.AddWithValue("@Retiree_id", Session["RetireeID"]);
                        sqlCmd.ExecuteNonQuery();
                        PopulateEmploymentGridView();
                        lblSuccess.Text = "New Record Added";
                        lblError.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }


        }


        protected void gvEmployment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployment.EditIndex = e.NewEditIndex;
            PopulateEmploymentGridView();
        }

        protected void gvEmployment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployment.EditIndex = -1;
            PopulateEmploymentGridView();
        }

        protected void gvEmployment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Employment SET Employername=@Employername,Startdate=@Startdate,Enddate = @Enddate, emailaddress=@emailaddress WHERE Employment_id = @EmploymentID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Employername", (gvEmployment.Rows[e.RowIndex].FindControl("txtEmployerName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Startdate", (gvEmployment.Rows[e.RowIndex].FindControl("txtStartDate") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Enddate", (gvEmployment.Rows[e.RowIndex].FindControl("txtEndDate") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@emailaddress", (gvEmployment.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                   
                    sqlCmd.Parameters.AddWithValue("@EmploymentID", Convert.ToInt32(gvEmployment.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvEmployment.EditIndex = -1;
                    PopulateEmploymentGridView();
                    lblSuccess.Text = "Selected Record Updated";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }

        protected void gvEmployment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Employment where Employment_id= @EmploymentID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@EmploymentID", Convert.ToInt32(gvEmployment.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateEmploymentGridView();
                    lblSuccess.Text = "Selected Record Deleted";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "";
                lblError.Text = ex.Message;
            }
        }


        #endregion
    }
}