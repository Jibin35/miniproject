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
    public partial class adminupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView1.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("INSERT INTO QP (Code,Scheme,EMonth,EYear,FilePath) VALUES (@Code,@Scheme,@EMonth,@EYear,@FileName)", connection);
                        cmd.Parameters.AddWithValue("@Code", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Scheme", DropDownList1.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@EMonth", DropDownList2.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@EYear", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@FileName", uniqueFileName);
                        cmd.ExecuteNonQuery();
                    }
                    string filePath = Server.MapPath("~/QPs/") + uniqueFileName;
                    fileUpload.SaveAs(filePath);
                    GridView1.DataBind();
                    Response.Write("<script>alert('File Uploaded Successfully');</script>");
                }
                else
                {
                    // Handle invalid file type
                    Response.Write("<script>alert('Error');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Error');</script>");
            }
        }
        private string GetUniqueFileName(string fileName)
        {
            string uniqueFileName = fileName;
            int count = 1;
            string filePath = Server.MapPath("~/QPs/") + uniqueFileName;
            while (File.Exists(filePath))
            {
                string extension = Path.GetExtension(fileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                uniqueFileName = $"{fileNameWithoutExtension}_{count}{extension}";
                filePath = Server.MapPath("~/QPs/") + uniqueFileName;
                count++;
            }

            return uniqueFileName;
        }


    }
}