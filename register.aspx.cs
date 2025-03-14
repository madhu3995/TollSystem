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
    public partial class Registration : System.Web.UI.Page
    {
        static string s = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(s);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string gender;
            if (RadioButton1.Checked == true)
            {
                gender = "Male";
            }
            else if (RadioButton2.Checked == true)
            {
                gender = "Female";
            }
            else
            {
                gender = "Other";
            }
            string status = "Inactive";
            con.Open();
            string photo = "photo/" + TextBox1.Text + ".jpg";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into register values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
            cmd.Parameters.AddWithValue("@p1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", TextBox2.Text);
            cmd.Parameters.AddWithValue("@p3", TextBox3.Text);
            cmd.Parameters.AddWithValue("@p4", gender);
            cmd.Parameters.AddWithValue("@p5", TextBox4.Text);
            cmd.Parameters.AddWithValue("@p6", TextBox5.Text);
            cmd.Parameters.AddWithValue("@p7", TextBox6.Text);
            cmd.Parameters.AddWithValue("@p8", photo);
            cmd.Parameters.AddWithValue("@p9", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@p10", TextBox7.Text);
            cmd.Parameters.AddWithValue("@p11", status);

            FileUpload1.SaveAs(Server.MapPath("~//photo//" + TextBox1.Text + ".jpg"));
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Registration Succesfully";
            Response.Redirect("index.aspx");
        }
    }
}