<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlRequestDiscount.ascx.cs" Inherits="TerraficPlan.Controls.CtlRequestDiscount" %>
    <div >
     <asp:Label ID="LblParamDisCountRequestID"  Visible="false" runat="server" ></asp:Label> 
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
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.DisCountRequestID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
<asp:TemplateField HeaderText="ویرایش">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.DisCountRequestID")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
   <asp:BoundField DataField="DisCountRequestID"  HeaderText="ش فرآیند"   SortExpression="DisCountRequestID" />
   <asp:BoundField DataField="RequestID"  HeaderText="شماره درخواست"   SortExpression="RequestID" />
   <asp:BoundField DataField="DiscountCode"  HeaderText="کد تخفیف"   SortExpression="DiscountCode" />
   <asp:BoundField DataField="Adress"  HeaderText="آدرس نهاد/آژانس/شرکت"   SortExpression="Adress" />
   <asp:BoundField DataField="DiscountComment"  HeaderText="توضیحات    "   SortExpression="DiscountComment" />
             </Columns>
</asp:GridView>
        </div>

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
<table>
<tr runat="server" id="TrPrimery" ><td>ش فرآیند</td><td><asp:textbox Visible="false"   runat="server" ID="TXTDisCountRequestID" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>شماره درخواست</td><td><asp:textbox runat="server" ID="TXTRequestID" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>کد تخفیف</td><td><asp:textbox runat="server" ID="TXTDiscountCode" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>آدرس نهاد/آژانس/شرکت</td><td><asp:textbox runat="server" ID="TXTAdress" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>توضیحات    </td><td><asp:textbox runat="server" ID="TXTDiscountComment" ></asp:textbox></td><td></td><td>
</td><td></td></tr>
</table>
              <div >
              <asp:Button runat="server" Text="افزودن"  ID="BtnInsert" SkinID="btnInsert" 
                      Visible="false"   ValidationGroup="RVTbl_RequestDiscount" />
             <asp:Button runat="server"  Text="ویرایش" ID="BtnUpdate" SkinID="btnOk" 
                      Visible="false" ValidationGroup="RVTbl_RequestDiscount"  />
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

