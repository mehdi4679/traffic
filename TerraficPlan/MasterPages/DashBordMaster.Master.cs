using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TrafficPlanDAL;
using TrafficPlanCL;

namespace Taxi.rtl
{
    public partial class TaxiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblpageName.Text =Securenamespace.SecureData.CheckSecurity( Request.QueryString["pname"]);
           
        }
    }
}