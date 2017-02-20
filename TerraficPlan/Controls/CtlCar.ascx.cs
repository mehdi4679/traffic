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

    public partial class CtlCar : System.Web.UI.UserControl
    {
                public  delegate  void    calll() ;
                public event calll peeee;

            public string FromCarD{
                get { return LblCarid1.Text; }
                set { LblCarid1.Text = value; }
}
            public string ToCarID{
                get { return LblCarid1.Text; }
                set { LblCarid1.Text = value; }
}
            public string  CommntUSer{
                get { return lblchangComment.Text; }
                set { lblchangComment.Text = value; }
}

            public string HeaderText
            {
                get { return LblHeaderText.Text; }
                set { LblHeaderText.Text = value; }
            }
        public ClCar Data
        {
            get
            {
                ClCar cl = new ClCar();
                cl.Pelak = txtpelek.Text;
                cl.CarCapacity =Convert.ToInt32( DDCarCapacity.SelectedValue);
                cl.CarColor = TXTCarColor.Text;
                cl.CarModel =  DDCarModel.Text ;
                cl.VIN = TXTVIN.Text;
                cl.CarType =   DDCarType.Text  ;
                cl.PersonID=Convert.ToInt32( lblPersonID.Text);
                cl.CarID = CarID;
                cl.SacrificeName = txtSacrificeName.Text;
                cl.SacrificePercent = txtSacrificePercent.Text;
                
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
                CarID =Convert.ToInt32( dr["CarID"].ToString());
                txtSacrificeName.Text = dr["SacrificeName"].ToString();
                txtSacrificePercent.Text = dr["SacrificePercent"].ToString();

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

            lblCarOFcompanyID.Text = lblPersonID.Text;
            CompnaytypeID();
            //DDCarType.DataSource = CatalogClass.GetListTypeID("1");
            //DDCarType.DataTextField = "CatalogName";
            //DDCarType.DataValueField = "CatalogValue";
            //DDCarType.DataBind();     
            
        }

        public int  CompnaytypeID()
        {
            string  ctype = "0";
            ClCompany cl = new ClCompany();
            cl.PersonalID = PersonID;
            DataSet ds = CompanyClass.GetListPersonl(cl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ctype = ds.Tables[0].Rows[0]["CompanyTypeID"].ToString();
                if (ctype == "2")
                { 
                    sa1.Visible = true;
                    sa2.Visible = true;
                }
                else
                {
                    sa1.Visible = false;
                    sa2.Visible = false;
                }
            }
            else
            {    
                sa1.Visible = false;
            sa2.Visible = false;
            ctype = "-1";
            }
            return Convert.ToInt32( ctype);
        }

        public int SelectedCar {
            get {
                int SelectedCaar =0;
                foreach (RepeaterItem item in GridView1.Items)
                {
                    CheckBox ch = (CheckBox)item.FindControl("chSelect");
                    if (ch.Checked)
                        SelectedCaar= Convert.ToInt32( ch.Attributes["carid"].ToString());
                }
                return SelectedCaar;
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
        public bool VisibleGrid
        {
           get{ return GridView1.Visible;}
            set {GridView1.Visible=value ;}
        }

        public bool VisibleJanbaz
        {
            get { return txtSacrificePercent.Visible;
            }
            set { 
                
            sa2.Visible = value;
            sa1.Visible = value;
                txtSacrificeName.Visible = value;
            txtSacrificePercent.Visible = value;
            }
        }
        public void BindGrid()
        {
            if (!VisibleGrid)
                return;

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
            int i = CarClass.Delete(CarID,Convert.ToInt32( lblPersonID.Text));
            if (i == 0)
            {
          
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else { BindGrid(); }
            LightBox.Value = "0";
        }

      private bool CheckDate() {
         
          bool result=true;
          int diffYear =0;

          try
          {
              if (rdSahmsi.Checked )
                  diffYear = DateTime.Now.Year - Convert.ToInt32(DateConvert.sh2m(DDCarModel.Text + "/01/01").Year);
              else
                  diffYear = DateTime.Now.Year - Convert.ToInt32(Convert.ToDateTime(DDCarModel.Text + "/01/01").Year);
          }
          catch {
              result = false;
          }

          if(diffYear<0 || diffYear>30)
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
            if (Convert.ToDecimal(txtSacrificePercent.Text) < 0 || Convert.ToDecimal(txtSacrificePercent.Text) > 70)
            { 
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "درصد جانبازی باید بین صفرو 100 باشد");
                return;
            }
            if (CompnaytypeID() == -1)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "ابتدا سازمان را تعریف نمایید");
                return;

            }
            //if (TXTVIN.Text.Length != 18)
            //{
            //    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "شماره وین خودرو را درست وارد نمایید");
            //    return;
            //}


             if (FileUploadCard.HasFile)
             {string Alarm=CSharp.PublicFunction.CheckFile(FileUploadCard.PostedFile);
                 if(Alarm!=""){TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,Alarm); return;} }
                else
             { TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,"ارسال کارت خودرو الزاامی است");return; }

             if (FileUploadFani.HasFile     )
             {string Alarm=CSharp.PublicFunction.CheckFile(FileUploadFani.PostedFile);
                 if(Alarm!=""){TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,Alarm); return;} }
                else if(
                 (DateTime.Now.Year- Convert.ToInt32( DateConvert.sh2m(DDCarModel.Text+"/01/01").Year)>6 && rdSahmsi.Checked) ||
             (DateTime.Now.Year- Convert.ToInt32( Convert.ToDateTime(DDCarModel.Text+"/01/01").Year)>6 && rdmilady.Checked)
                 )
             { TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,"ارسال کارت معاینه فنی  برای خودروهای زیر 5 سال الزاامی است");return; }
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
                if (VisibleGrid) { 
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "ثبت خودرو انجام شد..");
                 BindGrid();
                }
            }

                string tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                int iattach = 0;
            string fileName = Path.Combine(Server.MapPath(tempPath), FileUploadCard.FileName);
                 ClAttach ClAttach1 = new ClAttach();
                 ClAttach1.ForTable = "Tbl_Car";
                 ClAttach1.ForID = Convert.ToInt32(t);
                 ClAttach1.ForCatalogType = 1;
                 ClAttach1.ForCatalogValue =1;
                 ClAttach1.AttachName = FileUploadCard.FileName;
                   iattach = AttachClass.insert(ClAttach1);
                 //save the file to our local path
                 FileUploadCard.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach.ToString()) +Path.GetExtension(FileUploadCard.FileName));
                 if (iattach == 0)
                  TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
