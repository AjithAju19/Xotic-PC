using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Update_Manufacturer : System.Web.UI.Page
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

        SqlCommand cmd = new SqlCommand("select mname from Manufacturer where mid=@ID", con);
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds, "dt");
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnUpdateBrand.Enabled = true;
            txtUpdateBrandName.Text = ds.Tables[0].Rows[0]["mname"].ToString();

        }
        else
        {
            btnUpdateBrand.Enabled = false;
            txtUpdateBrandName.Text = string.Empty;
        }
        con.Close();
    }
    protected void btnUpdateBrand_Click(object sender, EventArgs e)
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("update Manufacturer set mname= (@mname) where mid=@ID", con);
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
        cmd.Parameters.AddWithValue("@mname", txtUpdateBrandName.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Updated successfully')</script>");
        BindGridview();
        txtID.Text = string.Empty;
        txtUpdateBrandName.Text = string.Empty;


    }

    private void BindGridview()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select * from Manufacturer", con);
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