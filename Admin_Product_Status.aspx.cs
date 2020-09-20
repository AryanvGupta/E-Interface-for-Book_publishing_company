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
    public partial class Admin_Product_Status : System.Web.UI.Page
    {

        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Edit
        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
                        
        }

        // Update
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        // Cancel
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox textBox3 = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox textBox4 = GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
            Label label1 = GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;

            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update Product_Status set Package_Status=@PS, Tenitive_Delivery_Date=@TDD where Order_Id=@Id";

            cmd.Parameters.AddWithValue("@PS", textBox3.Text);
            cmd.Parameters.AddWithValue("@TDD", textBox4.Text);
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(label1.Text));
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {

        }
    }
}