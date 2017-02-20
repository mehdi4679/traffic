<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="RegPerson.aspx.cs" Inherits="TerraficPlan.Public.RegPerson" %>
<%@ Register src="~/Controls/CtlPersonOnly.ascx" tagname="CtlPerson" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
  <style>
       tr {
   height:47px;
 }

  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <uc1:CtlPerson ID="CtlPerson1" runat="server" />
</asp:Content>
