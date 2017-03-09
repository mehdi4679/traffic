using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using System.Web.UI.HtmlControls;
using System.Data;
using TrafficPlanDAL;
using TrafficPlanCL;

namespace TerraficPlan.report
{
    public partial class Mspsoft : System.Web.UI.Page
    {
        public static string code { get; set; }
        public static string epayorderid { get; set; }

        public static DataSet RetDs()
        {
            ClRequestTraffic cl = new ClRequestTraffic();
             cl.Epayorderid = epayorderid;

             DataSet ds = RequestTrafficClass.GetListManagerep(cl);
            return ds;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            epayorderid = Request.QueryString["epayid"].ToString();

            Page.Title = "مرکز مدیریت هوشمند ترافیک قم";


            DataSet ds = RetDs();
            

            for (int i = 0;  i< ds.Tables[0].Rows.Count ; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                 HtmlGenericControl divhead = new HtmlGenericControl("div");
                divhead.ID = "divheaad" + i;
                divhead.Style.Add("height", "211px"); divhead.Style.Add("width", "620px"); divhead.Style.Add(" margin-top", "10px"); divhead.Style.Add("border-style", "solid"); divhead.Style.Add("border-radius", "20px"); divhead.Style.Add("margin-left", "auto"); divhead.Style.Add(" margin-right", "auto"); divhead.Style.Add(" margin-bottom", "0");
                divhead.InnerHtml += "<p id='p1' class='auto-style2'>&nbsp<strong><span class='auto-style3'>بسمه تعالی</span></strong></p><p id='p2' class='auto-style2'><img class='auto-style4' src='arm2.png' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<img class='auto-style5' src='terrafic.png' /></p></br>" +
                "<p class='auto-style2'>تاریخ اخذ مجوز: #Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;کد رهگیری: #Code</p><p class='auto-style2'>&nbsp</p><p class='auto-style2'>&nbsp</p>";
                 //pointer - events:none;
                 HtmlGenericControl divbody = new HtmlGenericControl("div");
                divbody.ID = "divbody" + i;
                divbody.Style.Add("height", "673px"); divbody.Style.Add("width", "620px"); divbody.Style.Add(" margin-top", "5px"); divbody.Style.Add("border-style", "solid"); divbody.Style.Add("border-radius", "20px"); divbody.Style.Add("margin-left", "auto"); divbody.Style.Add(" margin-right", "auto"); divbody.Style.Add(" margin-bottom", "0"); //divbody.Style.Add(" background-image", "url('car.png')");
                divbody.InnerHtml = "<img id='img" + i + "' src='trafic.png' height='512' width='610' style='position:absolute;z-index:-1;'/><p class='auto-style1'><strong>&nbsp ریاست محترم پلیس راهنمایی و رانندگی استان قم</strong><p style = 'font-size: small'>&nbsp;&nbspسلام علیکم<p style= 'font-size: small' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp " +
                    "با احترام بدینوسیله گواهی می گردد برای خودروی #prlak به شماره پلاک ایران #Carname &nbsp; &nbsp&nbsp&nbsp&nbsp&nbspاز طریق سامانه مرکز مدیریت هوشمند ترافیک، اقدام به صدور مجوز&nbsp ورود&nbspبه محدوده طرح ترافیک هسته &nbsp&nbsp&nbsp&nbsp&nbspمرکزی شهر قم ازتاریخ #FromDate &nbsp لغایت #ToDate &nbsp گردیده است.<p style= 'font-size: small' >&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspاین گواهی بنا به درخواست مالک محترم خودرو برای تردد در محدوده طرح ترافیک هسته&nbsp;مرکزی &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp; &nbsp&nbsp&nbsp&nbsp&nbsp;شهر(به استثناء خطوط ویژه) صادر شده و ارزش دیگری ندارد.<p style= 'font-size: small' >&nbsp<p style = 'font-size: small' >" +
                  "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp<p style = 'font-size: small' >" +
                   "</br></br></br></br></br></br></br></br></br></br></br></br></br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspمرکز مدیریت هوشمند ترافیک" +
                  "<p style= 'font-size: small' >&nbsp<p style = 'font-size: small' >&nbsp";
                // "<center>"+"<asp:PlaceHolder ID = 'plBarCode' runat='server' /></center>";
                 HtmlGenericControl c = new HtmlGenericControl("center");
                c.ID = "c";
                c.Style.Add(" margin-top", "-50px");
 
                divbody.Controls.Add(c);
                //printablediv.Controls.Add(divhead);
                //printablediv.Controls.Add(divbody);

                divhead.InnerHtml =  divhead.InnerHtml.ToString().Replace(@"#Date", dr[""].ToString());
                divhead.InnerHtml =  divhead.InnerHtml.ToString().Replace(@"#Code", dr[""].ToString());
                divhead.InnerHtml =  divhead.InnerHtml.ToString().Replace(@"#prlak", dr[""].ToString());
                divhead.InnerHtml =  divhead.InnerHtml.ToString().Replace(@"#Carname", dr[""].ToString());
                divhead.InnerHtml =  divhead.InnerHtml.ToString().Replace(@"#FromDate", dr[""].ToString());
                divhead.InnerHtml =  divhead.InnerHtml.ToString().Replace(@"#ToDate", dr[""].ToString());

                string code = "اینجا اطلاعات وارد شود به صورت استرینگ";
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                imgBarCode.Height = 150;
                imgBarCode.Width = 150;
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();
                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                    c.Controls.Add(imgBarCode);
                }




            }




        }

        protected void btnGenerate_OnClick(object sender, EventArgs e)
        {
            
        }


    }
}