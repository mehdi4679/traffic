using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
using TerraficPlanBLL;
using System.Data;
using System.Web.UI.HtmlControls;
using TerraficPlan.Controls;

namespace TerraficPlan.Organ
{
    public partial class Car : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CtlCar1.peeee += new CtlCar.calll(p);
            if (!Page.IsPostBack)
            {
        

                string msggg = "<i class='ace-icon fa fa-bell-o bigger-110 purple'></i>" + "توجه:" + Environment.NewLine + "پلاک های ت,الف,جانبازان بالای 50 درصد و انتظامی معاف بوده و نیازی به خر ید طرح ترافیک ندارند ";
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, msggg);

                CtlCar1.PersonID = Convert.ToInt32(Session["PersonalID"]);
                CtlCar1.BindDD();
                CtlCar1.BindGrid();

                SetJanbaziOrgan(Convert.ToInt32( Session["PersonalID"].ToString()),CtlCar1);
            }

           
        }

        public static  void SetJanbaziOrgan(int PErsonalID,CtlCar c)
        {
            ClPersonal cl=new ClPersonal();
            cl.PersonalID=PErsonalID;

            DataSet ds = PersonalClass.GetList(cl);
            DataRow dr = ds.Tables[0].Rows[0];
            if (dr["CompanyTypeID"].ToString() == "1007")
                c.VisibleJanbaz = true;
            else
                c.VisibleJanbaz = false;

            ds.Dispose();
        }
        public void p() { }
    }
}