<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlRequestView.ascx.cs" Inherits="TerraficPlan.Controls.CtlRequestView" %>
<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>


<asp:Label runat="server" ID="lblPersonID" Visible="false" Text="0"></asp:Label>
     <table>
        <tr><td>پلاک:</td><td>
            <uc1:CtlPelak runat="server" ID="CtlPelak" />
        </td></tr>
        <tr><td colspan="10" > <asp:Button runat="server" ID="btnS" OnClick="btnS_Click" Text="جستجوی پلاک" /></td></tr>
    </table>
<asp:GridView CssClass="gv" runat="server" AutoGenerateColumns="false" ID="GridView1" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
     PageSize="10"            >
                <Columns>
                <asp:TemplateField HeaderText="ردیف">
                <ItemTemplate>
                <asp:Label runat="server" ID="RowNum" Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="حذف"> 
                <ItemTemplate>
                <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="ADel_ServerClick" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
                <asp:TemplateField HeaderText="تغییر پلاک"> 
                <ItemTemplate>
                <a id="ADeldd" class="APelak"  href='<%# "/Organ/changPelak.aspx?Rahcode="+ Eval("TrackingCode") +"&RequestTrafficID="+ DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="تغییر پلاک"      runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >


   <asp:BoundField DataField="RequestTrafficID"  HeaderText="ش فرآیند"   SortExpression="RequestTrafficID" />

   <asp:BoundField DataField="OwnerTypeName"  HeaderText="مالکیت"   SortExpression="OwnerTypeName" />
   <asp:BoundField DataField="DiscountTypeName"  HeaderText="نوع تخفیف"   SortExpression="DiscountTypeName" />

   <asp:BoundField DataField="carname"  HeaderText="خودرو"   SortExpression="carname" />
   <asp:BoundField DataField="CompanyIDName"  HeaderText="شرکت"   SortExpression="CompanyIDName" />
   <asp:BoundField DataField="PersonalIDName"  HeaderText="فرد درخواست دهنده"   SortExpression="PersonalIDName" />
    <asp:BoundField DataField="SahmIDName"  HeaderText="سهمیه"   SortExpression="SahmIDName" />
      <asp:BoundField DataField="RequestStatusName"  HeaderText="نظر مرکز"   SortExpression="RequestStatusName" />
      <asp:BoundField DataField="RequestStatusComment"  HeaderText="توضیحات مرکز"   SortExpression="RequestStatusComment" />
           
                </Columns>
                   </asp:GridView>