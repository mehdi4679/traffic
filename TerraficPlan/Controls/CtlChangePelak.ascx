<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlChangePelak.ascx.cs" Inherits="TerraficPlan.Controls.CtlChangePelak" %>
<%@ Register Src="~/Controls/CtlPelak.ascx" TagPrefix="uc1" TagName="CtlPelak" %>
<%@ Register Src="~/Controls/CtlCar.ascx" TagPrefix="uc1" TagName="CtlCar" %>
        <asp:Label ID="LblCarid1"  Visible="false" runat="server" Text="0" ></asp:Label>
        <asp:Label ID="LblCarid2"  Visible="false" runat="server" Text="0" ></asp:Label>
        <asp:Label ID="lblchangComment"  Visible="false" runat="server" Text="0" ></asp:Label>
        <asp:Label ID="Lbl_RequestTrafficID"  Visible="false" runat="server" Text="0" ></asp:Label>

<asp:Label ID="LblPersonalID"  Visible="false" runat="server" Text="0" ></asp:Label>

 
<div runat="server" id="drahcode" style="padding:20px"> <table><tr><td>کد رهگیری</td>
    <td>
 <asp:Label ID="Lbl_RahCode"  runat="server" Text="0" ></asp:Label>
                                   </td></tr></table>       
</div>
<fieldset style="padding:20px"><legend>پلاک فعلی</legend>
<table>
    <tr><td>خودرو جاری&nbsp; </td><td>
        <uc1:CtlPelak runat="server" ID="CtlPelak1" Enable="false"/>
    </td></tr>
    <tr><td><asp:Label runat="server" ID="lblRequestTrafficName"></asp:Label></td></tr>
<%--    <tr><td>پلاک جدید</td><td>
        <uc1:CtlPelak runat="server" ID="CtlPelak2" />

                          </td></tr>--%>
    <tr><td>علت تغییر پلاک</td><td><asp:TextBox runat="server" TextMode="MultiLine" ID="txtCommentUser"></asp:TextBox></td></tr>
<%--    <tr><td colspan="10"><asp:Button runat="server" ID="btnCheck" OnClick="btnCheck_Click" Text="بررسی پلاکها" /></td></tr>--%>

</table>

</fieldset >
<div   >
    <uc1:CtlCar runat="server" ID="CtlCar"    />
</div>




