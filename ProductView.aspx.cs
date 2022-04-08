using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ProductView : System.Web.UI.Page
{
    public static string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            if (!IsPostBack)
            {
                BindProductImage();
                BindProductDetails();
            }
        }

        else
            Response.Redirect("~/Products.aspx");

    }

    protected void BindProductImage()
    {
        Int64 pid = Convert.ToInt64(Request.QueryString["pid"]);

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("select * from ProductsImages where pid = '"+pid+"'", con);

        cmd.CommandType = CommandType.Text;

        SqlDataReader sdr = cmd.ExecuteReader();

        rptrImage.DataSource = sdr;
        rptrImage.DataBind();


    }


    protected void BindProductDetails()
    {
        Int64 pid = Convert.ToInt64(Request.QueryString["pid"]);

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("select * from Products where pid = '" + pid + "'", con);

        cmd.CommandType = CommandType.Text;

        SqlDataReader sdr = cmd.ExecuteReader();

        rptrProductDetails.DataSource = sdr;
        rptrProductDetails.DataBind();


    }


    protected string GetActiveImgClass(int ItemIndex)
    {
        if (ItemIndex == 0)
        {
            return "active";
        }

        else
            return "";
    }

    #region rptrProductDetails_ItemDataBound

    protected void rptrProductDetails_ItemDataBound(object sender,RepeaterItemEventArgs e)
    {

    }

    #endregion 

}