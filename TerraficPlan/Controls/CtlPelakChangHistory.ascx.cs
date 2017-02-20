using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;

namespace TerraficPlan.Controls
{
    public partial class CtlPelakChangHistory : System.Web.UI.UserControl
    {
        public string  Reqid
        {
            get { return lblRequestID.Text; }
            set { lblRequestID.Text = value; }
        }
        public void BindGrid()
        {
            ClPelakChange cl = new ClPelakChange();
            cl.RequestTrafficID = Convert.ToInt32(lblRequestID.Text);
              
             DataSet ds = PelakChangeClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["PelakChange"] == null)
            {
                ViewState["PelakChange"] = "PelakChangeID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["PelakChange"].ToString()).ToString();
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
            if (ViewState["PelakChange" + "Direction"] == null)
            {
                ViewState.Add("PelakChange" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["PelakChange" + "Direction"].ToString();
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["PelakChange" + "Direction"] = StrSortDirection;
            }
            ViewState["PelakChange"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }


    }
}