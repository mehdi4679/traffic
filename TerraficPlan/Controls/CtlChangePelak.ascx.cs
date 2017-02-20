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

namespace TerraficPlan.Controls
{
    public partial class CtlChangePelak : System.Web.UI.UserControl
    {
        public string ToCarId
        {
            get { return LblCarid1.Text; }
            set { LblCarid1.Text = value; }
        }
        public string FromCarId
        {
            get { return LblCarid2.Text; }
            set { LblCarid2.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        
            CtlCar.peeee += new CtlCar.calll(InsertChangCar);
            CtlCar.HeaderText = "پلاک جدید:کاربر گرامی برای ثبت پلاک جدید باید مشخصات کلی خودرو جدید را وارد نمایید";
            CtlCar.VisibleGrid = false;
        }
        public  void bindPElak()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            
            if(Lbl_RahCode.Text!="0")
            cl.TrackingCode =  Lbl_RahCode.Text ;
            
            if (Lbl_RequestTrafficID.Text != "0")
                cl.RequestTrafficID = Convert.ToInt32(Lbl_RequestTrafficID.Text);

           
            DataSet ds = TrafficPlanDAL.RequestTrafficClass.GetList(cl);
            DataRow dr = ds.Tables[0].Rows[0];
            CtlPelak1.Text = dr["Pelak"].ToString();
            FromCarId = dr["CarID"].ToString();
            Lbl_RequestTrafficID.Text = dr["RequestTrafficID"].ToString();
            lblRequestTrafficName.Text = dr["RequestTrafficName"].ToString();

            ds.Dispose();



        }

        public void InsertChangCar()
        {
            int tt = 0;
            ClPelakChange clpelakChang = new ClPelakChange();
            clpelakChang.FromCarID = Convert.ToInt32(FromCarId);
            clpelakChang.ToCarID = Convert.ToInt32(CtlCar.CarID);
            clpelakChang.CommentUser = txtCommentUser.Text;
            clpelakChang.RahCode = Lbl_RahCode.Text;
            clpelakChang.RequestTrafficID = Convert.ToInt32(Lbl_RequestTrafficID.Text);
            clpelakChang.RequestUser =Convert.ToInt32( CSharp.PublicFunction.GetUserID());


            tt = TrafficPlanDAL.PelakChangeClass.insert(clpelakChang);
            if (tt == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در تغییر پلاک");
            else
            {
                //if (LblPersonalID.Text == "0")
                    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.General_Success, "کاربر گرامی درخواست شما ثبت گردید.جهت پیگیری از کد رهگیری استفاده نمایید");
                //else
                //    BindGrid();


            }



        }

        public bool VisibleJanbaz
        {
            get { return CtlCar.VisibleGrid; }
            set { CtlCar.VisibleJanbaz = value; }
        }

     

        public string PersonalID
        {
            get { return LblPersonalID.Text; }
            set { LblPersonalID.Text = value; }
        }
         public string RahCode
        {
            get { return Lbl_RahCode.Text; }
            set { Lbl_RahCode.Text = value; }
        }

         public string RequestTrafficID
        {
            get { return Lbl_RequestTrafficID.Text; }
            set { Lbl_RequestTrafficID.Text = value; }
        }

        private int ChekPelak(string Pelak)
        {
            ClCar cl = new ClCar();
            cl.Pelak = Pelak;
            DataSet ds = CarClass.GetList(cl);
            if ((ds.Tables[0].Rows.Count) > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["CarID"].ToString());
            else
                return 0;
        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            LblCarid1.Text = ChekPelak(CtlPelak1.Text).ToString();
            if (LblCarid1.Text == "0")
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "پلاک جاری در سیستم موجود نیست");
                return;
            }
            CtlCar.Visible = true;



        }



    }
}