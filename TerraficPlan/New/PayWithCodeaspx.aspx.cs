using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanDAL;
using TerraficPlanBLL;
using TrafficPlanCL;
using System.Data;

namespace TerraficPlan.New
{
    public partial class PayWithCodeaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cp"] != null)
                  if(Request.QueryString["cp"].ToString()=="100")
                      lblheadrr.Text = "جهت  مشاهده درخواست تغییر پلاک کد ملی و کد رهگیری خربد خود را وارد نمایید";
else

                    lblheadrr.Text = "جهت تغییر پلاک کد ملی و کد رهگیری خربد خود را وارد نمایید";

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtcode.Value=="" || txtUserName.Value=="")
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "وارد کردن کد رهگیری و کد ملی الزامی است");
                return;
            }


            string personid ="0";
            ClPersonal clperson = new ClPersonal();
            clperson.NationalCode = txtUserName.Value;
            DataSet dsperson = PersonalClass.GetList(clperson);
            if(dsperson.Tables[0].Rows.Count>0)
            {
                DataRow drperson = dsperson.Tables[0].Rows[0];
                personid = drperson["PersonalID"].ToString();
          
                    ClRequestTraffic cl = new ClRequestTraffic();
                    cl.PersonalID = Convert.ToInt32(personid);
                    cl.TrackingCode = txtcode.Value;
                
                    DataSet ds = RequestTrafficClass.GetList(cl);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                    DataRow dr = ds.Tables[0].Rows[0];
                        Session["code"] = dr["TrackingCode"].ToString();

                        if (Request.QueryString["cp"] == null)
                            Response.Redirect("~/New/RegSucces.aspx?Code=" + dr["TrackingCode"].ToString());
                        else if (Request.QueryString["cp"].ToString() == "100")
                            Response.Redirect("~/New/cpr.aspx?rid=" + dr["RequestTrafficID"].ToString());
                        else
                            Response.Redirect("~/New/ChangPelak.aspx?Code=" + dr["TrackingCode"].ToString() + "&pid=" + dr["PersonalID"].ToString() + "&rid=" + dr["RequestTrafficID"].ToString());

                    }
                    else
                    {
                        TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "کد رهگیری اشتباه است");
                    }


            }
            else
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "کد ملی در سامانه موحود نمیباشد");
            }
         }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (txtmobile.Value.ToString() == "")
                return;
            ClRequestTraffic cl = new ClRequestTraffic();
             
            cl.Mobile = txtmobile.Value;
            cl.RequestStatus=0;

            DataSet ds = RequestTrafficClass.GetList(cl);
            DataView dv=new DataView(ds.Tables[0]);
            dv.Sort="RequestTrafficID desc";
             

                string MsgMobile ="کد رهگیری شما:"+Environment.NewLine;
            int tt=0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                    foreach (DataRowView rowView in dv)
                    {
                        if(tt<3){
                    DataRow row = rowView.Row;
                    MsgMobile += "  " + row["TrackingCode"].ToString() + Environment.NewLine;
                        tt+=1;
                            }
                        else
                            break;
                     }

                     if (TerraficPlan.PublicFunction.SendSMSs(txtmobile.Value, MsgMobile) == 1)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "کلمه عبور شما ارسال شد لطفا دقایقی منتظر باشید.");
                    else
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "در ارسال پیامک مشکل ایجاد شده است.");

            }
            else
                 TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "شماره همراه در سیستم موجود نمیباشد یا درخواست در حالت انتظار پاسخ از مرکز ندارید");

 


            }
          

 
        }
    }
 
