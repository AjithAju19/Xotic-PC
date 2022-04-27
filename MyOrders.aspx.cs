using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Forms;
using System.Threading;

public partial class MyOrders : System.Web.UI.Page
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

  
    public override bool EnableEventValidation
    {
        get { return false; }
        set { /*Do nothing*/ }
    }

    private void BindGrid1()
    {
        Int64 CartID = Convert.ToInt64(Request.QueryString["CartID"]);

        string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        con.Open();


        string query = "select t1.OrderID,t1.Email,t1.CartID,t1.PID,t1.PName,t1.PPrice,t1.PSelPrice,t1.SubPAmount,t1.SubSAmount,t1.Qty,t1.OrderDate from Orders t1 where t1.Email = '"+Session["email"].ToString()+"'";


        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void btnPdf_Click(object sender, EventArgs e)
    {

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=MyOrder.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        this.GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;

        System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
        Controls.Add(form);
        form.Controls.Add(GridView1);
        form.RenderControl(hw);
       
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        
        Response.Write(pdfDoc);
        Response.End();
        GridView1.AllowPaging = true;
        GridView1.DataBind();
       
    }

    
}