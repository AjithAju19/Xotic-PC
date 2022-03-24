using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["email"] != null)
        {

            Label1.Text = "Welcome " + Session["email"].ToString();
        
        }

        else
        {
            Response.Redirect("~/Login.aspx");
        }

    }
}