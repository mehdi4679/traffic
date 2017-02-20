<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="CPR.aspx.cs" Inherits="TerraficPlan.New.CPR" %>
<%@ Register Src="~/Controls/CtlPelakChangHistory.ascx" TagPrefix="uc1" TagName="CtlPelakChangHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <uc1:CtlPelakChangHistory runat="server" id="CtlPelakChangHistory" />

</asp:Content>
