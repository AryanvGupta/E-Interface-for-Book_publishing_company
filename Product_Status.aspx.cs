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
    public partial class Product_Status : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                transfer();
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

            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
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
            DropDownList3.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = Request.QueryString["username"];


            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Product_Status where User_Id='" + Session["UserId"] + "'", con);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int i;
            for(i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                if (DropDownList3.SelectedValue.ToString() == ds.Tables[0].Rows[i]["Products"].ToString())
                {
                    Label22.Text = "";
                    Label4.Text = ds.Tables[0].Rows[i]["Order_Id"].ToString();
                    Label6.Text = ds.Tables[0].Rows[i]["Products"].ToString();
                    Label8.Text = ds.Tables[0].Rows[i]["Package_Status"].ToString();
                    Label10.Text = ds.Tables[0].Rows[i]["Tenitive_Delivery_Date"].ToString();
                    Label16.Text = "Rs. " + ds.Tables[0].Rows[i]["Amount"].ToString();
                    Image1.Visible = true;
                    Image1.ImageUrl = ds.Tables[0].Rows[i]["Products_Image"].ToString();
                    break;
                }
                else
                {
                    Label4.Text = "";
                    Label6.Text = "";
                    Label8.Text = "";
                    Label10.Text = "";
                    Label16.Text = "";
                    Image1.Visible = false;
                    Label22.Text = "No Value is Selected...!";
                }
            }
        }
    }
}