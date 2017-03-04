using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
//using Microsoft.Reporting.WebForms;

//using Microsoft.Reporting.WebForms;
namespace TerraficPlan
{

    //public class ReportServerCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    //{


    //    public ReportServerCredentials()
    //    {
    //    }

    //    public bool GetFormsCredentials(ref System.Net.Cookie authCookie, ref string userName, ref string password, ref string authority)
    //    {
    //        authCookie = null;
    //        userName = null;
    //        password = null;
    //        authority = null;

    //        //Not using form credentials
    //        return false;
    //    }

    //    public System.Security.Principal.WindowsIdentity ImpersonationUser
    //    {
    //        //Use the default Windows user. Credentials will be
    //        //provided by the NetworkCredentials property.
    //        get { return null; }
    //    }

    //    public System.Net.ICredentials NetworkCredentials
    //    {
    //        get
    //        {

    //            string userName = ConfigurationManager.AppSettings["ReportUser"];
    //            if (string.IsNullOrEmpty(userName))
    //            {
    //                throw new Exception("Missing user name in web.config file");
    //            }

    //            string password = ConfigurationManager.AppSettings["ReportUserPass"];
    //            if (string.IsNullOrEmpty(password))
    //            {
    //                throw new Exception("Missing password in web.config file");
    //            }

    //            string domain = ConfigurationManager.AppSettings["Domain"];
    //            if (string.IsNullOrEmpty(domain))
    //            {
    //                //Throw New Exception("Missing domain in web.config file")

    //            }

    //            return new NetworkCredential(userName, password, domain);
    //        }
    //    }
    //}


}