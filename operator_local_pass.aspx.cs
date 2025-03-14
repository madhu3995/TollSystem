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
    public partial class operator_local_pass : System.Web.UI.Page
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
            TextBox6.Text = Session["name"].ToString();
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
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into add_pass_local values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            cmd.Parameters.AddWithValue("@p1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", TextBox2.Text);
            cmd.Parameters.AddWithValue("@p3", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@p4", TextBox3.Text);
            cmd.Parameters.AddWithValue("@p5", TextBox4.Text);
            cmd.Parameters.AddWithValue("@p6", TextBox5.Text);
            cmd.Parameters.AddWithValue("@p7", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@p8", TextBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label2.Text = "Local Pass Added Successfully!!!!";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            Label2.Text = "";
        }
    }
}