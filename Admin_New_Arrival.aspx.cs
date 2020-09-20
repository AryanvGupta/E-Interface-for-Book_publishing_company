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
    public partial class Admin_New_Arrival : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Delete
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chck = gvrow.FindControl("CheckBox1") as CheckBox;
                if (chck.Checked)
                {
                    var Label = gvrow.FindControl("Label1") as Label;

                    SqlCommand cmd = new SqlCommand("delete from New_Arrival where Item_Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(Label.Text));
                    con.Open();
                    int id = cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
            }
        }

        // Insert
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textbox6 = GridView1.FooterRow.Cells[1].FindControl("TextBox6") as TextBox;
            TextBox textbox14 = GridView1.FooterRow.Cells[1].FindControl("TextBox14") as TextBox;
            TextBox textbox13 = GridView1.FooterRow.Cells[1].FindControl("TextBox13") as TextBox;
            TextBox textbox12 = GridView1.FooterRow.Cells[1].FindControl("TextBox12") as TextBox;
            TextBox textbox11 = GridView1.FooterRow.Cells[1].FindControl("TextBox11") as TextBox;

            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand insert_cmd = new SqlCommand("Insert into New_Arrival values(@Id, @Name, @Type, @Author, @Image);",con);
            insert_cmd.Parameters.AddWithValue("@Id",textbox6.Text);
            insert_cmd.Parameters.AddWithValue("@Name", textbox14.Text);
            insert_cmd.Parameters.AddWithValue("@Type", textbox13.Text);
            insert_cmd.Parameters.AddWithValue("@Author", textbox12.Text);
            insert_cmd.Parameters.AddWithValue("@Image", textbox11.Text);

            con.Open();
            insert_cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }
    }
}