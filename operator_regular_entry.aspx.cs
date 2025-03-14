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
    public partial class operator_regular_entry : System.Web.UI.Page
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
            auto();
        }
        public void auto()
        {
            TextBox1.Text = "Om Sai Plaza";
            TextBox3.Text = DateTime.Now.ToString();
            TextBox6.Text = Session["name"].ToString();
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(tno) from regular_entry", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    TextBox2.Text = "1";
                }
                else
                {
                    r = Convert.ToInt32(dr[0].ToString());
                    r = r + 1;
                    TextBox2.Text = r.ToString();
                }
            }
            dr.Close();
            con.Close();
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
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select amt from add_vehicle_fare where vtype=@p1 AND  jtype=@p2", con);
            cmd.Parameters.AddWithValue("@p1", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@p2", DropDownList2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox5.Text = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into regular_entry values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            cmd.Parameters.AddWithValue("@p1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", TextBox2.Text);
            cmd.Parameters.AddWithValue("@p3", TextBox3.Text);
            cmd.Parameters.AddWithValue("@p4", TextBox4.Text);
            cmd.Parameters.AddWithValue("@p5", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@p6", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@p7", TextBox5.Text);
            cmd.Parameters.AddWithValue("@p8", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@p9", TextBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label2.Text = "Record Added Successfully !!!";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            auto();
        }
    }
}