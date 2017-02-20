using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TerraficPlanBLL;

namespace TerraficPlan.Controls
{
    public partial class CtlPrice : System.Web.UI.UserControl
    {
        public string Text
        {
            get { return txtPrice.Text.Replace(",", ""); }
            set
            {
                txtPrice.Text = value;
               //  LblPrice.text=NumbertoText(Convert.ToInt32( txtPrice.Text.Replace("","")));
            }
        }



    }
}