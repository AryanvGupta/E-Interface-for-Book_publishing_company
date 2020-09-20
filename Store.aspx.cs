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
    public partial class Store : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        // Order
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand insert_cmd = new SqlCommand();
            insert_cmd.CommandText = "Insert into Product_Status values(@UserId, @Name, '', '', @Product, @Image, @Quantity, @Amount);";
            insert_cmd.Connection = con;

            int amount = Convert.ToInt32(TextBox7.Text) * 100;
            insert_cmd.Parameters.AddWithValue("@UserId", TextBox5.Text);
            insert_cmd.Parameters.AddWithValue("@Name", TextBox6.Text);
            insert_cmd.Parameters.AddWithValue("@Quantity", TextBox7.Text);
            
            if (Session["Product"] != null)
                insert_cmd.Parameters.AddWithValue("@Product", Session["Product"].ToString());
            
            insert_cmd.Parameters.AddWithValue("@Image", Session["Image"].ToString());
            insert_cmd.Parameters.AddWithValue("@Amount", amount);
            con.Open();
            insert_cmd.ExecuteNonQuery();
            con.Close();
            
            Response.Write("alert('Your Order is placed');return true;");
        //Name: "+ TextBox6.Text + " < br > Product:"+ Session["Product"].ToString() + " < br > Quantity:"+ TextBox7.Text + "
            //Session["Product"] = null;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;
            if (c.Checked)
            {
                string username = Session["UserName"].ToString();
                Session["Product"] = (row.Cells[1].FindControl("Label2") as Label).Text;
                Session["Image"] = (row.Cells[4].FindControl("Image1") as Image).ImageUrl;
                Response.Redirect("confirm_order.aspx?username=" + username);
            }
            else
                UpdatePanel2.Visible = false;
        }
    }
}
