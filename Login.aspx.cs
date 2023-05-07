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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = txtUserID.Text + " , " + txtPassword.Text;

            SqlDataAccess s = new SqlDataAccess();
            DataTable dt = new DataTable();
            
             dt = s.ExecuteStoredProcedure("CheckLogin", txtUserID.Text, txtPassword.Text);
            if (dt != null && dt.Rows.Count == 1 && (int)dt.Rows[0][0] > 0)
            {
                lblDisplay.Text = "Login Success!";
                Session["LoginID"] = dt.Rows[0][0].ToString();
                Response.Redirect("Home.aspx");
            }

            else
            {
                lblDisplay.Text = "Login Failure";
                Session["LoginID"] = 0;
            }                    
           
        }

       
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtPassword.Text = "";
        }

       
    }
}