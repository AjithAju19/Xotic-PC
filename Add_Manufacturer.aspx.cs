using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Add_Manufacturer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindManufacturerRepeater();
    }

    protected void Addmanufacturer_Click(object sender, EventArgs e)
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        string signup = "insert into manufacturer values('" + TextBox1.Text + "');";

        SqlCommand cmd = new SqlCommand(signup, con);
        int n = cmd.ExecuteNonQuery();

        if (n > 0)
        {
            Response.Write("<script> alert('Manufacturer added successfully');</script>");
            clear();
        }

        else
        {
            Response.Write("<script> alert('Unfortunately manufacturer could not be added ');</script>");
            clear();
        }

        con.Close();


        
        TextBox1.Focus();


    }

    private void clear()
    {
        TextBox1.Text = string.Empty;
    }


    
    private void BindManufacturerRepeater()
    {
        
        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        SqlCommand cmd = new SqlCommand("select * from Manufacturer", con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();

        GridView1.DataSource = dt;
        GridView1.DataBind();



    }

    /*

    private void BindManufacturerRepeater()
    {

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);


        con.Open();

        SqlCommand cmd = new SqlCommand("select * from Manufacturer", con);

        SqlDataReader sdr = cmd.ExecuteReader();

        // Repeater1.DataSource = sdr;
        //Repeater1.DataBind();

        GridView1.DataSource = sdr;
        GridView1.DataBind();

    }

    */

}