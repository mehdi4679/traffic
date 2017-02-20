using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TerraficPlanBLL;
using TrafficPlanCL;
using TrafficPlanDAL;

namespace TerraficPlan.Public
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        private string MerchantId = "10321755";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                BindGrid();
                if (GridView1.Items.Count == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "شما قبلا هیچ درخواستی ثبت نکرده اید");

                var dwizard = (HtmlGenericControl)Master.FindControl("dwiz");
                dwizard.Visible = false;
            }
        }


        protected void AAttach_ServerClick(object sender, EventArgs e)
        {
            String ID = ((HtmlAnchor)sender).HRef.ToString();
            ClAttach cl = new ClAttach();
            // cl.ForTable = "Tbl_RequestTraffic";
            cl.ForID = Convert.ToInt32(ID);
            RepeaterPic.DataSource = AttachClass.GetList(cl);
            RepeaterPic.DataBind();
            LightBoxAttach.Value = "1";

        }

        protected void APerson_ServerClick(object sender, EventArgs e)
        {
            ClPersonal cl = new ClPersonal();
            cl.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
            ctlperson.Data = cl;
            LightBoxPerson.Value = "1";
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


        public void BindGrid()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.PersonalID = Convert.ToInt32(Session["PersonalID"]);
            DataSet ds =  RequestTrafficClass.GetListCode2(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if ( ViewState["RequestTraffic"]  == null)
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
        //protected void gridview1_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        //{
        //    string StrSortDirection = "desc";
        //    if (ViewState["RequestTraffic" + "Direction"] == null)
        //    {
        //        ViewState.Add("RequestTraffic" + "Direction", "desc");
        //    }
        //    else
        //    {
        //        StrSortDirection =  ViewState["RequestTraffic" + "Direction"].ToString() ;
        //    }
        //    if (StrSortDirection == "desc")
        //    {
        //        StrSortDirection = "asc";
        //    }
        //    else
        //    {
        //        StrSortDirection = "desc";
        //        ViewState["RequestTraffic" + "Direction"] = StrSortDirection;
        //    }
        //    ViewState["RequestTraffic"] = e.SortExpression + " " + StrSortDirection;
        //    BindGrid();
        //}
       
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String RequestTrafficID = ((HtmlAnchor)sender).HRef.ToString();
            int i = RequestTrafficClass.Delete(RequestTrafficID);
            if (i == 0)
            {
                
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else { BindGrid(); }
           
        }
        public void UpItem(object sender, EventArgs e)
        {
            String RequestTrafficID = ((HtmlAnchor)sender).HRef.ToString();
            Session["rid"] = RequestTrafficID;
            Response.Redirect("/Public/PersonalView.aspx");

        }
      
       

        

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            try
            {

                string url = ConfigurationManager.AppSettings["SafhePardakhtPage"];// Properties.Settings.Default.SafhePardakhtPage;

                //string resNum = lblRahgiri.Text + ":" + DateTime.Now.Year.ToString() +
                //                DateTime.Now.Month.ToString().PadLeft(2, '0') +
                //                DateTime.Now.Day.ToString().PadLeft(2, '0') +
                //                DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                //                DateTime.Now.Minute.ToString().PadLeft(2, '0') +
                //                DateTime.Now.Second.ToString().PadLeft(2, '0');

                string RedirectURL = ConfigurationManager.AppSettings["ReturnAddress"];// Properties.Settings.Default.ReturnAddress;
               

                ClEpayOrder cl = new ClEpayOrder();
                cl.RequestID = Convert.ToInt32(((HtmlAnchor)sender).HRef.ToString());
                int Price = GetPrice(Convert.ToInt32(((HtmlAnchor)sender).HRef.ToString()));
                 cl.OrderDateStart = DateTime.Now.ToString();
                cl.IP = CSharp.PublicFunction.GetIPAddress();
                cl.OS = CSharp.PublicFunction.GetOS();
                cl.Prcie = Price;
                cl.Browser = CSharp.PublicFunction.GetBrowser() + " " + CSharp.PublicFunction.GetBrowserVersion();
                int i = EpayOrderClass.insert(cl);
                if (i == 0)
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در برنامه");
                else
                    Response.Redirect(url + "?ResNum=" + i + "&MID=" +
                    MerchantId + "&RedirectURL=" + RedirectURL + "&Amount=" + Price.ToString().Trim());

            }
            catch (Exception ex)
            {
            }
        }
        private Int32 GetPrice(int rid) {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.RequestTrafficID = rid;
          DataSet ds=  RequestTrafficClass.GetListPrice(cl);
          DataRow dr = ds.Tables[0].Rows[0];
          return Convert.ToInt32(dr["Price"].ToString());

        }

        protected void dd_ServerClick(object sender, EventArgs e)
        {

        }

        protected void dd2_ServerClick(object sender, EventArgs e)
        {
            Session["rid"] = "";
            Response.Redirect("/public/PersonalView.aspx");
        }
    }
}