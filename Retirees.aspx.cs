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
    public partial class Retirees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                    SqlDataAccess s = new SqlDataAccess();
                    DataTable dt = new DataTable();
                    
                    String LoginID = "";
                    if (Session["LoginID"] != null)
                    {
                        LoginID = Session["LoginId"].ToString();
                    }
                    else
                    {
                       Response.Redirect("Login.aspx");
                    }

                PopulateGridView();

            }
        }

        public void PopulateGridView()
        {
            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();
           
            dt = s.Execute("select * from RetireeDetails");
           if (dt != null && (int)dt.Rows[0][0] > 0)
            {

                gvRetirees.DataSource = dt;
                gvRetirees.DataBind();

            }
            else
            {
                gvRetirees.DataSource = dt;
                gvRetirees.DataBind();
                gvRetirees.Rows[0].Cells.Clear();
                gvRetirees.Rows[0].Cells.Add(new TableCell());
                gvRetirees.Rows[0].Cells[0].ColumnSpan=dt.Columns.Count;
                gvRetirees.Rows[0].Cells[0].Text = "No rows exist";
                gvRetirees.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

                     }
        }

        
        protected void gvRetirees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [dbo].[Retiree] ([Firstname],[Lastname],[DateofBirth],[Sex] ,[Emailaddress],[SSN]) VALUES " +
          " (@Firstname, @Lastname, @DOB, @Sex,  @Email,  @SSN) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvRetirees.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (gvRetirees.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DOB", (gvRetirees.FooterRow.FindControl("txtDOBFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Sex", "M");
                        sqlCmd.Parameters.AddWithValue("@Email", (gvRetirees.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@SSN", 123456789);
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridView();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }

                if (e.CommandName.Equals("Details"))
                {

                    int key = Convert.ToInt32(e.CommandArgument);
                    // Use the key variable as needed
                    Session["RetireeId"] = key;
                    Response.Redirect("Dashboard.aspx");
                }

            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }

          
        }

              
        protected void gvRetirees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRetirees.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvRetirees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRetirees.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvRetirees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Retiree SET FirstName=@FirstName,LastName=@LastName,Dateofbirth = @DOB,Emailaddress=@Email WHERE Retiree_id = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvRetirees.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (gvRetirees.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DOB", (gvRetirees.Rows[e.RowIndex].FindControl("txtDOB") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gvRetirees.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRetirees.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvRetirees.EditIndex = -1;
                    PopulateGridView();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvRetirees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM retiree WHERE Retiree_id = @Retireeid";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Retireeid", Convert.ToInt32(gvRetirees.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnRetireeGrid_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }


    }
}