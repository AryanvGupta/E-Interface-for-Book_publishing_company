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
    public partial class confirm_order : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label11.Text = Session["Product"].ToString();
            String name = Request.QueryString["username"];
            Label13.Text = name;
        }

        // Order
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand insert_cmd = new SqlCommand();
            insert_cmd.CommandText = "Insert into Product_Status values(@UserId, @UserName, @State, @City, @Address, '', '', @ProductName, @Image, @Quantity, @Amount)";
            insert_cmd.Connection = con;

            id = Session["UserId"].ToString();

            insert_cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());
            String name = Request.QueryString["username"];
            insert_cmd.Parameters.AddWithValue("@UserName", name);
            insert_cmd.Parameters.AddWithValue("@State", DropDownList1.SelectedValue.ToString());
            insert_cmd.Parameters.AddWithValue("@City", DropDownList2.SelectedValue.ToString());
            insert_cmd.Parameters.AddWithValue("@Address", TextBox5.Text);
            insert_cmd.Parameters.AddWithValue("@ProductName", Session["Product"].ToString());
            insert_cmd.Parameters.AddWithValue("@Image", Session["Image"].ToString());
            insert_cmd.Parameters.AddWithValue("@Quantity", TextBox6.Text);
            string amount = (Convert.ToInt32(TextBox6.Text) * 125).ToString();
            insert_cmd.Parameters.AddWithValue("@Amount", amount);

            con.Open();
            insert_cmd.ExecuteNonQuery();
            con.Close();


            Response.Write("<script>alert('Your Order is placed');</script>");


            SqlCommand cmd = new SqlCommand("Select * from user_info where User_Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();

            string type = ds.Tables[0].Rows[0]["User_Type"].ToString();

            if (type == "Student")
                Response.Redirect("Store.aspx");
            else if (type == "Libaray")
                Response.Redirect("LibraryInterface.aspx");
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            string amount = (Convert.ToInt32(TextBox6.Text) * 125).ToString();
            Label15.Text = "Rs. " + amount;
        }
    }
}
