<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="AfterPurches.aspx.cs" Inherits="TerraficPlan.New.AfterPurches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label runat="server" ID="txtResult"></asp:Label>
    <asp:Label runat="server" ID="lblPricde" Visible="false"></asp:Label>
 
    <asp:Label runat="server" Text="3116" ID="lblEpayID" Visible="false"></asp:Label>

    <br /><br />
     
      <a onclick="printDiv('dContent');" href="#">
  
        <fieldset> 
           پرینتــــ <img src="/App_Themes/Theme1/Images/print.png" style=" margin-top:-40px">
              
        </fieldset>
 
    </a>
          <asp:Button runat="server" ID="btnSendWS" Text="ارسال پلاک به سرور" OnClick="btnSendWS_Click" Visible="false" />


    <div id="dContent">
         <%--<fieldset>
             <legend>توجه:</legend>
             <ul class="list-unstyled spaced2">
                <li>
                <i class="ace-icon fa fa-circle green"></i>
               ثبت نام هیجگونه حق و حقوقی را ایجاد نمیکند
                </li>
                <li>
                <i class="ace-icon fa fa-circle green"></i>
              در صورتی که تا 72 ساعت به مرکز مراجعه نشود این درخواست حذف میگردد.
                </li>

                 </ul>
             
         </fieldset>--%>
    <center>
    <fieldset style="padding:30px;margin: 30px">
         

        <legend>عملیات خرید</legend>
        <table>
            <tr>
                <td>
                    شماره خرید:
                </td>
                <td>
 <asp:label runat="server" id="lblRacCode" ></asp:label>
                </td>
            </tr>
            <tr><td>شماره رسید دیجیتالی</td>
                <td>
                    <asp:Label runat="server" ID="lblref"></asp:Label>
                </td>

            </tr>
        <tr>
            <td>وضعیت:</td>
            <td>   <asp:Label runat="server" ID="lblstats"></asp:Label></td>
        </tr>
            <tr>
                <td>
                    تاریخ خرید:
                </td>
              <td><%--  <%# DateConvert.m2sh( DateTime.Now.ToString())+" "+DateTime.Now.Hour+":"+DateTime.Now.Minute %>--%></td>

            </tr>
            <tr><td>کد رهگیری:</td>
                <td><asp:Label runat="server" ID="lblRahCode" ></asp:Label></td>
            </tr>
        </table>
       
     


    <asp:Label runat="server" ID="lblmsg" ></asp:Label>
        <br />
        <div>
             

        </div>
    </fieldset>
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