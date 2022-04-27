using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["email"] != null)
            {
                BindGrid1();
                
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

    }


    private void BindGrid1()
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        
        string query = "select t1.CartID,t1.PID,t1.PName,t1.PPrice,t1.PSelPrice,t1.SubPAmount,t1.SubSAmount,t1.Qty,t1.OrderDate,t2.email from Cart t1 inner join Users t2 on t1.email = t2.email";


        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

   
}