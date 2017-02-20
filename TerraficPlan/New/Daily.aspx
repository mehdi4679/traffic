<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="Daily.aspx.cs" Inherits="TerraficPlan.New.Daily" %>

<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    
    <%--    	<link type="text/css" href="styles/jquery-ui-1.8.14.css" rel="stylesheet" />
  <script type="text/javascript" src="/App_Themes/Theme1/Date/scripts/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="/App_Themes/Theme1/Date/scripts/jquery.ui.datepicker-cc.all.min.js"></script>
  --%>

</asp:Content>
    
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <%-- <input type="text" id="Text1" value="100" runat="server" class="tareffprice" style="display:none"/>
           <div style="width: 100%">
            <div class="dselecttype ">
                <input style="padding-right: 10px" class="rdw" type="radio" runat="server" name="dis" id="rbWhithOutDiscount" value="بدون تخفیف" checked>خودروهای عادی</input></div>
            <div class="dselecttype ">
                <input style="padding-right: 10px" type="radio" name="dis" runat="server" id="rbWhithDiscount" value="با تخفیف" class="rdw1" >خودروهای ثبت نام شده متعلق به ارگانها,سازمان ها و آژانس ها </input></td></tr></table>


            </div>


        </div>--%>
    </div>

    <div>
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
                    <asp:RequiredFieldValidator ID="RqNationalCode" runat="server"  ControlToValidate="txtNationalCode" ErrorMessage="لطفا پر کنید" ValidationGroup="RVTbl_Personal" ForeColor="Red">  </asp:RequiredFieldValidator>

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
                     ErrorMessage="شماره موبایل را 11 رقمی و صحیح وارد نمایید" ValidationExpression="^\d{11}$">    
                </asp:RegularExpressionValidator>
                    
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server"
                        ControlToValidate="TXTPersonalMobile" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red">
                    </asp:RequiredFieldValidator> </td>
            </tr>
<tr><td> <span class="clrequir">*</span>پلاک</td><td colspan="10" style="text-align:center" >
    <uc1:CtlPelak runat="server" ID="CtlPelak" />
    </td></tr>
        <tr> <td>انتخاب تاریخ</td> <td>
        <input  data-rel="tooltip" type="text" id="datepickerr" title="ابتدا تاریخ را مشخص و سپس روی دکمه انتخاب روز کلیک نمایید"></input>
            <input type="button" value="انتخاب روز" onclick="adddate();"/>
<%--    <input type="text" id="txtalld" />--%>

</td></tr>

        </table>

    </div>

    <div style="text-align:center;" align="center">
    <table id="myTable" class="gv " style="width:300px;text-align:center" align="center"  >
        <tr>
            <td>حذف</td>
            <td >تاریخ انتخابی</td>
        </tr>
    </table>

    </div>

    <div id="dPrice">
       <table><tr><td> مبلغ قابل پرداخت بدون در نظر گرفتن تخفیف به ریال:</td><td><h1> <asp:Label value="0" runat="server" ID="lblPrice"></asp:Label> </h1></td></tr></table> 
    </div>

 <input type="button" validationgroup="RVTbl_Personal" id="btnrequest" runat="server" value="ثبت درخواست"  onclick="showlight();" onserverclick="BtnDailyReg_Click"/>

