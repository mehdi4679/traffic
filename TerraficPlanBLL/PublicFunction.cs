using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;
using System.Web.UI.WebControls;
 
namespace CSharp
{

      
    public class PublicFunction
    {
        //public void ExportModule(string PersianHeader, string SqlCommand, string ConnectionString, string app = "excel", string filename = "filename", string ReportHeader = "")
        //{
        //    //   Variables declaration
        //    DataSet dsExport = new DataSet();
        //    System.IO.StringWriter tw = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        //    DataGrid dgGrid = new DataGrid();
        //    dgGrid.DataSource =ds;
        //    //   Report Header
        //    hw.WriteLine("<b><u><font size='5'> " + ReportHeader + "</font></u></b>");

        //    //   Get the HTML for the control.
        //    dgGrid.HeaderStyle.Font.Bold = true;
        //    dgGrid.DataBind();
        //    dgGrid.RenderControl(hw);

        //    //Set App 
        //    if (app == "Word")
        //    {
        //        app = "application/vnd.word;";
        //        filename = filename + ".doc";

        //    }
        //    else
        //    {
        //        app = "application/vnd.ms-excel";
        //        filename = filename + ".xls";
        //    }
        //    //   Write the HTML back to the browser.
        //    HttpContext.Current.Response.ContentType = app;
        //    //EnableViewState = False
        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.BufferOutput = true;
        //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    HttpContext.Current.Response.Charset = "UTF-8";
        //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);

        //    HttpContext.Current.Response.Write(tw.ToString());
        //    HttpContext.Current.Response.End();


        //    //Dim dr As SqlDataReader = SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, SqlCommand)

        //    //If dr.HasRows = False Then Exit Sub

        //    //'Create Headers
        //    //Dim t1 As String = "<tr style=""background-color:Gray "">"
        //    //Dim columnCount As Integer = 0
        //    //Dim headers As String() = PersianHeader.Split(";")
        //    //For k As Integer = 0 To headers.Length - 1
        //    //    t1 += "<td>" & headers(k) & "</td>"
        //    //    columnCount += 1
        //    //Next
        //    //t1 += "</tr>"

        //    //'Create DataTable
        //    //Dim t2 As String
        //    //Do While dr.Read
        //    //    t2 += "<tr>"
        //    //    For i As Integer = 0 To columnCount - 1
        //    //        t2 += "<td>" & dr(i).ToString & "</td>"
        //    //    Next
        //    //    t2 += "</tr>"
        //    //Loop


        //    //Dim data As String = "<table border=1 dir=rtl>" & t1 & t2 & "</table>"

        //    //'Set App 
        //    //If app = "Word" Then
        //    //    app = "application/vnd.word;"
        //    //    filename = filename + ".doc"
        //    //Else

        //    //    app = "application/vnd.excel;"
        //    //    filename = filename + ".xls"
        //    //End If

        //    //Dim strFileToExport As String = String.Empty
        //    //Dim strContentType As String = String.Empty
        //    //Dim obj_StrBuilder As New StringBuilder
        //    //obj_StrBuilder.Append(data.ToString)
        //    //obj_StrBuilder.Replace("?", "&#1740;")
        //    //'strFileToExport = "Scores_Words.xls"
        //    //'strContentType = "application/vnd.word;"
        //    //strFileToExport = filename
        //    //strContentType = app
        //    //HttpContext.Current.Response.Clear()
        //    //HttpContext.Current.Response.BufferOutput = True
        //    //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8
        //    //HttpContext.Current.Response.Charset = "UTF-8"

        //    //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" & strFileToExport)
        //    //HttpContext.Current.Response.ContentType = strContentType
        //    //HttpContext.Current.Response.Write(obj_StrBuilder.ToString())
        //    //HttpContext.Current.Response.End()

        //}



        public static string CheckFile(HttpPostedFile a)
        {
            string[] acceptedFileTypes = new string[5];
            acceptedFileTypes[0] = ".jpg";
            acceptedFileTypes[1] = ".png";
            acceptedFileTypes[2] = ".gif";
            acceptedFileTypes[3] = ".bmp";
            acceptedFileTypes[4] = ".jpeg";
            bool c = false;
            for (int i = 0; i <= 4; i++)
            {
                if (Path.GetExtension(a.FileName) == acceptedFileTypes[i])
                    c = true;
            }

            string alarm = "";
            if (a.ContentLength > 300 * 1024)
                alarm = "عکس " + a.FileName + "باید از 300 کیلو بایت کمتر باشد";
            else if (!c)
                alarm = "عکس " + a.FileName + "باید نوع معتبر داشته باشد";

            return alarm;
        }
       

