<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlPelakChangHistory.ascx.cs" Inherits="TerraficPlan.Controls.CtlPelakChangHistory" %>
<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>

 
<asp:Label runat="server" ID="lblRequestID" Text="0" Visible="false" ></asp:Label>
<asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="gv"
               AllowSorting="True" >
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<%--<asp:TemplateField HeaderText="حذف" Visible="false"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.PelakChangeID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >--%>
    <asp:BoundField DataField="PelakChangeID"  HeaderText="ش فرآیند"   SortExpression="PelakChangeID" />
    <asp:TemplateField HeaderText="خودرو اولیه"   SortExpression="FromCarIDName" ><ItemTemplate>
        <uc1:CtlPelak runat="server" ID="CtlPelak" Enable="false" Text='<%#Eval("FromCarIDPelak").ToString() %>' />  <%#Eval("FromCarIDName") %>
    </ItemTemplate></asp:TemplateField>

    <asp:TemplateField HeaderText="خودرو ثانویه"   SortExpression="ToCarIDName" ><ItemTemplate>
        <uc1:CtlPelak runat="server" ID="CtlPelak2" Enable="false" Text='<%#Eval("ToCarIDPelak").ToString() %>' /> <%#Eval("ToCarIDName") %>
    </ItemTemplate></asp:TemplateField>
 
   <asp:BoundField DataField="CommentUser"  HeaderText="توضیحات"   SortExpression="CommentUser" />
        <asp:BoundField DataField="sysDATEfa"  HeaderText="تاریخ ثبت"   SortExpression="sysDATEfa" />
       <asp:BoundField DataField="RequestUserName"  HeaderText="کاربر متقاضی"   SortExpression="RequestUserName" />

   <asp:BoundField DataField="NazarIDName"  HeaderText="نظر مرکز"   SortExpression="NazarIDName" />
 
   <asp:BoundField DataField="NazarDatefa"  HeaderText="تاریخ پاسخ مرکز"   SortExpression="NazarDatefa" />
   <asp:BoundField DataField="CommentNazar"  HeaderText="توضیحات مرکز"   SortExpression="CommentNazar" />


             </Columns>
</asp:GridView>
