<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="TerraficPlan.Public.Car" %>
<%@ Register src="~/Controls/CtlCar.ascx" tagname="CtlCar" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>

     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   
    <uc1:CtlCar ID="CtlCar1" runat="server" />
    <div>
    <div class="wizard-actions">
             <a href="PersonalView.aspx" class="btn btn-prev">
            <i class="ace-icon fa fa-arrow-right"></i>
            مرحله قبلی
            </a> 

            <a href="#" runat="server" onserverclick="nextlink"   data-last="Finish" class="btn btn-success btn-next"  >
            مرحله بعدی
													
            <i class="ace-icon fa fa-arrow-left icon-on-left"></i></a>
            </div>

    </div>
</asp:Content>
