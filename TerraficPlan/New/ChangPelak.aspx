<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="ChangPelak.aspx.cs" Inherits="TerraficPlan.New.ChangPelak" %>

<%@ Register Src="~/Controls/CtlChangePelak.ascx" TagPrefix="uc1" TagName="CtlChangePelak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <uc1:CtlChangePelak runat="server" ID="CtlChangePelak" />
</asp:Content>