<%-- <input type="button" validationgroup="RVTbl_Personal" id="btngetprice" runat="server" value="ثبت درخواست"  onclick="showlight();" onserverclick="BtnDailyReg_Click"/>--%>

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
    <div>کاربر گرامی لطفا قبل از خرید کد رهگیری را یادداشت نمایید</div>
    <div> 
        <table>
            <tr><td> کد رهگیری شما جهت خرید:

                </td>
                <td>
                    <asp:Label runat="server" ID="lblRahCode" ></asp:Label>
                </td>
            </tr>
        </table>
   <div>
        <asp:Button runat="server" ID="BtnDailyReg" CssClass="btn-success " OnClick="BtnDailyReg_Click"  Text="پرداخت"/>
    </div>

    </div >
   
   
    </div>
    </div>
      
    
  <input type="hidden"  id="LightBox" runat="server" /> 
  <input type="hidden"  id="InputAllDay" runat="server" value="0"/> 
  <input type="hidden"  id="tareff" runat="server" value="0"/> 

    <script type="text/javascript">

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
        $("#datepickerr").click(function () {
           //   LoadPrice();
        });
        function LoadPrice() {
            var p = $('.t2').val() + $('.ta').val() + $('.t3').val() + "IR" + $('.t16').val()
            //alert(p);
            //'11د111IR16';
            //16چ33322
            $.ajax({
                type: "POST",
                url: "/New/News.aspx/GetPrice",
                data: "{ 'pelak':'" + p + "','repid':'" + 3 + "'}", //PUT DATA HERE
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    document.getElementById('<%= lblPrice.ClientID%>').innerHTML = msg.d;
                    $('<%= lblPrice.ClientID%>').attr("value", msg.d);

                 
                    //                     alert(msg.d);
                    // $('#inputmodat').val(d);
                    //$("#inputmodat").text(msg.d);
                    //                 document.getElementById('ViewDate').value = msg.d;
                }
            })
        }

        var flag = 0;
        var c = 0;


        function calprice() {
            //$("tr .trprice").each(function () {
            //    { c += 1; }
            //})
            c = $('#myTable >tbody >tr').length;
            c -= 1;
            //alert(c);
                document.getElementById('<%= lblPrice.ClientID%>').innerHTML = (c) * document.getElementById('<%= tareff.ClientID%>').value;
            $('<%= lblPrice.ClientID%>').attr("value", (c) * document.getElementById('<%= tareff.ClientID%>').value);
            c = 0;
        }
            function   norepeatDay(value) {
               
               $("td.selectDate").each(function () {
                   if ($(this).html() == value) {
                       flag = 1;
                       alert('روز تکراری مجاز نمیباشد.');
                   }
                   else
                       flag = 0;
               });
               if (flag == 1)
                return false;
            else
                return true;
            }


            function adddate() {
                // $('#txtalld').val($('#datepickerr').val());
                if ($('#datepickerr').val() == "") {
                    alert('یک روز را انتخاب نمایید و روی دکمه انتخاب روز کلیک نمایید');
                    return;
                }
                norepeatDay($('#datepickerr').val());
                if (flag == 0) {
                    
                    $('#myTable > tbody:last-child').append("<tr class='trprice'><td  class='ADelete' onclick='delrow(this);'><td class='selectDate'>" + $('#datepickerr').val() + "</td></tr>");
                }
                flag = 0;
                checktable();
                calprice();
            }

            function checktable() {
                $('#myTable').css('visibility', 'inherit');
                if ($('#myTable tr').length == 1)
                { $('#myTable').css('visibility', 'hidden'); }
                else
                { $('#myTable').css('visibility', 'inherit'); }


            }
            function delrow( obj) {
               // alert('');
                obj.closest('tr').remove();
                  //  tr.css("background-color", "#FF3700");
                  //  tr.fadeOut(400, function () {
                        //tr.remove();
                   // });
                //return false;
                checktable();
                calprice();
                }  
            
            $(function () {
 
                //$('#datepickerr').datepicker({
                //    changeMonth: true,
                //    dateFormat: 'yy/mm/dd',
                //    autoSize: true
                //})
                $("#datepickerr").persianDatepicker({
                    theme: 'dark'
                });


                checktable();

            });
            checktable();



        function showlight() {
           // document.getElementById('<%= LightBox.ClientID %>').value = "1";
            //  $document.getElementById('rr').value = $('#datepickid div').datepicker('getDates');
            var txt;
            $("td.selectDate").each(function () {
                // 'this' is now the raw td DOM element
                txt += $(this).html() + ',';
            });
            //alert(txt);
                document.getElementById('<%= InputAllDay.ClientID %>').value = txt;
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
   

        //$(document).ready(function () {


        //    $('#txtdate').datepicker({
        //     multidate: true,
        //    multidateSeparator: ",",
        //    //daysOfWeekDisabled: "4",
        //    //format: "dd/mm/yyyy",
        //    //startDate: "25/11/2015",
        //    //endDate: "30/11/2015",
        //});
        //    $('#datepickid div').datepicker({
        //        multidate: true,
        //        multidateSeparator: ",",

        //        todayHighlight: true
        //    }).on('changeDate', function (e) {
        //        //$('#s1').text($('#datepickid div').datepicker('method', show));
        //        //$('#dt_due').val($('#dt_due').val() + ',' + e.format('dd/mm/yyyy'))
        //        //var textday=$('#dt_due').val();
        //        //var daycout =textday.split(",");
        //        //$('#s1').text(((daycout.length) - 1) * 100);
        //    });


        //});
    </script>


</asp:Content>
