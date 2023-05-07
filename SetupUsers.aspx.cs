using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using NYUProject.Pages;

namespace NYUProject
{
    public partial class SetupUsers : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                
                   

                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                    /*SqlDataAccess s = new SqlDataAccess();
                    DataTable dt = new DataTable();

                    dt = s.Execute("select * from Users");
                    if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
                    {

                        gvUsers.DataSource = dt;
                        gvUsers.DataBind();

                    }*/

                    SqlCommand sqlCmd = new SqlCommand("GetUserDetails", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    
                    sqlCmd.Connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    DataSet dataSet = new DataSet();

                    adapter.Fill(dataSet);
                    gvUsers.DataSource = dataSet.Tables[0];
                    gvUsers.DataBind();


                    //PopulateUsersGridView();    

                }
                

            }
        }

        #region Users

        public void PopulateUsersGridView()
        {
            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();

            dt = s.Execute("select * from Users ;");
            if (dt != null && dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
            {

                gvUsers.DataSource = dt;
                gvUsers.DataBind();

            }
            else
            {

                DataRow dr = dt.NewRow();
                dr["userid"] = "";
                dr["password"] = "";
                dr["Status"] = "";
                dt.Rows.Add(dr);
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
                gvUsers.Rows[0].Cells.Add(new TableCell());
                gvUsers.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvUsers.Rows[0].Cells[0].Text = "No rows exist";
                gvUsers.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            }
        }





        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [dbo].[Users] ([userid],[password],[Status]) VALUES (@UserID, @Password, @Status) ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@UserID", (gvUsers.FooterRow.FindControl("txtUserIDFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", (gvUsers.FooterRow.FindControl("txtPasswordFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Status", (gvUsers.FooterRow.FindControl("txtStatusFooter") as TextBox).Text.Trim());
                        
                        sqlCmd.ExecuteNonQuery();
                        PopulateUsersGridView();
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


        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            PopulateUsersGridView();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            PopulateUsersGridView();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Users SET userid=@UserID,Password=@Password,Status = @Status WHERE Login_id = @LoginID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", (gvUsers.Rows[e.RowIndex].FindControl("txtUserID") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", (gvUsers.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Status", (gvUsers.Rows[e.RowIndex].FindControl("txtStatus") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LoginID", Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvUsers.EditIndex = -1;
                    PopulateUsersGridView();
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

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlDataAccess.ConnectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Users where login_id=@LoginID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@LoginID", Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateUsersGridView();
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