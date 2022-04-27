using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Remove_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] != null)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }


    }

    
    protected void btnRemoveProduct_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("delete from Products where pid = @ID", con);
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(TextBox1.Text));
        
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Removed successfully')</script>");
        BindGridview();
       

    }

    private void BindGridview()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select pcatid,pid,psubcatid,pname from Products", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }




}