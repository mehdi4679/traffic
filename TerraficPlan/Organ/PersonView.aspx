<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="PersonView.aspx.cs" Inherits="TerraficPlan.Organ.PersonView" %>
<%@ Register src="~/Controls/CtlPersonOnly.ascx" tagname="CtlPerson" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content332" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
      <div id="tabs-1" class="tabs-1" style="display:block;margin-top:12px">
       <fieldset class="fieldsetdiv" style="padding:30px"><legend class="legenddiv">مشخصات فردی</legend>
     <uc1:CtlPerson ID="CtlPerson1" runat="server" />

       </fieldset>
  </div>
</asp:Content>
