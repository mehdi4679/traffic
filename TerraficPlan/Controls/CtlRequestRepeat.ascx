<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlRequestRepeat.ascx.cs" Inherits="TerraficPlan.Controls.CtlRequestRepeat" %>
    <div >
     <asp:Label ID="LblParamRequestRepeatID"  Visible="false" runat="server" ></asp:Label> 
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
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.RequestRepeatID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
<asp:TemplateField HeaderText="ویرایش">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.RequestRepeatID")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
   <asp:BoundField DataField="RequestRepeatID"  HeaderText="ش فرآیند:"   SortExpression="RequestRepeatID" />
   <asp:BoundField DataField="RequestID"  HeaderText="درخواست:"   SortExpression="RequestID" />
   <asp:BoundField DataField="RepeatTypeID"  HeaderText="نوع تکرار:"   SortExpression="RepeatTypeID" />
   <asp:BoundField DataField="RepeatDate"  HeaderText="تاریخ تکرار"   SortExpression="RepeatDate" />
   <asp:BoundField DataField="YearMonthSeasonID"  HeaderText="سالانه فصلی ماهانه"   SortExpression="YearMonthSeasonID" />
             </Columns>
</asp:GridView>
        </div>

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
<table>
<tr runat="server" id="TrPrimery" ><td>ش فرآیند:</td><td><asp:textbox Visible="false"   runat="server" ID="TXTRequestRepeatID" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>درخواست:</td><td><asp:textbox runat="server" ID="TXTRequestID" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>نوع تکرار:</td><td><asp:textbox runat="server" ID="TXTRepeatTypeID" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>تاریخ تکرار</td><td><asp:textbox runat="server" ID="TXTRepeatDate" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr><td>سالانه فصلی ماهانه</td><td><asp:dropdownlist runat="server" ID="DDYearMonthSeasonID" ></asp:dropdownlist></td><td></td><td>
</td><td></td></tr>
</table>
              <div >
              <asp:Button runat="server" Text="افزودن"  ID="BtnInsert" SkinID="btnInsert" 
                      Visible="false"   ValidationGroup="RVTbl_RequestRepeat" />
             <asp:Button runat="server"  Text="ویرایش" ID="BtnUpdate" SkinID="btnOk" 
                      Visible="false" ValidationGroup="RVTbl_RequestRepeat"  />
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

