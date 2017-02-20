<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="sahm.aspx.cs" Inherits="TerraficPlan.Manage.sahm" %>
<%@ Register src="~/Controls/CtlSahm.ascx" tagname="CtlSahm" tagprefix="uc1" %>

<asp:Content ID="Content114" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
 
<asp:Content ID="Content356" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   
     
      <uc1:CtlSahm ID="CtlSahm1" runat="server" />

       
   
     
</asp:Content>
