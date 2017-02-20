<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="PriceList.aspx.cs" Inherits="TerraficPlan.Manage.PriceList" %>
<%@ Register src="../Controls/CtlDiscountPrice.ascx" tagname="CtlDiscountPrice" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
  <uc1:CtlDiscountPrice ID="CtlDiscountPrice1" runat="server" />
    <%-- <asp:DropDownList runat="server" ID="ddDiscountType"></asp:DropDownList>
    <asp:GridView runat="server" ID="grid1">
        <Columns>
            <asp:BoundField  DataField="CompanyID"  HeaderText="ش فرآیند"   SortExpression="CompanyID" />
            <asp:BoundField  DataField="CompanyID"  HeaderText="نوع "   SortExpression="CompanyID" />
        </Columns>
    </asp:GridView>--%>
</asp:Content>
