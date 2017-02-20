using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanDAL;
using TrafficPlanCL;
using System.Web.UI.HtmlControls;
using System.IO;
using TerraficPlanBLL;

namespace TerraficPlan.Public
{
    public partial class Discount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var liActive = (HtmlGenericControl)Master.FindControl("step1");
            liActive.Attributes.Add("class", "complete");
            var liActive2 = (HtmlGenericControl)Master.FindControl("step2");
            liActive2.Attributes.Add("class", "complete");
             var liActive3 = (HtmlGenericControl)Master.FindControl("step3");
            liActive3.Attributes.Add("class", "active");               

            LblRequestID.Text = Session["rid"].ToString();
            if (Session["CompanyID"].ToString()=="0")
            lblOwnerType.Text = "1";
            else
            lblOwnerType.Text = "2";

            if (Session["CompanyID"] == null || Session["CompanyID"] == "0")
 lblownerTypeNamee.Text = "تخفیف ها برای شخص حقیقی";
            else
             { lblownerTypeNamee.Text = "تخفیف ها برای شخص حقوقی"; lblalarmDiscountType.Text = "معرفی نامه از نهاد مربوطه الزامی است"; }
              


            if (!Page.IsPostBack) {
                BindDD();
                BindMadarek();
                if (lblOwnerType.Text == "1")
                    lblalarmDiscountType.Text = "ارایه کپی جانبازی الزامی است";
               

            }
        }
        public void BindDD() {
            ClCatalog cl=new ClCatalog();
            cl.parentID=Convert.ToInt32(lblOwnerType.Text);
            DDDiscountType.DataSource = CatalogClass.GetList(cl);
            DDDiscountType.DataTextField = "CatalogName";
            DDDiscountType.DataValueField = "caid";
            DDDiscountType.DataBind();
        }
        protected void RdList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertDay_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile   )
            {
                string Alarm = CSharp.PublicFunction.CheckFile(FileUpload1.PostedFile);
                if (Alarm != "") { TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, Alarm); return; }
            }
            else if (DDDiscountType.SelectedValue.ToString() != "1009")
            { TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "ارسال مدرک جهت تخفیف الزاامی است"); return; }

            
            
            
            int t =0;
            if (rbWhithDiscount.Checked) { 
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.RequestTrafficID = Convert.ToInt32( Session["rid"].ToString());
            cl.DiscountType = Convert.ToInt32(DDDiscountType.SelectedValue);
           t= RequestTrafficClass.Update(cl);
           lblDIscountID.Text = t.ToString();
            if ( t== 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا");
                //else
                //TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "تخفیف ثبت شد. شهروند گرامی پس از بررسی صحت مدارک تخفیف لحاظ گشته و نتیجه به شما پیامک میگردد");
            }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FileUpload1.HasFile)
            {
                string tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
                string fileName = Path.Combine(Server.MapPath(tempPath), FileUpload1.FileName);
                ClAttach ClAttach1 = new ClAttach();
                ClAttach1.ForTable = "Tbl_RequestTraffic";
                ClAttach1.ForID = Convert.ToInt32(t);

                if (lblOwnerType.Text == "1")
                    ClAttach1.ForCatalogType = 5;
                else
                    ClAttach1.ForCatalogType = 6;

                ClAttach1.ForCatalogValue = Convert.ToInt32(DDDiscountType.SelectedValue);
                ClAttach1.AttachName = FileUpload1.FileName;
                int iattach = AttachClass.insert(ClAttach1);
                //save the file to our local path
                FileUpload1.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach.ToString()) + Path.GetExtension(FileUpload1.FileName));
                if (iattach == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
            }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            BindMadarek();

            lbltakhfif.Text = "1";
        }

        private void BindMadarek() {
            String ID = LblRequestID.Text; //id.ToString();// ((HtmlAnchor)sender).HRef.ToString();
            ClAttach cl = new ClAttach();
            cl.ForTable = "Tbl_RequestTraffic";
            cl.ForID = Convert.ToInt32(ID);
            rpPic.DataSource = AttachClass.GetList(cl);
            rpPic.DataBind();
           // LightBox.Value = "1";
        }
        protected void nextlink(object sender, EventArgs e)
        {
   
            if(rbWhithOutDiscount.Checked)
                Response.Redirect("/Public/repeat.aspx?takhfif="+ "0" +"");
            else
            {
                if(lblDIscountID.Text=="")
                {
                    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "برای دریافت تخفیف شما باید نوع تخفیف را به همراه مدارک لازمه انتخاب و روی دکمه ثبت کلیک نمایید");
                    return;
                }
                else
                Response.Redirect("/Public/repeat.aspx?takhfif="+ lbltakhfif.Text +"");

            }
           

        }
   
    }
}