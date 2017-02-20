using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TerraficPlanBLL;
using TrafficPlanCL;
using TrafficPlanDAL;

namespace TerraficPlan.Controls
{
    public partial class CtlRequestView : System.Web.UI.UserControl
    {
        public  void BindGrid()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.PersonalID = Convert.ToInt32(lblPersonID.Text=="0"?null:lblPersonID.Text);
            
            if(CtlPelak.MustBeFill)
            cl.Pelak = CtlPelak.Text ;

            DataSet ds = RequestTrafficClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if (ViewState["RequestTrafficID"] == null)
            {
                ViewState["RequestTrafficID"] = "RequestTrafficID Desc";
            }
            dv.Sort = Securenamespace.SecureData.CheckSecurity(ViewState["RequestTrafficID"].ToString()).ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
         
        }

        protected void ADel_ServerClick(object sender, EventArgs e)
        {
            string id = ((HtmlAnchor)sender).HRef.ToString();
            int i = TrafficPlanDAL.RequestTrafficClass.Delete(id);
            if (i == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "");
            else
                BindGrid();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string StrSortDirection = "desc";
            if (ViewState["RequestTrafficID" + "Direction"] == null)
            {
                ViewState.Add("RequestTrafficID" + "Direction", "desc");
            }
            else
            {
                StrSortDirection = ViewState["RequestTrafficID" + "Direction"].ToString();
            }
            if (StrSortDirection == "desc")
            {
                StrSortDirection = "asc";
            }
            else
            {
                StrSortDirection = "desc";
                ViewState["RequestTrafficID" + "Direction"] = StrSortDirection;
            }
            ViewState["RequestTrafficID"] = e.SortExpression + " " + StrSortDirection;
            BindGrid();
        }

        protected void btnS_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        public string PersonalID
        {
            get { return lblPersonID.Text; }
            set { lblPersonID.Text = value; }
        }
    }
}