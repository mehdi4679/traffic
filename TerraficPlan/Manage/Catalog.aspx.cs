using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TrafficPlanCL;
using TrafficPlanDAL;
using System.Web.UI.HtmlControls;

namespace TerraficPlan.Manage
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                BindGrid();
                Binddd();
                BindYear();
            }
        }

        private void BindYear()
        {
            ClCatalog cl = new ClCatalog();
            cl.CatalogTypeID = 101;
            cl.parentID = 1;

            DataSet ds = CatalogClass.GetList(cl);
            if(ds.Tables[0].Rows.Count>0)
            ddDefauleYear.SelectedValue = ds.Tables[0].Rows[0]["CAID"].ToString();

        }

        private void BindGrid() {
            DataSet ds = CatalogClass.GetListTypeID("7");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        public void UpItem(object sender, EventArgs e)
        {
            String caid = ((HtmlAnchor)sender).HRef.ToString().Split('$')[0].ToString();
            String Isselect = ((HtmlAnchor)sender).HRef.ToString().Split('$')[1].ToString();

            ClCatalog cl = new ClCatalog();
            cl.CID = Convert.ToInt32(caid);
            cl.ISSelect =  (Isselect=="1" ? 0:1);
            int t = CatalogClass.Update(cl);
            if(t==0)
                TerraficPlanBLL.Utility.ShowMsg(Page,TerraficPlanBLL.ProPertyData.MsgType.warning,"خطا");
            else
            BindGrid();

        }
        private void Binddd()
        {
            DataSet ds = CatalogClass.GetListTypeID("101");
            ddDefauleYear.DataSource = ds;
            ddDefauleYear.DataTextField = "CatalogName";
            ddDefauleYear.DataValueField = "CAID";

            ddDefauleYear.DataBind();

        }
        protected void btnSaveYear_Click(object sender, EventArgs e)
        {
            ClCatalog cl = new ClCatalog();
            cl.CID = Convert.ToInt32( ddDefauleYear.SelectedValue );
            cl.parentID = 1;
            cl.CatalogTypeID =101;
            int i=CatalogClass.Update(cl);
            if (i > 0)
                lblmsg.Text = "ثبت انجام شد";
            else
                lblmsg.Text = "خطا در درج";  
        }
    }




}