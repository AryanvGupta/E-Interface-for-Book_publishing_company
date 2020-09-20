using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project__25M_
{
    public partial class StudentSignUp : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_students_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand insert_cmd = new SqlCommand();

            insert_cmd.Connection = con;
            insert_cmd.CommandText = "Insert into student_info values(@Id, @Name, @Email, @DoB, @Contact, @Address, @City, @State, @Password)";

            Random r = new Random();
            int id = r.Next(00000, 99999);
            string password = TextBox4.Text + id.ToString();

            insert_cmd.Parameters.AddWithValue("@Id", id);
            insert_cmd.Parameters.AddWithValue("@Name", TextBox4.Text);
            insert_cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            insert_cmd.Parameters.AddWithValue("@DoB", TextBox2.Text);
            insert_cmd.Parameters.AddWithValue("@Contact", TextBox1.Text);
            insert_cmd.Parameters.AddWithValue("@State", DropDownList1.Text);
            insert_cmd.Parameters.AddWithValue("@City", TextBox11.Text);
            insert_cmd.Parameters.AddWithValue("@Address", TextBox5.Text);
            insert_cmd.Parameters.AddWithValue("@Password", password);

            con.Open();
            insert_cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into user_info values(@Id, @Name, @password, @Type)";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Type", "Student");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            /* int id = 1;
             string password = "abc";*/

            MailMessage mail = new MailMessage();
            SmtpClient smtpsrvr = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("autowareautomation@gmail.com");
            mail.To.Add(TextBox3.Text);
            /*mail.To.Add("18103519@nuv.ac.in");*/
            mail.Subject = "Welcome to Online Publication company";
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + TextBox4.Text + ",<br/><br/>");
            //sbEmailBody.Append("You Service for Ca <br.Text + "</b> has been Booked and will be soon taken under processing<br/>");
            sbEmailBody.Append("UserId : <b>" + id.ToString() + "</b>");
            sbEmailBody.Append("<br/>Password : <b>" + password + "</b>");


            sbEmailBody.Append("<br><br><i>All the books/magazines are available at Rs.125 only...ENJOY..! </i>");
            sbEmailBody.Append("<br><br><i>Thankyou </i>");

            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Invincible Publication Co. </b>");
            mail.IsBodyHtml = true;
            mail.Body = sbEmailBody.ToString();
            smtpsrvr.Port = 587;
            smtpsrvr.Credentials = new System.Net.NetworkCredential("autowareautomation@gmail.com", "auto$1234");
            smtpsrvr.EnableSsl = true;
            smtpsrvr.Send(mail);

            Response.Redirect("LogIn.aspx");
        }
    }
}