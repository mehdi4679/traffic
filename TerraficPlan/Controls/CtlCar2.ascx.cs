using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
using TerraficPlanBLL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

namespace TerraficPlan.Controls
{
    public partial class CtlCar2 : System.Web.UI.UserControl
    {
        public ClCar Data
        {
            get
            {
                ClCar cl = new ClCar();
                cl.Pelak = txtpelek.Text;
                cl.CarCapacity = Convert.ToInt32(DDCarCapacity.SelectedValue);
                cl.CarColor = TXTCarColor.Text;
                cl.CarModel = DDCarModel.Text;
                cl.VIN = TXTVIN.Text;
                cl.CarType = DDCarType.Text;
                cl.PersonID = Convert.ToInt32(lblPersonID.Text);
                return cl;
            }
            set
            {
                DataSet ds = CarClass.GetList(value);
                DataRow dr = ds.Tables[0].Rows[0];
                txtpelek.Text = dr["pelek"].ToString();
                TXTCarColor.Text = dr["CarColor"].ToString();
                TXTVIN.Text = dr["VIN"].ToString();
                DDCarType.Text = dr["CarType"].ToString();
                DDCarCapacity.SelectedValue = dr["CarCapacity"].ToString();
                DDCarModel.Text = dr["CarModel"].ToString();
                lblPersonID.Text = dr["PersonID"].ToString();
                ds.Dispose();
            }
        }

        public void BindDD()
        {
            ////DDCarModel.DataSource = CatalogClass.GetListTypeID("2");
            ////DDCarModel.DataTextField = "CatalogName";
            ////DDCarModel.DataValueField = "CatalogValue";
            ////DDCarModel.DataBind();

            DDCarCapacity.DataSource = CatalogClass.GetListTypeID("3");
            DDCarCapacity.DataTextField = "CatalogName";
            DDCarCapacity.DataValueField = "CatalogValue";
            DDCarCapacity.DataBind();

            //DDCarType.DataSource = CatalogClass.GetListTypeID("1");
            //DDCarType.DataTextField = "CatalogName";
            //DDCarType.DataValueField = "CatalogValue";
            //DDCarType.DataBind();     

        }

        public int SelectedCar
        {
            get
            {
            //    int SelectedCaar = 0;
            //    foreach (RepeaterItem item in GridView1.Items)
            //    {
            //        CheckBox ch = (CheckBox)item.FindControl("chSelect");
            //        if (ch.Checked)
            //            SelectedCaar = Convert.ToInt32(ch.Attributes["carid"].ToString());
            //    }
                return 1;
            }
           
        }

        public int CarID
        {
            get { return Convert.ToInt32(LblParamCarID.Text); }
            set { LblParamCarID.Text = value.ToString(); }
        }
        public int PersonID
        {
            get { return Convert.ToInt32(lblPersonID.Text); }
            set { lblPersonID.Text = value.ToString(); }
        }
        public void BindGrid()
        {
            ClCar cl = new ClCar();
            cl.PersonID = PersonID;
            DataSet ds = CarClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["CarID"] == null)
            {
                ViewState["CarID"] = "CarID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["CarID"].ToString()).ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }

        public void DeleteItem(object sender, System.EventArgs e)
        {
            String CarID = ((HtmlAnchor)sender).HRef.ToString();
            int i = CarClass.Delete(CarID, Convert.ToInt32(lblPersonID.Text));
            if (i == 0)
            {

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else { BindGrid(); }
            LightBox.Value = "0";
        }

        private bool CheckDate()
        {

            bool result = true;
            int diffYear = 0;

            try
            {
                if (rdSahmsi.Checked)
                    diffYear = DateTime.Now.Year - Convert.ToInt32(DateConvert.sh2m(DDCarModel.Text + "/01/01").Year);
                else
                    diffYear = DateTime.Now.Year - Convert.ToInt32(Convert.ToDateTime(DDCarModel.Text + "/01/01").Year);
            }
            catch
            {
                result = false;
            }

            if (diffYear < 0 || diffYear > 30)
                result = false;


            return result;

        }


        protected void BtnInsert_Click2(Object sender, System.EventArgs e)
        {
            if (!CheckDate())
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "مدل خودرو  را درست وارد نماییدوبه خودرو های بالای 30 سال مجوز داده نمیشود");
                return;
            }
            if (txtpelek.Text.Length < 8)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "پلاک را درست وارد نمایید");
                return;
            }

