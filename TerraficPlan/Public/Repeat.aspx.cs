using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Globalization;
using TerraficPlanBLL;

namespace TerraficPlan.Public
{
    public partial class Repeat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var liActive = (HtmlGenericControl)Master.FindControl("step1");
            liActive.Attributes.Add("class", "complete");
            var liActive2 = (HtmlGenericControl)Master.FindControl("step2");
            liActive2.Attributes.Add("class", "complete");
            var liActive3 = (HtmlGenericControl)Master.FindControl("step3");
            liActive3.Attributes.Add("class", "complete");    
            var liActive4 = (HtmlGenericControl)Master.FindControl("step4");
            liActive4.Attributes.Add("class", "active");
            if (Securenamespace.SecureData.CheckSecurity( Request.QueryString["takhfif"].ToString() )== "1")
                dPrice.Visible = false;

            if (Session["CompanyID"].ToString() == "0")
                lblOwnerType.Text = "1";
            else
                lblOwnerType.Text = "2";
            LblRequestID.Text = Session["rid"].ToString();
            BindGrid();
            BindSelectedItem();
            BindYear();
        }

        private void BindSelectedItem() { 
        ClCatalog cl=new ClCatalog();
            cl.CatalogTypeID=Convert.ToInt32( "7");
            cl.Select=1;
            DataSet ds = CatalogClass.GetList(cl);
            rpSelectAllow.DataSource = ds;
            rpSelectAllow.DataBind();
            ds.Dispose();
        }
        private void BindYear()
        {
            ClCatalog cl = new ClCatalog();
            cl.CatalogTypeID = Convert.ToInt32("10");
           
            DataSet ds = CatalogClass.GetList(cl);
            rpYear.DataSource = ds;
            rpYear.DataBind();
            ds.Dispose();
        }
        public void BindGrid() {
            ClRequestRepeat cl = new ClRequestRepeat();
            cl.RequestID = Convert.ToInt32(LblRequestID.Text);
            DataSet ds= RequestRepeatClass.GetList(cl);
            dlistselect.DataSource =ds.Tables[0];
            dlistselect.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                lblprice.Text = dr["pricee"].ToString();
                //  lblPriceFa.Text=TerraficPlanBLL.NumbertoText.getnum3(Convert.ToInt32(dr["pricee"].ToString()));
            }
            else { 
                 lblprice.Text = "0";
            }
            ds.Dispose();
         }
        protected void btnInsertDay_Click(object sender, EventArgs e)
        {
            ClRequestRepeat cl = new ClRequestRepeat();
            cl.RepeatDate =DateConvert.sh2m( CtlDatePicker1.Text).ToString();
            cl.RequestID = Convert.ToInt32(LblRequestID.Text);
            cl.RepeatTypeID = Convert.ToInt32( ddHalfDay.SelectedValue);
            int t = RequestRepeatClass.insert(cl);
            if ( t== 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت!!!");
            else  if(t==-100)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "تداخل در تاریخ های انتخابی وجود دارد.لطفا دقت نمایید!!!");
            else
                BindGrid();
            LightBox.Value = "1";
        }
        public void RestLight() {
            LightBox.Value = "0";
            LightBox2.Value = "0";
            LightBox3.Value = "0";
            LightBox4.Value = "0";
            
        }
        protected void MonthClick(object sender, EventArgs e)
        {
            
            HtmlAnchor a = (HtmlAnchor)sender;
            int RepeatTypeID =Convert.ToInt32(LightBoxvalue.Value);
            int repeateVaue= Convert.ToInt32(a.HRef.ToString());
         
            ClRequestRepeat cl = new ClRequestRepeat();
             cl.RequestID = Convert.ToInt32(LblRequestID.Text);
            cl.RepeatTypeID = RepeatTypeID;
            cl.YearMonthSeasonID = repeateVaue;
            int t = RequestRepeatClass.insert(cl);
            if ( t== 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت!!!");
            else if(t==-100)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "تداخل در تاریخ های انتخابی وجود دارد.لطفا دقت نمایید!!!");
            else
                BindGrid();
        }

        protected void RepeatDelete(object sender, EventArgs e)
        {
            HtmlAnchor c = (HtmlAnchor)sender;
          int  id =Convert.ToInt32( c.HRef.ToString());
          ClRequestRepeat cl = new ClRequestRepeat();
          cl.RequestRepeatID = id;
          if (RequestRepeatClass.Delete(id.ToString()) == 0)
              TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در حذف");
          else
              BindGrid();

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            if (dlistselect.Items.Count == 0)  
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "هیچ تعرفه ای انتخاب نشده است.لطفا تعرفه مورد نظر را انتخاب و سپس وارد مرحله بعد گردید");
                else
                Response.Redirect("/Public/TrackingCode.aspx?takhfif=" + Securenamespace.SecureData.CheckSecurity( Request.QueryString["takhfif"].ToString() )+ "");
         }
        


    }
}