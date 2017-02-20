<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="TerraficPlan.Public.ChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <table style="float:right;width:auto">
        <tr>
            <td>کلمه عبور فعلی</td>
            <td><asp:TextBox runat="server" ID="txtPassWordNow" TextMode="Password"></asp:TextBox></td>
            <td>                    <asp:RequiredFieldValidator ID="RqLastName0" runat="server"
                        ControlToValidate="txtPassWordNow" ErrorMessage="لطفا پر کنید"
                        ValidationGroup="RVTbl_Personal" ForeColor="Red">
                    </asp:RequiredFieldValidator></td>
        </tr>
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
            <td>                    <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="txtpassRe" ControlToCompare="txtpass"  Operator="Equal"  ErrorMessage="تکرار کلمه عبور یکسان نمیباشد" ValidationGroup="RVTbl_Personal"></asp:CompareValidator>
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
</asp:Content>
 