<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="CompanyMange.aspx.cs" Inherits="TerraficPlan.Manage.CompanyMange" %>

<%@ Register Src="~/Controls/CtlCompany.ascx" TagPrefix="uc1" TagName="CtlCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <uc1:CtlCompany runat="server" id="CtlCompany" />
</asp:Content>
