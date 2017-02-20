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

namespace TerraficPlan.Controls
{
    public partial class CtlCompanyOnly : System.Web.UI.UserControl
    {
        public bool VisibleBtn
        {
            get { return BtnInsert.Visible; }
            set { BtnInsert.Visible = value; }
        }
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
                cl.CompanyID =Convert.ToInt32( LblParamCompanyID.Text);
                cl.PersonalID = Convert.ToInt32(LBlPersonalID.Text);

                cl.CompanyTypeID = Convert.ToInt32(ddCompanyTypeID.SelectedValue);

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
                    LBlPersonalID.Text = dr["PersonalID"].ToString();
                    ddCompanyTypeID.SelectedValue = dr["CompanyTypeID"].ToString();

                    ds.Dispose();
                }
                else {
                    Empty();
                }
            }
        }
      
        public int CompanyID {
            get { return Convert.ToInt32(LblParamCompanyID.Text); }
            set { LblParamCompanyID.Text = value.ToString(); }
        }
        public int PErsonalID {
            get { return Convert.ToInt32(LBlPersonalID.Text); }
            set { LBlPersonalID.Text = value.ToString(); }
        }

        public void BindDD()
        {
            DataSet ds = CatalogClass.GetListDiscountType();
            ddCompanyTypeID.DataSource = ds;
            ddCompanyTypeID.DataTextField = "CatalogName";
            ddCompanyTypeID.DataValueField = "caid";
            ddCompanyTypeID.DataBind();

        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            ClCompany cl = new ClCompany();
            cl = Data;
             int i = 0;
            if(LblParamCompanyID.Text=="0")
            i = CompanyClass.insert(cl) ;
            else
                i=CompanyClass.Update(cl) ;

             

            if (i.ToString() == "0")
            {
                Utility.ShowMsg(Page, ProPertyData.MsgType.General_Fault, "ثبت با خطا مواجه شد");
               
            }
            else
            {
                Utility.ShowMsg(Page, ProPertyData.MsgType.General_Success, "ثبت با موفقیت انجام شد.");
                //Session["CompanyID"] = LblParamCompanyID.Text;
            }
        }

        private void Empty() {
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
    }
}