            if (FileUploadCard.HasFile)
            {
                string Alarm = CSharp.PublicFunction.CheckFile(FileUploadCard.PostedFile);
                if (Alarm != "") { TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, Alarm); return; }
            }
            else
            { TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "ارسال کارت خودرو الزاامی است"); return; }

            if (FileUploadFani.HasFile)
            {
                string Alarm = CSharp.PublicFunction.CheckFile(FileUploadFani.PostedFile);
                if (Alarm != "") { TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, Alarm); return; }
            }
            else if (
             (DateTime.Now.Year - Convert.ToInt32(DateConvert.sh2m(DDCarModel.Text + "/01/01").Year) > 6 && rdSahmsi.Checked) ||
         (DateTime.Now.Year - Convert.ToInt32(Convert.ToDateTime(DDCarModel.Text + "/01/01").Year) > 6 && rdmilady.Checked)
             )
            { TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "ارسال کارت معاینه فنی  برای خودروهای زیر 5 سال الزاامی است"); return; }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ClCar cl = new ClCar();
            cl = Data;
            int t = 0;
            if (CSharp.PublicFunction.ModeInsert(CarID.ToString()))
                t = CarClass.insert(cl);
            else
                t = CarClass.Update(cl);
            if (t == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت");
            else
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "ثبت خودرو انجام شد.کاربر گرامی از بین خودرهای ثبت شده خود,یکی را انتخاب و دکمه مرحله بعد را بزنید.");
                BindGrid();
            }

            string tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string fileName = Path.Combine(Server.MapPath(tempPath), FileUploadCard.FileName);
            ClAttach ClAttach1 = new ClAttach();
            ClAttach1.ForTable = "Tbl_Car";
            ClAttach1.ForID = Convert.ToInt32(t);
            ClAttach1.ForCatalogType = 1;
            ClAttach1.ForCatalogValue = 1;
            ClAttach1.AttachName = FileUploadCard.FileName;
            int iattach = AttachClass.insert(ClAttach1);
            //save the file to our local path
            FileUploadCard.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach.ToString()) + Path.GetExtension(FileUploadCard.FileName));
            if (iattach == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
            ///////////////////////////////// ////////////////////////////////////////////////////////////////////////////// /////////////////////////////// 
            if (FileUploadFani.HasFile)
            {
                ClAttach ClAttach2 = new ClAttach();
                ClAttach2.ForTable = "Tbl_Car";
                ClAttach2.ForID = Convert.ToInt32(t);
                ClAttach2.ForCatalogType = 1;
                ClAttach2.ForCatalogValue = 2;
                ClAttach2.AttachName = FileUploadFani.FileName;
                int iattach2 = AttachClass.insert(ClAttach2);
                //save the file to our local path
                FileUploadFani.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach2.ToString()) + Path.GetExtension(FileUploadFani.FileName));
                if (iattach2 == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
            }
            //////////////////////////////////////////////////////////////




        }

        protected void viewAttach_ServerClick(object sender, EventArgs e)
        {
            String ID = ((HtmlAnchor)sender).HRef.ToString();
            ClAttach cl = new ClAttach();
            cl.ForTable = "Tbl_Car";
            cl.ForID = Convert.ToInt32(ID);
            rpPic.DataSource = AttachClass.GetList(cl);
            rpPic.DataBind();
            LightBox.Value = "1";
        }

        protected void rpPic_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void rpPic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        
            
    }
}