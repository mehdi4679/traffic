<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="ChangPelak2.aspx.cs" Inherits="TerraficPlan.Organ.ChangPelak2" %>

<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>
<%@ Register Src="~/Controls/CtlRequestView.ascx" TagPrefix="uc1" TagName="CtlRequestView" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     
    <uc1:CtlRequestView runat="server" ID="CtlRequestView" />
</asp:Content>
