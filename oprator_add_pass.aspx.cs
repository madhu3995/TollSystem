using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Toll_System
{
    public partial class oprator_add_pass : System.Web.UI.Page
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
            TextBox9.Text = Session["name"].ToString();
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
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select amt from add_fare_pass where vtype=@p1 AND ptype=@p2", con);
            cmd.Parameters.AddWithValue("@p1", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@p2", DropDownList3.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox6.Text = dr[0].ToString();
            }
            if (DropDownList3.Text == "Month")
            {
                DateTime dt = DateTime.Now;
                TextBox7.Text = dt.ToString();
                TextBox8.Text = dt.AddDays(30).ToString();
            }
            else if (DropDownList3.Text == "Quatarly")
            {
                DateTime dt = DateTime.Now;
                TextBox7.Text = dt.ToString();
                TextBox8.Text = dt.AddDays(90).ToString();
            }
            else
            {
            }
            dr.Close();
            con.Close();
            TextBox9.Text = Session["name"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Add_pass values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)";
            cmd.Parameters.AddWithValue("@p1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", TextBox2.Text);
            cmd.Parameters.AddWithValue("@p3", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@p4", TextBox3.Text);
            cmd.Parameters.AddWithValue("@p5", TextBox4.Text);
            cmd.Parameters.AddWithValue("@p6", TextBox5.Text);
            cmd.Parameters.AddWithValue("@p7", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@p8", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@p9", TextBox6.Text);
            cmd.Parameters.AddWithValue("@p10", TextBox7.Text);
            cmd.Parameters.AddWithValue("@p11", TextBox8.Text);
            cmd.Parameters.AddWithValue("@p12", TextBox9.Text);
            cmd.ExecuteNonQuery();
            Label2.Text = "Pass Added Successfully!!!!!";
            con.Close();

            // Create a MailMessage instance
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            try
            {
                // Recipient email
                string str = TextBox4.Text;
                msg.To.Add(str);

                // Email properties
                msg.IsBodyHtml = true;
                msg.From = new MailAddress("madhuri19test@gmail.com", "Max Jobs", System.Text.Encoding.UTF8);
                msg.Subject = "Notification Toll Plaza Pass";
                msg.BodyEncoding = System.Text.Encoding.UTF8;

                // Build email body
                string body = "Dear Customer,<br /><br />";
                body += "Please do not reply back to this mail. This is only an auto responder.<br /><br />";
                body += "<table style='border-collapse:collapse; width:500px;' cellspacing='2' align='center'>";
                body += "<tr style='background-color:#a7a7a7;'><td colspan='3' align='center'><strong>Paid Pass Details</strong></td></tr>";
                body += $"<tr style='background-color:#CCCCCC;'><td>Customer Name</td><td align='center'>:</td><td>{TextBox1.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>Mobile No</td><td align='center'>:</td><td>{TextBox2.Text}</td></tr>";
                body += $"<tr style='background-color:#CCCCCC;'><td>Address</td><td align='center'>:</td><td>{TextBox3.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>Email ID</td><td align='center'>:</td><td>{TextBox4.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>Vehicle No</td><td align='center'>:</td><td>{TextBox5.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>Vehicle Type</td><td align='center'>:</td><td>{DropDownList2.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>Pass Type</td><td align='center'>:</td><td>{DropDownList3.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>Fare</td><td align='center'>:</td><td>{TextBox6.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>Start Date</td><td align='center'>:</td><td>{TextBox7.Text}</td></tr>";
                body += $"<tr style='background-color:#EEEEEE;'><td>End Date</td><td align='center'>:</td><td>{TextBox8.Text}</td></tr>";
                body += "</table>";
                msg.Body = body;

                // Configure SMTP client
                SmtpClient client = new SmtpClient
                {
                    Credentials = new NetworkCredential("madhuri19test@gmail.com", "hrhv toza biul uuci"), 
                    Port = 587,
                    EnableSsl = true,
                    Host = "smtp.gmail.com"
                };

                // Send email
                client.Send(msg);
                Response.Write(@"<script>alert('Customer Send Pass To Email ID')</script>");
                Label3.Text = "Mail sent successfully.";
                Label3.ForeColor = System.Drawing.Color.Green;
            }
            catch (SmtpException smtpEx)
            {
                Response.Write(@"<script>alert('Error: Cannot send email.')</script>");
                Label3.Text = $"Error sending mail: {smtpEx.Message}";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                Response.Write(@"<script>alert('Error: Cannot send email.')</script>");
                Label3.Text = $"An unexpected error occurred: {ex.Message}";
                Label3.ForeColor = System.Drawing.Color.Red;
            }

            Label2.Text = "Add Pass Success.";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }
    }
}