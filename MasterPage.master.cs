using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (Session["email"] != null)
        {
            
            btnlogin.Visible = false;
            btnlogout.Visible = true;
            //BindCartNumber();
        }
        else
        {
            
            btnlogin.Visible = true;
            btnlogout.Visible = false;
        }
        
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");

    }

    protected void btnlogout_Click(object sender, EventArgs e)
    {

        Session["email"] = null;
        Response.Redirect("~/Home.aspx");


    }

    /*
    public void BindCartNumber()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] ProductArray = CookiePID.Split(',');
            int ProductCount = ProductArray.Length;
            pCount.InnerText = ProductCount.ToString();
        }
        else
        {
            pCount.InnerText = 0.ToString();
        }
    }

    */

    protected void btnCart_Click(object sender, EventArgs e)
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
                        pCount.InnerText = CartQuantity;

                    }
                    else
                    {
                        pCount.InnerText = 0.ToString();
                    }
                }
            }
        }

    

    }
