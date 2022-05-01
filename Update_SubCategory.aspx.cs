using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Update_SubCategory : System.Web.UI.Page
{
    string ID = "";
    string SCName = "";
    string MainCID = "";
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

        SqlCommand cmd = new SqlCommand("select subcatid,subcatname,maincatid from SubCategory where subcatID=@ID", con);
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds, "dt");
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {

            ID = ds.Tables[0].Rows[0]["subcatid"].ToString();
            SCName = ds.Tables[0].Rows[0]["subcatname"].ToString();
            MainCID = ds.Tables[0].Rows[0]["maincatid"].ToString();
            BindMainCat();
            txtSubCategory.Text = SCName;

        }
        else
        {
            ID = "";
            SCName = "";
            MainCID = "";
        }
        con.Close();
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

    private void BindMainCat()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from Category", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ddlMainCategory.DataSource = dt;
                ddlMainCategory.DataTextField = "CatName";
                ddlMainCategory.DataValueField = "CatID";
                ddlMainCategory.DataBind();
                ddlMainCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlMainCategory.SelectedValue = MainCID;

            }
        
    }
    protected void btnUpdateSubCategory_Click(object sender, EventArgs e)
    {

        if (txtID.Text != string.Empty && txtSubCategory.Text != string.Empty && ddlMainCategory.SelectedIndex != -1)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();

            SqlCommand cmd = new SqlCommand("update SubCategory set SubCatName=@SCN , MainCatID=@MCI where SubCatID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@MCI", ddlMainCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@SCN", txtSubCategory.Text);
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
            {
                Response.Write("<script>alert('Update successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Updation failed SubCatID donot match...')</script>");
            }
            BindGridview();
            txtID.Text = string.Empty;
            ddlMainCategory.SelectedIndex = -1;
            txtSubCategory.Text = string.Empty;
        }


    }

}