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


    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {

        Int64 PID = Convert.ToInt64(Request.QueryString["pid"]);

        if (Request.Cookies["CartPID"] != null)
        {
            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
            CookiePID = CookiePID + "," + PID + "-" ;

            HttpCookie CartProducts = new HttpCookie("CartPID");
            CartProducts.Values["CartPID"] = CookiePID;
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);
        }
        else
        {
            HttpCookie CartProducts = new HttpCookie("CartPID");
            CartProducts.Values["CartPID"] = PID.ToString() + "-" ;
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);
        }

        Response.Redirect("~/ProductView.aspx?pid=" + PID);

    }


    #region rptrProductDetails_ItemDataBound

    protected void rptrProductDetails_ItemDataBound(object sender,RepeaterItemEventArgs e)
    {




    }

    #endregion 
/*
    public void BindCartNumber()
    {
        if (Session["USERID"] != null)
        {
            string UserIDD = Session["USERID"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SP_BindCartNumberz", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserIDD);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                        CartBadge.InnerText = CartQuantity;

                    }
                    else
                    {
                        CartBadge.InnerText = 0.ToString();
                    }
                }
            }
        }
    }



*/


}