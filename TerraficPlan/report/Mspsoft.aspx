<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mspsoft.aspx.cs" Inherits="Qr.Mspsoft"  ViewStateMode="Disabled" MaintainScrollPositionOnPostback="False" EnableViewState="False" %>

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

    <script  type="text/javascript">
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

          
        }
      
    </script>
     
    </body>
</html>
