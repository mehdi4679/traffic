<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="ReportAfterPay.aspx.cs" Inherits="TerraficPlan.report.ReportAfterPay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
     <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            font-size: small;
        }
        .auto-style4 {
            width: 66px;
            height: 51px;
        }
        .auto-style5 {
            width: 66px;
            height: 51px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
               <input type="button" id="btnPrint" value="چاپ" style="width:150px; position:center; font-family: Titr; font-size: x-large; font-weight: bold;" onclick="javascript:printDiv('printablediv')" />
   

    <div id="printablediv" runat="server">
       
        </div>
<script type='text/javascript'>
 var originalContents;
 function printDiv() {

        if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
            var DocumentContainer = document.getElementById('printablediv');
            var WindowObject = window.open('', "PrintWindow", "width=800,height=750left=0,top=0,toolbar=0,scrollbars=0,status=0");
            WindowObject.document.writeln(DocumentContainer.innerHTML);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
        }
        else {
            originalContents = document.body.innerHTML;
            var printable = document.getElementById('printablediv');
            document.body.innerHTML = printable.innerHTML;
            printCoupon();
        }
    }

    function printCoupon() {
        window.print();
        endPrintCoupon();
    }

    function endPrintCoupon() {
        document.body.innerHTML = originalContents;
        document.getElementById('printablediv').scrollIntoView(true);
        location.reload();
    }
 </script>
</asp:Content>
