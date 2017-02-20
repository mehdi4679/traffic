using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Organ
{
    public partial class Regperson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CtlPerson1.RedirectPage = "/Organ/PersonView.aspx";
            CtlPerson1.UpdateMode = false;
        }
    }
}