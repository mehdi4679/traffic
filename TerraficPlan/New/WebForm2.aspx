<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="TerraficPlan.New.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="/New/0/ui.core.css" rel="stylesheet" />
<link type="text/css" href="/New/0/ui.theme.css" rel="stylesheet" />
<link type="text/css" href="/New/0/ui.datepicker.css" rel="stylesheet" />
<script type="text/javascript" src="/New/0/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/New/0/ui.core.min.js"></script>
<script type="text/javascript" src="/New/0/ui.datepicker-cc.min.js"></script>
<script type="text/javascript" src="/New/0/calendar.min.js"></script>
<script type="text/javascript" src="/New/0/ui.datepicker-cc-fa.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" id="datepicker1" class="hasDatepicker">
    </div>
    </form>

    <script>
        $('#datepicker1').datepicker();
    </script>
</body>
</html>
