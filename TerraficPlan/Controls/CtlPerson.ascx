<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlPerson.ascx.cs" Inherits="TerraficPlan.Controls.CtlPerson" %>
    <div >
     <asp:Label ID="LblParamPersonalID"  Visible="false" runat="server" Text="0" ></asp:Label> 
        <asp:Label ID="LBlPersonalPass"  Visible="false" runat="server"  Text="0" ></asp:Label>
    <asp:Button runat="server" ID="btnInsertLight"  text="افزودن"  SkinID="btnInsert" OnClick="btnInsertLight_Click"  />
    <asp:Button runat="server"  ID="btnSerachLight"  Text="جستجو" SkinID="hbtn-search-r" OnClick="btnSerachLight_Click"/> 
    </div >
    <div >
          <asp:Label runat="server" ID="LblNumber"  Font-Bold="True"  ForeColor="Green"  ></asp:Label> 
    </div >
 <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="gv"
               AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" PageSize="2">
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.PersonalID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
<asp:TemplateField HeaderText="ویرایش">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.PersonalID")%>' title="ویرایش" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
<asp:TemplateField HeaderText="کلمه عبور">
            <ItemTemplate>
                        <a id="sgrd" class="APass" href='<%# DataBinder.Eval(Container,"DataItem.PersonalID")%>' title="کلمه عبور" onserverclick="PassItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>

<asp:TemplateField HeaderText="اختصاص شرکت">
            <ItemTemplate>
                        <a id="Acompany" class="Acredit" href='<%# DataBinder.Eval(Container,"DataItem.PersonalID")%>' title="اختصاص شرکت" onserverclick="Acompany_ServerClick" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>

   <asp:BoundField DataField="PersonalID"  HeaderText="ش فرآیند:"   SortExpression="PersonalID" />
   <asp:BoundField DataField="NationalCode"  HeaderText="کد ملی:"   SortExpression="NationalCode" />
   <asp:BoundField DataField="FirstName"  HeaderText="نام:"   SortExpression="FirstName" />
   <asp:BoundField DataField="LastName"  HeaderText="نام خانوادگی:"   SortExpression="LastName" />
   <asp:BoundField DataField="PersonalAdress"  HeaderText="آدرس:"   SortExpression="PersonalAdress" />
   <asp:BoundField DataField="PostiCode"  HeaderText="کد پستی:"   SortExpression="PostiCode" />
   <asp:BoundField DataField="PersonalTel"  HeaderText="تلفن ثابت:"   SortExpression="PersonalTel" />
   <asp:BoundField DataField="PersonalMobile"  HeaderText="تلفن همراه:"   SortExpression="PersonalMobile" />
   <asp:BoundField DataField="JobName"  HeaderText="شغل:"   SortExpression="JobName" />
   <asp:BoundField DataField="Email"  HeaderText="ایمیل"   SortExpression="Email" />
    <asp:TemplateField     SortExpression="CompanyName" HeaderText="شرکت"><ItemTemplate><a href='<%#"/Manage/CompanyMange.aspx?cid="+Eval("CompanyID").ToString() %>'><%#Eval("CompanyName").ToString() %></a></ItemTemplate></asp:TemplateField>
 
             </Columns>
