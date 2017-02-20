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
using TerraficPlanBLL;

namespace TerraficPlan.Controls
{
    public partial class ctlChangPelakView : System.Web.UI.UserControl
    {
        protected void btnS_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void Binddd()
        {
            ddNazarID.DataSource = CatalogClass.GetListTypeID("12");
            ddNazarID.DataTextField = "CatalogName";
            ddNazarID.DataValueField = "CatalogValue";
            ddNazarID.DataBind();

            if (IsManage)
                GridView1.Columns[2].Visible = true;
            else
                GridView1.Columns[2].Visible = false ;
        }
        public bool NazaInsert
        {
            get {return  GridView1.Columns[2].Visible; }
            set { GridView1.Columns[2].Visible = value; }
        }
        public void BindGrid()
        {

            ClPelakChange cl = new ClPelakChange();
            cl.PersonalID = Convert.ToInt32(LblPersonalID.Text == "0" ? null : LblPersonalID.Text);

            if (LblPersonalID.Text != "0")
                cl.RequestTrafficID = Convert.ToInt32(Lbl_RequestTrafficID.Text == "0" ? null : Lbl_RequestTrafficID.Text);

            if (CtlPelak.MustBeFill)
                cl.Pelak = CtlPelak.Text;
           
            if (IsManage)
                cl.PersonalID = null;




            DataSet ds = PelakChangeClass.GetList(cl);
            DataView dv = new DataView(ds.Tables[0]);
            if ( ViewState["PelakChange"]  == null)
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
                StrSortDirection =  ViewState["PelakChange" + "Direction"].ToString() ;
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
        public void DeleteItem(object sender, System.EventArgs e)
        {
            String PelakChangeID = ((HtmlAnchor)sender).HRef.ToString();
            int i = PelakChangeClass.Delete(PelakChangeID);
            if (i == 0)
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('خطا در حذف');", true);
            else
                BindGrid();


        }

        public void NazarItem(object sender, System.EventArgs e)
        {
            String PelakChangeID = ((HtmlAnchor)sender).HRef.ToString();
            Lbl_PelakChangeID.Text = PelakChangeID;

            ClPelakChange cl = new ClPelakChange();
            cl.PelakChangeID = Convert.ToInt32(Lbl_PelakChangeID.Text);
            DataSet ds = PelakChangeClass.GetList(cl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                txtCommentNazar.Text = dr["CommentNazar"].ToString();
                if (dr["NazarID"].ToString()!="")
                    ddNazarID.SelectedValue =  dr["NazarID"].ToString()  ;

            }
            LightBox.Value = "1";


        }


        protected void btnAddNazar_Click(object sender, EventArgs e)
        {
            ClPelakChange cl = new ClPelakChange();
            cl.NazarID = Convert.ToInt32(ddNazarID.SelectedValue);
            cl.PelakChangeID=Convert.ToInt32(Lbl_PelakChangeID.Text);
            cl.CommentNazar = txtCommentNazar.Text;
            cl.NazarDate = DateTime.Now.ToString();

            int i = PelakChangeClass.Update(cl);
            if (i > 0)
                BindGrid();
            else
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "خطا در ثبت نظر مرکز");

            LightBox.Value = "0";
        }

        public string PersonalID
        {
            get {return  LblPersonalID.Text; }
            set { LblPersonalID.Text = value; }
        }

        public bool   IsManage
        {
            get { return Convert.ToBoolean( lbl_IsManage.Text); }
            set { lbl_IsManage.Text = value.ToString(); }
        }

    }
}