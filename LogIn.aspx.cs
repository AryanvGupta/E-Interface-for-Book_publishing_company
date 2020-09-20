using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;
using AjaxControlToolkit.HtmlEditor.Popups;

namespace Project__25M_
{
    public partial class LogIn : System.Web.UI.Page
    {

        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        String User_name;
        int User_Id;
        string x;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if(x == "true")
            {
                Label1.Text = "Error";o
            }
            x = "false";*/
        }

        protected void staff_login_Click(object sender, EventArgs e)
        {
            UpdatePanel_student.Visible = false;
            UpdatePanel_staff.Visible = true;
            UpdatePanel_instute.Visible = false;
        }

        protected void student_login_Click(object sender, EventArgs e)
        {
            UpdatePanel_student.Visible = true;
            UpdatePanel_staff.Visible = false;
            UpdatePanel_instute.Visible = false;
        }

        protected void institute_login_Click1(object sender, EventArgs e)
        {
            UpdatePanel_student.Visible = false;
            UpdatePanel_staff.Visible = false;
            UpdatePanel_instute.Visible = true;
        }

        // student
        protected void submit_student_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("Select * from user_info where User_Id = @Id and User_Password = @Pass and User_Type = 'Student'", con);
            cmd.Parameters.AddWithValue("@Id", TextBox_studentid.Text);
            cmd.Parameters.AddWithValue("@Pass", TextBox_stupassword.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(ds);
            con.Close();

            if(ds.Tables[0].Rows.Count == 0)
            {
                //x = "true";

                //ErrorMessage.Text = "Sorry your credentials are wrong";

                //Response.Write("<script>alert('Sorry your credentials are wrong');</script>");
                string script = "alert(\"Sorry your credentials are wrong\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                //String name = Request.QueryString["username"];
            }
            else
            {
                Session["UserId"] = TextBox_studentid.Text;
                User_Id = Convert.ToInt32(Session["UserId"].ToString());
                User_name = ds.Tables[0].Rows[0]["User_Name"].ToString();
                Session["UserName"] = User_name;
                Response.Redirect("StudentInterface.aspx");
                //Response.Redirect("StudentInterface.aspx?username=" + User_name);
            }
            /*else
            {
                Response.Write("<script language=javascript>alert('ERROR');</script>");
            }*/            
        }

        // library
        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("Select * from user_info where User_Id = @Id and User_Password = @Pass and User_Type = 'Libaray'", con);
            cmd.Parameters.AddWithValue("@Id", TextBox_instituteid.Text);
            cmd.Parameters.AddWithValue("@Pass", TextBox_inspassword.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert(\"Sorry your credentials are wrong\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                Session["UserId"] = TextBox_instituteid.Text;
                User_name = ds.Tables[0].Rows[0]["User_Name"].ToString();                                               
                Session["UserName"] = User_name;
                Response.Redirect("LibraryInterface.aspx?username=" + User_name);
            }
        }

        // Admin
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("Select * from user_info where User_Id = @Id and User_Password = @Pass and User_Type = 'Admin'", con);
            cmd.Parameters.AddWithValue("@Id", TextBox_staffid.Text);
            cmd.Parameters.AddWithValue("@Pass", TextBox_staffpassword.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                string script = "alert(\"Sorry your credentials are wrong\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                Session["UserId"] = TextBox_staffid.Text;
                User_name = ds.Tables[0].Rows[0]["User_Name"].ToString();
                Session["UserName"] = User_name;
                Response.Redirect("Admin_Weekly_Sugg.aspx?username=" + User_name);
            }
        }
    }
}