</asp:GridView>
        

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
<table>
            <tr>
                <td colspan="5">توجه :کد ملی شما به منزله نام کاربری جهت ورود به سایت میباشد.</td>
            </tr>
            <tr>
                <td class="auto-style1"><span class="clrequir">*</span>کد ملی:</td>
                <td>
                    <asp:TextBox runat="server" ID="TXTNationalCode" data-rel="tooltip" data-placement="left" title="فقط عدد و بدون خط تیره" placeholder="فقط عدد و بدون خط تیره"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RVNationalCode" runat="server"
                        ControlToValidate="txtNationalCode" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید"
                        ValidationExpression="^[+]?\d*$" SetFocusOnError="True"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TXTNationalCode"
                        Display="Dynamic" ErrorMessage="کد ملی نامعتبر است" ClientValidationFunction="checkMelliCode"
                        SetFocusOnError="True" ValidateEmptyText="false" ValidationGroup="RFV" ForeColor="Red"
                        Width="128px"></asp:CustomValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RqNationalCode" runat="server"  ControlToValidate="txtNationalCode" ErrorMessage="لطفا پر کنید" ValidationGroup="RVTbl_Personal" ForeColor="Red">  </asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1"><span class="clrequir">*</span>
                    نام:</td>
                <td>
                    <asp:TextBox runat="server" data-rel="tooltip" title="فقط حروف فارسی وارد کنید" ID="TXTFirstName"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RVFirstName" runat="server"
                        ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="فقط حروف فارسی وارد کنید"
                        ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RqFirstName" runat="server"
                        ControlToValidate="txtFirstName" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red">
                    </asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style1"><span class="clrequir">*</span>
                     نام خانوادگی:</td>
                <td>
                    <asp:TextBox runat="server" ID="TXTLastName" data-rel="tooltip" title="فقط حروف فارسی وارد کنید"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RVLastName" runat="server"
                        ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="فقط حروف فارسی وارد کنید"
                        ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <%--<asp:RequiredFieldValidator ID="RqLastName" runat="server"
                        ControlToValidate="txtLastName" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red">
                    </asp:RequiredFieldValidator>--%></td>
            </tr>
            <tr runat="server" id="trttt" visible="false">
                <td class="auto-style1">نوع مجوز تخفیف</td>
                <td>
                   <asp:DropDownList runat="server" ID="ddDiscountTypeUser"></asp:DropDownList></td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">ایمیل</td>
                <td>
                    <asp:TextBox runat="server" ID="TXTEmail"  data-rel="tooltip" title="فقط حروف انگلیسی وارد کنید" ></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="validateEmail"    ValidationGroup="RVTbl_Personal"
  runat="server" ErrorMessage="ایمیل اشتباه است."
  ControlToValidate="TXTEmail" 
  ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
             
            <tr runat="server" visible="false" id="trrepass">
                <td class="auto-style1"><span class="clrequir">*</span> تکرار کلمه عبور   </td>
                <td>
                    <asp:TextBox runat="server" ID="txtrepass"  TextMode="Password"></asp:TextBox></td>
                <td>&nbsp;</td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="txtrepass" ControlToCompare="txtpass"  Operator="Equal"  ErrorMessage="تکرار کلمه عبور یکسان نمیباشد" ValidationGroup="RVTbl_Personal"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            
<tr>
                <td class="auto-style1"> <span class="clrequir">*</span> تلفن همراه:  </td>
                <td>
                    <asp:TextBox runat="server" ID="TXTPersonalMobile" MaxLength="11" data-rel="tooltip" title="شماره موبایل را 11 رقمی و صحیح وارد نمایید"></asp:TextBox></td>
                <td></td>
                <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"    ValidationGroup="RVTbl_Personal" 
                     ControlToValidate="TXTPersonalMobile" Display="Dynamic"  
                     ErrorMessage="شماره موبایل را 11 رقمی و صحیح وارد نمایید" ValidationExpression="^\d{11}$">    
                </asp:RegularExpressionValidator>
                    
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server"
                        ControlToValidate="TXTPersonalMobile" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red">
                    </asp:RequiredFieldValidator> </td>
            </tr>
            <tr>
                <td class="auto-style1">آدرس:</td>
                <td>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="TXTPersonalAdress" data-rel="tooltip" title="آدرس محل سکونت"></asp:TextBox></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">کد پستی:</td>
                <td>
                    <asp:TextBox runat="server" ID="TXTPostiCode" data-rel="tooltip" title="وارد کردن کدپستی برای متقاضیان تخفیف اجباری است"></asp:TextBox></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">تلفن ثابت:</td>
                <td>
                    <asp:TextBox runat="server" ID="TXTPersonalTel" data-rel="tooltip" title="فقط عدد وارد نمایید"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="RVJobName0" runat="server"
                        ControlToValidate="TXTPersonalTel" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید"
                       ValidationExpression="^[+]?\d*$" SetFocusOnError="True"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr runat="server" visible="false">
                <td class="auto-style1">شغل:</td>
                <td>
                    <asp:TextBox runat="server" ID="TXTJobName"></asp:TextBox></td>
                <td></td>
                <td>&nbsp;</td>
                <td></td>
            </tr>
            </table>
              <div >
              <asp:Button runat="server" Text="ثبت"  ID="BtnInsert" SkinID="btnInsert" 
                      Visible="false"   ValidationGroup="RVTbl_Personal" OnClick="BtnInsert_Click" />
              
             <asp:Button runat="server"  Text="جستجو" ID="BtnSerach" SkinID="hbtn-search-r"  Visible="false" OnClick="BtnSerach_Click1" />   
            </div>
        <div>
            <asp:Label runat="server" ID="LblMsg" ></asp:Label>
        </div>
        </div>

    <div id="lightinsert2" class="Lightbox" >
 <table style="float:right;width:auto">
 
        <tr>
            <td>کلمه عبور جدید</td>
            <td><asp:TextBox runat="server" ID="txtPass" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"   ValidationGroup="RVTbl_Personal"    
