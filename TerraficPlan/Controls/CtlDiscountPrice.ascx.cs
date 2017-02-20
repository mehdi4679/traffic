using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TrafficPlanDAL;
using TrafficPlanCL;


namespace TerraficPlan.Controls
{
    public partial class CtlDiscountPrice : System.Web.UI.UserControl
    {
        

        protected void btnInsertLight_Click(object sender, EventArgs e)
        {
            LightBox.Value = "1";
        }
        public ClDiscountPrice Data {
            get {
                ClDiscountPrice cl = new ClDiscountPrice();
                cl.DiscountID = Convert.ToInt32(DDDiscountID.SelectedValue);
                cl.RepeatTypeID = Convert.ToInt32(DDRepeatTypeID.SelectedValue);
                cl.Price = Convert.ToInt32(TXTPrice.Text);
                cl.DiscountPriceID = Convert.ToInt32(LblParamDiscountPriceID.Text);
                return cl;
            }
            set {
                DataSet ds = DiscountPriceClass.GetList(value);
                DataRow dr = ds.Tables[0].Rows[0];
                TXTPrice.Text = dr["Price"].ToString();
                DDDiscountID.SelectedValue = dr["DiscountID"].ToString();
                DDRepeatTypeID.SelectedValue = dr["RepeatTypeID"].ToString();
                LblParamDiscountPriceID.Text = dr["DiscountPriceID"].ToString();
                ds.Dispose();
            }
        }
        public void Binddd() {
            DataSet ds = CatalogClass.GetListTypeID("-1000");
            DDDiscountID.DataTextField = "CatalogName";
            DDDiscountID.DataValueField = "caid";
            DDDiscountID.DataSource = ds;
            DDDiscountID.DataBind();
            DDDiscountID.Items.Insert(0, new ListItem("بدون تخفیف", "0"));

            ds.Dispose();

            DataSet ds2 = CatalogClass.GetListTypeID("7");
            DDRepeatTypeID.DataTextField = "CatalogName";
            DDRepeatTypeID.DataValueField = "CatalogValue";
            DDRepeatTypeID.DataSource = ds2;
            DDRepeatTypeID.DataBind();
            ds2.Dispose();


        }
        public void BindGrid()
        {
            ClDiscountPrice cl = new ClDiscountPrice();

            DataSet ds = DiscountPriceClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["DiscountPrice"]== null)
            {
                ViewState["DiscountPrice"] = "DiscountPriceID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["DiscountPrice"].ToString()).ToString();
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
            string StrSortDirection="" ;
            

            if (ViewState["DiscountPrice" + "Direction"] == null)
            {
                ViewState.Add("DiscountPrice" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["DiscountPrice" + "Direction"].ToString();
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["DiscountPrice" + "Direction"] = StrSortDirection;
            }
            ViewState["DiscountPrice"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String DiscountPriceID = ((HtmlAnchor)sender).HRef.ToString();
            int i = DiscountPriceClass.Delete( DiscountPriceID );
            if (i == 0)
            {
                LblMsg.Text = " error ";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else { BindGrid(); }
            LightBox.Value = "0";
        }
        public void UpItem(object sender, EventArgs e)
        {
            String DiscountPriceID = ((HtmlAnchor)sender).HRef.ToString();
            ClDiscountPrice cl = new ClDiscountPrice();
            cl.DiscountPriceID = Convert.ToInt32(DiscountPriceID);
            Data = cl;
            LightBox.Value = "1";
        }
       
        protected void btnSerachLight_Click(object sender, EventArgs e)
        {
            EmptyLight();
            
        }
        protected void BtnInsert_Click(Object sender, System.EventArgs e)
        {
            int t = 0;
            ClDiscountPrice cl = Data;
            if (LblParamDiscountPriceID.Text == "0")
                t = DiscountPriceClass.insert(cl);
            else
                t = DiscountPriceClass.Update(cl);
            if (t == 0)
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "خطا در ثبت";
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در ثبت");
            }
            else
            {
                LblMsg.ForeColor = System.Drawing.Color.Green;
                LblMsg.Text = "ثبت  انجام شد.";
                BindGrid();

            }
        }
        protected void EmptyLight()
        {
            TXTPrice.Text = "";
        }
     




    }
}