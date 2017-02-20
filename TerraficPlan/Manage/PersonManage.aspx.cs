using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Manage
{
    public partial class PersonManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                              try
                {
                    if ( Request.QueryString["pid"] !=null)
                        CtlPerson.PersonalID = Request.QueryString["pid"].ToString() ;


                    CtlPerson.BindDD();
                CtlPerson.BindGrid();

                }
                catch { }
              


            }
        }
    }
}