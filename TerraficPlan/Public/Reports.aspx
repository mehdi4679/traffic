<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TerraficPlan.Public.Reports" %>
 <%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table>
        <tr>
            <td>از تاریخ:</td>
            <td><asp:TextBox runat="server" ID="txtFromDate" Text="1394/01/01"></asp:TextBox></td>
        </tr>
        <tr>
            <td>تا تاریخ</td>
            <td><asp:TextBox runat="server" ID="txtToDate" Text="1394/01/01"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="10">
                <asp:Button runat="server" ID="btn" Text="پرینتـــــــ" OnClick="btn_Click"/>
                 <asp:Button runat="server" ID="btn1" Text="خروجی اکسل" OnClick="btn1_Click"/>
               
            </td>
        </tr>
    </table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server">
</rsweb:ReportViewer>
<rsweb:ReportViewer ID="ReportViewer2" runat="server">
</rsweb:ReportViewer>
</asp:Content>
