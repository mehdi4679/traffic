﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="AfterPurches.aspx.cs" Inherits="TerraficPlan.Organ.AfterPurches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div runat="server" id="derror" visible="false">
    <asp:Label runat="server" ID="txtResult"></asp:Label>
    <asp:Label runat="server" ID="lblPricde" Visible="false"></asp:Label>
 

    <br /><br />
     
      <a onclick="printDiv('dContent');" href="#">
  
        <fieldset> 
           پرینتــــ <img src="/App_Themes/Theme1/Images/print.png" style=" margin-top:-40px">
              
        </fieldset>
 

    </a>

    <asp:Button runat="server" Text="sendpelak" id="btn" OnClick="btn_Click" Visible="false"  />
    <asp:TextBox runat="server" ID="txtepid"   Text="0" Visible="false" ></asp:TextBox>
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
              <td>
                  <asp:Label runat="server" ID="lblDatePay"></asp:Label>
                  <%--  <%# DateConvert.m2sh( DateTime.Now.ToString())+" "+DateTime.Now.Hour+":"+DateTime.Now.Minute %>--%></td>

            </tr>
            <tr><td>کد رهگیری:</td>
                <td><asp:Label runat="server" ID="lblRahCode" ></asp:Label></td>
            </tr>
        </table>
       
<%--     <a href="sharj.aspx">مشاهده شارژهای خریداری شده</a>--%>
         

    <asp:Label runat="server" ID="lblmsg" ></asp:Label>
        <br />
        <div>
             

        </div>
    </fieldset>
</center>
</div>
    </div>

        <div id="lkjljnjkn" >
        <iframe runat="server" id="if1" visible="false" width="100%" height="600px"  ></iframe>

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
