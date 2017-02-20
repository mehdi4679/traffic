using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;

namespace TerraficPlan.MasterPages
{
    public partial class WizardDashboard : System.Web.UI.MasterPage
    {
        private string MerchantId = "10321755";
        public string listep2 {
            set { step2.Attributes.Add("class", value.ToString()); }
        }
        public string listep3 {
            set { step3.Attributes.Add("class", value.ToString()); }
        }
        public string listep4 {
            set { step4.Attributes.Add("class", value.ToString()); }
        }
        public string listep5 {
            set { step5.Attributes.Add("class", value.ToString()); }
        }
        public string listep1{
            set { step1.Attributes.Add("class", value.ToString()); }
        }
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String RequestTrafficID = ((HtmlAnchor)sender).HRef.ToString();
            int i = RequestTrafficClass.Delete(RequestTrafficID);
            if (i == 0)
            {

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else { BindChart(); }

        }

        protected void sss_ServerClick(object sender, EventArgs e)
        {
            string personalid = Session["PersonalID"].ToString();
            Session.Clear();
            Session["PersonalID"] = personalid;
            Response.Redirect("/Public/PersonalView.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //    BindChart();

            //try { 
            //    if(Session["IsManage"]!=null && Session["IsManage"]!="")
            //    {if(Session["IsManage"].ToString()=="true")
            //    liManage.Visible = true;
            //    }
 
                   

            //}
            //catch{
            //}
             
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            try
            {

                string url = ConfigurationManager.AppSettings["SafhePardakhtPage"];// Properties.Settings.Default.SafhePardakhtPage;
                string RedirectURL = ConfigurationManager.AppSettings["ReturnAddress"];// Properties.Settings.Default.ReturnAddress;

                ClEpayOrder cl = new ClEpayOrder();
                cl.RequestID = Convert.ToInt32(((HtmlAnchor)sender).HRef.ToString());
                int Price = GetPrice(Convert.ToInt32(((HtmlAnchor)sender).HRef.ToString()));
                cl.OrderDateStart = DateTime.Now.ToString();
                cl.IP = CSharp.PublicFunction.GetIPAddress();
                cl.OS = CSharp.PublicFunction.GetOS();
                cl.Prcie = Price;
                cl.Browser = CSharp.PublicFunction.GetBrowser() + " " + CSharp.PublicFunction.GetBrowserVersion();
                int i = EpayOrderClass.insert(cl);
                if (i == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در برنامه");
                else
                    Response.Redirect(url + "?ResNum=" + i + "&MID=" +
                    MerchantId + "&RedirectURL=" + RedirectURL + "&Amount=" + Price.ToString().Trim());

            }
            catch (Exception ex)
            {
            }
        }
        private Int32 GetPrice(int rid)
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.RequestTrafficID = rid;
            DataSet ds = RequestTrafficClass.GetListPrice(cl);
            DataRow dr = ds.Tables[0].Rows[0];
            return Convert.ToInt32(dr["Price"].ToString());

        }
        private void BindChart(){
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.PersonalID = Convert.ToInt32(Session["PersonalID"]);
            DataSet ds = RequestTrafficClass.GetListCode2(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["RequestTraffic"] == null)
            {
                ViewState["RequestTraffic"] = "RequestTrafficID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["RequestTraffic"].ToString()).ToString();
            DataTable dt = dv.ToTable();
            rpPayy.DataSource = dv;// dt.Rows.Cast<System.Data.DataRow>().Take(10);
            rpPayy.DataBind();
            lblcount.Text = ds.Tables[0].Rows.Count.ToString();
            lblcount2.Text = ds.Tables[0].Rows.Count.ToString();

        }
    }
}