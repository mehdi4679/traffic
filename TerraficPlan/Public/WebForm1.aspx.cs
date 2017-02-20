using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TerraficPlan.Public
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var liActive = (HtmlGenericControl)Master.FindControl("llll");
            liActive.Attributes.Add("class", "active");
         

        }
    }
}