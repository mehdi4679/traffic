<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="Yearly.aspx.cs" Inherits="TerraficPlan.New.Yearly" %>

<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
     <style>
        .dselecttype {
        width:auto;
        float:right;
        background-color:#CDCDCD;
        padding:5px;
        border-style:solid;
        border-radius:5px;
        font-family:'mitrabold',Tahoma;
        margin:5px;
        
        }
    .wizard-steps li .title {

        margin-top:-10px;
    }
      .selectmonth{width:700px}
        .dselected {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;

        }
        
        .bahar {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:lightgreen;
    cursor: pointer; cursor: pointer;
        }   
        .tabestan {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:red;
    cursor: pointer; cursor: pointer;
        } 
        .payeez {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:lightyellow;
    cursor: pointer; cursor: pointer;
        } 
       .Zemestan {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:white;
    cursor: pointer; cursor: pointer;
        }
        div {

            font-family:'mitrabold','tahoma';
        }
         
    </style>
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label runat="server" ID="lblREpeatTypeID" Text="0" Visible="false"></asp:Label>
    <input type="text" id="tareff" value="100" runat="server" class="tareffprice" style="display:none"/>
  <%--        <div style="width: 100%">
            <div class="dselecttype ">
                <input style="padding-right: 10px" class="rdw" type="radio" runat="server" name="dis" id="rbWhithOutDiscount" value="بدون تخفیف" checked>خودروهای عادی</input></div>
            <div class="dselecttype ">
                <input style="padding-right: 10px" type="radio" name="dis" runat="server" id="rbWhithDiscount" value="با تخفیف" class="rdw1" >خودروهای آژانس  درون شهری </input></td></tr></table>


            </div>


        </div>
    </div>--%>
<table>
<tr>
                <td><span class="clrequir">*</span>کد ملی:</td>
                <td>
                    <asp:TextBox runat="server" ID="TXTNationalCode" data-rel="tooltip" data-placement="left" title="فقط عدد و بدون خط تیره" placeholder="فقط عدد و بدون خط تیره"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RVNationalCode" runat="server"
                        ControlToValidate="txtNationalCode" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید"
                        ValidationExpression="^[+]?\d*$" SetFocusOnError="True"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TXTNationalCode"
                        Display="Dynamic" ErrorMessage="کد ملی نامعتبر است" ClientValidationFunction="checkMelliCode"
                        SetFocusOnError="True" ValidateEmptyText="false" ValidationGroup="RFV" ForeColor="Red"
                        Width="128px"></asp:CustomValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RqNationalCode" runat="server"  ControlToValidate="txtNationalCode" ErrorMessage="لطفا پر کنید" ValidationGroup="RVTbl_Personal" ForeColor="Red"> </asp:RequiredFieldValidator>

                </td>
            </tr>
                <tr><td><span class="clrequir">*</span>  نام:</td><td><asp:TextBox runat="server" ID="txtFirstName"  data-rel="tooltip" title="فقط حروف فارسی وارد کنید"></asp:TextBox></td>
                    <td>                    <asp:RegularExpressionValidator ID="RVLastName" runat="server"
                        ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="فقط حروف فارسی وارد کنید"
                        ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator135556" runat="server"
                        ControlToValidate="txtFirstName" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"> </asp:RequiredFieldValidator> </td>
                 </tr>
            <tr><td><span class="clrequir">*</span> نام خانوادگی:</td><td><asp:TextBox runat="server" ID="txtLastName"  data-rel="tooltip" title="فقط حروف فارسی وارد کنید"></asp:TextBox></td>
                    <td>                    <asp:RegularExpressionValidator ID="txtLastNameRVLastName" runat="server"
                        ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="فقط حروف فارسی وارد کنید"
                        ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                  <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3221" runat="server"
                        ControlToValidate="txtLastName" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"> </asp:RequiredFieldValidator> </td>
            </tr>

