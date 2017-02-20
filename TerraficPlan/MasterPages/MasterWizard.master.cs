using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cityTheme
{
   
    public partial class MasterWizard : System.Web.UI.MasterPage
    {
        public static string nextlink;
        public static string prelink;
        public static string currentstep;
        public static string GetClass(string id) {
            if (currentstep == "step1")
            {
                if (id == "step1")
                    return "active";
                else
                    return "";
            }
            else if (currentstep == "step2")
            {
                if (id == "step1")
                    return "complete";
                else if (id == "step2")
                    return "active";
                else
                    return "";
            }
            else 
                return "";
         }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["PersonalID"] == "0")
                Response.Redirect("LoginMain.aspx");
        }


    }
}
public class  publicFunction {
    public static string NextLink(string pid)
    {
        int i = Convert.ToInt32(pid.Replace("p", "").Replace(".aspx", ""));
        return "p" + (i + 1).ToString() + ".aspx";
    }
    public static string PreLink(string pid)
    {
        int i = Convert.ToInt32(pid.Replace("p", "").Replace(".aspx", ""));
        if (i - 1 > 0)
            return "p" + (i - 1).ToString() + ".aspx";
        else
            return pid;
    }
}