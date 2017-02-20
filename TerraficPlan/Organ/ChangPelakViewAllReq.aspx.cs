using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Organ
{
    public partial class ChangPelakViewAllReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ctlChangPelakView.PersonalID = Session["PersonalID"].ToString();
                ctlChangPelakView.Binddd();
                ctlChangPelakView.BindGrid();

            }

        }
    }
}