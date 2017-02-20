using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TerraficPlanBLL;
using TrafficPlanDAL;
using TrafficPlanCL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
 

namespace TerraficPlan.Public
{
     
    public partial class TrackingCode : System.Web.UI.Page
    {
        private string MerchantId = "10321755";
        private bool hoghoghiOrTakhfif = false;
        public  string GetUniquCode() {
            string trancadeCode = "";
            int i = 0;

            DataSet ds = new DataSet();
            while (i ==0) { 
             trancadeCode= TerraficPlanBLL.Utility.RandomString(12).ToUpper();
             ClRequestTraffic cl = new ClRequestTraffic();
             cl.TrackingCode = trancadeCode;
             ds = RequestTrafficClass.GetList(cl);
             if (ds.Tables[0].Rows.Count == 0)
               i = 1;
            }
            return trancadeCode;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            var liActive = (HtmlGenericControl)Master.FindControl("step1");
            liActive.Attributes.Add("class", "complete");
            var liActive2 = (HtmlGenericControl)Master.FindControl("step2");
            liActive2.Attributes.Add("class", "complete");
            var liActive3 = (HtmlGenericControl)Master.FindControl("step3");
            liActive3.Attributes.Add("class", "complete");
            var liActive4 = (HtmlGenericControl)Master.FindControl("step4");
            liActive4.Attributes.Add("class", "complete");   
            var liActive5 = (HtmlGenericControl)Master.FindControl("step5");
            liActive5.Attributes.Add("class", "active");

            if (Securenamespace.SecureData.CheckSecurity(Request.QueryString["takhfif"].ToString()) == "1")
            { fdiscount.Visible = true; lblresid.Text = "رسید ثبت نام"; }
            else
            { fWhithoutDiscount.Visible = true; lblresid.Text = "رسید پرداخت"; }
            if (!Page.IsPostBack)
            {

                txtpelak.Enable = false;

                ClRequestTraffic cl1=new ClRequestTraffic();
                cl1.RequestTrafficID=Convert.ToInt32( Session["rid"].ToString());
                DataSet ds = RequestTrafficClass.GetList(cl1);
                DataRow dr = ds.Tables[0].Rows[0];
               


                if (dr["TrackingCode"].ToString().Length > 2)//second time
                {
                    FillReport(0);
                    return;
                }
              
                string trancadeCode = GetUniquCode();

                
                string mobilesmg = "";
                mobilesmg=FillReport(1);
                lblRahgiri.Text = trancadeCode;

                try
                {
                  
                    if(!hoghoghiOrTakhfif)
                    mobilesmg= "کد رهگیری شما " + Environment.NewLine + trancadeCode.ToString() + Environment.NewLine + "میباشد." + Environment.NewLine + "مرکز مدیریت هوشمند ترافیک شهرداری قم ";
                    PublicFunction.SendSMSs(lblmobileeee.Text, mobilesmg);
                }
                catch { }
                ClRequestTraffic cl = new ClRequestTraffic();
                cl.RequestTrafficID = Convert.ToInt32(Session["rid"]);
                cl.TrackingCode = trancadeCode;
                RequestTrafficClass.Update(cl);

                

              
       
                }
             


        }

        private string FillReport(int i) {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.RequestTrafficID =Convert.ToInt32( Session["rid"].ToString());
            DataSet ds = RequestTrafficClass.GetListCode(cl);
            DataRow dr = ds.Tables[0].Rows[0];
            lblcar.Text = dr["CarName"].ToString();
            lbldate.Text = DateConvert.m2sh(DateTime.Now.ToString()).ToString();
            lbltime.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            lblDiscount.Text = dr["discountName"].ToString();
            LblMobile.Text = dr["mobile"].ToString();
            txtpelak.Text = dr["pelak"].ToString();
             lblNationalCode.Text = dr["NationalCode"].ToString();
            lblOwnerName.Text = dr["OwnerName"].ToString();
            lblPrice.Text = dr["Price"].ToString();
            lblAmount.Text= dr["Price"].ToString();
            lblRahgiri.Text = dr["TrackingCode"].ToString();
            lblregname.Text = dr["RegName"].ToString();
            lblmobileeee.Text = dr["mobile"].ToString();
            if(i==0)
            lblRahgiri.Text = dr["TrackingCode"].ToString();
            if (Convert.ToBoolean(dr["HasDiscount"].ToString()) || Convert.ToBoolean(dr["IsHoghoghi"].ToString()))
                hoghoghiOrTakhfif = true;

            string mobilestr="";
            if (hoghoghiOrTakhfif)
            {
                mobilestr = " آقا/خانم " + dr["OwnerName"].ToString() + "مالک خودرو " + dr["CarName"].ToString() + "به شماره پلاک" + dr["pelak"].ToString().Replace("ir","_") + "متقاضی خرید طرح ترافیک." + Environment.NewLine;
                mobilestr += "درخواست اولیه شما ثبت گردید و  از طریق پیام کوتاه به اطلاع شما خواهد رسید"+ Environment.NewLine;
                mobilestr+="مرکز مدیریت هوشمند ترافیک شهرداری قم";
            }
            return mobilestr;
             
        }

        protected void BTNpAY_Click(object sender, EventArgs e)
        {
            try
            {

                string url = ConfigurationManager.AppSettings["SafhePardakhtPage"];// Properties.Settings.Default.SafhePardakhtPage;

                string resNum =lblRahgiri.Text+":"+ DateTime.Now.Year.ToString() +
                                DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                DateTime.Now.Day.ToString().PadLeft(2, '0') +
                                DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                                DateTime.Now.Minute.ToString().PadLeft(2, '0') +
                                DateTime.Now.Second.ToString().PadLeft(2, '0');

                string RedirectURL = ConfigurationManager.AppSettings["ReturnAddress"];// Properties.Settings.Default.ReturnAddress;

                ClEpayOrder cl = new ClEpayOrder();
                cl.RequestID = Convert.ToInt32( Session["rid"].ToString());
                //cl.ResCode = resNum;
                cl.OrderDateStart = DateTime.Now.ToString();
                cl.IP = CSharp.PublicFunction.GetIPAddress();
                cl.OS = CSharp.PublicFunction.GetOS();
                cl.Prcie = Convert.ToInt32( lblAmount.Text);
                cl.Browser = CSharp.PublicFunction.GetBrowser() + " " + CSharp.PublicFunction.GetBrowserVersion();
             int i=   EpayOrderClass.insert(cl);
             if (i == 0)
                 TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در برنامه");
                else
                Response.Redirect(url + "?ResNum=" + i + "&MID=" +
                MerchantId + "&RedirectURL=" + RedirectURL + "&Amount=" + lblAmount.Text.Trim());

            }
            catch (Exception ex)
            {
            }
        }
    }
}