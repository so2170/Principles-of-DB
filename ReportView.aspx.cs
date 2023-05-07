using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NYUProject.Pages
{
    public partial class ReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

            if (Session["LoginID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
       

            if (!IsPostBack)
            { 
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");



                    // Set the data source for the report
                    // The data source should be a collection of objects
                    SqlDataAccess s = new SqlDataAccess();
                    DataTable dt = new DataTable();

                    dt = s.Execute("select * from RetireePayView");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));


                    // Refresh the report viewer to display the report
                    ReportViewer1.LocalReport.Refresh();

                    //// Render the report to a byte array in PDF format
                    //byte[] pdfBytes = reportViewer.LocalReport.Render("PDF");

                    ////// Return the PDF file to the browser as a file download
                    //Response.ContentType = "application/pdf";
                    //Response.AddHeader("content-disposition", "attachment;filename=MyReport.pdf");
                    //Response.BinaryWrite(pdfBytes);
                    //Response.Flush();
                    //Response.End();
            }

        }
    }
}