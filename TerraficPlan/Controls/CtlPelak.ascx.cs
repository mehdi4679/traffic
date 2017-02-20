using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TerraficPlan.Controls
{
    public partial class CtlPelak : System.Web.UI.UserControl
    {
        public string Text
        {
            get
            {
                string p = txt2.Text + ddAlphabet.SelectedValue.ToString() + txt3.Text + "IR" + txt16.Text;

                if (p.Length == 5)
                    return "";
                else
                    return p;
            }
            set
            {

                if (value.Length == 10)
                {

                    string v = value;
                    txt2.Text = v.Substring(0, 2);
                    ddAlphabet.SelectedValue = v.Substring(2, 1);
                    txt3.Text = v.Substring(3, 3);
                    txt16.Text = v.Substring(8, 2);


                }
            }
        }

        public bool MustBeFill
        {
            get
            {
                return CheckEmptyPelak(Text);
            }
            set { }

        }
        private bool CheckEmptyPelak(string v)
        {
            if (v.Length < 7)
            {
                // lblpmsg.Text = "باید پلاک را وارد نمایید.";
                return false;
            }
            else
                //   lblpmsg.Text = "";
                return true;
        }
       


        public bool IsNumeric()
        {
            if (CheckIsnumber(txt2.Text) && CheckIsnumber(txt3.Text) && CheckIsnumber(txt16.Text))
                return true;
            else
                return
                    false;
        }
        private bool CheckIsnumber(string s)
        {
            try
            {
                int i = Convert.ToInt32(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Enable
        {
            get { return txt16.Enabled; }
            set
            {
                txt16.Enabled = value;
                txt2.Enabled = value;
                txt3.Enabled = value;
                txtIR.Enabled = value;
                ddAlphabet.Enabled = value;
            }
        }



    }
}