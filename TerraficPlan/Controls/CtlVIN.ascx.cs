using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Controls
{
    public partial class CtlVIN : System.Web.UI.UserControl
    {
        public string Text
        {
            get
            {
               
                return   txtv.Text;
            }
            set { txtv.Text = value; }
        }

    }
}