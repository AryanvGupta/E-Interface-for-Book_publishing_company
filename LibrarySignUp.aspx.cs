using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace Project__25M_
{
    public partial class LibrarySignUp : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_library_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand insert_cmd = new SqlCommand();

            insert_cmd.Connection = con;
            insert_cmd.CommandText = "Insert into library_info values(@Id, @Name, @Email, @NoR, @Contact, @Address, @City, @State, @Password)";

            Random r = new Random();
            int id = r.Next(0000, 9999);
            string password = TextBox8.Text + id.ToString();

            insert_cmd.Parameters.AddWithValue("@Id", id);
            insert_cmd.Parameters.AddWithValue("@Name", TextBox8.Text);
            insert_cmd.Parameters.AddWithValue("@Email", TextBox7.Text);
            insert_cmd.Parameters.AddWithValue("@NoR", TextBox6.Text);
            insert_cmd.Parameters.AddWithValue("@Contact", TextBox9.Text);
            insert_cmd.Parameters.AddWithValue("@State", DropDownList3.Text);
            insert_cmd.Parameters.AddWithValue("@City", TextBox12.Text);
            insert_cmd.Parameters.AddWithValue("@Address", TextBox10.Text);
            insert_cmd.Parameters.AddWithValue("@Password", password);

            con.Open();
            insert_cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into user_info values(@Id, @Name, @password, @Type)";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", TextBox8.Text);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Type", "Libaray");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            /* int id = 1;
             string password = "abc";*/

            MailMessage mail = new MailMessage();
            SmtpClient smtpsrvr = new SmtpClient("smtp.gmail.com"); // port address, port no., credentials
            mail.From = new MailAddress("autowareautomation@gmail.com");
            mail.To.Add(TextBox7.Text);
            /*mail.To.Add("18103519@nuv.ac.in");*/
            mail.Subject = "Welcome to Invincible Publications - Online Portal for Libaries";
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + TextBox8.Text + ",<br/><br/>");
            //sbEmailBody.Append("You Service for Ca <br.Text + "</b> has been Booked and will be soon taken under processing<br/>");
            sbEmailBody.Append("UserId : <b>" + id.ToString() + "</b>");
            sbEmailBody.Append("<br/>Password : <b>" + password + "</b>");


            sbEmailBody.Append("<br><i>Thankyou </i>");

            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Invincible Publication Co. </b>");
            mail.IsBodyHtml = true;
            mail.Body = sbEmailBody.ToString();
            smtpsrvr.Port = 587;
            smtpsrvr.Credentials = new System.Net.NetworkCredential("autowareautomation@gmail.com", "auto$1234");
            smtpsrvr.EnableSsl = true; // security layer
            smtpsrvr.Send(mail); // send mail

            Response.Redirect("LogIn.aspx");
        }
    }
}