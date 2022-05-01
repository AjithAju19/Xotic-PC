using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Remove_SubCategory : System.Web.UI.Page
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


    private void BindGridview()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select t1.SubCatID ,t1.maincatid,t2.CatName,t1.subcatname from SubCategory t1 inner join Category t2 on t2.catid  = t1.MainCatID", con);
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

    protected void btnRemoveSubCategory_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("delete from SubCategory where subcatid = @ID", con);
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));

        int n = cmd.ExecuteNonQuery();
        con.Close();
        if (n > 0)
        {
            Response.Write("<script>alert('Removed successfully')</script>");
        }
        else
        {
            Response.Write("<script>alert('Deletion failed SubCatID donot match...')</script>");
        }
        BindGridview();


    }


  
    

}