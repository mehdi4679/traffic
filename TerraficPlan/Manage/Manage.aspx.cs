using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TerraficPlanBLL;
using TrafficPlanCL;
using TrafficPlanDAL;
namespace TerraficPlan.Manage
{
    public partial class Manage : System.Web.UI.Page
    {
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String RequestTrafficID = ((HtmlAnchor)sender).HRef.ToString();
            int i = RequestTrafficClass.DeleteReal(RequestTrafficID);
            if (i == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else { BindGrid(); }

        }



        public void BindGrid()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
             cl.Firstname = txtname.Text;
            cl.LastName = txtLastName.Text;
            cl.fromDate = DateConvert.sh2m(txtFromDate.Text).ToString();
            cl.ToDate = DateConvert.sh2m(txtToDate.Text).ToString();
            cl.Pelak = CtlPelak.Text.Length > 5 ? CtlPelak.Text : null;
            cl.CompanyID =Convert.ToInt32( ddcompany.SelectedValue);
            cl.MelliCode = nationalCode.Text;

            if (ddRequestStatus.SelectedValue == "-1")
                cl.RequestStatus = null;
            else
            cl.RequestStatus = Convert.ToInt32(ddRequestStatus.SelectedValue)   ;


            DataSet ds = RequestTrafficClass.GetListManage(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["RequestTraffic"] == null)
            {
                ViewState["RequestTraffic"] = "RequestTrafficID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["RequestTraffic"].ToString()).ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        protected void gridview1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            //BindGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClPersonal cl = new ClPersonal();
                cl.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());

                DataSet ds = PersonalClass.GetList(cl);
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["Manage"].ToString() != "1")
                {
                    Response.Redirect("PersonalView.aspx?msg=شما دسترسی به این صفحه ندارید");
                    return;
                }

                txtFromDate.Text = DateConvert.m2sh(DateTime.Now.AddDays(-10).ToString());
                txtToDate.Text = DateConvert.m2sh(DateTime.Now.ToString());
                BindddNazar();

                if (Request.QueryString["sid"] != null)
                    ddRequestStatus.SelectedValue = Request.QueryString["sid"].ToString();

                if (Request.QueryString["pid"] != null)
                    SetNameAndFamil(Convert.ToInt32(Request.QueryString["pid"]));

                if (Request.QueryString["companyID"] != null)
                    ddcompany.SelectedValue = Request.QueryString["companyID"].ToString();


