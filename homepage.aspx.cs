using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace JAM
{
    public partial class downloading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindBooks();
            }

        }

        private void BindBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM QP", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            LinkButton lnkDownload = (LinkButton)sender;
            string fileName = lnkDownload.CommandArgument;
            string filePath = Server.MapPath("~/QPs/") + fileName;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + EncodeFilename(file.Name) + "\"");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }

        private string EncodeFilename(string filename)
        {
            
            return HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8).Replace("+", "%20");
        }




        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}