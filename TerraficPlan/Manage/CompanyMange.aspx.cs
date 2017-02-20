using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Manage
{
    public partial class CompanyMange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    if ( Request.QueryString["cid"] != null)
                        CtlCompany.CompanyID = Convert.ToInt32(Request.QueryString["cid"].ToString());
                    CtlCompany.BindDD();
                CtlCompany.BindGrid();

                }
                catch { }


            }
        }
    }
}