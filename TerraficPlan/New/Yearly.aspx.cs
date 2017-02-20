using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TrafficPlanDAL;
using TrafficPlanCL;
using System.Data;
using TerraficPlanBLL;
using System.IO;

namespace TerraficPlan.New
{
    public partial class Yearly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack)
            {
                lblRahCode.Text = PublicFunction.GetUniquCode();
                lblREpeatTypeID.Text = Convert.ToInt32(Request.QueryString["tid"].ToString()).ToString();
                if (lblREpeatTypeID.Text == "4")
                    TrMonth.Visible = true;
                else if (lblREpeatTypeID.Text == "5")
                    Trseason.Visible = true;
                else if (lblREpeatTypeID.Text == "6")
                { trYear.Visible = true; BindYear(); ts.Visible = true; isSakenSelected.Visible = true; }

                tareff.Value = PublicFunction.GetTareefe(Convert.ToInt32(lblREpeatTypeID.Text),null);
                if (Request.QueryString["tid"] != null)
                {
                    if (Request.QueryString["tid"].ToString() == "6")
                        trmoarrefi.Visible = true;
                    else
                        trmoarrefi.Visible = false;
                }
            }
            typee.Value = lblREpeatTypeID.Text;
        }

        private bool CheckSaken()
        {
            if (isSakenSelected.Checked && (txtLastName.Text == "" || txtFirstName.Text == "" || txtAdress.Text == ""))
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "ارسال نام و نام خانوادگی و آدرس الزامی است");
                return false;
            }

            if (isSakenSelected.Checked && !(FileUploadghabz.HasFile && FileUploadSanad.HasFile))
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "اگر ساکن محدوده هستید ارسال سند یا قولنامه و قبض خانه الزامی است");
                return false ;
            }

            return true;

        }

        private void BindYear()
        {
            ClCatalog cl = new ClCatalog();
            cl.CatalogTypeID = Convert.ToInt32("10");

            DataSet ds = CatalogClass.GetList(cl);
            ddYear.DataSource = ds;
            ddYear.DataTextField = "CatalogName";
            ddYear.DataValueField = "CatalogValue"; 
            ddYear.DataBind();
            ds.Dispose();
        }
        private string GetMonth(){
            string allmonth ="";
            if(ch1.Checked)
                allmonth+="1,";
            if(ch2.Checked)
                allmonth+="2,";
            if(ch3.Checked)
                allmonth+="3,";
            if(ch4.Checked)
                allmonth+="4,";
            if(ch5.Checked)
                allmonth+="5,";
            if(ch6.Checked)
                allmonth+="6,";
            if(ch7.Checked)
                allmonth+="7,";
            if(ch8.Checked)
                allmonth+="8,";
            if(ch9.Checked)
                allmonth+="9,";
            if(ch10.Checked)
                allmonth+="10,";
            if(ch11.Checked)
                allmonth+="11,";
            if(ch12.Checked)
                allmonth+="12,";
            if (allmonth != "")
            {
                if (allmonth.Remove(allmonth.Length - 1).Length > 0)
                    return allmonth.Remove(allmonth.Length - 1);
                else
                    return "";
            }
            else
                return "";

                 
        }
          private string GetSeason(){
              string allse="";
              if(chbahar.Checked)
                  allse+="1,";
              if(chtab.Checked)
                  allse+="2,";
              if(chpayyz.Checked)
                  allse+="3,";
              if(chzem.Checked)
                  allse+="4,";
              if (allse != "")
              {
                  if (allse.Remove(allse.Length - 1).Length > 0)
                      return allse.Remove(allse.Length - 1);
                  else
                      return "";
              }
              else
                  return "";
          }

          private void Uploadmadarek(int t)
          {
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
              if (FileUploadmorrefi.HasFile)
              {
                  ClAttach ClAttach2 = new ClAttach();
                  ClAttach2.ForTable = "Tbl_Car";
                  ClAttach2.ForID = Convert.ToInt32(t);
                  ClAttach2.ForCatalogType = 1;
                  ClAttach2.ForCatalogValue = 2;
                  ClAttach2.AttachName = FileUploadmorrefi.FileName;
                  int iattach2 = AttachClass.insert(ClAttach2);
                  //save the file to our local path
                  FileUploadmorrefi.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach2.ToString()) + Path.GetExtension(FileUploadmorrefi.FileName));
                  if (iattach2 == 0)
                      TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
              }

          }
          private void Uploadmadarekjanbaz(int t)
          {
              string tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
              /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
              string fileName = Path.Combine(Server.MapPath(tempPath), FileUploadjanbaz.FileName);
              ClAttach ClAttach1 = new ClAttach();
              ClAttach1.ForTable = "Tbl_Car";
              ClAttach1.ForID = Convert.ToInt32(t);
              ClAttach1.ForCatalogType = 1;
              ClAttach1.ForCatalogValue = 1;
              ClAttach1.AttachName = FileUploadjanbaz.FileName;
              int iattach = AttachClass.insert(ClAttach1);
              //save the file to our local path
              FileUploadjanbaz.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach.ToString()) + Path.GetExtension(FileUploadjanbaz.FileName));
              if (iattach == 0)
                  TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
              //////////////////////////////////////////////////////////////
          }

           private void UploadmadarekSaken(int t)
          {
              string tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
              /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
              string fileName = Path.Combine(Server.MapPath(tempPath), FileUploadSanad.FileName);
              ClAttach ClAttach1 = new ClAttach();
              ClAttach1.ForTable = "Tbl_Car";
              ClAttach1.ForID = Convert.ToInt32(t);
              ClAttach1.ForCatalogType = 100;
              ClAttach1.ForCatalogValue = 3;
              ClAttach1.AttachName = FileUploadSanad.FileName;
              int iattach = AttachClass.insert(ClAttach1);
              //save the file to our local path
              FileUploadSanad.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach.ToString()) + Path.GetExtension(FileUploadSanad.FileName));
              if (iattach == 0)
                  TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
              ///////////////////////////////// ////////////////////////////////////////////////////////////////////////////// /////////////////////////////// 
              if (FileUploadghabz.HasFile)
              {
                  ClAttach ClAttach2 = new ClAttach();
                  ClAttach2.ForTable = "Tbl_Car";
                  ClAttach2.ForID = Convert.ToInt32(t);
                  ClAttach2.ForCatalogType = 100;
                  ClAttach2.ForCatalogValue = 4;
                  ClAttach2.AttachName = FileUploadghabz.FileName;
                  int iattach2 = AttachClass.insert(ClAttach2);
                  //save the file to our local path
                  FileUploadghabz.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach2.ToString()) + Path.GetExtension(FileUploadghabz.FileName));
                  if (iattach2 == 0)
                      TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
              }
              //////////////////////////////////////////////////////////////

          }

          public bool checkAjance()
          {
              ClCar cl = new ClCar();
              cl.Pelak = CtlPelak.Text;
              DataSet ds = CarClass.GetList(cl);
              if (ds.Tables[0].Rows.Count > 0)
                  return true;
              else
                  return false;
          }
        protected void btnAddRequest_Click(object sender, EventArgs e)
        {


            string RepeatTypeValues="";
            if(lblREpeatTypeID.Text=="6")
            { trYear.Visible = true; RepeatTypeValues = ddYear.SelectedValue; isSakenSelected.Visible = true; ts.Visible = true; }
            else if(lblREpeatTypeID.Text=="4")
            { TrMonth.Visible=true; RepeatTypeValues=GetMonth();}
            else if(lblREpeatTypeID.Text=="5")
            { Trseason.Visible=true; RepeatTypeValues=GetSeason();}

            
            if(RepeatTypeValues=="")
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "باید طرح را انتخاب نمایید");
                return;
            }

            if (!CtlPelak.MustBeFill)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "وارد کردن پلاک الزامی است");
                return;
            }

            //if (rbWhithDiscount.Checked && !checkAjance())
            //{
            //    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خودرو وارده در آژانس ثبت نشده است");
            //    return;
            //}

            ClRequestTraffic  objreq=new ClRequestTraffic();
            objreq.TrackingCode=lblRahCode.Text;
            objreq.Pelak=CtlPelak.Text;
            objreq.ModelCar=DDCarModel.Text;
            objreq.NationalCode=TXTNationalCode.Text;
            objreq.Mobile=TXTPersonalMobile.Text;
            objreq.RepeatTypeID=Convert.ToInt32( lblREpeatTypeID.Text);
            objreq.RepeatTypeValues=RepeatTypeValues;
            objreq.OwnerType=1;
            objreq.Firstname = txtFirstName.Text;
            objreq.LastName=txtLastName.Text;
            objreq.Adress = txtAdress.Text;
            objreq.CodePosti = txtPostiCode.Text;


            if (isSakenSelected.Checked)
                objreq.PersonalType = 2;
                else if(isSakenSelected2.Checked)
                objreq.PersonalType = 1;
            else
                objreq.PersonalType = 0;

            //objreq.DiscountType = Disscount;


            if (isSakenSelected2.Checked)
                objreq.DiscountType = 1007;
            if (isSakenSelected.Checked)
                objreq.DiscountType = 1008;



            int carid = RequestTrafficClass.insertNew(objreq);
            if (carid == 0)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در ثبت");
            }
            else
            {

                try
                {
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

                    
                    Uploadmadarek(carid);

                    if (isSakenSelected.Checked)
                         UploadmadarekSaken(carid);
                    else if (isSakenSelected2.Checked)
                         Uploadmadarekjanbaz(carid);

 
                 //LightBox.Value = "1";
                  Response.Redirect("~/New/RegSucces.aspx?code="+lblRahCode.Text);
                }
                catch
                {
                    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در ارسال مدارک به سرور");
                }

                //lblRahCode.Text = PublicFunction.GetUniquCode();
            }


         }
    }
}