<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="sharj.aspx.cs" Inherits="TerraficPlan.Organ.sharj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label runat="server" ID="LBLPersonlID" Text="0" Visible="false"></asp:Label>
    <table>
             <tr>
                 <td>مبلغ شارژ:</td>
                 <td><asp:TextBox runat="server" ID="txtPrice" CssClass="price"></asp:TextBox></td>
             </tr>  
        <tr>
            <td>
                توضیحات:
            </td>
            <td><asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine"></asp:TextBox></td>
        </tr>       
    </table>
   
                <asp:Button runat="server" ID="btnShajBank" Text="پرداختــــ" OnClick="btnShajBank_Click" />

    


<asp:GridView CssClass="gv" ID="GridView1"  runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
               AllowSorting="True" >
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.SharjID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
 
   <asp:BoundField DataField="SharjID"  HeaderText="ش فرآیند"   SortExpression="SharjID" />
   <asp:BoundField DataField="PersonalIDName"  HeaderText="نام متقاضی"   SortExpression="PersonalIDName" />
   <asp:BoundField DataField="ShariPrice" ItemStyle-CssClass="price"  HeaderText="مبلغ شارژ"   SortExpression="ShariPrice" />
   <asp:BoundField DataField="ShajComment"  HeaderText="توضیحات"   SortExpression="ShajComment" />
<%--    <asp:TemplateField   HeaderText="تاریخ شارژ"   SortExpression="SharjDate" ><ItemTemplate> <%# TerraficPlanBLL.DateConvert.m2sh(  Eval("SharjDate").ToString()).ToString()  %></ItemTemplate></asp:TemplateField>--%>
    <asp:BoundField DataField="SharjDatefa"  HeaderText="تاریخ شارژ"   SortExpression="SharjDatefa" /> 
   <asp:BoundField DataField="ISExpireNAme"  HeaderText="منقضی شده؟"   SortExpression="ISExpireNAme" />
   <asp:BoundField DataField="OrderStatusName"  HeaderText="وضعیت خرید"   SortExpression="OrderStatusName" />
<%--   <asp:BoundField DataField="RahCode"  HeaderText="کد رهگیری"   SortExpression="RahCode" />--%>
             </Columns>
</asp:GridView>
    
</asp:Content>