                BindGrid();
                if (GridView1.Items.Count == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "درخواستی وجود ندارد");

             
            }
        }

        private void SetNameAndFamil(int pid)
        {
            ClPersonal cl = new ClPersonal();
             cl.PersonalID = pid;
            DataSet ds = PersonalClass.GetList(cl);
            if(ds.Tables[0].Rows.Count>0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                //txtname.Text = dr["FirstName"].ToString();
                //txtLastName.Text = dr["LastName"].ToString();
                nationalCode.Text = dr["NationalCode"].ToString();
            }
            ds.Dispose();
        }
        private void BindddNazar()
        {
            DataSet ds = CatalogClass.GetListTypeID("11");

            ddnazar.DataSource = ds;
            ddnazar.DataTextField = "CatalogName";
            ddnazar.DataValueField = "CatalogValue";
            ddnazar.DataBind();


            ddRequestStatus.DataSource = ds;
            ddRequestStatus.DataTextField = "CatalogName";
            ddRequestStatus.DataValueField = "CatalogValue";
            ddRequestStatus.DataBind();
            ddRequestStatus.Items.Insert(0, new ListItem("همه موارد", "-1"));
             ddRequestStatus.Items.Insert(1, new ListItem("پرداخت شده", "-2"));

            ClCompany cl=new ClCompany();
            ddcompany.DataSource=CompanyClass.GetList(cl);
            ddcompany.DataTextField="CompanyName";
            ddcompany.DataValueField="CompanyID";
            ddcompany.DataBind();
            ddcompany.Items.Insert(0, new ListItem("بدون انتخاب", "0"));


            ds.Dispose();

        }
        protected void ACar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void Aselect_ServerClick(object sender, EventArgs e)
        {
            string RequestID = ((HtmlAnchor)sender).HRef.ToString();

            ClRequestRepeat cl = new ClRequestRepeat();
            cl.RequestID = Convert.ToInt32(RequestID);
            DataSet ds = RequestRepeatClass.GetList(cl);
            dlistselect.DataSource = ds.Tables[0];
            dlistselect.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                //   lblprice.Text = dr["pricee"].ToString();
                //  lblPriceFa.Text=TerraficPlanBLL.NumbertoText.getnum3(Convert.ToInt32(dr["pricee"].ToString()));
            }
            else
            {
                //  lblprice.Text = "0";
            }
            ds.Dispose();
            LightBoxRepeat.Value = "1";
        }

        protected void ATakhfif_ServerClick(object sender, EventArgs e)
        {
            //string RequestID = ((HtmlAnchor)sender).HRef.ToString();
            //LbliscountType.Text = ((HtmlAnchor)sender).Attributes["takhfifname"].ToString();

            //ClAttach cl = new ClAttach();
            //cl.ForTable = "Tbl_RequestTraffic";
            //cl.ForID = Convert.ToInt32(ID);
            //rpPictakhfif.DataSource = AttachClass.GetList(cl);
            //rpPictakhfif.DataBind();
            //// LightBox.Value = "1";
        }

        protected void APerson_ServerClick(object sender, EventArgs e)
        {
            string PersonalIDD = ((HtmlAnchor)sender).HRef.ToString();
            ClPersonal cl = new ClPersonal();
            cl.PersonalID = Convert.ToInt32(PersonalIDD);
            ctlperson.Data = cl;
            LightBoxPerson.Value = "1";
            ctlperson.VisibleInsert = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnNazar_Click(object sender, EventArgs e)
        {

            ClRequestTraffic cl = new ClRequestTraffic();
            cl.RequestTrafficID = Convert.ToInt32(txtRequestParam.Value.ToString());
            cl.RequestStatus = Convert.ToInt32(ddnazar.SelectedValue);
            cl.RequestStatusComment = txtnazar.Text;
            cl.PriceRequest =Convert.ToInt32( txtPriceRequest.Text);

            int t = RequestTrafficClass.Update(cl);
            if (t == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "ثبت اطلاعات با خطا مواجه شده است");
            else
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.General_Success, "نظر مرکز اعمال شد");
            BindGrid();
            LightBoxNazar.Value = "1";

        }

        protected void AAttach_ServerClick(object sender, EventArgs e)
        {
            String ID = ((HtmlAnchor)sender).HRef.ToString();
            ClAttach cl = new ClAttach();
            // cl.ForTable = "Tbl_RequestTraffic";
            cl.ForID = Convert.ToInt32(ID);
            RepeaterPic.DataSource = AttachClass.GetListAll(cl);
            RepeaterPic.DataBind();
            LightBoxAttach.Value = "1";

        }

        protected void ACompany_ServerClick(object sender, EventArgs e)
        {
            ClCompany clCompany = new ClCompany();
            clCompany.PersonalID = Convert.ToInt32(((HtmlAnchor)sender).HRef.ToString());
            ctlCompany.Data = clCompany;
            LightBoxCompany.Value = "1";
        }

        protected void ASMS_ServerClick(object sender, EventArgs e)
        {
            LightBoxSMS.Value = "1";
            lblmobile.Value = ((HtmlAnchor)sender).HRef.ToString();
        }

        protected void btnSMS_Click(object sender, EventArgs e)
        {
            try
            {
                string mobilesmg = txtSMS.Text;
                PublicFunction.SendSMSs(lblmobile.Value.ToString(), mobilesmg);
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.General_Success, "پیامک با موفقیت ارسال شد");
            }
            catch
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در ارسال پیامک");
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {

        }

        protected void ANazar_ServerClick(object sender, EventArgs e)
        {

        }
    }
}