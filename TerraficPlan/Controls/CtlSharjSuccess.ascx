<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlSharjSuccess.ascx.cs" Inherits="TerraficPlan.Controls.CtlSharjSuccess" %>
<%--    <fieldset id="fdiscount" runat="server" visible="false">
        <legend>توجه:</legend>
        کاربر گرامی شما خرید با تخفیف را انتخاب نموده اید که پس از بررسی مدارک تخفیف به شما پیامک ارسال میگردد
        <br />
        لازم به ذکر است پس از دریافت پیامک و ورود به سایت از قسمت "پرداخت" بالای صفحه میتوانید اقدام به پرداخت نمایید.
    </fieldset>--%>
       
    <div style="width:200px;position:relative;float:right">
  <a onclick="printDiv('dContent');" href="#">
  

        <fieldset > 
           پرینتــــ <img src="/App_Themes/Theme1/Images/print.png" style=" margin-top:-40px">
 
        </fieldset>


    </a> 
        <asp:Label runat="server" ID="lblRID" Text="0" Visible="false"></asp:Label>
                   <div style="width:250px;position:relative;float:right">
            </div>
        </div>
    <div id="dContent">
        <center>
    <table>
    <tr>
    <td>  
          <asp:Label runat="server" ID="lblmobileeee" Text="" Visible="false"></asp:Label>
          <asp:Label runat="server" ID="lblreqtraficID" Text="0" Visible="false"></asp:Label>

        <img width="100px" height="80px" alt="" src="/app_Themes/Theme1/Css/images/arm.jpg" /><br />
        &nbsp; 
        

    </td>
    <td>
   
                                   &nbsp;</td>
    <td width="1%">
   
                                   &nbsp;</td>
    <td>
   
                                   <asp:Label ID="lblresid" runat="server" 
            Text="رسید شارژ " Font-Bold="True" Font-Italic="False" Font-Size="X-Large" 
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

        <div id="DCode" dir=rtl style="width:280px;border-style:solid;border-radius:5px;border-width:5px;border-color:lightgreen">
<table >
<tr  >
<td style="font-family: B titr,tahoma; font-size: large;">کد رهگیری:</td>
<td style="font-family: B titr,tahoma; font-size: large;">
                          
                                    <asp:Label ID="lblRahgiri" runat="server" Font-Bold="True" CssClass=p></asp:Label></td>
</tr>
</table>
            </div>
<hr />
<table>
    <tr><td>&nbsp;</td><td>&nbsp;</td></tr>

    <tr><td>کد ملی متقاضی</td><td><asp:Label runat="server" ID="lblNationalCode"></asp:Label></td></tr>
    <tr><td>موبایل متقاضی</td><td><asp:Label runat="server" ID="LblMobile"></asp:Label></td></tr>

    <tr><td>مبلغ به ریال:</td><td><asp:Label runat="server" ID="lblAmount" CssClass="priceclass"></asp:Label>

         
                     </td></tr>
     <tr style="visibility:hidden"><td>قیمت قابل پرداخت</td><td><asp:Label runat="server" ID="lblPrice" CssClass="priceclass"></asp:Label></td></tr>

</table>
         
          
                    
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