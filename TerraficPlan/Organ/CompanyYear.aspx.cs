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
using System.Configuration;

namespace TerraficPlan.Organ
{
    public partial class CompanyYear : System.Web.UI.Page
    {
        private string MerchantId = "10321755";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lblPersonID.Text = Session["PersonalID"].ToString();
                lblCompanyID.Text = GetCompanyID(Convert.ToInt32(lblPersonID.Text));

                BindDD();

                BindGrid();
            }
            Visiblebtnpay();
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

        private void BindCar()
        {
            ClCar cl = new ClCar();
            cl.PersonID =Convert.ToInt32( lblPersonID.Text);
            cl.yearID = Convert.ToInt32(ddYear.SelectedValue);

            ddCar.DataSource = CarClass.GetListCarInYear(cl);
            ddCar.DataTextField = "carname";
            ddCar.DataValueField = "CarID";
            ddCar.DataBind();

        }
        private void BindDD()
        {
            BindYear();

            BindCar();

            BindDiscount();

            BindSahm();

 

        }
        private void BindDiscount()
        {
            //DDhagighiOrNot.DataSource = CatalogClass.GetListDiscountType();
            //DDhagighiOrNot.DataTextField = "CatalogName";
            //DDhagighiOrNot.DataValueField = "caid";
            //DDhagighiOrNot.DataBind();
            //DDhagighiOrNot.Items.Insert(0, new ListItem("انتخاب نمایید", "-1"));



        }
        private void BindSahm()
        {
            ClSahm clsahm = new ClSahm();
            clsahm.CompanyID = Convert.ToInt32(lblCompanyID.Text);
            clsahm.Year = Convert.ToInt32(ddYear.SelectedValue.ToString());
            ddsahmie.DataSource = SahmClass.GetListWhithHaghighi(clsahm);
            ddsahmie.DataTextField = "SahmName";
            ddsahmie.DataValueField = "SahmID";
            ddsahmie.DataBind();
        }

