<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TerraficPlan.Public.Reports" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
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
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="400px" ProcessingMode="Remote" Width="722px" 
    reportpath="/Terrafical/Terrafical2.rdlc" reportserverurl="http://192.168.200.25/Reports"   
          ShowParameterPrompts="False">
            
        </rsweb:ReportViewer>
</asp:Content>
