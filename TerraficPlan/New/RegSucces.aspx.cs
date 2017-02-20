using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanDAL;
using TrafficPlanCL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Configuration;
using TerraficPlanBLL;

namespace TerraficPlan.New
{
    public partial class RegSucces : System.Web.UI.Page
    {
        private string MerchantId = "10321755";
 
        protected void BTNpAY_Click(object sender, EventArgs e)
        {
            try
            {

                string url = ConfigurationManager.AppSettings["SafhePardakhtPage"];// Properties.Settings.Default.SafhePardakhtPage;

                string resNum = lblRahgiri.Text + ":" + DateTime.Now.Year.ToString() +
                                DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                DateTime.Now.Day.ToString().PadLeft(2, '0') +
                                DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                                DateTime.Now.Minute.ToString().PadLeft(2, '0') +
                                DateTime.Now.Second.ToString().PadLeft(2, '0');

                string RedirectURL = ConfigurationManager.AppSettings["ReturnAddressNew"];// Properties.Settings.Default.ReturnAddress;

                ClEpayOrder cl = new ClEpayOrder();
                cl.RequestID = Convert.ToInt32(lblreqtraficID.Text);
                //cl.ResCode = resNum;
                cl.OrderDateStart = DateTime.Now.ToString();
                cl.IP = CSharp.PublicFunction.GetIPAddress();
                cl.OS = CSharp.PublicFunction.GetOS();
                cl.Prcie =   Convert.ToInt32(lblAmount.Text);
                cl.Browser = CSharp.PublicFunction.GetBrowser() + " " + CSharp.PublicFunction.GetBrowserVersion();
                int i = EpayOrderClass.insert(cl);
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

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["Code"].ToString() != Request.QueryString["Code"].ToString())
            //    return;
           // if (HttpContext.Current.Request.Url.AbsoluteUri.Contains(""))
            if (Request.QueryString["t"] != null)
                if (Request.QueryString["t"].ToString() == "1")
                    lblStatusRequest.Visible = false;

            lblresid.Text = "رسید ثبت نام";

            if (!Page.IsPostBack)
            {
                txtpelak.Enable = false;
               string smstext= FillReport();
             //  PublicFunction.SendSMSs(lblmobileeee.Text, smstext);
            }
        }

        private string FillReport()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.TrackingCode =Securenamespace.SecureData.CheckSecurity( Request.QueryString["code"].ToString()) ;
            DataSet ds = RequestTrafficClass.GetListCode(cl);
            DataRow dr = ds.Tables[0].Rows[0];
           
            lbldate.Text = DateConvert.m2sh(DateTime.Now.ToString()).ToString();
            lbltime.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
           
            LblMobile.Text = dr["mobile"].ToString();
            txtpelak.Text = dr["pelak"].ToString();
            lblNationalCode.Text = dr["NationalCode"].ToString();
           
            lblPrice.Text = dr["Price"].ToString();
            lblAmount.Text = dr["Price"].ToString();
            lblRahgiri.Text = dr["TrackingCode"].ToString();
           


            lblmobileeee.Text = dr["mobile"].ToString();

             
                lblRahgiri.Text = dr["TrackingCode"].ToString();

                lblreqtraficID.Text = dr["RequestTrafficID"].ToString();
                BindData();

                VisiblePay(Convert.ToInt32(dr["RepeateTypeID"].ToString()), Convert.ToInt32(dr["RequestStatus"].ToString()), dr["StatusName"].ToString(), dr["RequestStatusComment"].ToString());


            string mobilestr = "";
            //if (hoghoghiOrTakhfif)
            //{
                mobilestr = " آقا/خانم " + dr["OwnerName"].ToString() + "مالک خودرو " + dr["CarName"].ToString() + "به شماره پلاک" + dr["pelak"].ToString().Replace("ir", "_") + "متقاضی خرید طرح ترافیک." + Environment.NewLine;
                mobilestr += "درخواست اولیه شما ثبت گردید و  از طریق پیام کوتاه به اطلاع شما خواهد رسید" + Environment.NewLine;
                mobilestr += "مرکز مدیریت هوشمند ترافیک شهرداری قم";
            //}
            return mobilestr;

        }

        private void VisiblePay(int RepeatType,int statuse,string statusName,string statuseComment) 
        {
            lblStatusRequest.Text=statusName;
           lblStatusRequest.Text+= "  "+statuseComment;

            if (RepeatType > 3 && statuse == 1)
                BTNpAY.Visible = true;

            if (RepeatType ==3)
                BTNpAY.Visible = true;
           
           

        }
        private void BindData()
        {
            ClRequestRepeat cl=new ClRequestRepeat();
           cl.RequestID=Convert.ToInt32(lblreqtraficID.Text);
           DataSet ds = RequestRepeatClass.GetList(cl);
           DataList1.DataSource = ds;
           DataList1.DataBind();

        }




      }
}