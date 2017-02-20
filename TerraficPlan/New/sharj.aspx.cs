using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace TerraficPlan.New
{
    public partial class sharj : System.Web.UI.Page
    {
        private string MerchantId = "10321755";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
 
        protected void btnShajBank_Click(object sender, EventArgs e)
            
        {
            //if(Convert.ToInt32( txtPrice.Text)<10000)
            //{
            //    TerraficPlanBLL.Utility.ShowMsg(Page,TerraficPlanBLL.ProPertyData.MsgType.warning,"مبلغ شارژ باید از 1000 تومات بیشتر باشد");
            //    return;
            //}

            ClSharj cl = new ClSharj();
            cl.CodeMelli = TXTNationalCode.Text;
            cl.Mobile = TXTPersonalMobile.Text;
            cl.ShariPrice =Convert.ToInt32( txtPrice.Text);


            int i   = SharjClass.insert(cl);
            if (i == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در ثبت");
            else
            Pay_Click(i,Convert.ToInt32(txtPrice.Text));

        }
        public void Pay_Click(int sharjID,int price)
        {
            try
            {

                string url = ConfigurationManager.AppSettings["SafhePardakhtPage"];// Properties.Settings.Default.SafhePardakhtPage;


                string RedirectURL = ConfigurationManager.AppSettings["ReturnAddressNew"];// Properties.Settings.Default.ReturnAddress;

                ClEpayOrder cl = new ClEpayOrder();
                cl.SharjID = Convert.ToInt32(sharjID);
              // cl.ResCode = resNum;
                cl.OrderDateStart = DateTime.Now.ToString();
                cl.IP = CSharp.PublicFunction.GetIPAddress();
                cl.OS = CSharp.PublicFunction.GetOS();
                cl.Prcie = Convert.ToInt32(price);
                cl.Browser = CSharp.PublicFunction.GetBrowser() + " " + CSharp.PublicFunction.GetBrowserVersion();
                int i = EpayOrderClass.insert(cl);
                if (i == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در برنامه");
                else
                    Response.Redirect(url + "?ResNum=" + i + "&MID=" +
                    MerchantId + "&RedirectURL=" + RedirectURL + "&Amount=" + price.ToString().Trim());

            }
            catch (Exception ex)
            {
            }
        }
    }
}