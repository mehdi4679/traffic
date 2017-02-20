using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;

namespace TerraficPlan.Public
{
    public partial class Car : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var liActive = (HtmlGenericControl)Master.FindControl("step1");
                liActive.Attributes.Add("class", "complete");
                var liActive2 = (HtmlGenericControl)Master.FindControl("step2");
                liActive2.Attributes.Add("class", "active");


                string msggg = "<i class='ace-icon fa fa-bell-o bigger-110 purple'></i>" + "توجه:" + Environment.NewLine + "پلاک های ت,الف,جانبازان بالای 50 درصد و انتظامی معاف بوده و نیازی به خر ید طرح ترافیک ندارند ";
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, msggg);

                CtlCar1.PersonID = Convert.ToInt32(Session["PersonalID"]);
                CtlCar1.BindDD();
                CtlCar1.BindGrid();
            
            
            }
        }
        protected void nextlink(object sender, EventArgs e)
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
            cl.CarID = CtlCar1.SelectedCar;
            if(cl.CarID==0)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "ابتدا خوروی انتخابی برای دریافت طرح ترافیک را انتخاب  یا ثبت نمایید.");
            return;
            }
            cl.RequestTrafficID =Convert.ToInt32( Session["rid"].ToString());
            int i = RequestTrafficClass.Update(cl);
            if (i == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در درج اطلاعات");
            else
            {
                Response.Redirect("~/Public/Discount.aspx");
             }


        }
   
    }
}