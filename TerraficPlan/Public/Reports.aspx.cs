using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using Microsoft.Reporting.WebForms;
using System.Security.Principal;
using TerraficPlanBLL;
using TrafficPlanDAL;
using TrafficPlanCL;
using System.Text;
using Microsoft.Reporting.WebForms;

 namespace TerraficPlan.Public
{

     //public class ReportServerCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
     //{


     //    public ReportServerCredentials()
     //    {
     //    }

     //    public bool GetFormsCredentials(ref System.Net.Cookie authCookie, ref string userName, ref string password, ref string authority)
     //    {
     //        authCookie = null;
     //        userName = null;
     //        password = null;
     //        authority = null;

     //        //Not using form credentials
     //        return false;
     //    }

     //    public System.Security.Principal.WindowsIdentity ImpersonationUser
     //    {
     //        //Use the default Windows user. Credentials will be
     //        //provided by the NetworkCredentials property.
     //        get { return null; }
     //    }

     //    public System.Net.ICredentials NetworkCredentials
     //    {
     //        get
     //        {

     //            string userName = ConfigurationManager.AppSettings["ReportUser"];
     //            if (string.IsNullOrEmpty(userName))
     //            {
     //                throw new Exception("Missing user name in web.config file");
     //            }

     //            string password = ConfigurationManager.AppSettings["ReportUserPass"];
     //            if (string.IsNullOrEmpty(password))
     //            {
     //                throw new Exception("Missing password in web.config file");
     //            }

     //            string domain = ConfigurationManager.AppSettings["Domain"];
     //            if (string.IsNullOrEmpty(domain))
     //            {
     //                //Throw New Exception("Missing domain in web.config file")

     //            }

     //            return new NetworkCredential(userName, password, domain);
     //        }
     //    }
     //}




  
    public partial class Reports : System.Web.UI.Page
    {
        protected  void Page_Init(object sender ,EventArgs e)  {
          //  ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerCredentials();
        }

      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            //    Bindddd();
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
          //  BB();
        }
        //protected void BB() {
        //    //ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServer"].ToString());
        //    //ReportViewer1.ServerReport.ReportPath = "/Terrafical/Terrafical2";

        //    IReportServerCredentials irsc = new CustomReportCredentials(ConfigurationManager.AppSettings["ReportUser"], ConfigurationManager.AppSettings["ReportUserPass"], ConfigurationManager.AppSettings["Domain"]);
        //    ReportViewer1.ServerReport.ReportServerCredentials = irsc;

        //     ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        //    ReportViewer1.Visible = true;
        //    ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServer"]);
        //    ReportViewer1.ServerReport.ReportPath = "/Terrafical/Terrafical2.rdlc";

        //    ReportParameter     fromdate =new ReportParameter();
        //    fromdate.Name = "FromDate";
        // fromdate.Values.Add(DateConvert.sh2m(txtFromDate.Text).ToString());
          

        //ReportParameter ToDate = new ReportParameter();
        //ToDate.Name = "ToDate";
        //ToDate.Values.Add(DateConvert.sh2m(txtToDate.Text).ToString());




        //ReportParameter[] parameters = { fromdate, ToDate };
        //ReportViewer1.ServerReport.SetParameters(parameters);
        //    ReportViewer1.DataBind();       
        //}

        protected void btn1_Click(object sender, EventArgs e)
        {








            ClRequestTraffic c = new ClRequestTraffic();
            c.fromDate = DateConvert.sh2m(txtFromDate.Text).ToString();
            c.ToDate=DateConvert.sh2m(txtToDate.Text).ToString();
            DataSet ds = TrafficPlanDAL.RequestTrafficClass.GetListCodeManagee(c);

 
	//   Variables declaration
            string filename = "Terrafical.xls";
	DataSet dsExport = new DataSet();
	System.IO.StringWriter tw = new System.IO.StringWriter();
	System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
	DataGrid dgGrid = new DataGrid();
	dgGrid.DataSource = ds;
	//   Report Header
	hw.WriteLine("<b><u><font size='5'> " + "درخواست های ثبت شده" + "</font></u></b>");

	//   Get the HTML for the control.
	dgGrid.HeaderStyle.Font.Bold = true;
	dgGrid.DataBind();
	dgGrid.RenderControl(hw);

    ////Set App 
    //if (app == "Word") {
    //    app = "application/vnd.word;";
    //    filename = filename + ".doc";

    //} else {
    //    app = "application/vnd.ms-excel";
    //    filename = filename + ".xls";
    //}
	//   Write the HTML back to the browser.
    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
	//EnableViewState = False
	HttpContext.Current.Response.Clear();
	HttpContext.Current.Response.BufferOutput = true;
	HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
	HttpContext.Current.Response.Charset = "UTF-8";
	HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);

	HttpContext.Current.Response.Write(tw.ToString());
	HttpContext.Current.Response.End();

 
















           //DataTable dt = ds.Tables[0];
           // string attachment = "attachment; filename=city.xls";
           // Response.ClearContent();
           // Response.AddHeader("content-disposition", attachment);
           // Response.ContentType = "application/vnd.ms-excel";
           // string tab = "";
           // foreach (DataColumn dc in dt.Columns)
           // {
           //     Response.Write(tab + dc.ColumnName);
           //     tab = "\t";
           // }
           // Response.Write("\n");
           // int i;
           // foreach (DataRow dr in dt.Rows)
           // {
           //     tab = "";
           //     for (i = 0; i < dt.Columns.Count; i++)
           //     {
           //         Response.Write(tab + Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(dr[i].ToString())));
           //         tab = "\t";
           //     }
           //     Response.Write("\n");
           // }
           // Response.End();
        }


    }
}