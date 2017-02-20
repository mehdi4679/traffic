using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficPlanCL;
using TrafficPlanDAL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TerraficPlan
{
    public partial class AfterPurches : System.Web.UI.Page
    {
        private string refrenceNumber = string.Empty;
        private string reservationNumber = string.Empty;
        private string transactionState = string.Empty;
        private string MerchantId = "10321755";
        bool isError = false;
        string errorMsg = "";
        string succeedMsg = "";
        private string message = "";
        private string UserName = "10321755";
        private string PassWord =  ConfigurationManager.AppSettings["9782538 "];
        private double EpayOrderID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            try
            {
                if (RequestUnpack())
                {


                    if (transactionState.Equals("OK"))
                    {



                        ///////////////////////////////////////////////////////////////////////////////////
                        //   *** IMPORTANT  ****   ATTENTION
                        // Here you should check refrenceNumber in your DataBase tp prevent double spending
                        ///////////////////////////////////////////////////////////////////////////////////
                        ClEpayOrder cl = new ClEpayOrder();
                        cl.RefId = refrenceNumber;
                        DataSet ds = EpayOrderClass.GetList(cl);
                        if (ds.Tables[0].Rows.Count > 1)
                        {
                            //com.samanepay.acquirer.reverseTransaction1CompletedEventHandler;
                            try { ReverseTransaction(); }
                            catch { }
                            TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "با این کد قبلا خرید شده  است .مبلغ حداکثر تا 48 ساعت دیگر عودت میگردد");
                            return;
                         }
                        ds.Dispose();
                        //////////////////////////////////////////////////////////////////////////////////




                        string RegMojaz = PublicFunction.RegWSmojaz(0, EpayOrderID);
                        if (RegMojaz != "")
                        {
                            TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, RegMojaz+" کاربر گرامی پول پرداختی شما تا چند دقیقه دیگر بازگشت خواهد خورد ");
                            return;
                        }

                        
                        //For Ignore SSL Error
                        ServicePointManager.ServerCertificateValidationCallback =
                        delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                        var srv = new ServiceReference1.PaymentIFBindingSoapClient();
                        var result = srv.verifyTransaction1(refrenceNumber, MerchantId);
                        ////////////////////////Save Result To DB///////////////////////////
                        ////////////string SQL = "update Tbl_EpayOrder set VerifyResult=" + result.ToString() + " where ResCode=" + reservationNumber.ToString() + " and RefId=" + refrenceNumber.ToString() + "";
                        ////////////SqlCommand cmd = new SqlCommand(SQL,new SqlConnection(CSharp.PublicFunction.cnstr()) );
                        ////////////cmd.CommandType = System.Data.CommandType.Text;
                        ClEpayOrder ClResultVerify = new ClEpayOrder();
                        //ClResultVerify.RefId = refrenceNumber;
                        //ClResultVerify.ResCode = reservationNumber;
                        ClResultVerify.VerifyResult = result.ToString();
                        ClResultVerify.EpayOrderID =Convert.ToInt32( EpayOrderID);
                        EpayOrderClass.Update(ClResultVerify);
                        /////////////////////////////////////////////////////////////////////
                         if (result > 0)
                        {
                            ClEpayOrder cl2 = new ClEpayOrder();
                            cl2.ResCode = reservationNumber;
                            DataSet ds2 = EpayOrderClass.GetList(cl2);
                                DataRow dr2 = ds2.Tables[0].Rows[0];
                                if (Convert.ToInt32(dr2["Prcie"].ToString()) != result)//check price
                                {
                                    isError = true;
                                    try { ReverseTransaction(); }
                                    catch { TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "عملیات خرید لغو شد"); }
                                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "مبلغ بازگشتی معتبر نیست وعملیات خرید لغو و مبلغ عودت شد");
                                }
                                else
                                {
                                    isError = false;
                                    succeedMsg = "بانک صحت رسيد ديجيتالي شما را تصديق نمود. فرايند خريد تکميل گشت";
                                    TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.General_Success, succeedMsg);
                                   ///Save To DB Transaction Complete
                                    ClEpayOrder cll = new ClEpayOrder();
                                    cll.EpayOrderID = Convert.ToInt32(EpayOrderID);
                                   // cll.ResCode = reservationNumber;
                                    cll.Comment = "OKK";
                                     EpayOrderClass.Update(cll);
                               }
                         }
                        else
                        {
                            TransactionChecking((int)result);
                        }
                    }
                    else
                    {
                        isError = true;
                        errorMsg = "متاسفانه بانک خريد شما را تاييد نکرده است";


                        if (transactionState.Equals("Canceled By User") || transactionState.Equals(string.Empty))
                        {
                            // Transaction was canceled by user
                            isError = true;
                            errorMsg = "تراكنش توسط خريدار كنسل شد";
                        }
                        else if (transactionState.Equals("Invalid Amount"))
                        {
                            isError = true;
 
                            // Amount of revers teransaction is more than teransaction
                        }
                        else if (transactionState.Equals("Invalid Transaction"))
                        {
                            // Can not find teransaction
                        }
                        else if (transactionState.Equals("Invalid Card Number"))
                        {
                            // Card number is wrong
                        }
                        else if (transactionState.Equals("No Such Issuer"))
                        {
                            // Issuer can not find
                        }
                        else if (transactionState.Equals("Expired Card Pick Up"))
                        {
                            // The card is expired
                        }
                        else if (transactionState.Equals("Allowable PIN Tries Exceeded Pick Up"))
                        {
                            // For third time user enter a wrong PIN so card become invalid
                        }
                        else if (transactionState.Equals("Incorrect PIN"))
                        {
                            // Pin card is wrong
                        }
                        else if (transactionState.Equals("Exceeds Withdrawal Amount Limit"))
                        {
                            // Exceeds withdrawal from amount limit
                        }
                        else if (transactionState.Equals("Transaction Cannot Be Completed"))
                        {
                            // PIN and PAD are currect but Transaction Cannot Be Completed
                        }
                        else if (transactionState.Equals("Response Received Too Late"))
                        {
                            // Timeout occur
                        }
                        else if (transactionState.Equals("Suspected Fraud Pick Up"))
                        {
                            // User did not insert cvv2 & expiredate or they are wrong.
                        }
                        else if (transactionState.Equals("No Sufficient Funds"))
                        {
                            // there are not suficient funds in the account
                        }
                        else if (transactionState.Equals("Issuer Down Slm"))
                        {
                            // The bank server is down
                        }
                        else if (transactionState.Equals("TME Error"))
                        {
                            // unknown error occur
                        }

                        TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, errorMsg);

                    }




                }
            }

            catch (Exception ex)
            {

                string s="عملیات با خطا مواجه شد"+Environment.NewLine+"کد :"+ EpayOrderID.ToString()+ " را برای رهگیری خطا یادداشت نمایید " ;
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, s);
                lblmsg.Text = s+Environment.NewLine+ex.ToString();
             }



        }

        private Double ReverseTransaction() {
            var r = new ServiceReference1.PaymentIFBindingSoapClient().reverseTransaction(refrenceNumber.ToString(), MerchantId.ToString(), MerchantId.ToString(), PassWord);
            return r;// TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, "کاربر گرامی خرید لغو شد ");
        }

        private bool RequestUnpack()
        {

            if (RequestFeildIsEmpty()) return false;

            refrenceNumber = Request.Form["RefNum"].ToString();
            reservationNumber = Request.Form["ResNum"].ToString();
            transactionState = Request.Form["state"].ToString();
            
         

           // message ="شماره رسید دیجیتالی:"+ refrenceNumber +Environment.NewLine + " شماره خرید: " + reservationNumber +Environment.NewLine+ " وضعیت خرید: " + transactionState + " \n";
            ClEpayOrder cl = new ClEpayOrder();
            cl.ResCode = reservationNumber;
            cl.RefId = refrenceNumber;
            cl.OrderStatus = transactionState;
           EpayOrderID= EpayOrderClass.UpdateByRaseCode(cl);

           lblref.Text = refrenceNumber.ToString();
           lblRacCode.Text = EpayOrderID.ToString();

           // TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.none, message.ToString());
            // txtResult.Text = message.ToString();



            return true;
        }

        private bool RequestFeildIsEmpty()
        {

            if (Request.Form["state"].ToString().Equals(string.Empty))
            {
                isError = true;
                errorMsg = "خريد شما توسط بانک تاييد شده است اما رسيد ديجيتالي شما تاييد نگشت! مشکلي در فرايند رزرو خريد شما پيش آمده است";
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, errorMsg);
                return true;
            }

            if (Request.Form["RefNum"].ToString().Equals(string.Empty) && Request.Form["state"].ToString().Equals(string.Empty))
            {
                isError = true;
                errorMsg = "فرايند انتقال وجه با موفقيت انجام شده است اما فرايند تاييد رسيد ديجيتالي با خطا مواجه گشت";
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, errorMsg);

                return true;
            }

            if (Request.Form["ResNum"].ToString().Equals(string.Empty) && Request.Form["state"].ToString().Equals(string.Empty))
            {
                isError = true;
                errorMsg = "خطا در برقرار ارتباط با بانک";
                TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, errorMsg);

                return true;
            }
            return false;
        }



        private string TransactionChecking(int i)
        {
            bool isError = false;
            string errorMsg = "";
            switch (i)
            {

                case -1: //TP_ERROR
                    isError = true;
                    errorMsg = "بروز خطا درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-1";
                    break;
                case -2: //ACCOUNTS_DONT_MATCH
                    isError = true;
                    errorMsg = "بروز خطا در هنگام تاييد رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-2";
                    break;
                case -3: //BAD_INPUT
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-3";
                    break;
                case -4: //INVALID_PASSWORD_OR_ACCOUNT
                    isError = true;
                    errorMsg = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-4";
                    break;
                case -5: //DATABASE_EXCEPTION
                    isError = true;
                    errorMsg = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-5";
                    break;
                case -7: //ERROR_STR_NULL
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-7";
                    break;
                case -8: //ERROR_STR_TOO_LONG
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-8";
                    break;
                case -9: //ERROR_STR_NOT_AL_NUM
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-9";
                    break;
                case -10: //ERROR_STR_NOT_BASE64
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-10";
                    break;
                case -11: //ERROR_STR_TOO_SHORT
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-11";
                    break;
                case -12: //ERROR_STR_NULL
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-12";
                    break;
                case -13: //ERROR IN AMOUNT OF REVERS TRANSACTION AMOUNT
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-13";
                    break;
                case -14: //INVALID TRANSACTION
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-14";
                    break;
                case -15: //RETERNED AMOUNT IS WRONG
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-15";
                    break;
                case -16: //INTERNAL ERROR
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-16";
                    break;
                case -17: // REVERS TRANSACTIN FROM OTHER BANK
                    isError = true;
                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد "+Environment.NewLine+"برگشت تراکنش از بانک دیگر " + "-17";
                    break;
                case -18: //INVALID IP
                    isError = true;
                    errorMsg = "آی پی سایت اشتباه است " + "-18";
                    break;

            }
         //   TextBox1.Text = errorMsg.ToString();
            TerraficPlanBLL.Utility.ShowMsg(Page, TerraficPlanBLL.ProPertyData.MsgType.warning, errorMsg.ToString());
            return errorMsg;
        }

        protected void btnReBuy_Click(object sender, EventArgs e)
        {
            // string i = Session["PersonalID"].ToString();
            //Session.Clear();

            //if (Session["PersonalID"] != null && Session["PersonalID"] != "" && Session["PersonalID"] != "0")
            //    Session["PersonalID"] = i;
            //{
            //    ClEpayOrder cl = new ClEpayOrder();
            //    cl.RefId =lblref.Text.ToString();
            //    cl.ResCode =lblRacCode.Text.ToString();
            //    DataSet ds = EpayOrderClass.GetList(cl);
            //    DataRow dr = ds.Tables[0].Rows[0];
            //    ds.Dispose();

            //    ClRequestTraffic clreq=new ClRequestTraffic();
            //    clreq.RequestTrafficID = Convert.ToInt32(dr["RequestID"]);
            //    DataSet dsreq = RequestTrafficClass.GetList(clreq);
            //    DataRow drreq = dsreq.Tables[0].Rows[0];
            //    Session["PersonalID"] = drreq["PersonalID"].ToString();
                Response.Redirect("~/loginmain.aspx");
            //}
            

        }

  
    }
}