using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if(Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            {
                TextBox1.Text = Request.Cookies["email"].Value;
                TextBox2.Text = Request.Cookies["password"].Value;
                
                CheckBox2.Checked = true;
            
            }


        }


    }

    protected void Login_Click(object sender,EventArgs e)
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("select * from users where email = @email and password = @password",con);

        cmd.Parameters.AddWithValue("@email", TextBox1.Text);
        cmd.Parameters.AddWithValue("@password", TextBox2.Text);

        SqlDataReader sdr = cmd.ExecuteReader();


        if (sdr.HasRows)
        {
            if (CheckBox2.Checked)
            {

                Response.Cookies["email"].Value = TextBox1.Text;
                Response.Cookies["password"].Value = TextBox2.Text;

                Response.Cookies["email"].Expires = DateTime.Now.AddDays(10);
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(10);


            }

            else
            {

                Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);


            }

            string utype;
            while (sdr.Read())
            {

                utype = sdr.GetString(4).ToString().Trim();



                if (utype == "User")
                {

                    Session["email"] = TextBox1.Text;

                    Response.Redirect("~/User_Home.aspx");

                }

                if (utype == "Admin")
                {

                    Session["email"] = TextBox1.Text;

                    Response.Redirect("~/Admin_Home.aspx");

                }

            }
        }

        else
        {
            Label3.Text = "Invalid email or password";
        }
        
        
        clear();
        con.Close();



    }

    private void clear()
    {
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox1.Focus();
    }

  

}