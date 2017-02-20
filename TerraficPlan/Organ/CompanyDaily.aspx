<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="CompanyDaily.aspx.cs" Inherits="TerraficPlan.Organ.CompanyDaily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <table>
        <tr><td>خودرو:</td><td><asp:DropDownList runat="server" ID="ddCar"></asp:DropDownList></td></tr>
<%--        <tr><td>نوع:</td><td><asp:DropDownList runat="server" ID="ddmalektype"></asp:DropDownList></td>
            <td><asp:DropDownList runat="server" ID="ddmalektype2"></asp:DropDownList></td></tr>--%>
        <tr ><td>سهمیه:</td><td><asp:DropDownList runat="server" ID="ddsahmie"></asp:DropDownList></td></tr>

    </table>
    <asp:Button runat="server" ID="btnAdd" Text="ثبت درخواست" />

</asp:Content>
