using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Toll_System
{
    public partial class operator_change_password : System.Web.UI.Page
    {
        static string s = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(s);
        string ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                Label1.Text = "Welcome to..." + Session["name"];
            }
            ID = Session["id"].ToString();
            photobind();
        }
        public void photobind()
        {
            string name = (string)Session["name"];
            SqlCommand cmd = new SqlCommand("select photo from register where username='" + name + "' and id=" + ID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            adp.SelectCommand = cmd;
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // change pass
            con.Open();
            SqlCommand cmd = new SqlCommand("select password from register where id='" + ID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string pass = dt.Rows[0]["password"].ToString();
            if (TextBox1.Text == pass)
            {
                SqlCommand cmd1 = new SqlCommand("update register set password='" + TextBox2.Text + "', confimpass='" + TextBox3.Text + "' where id='" + ID + "'", con);
                cmd1.ExecuteNonQuery();
                Label2.Text = "Password Update Sucessfull";
                Response.Redirect("index.aspx");
            }
            else
            {
                Label2.Text = "Enter Correct old password";
            }
            con.Close();
        }
    }
}