<tr>
                <td> <span class="clrequir">*</span> تلفن همراه:  </td>
                <td>
                    <asp:TextBox runat="server" ID="TXTPersonalMobile" MaxLength="11" data-rel="tooltip" title="شماره موبایل را 11 رقمی و صحیح وارد نمایید"></asp:TextBox></td>
                <td></td>
                <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"    ValidationGroup="RVTbl_Personal" 
                     ControlToValidate="TXTPersonalMobile" Display="Dynamic"  
                     ErrorMessage="شماره موبایل را 11 رقمی و صحیح وارد نمایید" ValidationExpression="^\d{11}$"> </asp:RegularExpressionValidator>
                    
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server"
                        ControlToValidate="TXTPersonalMobile" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"> </asp:RequiredFieldValidator> </td>
            </tr>
<tr><td><span class="clrequir">*</span> آدرس:</td><td><asp:TextBox runat="server" ID="txtAdress"  data-rel="tooltip" title="آدرس جهت ارسال برچسب دقیق ذکر شود" TextMode="MultiLine" ></asp:TextBox></td>
                    <td>                    
                </td>
                  <td>
                <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidator3err" runat="server"
                        ControlToValidate="txtAdress" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"> </asp:RequiredFieldValidator> --%>

                  </td>
            </tr>
    <tr><td><span class="clrequir">*</span> کد پستی:</td><td><asp:TextBox runat="server" ID="txtPostiCode"  data-rel="tooltip" title="کد پستی جهت ارسال برچسب دقیق ذکر شود"></asp:TextBox></td>
                    <td>                    
                </td>
                  <td>
                     <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1345" runat="server"
                        ControlToValidate="txtPostiCode" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"> </asp:RequiredFieldValidator> --%>

                  </td>
            </tr>
<tr>
    <td> <span class="clrequir">*</span>پلاک</td><td colspan="10" style="text-align:center" >
    <uc1:CtlPelak runat="server" ID="CtlPelak" />
    </td>

</tr>
    </table>
    <table>
<tr runat="server" id="trYear" visible="false">
    <td>انتخاب طرح برای سال </td> 
            <td colspan="10">
     <asp:DropDownList runat="server" ID="ddYear"></asp:DropDownList>
        
    
</td>

</tr>
<tr runat="server" id="TrMonth" visible="false">
    <td>انتخاب طرح ماهیانه </td> 
            <td colspan="10">
 <div id="dselectMonth" class="select selectmonth" runat="server">
                <div class="dmonth bahar"><asp:CheckBox runat="server" Text="فروردین" ID="ch1" name="lineup[]"> </asp:CheckBox> </div> 
                <div class="dmonth bahar"><asp:CheckBox runat="server" Text="اریبهشت"  ID="ch2"  name="lineup[]"/></div> 
                <div class="dmonth bahar"><asp:CheckBox runat="server" Text="خرداد "  ID="ch3" /></div> 
                <div class="dmonth tabestan"><asp:CheckBox runat="server" Text="تیر"  ID="ch4" /></div> 
                <div class="dmonth tabestan"><asp:CheckBox runat="server" Text="مرداد"  ID="ch5" /> </div> 
                <div class="dmonth tabestan"><asp:CheckBox runat="server" Text="شهریور" ID="ch6" /> </div> 
                <div class="dmonth payeez"><asp:CheckBox runat="server" Text="مهر"  ID="ch7" /></div> 
                <div class="dmonth payeez"><asp:CheckBox runat="server" Text="آبان"  ID="ch8" /></div> 
                <div class="dmonth payeez"><asp:CheckBox runat="server" Text="آذر"  ID="ch9" /></div> 
                <div class="dmonth Zemestan"><asp:CheckBox runat="server" Text="دی" ID="ch10"  /></div> 
                <div class="dmonth Zemestan"><asp:CheckBox runat="server" Text="بهمن" ID="ch11"  /></div> 
                <div class="dmonth Zemestan"><asp:CheckBox runat="server" Text="اسفند" ID="ch12"  /></div> 
            </div>        
    
