using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAM
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; 
                    LinkButton2.Visible = true; 

                    LinkButton3.Visible = false; 
                    LinkButton7.Visible = false; 


                    LinkButton6.Visible = true; 
                    LinkButton11.Visible = false; 
                    LinkButton12.Visible = false;
                    LinkButton13.Visible = false;
                    LinkButton10.Visible = false;

                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; 
                    LinkButton2.Visible = false; 

                    LinkButton3.Visible = true; 
                    LinkButton7.Visible = true; 
                    LinkButton7.Text = "Hello " + Session["username"].ToString();


                    LinkButton6.Visible = true; 
                    LinkButton11.Visible = false; 
                    LinkButton12.Visible = false; 
                    LinkButton13.Visible = false;
                    LinkButton10.Visible = false;

                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; 
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true; 
                     
                    LinkButton7.Visible = false;
                    LinkButton10.Visible = true;


                    LinkButton6.Visible = false; 
                    LinkButton11.Visible = true; 
                    LinkButton12.Visible = true; 
                    LinkButton13.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminusermanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminupload.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("admindelete.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";           
            Session["role"] = "";

            LinkButton1.Visible = true; 
            LinkButton2.Visible = true; 

            LinkButton3.Visible = false; 
            LinkButton7.Visible = false; 


            LinkButton6.Visible = true; 
            LinkButton11.Visible = false; 
            LinkButton12.Visible = false; 
            LinkButton13.Visible = false;

            Response.Redirect("homepage.aspx");

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}