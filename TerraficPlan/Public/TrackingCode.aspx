<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="TrackingCode.aspx.cs" Inherits="TerraficPlan.Public.TrackingCode" %>
<%@ Register src="../Controls/CtlPelak.ascx" tagname="CtlPelak" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <center>
    <fieldset runat="server" id="fWhithoutDiscount" visible="false"><legend> پرداخت الکترونیک</legend><center>
     توجه کاربر گرامی قبل از ورود به صفحه پرداخت کد رهگیری را یادداشت نمایید .
     <br />
    مبلغ قابل پرداخت:   <asp:Label runat="server" ID="lblAmount" CssClass="priceclass"></asp:Label> میباشد.
           <asp:Button runat="server" ID="BTNpAY" Text="پرداختــــــــ"  OnClick="BTNpAY_Click"/>
             </center>
        </fieldset>

    <fieldset id="fdiscount" runat="server" visible="false">
        <legend>توجه:</legend>
        کاربر گرامی شما خرید با تخفیف را انتخاب نموده اید که پس از بررسی مدارک تخفیف به شما پیامک ارسال میگردد
        <br />
        لازم به ذکر است پس از دریافت پیامک و ورود به سایت از قسمت "پرداخت" بالای صفحه میتوانید اقدام به پرداخت نمایید.
    </fieldset>
        </center>
  <a onclick="printDiv('dContent');" href="#">
  
        <fieldset> 
           پرینتــــ <img src="/App_Themes/Theme1/Images/print.png" style=" margin-top:-40px">
              
        </fieldset>
 

    </a>
    <div id="dContent">
        <center>
    <table>
    <tr>
    <td>  
          <asp:Label runat="server" ID="lblmobileeee" Text="" Visible="false"></asp:Label>
        <img width="100px" height="80px" alt="" src="/app_Themes/Theme1/Css/images/arm.jpg" /><br />
        &nbsp; 
        

    </td>
    <td>
   
                                   &nbsp;</td>
    <td width="1%">
   
                                   &nbsp;</td>
    <td>
   
                                   <asp:Label ID="lblresid" runat="server" 
            Text="پرداخت آنلاین ترافیک " Font-Bold="True" Font-Italic="False" Font-Size="X-Large" 
                                       Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                                       Font-Names="B titr,tahoma"  ></asp:Label>    </td>
    <td>
   
                                   &nbsp;</td>
    <td>
   
                                   &nbsp;</td>
    <td>
      <table>
                                       <tr>
                                  <td align="right" dir="ltr" 
                                        style="font-size: small; font-weight: bold;font-family:mitrabold,Tahoma;">
                                         <asp:Label ID="lbldate" runat="server" Font-Size="Large" ForeColor="Red" 
                                            Font-Names="B Titr"></asp:Label>  
                                       </td>
                                </tr>
                                        <tr>
                                            <td align="right" dir="rtl" 
                                                style="font-size: small; font-weight: bold;font-family:mitrabold,Tahoma;">
                                                ساعت:<asp:Label ID="lbltime" runat="server" Font-Size="Large" ForeColor="Red" 
                                                    Font-Names="B Titr"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>

    </td>
    </tr>
    </table>

        <div id="DCode" dir=rtl style="border-style:solid;border-radius:5px;border-width:5px;border-color:lightgreen">
<table >
<tr  >
<td style="font-family: B titr,tahoma; font-size: large;">کد رهگیری</td>
<td style="font-family: B titr,tahoma; font-size: large;">
                          
                                    <asp:Label ID="lblRahgiri" runat="server" Font-Bold="True" CssClass=p></asp:Label></td>
</tr>
</table>
            </div>
<hr />
<table>
    <tr><td>مشخصات خودرو انتخابی</td><td><asp:Label runat="server" ID="lblcar"></asp:Label></td></tr>
    <tr><td>پلاک</td><td>
        <uc1:CtlPelak ID="txtpelak" runat="server" Enable="false"/>
        </td></tr>
    <tr><td> مشخصات مالک </td><td><asp:Label runat="server" ID="lblOwnerName"></asp:Label></td></tr>
    <tr><td> مشخصات متقاضی </td><td><asp:Label runat="server" ID="lblregname"></asp:Label></td></tr>

    <tr><td>کد ملی متقاضی</td><td><asp:Label runat="server" ID="lblNationalCode"></asp:Label></td></tr>
    <tr><td>موبایل متقاضی</td><td><asp:Label runat="server" ID="LblMobile"></asp:Label></td></tr>

    <tr><td>وضعیت تخفیف</td><td><asp:Label runat="server" ID="lblDiscount"></asp:Label></td></tr>
     <tr style="visibility:hidden"><td>قیمت قابل پرداخت</td><td><asp:Label runat="server" ID="lblPrice" CssClass="priceclass"></asp:Label></td></tr>

</table>
        <fieldset runat="server" id="rrepeat" visible="false"><legend>ایام مورد تقاضا جهت خرید طرح ترافیک</legend>
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="6" > 
        <ItemTemplate>
        <div style="width:150px;">
        <table><tr><td><input type="checkbox"  checked="checked" /></td><td> <%#Eval("title").ToString() %></td><td></td></tr></table>
                                              
        </div>
        </ItemTemplate>
        </asp:DataList>
        </fieldset>
          
                    
                            <hr />
                     <br />
             
                                    <div class="formCotainer">
                <%--<div class="section round">
                    <h1 class="caption round">کد رهگیری</h1>
                    <div class="body active">
                    <table dir=rtl >
                    <tr>
                     
                    <td>   </td>
                    </tr>
                    </table>
                    <span style="  font-weight:bold ; font-size:large  ; direction:rtl ">
</span></div>
                </div>--%>
                <div class="footer">
                 
                </div>
            </div>
                            </center>
    </div>

    <script language="javascript" type="text/javascript">
        // printDiv('dContent');
        var t = document.getElementById('dContent').innerHTML;
        //var printwindow = window.open('', '', 'fullScreen=no');
        //printwindow.document.write('ggggggggggggggggg');
        //printwindow.onload = printwindow.print;


        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;

            return false;
        }
    </script>

</asp:Content>
