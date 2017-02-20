using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;

namespace TerraficPlan.Controls
{
    public partial class CtlSahm : System.Web.UI.UserControl
    {
        public ClSahm Data
        {
            get
            {
                ClSahm cl = new ClSahm();
                cl.Year = Convert.ToInt32(TXTYear.Text);
                cl.sahmNumbre = Convert.ToInt32(TXTsahmNumbre.Text);
                cl.SahmID = Convert.ToInt32(LblParamSahmID.Text);
                cl.DiscountTypeID = Convert.ToInt32(DDDiscountTypeID.SelectedValue == "" ? "0" : DDDiscountTypeID.SelectedValue);
                cl.DiscountPersent = Convert.ToInt32(TXTDiscountPersent.Text);
                cl.CompanyID = Convert.ToInt32(DDCompanyID.SelectedValue);
                cl.Comment = TXTComment.Text;
                return cl;
            }
            set
            {
                DataSet ds = SahmClass.GetList(value);
                DataRow dr = ds.Tables[0].Rows[0];
                TXTComment.Text = dr["Comment"].ToString();
                TXTDiscountPersent.Text = dr["DiscountPersent"].ToString();
                TXTSahmID.Text = dr["SahmID"].ToString();
                TXTsahmNumbre.Text = dr["sahmNumbre"].ToString();
                TXTYear.Text = dr["Year"].ToString();
                DDCompanyID.SelectedValue = dr["CompanyID"].ToString();
                DDDiscountTypeID.SelectedValue = dr["DiscountTypeID"].ToString();
                LblParamSahmID.Text = dr["SahmID"].ToString();

                ds.Dispose();
            }
        }
        public void BindDD()
        {
            ClCompany cl=new ClCompany();
   
            DDCompanyID.DataSource = CompanyClass.GetList(cl);
            DDCompanyID.DataTextField = "CompanyName";
            DDCompanyID.DataValueField = "CompanyID";
            DDCompanyID.DataBind();
            DDCompanyID.Items.Insert(0, new ListItem("", "0"));

            //DDDiscountTypeID.DataSource = CatalogClass.GetListDiscountType();
            //DDDiscountTypeID.DataTextField = "CatalogName"; 
            //DDDiscountTypeID.DataValueField = "caid";
            //DDDiscountTypeID.DataBind();

        }
        public void BindGrid()
        {
            ClSahm cl = new ClSahm();
            DataSet ds = SahmClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["Sahm"]  == null)
            {
                ViewState["Sahm"] = "SahmID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["Sahm"].ToString()).ToString();
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
            if (ViewState["Sahm" + "Direction"] == null)
            {
                ViewState.Add("Sahm" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["Sahm" + "Direction"].ToString() ;
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["Sahm" + "Direction"] = StrSortDirection;
            }
            ViewState["Sahm"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String SahmID = ((HtmlAnchor)sender).HRef.ToString();
           
            int i = SahmClass.Delete( SahmID.ToString());
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
            String SahmID = ((HtmlAnchor)sender).HRef.ToString();
            ClSahm cl = new ClSahm();
            cl.SahmID = Convert.ToInt32(SahmID);
            LblParamSahmID.Text = SahmID;
            Data = cl;
            BtnInsert.Visible = true;
            LightBox.Value = "1";
        }
        protected void btnInsertLight_Click(object sender, EventArgs e)
        {
            EmptyLight();
            LightBox.Value = "1";
            BtnInsert.Visible = true;
            BtnSerach.Visible = false;
         }
        protected void btnSerachLight_Click(object sender, EventArgs e)
        {
            EmptyLight();
            BtnSerach.Visible = true;
            BtnInsert.Visible = false;
         }
        protected void BtnSerach_Click1(object sender, EventArgs e)
        {
            ClSahm cl = Data;
            DataSet ds = SahmClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            String StrSort = Securenamespace.SecureData.CheckSecurity(ViewState["Sahm"].ToString());
            if (StrSort != null)
            {
                dv.Sort = StrSort;
            }
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        protected void BtnInsert_Click(Object sender, System.EventArgs e)
        {
            int t = 0;
            ClSahm cl = new ClSahm();
            cl = Data;
            if (LblParamSahmID.Text == "0")
             t=    SahmClass.insert(cl);
            else
             t=   SahmClass.Update(cl);

            if (t == 0)
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "خطا در ثبت";
            }
                else if(t==-1)
                TerraficPlanBLL.Utility.ShowMsg(Page,TerraficPlanBLL.ProPertyData.MsgType.warning,"برای این نوع تخفیف در این سال سهمبه ثبت شده است=");
            else
            {
                LblMsg.ForeColor = System.Drawing.Color.Green;
                LblMsg.Text = "ثبت  انجام شد.";
                BindGrid();
            }
            LblParamSahmID.Text = "0";
        }
        protected void EmptyLight()
        {
            TXTComment.Text = "";
            TXTDiscountPersent.Text = "";
            TXTSahmID.Text = "";
            TXTsahmNumbre.Text = "";
            TXTYear.Text = "";
        }

       
      

    }
}