///////////////////////////////// ////////////////////////////////////////////////////////////////////////////// /////////////////////////////// 
                 int iattach2 = 0;
            if(FileUploadFani.HasFile)    {
            ClAttach ClAttach2 = new ClAttach();
                 ClAttach2.ForTable = "Tbl_Car";
                 ClAttach2.ForID = Convert.ToInt32(t);
                 ClAttach2.ForCatalogType = 1;
                 ClAttach2.ForCatalogValue =2;
                 ClAttach2.AttachName = FileUploadFani.FileName;
                   iattach2 = AttachClass.insert(ClAttach2);
                 //save the file to our local path
                 FileUploadFani.SaveAs(Path.Combine(Server.MapPath(tempPath), iattach2.ToString()) + Path.GetExtension(FileUploadFani.FileName));
                 if (iattach2 == 0)
                  TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Fault, "خطا در ثبت مدرک");
                }
//////////////////////////////////////////////////////////////

            if (t > 0   && iattach2 > 0 && iattach2>0)
            {
                CarID = t;
                 peeee();

                 
            }


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

        
            
         
        }

        //protected void chSelect_CheckedChanged(object sender, EventArgs e)
        //{

        //    //      CheckBox ch = (CheckBox)sender;
        //    //    int    CarID = Convert.ToInt32( ch.Attributes["carid"].ToString());

        //    //    ClRequestTraffic cl = new ClRequestTraffic();
        //    //    cl.CarID = CarID;
             
        //    //cl.PersonalID = Convert.ToInt32(Session["PersonID"]);
        //    //if (RequestTrafficClass.Update(cl) > 0)
        //    //    BindGrid();
        //    //else
        //    //    Utility.ShowMsg(Page, ProPertyData.MsgType.General_Fault, "در انتخاب خودرو خطا رخ داده است");


        //}

          

 

   
    }
