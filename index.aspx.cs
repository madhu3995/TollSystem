using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Toll_System
{
    public partial class index : System.Web.UI.Page
    {
        static string s = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(s); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["name"] = TextBox1.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("select username,password,id,status from register ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == "admin" && dr[1].ToString() == TextBox2.Text && dr[3].ToString() == "active")
                {
                    Session["id"] = dr[2].ToString();
                    Response.Redirect("Admin_loginstatus.aspx");
                }
                else if (dr[0].ToString() == TextBox1.Text && dr[1].ToString() == TextBox2.Text && dr[3].ToString() == "active")
                {
                    Session["id"] = dr[2].ToString();
                    Response.Redirect("operator_regular_entry.aspx");
                }
                else
                {
                    Label1.Text = "invalid User name and password";
                }

            }
            con.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgetpassword.aspx");
        }
    }
}