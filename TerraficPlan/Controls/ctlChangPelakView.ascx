<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlChangPelakView.ascx.cs" Inherits="TerraficPlan.Controls.ctlChangPelakView" %>
<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>

<div >
     
    <asp:Label runat="server" id="LblPersonalID" Visible="false" Text="0"></asp:Label>
    <asp:Label runat="server" id="Lbl_RequestTrafficID" Visible="false" Text="0"></asp:Label>
<asp:Label runat="server" id="Lbl_PelakChangeID" Visible="false" Text="0"></asp:Label>
<asp:Label runat="server" id="lbl_IsManage" Visible="false" Text="false"></asp:Label>
         <table>
        <tr><td>پلاک:</td><td>
            <uc1:CtlPelak runat="server" ID="CtlPelak" />
        </td></tr>
        <tr><td colspan="10" > <asp:Button runat="server" ID="btnS" OnClick="btnS_Click" Text="جستجوی پلاک" /></td></tr>
    </table>

    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="gv"
               AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="حذف" Visible="false"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.PelakChangeID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
 <asp:TemplateField HeaderText="نظر مرکز"  > 
               <ItemTemplate>
                        <a id="ADel2" class="ADoc"  href='<%# DataBinder.Eval(Container,"DataItem.PelakChangeID")%>' title="حذف"   onserverclick="NazarItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
   <asp:BoundField DataField="PelakChangeID"  HeaderText="ش فرآیند"   SortExpression="PelakChangeID" />
    <asp:TemplateField HeaderText="خودرو اولیه"   SortExpression="FromCarIDName" ><ItemTemplate>
        <uc1:CtlPelak runat="server" ID="CtlPelak" Enable="false" Text='<%#Eval("FromCarIDPelak").ToString() %>' />  <%#Eval("FromCarIDName") %>
    </ItemTemplate></asp:TemplateField>

    <asp:TemplateField HeaderText="خودرو ثانویه"   SortExpression="ToCarIDName" ><ItemTemplate>
        <uc1:CtlPelak runat="server" ID="CtlPelak2" Enable="false" Text='<%#Eval("ToCarIDPelak").ToString() %>' /> <%#Eval("ToCarIDName") %>
    </ItemTemplate></asp:TemplateField>
<%--   <asp:BoundField DataField="FromCarIDName"  HeaderText="خودرو اولیه"   SortExpression="FromCarIDName" />--%>
<%--   <asp:BoundField DataField="ToCarIDName"  HeaderText="خودرو ثانویه"   SortExpression="ToCarIDName" />--%>

   <asp:BoundField DataField="CommentUser"  HeaderText="توضیحات"   SortExpression="CommentUser" />
<%--    <asp:TemplateField HeaderText="تاریخ ثبت"   SortExpression="sysDATE"><ItemTemplate><%= TerraficPlanBLL.DateConvert.m2sh( Eval("sysDATE").ToString()).ToString() %></ItemTemplate></asp:TemplateField>--%>
       <asp:BoundField DataField="sysDATEfa"  HeaderText="تاریخ ثبت"   SortExpression="sysDATEfa" />
       <asp:BoundField DataField="RequestUserName"  HeaderText="کاربر متقاضی"   SortExpression="RequestUserName" />

   <asp:BoundField DataField="NazarIDName"  HeaderText="نظر مرکز"   SortExpression="NazarIDName" />
<%--    <asp:TemplateField HeaderText="تاریخ پاسخ مرکز"   SortExpression="NazarDate"><ItemTemplate><%# TerraficPlanBLL.DateConvert.m2sh( Eval("NazarDate").ToString()).ToString() %></ItemTemplate></asp:TemplateField>--%>

   <asp:BoundField DataField="NazarDatefa"  HeaderText="تاریخ پاسخ مرکز"   SortExpression="NazarDatefa" />
   <asp:BoundField DataField="CommentNazar"  HeaderText="توضیحات مرکز"   SortExpression="CommentNazar" />


             </Columns>
</asp:GridView>
<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
    <table>
        <tr><td>نظر مرکز</td><td><asp:DropDownList runat="server" ID="ddNazarID"></asp:DropDownList></td></tr>
        <tr><td>توضیحات مرکز</td><td><asp:TextBox runat="server" TextMode="MultiLine" id="txtCommentNazar"></asp:TextBox></td></tr>
        <tr><td colspan="10"><asp:Button runat="server" ID="btnAddNazar" Text="نظر مــرکز" OnClick="btnAddNazar_Click"/></td></tr>
    </table>
    </div>
    </div>
    <input type="hidden"  id="LightBox" runat="server" /> 
<script type="text/javascript">
       if (document.getElementById('<%= LightBox.ClientID %>').value == "1") {
            setTimeout(f, 0);
        }
   
    function g() {
        scripthelper.CloseLightBox("lightinsert");
    }
    function f() {
        scripthelper.ShowLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv");
    }
    function back() {
        scripthelper.CloseLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv")
    }
   </script>
</div>