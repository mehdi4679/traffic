<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="TerraficPlan.Organ.Car" %>
<%@ Register src="~/Controls/CtlCar.ascx" tagname="CtlCar" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <uc1:CtlCar ID="CtlCar1" runat="server" />

</asp:Content>
