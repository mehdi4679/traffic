using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
 
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace TerraficPlan.Public
{
    public partial class PersonalView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var liActive = (HtmlGenericControl)Master.FindControl("step1");
                liActive.Attributes.Add("class", "active");
                var master = this.Master  ;
          

            if (!Page.IsPostBack)
            {

                if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!=null)
                {
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, Request.QueryString["msg"]);
                  //  Request.QueryString["msg"] = "";
                  
                }

                CtlPerson1.RedirectPage = "";
                CtlPerson1.UpdateMode = true;
                ClPersonal cl = new ClPersonal();

                cl.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
                CtlPerson1.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
                CtlPerson1.Data = cl;


                ClCompany clCompany = new ClCompany();
                clCompany.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
                CtlCompanyOnly1.Data = clCompany;
                Session["CompanyID"] = CtlCompanyOnly1.CompanyID.ToString();
            }

        }

        

        protected void nextlink(object sender, EventArgs e)
        {
            if ((Session["CompanyID"] == null || Session["CompanyID"].ToString() == "0" || Session["CompanyID"].ToString()=="") && rd2.Checked)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "کاربر گرامی شما نوع حقوقی را انتخاب کرده اید و باید سازمان مربوطه را ثبت نمایید");
                return;
            }


            ClRequestTraffic cl = new ClRequestTraffic();
              cl.PersonalID =Convert.ToInt32( Session["PersonalID"].ToString());
        if(rd2.Checked)
            cl.CompanyID = Convert.ToInt32(CtlCompanyOnly1.CompanyID);

          int i=  RequestTrafficClass.insert(cl);
          if (i == 0)
              TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در درج اطلاعات");
          else
          {
              if (  CtlCompanyOnly1.CompanyID != 0 && rd2.Checked)
                  Session["CompanyID"] = CtlCompanyOnly1.CompanyID;
              else
                  Session["CompanyID"] = "0";

          // if(Session["rid"] ==null || Session["rid"].ToString() =="" )
               Session["rid"] = i.ToString();
              
              Response.Redirect("~/Public/Car.aspx");
          }


        }
    }
}