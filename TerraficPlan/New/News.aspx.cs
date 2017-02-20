using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanDAL;
using TrafficPlanCL;
using System.Data;
using System.Web.Services;

namespace TerraficPlan.New
{
    public partial class News : System.Web.UI.Page
    {
         [WebMethod]
        public static string GetPrice(string pelak,string repid)
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.Pelak = pelak;
            cl.RepeatTypeID = Convert.ToInt32(repid);
            int i=  RequestTrafficClass.GetPrice(cl);
 
  
            
            return i.ToString();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClNews cl=new ClNews();
                DataSet ds=NewsClass.GetList(cl);
                lblnews.Text = ds.Tables[0].Rows[0]["CommentClear"].ToString();
                ds.Dispose();
            }
        }
    }
}