using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace JAM
{
    public partial class admindelete : System.Web.UI.Page
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


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            int SI_No = Convert.ToInt32(btnDelete.CommandArgument);
            string fileName = GetFileName(SI_No);

            if (!string.IsNullOrEmpty(fileName))
            {
                // Delete the file from the server
                string filePath = Server.MapPath("~/QPs/") + fileName;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Delete the record from the database
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM QP WHERE SI_No = @SI_No", connection);
                    cmd.Parameters.AddWithValue("@SI_No", SI_No);
                    cmd.ExecuteNonQuery();
                }

                // Rebind the GridView
                BindBooks();
            }
        }

        private string GetFileName(int SI_No)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FilePath FROM QP WHERE SI_No = @SI_No", connection);
                cmd.Parameters.AddWithValue("@SI_No", SI_No);
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
            }
            return null;

        }
    }
}