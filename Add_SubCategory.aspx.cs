using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Add_SubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] != null)
        {
            if (!IsPostBack)
            {
                BindMainCat();
                BindSubCategoryRepeater();
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void SubCategory_SelectedIndexChanged(object sender,EventArgs e)
    {

        int maincatid = int.Parse(DropDownList1.SelectedItem.Value);


    }

    protected void Addsubcategory_Click(object sender, EventArgs e)
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        //con.ConnectionString = "Data Source=AJITH\\SERVER;Initial Catalog='Xotic PC';Integrated Security=True";


        con.Open();

        string signup = "insert into SubCategory values('" + TextBox1.Text + "','" + int.Parse(DropDownList1.SelectedValue) + "');";

        SqlCommand cmd = new SqlCommand(signup, con);
        int n = cmd.ExecuteNonQuery();

        if (n > 0)
        {
            Response.Write("<script> alert('Sub Category added successfully');</script>");
            clear();
        }

        else
        {
            Response.Write("<script> alert('Unfortunately sub category could not be added ');</script>");
            clear();
        }

        con.Close();

        DropDownList1.ClearSelection();
        DropDownList1.Items.FindByValue("0").Selected = true;

        TextBox1.Focus();

        BindSubCategoryRepeater(); 
    }

    private void clear()
    {
        TextBox1.Text = string.Empty;
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

        if(dt.Rows.Count != 0)
        {
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "catname";
            DropDownList1.DataValueField = "catid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("-Select-","0"));
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
            DropDownList1.DataSource = sdr;
            DropDownList1.DataTextField = "catname";
            DropDownList1.DataValueField = "catid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("-Select-", "0"));
        }


    }

    */

    
        private void BindSubCategoryRepeater()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnString);

            con.Open();

            SqlCommand cmd = new SqlCommand("select A.*,B.* from SubCategory A inner join Category B on B.catid = A.maincatid", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();


            GridView1.DataSource = dt;
            GridView1.DataBind();



        }

    /*
    private void BindSubCategoryRepeater()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();

        SqlCommand cmd = new SqlCommand("select A.*,B.* from SubCategory A inner join Category B on B.catid = A.maincatid", con);

        SqlDataReader sdr = cmd.ExecuteReader();

        //Repeater1.DataSource = sdr;
        //Repeater1.DataBind();

        GridView1.DataSource = sdr;
        GridView1.DataBind();


    }
    */



}