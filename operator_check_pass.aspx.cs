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
    public partial class operator_check_pass : System.Web.UI.Page
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
            con.Open();
            string str = "select * from Add_pass where vno = '" + TextBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DateTime d = DateTime.Now;
            if (dr.HasRows)
            {
                dr.Read();
                DateTime d1 = Convert.ToDateTime(dr[11]);
                if (DateTime.Compare(d, d1) > 0)
                {
                    Label2.Text = "InValid pass";
                }
                else
                {
                    Label2.Text = "Pass is Valid";
                    dr.Close();
                    SqlDataAdapter adp = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }

            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            Label2.Text = "";
          
        }
    }
}