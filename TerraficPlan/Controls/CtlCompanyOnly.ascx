<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlCompanyOnly.ascx.cs" Inherits="TerraficPlan.Controls.CtlCompanyOnly" %>
     <asp:Label ID="LblParamCompanyID"  Visible="false" runat="server" Text="0" ></asp:Label> 
        <asp:Label ID="LblRequestID" Visible="false" runat="server" Text="0" ></asp:Label>
<asp:Label ID="LBlPersonalID" Visible="false" runat="server" Text="0" ></asp:Label>
<table>
<tr runat="server" id="TrPrimery"  visible="false"><td>ش فرآیند</td><td><asp:textbox Visible="false"   runat="server" ID="TXTCompanyID" ></asp:textbox></td><td></td><td>
</td><td></td></tr>
        <tr><td>نوع&nbsp; :</td><td>
            <asp:DropDownList runat="server" ID="ddCompanyTypeID" >
       
        </asp:DropDownList>

                                </td><td></td><td>
</td><td>                 </td></tr>
    <tr><td><span class="clrequir">*</span> نام سازمان :</td><td><asp:textbox data-rel="tooltip" title="نام سازمان اجباری است" runat="server" ID="TXTCompanyName" ></asp:textbox></td><td></td><td>
</td><td>                 <asp:RequiredFieldValidator ID="RqCompanyName" runat="server" 
                  ControlToValidate="txtCompanyName" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td><span class="clrequir">*</span> نام مدیر نهاد/موسسه/سازمان :</td><td><asp:textbox data-rel="tooltip" title="فقط حروف فارسی" runat="server" ID="TXTManageName" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVManageName" runat="server" 
                  ControlToValidate="txtManageName" Display="Dynamic" ErrorMessage="فقط حروف وارد کنید" 
                  ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqManageName" runat="server" 
                  ControlToValidate="txtManageName" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td><span class="clrequir">*</span>  تلفن سازمان:</td><td><asp:textbox runat="server" data-rel="tooltip" title="تلفن را عددی و صحیح وارد نمایید" ID="TXTCompanyTel" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVCompanyTel" runat="server" 
                  ControlToValidate="txtCompanyTel" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqCompanyTel" runat="server" 
                  ControlToValidate="txtCompanyTel" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td><span class="clrequir">*</span>  آدرس سازمان:</td><td>
                     <asp:textbox runat="server" ID="TXTComapnyAdress" TextMode="MultiLine" data-rel="tooltip" title="آدرس سازمان" ></asp:textbox>
                     <asp:RequiredFieldValidator ID="RqRepresentativeName" runat="server" 
                  ControlToValidate="TXTComapnyAdress" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator>

                                                                                                                  </td><td></td><td>
</td><td></td></tr><tr runat="server" id="kjbkjk" visible="false"><td>نام نماینده سازمان:</td><td><asp:textbox runat="server" ID="TXTRepresentativeName" data-rel="tooltip" title="فقط حروف فارسی وارد کنید"></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVRepresentativeName" runat="server" 
                  ControlToValidate="txtRepresentativeName" Display="Dynamic" ErrorMessage="فقط حروف فارسی کنید" 
                  ValidationExpression="^([ اآبپتثجچحیخدذرزژسشطظعغفقکكگلمنوهيئضصي]\s?)*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 </td></tr><tr runat="server" id="kjkxsc" visible="false" ><td><span class="clrequir">*</span>  تلفن همراه نماینده:</td><td><asp:textbox   data-rel="tooltip" title="موبایل را عددی و صحیح وارد نمایید" runat="server" ID="TXTRepresentativeMobile" ></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVRepresentativeMobile" runat="server" 
                  ControlToValidate="txtRepresentativeMobile" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td>                 <asp:RequiredFieldValidator ID="RqRepresentativeMobile" runat="server" 
                  ControlToValidate="txtRepresentativeMobile" ErrorMessage="لطفا پر کنید" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red">
                 </asp:RequiredFieldValidator></td></tr><tr><td>ایمیل سازمان:</td><td><asp:textbox runat="server" ID="TXTCompanyEmail"  data-rel="tooltip" title="حروف انگلیسی وارد نمایید" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr runat="server" visible="false"><td>تلفن ثابت نماینده:</td><td><asp:textbox runat="server" ID="TXTRepresentativeTel"    data-rel="tooltip" title="فقط عدد وارد کنید"></asp:textbox></td><td></td><td>                 <asp:RegularExpressionValidator ID="RVRepresentativeTel" runat="server" 
                  ControlToValidate="txtRepresentativeTel" Display="Dynamic" ErrorMessage="فقط عدد وارد کنید" 
                  ValidationExpression="^[+]?\d*$" SetFocusOnError="True" 
                  ValidationGroup="RVTbl_Company" ForeColor="Red"></asp:RegularExpressionValidator>
</td><td></td></tr>
</table>
              <div >
              <asp:Button runat="server" Text="ثبت"  ID="BtnInsert" SkinID="btnInsert" 
                        ValidationGroup="RVTbl_Company" OnClick="BtnInsert_Click" />
            </div>