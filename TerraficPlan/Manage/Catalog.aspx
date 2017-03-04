<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="TerraficPlan.Manage.Catalog" %>
<%--<%@ Register src="../Controls/CtlCatalog.ascx" tagname="CtlCatalog" tagprefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <fieldset>

        <legend>سال پیش فرض</legend>    <br />
    <br />
        <asp:DropDownList runat="server" ID="ddDefauleYear" ></asp:DropDownList>
        <asp:Button runat="server" ID="btnSaveYear" Text="ذخیره" OnClick="btnSaveYear_Click" />
    <br />
        <asp:Label runat="server" ID="lblmsg" Text=""></asp:Label>
    </fieldset>

    <div align="cenetr" style="text-align:center;width:80%"></div> 
    <asp:GridView ID="GridView1" Width="100%" CssClass="gv" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
               AllowSorting="True" >
<Columns>
    <asp:TemplateField HeaderText="عرضه طرح">
            <ItemTemplate>
                        <a id="AEdit" class='<%# Eval("ISSelect").ToString()=="0"||Eval("ISSelect")==null||Eval("ISSelect").ToString()==""  ? "AFalse":"ATrue" %>' href='<%# DataBinder.Eval(Container,"DataItem.CAID")+"$"+Eval("ISSelect")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
   <asp:BoundField DataField="CAID"  HeaderText="ش فرآیند"   SortExpression="CaID" />
   <asp:BoundField DataField="CatalogName"  HeaderText="نوع تکرار"   SortExpression="CatalogName" />
   <asp:BoundField DataField="CatalogValue"  HeaderText="مقدار"   SortExpression="CatalogValue" />
 


    </Columns>

     </asp:GridView>
</asp:Content>
