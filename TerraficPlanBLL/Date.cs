using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TerraficPlanBLL
{
    public class DateConvert
    {
        public static string m2sh(string jdate)
        {
            string result = "";
            if (!string.IsNullOrEmpty(jdate) || jdate == "1900/1/1")
            {
                PersianCalendar p = new PersianCalendar();
                DateTime dmiladi = new DateTime();
                dmiladi = Convert.ToDateTime(jdate);
                result = p.GetYear(dmiladi).ToString() + "/" + p.GetMonth(dmiladi).ToString() + "/" + p.GetDayOfMonth(dmiladi).ToString();
            }
            return result;
        }

        public static DateTime sh2m(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return DateTime.Parse("1900/1/1");
            }
            else
            {
                PersianCalendar persian = new PersianCalendar();
                DateTime result;
                string[] TempDate;
                TempDate = date.Split('/');

                int year = Int32.Parse(TempDate[0]);
                int month = Int32.Parse(TempDate[1]);
                int day = Int32.Parse(TempDate[2]);
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                int second = DateTime.Now.Second;
                int milisecond = DateTime.Now.Millisecond;
                result = persian.ToDateTime(year, month, day, hour, minute, second, milisecond);
                return result;
            }

        }
    }
}
