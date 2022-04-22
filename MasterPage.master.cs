using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        BindCartNumber();
        if (Session["email"] != null)
        {
            
            btnlogin.Visible = false;
            btnlogout.Visible = true;
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

        Session["username"] = null;
        Response.Redirect("~/Home.aspx");


    }

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

    protected void btnCart_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Cart.aspx");

    }
}