</td>
</tr>
<tr runat="server" id="Trseason" visible="false">
 <td>انتخاب طرح فصلی </td> 
    <td>
        <div id="dselectSeason" class="select selectsason">
                <div class="dmonth bahar">  <asp:CheckBox runat="server" ID="chbahar" Text="بهار"  CssClass="chhh" /> </div> 
                 <div class="dmonth tabestan"> <asp:CheckBox runat="server" ID="chtab" Text="تابستان"  CssClass="chhh" /></div> 
                  <div class="dmonth payeez"> <asp:CheckBox runat="server" ID="chpayyz" Text="پاییز"  CssClass="chhh" /></div> 
                 <div class="dmonth Zemestan"> <asp:CheckBox runat="server" ID="chzem" Text="زمستان"  CssClass="chhh" /></div> 

            </div>
    </td>
</tr>
</table>
<table>
    <tr>
    <td>مدل خودرو</td>
                                                       <td><div style="padding-top:20px" ><table><tr>
                                                           <td>
    <fieldset class="fieldsetdiv" style="padding:25px"><legend style="margin-bottom:-3px;margin-bottom:2px"><asp:RadioButton Checked="true" runat="server" Text="شمسی" GroupName="rr" Style="padding-right:10px" ID="rdSahmsi" />
        <asp:RadioButton runat="server" Text="میلادی"  GroupName="rr" ID="rdmilady"/></legend> 
    <asp:TextBox runat="server" data-rel="tooltip" title="در وارد کردن تاریخ شمسی یا میلادی دقت نمایید" data-placement="left" data-original-title="  تاریخ شمسی یا میلادی را 4 رقمی وارد   نمایید" ID="DDCarModel" MaxLength="4" onkeyup="var Key = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if (Key==37 || Key==38 || Key==39 || Key==40 || Key==9) return false; " onkeypress="ValidateNumber(event); "></asp:TextBox></fieldset>    
</tr></table></div></td><td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"    ValidationGroup="RVTbl_Car" 
                     ControlToValidate="DDCarModel" Display="Dynamic"  
                     ErrorMessage="مدل خودرو را 4 رقمی و صحیح وارد نمایید" ValidationExpression="^\d{4}$"> </asp:RegularExpressionValidator>
</td><td></td><td></td></tr>
            <tr><td>پیوست کارت خودرو</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadCard" runat="server"  />
        </td><td>&nbsp;</td><td>
        &nbsp;</td><td>                 &nbsp;</td></tr>
    <tr><td>پیوست معاینه فنی</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadFani" runat="server" />
        </td><td>&nbsp;</td><td>
        &nbsp;</td><td>                 &nbsp;</td></tr>
    <tr runat="server" id="trmoarrefi" visible="false" ><td>پیوست معرفی نامه(اختیاری)</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadmorrefi" runat="server" />
        </td><td>&nbsp;</td><td>
        &nbsp;</td><td>                 &nbsp;</td></tr>

</table>


   <table runat="server" id="ts" visible="false" ><tr><td>
       <input type="checkbox" id="isSakenSelected"  class="ff" runat="server" visible="false" />
                                                       </td><td>ساکن در محدوده طرح ترافیک میباشم</td></tr>
<tr><td>
       <input type="checkbox" id="isSakenSelected2"  class="ffj" runat="server"   />
                                                       </td><td>من جانباز/معلول هستم</td></tr>
<%--<tr><td>
       <input type="checkbox" id="isSakenSelected3"  class="ffj" runat="server" visible="false" />
                                                       </td><td>من معلول هستم</td></tr>
   --%></table> 
    <div id="dSaken" style="display:none">
        <fieldset><legend>مشخصات متقاضی ساکن در محدوده طرح ترافیک  </legend>
        <table style="margin-top: 15px;">
<%--            <tr><td>آدرس:</td><td><asp:TextBox TextMode="MultiLine" runat="server" ID="PersonalAdress"></asp:TextBox></td></tr>--%>
         <tr><td>پیوست کپی سند یا قولنامه</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadSanad" runat="server"  />
        </td> </tr>
                     <tr><td>پیوست یکی از قبوض منزل</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadghabz" runat="server"  />
        </td> </tr>

        </table>
            </fieldset>
    </div>
         <div id="dJanbaz" style="display:none">
        <fieldset><legend>مشخصات  تکمیلی جانبازان و معلولین  </legend>
        <table style="margin-top: 15px;">
             <tr><td>پیوست نامه بنیاد شهید یا بهزیستی</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadjanbaz" runat="server"  />
        </td> </tr>
                     
        </table>
            </fieldset>
    </div>

