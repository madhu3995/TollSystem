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
    public partial class Admin_loginstatus : System.Web.UI.Page
    {
        static string s = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(s);
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
            if (Session["id"] != null)
            {
                ID = Session["id"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                photobind();
                data();
            }
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
            SqlDataAdapter adp = new SqlDataAdapter("select * from register ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            GridViewRow g = (GridViewRow)b.NamingContainer;
            TextBox1.Text = GridView2.DataKeys[g.RowIndex].Value.ToString();
            TextBox2.Text = g.Cells[1].Text;
            TextBox3.Text = g.Cells[2].Text;
            TextBox4.Text = g.Cells[3].Text;
            TextBox5.Text = g.Cells[5].Text;
            this.ModalPopupExtender1.Show();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update register set status='" + TextBox5.Text + "' where id=" + TextBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            data();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from register  where id=" + TextBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            data();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
          
        }
    }
}