using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TerraficPlanBLL;
using TrafficPlanCL;
using TrafficPlanDAL;
using System.Data;

namespace TerraficPlan.New
{
    public partial class Daily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //var dwizard = (HtmlGenericControl)Master.FindControl("dwiz");
            //dwizard.Visible = false;

            //var navigationHeader = (HtmlGenericControl)Master.FindControl("navigationHeader");
            //navigationHeader.Visible = false;
            if (!Page.IsPostBack) { 
            lblRahCode.Text =  PublicFunction.GetUniquCode();
            tareff.Value = PublicFunction.GetTareefe(3, null);
        }

        }
        private string  getallday(string  allmonth){
            string finalstr = "";
             if (allmonth != "0" && allmonth != "")
            {
                if (allmonth.Remove(allmonth.Length - 1).Length > 0)
                {
                    string iii = allmonth.Remove(allmonth.Length - 1).Replace("undefined", "");
                    string[] oo = iii.Split(',');
                    for (int t = 0; t < oo.Length ; t++)
                    {
                        finalstr += DateConvert.sh2m(oo[t].ToString()).ToString() + ",";

                    }
                    return finalstr.Remove(finalstr.Length - 1);
                }
                else
                    return "";
            }
            else
                return "";

        }
        //public int Disscount
        //{
        //    get {
        //        if (rbWhithDiscount.Checked)
        //            return 1009;
        //        else
        //            return 0;            
        //    }
        
        
        //}
        public bool checkAjance()
        {
            ClCar cl = new ClCar();
            cl.Pelak = CtlPelak.Text;
          DataSet ds=     CarClass.GetList(cl);
          if (ds.Tables[0].Rows.Count > 0)
              return true;
          else
              return false;
        }

        protected void BtnDailyReg_Click(object sender, EventArgs e)
        {
            if (InputAllDay.Value.ToString() == "undefined")
            {  TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "لطفا حداقل یک روز را انتخاب کرده و روی انتخاب روز کلیلک نمایید");
            return;
            }

            string RepeatTypeValues = getallday(InputAllDay.Value);
            

            if (InputAllDay.Value == "0")
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "باید حداقل یک روز را انتخاب نمایید");
                return;
            }

            if (!CtlPelak.MustBeFill)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "وارد کردن پلاک الزامی است");
                return;
            }

            //if(rbWhithDiscount.Checked && !checkAjance())
            //{
            //    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خودرو وارده در آژانس ثبت نشده است");
            //    return;
            //}


            ClRequestTraffic objreq = new ClRequestTraffic();
            objreq.TrackingCode = lblRahCode.Text;
            objreq.Pelak = CtlPelak.Text;
             objreq.NationalCode = TXTNationalCode.Text;
            objreq.Mobile = TXTPersonalMobile.Text;
            objreq.RepeatTypeID =3;
            objreq.RepeatTypeValues = RepeatTypeValues;
            objreq.OwnerType = 1;
            objreq.DiscountType = 0;
            objreq.Firstname = txtFirstName.Text;
            objreq.LastName = txtLastName.Text;

            //objreq.PriceRequest = Convert.ToInt32(lblPrice.Attributes["value"]);
                        int carid = RequestTrafficClass.insertNew(objreq);
                        if (carid == 0)
                        {
                            TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در ثبت");
                        }
                        else
                        {
                            Response.Redirect("~/New/RegSucces.aspx?t=1&code=" + lblRahCode.Text);

                        }



        }
    }
}