using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
using TerraficPlanBLL;
using System.Web.UI.HtmlControls;
using System.Web.Security;

namespace TerraficPlan.Controls
{
    public partial class CtlPerson : System.Web.UI.UserControl
    {
        public ClPersonal Data
        {
            get
            {
                ClPersonal cl = new ClPersonal();
                cl.FirstName = TXTFirstName.Text;
                cl.LastName = TXTLastName.Text;
                cl.Email = TXTEmail.Text;
                cl.PersonalTel = TXTPersonalTel.Text;
                cl.PersonalMobile = TXTPersonalMobile.Text;
                cl.PostiCode = TXTPostiCode.Text;
                cl.NationalCode = TXTNationalCode.Text;
                cl.PersonalAdress = TXTPersonalAdress.Text;
                cl.JobName = TXTJobName.Text;
                cl.PersonalID = Convert.ToInt32(LblParamPersonalID.Text);
                return cl;
            }
            set
            {
                DataSet ds = PersonalClass.GetList(value);
                DataRow dr = ds.Tables[0].Rows[0];
                TXTFirstName.Text = dr["FirstName"].ToString();
                TXTLastName.Text = dr["LastName"].ToString();
                TXTEmail.Text = dr["Email"].ToString();
                TXTNationalCode.Text = dr["NationalCode"].ToString();
                TXTPersonalMobile.Text = dr["PersonalMobile"].ToString();
                TXTPersonalTel.Text = dr["PersonalTel"].ToString();
                TXTPostiCode.Text = dr["PostiCode"].ToString();
                TXTPersonalAdress.Text = dr["PersonalAdress"].ToString();
                TXTJobName.Text = dr["JobName"].ToString();
                LblParamPersonalID.Text = dr["PersonalID"].ToString();
                ds.Dispose();
            }
        }
        public void BindGrid()
        {
            ClPersonal cl = new ClPersonal();
            cl = Data;
            DataSet ds = PersonalClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if ( ViewState["Personal"]  == null)
            {
                ViewState["Personal"] = "PersonalID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["Personal"].ToString()).ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        public string PersonalID
        {
            get { return LblParamPersonalID.Text; }
            set { LblParamPersonalID.Text = value; }
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void GridView1_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
            string StrSortDirection = "desc";
            if (ViewState["Personal" + "Direction"] == null)
            {
                ViewState.Add("Personal" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["Personal" + "Direction"].ToString() ;
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["Personal" + "Direction"] = StrSortDirection;
            }
            ViewState["Personal"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String PersonalID = ((HtmlAnchor)sender).HRef.ToString();
            ClPersonal cl = new ClPersonal();
            cl.PersonalID = Convert.ToInt32(PersonalID);
            cl.IsInActive = 1;
            int i = PersonalClass.Delete(PersonalID);
            //int i = PersonalClass.Update(cl);
            if (i == 0)
            {
                LblMsg.Text = " error ";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف .برای کاربر درخواست ثبت شده است');", true);
            }
            else { BindGrid(); }
            LightBox.Value = "0";
        }
        public void UpItem(object sender, EventArgs e)
        {
            String PersonalID = ((HtmlAnchor)sender).HRef.ToString();
            ClPersonal cl = new ClPersonal();
            cl.PersonalID = Convert.ToInt32(PersonalID);
            Data = cl;
            LightBox.Value = "1";

        }

        public void PassItem(object sender, EventArgs e)
        {
             LightBox2.Value = "1";
             LBlPersonalPass.Text = ((HtmlAnchor)sender).HRef.ToString();

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
            LightBox.Value = "1";

         }
        protected void BtnSerach_Click1(object sender, EventArgs e)
        {
            LblParamPersonalID.Text = "0";
            BindGrid();

            //DataSet ds = PersonalClass.GetList(Data);
            //DataView dv = new DataView(ds.Tables[0]);
            //String StrSort = Securenamespace.SecureData.CheckSecurity(ViewState["Personal"].ToString());
            //if (StrSort != null)
            //{
            //    dv.Sort = StrSort;
            //}
            //GridView1.DataSource = dv;
            //GridView1.DataBind();
        }
        protected void BtnInsert_Click(Object sender, System.EventArgs e)
        {
            ClPersonal cl = new ClPersonal();
            cl = Data;
            int t = 0;
            if (LblParamPersonalID.Text == "0")
                t = PersonalClass.insert(Data);
            else
                t = PersonalClass.Update(Data);

            if (t == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,"خطا در ثبت");
             else
                BindGrid();
 
        }
        protected void EmptyLight()
        {
            TXTEmail.Text = "";
            TXTFirstName.Text = "";
            TXTJobName.Text = "";
            TXTLastName.Text = "";
            TXTNationalCode.Text = "";
            TXTPersonalAdress.Text = "";
             TXTPersonalMobile.Text = "";
            TXTPersonalTel.Text = "";
            TXTPostiCode.Text = "";



        }

        protected void btn_Click(object sender, EventArgs e)
        {
 if(txtPass.Text!=txtpassRe.Text){
     TerraficPlanBLL.Utility.ShowMsg(Page,ProPertyData.MsgType.warning,"یکسان نیودن کلمه عبور");
     return;
 }
            if (txtPass.Text.Length < 4)
            {
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "کلمه عبور باید از 4 کارکتر بیشتر باشد");
                return;
            }

            ClPersonal cl = new ClPersonal();
                 cl.Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPass.Text + "~!@", "MD5");
                cl.PersonalID = Convert.ToInt32(LBlPersonalPass.Text);
                int t = PersonalClass.Update(cl);

                if (t > 0)
                {
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, "کلمه عبور تغییر کرد");
                    LBlPersonalPass.Text = "0";
                    LightBox2.Value = "0";
                }
                else
                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در تغییر کلمه عبور");

   


        }

        protected void Acompany_ServerClick(object sender, EventArgs e)
        {
            LightBox3.Value = "1";
            string id=((HtmlAnchor)sender).HRef.ToString();

            ClPersonal cl = new ClPersonal();
            cl.PersonalID = Convert.ToInt32(id);
            DataSet ds = PersonalClass.GetList(cl);
            if(ds.Tables[0].Rows.Count>0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if(dr["CompanyID"].ToString()!="")
                ddCompany.SelectedValue = dr["CompanyID"].ToString();
                LblParamPersonalID.Text = id;

            }

            ds.Dispose();
        }
        public void BindDD()
        {
            ClCompany cl = new ClCompany();
             DataSet ds=CompanyClass.GetList(new ClCompany());
             ddCompany.DataSource = ds;
            ddCompany.DataTextField = "CompanyName";
            ddCompany.DataValueField="CompanyID";
            ddCompany.DataBind();

        }
        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            ClPersonal cl = new ClPersonal();
            cl.PersonalID = Convert.ToInt32( LblParamPersonalID.Text);
            cl.CompanyID = Convert.ToInt32( ddCompany.SelectedValue);
            int i = PersonalClass.Update(cl);
            if (i == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در ثبت شرکت");
            else
            {
                BindGrid();
                LblParamPersonalID.Text = "0";
            }
        }

        

        
 
    }
}