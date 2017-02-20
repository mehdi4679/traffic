using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.MasterPages
{
    public partial class NewDiscountMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPersonalName.Text = Session["PersonaName"].ToString();
           if (Session["IsManage"] == "true")
            {
                liManage.Visible = true;
            }
        }
         
    }
}