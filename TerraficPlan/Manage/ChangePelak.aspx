<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="ChangePelak.aspx.cs" Inherits="TerraficPlan.Manage.ChangePelak" %>
<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>
<%@ Register Src="~/Controls/ctlChangPelakView.ascx" TagPrefix="uc1" TagName="ctlChangPelakView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <fieldset style="padding:30px"><legend>لیست درخواست های تغییر پلاک</legend>
    <uc1:ctlChangPelakView runat="server" ID="ctlChangPelakView" />

    </fieldset>
</asp:Content>
