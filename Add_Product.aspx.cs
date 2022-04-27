using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


public partial class Add_Product : System.Web.UI.Page
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

    protected void Addproduct_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        SqlCommand cmd = new SqlCommand("SPInsertProduct",con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pname",TextBox1.Text);
        cmd.Parameters.AddWithValue("@price",TextBox2.Text);
        cmd.Parameters.AddWithValue("@sellingprice",TextBox3.Text);
        cmd.Parameters.AddWithValue("@pcatid",ddl2.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@psubcatid",ddl3.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@pmid", DropDownList1.SelectedItem.Value);

        cmd.Parameters.AddWithValue("@pdesc",TextBox4.Text);
        
        if(CheckBox1.Checked == true)
        {
            cmd.Parameters.AddWithValue("@freedelivery", 1.ToString());
        }
        else if(CheckBox1.Checked == false)
        {
            cmd.Parameters.AddWithValue("@freedelivery", 0.ToString());
        }

        if (CheckBox2.Checked == true)
        {
            cmd.Parameters.AddWithValue("@30dayret", 1.ToString());
        }

        else if(CheckBox2.Checked == false)
        {
            cmd.Parameters.AddWithValue("@30dayret", 0.ToString());
        }


        if (CheckBox3.Checked == true)
        {
            cmd.Parameters.AddWithValue("@cod", 1.ToString());
        }
        else if(CheckBox3.Checked == false)
        {
            cmd.Parameters.AddWithValue("@cod", 0.ToString());
        }


        Int64 n = Convert.ToInt64(cmd.ExecuteScalar());

        if (n > 0)
        {
            Response.Write("<script> alert('Product added successfully');</script>");
            
        }

        else
        {
            Response.Write("<script> alert('Unfortunately Product could not be added ');</script>");
            
        }

        if (FileUpload1.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/") + n;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);

            }

            string Extention = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(SavePath + "\\" + TextBox1.Text.ToString().Trim() + "01"+Extention);

            
            SqlCommand cmd1 = new SqlCommand("insert into ProductsImages values('"+n+"','"+TextBox1.Text.ToString().Trim()+"01','"+Extention+"');",con);
            cmd1.ExecuteNonQuery();

        }
        
        if (FileUpload2.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/") + n;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);

            }

            string Extention = Path.GetExtension(FileUpload2.PostedFile.FileName);
            FileUpload2.SaveAs(SavePath + "\\" + TextBox1.Text.ToString().Trim() + "02"+Extention);

            SqlCommand cmd2 = new SqlCommand("insert into ProductsImages values('" + n + "','" + TextBox1.Text.ToString().Trim() + "02','" + Extention + "')", con);
            cmd2.ExecuteNonQuery();

        }

        if (FileUpload3.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/") + n;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);

            }

            string Extention = Path.GetExtension(FileUpload3.PostedFile.FileName);
            FileUpload3.SaveAs(SavePath + "\\" + TextBox1.Text.ToString().Trim() + "03"+Extention);

            SqlCommand cmd3 = new SqlCommand("insert into ProductsImages values('" + n + "','" + TextBox1.Text.ToString().Trim() + "03','" + Extention + "')", con);
            cmd3.ExecuteNonQuery();

        }

        if (FileUpload4.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/") + n;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);

            }

            string Extention = Path.GetExtension(FileUpload4.PostedFile.FileName);
            FileUpload4.SaveAs(SavePath + "\\" + TextBox1.Text.ToString().Trim() + "04"+Extention);

            SqlCommand cmd4 = new SqlCommand("insert into ProductsImages values('" + n + "','" + TextBox1.Text.ToString().Trim() + "04','" + Extention + "')", con);
            cmd4.ExecuteNonQuery();


        }

        if (FileUpload5.HasFile)
        {
            string SavePath = Server.MapPath("~/Images/") + n;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);

            }

            string Extention = Path.GetExtension(FileUpload5.PostedFile.FileName);
            FileUpload5.SaveAs(SavePath + "\\" + TextBox1.Text.ToString().Trim() + "05"+Extention);

            SqlCommand cmd5 = new SqlCommand("insert into ProductsImages values('" + n + "','" + TextBox1.Text.ToString().Trim() + "05','" + Extention + "')", con);
            cmd5.ExecuteNonQuery();

        }
        
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
        CheckBox2.Checked = false;
        CheckBox3.Checked = false;


    }
}