<div id="dPrice">
       <table><tr><td> مبلغ قابل پرداخت بدون تخفیف به ریال:</td><td><h1><asp:Label runat="server" ID="lblPrice" CssClass="priceclass"  ></asp:Label> </h1></td></tr></table> 
    </div>

    <asp:Button ValidationGroup="RVTbl_Personal" runat="server" ID="btnRegREquest" Text="ثبت درخواست" OnClick="btnAddRequest_Click" />
 

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
    <div>کاربر گرامی لطفا قبل از خرید کد رهگیری را یادداشت نمایید  
    </div>
    <div> 
        <table>
            <tr><td> کد رهگیری شما جهت خرید:

                </td>
                <td>
                    <asp:Label runat="server" ID="lblRahCode" ></asp:Label>
                </td>
            </tr>
        </table>
<%--        <asp:Button runat="server" ID="btnAddRequest" OnClick="btnAddRequest_Click" />--%>
   <div>
<%--        <asp:Button runat="server" ID="BtnDailyReg" CssClass="btn-success "   Text="پرداخت"/>--%>
    </div>

    </div>
   
   
    </div>
    </div>

      <input type="hidden"  id="LightBox" runat="server" /> 
      <input type="hidden"  id="typee" runat="server"  value="0"/>
    <script>
        
        function checkboxcheck() {

            if ($(".ff").is(':checked')) {
                $("#dSaken").show(1000);  // checked
                $(".ffj").attr("checked", false);
                $("#dJanbaz").hide(1000);
            }
            else
                $("#dSaken").hide(1000);

            if ($(".ffj").is(':checked')) {
                $("#dJanbaz").show(1000);  // checked
                $(".ff").attr("checked", false);
                $("#dSaken").hide(1000);
            }
            else
                $("#dJanbaz").hide(1000);
        }

        checkboxcheck();




        $('.ff').click(function () {

            if ($(".ff").is(':checked')) {
                $("#dSaken").show(1000);  // 
                $(".ffj").attr("checked", false);
            }
            else
                $("#dSaken").hide(1000);
            checkboxcheck();
           // checkboxcheck();
        });

        $('.ffj').click(function () {

            if ($(".ffj").is(':checked')) {
                $("#dJanbaz").show(1000);  // checked
                $(".ff").attr("checked", false);
            }
            else
                $("#dJanbaz").hide(1000);

            checkboxcheck();
           // checkboxcheck();
        });

        $(".rdw").on("click", function (event) {
            $('#dPrice').fadeIn(1000);
        });
        $(".rdw1").on("click", function (event) {
            $('#dPrice').fadeOut(1000);
        });

        if ($(".rdw").attr("checked") == "checked") {
            $('#dPrice').fadeIn(1000);
        }
        if ($(".rdw1").attr("checked") == "checked") {
            $('#dPrice').fadeOut();
        }

        document.getElementById('<%= lblPrice.ClientID%>').innerHTML =  document.getElementById('<%= tareff.ClientID%>').value;

  var c=0;
        $("input[type='checkbox']").change(function () {
            if (this.checked)
                c += 1;
            else
                c -= 1;
            c = $("input:checked").length-1;

            if (document.getElementById('<%=typee.ClientID%>').value  != '6')
                document.getElementById('<%= lblPrice.ClientID%>').innerHTML = c * document.getElementById('<%= tareff.ClientID%>').value;

        })


        function showlight() {
            document.getElementById('<%= LightBox.ClientID %>').value = "1";
 
               }
               if (document.getElementById('<%= LightBox.ClientID %>').value == "1") {
            setTimeout(f, 0);
        }

        function g() {
            scripthelper.CloseLightBox("lightinsert");
        }
        function f() {
            scripthelper.ShowLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv");
        }
        function back() {
            scripthelper.CloseLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv")
    }
    </script>
</asp:Content>
