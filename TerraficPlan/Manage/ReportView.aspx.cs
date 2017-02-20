using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Manage
{
    public partial class ReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
                DataSet ds = new DataSet();
                ds = (DataSet)Session["data"];
                if (ds != null)
                {
                    ds.Tables[0].TableName = "DataSource1";
                    StiReport srt = new StiReport();
                    srt.Load(Server.MapPath("~/Manage/rep/" + Request.QueryString["RName"].ToString() + ".mrt"));// @"E:\Other\Report\PB0201.mrt");
                    srt.DataSources.Clear();
                    srt.DataStore.Clear();

                    srt.RegData("DataSource1", ds);
                    srt.Dictionary.Synchronize();
                    srt.Compile();
                    StiWebViewer1.Report = srt;
                //    Session["data"] = "";
                     ds.Dispose();
                }
            //}
        }
    }
}