        private string GetCompanyID(int PersonalId)
        {

            ClCompany clCompany = new ClCompany();
            clCompany.PersonalID = PersonalId;
            DataSet ds = CompanyClass.GetListPersonl(clCompany);
                DataRow dr;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    lblCompanyID.Text = dr["CompanyID"].ToString();
                }
                ds.Dispose();
               return   lblCompanyID.Text ;
        }
        private bool correctData()
        {
            //if (Convert.ToInt32(txtDarsadJanbazi.Text)<=0 &&  Convert.ToInt32(txtDarsadJanbazi.Text)>=100)
            //{
            //    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "درصد جانبازی را بین 0 و 100 وارد نمایید");
            //    return false;
            //}

            //if (DDhagighiOrNot.SelectedValue == "-1")
            //{
            //    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "لطفا نوع را انتخاب نمایید");
            //    return false;

            //}



            return true;
        }
        private void Visiblebtnpay()
        {
            if (GridView1.Rows.Count == 0)
                btnnpayy.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            else
                btnnpayy.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "inherit";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {


            ClRequestTraffic cl = new ClRequestTraffic();
            cl.CarID =Convert.ToInt32(ddCar.SelectedValue);
            cl.CompanyID = Convert.ToInt32(lblCompanyID.Text);
             cl.PersonalID = Convert.ToInt32(lblPersonID.Text);
            cl.YearID = Convert.ToInt32( ddYear.SelectedValue);
            cl.RepeatTypeID = 6;
            cl.RepeatTypeValues = ddYear.SelectedValue;
            cl.SahmID =Convert.ToInt32( ddsahmie.SelectedValue);
            cl.DiscountType = 1067;


            //if (DDhagighiOrNot.SelectedValue == "1007" || DDhagighiOrNot.SelectedValue == "1008")
            //{ cl.OwnerType = 1; cl.CompanyID = null; }
            //else
            //    cl.OwnerType = 2;
            //if(DDhagighiOrNot.SelectedValue == "1007")
            //cl.DarsadJanbazi = Convert.ToInt32(txtDarsadJanbazi.Text);
            //else if(DDhagighiOrNot.SelectedValue == "1009")
            //cl.SahmID = Convert.ToInt32(ddsahmie.SelectedValue);



            if (!correctData())
                return;

            int i = RequestTrafficClass.insertGroup(cl);

            if (i > 0)
                BindGrid();
            else if(i==-1)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "برای این خودرو در این سال تخفیف اعمال شده است");
            else if(i==-100)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "سقف سهمیه پر شده است.");
                else
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در درج");



        }

        private void BindGrid()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.PersonalID = Convert.ToInt32(lblPersonID.Text);
            cl.RepeatTypeID = 6;
            cl.YearID =Convert.ToInt32( ddYear.SelectedValue);

            DataSet ds=RequestTrafficClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["RequestTrafficID"] == null)
            {
                ViewState["RequestTrafficID"] = "RequestTrafficID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["RequestTrafficID"].ToString()).ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
            BindCar();
            BindDiscount();
            if(ds.Tables[0].Rows.Count>0)
            rdcurrentSharj.Text = "با استفاده از شارژ موجود به مبلغ" + ds.Tables[0].Rows[0]["SharjCurrent"].ToString();
            ds.Dispose();

        }

        protected void ADel_ServerClick(object sender, EventArgs e)
        {
            string id = ((HtmlAnchor)sender).HRef.ToString();
            int i = TrafficPlanDAL.RequestTrafficClass.Delete(id);
            if (i == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "");
            else
                BindGrid();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string StrSortDirection = "desc";
            if (ViewState["RequestTrafficID" + "Direction"] == null)
            {
                ViewState.Add("RequestTrafficID" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["RequestTrafficID" + "Direction"].ToString();
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["RequestTrafficID" + "Direction"] = StrSortDirection;
            }
            ViewState["RequestTrafficID"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }

        protected void DDhagighiOrNot_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            int Price = 0;
            string allReq = "";
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    HtmlInputCheckBox ch = (HtmlInputCheckBox)GridView1.Rows[i].FindControl("chh");
                    Label lblprice = (Label)GridView1.Rows[i].FindControl("lblPricRow");
                    Label lblRequestTrafficID = (Label)GridView1.Rows[i].FindControl("lblRequestTrafficID");
                    if (ch.Checked)
                    {
                        Price += Convert.ToInt32(lblprice.Text);
                        allReq += lblRequestTrafficID.Text + ",";
                    }
                }
                if (allReq.Length<2)
                {
                    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "شما باید حداقل یک درخواست را برای پرداخت انتخاب نمایید");
                    return;
                }
            if (rdonline.Checked)
                Pay_Click(Price, allReq.Remove(allReq.Length - 1));
            else
                PayForSharj(Price,allReq.Remove(allReq.Length - 1));
        }

        private void PayForSharj(int price,string AllReq)
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.ALlRequest = AllReq;
            cl.PersonalID = Convert.ToInt32(lblPersonID.Text);
            cl.PayForShajDate = DateTime.Now.ToString();
            cl.AllPrice = price;

            int t = RequestTrafficClass.UpdateAllReqPayForShaj(cl);
            if (t == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در سیستم");
            else if (t == -10)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "شارژ موجود کم میباشد.لطفا یا پرداخت آنلاین نمایید یا شارژ خود را افزایش دهید");
            else
            {
                BindGrid();
                string error="";
                error = SendRequestToWS(AllReq);
                if(error!="")
                    TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,error);
            }
        }

        public   string SendRequestToWS(string str)
        {
            string[] arrayREq = str.Split(',');
            string error = "";
            for (int i = 0; i <= arrayREq.Length - 1; i++)
            {
                string RegMojaz = PublicFunction.RegWSmojaz(Convert.ToInt32(arrayREq[i]), 0);
                if (RegMojaz != "")
                    error += "" + arrayREq[i] + "" + RegMojaz;
            }
            if (error != "")
                return error;
            else
                return "";
                // TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, error);
        }
        private int GetGroupID(string AllRequest)
        {
            ClEpayGroup cl = new ClEpayGroup();
            cl.AllReq = AllRequest;
            cl.PersonalID = Convert.ToInt32(lblPersonID.Text);
            int i = EpayGroupClass.insertAllReq(cl);
            if (i == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در ثبت");

            return i;
        }

        public void Pay_Click( int price,string AllReq)
        {
            int groupID = GetGroupID(AllReq);
            if (groupID == 0)
                return;
            try
            {

                string url = ConfigurationManager.AppSettings["SafhePardakhtPage"];// Properties.Settings.Default.SafhePardakhtPage;


                string RedirectURL = ConfigurationManager.AppSettings["ReturnAddressOrgan"];// Properties.Settings.Default.ReturnAddress;

                ClEpayOrder cl = new ClEpayOrder();
                cl.GroupID = groupID;
                // cl.ResCode = resNum;
                cl.OrderDateStart = DateTime.Now.ToString();
                cl.IP = CSharp.PublicFunction.GetIPAddress();
                cl.OS = CSharp.PublicFunction.GetOS();
                cl.Prcie = Convert.ToInt32(price);
                cl.Browser = CSharp.PublicFunction.GetBrowser() + " " + CSharp.PublicFunction.GetBrowserVersion();
                int i = EpayOrderClass.insert(cl);
                if (i == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در برنامه");
                else
                    Response.Redirect(url + "?ResNum=" + i + "&MID=" +
                    MerchantId + "&RedirectURL=" + RedirectURL + "&Amount=" + price.ToString().Trim());

            }
            catch (Exception ex)
            {
            }
        }
    }
}