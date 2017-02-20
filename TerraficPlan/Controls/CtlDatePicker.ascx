<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlDatePicker.ascx.cs" Inherits="TerraficPlan.Controls.CtlDatePicker" %>
<input type="text" id="txtDate" runat="server"  />

<script type="text/javascript" >

    $("#<%= txtDate.ClientID %>").persianDatepicker({
        theme: 'dark'
    });

    </script>
   