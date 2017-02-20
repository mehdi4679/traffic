<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="TerraficPlan.Organ.Company" %>
<%@ Register src="~/Controls/CtlCompanyOnly.ascx" tagname="CtlCompanyOnly" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <div id="tabs-2" class="tabs-2" style="margin-top:12px">
       <fieldset class="fieldsetdiv" style="padding:30px"><legend  class="legenddiv">خرید عوارض برای شرکت ها,نهادها,اداره ها و سازمانها</legend>
     

           <uc2:CtlCompanyOnly ID="CtlCompanyOnly1" runat="server" />
     

       </fieldset>
  </div>
</asp:Content>
