<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TerraficPlan.Organ.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="login-layout light-login">

                        <div class="login-container">
                        <div class="center">
                            <h1>
<%--                                <i class="ace-icon fa  fa-car green"></i>
                                <span class="green">سامانه فروش مجوز محدوده طرح ترافیک شهر قم  </span>--%>
                            </h1>
                            <h4 class="blue" id="id-company-text">مرکز مدیریت هوشمند  ترافیک شهرداری  قم</h4>
                        </div>

                        <div class="space-6"></div>

                        <div class="position-relative">
                            <div id="login-box" class="login-box visible widget-box no-border">
                                <div class="widget-body">
                                    <div class="widget-main">
                                        <h4 class="header blue lighter bigger">
                                            <i class="ace-icon fa fa-coffee green"></i>
                                            لطفا کد ملی و کلمه عبور خود را وارد کنید
                                        </h4>
                                        <div  >

                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserName"
                                        Display="Dynamic" ErrorMessage="کد ملی نامعتبر است" ClientValidationFunction="checkMelliCode"
                                        SetFocusOnError="True" ValidateEmptyText="false" ValidationGroup="RFV" ForeColor="Red"
                                        Width="128px"></asp:CustomValidator>
                                        </div>
                                        <div class="space-6"></div>
                                        <fieldset>
                                            <label class="block clearfix">
                                                <span class="block input-icon input-icon-right">
                                                    <input type="text" runat="server" ID="txtUserName" class="form-control" placeholder="کد ملی" />
                                                    <i class="ace-icon fa fa-user"></i>
                                                </span>
                                            </label>

                                            <label class="block clearfix">
                                                <span class="block input-icon input-icon-right">
                                                    <input type="password" class="form-control"  ID="txtPass"  runat="server" placeholder="کلمه عبور" />
                                                    <i class="ace-icon fa fa-lock"></i>
                                                </span>
                                            </label>

                                            <div class="space"></div>

                                            <div class="clearfix">
                                            <asp:Button runat="server" ID="btnLogin" Text="ورود به سامانه" 
                                                    class="width-35 pull-right btn btn-sm btn-primary bigger-110 ace-icon   " 
                                                    onclick="btnLogin_Click"   />
                           
                                      <asp:Label runat="server" ID="lblmsg" ForeColor="Red" ></asp:Label>
                                               <br />
                                               
                                                    <input type="checkbox" class="ace" />
                                                
                                            </div>

                                            <div class="space-4"></div>
                                        </fieldset>
                                        <div class="space-6"></div>
                                    </div>
                                    <!-- /.widget-main -->

                                    <div class="toolbar clearfix">
                                        <div style="width:auto">
                                            <a href="login.html#" data-target="#forgot-box" class="forgot-password-link">
                                                <i class="ace-icon fa fa-arrow-left"></i>
                                                کلمه عبور خود را فراموش کرده‌ام
                                            </a>
                                        </div>
                                    </div>
                         <div id="reg">  
                            <%-- <a href="/organ/RegPerson.aspx"> </a>--%>
                                 <div id="signindiv" style="border:solid; margin-top:5px;background:none repeat scroll 0 0 #f7f7f7" class="center">   
                                    <%--   <h1><span class="lbl">ثبت نام اولیه</span>--%>

                                       
<span style="color:black">

   
     متقاضیان محترم استفاده از تخفیف اعم از موسسات ارگانها,نهادها محترم
    در صورتیکه قبلا اقدام به ثبت نام نکرده اند    
    .ابتدا باید اقدام به ثبت نام نمایند.
    جانبازان و آژانس ها  پس   از ثبت پلاک از طریق نهاد خود میتوانند جهت خرید اقدام نمایند
    .
</span>


                                 </div>

                            

                         </div>

                                </div>
                                <!-- /.widget-body -->
                            </div>
                            <!-- /.login-box -->

                            <div id="forgot-box" class="forgot-box widget-box no-border">
                                <div class="widget-body">
                                    <div class="widget-main">
                                        <h4 class="header red lighter bigger">
                                            <i class="ace-icon fa fa-key"></i>
                                            باز نشانی کلمه عبور
                                        </h4>

                                        <div class="space-6"></div>
                                        <p>
                                            شماره تلفن همراه خود را وارد کنید تا رمز برایتان ارسال شود
                                        </p>
                                        <fieldset>
                                            <label class="block clearfix">
                                                <span class="block input-icon input-icon-right">
                                                    <input  type="text" runat="server" id="txtmobile" CssClass="form-control " placeholder="شماره تلفن همراه" />
                                                    <i class="ace-icon fa fa-mobile large"></i>
                                                </span>
                                            </label>
 
                                            <div class="clearfix">
                                                <asp:Button Text="ارسال کلمه عبور" runat="server" ID="btnSendEmail" CssClass="width-35 pull-right btn btn-sm btn-danger ace-icon fa fa-lightbulb-o" OnClick="btnSendEmail_Click"
                  />
                                            </div>
                                        </fieldset>
                                    </div>
                                    <!-- /.widget-main -->

                                    <div class="toolbar center">
                                        <a href="login.html#" data-target="#login-box" class="back-to-login-link">بازگشت به صفحه ورود به سامانه
												<i class="ace-icon fa fa-arrow-right"></i>
                                        </a>
                                    </div>
                                </div>
                                <!-- /.widget-body -->
                            </div>
                            <!-- /.forgot-box -->
                        </div>
                        <!-- /.position-relative -->
                    </div>
</div>


     <script type="text/javascript">
         $(document).ready(function () {
           //  $('body').attr('class', 'login-layout light-login');
             $('#id-company-text').attr('class', 'blue');
         });

         jQuery(function ($) {
             $(document).on('click', '.toolbar a[data-target]', function (e) {
                 e.preventDefault();
                 var target = $(this).data('target');
                 $('.widget-box.visible').removeClass('visible'); //hide others
                 $(target).addClass('visible'); //show target
             });
         });
    </script>
     
    <script type="text/javascript">
        function checkMelliCode(val, args) {
            var meli_code;
            meli_code = args.Value;
            if (meli_code.length == 10) {
                if ((meli_code == '0000000000') || (meli_code == '1111111111') || (meli_code == '2222222222') || (meli_code == '3333333333') || (meli_code == '4444444444') || (meli_code == '5555555555') || (meli_code == '6666666666') || (meli_code == '7777777777') || (meli_code == '8888888888') || meli_code == ('9999999999')) {
                    alert("کد ملي صحيح نمي باشد");
                    args.IsValid = false;
                    return false;
                }
                c = parseInt(meli_code.charAt(9));
                n = (parseInt(meli_code.charAt(0)) * 10) + (parseInt(meli_code.charAt(1)) * 9) + (parseInt(meli_code.charAt(2)) * 8) + (parseInt(meli_code.charAt(3)) * 7) + (parseInt(meli_code.charAt(4)) * 6) + (parseInt(meli_code.charAt(5)) * 5) + (parseInt(meli_code.charAt(6)) * 4) + (parseInt(meli_code.charAt(7)) * 3) + (parseInt(meli_code.charAt(8)) * 2);
                r = n - parseInt(n / 11) * 11;
                if ((r == 0 && r == c) || (r == 1 && c == 1) || (r > 1 && c == 11 - r)) {
                    args.IsValid = true;
                }
                else {
                    alert("کد ملي صحيح نمي باشد");
                    args.IsValid = false;
                }
            }
            else {
                alert("کد ملي صحيح نمي باشد");
                args.IsValid = false;
                return false;
            }
        }


 </script>
</asp:Content>
