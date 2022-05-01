using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class Update_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindMainCat();
            BindManufacturer();

            ddl3.Enabled = false;

        }


    }



    protected void Updateproduct_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        SqlCommand cmd = new SqlCommand("SPUpdateProduct", con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pid", pid.Text);
        cmd.Parameters.AddWithValue("@pname", TextBox1.Text);
        cmd.Parameters.AddWithValue("@price", TextBox2.Text);
        cmd.Parameters.AddWithValue("@sellingprice", TextBox3.Text);
        cmd.Parameters.AddWithValue("@pcatid", ddl2.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@psubcatid", ddl3.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@pmid", DropDownList1.SelectedItem.Value);

        cmd.Parameters.AddWithValue("@pdesc", TextBox4.Text);

        if (CheckBox1.Checked == true)
        {
            cmd.Parameters.AddWithValue("@freedelivery", 1.ToString());
        }
        else if (CheckBox1.Checked == false)
        {
            cmd.Parameters.AddWithValue("@freedelivery", 0.ToString());
        }


        if (CheckBox3.Checked == true)
        {
            cmd.Parameters.AddWithValue("@cod", 1.ToString());
        }
        else if (CheckBox3.Checked == false)
        {
            cmd.Parameters.AddWithValue("@cod", 0.ToString());
        }


       cmd.ExecuteScalar();


        
            Response.Write("<script> alert('Product details updated successfully');</script>");

       
      
        con.Close();
        clear();

    }


    private void BindMainCat()
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        SqlCommand cmd = new SqlCommand("select * from Category", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sda.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            ddl2.DataSource = dt;
            ddl2.DataTextField = "catname";
            ddl2.DataValueField = "catid";
            ddl2.DataBind();
            ddl2.Items.Insert(0, new ListItem("-Select-", "0"));
        }


    }


    /*
        private void BindMainCat()
        {

            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);


            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Category", con);
            SqlDataReader sdr = cmd.ExecuteReader();


            if (sdr.HasRows)
            {
                ddl2.DataSource = sdr;
                ddl2.DataTextField = "catname";
                ddl2.DataValueField = "catid";
                ddl2.DataBind();
                ddl2.Items.Insert(0, new ListItem("-Select-", "0"));
            }


        }
        */

    private void BindManufacturer()
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        SqlCommand cmd = new SqlCommand("select * from Manufacturer", con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "mname";
            DropDownList1.DataValueField = "mid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("-Select-", "0"));
        }



    }


    /*
    private void BindManufacturer()
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        SqlCommand cmd = new SqlCommand("select * from Manufacturer", con);

        SqlDataReader sdr = cmd.ExecuteReader();
        
        if (sdr.HasRows)
        {
            DropDownList1.DataSource = sdr;
            DropDownList1.DataTextField = "mname";
            DropDownList1.DataValueField = "mid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("-Select-", "0"));
        }



    }

    */
    /*
    protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl3.Enabled = true;

        string MainCategoryID = ddl2.SelectedItem.Value;


        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();
        SqlCommand cmd = new SqlCommand("select * from SubCategory where maincatid = '" + MainCategoryID + "'", con);

        SqlDataReader sdr = cmd.ExecuteReader();
        
        if (sdr.HasRows)
        {
            ddl3.DataSource = sdr;
            ddl3.DataTextField = "subcatname";
            ddl3.DataValueField = "subcatid";
            ddl3.DataBind();
            ddl3.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }

    */

    protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddl3.Enabled = true;

        string MainCategoryID = ddl2.SelectedItem.Value;


        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();
        SqlCommand cmd = new SqlCommand("select * from SubCategory where maincatid = '" + MainCategoryID + "'", con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            ddl3.DataSource = dt;
            ddl3.DataTextField = "subcatname";
            ddl3.DataValueField = "subcatid";
            ddl3.DataBind();
            ddl3.Items.Insert(0, new ListItem("-Select-", "0"));
        }



    }



    protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void clear()
    {
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
        TextBox4.Text = string.Empty;
        ddl2.SelectedIndex = 0;
        ddl3.SelectedIndex = 0;
        DropDownList1.SelectedIndex = 0;
        CheckBox1.Checked = false;
        
        CheckBox3.Checked = false;


    }

}