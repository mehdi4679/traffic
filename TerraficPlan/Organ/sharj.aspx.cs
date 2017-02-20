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
    public partial class sharj : System.Web.UI.Page
    {
        private string MerchantId = "10321755";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack )
            {
                LBLPersonlID.Text = Session["PersonalID"].ToString();
                BindGrid();

            }
        }
        public void BindGrid()
        {
            ClSharj cl = new ClSharj();
            cl.PersonalID = Convert.ToInt32(LBLPersonlID.Text);

            DataSet ds = SharjClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["Sharj"] == null)
            {
                ViewState["Sharj"] = "SharjID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["Sharj"].ToString()).ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void GridView1_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
            string StrSortDirection = "desc";
            if (ViewState["Sharj" + "Direction"] == null)
            {
                ViewState.Add("Sharj" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["Sharj" + "Direction"].ToString();
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["Sharj" + "Direction"] = StrSortDirection;
            }
            ViewState["Sharj"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String SharjID = ((HtmlAnchor)sender).HRef.ToString();
            int i = SharjClass.Delete(SharjID);
            if (i == 0)
            {
                //  LblMsg.Text = " error ";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else { BindGrid(); }

        }

        protected void btnShajBank_Click(object sender, EventArgs e)
        {
           
                ClSharj cl = new ClSharj();
                cl.PersonalID = Convert.ToInt32(LBLPersonlID.Text);
                cl.ShariPrice = Convert.ToInt32(txtPrice.Text);
                cl.ShajComment = txtComment.Text;


                int i = SharjClass.insert(cl);
                if (i == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "");
                else
                {
                    Pay_Click(i, Convert.ToInt32(txtPrice.Text));
                    BindGrid();
                }

            }
            
         
        public void Pay_Click(int sharjID, int price)
        {
            try
            {

                string url = ConfigurationManager.AppSettings["SafhePardakhtPage"];// Properties.Settings.Default.SafhePardakhtPage;


                string RedirectURL = ConfigurationManager.AppSettings["ReturnAddressOrgan"];// Properties.Settings.Default.ReturnAddress;

                ClEpayOrder cl = new ClEpayOrder();
                cl.SharjID = Convert.ToInt32(sharjID);
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