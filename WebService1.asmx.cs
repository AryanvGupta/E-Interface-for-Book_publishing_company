using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AjaxControlToolkit;

namespace Project__25M_
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        //Web method for bind state
        [WebMethod]
        public CascadingDropDownNameValue[] BindState(string knownCategoryValues, string category)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataSet ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from State", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adp.Fill(ds);
            conn.Close();
            List<CascadingDropDownNameValue> StateDetails = new List<CascadingDropDownNameValue>();
            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                string stateID = DR["State_Id"].ToString();
                string stateName = DR["State_Name"].ToString();
                StateDetails.Add(new CascadingDropDownNameValue(stateName, stateID));
            }
            return StateDetails.ToArray();
        }
        //Web method for bind city
        [WebMethod]
        public CascadingDropDownNameValue[] BindCity(string knownCategoryValues, string category)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataSet ds = new DataSet();
            int StateID;
            StringDictionary StateDetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            StringDictionary d = new StringDictionary();
            string s = "0"; //Default State
            if (knownCategoryValues.Length == 8)
                s = knownCategoryValues.Substring(6, 1);
            else if (knownCategoryValues.Length == 9)
                s = knownCategoryValues.Substring(6, 2);

            StateID = Convert.ToInt32(s);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Cities where State_Id=@StateID", conn);
            cmd.Parameters.AddWithValue("@StateID", StateID);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            conn.Close();
            List<CascadingDropDownNameValue> CityDetails = new List<CascadingDropDownNameValue>();
            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                string cityID = DR["City_Id"].ToString();
                string cityName = DR["City_Name"].ToString();
                CityDetails.Add(new CascadingDropDownNameValue(cityName, cityID));
            }
            return CityDetails.ToArray();
        }


    }
}
