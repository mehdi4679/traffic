﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerraficPlanBLL
{
  
        public 
            class NumbertoText
        {

            // Convert Num To String
            private static string[] yekan = new string[10] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
            private static string[] dahgan = new string[10] { "", "", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
            private static string[] dahyek = new string[10] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
            private static string[] sadgan = new string[10] { "", "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
            private static string[] basex = new string[5] { "", "هزار", "میلیون", "میلیارد", "تریلیون" };

            public  static string getnum3(int num3)
            {
                string s = "";
                int d3, d12;
                d12 = num3 % 100;
                d3 = num3 / 100;
                if (d3 != 0)
                    s = sadgan[d3] + " و ";
                if ((d12 >= 10) && (d12 <= 19))
                {
                    s = s + dahyek[d12 - 10];
                }
                else
                {
                    int d2 = d12 / 10;
                    if (d2 != 0)
                        s = s + dahgan[d2] + " و ";
                    int d1 = d12 % 10;
                    if (d1 != 0)
                        s = s + yekan[d1] + " و ";
                    s = s.Substring(0, s.Length - 3);
                };
                return s;
            }


        }
 
}