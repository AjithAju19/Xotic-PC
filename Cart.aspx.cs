using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Cart : System.Web.UI.Page
{
    public static string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        divQtyError.Visible = false;

        if (!IsPostBack)
        {
            if (Session["email"] != null)
            {
                BindProductCart();
                BindCartNumber();
                //BindProductDetails();
            }

            else
            {
                Response.Redirect("Login.aspx");
            }
        }

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
                        //_ = CartBadge.InnerText == 0.ToString();
                        CartBadge.InnerText = "0";

                    }
                }
            
        }

    }

    protected void btnRemoveItem_Click(object sender, EventArgs e)
    {
        /*
        string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];

        Button btn = (Button)(sender);

        List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();

        string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());

        if(CookiePIDUpdated == "")
        {
            HttpCookie CartProducts = Request.Cookies["CartPID"];
            CartProducts.Values["CartPID"] = null;
            CartProducts.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(CartProducts);
        }

        else
        {
            HttpCookie CartProducts = Request.Cookies["CartPID"];
            CartProducts.Values["CartPID"] = CookiePIDUpdated;
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);
        }

        Response.Redirect("~/Cart.aspx");
*/
    }

    protected void btnBuyNow_Click(object sender, EventArgs e)
    {

    }

    /* 
     private void BindProductCart()
     {
         if (Request.Cookies["CartPID"] != null)
         {

             string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
             string[] CookieDataArray = CookieData.Split(',');

             if (CookieDataArray.Length > 0)
             {
                 noofitems.InnerText = "MY CART (" + CookieDataArray.Length + " Items)";
                 DataTable dtBrands = new DataTable();
                 Int64 CartTotal = 0;
                 Int64 Total = 0;
                 for (int i = 0; i < CookieDataArray.Length; i++)
                 {
                     string PID = CookieDataArray[i].ToString().Split('-')[0];
                     //string SizeID = CookieDataArray[i].ToString().Split('-')[1];

                     string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

                     SqlConnection con = new SqlConnection(strConnString);


                     SqlCommand cmd = new SqlCommand("select top(1) A.*,B.* from Products A inner join ProductsImages B on A.pid = '"
                         + PID + "'", con);

                     cmd.CommandType = CommandType.Text;
                     SqlDataAdapter sda = new SqlDataAdapter(cmd);
                     {
                         sda.Fill(dtBrands);



                     }
                     CartTotal += Convert.ToInt64(dtBrands.Rows[i]["price"]);
                     Total += Convert.ToInt64(dtBrands.Rows[i]["sellingprice"]);
                 }
                 rptrCartProducts.DataSource = dtBrands;
                 rptrCartProducts.DataBind();
                 divPriceDetails.Visible = true;

                 spanCartTotal.InnerText = CartTotal.ToString();
                 spanTotal.InnerText = "Rs. " + Total.ToString();
                 spanDiscount.InnerText = "- " + (CartTotal - Total).ToString();
             }
             else
             {
                 //TODO Show Empty Cart
                 noofitems.InnerText = "Your Shopping Cart is Empty";
                 divPriceDetails.Visible = false;
             }
         }

     }


    */

    private void BindProductCart()
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
                rptrCartProducts.DataSource = dt;
                rptrCartProducts.DataBind();
                if (dt.Rows.Count > 0)
                {
                    string Total = dt.Compute("Sum(SubSAmount)", "").ToString();
                    string CartTotal = dt.Compute("Sum(SubPAmount)", "").ToString();
                    string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                    noofitems.InnerText = "My Cart ( " + CartQuantity + " Item(s) )";
                    int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
                    int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
                    spanTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(Total)) + ".00";
                    spanCartTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(CartTotal)) + ".00";
                    spanDiscount.InnerText = "- Rs. " + (CartTotal1 - Total1).ToString() + ".00";
                }
                else
                {
                    noofitems.InnerText = "Your Shopping Cart is Empty.";
                    divAmountSect.Visible = false;

                }
            }

        }

    protected void rptrCartProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string email = Session["email"].ToString();
        //This will add +1 to current quantity using PID
        if (e.CommandName == "DoPlus")
        {
            string PID = (e.CommandArgument.ToString());
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();

            {
                SqlCommand cmd = new SqlCommand("SP_getUserCartItem", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@Email", email);
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
                        con.Close();
                        BindProductCart();
                        BindCartNumber();
                    }
                }

            }
        }
        else if (e.CommandName == "DoMinus")
        {
            string PID = (e.CommandArgument.ToString());
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();
            {
                SqlCommand cmd = new SqlCommand("SP_getUserCartItem", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@Email", email);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Int32 myQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                        if (myQty <= 1)
                        {
                            divQtyError.Visible = true;
                        }
                        else
                        {
                            SqlCommand myCmd = new SqlCommand("SP_UpdateCart", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            myCmd.Parameters.AddWithValue("@Quantity", myQty - 1);
                            myCmd.Parameters.AddWithValue("@CartPID", PID);
                            myCmd.Parameters.AddWithValue("@Email", email);
                            
                            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                            con.Close();
                            BindProductCart();
                            BindCartNumber();

                        }
                    }

                }
            }
        }
        else if (e.CommandName == "RemoveThisCart")
        {
            int CartPID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();
            {
                SqlCommand myCmd = new SqlCommand("SP_DeleteThisCartItem", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                myCmd.Parameters.AddWithValue("@CartID", CartPID);
                
                myCmd.ExecuteNonQuery();
                con.Close();
                BindProductCart();
                BindCartNumber();
            }
        }
    }

    protected void btnCart2_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }


    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        //Int64 CartID = Convert.ToInt64(Request.QueryString["CartID"]);
        PlaceOrder();
        Response.Redirect("~/MyOrders.aspx");
    }


    public void PlaceOrder()
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        DateTime @dt = DateTime.Now;

        string query = "INSERT INTO Orders(CartID, Email, PID, PName, PPrice, PSelPrice, SubPAmount, SubSAmount, Qty,OrderDate) SELECT CartID, Email, PID, PName, PPrice, PSelPrice, SubPAmount, SubSAmount, Qty,OrderDate FROM Cart" ;

      

        SqlCommand cmd = new SqlCommand(query, con);
        //SqlCommand cmd1 = new SqlCommand(q, con);

        int n = cmd.ExecuteNonQuery();
       // int m = cmd1.ExecuteNonQuery();

        if (n > 0)
        {
            Response.Write("<script> alert('Order placed successfully');</script>");
            
        }

        else
        {
            Response.Write("<script> alert('Unfortunately order could not be placed ');</script>");
            
        }

        con.Close();



    }


}