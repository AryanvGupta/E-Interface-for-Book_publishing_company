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
    public partial class Admin_Weekly_Sugg : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Delete
        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chck = gvrow.FindControl("CheckBox1") as CheckBox;
                if (chck.Checked)
                {
                    var Label = gvrow.FindControl("Label1") as Label;

                    SqlCommand cmd = new SqlCommand("delete from Weekly_Suggestion where Suggestion_Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(Label.Text));

                    try
                    {
                        con.Open();
                        int id = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch
                    {
                        Response.Write("\n\n\n\n Error");
                    }
                    GridView1.DataBind();
                }
            }
        }

        // Insert
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textbox1 = GridView1.FooterRow.Cells[1].FindControl("TextBox1") as TextBox;
            TextBox textbox2 = GridView1.FooterRow.Cells[2].FindControl("TextBox2") as TextBox;
            TextBox textbox3 = GridView1.FooterRow.Cells[3].FindControl("TextBox3") as TextBox;
            TextBox textbox4 = GridView1.FooterRow.Cells[4].FindControl("TextBox4") as TextBox;

            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand insert_cmd = new SqlCommand("Insert into Weekly_Suggestion values(@Name, @Type, @Desc, @Image)", con);
            insert_cmd.Parameters.AddWithValue("@Name", textbox1.Text);
            insert_cmd.Parameters.AddWithValue("@Type", textbox2.Text);
            insert_cmd.Parameters.AddWithValue("@Desc", textbox3.Text);
            insert_cmd.Parameters.AddWithValue("@Image", textbox4.Text);

            
            {
                con.Open();
                insert_cmd.ExecuteNonQuery();
                con.Close();
            }
            
            {
                //Response.Write("\n\n\n\n Error");
            }
            GridView1.DataBind();
        }
    }
} 