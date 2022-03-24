using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SignUp : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender,EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

    protected void Signup_Click(object sender,EventArgs e)
    {

        if (isValidForm())
        {
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);


            con.Open();

            string signup = "insert into users values('" + Textbox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "'"+",'User');";
            
            SqlCommand cmd = new SqlCommand(signup,con);
            int n = cmd.ExecuteNonQuery();

            if (n > 0)
            {
                Response.Write("<script> alert('Registration successfull');</script>");

            }

            else
            {
                Response.Write("<script> alert('Unfortunately registration failed');</script>");

            }

            con.Close();


            clear();
            Response.Redirect("~/Login.aspx");

        }

    }

    private bool isValidForm()
    {
        if(Textbox1.Text == "")
        {
            Response.Write("<script> alert('First name not valid'); </script>");
            Textbox1.Focus();
            return false;
        }

        else if(TextBox2.Text == "")
        {
            Response.Write("<script> alert('Last name not valid'); </script>");
            TextBox2.Focus();
            return false;
        }

        else if (TextBox3.Text == "")
        {
            Response.Write("<script> alert('Email not valid'); </script>");
            TextBox3.Focus();
            return false;
        }

        else if (TextBox4.Text == "")
        {
            Response.Write("<script> alert('Password not valid'); </script>");
            TextBox4.Focus();
            return false;
        }


        return true;
    }

    private void clear()
    {
        Textbox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
        TextBox4.Text = string.Empty;
    }
}