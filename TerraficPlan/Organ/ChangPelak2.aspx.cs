using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Organ
{
    public partial class ChangPelak2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CtlRequestView.PersonalID = Session["PersonalID"].ToString();
               
                CtlRequestView.BindGrid();

            }
        }

       
       
    }
}