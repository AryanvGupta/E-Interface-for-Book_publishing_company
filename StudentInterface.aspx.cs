using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project__25M_
{
    public partial class StudentInterface : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                if (Session["UserName"] != null)
                {
                    Label16.Text = "Welcome " + Session["UserName"].ToString();
                }
            }
           
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton2_Command(object sender, CommandEventArgs e)
        {
            string path = Server.MapPath("~/PDFs/") + e.CommandArgument + ".pdf";
            WebClient wb = new WebClient();
            Byte[] file = wb.DownloadData(path);
            if (file != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", file.Length.ToString());
                Response.BinaryWrite(file);
            }

        }

    }
}