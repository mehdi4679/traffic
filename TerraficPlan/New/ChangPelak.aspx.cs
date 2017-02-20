using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.New
{
    public partial class ChangPelak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

             if (Session["Code"].ToString() != Request.QueryString["Code"].ToString())
                return;

            if (!Page.IsPostBack)
            {
                CtlChangePelak.RahCode = Session["Code"].ToString();
                CtlChangePelak.RequestTrafficID = Request.QueryString["rid"].ToString();
                 CtlChangePelak.PersonalID = Request.QueryString["pid"].ToString();
                 CtlChangePelak.bindPElak();
                 CtlChangePelak.VisibleJanbaz = false;
            }
                           //if (Request.QueryString["Rahcode"] != null)
                //{ Lbl_RahCode.Text = Request.QueryString["Rahcode"].ToString(); }

                //if (Request.QueryString["RequestTrafficID"] != null)
                //    Lbl_RequestTrafficID.Text = Request.QueryString["RequestTrafficID"].ToString();


                //bindPElak();
        }
    }
}