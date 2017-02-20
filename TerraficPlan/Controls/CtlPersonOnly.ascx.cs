 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TrafficPlanCL;
using TrafficPlanDAL;
using TerraficPlanBLL;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Security.Principal;

namespace TerraficPlan.Controls
{
    public partial class CtlPersonOnly : System.Web.UI.UserControl
    {
        public bool VisibleBtn
        {
            get { return BtnInsert.Visible; }
            set { BtnInsert.Visible = value; }
        }
        public ClPersonal Data
        {
            get
            {
                ClPersonal cl = new ClPersonal();
                cl.FirstName = TXTFirstName.Text;
                cl.LastName = TXTLastName.Text;
                cl.Email = TXTEmail.Text;
                cl.PersonalTel = TXTPersonalTel.Text;
                cl.PersonalMobile = TXTPersonalMobile.Text;
                cl.PostiCode = TXTPostiCode.Text;
                cl.NationalCode = TXTNationalCode.Text;
                cl.PersonalAdress = TXTPersonalAdress.Text;
                cl.JobName = TXTJobName.Text;
                cl.PersonalID = Convert.ToInt32( lblPersonalID.Text);
                return cl;
            }
            set
            {
                DataSet ds = PersonalClass.GetList(value);
                DataRow dr = ds.Tables[0].Rows[0];
                TXTFirstName.Text = dr["FirstName"].ToString();
                TXTLastName.Text = dr["LastName"].ToString();
                TXTEmail.Text = dr["Email"].ToString();
                TXTNationalCode.Text = dr["NationalCode"].ToString();
                TXTPersonalMobile.Text = dr["PersonalMobile"].ToString();
                TXTPersonalTel.Text = dr["PersonalTel"].ToString();
                TXTPostiCode.Text = dr["PostiCode"].ToString();
                TXTPersonalAdress.Text = dr["PersonalAdress"].ToString();
                TXTJobName.Text = dr["JobName"].ToString();
                lblPersonalID.Text = dr["PersonalID"].ToString();
                ds.Dispose();
            }
        }

        public bool UpdateMode {
            get { return Convert.ToBoolean( lblupdatemomde.Text);}
            set{lblupdatemomde.Text=value.ToString();
            if (value)
            {
                trpass.Visible = false;
                trrepass.Visible = false;

            }
            else
            {
                trpass.Visible = true;
                    trrepass.Visible=true;
            }
            }
        }

        public int PersonalID
        {
            get { return Convert.ToInt32(lblPersonalID.Text); }
            set { lblPersonalID.Text = value.ToString(); }
        }
             public string RedirectPage
        {
            get { return lblRedirect.Text; }
            set { lblRedirect.Text = value ; }
        }
     
        protected void BtnInsert_Click(Object sender, System.EventArgs e)
        {
            ClPersonal cl = new ClPersonal();
            cl = Data;

            //if (Utility.IsValidEmail(TXTEmail.Text)) {
            //    Utility.ShowMsg(Page, ProPertyData.MsgType.General_Fault, "ایمیل معتبر نیست");
            //    return;

            //}
            //if (Utility.isValidMelliCode(TXTNationalCode.Text)) {
            //    Utility.ShowMsg(Page, ProPertyData.MsgType.General_Fault, "کد ملی معتبر نیست");
            //    return;
            //}

            if (!UpdateMode)
            {

                if (txtpass.Text == "" || txtrepass.Text == "")
                {
                    Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "کلمه عبور را وارد نمایید");
                    return;
                }
                if (txtpass.Text.Length < 4)
                {   Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "کلمه عبور حداقل باید 4 کاراکتر باشد.");
                return;
                }
            }


            int t = 0;
            if (!UpdateMode)
            {  
              
                var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text + "~!@", "MD5");
                cl.Pass = hash;
                t = PersonalClass.insert(cl);}
            else
                t = PersonalClass.Update(cl);

            if (t == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت");
            else if (t == -1)
                TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,"کد ملی تکراری است  در صورت فراموشی کلمه عبور  روی گزینه رمز را فراموش کرده ام   صفحه ورود به سایت کلیک کنید.");
               // lblmsg.Text = ;
            else
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "ثبت انجام شد.");
                Session["PersonalID"] = t;
                Session["PersonaName"] = TXTFirstName.Text + " " + TXTLastName.Text;

                if(lblRedirect.Text!="")
                {
                    string role = "public";
                    var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpass.Text + "~!@", "MD5");
                    String userid = Session["PersonalID"].ToString();

                    HttpContext.Current.User = new GenericPrincipal(Page.User.Identity, new string[] { role });
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userid, DateTime.Now, DateTime.Now.AddMinutes(540), false, role, FormsAuthentication.FormsCookiePath);
                    hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    if (ticket.IsPersistent == true)
                        cookie.Expires = ticket.Expiration;

                    Response.Cookies.Add(cookie);
                Response.Redirect(lblRedirect.Text);
                
                }

            }

       
        }

        private void BindDD()
        {
           // DataSet ds=
        }
        public bool VisibleInsert {
            get {
                return BtnInsert.Visible;
            }
            set {
                BtnInsert.Visible = value;
            }
        }


    }
}