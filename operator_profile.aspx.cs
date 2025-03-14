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
    public partial class operator_profile : System.Web.UI.Page
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
            data();
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
        public void data()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select username,gender,mob,address,doj from register where id=" + ID + "", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "register");
            TextBox1.Text = ds.Tables["register"].Rows[0]["username"].ToString();
            TextBox2.Text = ds.Tables["register"].Rows[0]["gender"].ToString();
            TextBox3.Text = ds.Tables["register"].Rows[0]["mob"].ToString();
            TextBox4.Text = ds.Tables["register"].Rows[0]["address"].ToString();
            TextBox5.Text = ds.Tables["register"].Rows[0]["doj"].ToString();
            con.Close();
        }
    }
}