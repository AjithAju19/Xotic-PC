using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Forgot_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SendEmail_Click(object sender,EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=AJITH\\SERVER;Initial Catalog='Xotic PC';Integrated Security=True";

        con.Open();

        SqlCommand cmd = new SqlCommand("select * from users where email = @email", con);

        cmd.Parameters.AddWithValue("@Email", TextBox1.Text);

        SqlDataReader sdr = cmd.ExecuteReader();
        
        if(sdr.HasRows)
        {

        }

    }
}