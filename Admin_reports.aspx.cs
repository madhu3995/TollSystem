using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Toll_System
{
    public partial class Admin_reports : System.Web.UI.Page
    {
        static string s = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(s);
        string ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Label1.Text = "Welcome to..." + Session["name"];
            }
            ID = Session["id"].ToString();
            if (!IsPostBack)
            {
                photobind();
                operatorbind();
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
        void operatorbind()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select username from register", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            data();
        }
        public void data()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from Add_pass where operator_name='" + DropDownList1.Text + "'", con);
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", " collection.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView2.AllowPaging = false;
            data();
            GridView2.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}