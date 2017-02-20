using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TrafficPlanCL;
using TrafficPlanDAL;

namespace TerraficPlan
{
    public class PublicFunction
    {
        public static string GetUniquCode()
        {
            string trancadeCode = "";
            int i = 0;

            DataSet ds = new DataSet();
            while (i == 0)
            {
                trancadeCode = TerraficPlanBLL.Utility.RandomString(12).ToUpper();
                ClRequestTraffic cl = new ClRequestTraffic();
                cl.TrackingCode = trancadeCode;
                ds = RequestTrafficClass.GetList(cl);
                if (ds.Tables[0].Rows.Count == 0)
                    i = 1;
            }
            return trancadeCode;
        }

        public static int SendSMSsOld(string mobile, string msg)
        {

            TerraficPlan.TerraficSms.Send sms = new TerraficPlan.TerraficSms.Send();

            long[] rec = null;
            byte[] status = null;
            int retval = sms.SendSms("rshekari", "r24qz137", new string[] { mobile.ToString() }, "1000724137", msg, false, "", ref rec, ref status);
            //retval :

            //    switch (retval){ 
            //        case 1:
            //           ReturnMSG="کلمه عبور نامعتبر.!!";
            //           break;
            //        case 2:
            //           ReturnMSG = "اعتبار موجود نمیباشد";
            //           break;
            //        case 3:
            //           ReturnMSG = "محدودیت روزانه!!";
            //           break;
            //        case 4:
            //           ReturnMSG = "محدودیت ارسال";
            //           break;
            //        case 5:
            //           ReturnMSG = "شماره همراه نامعتبر است!!!";
            //           break;
            //        case 6:
            //           ReturnMSG = "سیستم غیر فعال!!";
            //           break;
            //        case 7:
            //           ReturnMSG = "کلمات نامناسب";
            //        case 8:
            //           ReturnMSG = "Pardis Minimum Receivers";
            //        case 9:
            //           ReturnMSG = "شماره عمومی است!!";
            //           break;

            //}

            return retval;
            //Status :
            // Sent=0,
            // Failed=1


        }

        public static int SendSMSs(string mobile, string msg)
        {

            TerraficPlan.WebReference.Send sms = new TerraficPlan.WebReference.Send();

            long[] rec = null;
            byte[] status = null;
            int retval = sms.SendSms("hooshmand", "6613", new string[] { mobile.ToString() }, "9830002666025138", msg, false, "", ref rec, ref status);
            //retval :

            //    switch (retval){ 
            //        case 1:
            //           ReturnMSG="کلمه عبور نامعتبر.!!";
            //           break;
            //        case 2:
            //           ReturnMSG = "اعتبار موجود نمیباشد";
            //           break;
            //        case 3:
            //           ReturnMSG = "محدودیت روزانه!!";
            //           break;
            //        case 4:
            //           ReturnMSG = "محدودیت ارسال";
            //           break;
            //        case 5:
            //           ReturnMSG = "شماره همراه نامعتبر است!!!";
            //           break;
            //        case 6:
            //           ReturnMSG = "سیستم غیر فعال!!";
            //           break;
            //        case 7:
            //           ReturnMSG = "کلمات نامناسب";
            //        case 8:
            //           ReturnMSG = "Pardis Minimum Receivers";
            //        case 9:
            //           ReturnMSG = "شماره عمومی است!!";
            //           break;

            //}

            return retval;
            //Status :
            // Sent=0,
            // Failed=1


        }

        public static string GetTareefe(int reapeattype, int? discounttype)
        {
            string price = "0";
            ClDiscountPrice cl = new ClDiscountPrice();
            cl.RepeatTypeID = reapeattype;
            cl.DiscountID = discounttype;

            DataSet ds = DiscountPriceClass.GetList(cl);
            DataRow dr = ds.Tables[0].Rows[0];
            price = dr["Price"].ToString();
            ds.Dispose();
            return price;

        }

