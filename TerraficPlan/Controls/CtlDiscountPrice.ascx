<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlDiscountPrice.ascx.cs" Inherits="TerraficPlan.Controls.CtlDiscountPrice" %>
    <div >
     <asp:Label ID="LblParamDiscountPriceID"  Visible="false" runat="server" Text="0"></asp:Label> 
    <asp:Button runat="server" ID="btnInsertLight"  text="افزودن" Visible="false"  SkinID="btnInsert" OnClick="btnInsertLight_Click"  />
    </div >
    <div >
          <asp:Label runat="server" ID="LblNumber"  Font-Bold="True"  ForeColor="Green"  ></asp:Label> 
    </div >
<center>
    <div style="width:80%">
 <asp:GridView CssClass="gv" ID="GridView1" Width="100%" PageSize="15"  runat="server" AutoGenerateColumns="False" AllowPaging="True" OnSorting="GridView1_Sorting" OnPageIndexChanging="GridView1_PageIndexChanging"
               AllowSorting="True" >
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<%--<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.DiscountPriceID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >--%>
<asp:TemplateField HeaderText="ویرایش">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.DiscountPriceID")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
   <asp:BoundField DataField="DiscountPriceID"  HeaderText="ش فرآیند"   SortExpression="DiscountPriceID" />
   <asp:BoundField DataField="RepeatTypeIDName"  HeaderText="نوع تکرار"   SortExpression="RepeatTypeIDName" />
   <asp:BoundField DataField="DiscountIDNAme"  HeaderText="نوع تخفیف"   SortExpression="DiscountIDName" />
   <asp:BoundField DataField="Price"  HeaderText="مبلغ تخفیف "   SortExpression="Price" ItemStyle-CssClass="priceclass" />
             </Columns>
</asp:GridView>
        </div>

</center>

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
<table>
<tr runat="server" id="TrPrimery" visible="false" ><td>ش فرآیند</td><td><asp:textbox Visible="false"   runat="server" ID="TXTDiscountPriceID" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>نوع تکرار</td><td><asp:dropdownlist runat="server" ID="DDRepeatTypeID" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr><tr><td>نوع تخفیف</td><td><asp:dropdownlist runat="server" ID="DDDiscountID" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr><tr><td>مبلغ تخفیف </td><td><asp:textbox runat="server" ID="TXTPrice" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVPrice" runat="server" 
                  ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_DiscountPrice" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqPrice" runat="server" 
                  ControlToValidate="txtPrice" ErrorMessage="لطفا پر کنبد" 
                  ValidationGroup="RVTbl_DiscountPrice" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr>
</table>
              <div >
              <asp:Button runat="server" Text="ثبت"  ID="BtnInsert" SkinID="btnInsert" OnClick="BtnInsert_Click"
                        ValidationGroup="RVTbl_DiscountPrice" />
            </div>
        <div>
            <asp:Label runat="server" ID="LblMsg" ></asp:Label>
        </div>
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

