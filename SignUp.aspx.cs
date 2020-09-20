using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project__25M_
{
    public partial class SignUp : System.Web.UI.Page
    {

        int i = 101;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aryan Gupta\source\repos\Project(25M)\App_Data\Database1.mdf;Integrated Security=True";
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void insert_student()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            
        }

        protected void Button_individual_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSignUp.aspx");
            /*UpdatePanel_individual.Visible = true;
            UpdatePanel_instutite.Visible = false;*/
        }

        protected void Button_institute_Click(object sender, EventArgs e)
        {
            Response.Redirect("LibrarySignUp.aspx");
            /*UpdatePanel_individual.Visible = false;
            UpdatePanel_instutite.Visible = true;*/
        }

        protected void submit_students_Click(object sender, EventArgs e)
        {
            //PLEASE SAVE THIS ID and PASSWORD FOR FUTURE USE. <br /> Student_Id :S"+i +"<br /> Password : name:"+i+" <br />            
            Response.Write("<script>alert('Hello');</script>");
            i++;
        }

        protected void submit_library_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('PLEASE SAVE THIS ID and PASSWORD FOR FUTURE USE. <br /> Student_Id :S" + i + "<br /> Password : name:" + i + " <br /> ')</script>");
            i++;

        }
    }
}