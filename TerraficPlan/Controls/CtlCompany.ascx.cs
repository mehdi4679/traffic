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
    public partial class CtlCompany : System.Web.UI.UserControl
    {
        public ClCompany Data
        {
            get
            {
                ClCompany cl = new ClCompany();
                cl.ComapnyAdress = TXTComapnyAdress.Text;
                cl.CompanyEmail = TXTCompanyEmail.Text;
                cl.CompanyName = TXTCompanyName.Text;
                cl.CompanyTel = TXTCompanyTel.Text;
                cl.ManageName = TXTManageName.Text;
                cl.RepresentativeMobile = TXTRepresentativeMobile.Text;
                cl.RepresentativeName = TXTRepresentativeName.Text;
                cl.ManageName = TXTManageName.Text;
                cl.CompanyID = Convert.ToInt32(LblParamCompanyID.Text);
                cl.CompanyTypeID = Convert.ToInt32(ddCompanyTypeID.SelectedValue);
               // cl.CompanyID = Convert.ToInt32(LblParamCompanyID.Text);
                //cl.PersonalID = Convert.ToInt32(LBlPersonalID.Text);
                return cl;

            }
            set
            {
                DataSet ds = CompanyClass.GetListPersonl(value);
                DataRow dr;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    TXTComapnyAdress.Text = dr["ComapnyAdress"].ToString();
                    TXTCompanyEmail.Text = dr["CompanyEmail"].ToString();
                    LblParamCompanyID.Text = dr["CompanyID"].ToString();
                    TXTCompanyName.Text = dr["CompanyName"].ToString();
                    TXTCompanyTel.Text = dr["CompanyTel"].ToString();
                    TXTManageName.Text = dr["ManageName"].ToString();
                    TXTRepresentativeMobile.Text = dr["RepresentativeMobile"].ToString();

                    TXTRepresentativeName.Text = dr["RepresentativeName"].ToString();
                    TXTRepresentativeTel.Text = dr["RepresentativeTel"].ToString();
                    ddCompanyTypeID.SelectedValue = dr["CompanyTypeID"].ToString();

                    //LBlPersonalID.Text = dr["PersonalID"].ToString();
                    ds.Dispose();
                }
                else
                {
                    Empty();
                }
            }
        }

        public void UpItem(object sender, EventArgs e)
        {
            String  ID = ((HtmlAnchor)sender).HRef.ToString();
            ClCompany cl = new ClCompany();
            cl.CompanyID = Convert.ToInt32(ID);
            Data = cl;
            LightBox.Value = "1";
            BtnInsert.Visible = true ;
            BtnSerach.Visible = false;

        }


        public void BindGrid()
        {
            ClCompany cl = new ClCompany();
            cl = Data;
            
             DataSet ds = CompanyClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if ( ViewState["CompanyID"]  == null)
            {
                ViewState["CompanyID"] = "CompanyID Desc";
            }
            dv.Sort =  ViewState["CompanyID"].ToString() ;
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
            if (ViewState["CompanyID" + "Direction"] == null)
            {
                ViewState.Add("CompanyID" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["CompanyID" + "Direction"].ToString();
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["CompanyID" + "Direction"] = StrSortDirection;
            }
            ViewState["CompanyID"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }

        public void BindDD()
        {
            DataSet ds = CatalogClass.GetListDiscountType();
            ddCompanyTypeID.DataSource = ds;
            ddCompanyTypeID.DataTextField = "CatalogName";
            ddCompanyTypeID.DataValueField = "caid";
            ddCompanyTypeID.DataBind();
            ddCompanyTypeID.Items.Insert(0, new ListItem("", "0"));

        }
        public int CompanyID
        {
            get { return Convert.ToInt32(LblParamCompanyID.Text); }
            set { LblParamCompanyID.Text = value.ToString(); }
        }
        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            ClCompany cl = new ClCompany();
            cl = Data;
            int i = 0;
            if (LblParamCompanyID.Text == "0")
                i = CompanyClass.insert(cl);
            else
                i = CompanyClass.Update(cl);



            if (i.ToString() == "0")
            {
                Utility.ShowMsg(Page, ProPertyData.MsgType.General_Fault, "ثبت با خطا مواجه شد");

            }
            else
            {
               // Utility.ShowMsg(Page, ProPertyData.MsgType.General_Success, "ثبت با موفقیت انجام شد.");
                //Session["CompanyID"] = LblParamCompanyID.Text;
                BindGrid();
                LightBox.Value = "0";
            }
            LblParamCompanyID.Text = "0";

        }

        private void Empty()
        {
            TXTComapnyAdress.Text = "";
            TXTCompanyEmail.Text = "";
            LblParamCompanyID.Text = "0";
            TXTCompanyName.Text = "";
            TXTCompanyTel.Text = "";
            TXTManageName.Text = "";
            TXTRepresentativeMobile.Text = "";
            TXTRepresentativeName.Text = "";
            TXTRepresentativeTel.Text = "";
        }

        protected void btnInsertLight_Click(object sender, EventArgs e)
        {
            LightBox.Value = "1";
            BtnInsert.Visible = true;
            BtnSerach.Visible = false;
         }

        protected void btnSerachLight_Click(object sender, EventArgs e)
        {
            LightBox.Value = "1";
            BtnInsert.Visible =false ;
            BtnSerach.Visible = true;
        }

        protected void BtnSerach_Click(object sender, EventArgs e)
        {
            LblParamCompanyID.Text = "0";
            BindGrid();

            
        }

        public void DeleteItem(object sender, System.EventArgs e)
        {
            String cid = ((HtmlAnchor)sender).HRef.ToString();
            //ClCompany cl = new ClCompany();
            //cl.CompanyID = Convert.ToInt32(cid);
 
            int i = CompanyClass.Delete(cid);
            if (i == 0)
            {
                Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در حذف");
                //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            }
            else
                BindGrid(); 

            LightBox.Value = "0";
        }

    }
}