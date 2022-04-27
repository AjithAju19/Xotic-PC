using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class Update_Category : System.Web.UI.Page
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



    protected void txtID_TextChanged(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("select catname from Category where catid = @ID", con);
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds, "dt");
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnUpdateBrand.Enabled = true;
            txtUpdateCatName.Text = ds.Tables[0].Rows[0]["catname"].ToString();

        }
        else
        {
            btnUpdateBrand.Enabled = false;
            txtUpdateCatName.Text = string.Empty;
        }
        con.Close();
    }
    protected void btnUpdateCategory_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("update Category set catname =@Name where catid=@ID", con);
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
        cmd.Parameters.AddWithValue("@Name", txtUpdateCatName.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Updated successfully')</script>");
        BindGridview();
        txtID.Text = string.Empty;
        txtUpdateCatName.Text = string.Empty;


    }

    private void BindGridview()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select catid,catname from Category", con);
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