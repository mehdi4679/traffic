using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;

namespace TerraficPlan.Organ
{
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                CtlCompanyOnly1.PErsonalID = Convert.ToInt32(Session["PersonalID"].ToString());

                ClCompany cl = new ClCompany();
                cl.PersonalID=Convert.ToInt32(Session["PersonalID"].ToString());
               CtlCompanyOnly1.BindDD();

               CtlCompanyOnly1.Data = cl;
               CtlCompanyOnly1.VisibleBtn = false;
            }

        }
    }
}