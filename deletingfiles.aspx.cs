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
    public partial class deletingfiles : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int bookID = Convert.ToInt32(btnDelete.CommandArgument);
            string fileName = GetFileName(bookID);

            if (!string.IsNullOrEmpty(fileName))
            {
                // Delete the file from the server
                string filePath = Server.MapPath("~/Books/") + fileName;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Delete the record from the database
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE BookID = @BookID", connection);
                    cmd.Parameters.AddWithValue("@BookID", bookID);
                    cmd.ExecuteNonQuery();
                }

                // Rebind the GridView
                BindBooks();
            }
        }

        private string GetFileName(int bookID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FileName FROM Books WHERE BookID = @BookID", connection);
                cmd.Parameters.AddWithValue("@BookID", bookID);
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