using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAM
{
    public partial class uploading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string fileName = fileUpload.FileName;
                string uniqueFileName = GetUniqueFileName(fileName);
                string fileExtension = System.IO.Path.GetExtension(fileName);

                if (fileExtension.ToLower() == ".pdf")
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Books (FileName) VALUES (@FileName)", connection);
                        cmd.Parameters.AddWithValue("@FileName", uniqueFileName);
                        cmd.ExecuteNonQuery();
                    }
                    string filePath = Server.MapPath("~/Books/") + uniqueFileName;
                    fileUpload.SaveAs(filePath);
                }
                else
                {
                    // Handle invalid file type
                }
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            string uniqueFileName = fileName;
            int count = 1;
            string filePath = Server.MapPath("~/Books/") + uniqueFileName;
            while (File.Exists(filePath))
            {
                string extension = Path.GetExtension(fileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                uniqueFileName = $"{fileNameWithoutExtension}_{count}{extension}";
                filePath = Server.MapPath("~/Books/") + uniqueFileName;
                count++;
            }

            return uniqueFileName;
        }
    }
}