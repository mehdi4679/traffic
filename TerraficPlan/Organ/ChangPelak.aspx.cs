using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Organ
{
    public partial class ChangPelak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Rahcode"] != null)
                {CtlChangePelak.RahCode = Request.QueryString["Rahcode"].ToString(); }

                if (Request.QueryString["RequestTrafficID"] != null)
                   CtlChangePelak.RequestTrafficID = Request.QueryString["RequestTrafficID"].ToString();


                CtlChangePelak.bindPElak();


               
            }
        }
    }
}