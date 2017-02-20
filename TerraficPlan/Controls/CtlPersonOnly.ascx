<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlPersonOnly.ascx.cs" Inherits="TerraficPlan.Controls.CtlPersonOnly" %>
<style type="text/css">
    .auto-style1 {
        width: 130px;
    }
</style>
<asp:Label runat="server" ID="lblPersonalID" Visible="false" Text="0"></asp:Label>
<div id="lightboxdivc" class=" ">
    <div id="lightinsertc" class=" ">
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
                    <asp:RequiredFieldValidator ID="RqLastName" runat="server"
                        ControlToValidate="txtLastName" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red">
                    </asp:RequiredFieldValidator></td>
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
            <tr runat="server" visible="false" id="trpass"  >
                <td class="auto-style1"> <span class="clrequir">*</span>
                    کلمه عبور 
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtpass" TextMode="Password"></asp:TextBox></td>
                <td>
                    &nbsp;</td>
                <td>
<asp:RequiredFieldValidator ID="RqLastName02" runat="server"
                        ControlToValidate="txtpass" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
                <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"   ValidationGroup="RVTbl_Personal"    
ErrorMessage="کلمه عبور بایستی بین 4 تا 10 کاراکتر و اعداد و حروف انگلیسی باشد"
ControlToValidate="txtpass"    
ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,10}$" />&nbsp;</td>
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
        <div>
            <asp:Button runat="server" Text="ثبت" ID="BtnInsert" SkinID="btnInsert" OnClick="BtnInsert_Click"
                ValidationGroup="RVTbl_Personal" />
            <asp:Label runat="server" ID="lblmsg"></asp:Label>
            <asp:Button runat="server" Text="جستجو" ID="BtnSerach" SkinID="hbtn-search-r" Visible="false" />
        </div>
        <div>
            <asp:Label runat="server" ID="lblupdatemomde" Text="false" Visible="false"></asp:Label>
             <asp:Label runat="server" ID="lblRedirect" Text="false" Visible="false"></asp:Label>
        </div>
    </div>
</div>
 
    <script type="text/javascript">
    function checkMelliCode(val, args) {
        var meli_code;
        meli_code = args.Value;
        if (meli_code.length == 10) {
            if ((meli_code == '0000000000') || (meli_code == '1111111111') || (meli_code == '2222222222') || (meli_code == '3333333333') || (meli_code == '4444444444') || (meli_code == '5555555555') || (meli_code == '6666666666') || (meli_code == '7777777777') || (meli_code == '8888888888') || meli_code == ('9999999999')) {
                alert("کد ملي صحيح نمي باشد");
                args.IsValid = false;
                return false;
            }
            c = parseInt(meli_code.charAt(9));
            n = (parseInt(meli_code.charAt(0)) * 10) + (parseInt(meli_code.charAt(1)) * 9) + (parseInt(meli_code.charAt(2)) * 8) + (parseInt(meli_code.charAt(3)) * 7) + (parseInt(meli_code.charAt(4)) * 6) + (parseInt(meli_code.charAt(5)) * 5) + (parseInt(meli_code.charAt(6)) * 4) + (parseInt(meli_code.charAt(7)) * 3) + (parseInt(meli_code.charAt(8)) * 2);
            r = n - parseInt(n / 11) * 11;
            if ((r == 0 && r == c) || (r == 1 && c == 1) || (r > 1 && c == 11 - r)) {
                args.IsValid = true;
            }
            else {
                alert("کد ملي صحيح نمي باشد");
                args.IsValid = false;
            }
        }
        else {
            alert("کد ملي صحيح نمي باشد");
            args.IsValid = false;
            return false;
        }
    }
           

 </script> 
 