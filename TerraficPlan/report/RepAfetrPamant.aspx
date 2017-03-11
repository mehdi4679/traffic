<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepAfetrPamant.aspx.cs" Inherits="TerraficPlan.report.RepAfetrPamant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
</head>
<body style="direction: rtl; font-family: tahoma;">
    <form id="form1" runat="server">

           <input type="button" id="btnPrint" value="چاپ" style="width:150px; position:center; font-family: Titr; font-size: x-large; font-weight: bold;" onclick="javascript:printDiv('printablediv')" />
   

    <div id="printablediv" runat="server">
       
        </div>
 </form>

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

     
    </body>
</html>
