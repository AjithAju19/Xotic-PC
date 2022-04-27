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
        if (Session["email"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BuyNow"] == "YES")
                {

                }
                BindProductsRepeater();
                BindCartNumber();

            }
        }
        else
        {
            if (Request.QueryString["BuyNow"] == "YES")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
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

        SqlCommand cmd = new SqlCommand("SP_BindAllProducts", con);

        cmd.CommandType = CommandType.StoredProcedure;

        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            if (dt.Rows.Count <= 0)
            {
                Label1.Text = "Sorry! Currently no products in this category.";
            }
            else
            {
                Label1.Text = "Showing All Products";
            }
        }
    

}

    protected void btnCart2_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Cart.aspx");
    }

    public void BindCartNumber()
    {
        if (Session["email"] != null)
        {
            string email = Session["email"].ToString();
            DataTable dt = new DataTable();
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();
            {
                SqlCommand cmd = new SqlCommand("SP_BindCartNumbers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Email", email);
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
                        // _ = CartBadge.InnerText == 0.ToString();
                        CartBadge.InnerText = "0";
                    }
                }
            }
        }
    }



}