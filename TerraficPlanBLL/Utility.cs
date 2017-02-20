using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TerraficPlanBLL
{
  public   class Utility
    {
        public static void ShowMsg(System.Web.UI.Page page,ProPertyData.MsgType type, string msg )
        {
            switch (type)
            {
                case ProPertyData.MsgType.General_Fault:
                  //  msg = "متاسفانه مشکلی پیش بینی نشده به وجود آمد.لطفا لحظاتی بعد مجددا سعی نمایید";
                    type = ProPertyData.MsgType.warning;
                    break;
                case ProPertyData.MsgType.General_Success:
                  //  msg = "انجام عملیات با موفقیت به پایان رسید";
                    type = ProPertyData.MsgType.accept;
                    break;
                default:
                    break;
            }

            string myScript2 = "showMsg('" + type.ToString() + "','" + msg + "') ";
            page.ClientScript.RegisterStartupScript(page.GetType(), "key" + DateTime.Now.Millisecond.ToString(), myScript2, true);
        }
         
        public static string GetRandomString()
        {
            string path = System.IO.Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
        public static string RandomDigit(int length)
        {
            //It will generate string with combination of small,capital letters and numbers
            char[] charArr = "0123456789".ToCharArray();
            string randomString = string.Empty;
            Random objRandom = new Random();
            for (int i = 0; i < length; i++)
            {
                //Don't Allow Repetation of Characters
                int x = objRandom.Next(1, charArr.Length);
                if (!randomString.Contains(charArr.GetValue(x).ToString()))
                    randomString += charArr.GetValue(x);
                else
                    i--;
            }
            return randomString;
        }
        public static string RandomString(int length)
        {
            //It will generate string with combination of small,capital letters and numbersABCDEFGHIJKLMNOPQRSTUVWXYZ
            char[] charArr = "0123456789".ToCharArray();
            string randomString = string.Empty;
            Random objRandom = new Random();
            for (int i = 0; i < length; i++)
            {
                //Don't Allow Repetation of Characters
                int x = objRandom.Next(1, charArr.Length);
             //   if (!randomString.Contains(charArr.GetValue(x).ToString()))
                    randomString += charArr.GetValue(x);
               // else
                 //   i--;
            }
            return randomString;
        }
        public static string GetMD5HashText(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));

                System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static bool IsValidExt(string strFilePath)
        {
            if (strFilePath.Contains("?"))
                strFilePath = strFilePath.Substring(0, strFilePath.IndexOf('?'));

            string[] astrValidExtensions = { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };

            bool isValid = false;
            foreach (string item in astrValidExtensions)
            {
                if (item.ToLower() == System.IO.Path.GetExtension(strFilePath).ToLower())
                    isValid = true;
            }

            return isValid;
        }
        public static bool IsValidPicOrSwfExt(string strFilePath)
        {
            if (strFilePath.Contains("?"))
                strFilePath = strFilePath.Substring(0, strFilePath.IndexOf('?'));

            string[] astrValidExtensions = { ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".swf", ".flv" };

            bool isValid = false;
            foreach (string item in astrValidExtensions)
            {
                if (item.ToLower() == System.IO.Path.GetExtension(strFilePath).ToLower())
                    isValid = true;
            }

            return isValid;
        }
        public static bool IsValidLink(string Link)
        {
            string strRegex = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Link))
                return true;
            else
                return false;


        }
        public static bool IsValidEmail(string address)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(address.Trim()))
                return true;
            else
                return false;
        }

        public static bool IsValiUserName(string UserName)
        {
            string strRegex = "[A-Za-z][A-Za-z0-9_-]{5,25}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(UserName.Trim()))
                return true;
            else
                return false;
        }

        public static bool IsNumeric(string input)
        {
            try
            {
                double x = double.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static long GetNumeric(object input, long Return = -1)
        {
            try
            {
                long x = long.Parse(input.ToString());
                return long.Parse(input.ToString());
            }
            catch
            {
                return Return;
            }
        }

        public static string GetString(object input, string Return = "")
        {
            try
            {
                string x = input.ToString();
                return input.ToString();
            }
            catch
            {
                return Return;
            }
        }

        public static bool isValidMelliCode(string MelliCode)
        {
            if (MelliCode.Length < 8)
                return false;

            int chk, s, r;

            if (MelliCode.Length == 8)
                MelliCode = "00" + MelliCode;

            if (MelliCode == "0000000000" || MelliCode == "1111111111" || MelliCode == "2222222222" || MelliCode == "3333333333" || MelliCode == "4444444444" || MelliCode == "5555555555" || MelliCode == "6666666666" || MelliCode == "7777777777" || MelliCode == "8888888888" || MelliCode == "9999999999")
                return false;

            chk = int.Parse(MelliCode.Substring(9, 1));

            s = 0;

            for (int i = 0; i < 9; i++)
            {
                s = s + int.Parse(MelliCode.Substring(i, 1)) * (10 - i);
            }

            r = s % 11;

            if ((r < 2 && chk == r) || (r >= 2 && chk == (11 - r)))
            {

                return true;
            }
            else
            {

                return false;
            }
        }

     
    }
}
