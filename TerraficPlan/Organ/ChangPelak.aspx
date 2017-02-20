<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="ChangPelak.aspx.cs" Inherits="TerraficPlan.Organ.ChangPelak" %>

<%@ Register Src="~/Controls/CtlChangePelak.ascx" TagPrefix="uc1" TagName="CtlChangePelak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <uc1:CtlChangePelak runat="server" id="CtlChangePelak" />
</asp:Content>
