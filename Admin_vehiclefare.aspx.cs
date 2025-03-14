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
    public partial class Admin_vehiclefare : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("select photo from register where username=@name and id=@id", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", ID);
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
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from add_vehicle_fare", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Label2.Text = "Error loading data: " + ex.Message;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into add_vehicle_fare values(@p1,@p2,@p3)";
            cmd.Parameters.AddWithValue("@p1", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@p2", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@p3", TextBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label2.Text = " Fare Added SuccessFully !!!";
            TextBox1.Text = "";
            data();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            // edit
            Button b = sender as Button;
            GridViewRow g = (GridViewRow)b.NamingContainer;
            Label3.Text = GridView2.DataKeys[g.RowIndex].Value.ToString();
            DropDownList3.Text = g.Cells[1].Text;
            DropDownList4.Text = g.Cells[2].Text;
            TextBox2.Text = g.Cells[3].Text;
            this.ModalPopupExtender1.Show();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // update
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update add_vehicle_fare set amt=@p2 where id=@p1";
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt16(Label3.Text));
            cmd.Parameters.AddWithValue("@p2", TextBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label4.Text = " Fare Update Successfully!!!";
            TextBox2.Text = "";
            data();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // delete
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from add_vehicle_fare  where id=@p1";
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt16(Label3.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            Label4.Text = "Fare Deleted Successully";
            TextBox2.Text = "";
            data();
        }
    }
}