ErrorMessage="کلمه عبور بایستی بین 4 تا 10 کاراکتر و اعداد و حروف انگلیسی باشد"
ControlToValidate="txtPass"    
ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,10}$" />
            </td>
        </tr>
        <tr>
            <td>تکرار کلمه عبور جدبد</td>
            <td><asp:TextBox runat="server" ID="txtpassRe"  TextMode="Password"></asp:TextBox> </td>
            <td>                    <asp:CompareValidator ID="CompareValidator2" runat="server" ForeColor="Red" ControlToValidate="txtpassRe" ControlToCompare="txtpass"  Operator="Equal"  ErrorMessage="تکرار کلمه عبور یکسان نمیباشد" ValidationGroup="RVTbl_Personal"></asp:CompareValidator>
</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server" ID="btn" OnClick="btn_Click"  Text="تغییر کلمه عبور"/>

            </td>
        </tr>
    </table>
    <div style="float:right;width:auto" > 
        <img src="/App_Themes/Theme1/Css/Images/passs.png" />
    </div>
        </div>

        <div id="lightinsert3" class="Lightbox" >
            <table>
                <tr><td>شرکت:</td><td><asp:DropDownList runat="server" ID="ddCompany"></asp:DropDownList></td></tr>
            </table>
            <asp:Button runat="server" ID="btnAddCompany" Text="اختصاص شرکت" OnClick="btnAddCompany_Click"/>
            </div>
        </div>
 <input type="hidden"  id="LightBox" runat="server" /> 
 <input type="hidden"  id="LightBox2" runat="server" /> 
 <input type="hidden"  id="LightBox3" runat="server" /> 


<script type="text/javascript">
      if (document.getElementById('<%= LightBox.ClientID %>').value == "1") {
            setTimeout(f, 0);
        }
        if (document.getElementById('<%= LightBox2.ClientID %>').value == "1") {
            setTimeout(f2, 0);
        }
        if (document.getElementById('<%= LightBox3.ClientID %>').value == "1") {
            setTimeout(f3, 0);
        }
    function g() {
        scripthelper.CloseLightBox("lightinsert");
        scripthelper.CloseLightBox("lightinsert2");
        scripthelper.CloseLightBox("lightinsert3");

    }
    function f() {
        scripthelper.ShowLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv");
    }
    function f2() {
        scripthelper.ShowLightBox("lightinsert2", '<%= LightBox2.ClientID %>', "lightboxdiv");
    }
    function f3() {
        scripthelper.ShowLightBox("lightinsert3", '<%= LightBox3.ClientID %>', "lightboxdiv");
    }


    function back() {
        scripthelper.CloseLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv")
        scripthelper.CloseLightBox("lightinsert2", '<%= LightBox2.ClientID %>', "lightboxdiv")
        scripthelper.CloseLightBox("lightinsert3", '<%= LightBox3.ClientID %>', "lightboxdiv")

    }   
   </script>

