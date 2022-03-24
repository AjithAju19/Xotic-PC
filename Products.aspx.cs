using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProductsRepeater();
        }
    }

    /*
    protected void BindProductsRepeater()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("SPBindAllProducts", con);

        cmd.CommandType = CommandType.StoredProcedure; 

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
 

    }

    */
    protected void BindProductsRepeater()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("SPBindAllProducts", con);

        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader sdr = cmd.ExecuteReader();
        
        Repeater1.DataSource = sdr;
        Repeater1.DataBind();


    }


}