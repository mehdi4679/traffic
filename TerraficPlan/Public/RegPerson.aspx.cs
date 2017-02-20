using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TerraficPlan.Public
{
    public partial class RegPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var dwizard = (HtmlGenericControl)Master.FindControl("dwiz");
             dwizard.Visible = false;

             var navigationHeader = (HtmlGenericControl)Master.FindControl("navigationHeader");
             navigationHeader.Visible = false;

            CtlPerson1.RedirectPage = "/public/PersonalView.aspx";
            CtlPerson1.UpdateMode = false;

            //if (CtlPerson1.PersonalID != 0)
            //{
            //    Session["PersonalID"] = CtlPerson1.PersonalID.ToString();
            //    Response.Redirect("~/Public/PeronalView.aspx");
            //}
        }
    }
}