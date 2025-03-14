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
    public partial class forgetpassword : System.Web.UI.Page
    {
        static string s = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(s);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(" select * from register where username = '" + TextBox1.Text + "'and que='" + DropDownList1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ans = dt.Rows[0]["ans"].ToString();
            if (TextBox2.Text == ans)
            {
                Label1.Text = dt.Rows[0]["password"].ToString();
            }
            else
            {
                Label1.Text = "Invalid Your Ans";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            Response.Redirect("index.aspx");
        }
    }
}