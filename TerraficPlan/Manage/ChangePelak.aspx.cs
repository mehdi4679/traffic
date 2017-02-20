using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Manage
{
    public partial class ChangePelak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ctlChangPelakView.IsManage = true;

                ctlChangPelakView.PersonalID = Session["PersonalID"].ToString();
                ctlChangPelakView.Binddd();
                ctlChangPelakView.BindGrid();
            }
        }
    }
}