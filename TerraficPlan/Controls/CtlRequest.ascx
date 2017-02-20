<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlRequest.ascx.cs" Inherits="TerraficPlan.Controls.CtlRequest" %>
    <div >
     <asp:Label ID="LblParamRequestTrafficID"  Visible="false" runat="server" ></asp:Label> 
    <asp:Button runat="server" ID="btnInsertLight"  text="افزودن"  SkinID="btnInsert"  />
    <asp:Button runat="server"  ID="btnSerachLight"  Text="جستجو" SkinID="hbtn-search-r"/> 
    </div >
    <div >
          <asp:Label runat="server" ID="LblNumber"  Font-Bold="True"  ForeColor="Green"  ></asp:Label> 
    </div >
 <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" AllowPaging="True"
               AllowSorting="True" >
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
<asp:TemplateField HeaderText="ویرایش">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
   <asp:BoundField DataField="RequestTrafficID"  HeaderText="ش فرآیند"   SortExpression="RequestTrafficID" />
   <asp:BoundField DataField="OwnerType"  HeaderText="نوع مالکیت:"   SortExpression="OwnerType" />
   <asp:BoundField DataField="DiscountType"  HeaderText="تخفیف"   SortExpression="DiscountType" />
   <asp:BoundField DataField="PersonalID"  HeaderText="فرد"   SortExpression="PersonalID" />
   <asp:BoundField DataField="CompanyID"  HeaderText="شرکت"   SortExpression="CompanyID" />
   <asp:BoundField DataField="CarID"  HeaderText="خودرو"   SortExpression="CarID" />
             </Columns>
</asp:GridView>
        

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
<table>
<tr runat="server" id="TrPrimery" ><td>ش فرآیند</td><td><asp:textbox Visible="false"   runat="server" ID="TXTRequestTrafficID" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>نوع مالکیت:</td><td><asp:dropdownlist runat="server" ID="DDOwnerType" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr><tr><td>تخفیف</td><td><asp:dropdownlist runat="server" ID="DDDiscountType" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr><tr><td>فرد</td><td><asp:dropdownlist runat="server" ID="DDPersonalID" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr><tr><td>شرکت</td><td><asp:dropdownlist runat="server" ID="DDCompanyID" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr><tr><td>خودرو</td><td><asp:textbox runat="server" ID="TXTCarID" ></asp:textbox></td><td></td><td>
</td><td></td></tr>
</table>
              <div >
              <asp:Button runat="server" Text="افزودن"  ID="BtnInsert" SkinID="btnInsert" 
                      Visible="false"   ValidationGroup="RVTbl_RequestTraffic" />
             <asp:Button runat="server"  Text="ویرایش" ID="BtnUpdate" SkinID="btnOk" 
                      Visible="false" ValidationGroup="RVTbl_RequestTraffic"  />
             <asp:Button runat="server"  Text="جستجو" ID="BtnSerach" SkinID="hbtn-search-r"  Visible="false" />   
            </div>
        <div>
            <asp:Label runat="server" ID="LblMsg" ></asp:Label>
        </div>
        </div>
        </div>
 <input type="hidden"  id="LightBox" runat="server" /> 
<script type="text/javascript">
    var requestinupdatePrm = Sys.WebForms.PageRequestManager.getInstance();
    requestinupdatePrm.add_pageLoaded(requestinupdatePageLoaded);
    function requestinupdatePageLoaded(sender, args) {
        if (document.getElementById('<%= LightBox.ClientID %>').value == "1") {
            setTimeout(f, 0);
        }
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

