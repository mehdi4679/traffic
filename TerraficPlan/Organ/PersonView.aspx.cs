using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;

namespace TerraficPlan.Organ
{
    public partial class PersonView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CtlPerson1.RedirectPage = "";
                CtlPerson1.UpdateMode = true;
                ClPersonal cl = new ClPersonal();

                cl.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
                CtlPerson1.PersonalID = Convert.ToInt32(Session["PersonalID"].ToString());
                CtlPerson1.Data = cl;
                CtlPerson1.VisibleBtn = false;
            }
        }
    }
}