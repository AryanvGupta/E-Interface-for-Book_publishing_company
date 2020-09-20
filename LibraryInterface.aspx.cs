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
    public partial class LibraryInterface : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Flag"] == null)
                { Session["Flag"] = true;  transfer(); }
                else
                    Session["Flag"] = null;
            }
        }

        protected void transfer()
        {
            String name = Request.QueryString["username"];

            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Product_Status where User_Id='" + Session["UserId"] + "'", con);

            DataSet ds = new DataSet();
            da.Fill(ds);

            DropDownList3.Items.Add("--select--");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (ds.Tables[0].Rows[i]["Products"] != null)
                    {
                        DropDownList3.Items.Add(ds.Tables[0].Rows[i]["Products"].ToString());
                    }
                }
                else
                {
                    Label22.Text = "You have not made any purchase yet..!";
                }
            }
            //DropDownList3.DataBind();
        }

        // Magazines
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            String name = Request.QueryString["username"];
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            if (c.Checked)
            {
                string s = (row.Cells[0].FindControl("Label1") as Label).Text;
                Session["Magazine_Id"] = s;
            }

            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from magazine_info where Magazine_Id='" + Session["Magazine_Id"] + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Session["Product"] = ds.Tables[0].Rows[0]["Magazine_Name"].ToString();
            Session["Image"] = ds.Tables[0].Rows[0]["Magazine_Image"].ToString();

            Response.Redirect("confirm_order.aspx?username=" + name);
        }

        // Books
        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            String name = Request.QueryString["username"];
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            if (c.Checked)
            {
                string s = (row.Cells[0].FindControl("Label1") as Label).Text;
                Session["Book_Id"] = s;
            }

            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from book_info where Book_Id='" + Session["Book_Id"] + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Session["Product"] = ds.Tables[0].Rows[0]["Book_Name"].ToString();
            Session["Image"] = ds.Tables[0].Rows[0]["Book_Image"].ToString();

            Response.Redirect("confirm_order.aspx?username=" + name);
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = Request.QueryString["username"];
            id = Session["UserId"].ToString();
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Product_Status where User_Id='" + id + "'", con);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (DropDownList3.SelectedValue.ToString() == ds.Tables[0].Rows[i]["Products"].ToString())
                {
                    Label29.Text = "";
                    Label23.Text = ds.Tables[0].Rows[i]["Order_Id"].ToString();
                    Label25.Text = ds.Tables[0].Rows[i]["Products"].ToString();
                    Label10.Text = ds.Tables[0].Rows[i]["Package_Status"].ToString();
                    Label27.Text = ds.Tables[0].Rows[i]["Tenitive_Delivery_Date"].ToString();
                    Label16.Text = "Rs. " + ds.Tables[0].Rows[i]["Amount"].ToString();
                    Image4.Visible = true;
                    Image4.ImageUrl = ds.Tables[0].Rows[i]["Products_Image"].ToString();
                    break;
                }
                else
                {
                    Label23.Text = "";
                    Label25.Text = "";
                    Label27.Text = "";
                    Label10.Text = "";
                    Label16.Text = "";
                    Image4.Visible = false;
                    Label29.Text = "No Value is Selected...!";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}