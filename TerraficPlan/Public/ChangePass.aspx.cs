using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TrafficPlanCL;
using TrafficPlanDAL;
using System.Web.Security;

namespace TerraficPlan.Public
{
    public partial class ChangePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
           // var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPass + "~!@", "MD5");

            if (txtPass.Text.Length < 4) {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "کلمه عبور باید از 4 کارکتر بیشتر باشد");
                return;
            }

            ClPersonal cl=new ClPersonal();
            cl.Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassWordNow.Text + "~!@", "MD5");
            cl.PersonalID=Convert.ToInt32( Session["PersonalID"].ToString());
            DataSet ds = PersonalClass.GetList(cl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cl.Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPass.Text + "~!@", "MD5");
                cl.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
                int t=PersonalClass.Update(cl);

                if (t > 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "کلمه عبور تغییر کرد");
                else
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در تغییر کلمه عبور");

            }
            else {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "کلمه عبور فعلی اشتباه است");
            }
        }
    }
}