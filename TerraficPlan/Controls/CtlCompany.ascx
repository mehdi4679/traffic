<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlCompany.ascx.cs" Inherits="TerraficPlan.Controls.CtlCompany" %>
    <div >
     <asp:Label ID="LblParamCompanyID"  Visible="false" runat="server" Text="0" ></asp:Label> 
        <asp:Label ID="LblRequestID" Visible="false" runat="server"  ></asp:Label>
   <asp:Button runat="server" ID="btnInsertLight"  text="افزودن"  SkinID="btnInsert" OnClick="btnInsertLight_Click" />
    <asp:Button runat="server"  ID="btnSerachLight"  Text="جستجو" SkinID="hbtn-search-r" OnClick="btnSerachLight_Click"/>  
    </div >
    <div >
          <asp:Label runat="server" ID="LblNumber"  Font-Bold="True"  ForeColor="Green"  ></asp:Label> 
    </div >
 <asp:GridView ID="GridView1" CssClass="gv"  runat="server" AutoGenerateColumns="False" AllowPaging="True"  
               AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" >
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.CompanyID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
<asp:TemplateField HeaderText="ویرایش">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.CompanyID")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
   <asp:BoundField DataField="CompanyID"  HeaderText="ش فرآیند"   SortExpression="CompanyID" />
   <asp:BoundField DataField="CompanyTypeIDName"  HeaderText="نوع شرکت:"   SortExpression="CompanyTypeIDName" />
   <asp:BoundField DataField="CompanyName"  HeaderText="نام شرکت:"   SortExpression="CompanyName" />
 <asp:TemplateField  HeaderText="نام نماینده:"   SortExpression="ResponsivePerson"><ItemTemplate><a href='<%#"/Manage/PersonManage.aspx?PId="+Eval("PersonalID").ToString() %>' ><%# Eval("ResponsivePerson").ToString() %></a></ItemTemplate></asp:TemplateField>
   <asp:BoundField DataField="ManageName"  HeaderText="نام مدیر شرکت:"   SortExpression="ManageName" />
   <asp:BoundField DataField="CompanyTel"  HeaderText="تلفن شرکت:"   SortExpression="CompanyTel" />
   <asp:BoundField DataField="ComapnyAdress"  HeaderText="آدرس شرکت:"   SortExpression="ComapnyAdress" />
<%--   <asp:BoundField DataField="RepresentativeName"  HeaderText="نام نماینده شرکت:"   SortExpression="RepresentativeName" />
   <asp:BoundField DataField="RepresentativeMobile"  HeaderText="تلفن همراه نماینده:"   SortExpression="RepresentativeMobile" />--%>
   <asp:BoundField DataField="CompanyEmail"  HeaderText="ایمیل شرکت:"   SortExpression="CompanyEmail" />
<%--   <asp:BoundField DataField="RepresentativeTel"  HeaderText="تلفن ثابت نماینده:"   SortExpression="RepresentativeTel" />--%>
             </Columns>
</asp:GridView>
       
 <div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
<table>
<tr runat="server" id="TrPrimery"  visible="false"><td>ش فرآیند</td><td><asp:textbox Visible="false"   runat="server" ID="TXTCompanyID" ></asp:textbox></td><td></td><td>
</td><td></td></tr>
    <tr><td>نوع&nbsp; :</td><td>
        <asp:DropDownList runat="server" ID="ddCompanyTypeID" >
         </asp:DropDownList>

                            </td><td></td><td>
</td><td>                 </td></tr>
    <tr><td>نام&nbsp; :</td><td><asp:textbox runat="server" ID="TXTCompanyName" ></asp:textbox></td><td></td><td>
</td><td>                 <asp:RequiredFieldValidator ID="RqCompanyName" runat="server" 
                  ControlToValidate="txtCompanyName" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr>
    
    
    <tr  ><td>نام مدیر نهاد/موسسه/شرکت:</td><td><asp:textbox runat="server" ID="TXTManageName" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVManageName" runat="server" 
                  ControlToValidate="txtManageName" Display="Dynamic" ErrorMessage="فقط حروف وارد کنید" 
                  ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqManageName" runat="server" 
                  ControlToValidate="txtManageName" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td>تلفن&nbsp; :</td><td><asp:textbox runat="server" ID="TXTCompanyTel" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVCompanyTel" runat="server" 
                  ControlToValidate="txtCompanyTel" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqCompanyTel" runat="server" 
                  ControlToValidate="txtCompanyTel" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td>آدرس&nbsp; :</td><td><asp:textbox runat="server" ID="TXTComapnyAdress" TextMode="MultiLine" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr runat="server" id="recc" visible="false" ><td>نام نماینده&nbsp; :</td><td><asp:textbox runat="server" ID="TXTRepresentativeName" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVRepresentativeName" runat="server" 
                  ControlToValidate="txtRepresentativeName" Display="Dynamic" ErrorMessage="فقط حروف فارسی کنید" 
                  ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqRepresentativeName" runat="server" 
                  ControlToValidate="txtRepresentativeName" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr runat="server" id="reeee" visible="false" ><td>تلفن همراه نماینده:</td><td><asp:textbox runat="server" ID="TXTRepresentativeMobile" ></asp:textbox></td><td></td><td>             
                         <asp:RegularExpressionValidator ID="RVRepresentativeMobile" runat="server" 
                  ControlToValidate="txtRepresentativeMobile" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqRepresentativeMobile" runat="server" 
                  ControlToValidate="txtRepresentativeMobile" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td>ایمیل&nbsp; :</td><td><asp:textbox runat="server" ID="TXTCompanyEmail" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr runat="server" id="kkhkh" visible="false" ><td>تلفن ثابت نماینده:</td><td><asp:textbox runat="server" ID="TXTRepresentativeTel" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVRepresentativeTel" runat="server" 
                  ControlToValidate="txtRepresentativeTel" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td></td></tr>
</table>
              <div >
              <asp:Button runat="server" Text="ثبت"  ID="BtnInsert" SkinID="btnInsert"  
                        ValidationGroup="RVTbl_Company" OnClick="BtnInsert_Click" />
              <asp:Button runat="server"  Text="جستجو" ID="BtnSerach" SkinID="hbtn-search-r" OnClick="BtnSerach_Click"  Visible="false" />   
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

