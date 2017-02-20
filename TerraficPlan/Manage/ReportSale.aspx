<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="ReportSale.aspx.cs" Inherits="TerraficPlan.Manage.ReportSale"   %>
<%@ Register assembly="Stimulsoft.Report.Web, Version=2015.1.0.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" namespace="Stimulsoft.Report.Web" tagprefix="cc1" %>


<%@ Register src="~/Controls/CtlPelak.ascx" tagname="CtlPelak" tagprefix="uc1" %>
<%@ Register src="~/Controls/CtlCar.ascx" tagname="Ctlcar" tagprefix="uccar" %>
<%@ Register src="~/Controls/CtlPersonOnly.ascx" tagname="CtlPerson" tagprefix="ucperson" %>
<%@ Register src="~/Controls/CtlCompanyOnly.ascx" tagname="Ctlcompany" tagprefix="ucCompany" %>
<%@ Register src="../Controls/CtlDatePicker.ascx" tagname="CtlDatePicker" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <table style="padding:30px">
 
           <tr>
               <td>کد ملی:</td>
              <td><asp:TextBox runat="server" ID="nationalCode"></asp:TextBox></td>
                 <td>نام</td>
               <td><asp:TextBox runat="server" ID="txtname"></asp:TextBox></td>
               <td>نام خانوادگی</td>
               <td><asp:TextBox runat="server" ID="txtLastName"></asp:TextBox></td>
           </tr>
           <tr><td>شرکت:</td><td colspan="10"><asp:DropDownList runat="server" ID="ddcompany"></asp:DropDownList></td></tr>

           <tr>
               <td>پلاک:</td>
               <td colspan="10">
                  
                  
                  
                   <uc1:CtlPelak ID="CtlPelak" runat="server" />
                  
               
                  
               </td>
           </tr>
           <tr>
               <td>از تاریخ</td>
               <td> 

                    <uc2:CtlDatePicker ID="txtFromDate" runat="server" />
               </td>
              
           </tr>
           <tr>
               <td>تا تاریخ</td>
               <td>
                   <uc2:CtlDatePicker ID="txtToDate" runat="server" /></td>
                   
           </tr>

           <tr>
               <td>از تاریخ تراکنش:</td>
               <td> 

                    <uc2:CtlDatePicker ID="txtFromDateTransaction" runat="server" />
               </td>
              
           </tr>
           <tr>
               <td>تا تاریخ تراکنش:</td>
               <td>
                   <uc2:CtlDatePicker ID="txtToDateTransaction" runat="server" /></td>
                   
           </tr>



           <tr>
               <td>وضعیت</td>
               <td>
                   <asp:DropDownList runat="server" ID="ddRequestStatus" ></asp:DropDownList></td>
                   
           </tr>
           <tr>
               <td>تخفیف</td>
               <td>
                   <asp:DropDownList runat="server" ID="ddDiscountype" ></asp:DropDownList></td>
                   
           </tr>
           <tr>
               <td>نوع درخواست</td>
               <td>
                   <asp:DropDownList runat="server" ID="ddRepeatType" ></asp:DropDownList></td>
                   
           </tr>
           <tr>
               <td>تداخل در پرداخت</td>
               <td>
                   <asp:CheckBox runat="server" ID="chGetConfilict" ></asp:CheckBox></td>
                   
           </tr>
           <tr>
               <td>
                   <asp:Button runat="server" ID="btnSearch" Text="جستجو" OnClick="btnSearch_Click" /></td>
               <td>

               </td>
           </tr>
       </table>
  <%--  <iframe   id="MyIfarm" runat="server" visible="false" >

</iframe>--%>
 
     
</asp:Content>
