using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Security.Principal;
using TrafficPlanCL;
using TrafficPlanDAL;
using TerraficPlanBLL;
using System.Data;
using System.Web.Services;

namespace Taxi
{
    public partial class LoginMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["PersonalID"] != null && Session["PersonalID"] != "0" && Session["PersonalID"] != "" && !Page.IsPostBack)
                Response.Redirect("/Public/PersonalView.aspx");

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
                
            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPass.Value + "~!@", "MD5");
             ClPersonal cl = new ClPersonal();
            cl.NationalCode = Securenamespace.SecureData.CheckSecurity(txtUserName.Value);
            cl.Pass =Securenamespace.SecureData.CheckSecurity(hash);
          
            DataSet ds = PersonalClass.GetList(cl);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Session["PersonalID"] = dr["PersonalID"].ToString();

                String userid = dr["PersonalID"].ToString();
                string role = "public";
                if (dr["Manage"].ToString() == "1")
                    role += ",Manage";
              
            HttpContext.Current.User = new GenericPrincipal(User.Identity,new string[]{ role  });
            FormsAuthentication.Initialize();
            FormsAuthenticationTicket   ticket    = new  FormsAuthenticationTicket(1, userid, DateTime.Now, DateTime.Now.AddMinutes(540), false, role, FormsAuthentication.FormsCookiePath);
            hash       = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            if( ticket.IsPersistent == true)  
            cookie.Expires = ticket.Expiration;

            Response.Cookies.Add(cookie);
               // Roles.AddUserToRole(userid, role);

              // Roles.AddUserToRole(dr["UserName"].ToString(),"admin");
            if (dr["Manage"].ToString() == "1")
                Session["IsManage"] = "true";
            ////    Response.Redirect("/Public/PersonalView.aspx?manage=1");
            ////else
            Response.Redirect("/Public/PersonalView.aspx");
            ds.Dispose();

            }
            else
            {
                //lblmsg.Text = "نام کاربری یا کلمه عبور اشتباه میباشد";
                Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "نام کاربری یا کلمه عبور اشتباه میباشد");
            
            }
   
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (txtmobile.Value.ToString() == "")
                return;
            ClPersonal cl = new ClPersonal();
             
            cl.PersonalMobile = txtmobile.Value;
            DataSet ds = PersonalClass.GetList(cl);
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                string NewPass = TerraficPlanBLL.Utility.RandomString(5);
                var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPass + "~!@", "MD5");
                cl.Pass = hash;
                int t = PersonalClass.UpdatePass(cl);
                if (t == 0)
                {
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "خطا در تغییر کلمه عبور!!");
                    return;
                }
                string MsgMobile = "  گذر واژه شما به " + Environment.NewLine + NewPass + Environment.NewLine + "  تغییر پیدا کرد ";
                if (TerraficPlan.PublicFunction.SendSMSs(txtmobile.Value, MsgMobile) == 1)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "کلمه عبور شما ارسال شد لطفا دقایقی منتظر باشید.");
                else
                 TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "در ارسال پیامک مشکل ایجاد شده است.");


 
            }
            else {
                //Response.Redirect("/Public/RegPerson.aspx");
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "شماره همراه در سیستم موجود نمیباشد لطفا ابتدا اقدام به ثبت نام نمایید");
            
            }
            
        }
    }
}