<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="PersonManage.aspx.cs" Inherits="TerraficPlan.Manage.PersonManage" %>

<%@ Register Src="~/Controls/CtlPerson.ascx" TagPrefix="uc1" TagName="CtlPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <uc1:CtlPerson runat="server" id="CtlPerson" />
</asp:Content>
