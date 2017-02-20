<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewFreeMaster.master" AutoEventWireup="true" CodeBehind="sharj.aspx.cs" Inherits="TerraficPlan.New.sharj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

        <table>

    
<tr>
                <td><span class="clrequir">*</span>کد ملی:</td>
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
                <td> <span class="clrequir">*</span> تلفن همراه:  </td>
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
                 <td>مبلغ شارژ:</td>
                 <td><asp:TextBox runat="server" ID="txtPrice" CssClass="price"></asp:TextBox></td>
             </tr>
</table>
    <asp:Button runat="server" ID="btnShajBank" Text="ورود به صفحه بانک و انجام شارژ" OnClick="btnShajBank_Click" />


    
</asp:Content>
