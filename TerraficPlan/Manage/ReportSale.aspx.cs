using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
using System.Data;
using System.Web.UI.HtmlControls;
using Stimulsoft.Report;
using Stimulsoft.Report.Web;
using Stimulsoft.Report.Win;
using System.Data;
 using System.Data.SqlClient;
using TerraficPlanBLL;
 

namespace TerraficPlan.Manage
{
    public partial class ReportSale : System.Web.UI.Page
    {
        private void BindddNazar()
        {
            DataSet ds = CatalogClass.GetListTypeID("11");

          


            ddRequestStatus.DataSource = ds;
            ddRequestStatus.DataTextField = "CatalogName";
            ddRequestStatus.DataValueField = "CatalogValue";
            ddRequestStatus.DataBind();
            ddRequestStatus.Items.Insert(0, new ListItem("همه موارد", "-1"));
            ddRequestStatus.Items.Insert(1, new ListItem("پرداخت شده", "-2"));


            ClCompany cl = new ClCompany();
            ddcompany.DataSource = CompanyClass.GetList(cl);
            ddcompany.DataTextField = "CompanyName";
            ddcompany.DataValueField = "CompanyID";
            ddcompany.DataBind();
            ddcompany.Items.Insert(0, new ListItem("بدون انتخاب", "0"));

            ddDiscountype.DataSource = CatalogClass.GetListDiscountType();
            ddDiscountype.DataTextField = "CatalogName";
            ddDiscountype.DataValueField = "CaID";
            ddDiscountype.DataBind();
            ddDiscountype.Items.Insert(0, new ListItem("بدون اننتخاب", "0"));


            ddRepeatType.DataSource = CatalogClass.GetListTypeID("7");
            ddRepeatType.DataTextField = "CatalogName";
            ddRepeatType.DataValueField = "CatalogValue";
            ddRepeatType.DataBind();
            ddRepeatType.Items.Insert(0, new ListItem("بدون انتخاب", "0"));



            ds.Dispose();

        }
        private string  RetAllRequestDate(int RequestID) {
            ClRequestRepeat cl=new ClRequestRepeat();
            cl.RequestID=RequestID;
            DataSet ds = RequestRepeatClass.GetList(cl);
            string s = "";

            if(ds.Tables[0].Rows.Count>0)
            {
            s = ds.Tables[0].Rows[0]["RepeatTypeIDName"].ToString()+"::";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                s += ds.Tables[0].Rows[i]["TitelName"].ToString() + ";";
            }

            }
            ds.Dispose();

            return s;
        }
        public void BindGrid()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
             cl.Firstname = txtname.Text;
            cl.LastName = txtLastName.Text;
            cl.fromDate = DateConvert.sh2m(txtFromDate.Text).ToString();
            cl.ToDate = DateConvert.sh2m(txtToDate.Text).ToString();
            cl.Pelak = CtlPelak.Text.Length > 5 ? CtlPelak.Text : null;
            cl.CompanyID = Convert.ToInt32(ddcompany.SelectedValue);
            cl.MelliCode = nationalCode.Text;
            cl.DiscountType =Convert.ToInt32( ddDiscountype.SelectedValue);
            cl.RepeatTypeID = Convert.ToInt32(ddRepeatType.SelectedValue);
            ////cl.FRomOrderDateStart = DateConvert.sh2m(txtFromDateTransaction.Text).ToString();
            ////cl.ToOrderDateStart = DateConvert.sh2m(txtToDateTransaction.Text).ToString();
            ////cl.GetConfilict = chGetConfilict.Checked == true ? 1 : 0;


            if (ddRequestStatus.SelectedValue == "-1")
                cl.RequestStatus = null;
            else
                cl.RequestStatus = Convert.ToInt32(ddRequestStatus.SelectedValue);


            DataSet ds = RequestTrafficClass.GetListManage(cl);
 
            ds.Tables[0].TableName = "DataSource1";
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {

                ds.Tables[0].Rows[intCount]["allRequests"] = RetAllRequestDate(Convert.ToInt32(ds.Tables[0].Rows[intCount]["RequestTrafficID"].ToString()));
                ds.Tables[0].Rows[intCount]["CreateTime"] = DateConvert.m2sh(ds.Tables[0].Rows[intCount]["MiladyDate"].ToString()) + " " + ds.Tables[0].Rows[intCount]["timeOnly"].ToString();
                if(ds.Tables[0].Rows[intCount]["d"].ToString()!="")
                ds.Tables[0].Rows[intCount]["d"] = DateConvert.m2sh(ds.Tables[0].Rows[intCount]["d"].ToString());


            }

            Session["data"] = null;
            Session["data"] = ds;

            Response.Redirect("~/Manage/ReportView.aspx?RName=Sale");
            //f1.Src="~/Manage/ReportView.aspx?RName=Sale.mrt";
            //MyIfarm.Attributes.Add("src", "Manage/ReportView.aspx?RName=Sale.mrt");
            //MyIfarm.Visible = true;

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
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

                //if (Request.QueryString["pid"] != null)
                //    SetNameAndFamil(Convert.ToInt32(Request.QueryString["pid"]));

                //if (Request.QueryString["companyID"] != null)
                //    ddcompany.SelectedValue = Request.QueryString["companyID"].ToString();


              
              

            }

        }
    }
}