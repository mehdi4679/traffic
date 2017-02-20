<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlSahm.ascx.cs" Inherits="TerraficPlan.Controls.CtlSahm" %>
    <div >
     <asp:Label ID="LblParamSahmID"  Visible="false" runat="server" Text="0"></asp:Label> 
    <input type="button"  ID="btnInsertLight"  value="افزودن"  class="btnInsert" onclick="openlight();" />
<%--    <asp:Button runat="server"  ID="btnSerachLight"  Text="جستجو" SkinID="hbtn-search-r"/> --%>
    </div >
    <div >
          <asp:Label runat="server" ID="LblNumber"  Font-Bold="True"  ForeColor="Green"  ></asp:Label> 
    </div >
 <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="gv"
               AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" >
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.SahmID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
<asp:TemplateField HeaderText="ویرایش">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.SahmID")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
   <asp:BoundField DataField="SahmID"  HeaderText="ش فرآیند"   SortExpression="SahmID" />
   <asp:BoundField DataField="CompanyName"  HeaderText="نام سازمان,نهاد,ارگان"   SortExpression="CompanyName" />
<%--   <asp:BoundField DataField="DiscountTypeIDName"  HeaderText="نوع تخفیف"   SortExpression="DiscountTypeIDName" />--%>
   <asp:BoundField DataField="sahmNumbre"  HeaderText="تعداد خودرو سهمیه"   SortExpression="sahmNumbre" />
   <asp:BoundField DataField="DiscountPersent"  HeaderText="درصد تخفیف"   SortExpression="DiscountPersent" />
   <asp:BoundField DataField="Comment"  HeaderText="توضیحات"   SortExpression="Comment" />
   <asp:BoundField DataField="RegDateFa"  HeaderText="تاریخ ثبت"   SortExpression="RegDateFa" />
   <asp:BoundField DataField="fullnamereg"  HeaderText="کاربر ثبت کننده"   SortExpression="fullnamereg" />
   <asp:BoundField DataField="Year"  HeaderText="سال سهمیه"   SortExpression="Year" />
             </Columns>
</asp:GridView>
       

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
<table>
<tr runat="server" id="TrPrimery" visible="false" ><td>ش فرآیند</td><td><asp:textbox Visible="false"   runat="server" ID="TXTSahmID" ></asp:textbox></td><td></td><td>
</td><td></td></tr>
    

    <tr runat="server" visible="false"> <td>نوع تخفیف</td><td><asp:dropdownlist runat="server" ID="DDDiscountTypeID" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr>
        <tr><td>نام سازمان,نهاد,ارگان</td><td><asp:dropdownlist runat="server" ID="DDCompanyID" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr>
    <tr><td>تعداد خودرو سهمیه</td><td><asp:textbox runat="server" ID="TXTsahmNumbre" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVsahmNumbre" runat="server" 
                  ControlToValidate="txtsahmNumbre" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Sahm" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqsahmNumbre" runat="server" 
                  ControlToValidate="txtsahmNumbre" ErrorMessage="لطفا پر کنبد" 
                  ValidationGroup="RVTbl_Sahm" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td>درصد تخفیف</td><td><asp:textbox runat="server" ID="TXTDiscountPersent" ></asp:textbox>%</td><td></td><td>                 <asp:RegularExpressionValidator ID="RVDiscountPersent" runat="server" 
                  ControlToValidate="txtDiscountPersent" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Sahm" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqDiscountPersent" runat="server" 
                  ControlToValidate="txtDiscountPersent" ErrorMessage="لطفا پر کنبد" 
                  ValidationGroup="RVTbl_Sahm" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td>توضیحات</td><td><asp:textbox TextMode="MultiLine" runat="server" ID="TXTComment" ></asp:textbox></td><td></td><td>
</td><td></td></tr> 
    <tr><td>سال سهمیه</td><td>
        <asp:DropDownList runat="server" ID="TXTYear"    >
            <asp:ListItem>1393</asp:ListItem>
            <asp:ListItem Selected="True">1394</asp:ListItem>
            <asp:ListItem>1395</asp:ListItem>
            <asp:ListItem>1396</asp:ListItem>
            <asp:ListItem></asp:ListItem>

                              </asp:DropDownList></td><td></td><td>
        <asp:RequiredFieldValidator ID="RqDiscountPersent0" runat="server" 
                  ControlToValidate="TXTYear" ErrorMessage="لطفا پر کنبد" 
                  ValidationGroup="RVTbl_Sahm" ForeColor="Red">
                 </asp:RequiredFieldValidator>
</td><td></td></tr>
</table>
              <div >
              <asp:Button runat="server" Text="ثبت"  ID="BtnInsert" SkinID="btnInsert" OnClick="BtnInsert_Click"
                      ValidationGroup="RVTbl_Sahm" />
          
             <asp:Button runat="server" OnClick="BtnSerach_Click1"  Text="جستجو" ID="BtnSerach" SkinID="hbtn-search-r"  Visible="false" />   
            </div>
        <div>
            <asp:Label runat="server" ID="LblMsg" ></asp:Label>
        </div>
        </div>
        </div>
 <input type="hidden"  id="LightBox" runat="server" /> 
<script type="text/javascript">
    function openlight() {
        document.getElementById('<%= LightBox.ClientID %>').value = "1";
        f();
    }
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

