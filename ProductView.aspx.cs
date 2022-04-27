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
    Int32 myQty = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            if (!IsPostBack)
            {
                divSuccess.Visible = false;
                BindProductImage();
                BindProductDetails();
                BindCartNumber();
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

        SqlCommand cmd = new SqlCommand("select * from ProductsImages where pid = '" + pid + "'", con);

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

        SqlCommand cmd = new SqlCommand("SP_BindProductDetails", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@PID", pid);
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrProductDetails.DataSource = dt;
            rptrProductDetails.DataBind();
            Session["CartPID"] = Convert.ToInt32(dt.Rows[0]["PID"].ToString());
            Session["myPName"] = dt.Rows[0]["PName"].ToString();
            Session["myPPrice"] = dt.Rows[0]["price"].ToString();
            Session["myPSelPrice"] = dt.Rows[0]["sellingprice"].ToString();
        }

    
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
        AddToCartProduction();
        Response.Redirect("~/ProductView.aspx?pid=" + PID);

    }


    /*
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
            CartProducts.Values["CartPID"] = PID.ToString() + "-";
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);
        }

        Response.Redirect("~/ProductView.aspx?pid=" + PID);

    }

    */

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


    public void BindCartNumber()
    {
        if (Session["email"] != null)
        {
            string email = Session["email"].ToString();

            DataTable dt = new DataTable();

            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();

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
                        CartBadge.InnerText = 0.ToString();
                    }
                }
            
        }
    }

    private void AddToCartProduction()
    {
        if (Session["email"] != null)
        {
            string email = Session["email"].ToString();
            Int64 PID = Convert.ToInt64(Request.QueryString["pid"]);

            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_IsProductExistInCart", con)
            {
                    CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@PID", PID);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                        SqlCommand myCmd = new SqlCommand("SP_UpdateCart", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                        myCmd.Parameters.AddWithValue("@CartPID", PID);
                        myCmd.Parameters.AddWithValue("@Email", email);
                        Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                        BindCartNumber();
                        divSuccess.Visible = true;
                    }
                    else
                    {
                        SqlCommand myCmd = new SqlCommand("SP_InsertCart", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        myCmd.Parameters.AddWithValue("@Email", email);
                        myCmd.Parameters.AddWithValue("@PID", Session["CartPID"].ToString());
                        myCmd.Parameters.AddWithValue("@PName", Session["myPName"].ToString());
                        myCmd.Parameters.AddWithValue("@PPrice", Session["myPPrice"].ToString());
                        myCmd.Parameters.AddWithValue("@PSelPrice", Session["myPSelPrice"].ToString());
                        myCmd.Parameters.AddWithValue("@Qty", myQty);
                        myCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                        con.Close();
                        BindCartNumber();
                        divSuccess.Visible = true;
                    }
                }
            }
        
        else
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            Response.Redirect("Login.aspx?rurl=" + PID);
        }
    }



    protected void btnCart2_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }


}