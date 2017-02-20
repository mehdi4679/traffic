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

namespace TerraficPlan.Manage
{
    public partial class PersonRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            ClCompany cl = new ClCompany();
            DataSet ds = CompanyClass.GetListCompanyRequest(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["PersonalID"] == null)
            {
                ViewState["PersonalID"] = "PersonalID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["PersonalID"].ToString()).ToString();
            grid1.DataSource = dv;
            grid1.DataBind();
 
        }
        protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;
            BindGrid();

        }

        protected void grid1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string StrSortDirection = "";


            if (ViewState["PersonalID" + "Direction"] == null)
            {
                ViewState.Add("PersonalID" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["PersonalID" + "Direction"].ToString();
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["PersonalID" + "Direction"] = StrSortDirection;
            }
            ViewState["PersonalID"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();

        }
    }
}