        public static bool sendmail(string address, string subject, string body, string MyEmail, string MyPass)
        {
            bool result = true;
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            //mailMessage.From = New System.Net.Mail.MailAddress("helli@hemail.ir")
            mailMessage.From = new System.Net.Mail.MailAddress("" + MyEmail + "@hemail.ir");
            mailMessage.To.Add(new System.Net.Mail.MailAddress(address));
            mailMessage.Priority = System.Net.Mail.MailPriority.High;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            string smtpsetting = "hemail.ir";
            string smtpUsername = "" + MyEmail + "@hemail.ir";
            string smtpPassword = MyPass;
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtpsetting);
            if (!string.IsNullOrEmpty(smtpUsername) & smtpPassword != "0")
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
            }
            try
            {
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public static void SendMail(string mailtext,string to){
            SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
            mail.To.Add(new MailAddress(to));
            mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            smtpClient.Send(mail);
        }

        public static string  removeSpace(string s){
        return Regex.Replace(s.Trim(), @"\s+", "");
        }

        public static bool? STb(string s) {
            if(s=="-111")
                return null;
            if (s == "" || s == "0" || s==null    )
                return false;
            else
                return true;
        }

        public static string   EmpToNull(string  i){
            if (i == "")
                return null;
            else
                return i;
        }

      

        public static string  BTS(bool s) {
            if (s == true)
                return "1";
            else if (s == null)
                return null;
            else
                return "0";
        }

        public static bool  ModeInsert(string i){
            if (i == "0" || i == "" || i == null)
                return true;
            else
                return false;
        }
        
        public static string cnstr()
        {
            return ConfigurationManager.ConnectionStrings["TerraficCnn"].ConnectionString;

            //; "Data Source=.;Initial Catalog=Taxi;Integrated Security=True";
        }

        public static bool sendmail(string address, string subject, string body)
        {
            bool result = true;
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("makarem@makarem.ir");
            mailMessage.To.Add(new System.Net.Mail.MailAddress(address));
            mailMessage.Priority = System.Net.Mail.MailPriority.High;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            string smtpsetting = "hemail.ir";
            string smtpUsername = "makarem@makarem.ir";
            string smtpPassword = "ali110";
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtpsetting);
            if (!string.IsNullOrEmpty(smtpUsername) & smtpPassword != "0")
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
            }
            try
            {
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public static bool CheckMail(string email)
        {
            if (String.IsNullOrEmpty(email)) return false;
            var pos = email.IndexOf('@');
            if (pos == -1) return false;
            var pos2 = email.LastIndexOf('.');
            if (!(pos < pos2)) return false;
            return true;
        }
        public static bool CheckDigit(string str, int Minlenght = 0, int Maxlenght = 10)
        {
            if (str.Length < Minlenght) return false;
            if (Maxlenght < str.Length) return false;
            var key = 0;
            if (String.IsNullOrEmpty(str)) return false;
            for (int j = 0; j < str.Length; j++)
            {
                key = Convert.ToInt32(str[j]);
                if (!(48 <= key && key <= 57)) return false;
            }
            return true;
        }
        public static bool CheckScripts(string str, int Minlenght = 0, int Maxlenght = 10)
        {
            if (str.Length < Minlenght) return false;
            if (Maxlenght < str.Length) return false;
            int key = 0;
            for (int i = 0; i < str.Length; i++)
            {
                key = Convert.ToInt32(str[i]);
                if (!((97 <= key && key <= 125) || (1570 <= key) || (key == 32))) return false;
            }
            return true;
        }
        public static bool CheckUserAndPass(string str, int Minlenght = 6, int Maxlenght = 20)
        {
            if (str.Length < Minlenght) return false;
            if (Maxlenght < str.Length) return false;
            int key = 0;
            for (int i = 0; i < str.Length; i++)
            {
                key = Convert.ToInt32(str[i]);
                if (!((97 <= key && key <= 125) || (48 <= key && key <= 57) || (65 <= key && key <= 90))) return false;
            }
            return true;
        }
        public static bool CheckInjection(string str)
        {
            if (str.Contains("'"))
            {
                return false;
            }
            else if (str.ToLower().Contains("script"))
            {
                return false;
            }
            else if (str.ToLower().Contains("select"))
            {
                return false;
            }
            else if (str.ToLower().Contains("update"))
            {
                return false;
            }
            else if (str.ToLower().Contains("insert"))
            {
                return false;
            }
            else if (str.ToLower().Contains("into"))
            {
                return false;
            }
            else if (str.ToLower().Contains("delete"))
            {
                return false;
            }
            else if (str.ToLower().Contains("from"))
            {
                return false;
            }
            else if (str.ToLower().Contains("execute"))
            {
                return false;
            }
            else if (str.ToLower().Contains("print"))
            {
                return false;
            }
            else if (str.ToLower().Contains("union"))
            {
                return false;
            }
            else if (str.ToLower().Contains("join"))
            {
                return false;
            }
            return true;
        }
        public static string GetUserID() {
            if (HttpContext.Current.Session["PersonalID"] == null)
                return "0";
            else
                return HttpContext.Current.Session["PersonalID"].ToString();
        }
        public static string GetIPAddress()
        {
            var sIPAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(sIPAddress))
            {
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                var ipArray = sIPAddress.Split(',');
                return ipArray[0];
            }
        }
        public static string GetBrowser()
        {
            var s = System.Web.HttpContext.Current.Request.Browser.Browser;
            return s;
        }
        public static string GetOS()
        {
            return System.Web.HttpContext.Current.Request.Browser.Platform;
        }
        public static string GetBrowserVersion()
        {
            var ret = System.Web.HttpContext.Current.Request.Browser.Version;
            return ret.ToString();
        }
        public static string GetURL() {
            return System.Web.HttpContext.Current.Request.Url.AbsolutePath ;
        }

        public static void ErrorLog(string ex) {
            SqlConnection cnn = new SqlConnection(cnstr());
            SqlCommand cmd = new SqlCommand("Prc_ErrorLOG",cnn);
            cmd.Parameters.Add(new SqlParameter("ex", SqlDbType.NVarChar)).Value = ex;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


    }
}
