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
using System.Data.Sql;

namespace TerraficPlan.Manage
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindNews();
            }
        }
        private void BindNews()
        {
            ClNews cl=new ClNews();
            DataSet ds = NewsClass.GetList(cl);
            if(ds.Tables[0].Rows.Count>0){
                DataRow DR = ds.Tables[0].Rows[0];
                txtcontent.Value = DR["Comment"].ToString().Replace("<_", "<").Replace("_>", ">");
                lblNewsID.Text = DR["NewID"].ToString();
            }
        }

        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            ClNews cl=new ClNews();
             cl.Comment= txtcontent.Value  ;
            cl.RegUser=Convert.ToInt32( CSharp.PublicFunction.GetUserID());
            cl.NewID=Convert.ToInt32(lblNewsID.Text);

            int i=0;
            if(lblNewsID.Text=="0")
            i = NewsClass.insert(cl);
            else
            i=NewsClass.Update(cl);

            if (i == 0)
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.warning, "خطا در ثبت");
            else
                TerraficPlanBLL.Utility.ShowMsg(Page, ProPertyData.MsgType.General_Success, "درج انجام شد");

        }
    }
}