        public static int GetReqidFromEpayID(int epayid)
        {
            ClEpayOrder cl = new ClEpayOrder();
            cl.EpayOrderID = epayid;
            DataSet ds = EpayOrderClass.GetList(cl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                return Convert.ToInt32(dr["RequestID"].ToString());
            }
            else
                return 0;

        }
        public static string RegWSmojaz(int? reqid = 0, double epayid = 0)
        {
            string alert = "";

            ClEpayOrder cl = new ClEpayOrder();
            cl.EpayOrderID = Convert.ToInt32(epayid);
            DataSet ds = EpayOrderClass.GetList(cl);
            string groupid = ds.Tables[0].Rows[0]["GroupID"].ToString();
            if (groupid != "")
            {
                ClEpayGroup cl2 = new ClEpayGroup();
                cl2.GroupID = Convert.ToInt32(groupid);
                DataSet ds2 = EpayGroupClass.GetList(cl2);
                for (int i = 0; i <= ds2.Tables[0].Rows.Count-1; i++)
                {
                    alert += RegWSmojazOneReq(Convert.ToInt32(ds2.Tables[0].Rows[i]["ReqID"].ToString()), epayid);
                }
                ds2.Dispose();
            }
            else
                alert = RegWSmojazOneReq(reqid, epayid);

            ds.Dispose();

            return alert;
 
        }

        public static string RegWSmojazOneReq(int? reqid = 0, double epayid = 0)
        {
            string alarm = "";

            if (reqid == 0)
                reqid = GetReqidFromEpayID(Convert.ToInt32(epayid));
            if (reqid <= 0)
            {
                alarm = "خطا در گرفتن شماره تراکنش";
                return "";
            }



            string pelak = "";
            byte pelak_type;
            byte plan_type;
            byte off_type;
            string familyName;
            int mobile_num;
            string start_time;
            string end_time;
            int rial;
            string stations;
            string retvalue;
            int c = 0;
            int i = 0;
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.RequestTrafficID = reqid;
            string Tempretval = "";

            DataSet ds = RequestTrafficClass.GetListWS(cl);
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                pelak = dr["pelak"].ToString();
                pelak_type = Convert.ToByte(dr["pelak_type"].ToString());
                plan_type = Convert.ToByte(dr["plan_type"].ToString() == "" ? "0" : dr["plan_type"].ToString());
                off_type = Convert.ToByte(dr["off_type"].ToString());//Convert.ToByte(0);
                familyName = dr["familyName"].ToString();
                mobile_num = Convert.ToInt32(dr["mobile_num"].ToString());
                start_time = dr["start_time"].ToString();//"2015-06-09";//
                end_time = dr["end_time"].ToString();//"2015-06-10";
                rial = Convert.ToInt32(dr["rial"].ToString());
                stations = "141101,141251,141351,141451,141501,141601,141301,141102,141201";// dr["stations"].ToString();// "0";
                //try
                //{
                   // TerraficPlan.WSmojaz.Service1 WSmojaz = new TerraficPlan.WSmojaz.Service1();
                    TerraficPlan.Mojaz2.Service1 WSmojaz = new TerraficPlan.Mojaz2.Service1();
                    string retval = WSmojaz.add_mojaz("user1", "user*11", pelak, pelak_type, plan_type, off_type, familyName, mobile_num, start_time, end_time, rial, stations);
                    Tempretval += retval + ",";

                    if (Convert.ToInt32(retval) > 0)
                    {
                        alarm += "";
                        c += 1;
                        //Tempretval += retval + ",";
                     }
                    else
                        alarm += "خطا در اتصال به سامانه محدوده طرح ترافیک";
                //}
                //catch
                //{
                //    alarm += "خطا در اتصال به سامانه محدوده طرح ترافیک";
                //}


            }//end for
            if (i != c)
            { alarm += "خطا در ثیت مجوز در بانک"; }

            UpReqForMojaz(reqid, Tempretval);
            return alarm;

        }

        private static int UpReqForMojaz(int? reqid, string retmojaz)
        {
            ClRequestTraffic cl = new ClRequestTraffic();
            cl.RequestTrafficID = reqid;
            cl.WsMojaz = retmojaz;
            int i = RequestTrafficClass.Update(cl);
            if (i > 0)
                return 1;
            else
                return i;
        }


    }
}