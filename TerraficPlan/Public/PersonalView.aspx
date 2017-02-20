<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="PersonalView.aspx.cs" Inherits="TerraficPlan.Public.PersonalView" %>
<%@ Register src="~/Controls/CtlPersonOnly.ascx" tagname="CtlPerson" tagprefix="uc1" %>

<%@ Register src="../Controls/CtlCompanyOnly.ascx" tagname="CtlCompanyOnly" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   


    
     <div>
    <input class="rdw"  type="radio" id="rd1" runat="server" name="rr"  value="حقیقی" onclick="setcheckk();" checked   >حقیقی</input>
    <input class="rdw1" type="radio" id="rd2" runat="server" name="rr" value="حقوقی" onclick="setcheckk2();"  >حقوقی</input> 
    </div>

 
  <div id="tabs-1" class="tabs-1" style="display:block;margin-top:12px">
       <fieldset class="fieldsetdiv"><legend class="legenddiv">خرید عوارض برای شخص</legend>
     <uc1:CtlPerson ID="CtlPerson1" runat="server" />

       </fieldset>
  </div>
    <div id="tabs-2" class="tabs-2" style="display:none;margin-top:12px">
       <fieldset class="fieldsetdiv"><legend  class="legenddiv">خرید عوارض برای شرکت ها,نهادها,اداره ها و سازمانها</legend>
     

           <uc2:CtlCompanyOnly ID="CtlCompanyOnly1" runat="server" />
     

       </fieldset>
  </div>

      
    
            <div class="wizard-actions">
 

            <a href="#" runat="server" onserverclick="nextlink"   data-last="Finish" class="btn btn-success btn-next"  >
            مرحله بعدی
													
            <i class="ace-icon fa fa-arrow-left icon-on-left"></i></a>
            </div>
        
     <script>
         if ($(".rdw").attr("checked") == "checked") {
             $('.tabs-1').fadeIn(1000);
            $('.tabs-2').fadeOut();
         }
         if ($(".rdw1").attr("checked") == "checked") {
             $('.tabs-1').fadeOut();
             $('.tabs-2').fadeIn(1000);
         }

         $(function () {
             //  $("#tabs").tabs();

             $("input[type=checkbox]").click(function () {
                 if ($(this).is(':checked')) {
                     $('input[type=checkbox]').prop('checked', false);
                     $(this).prop('checked', true);
                 }
             });



         });

         function setcheck() {
             //        document.getElementById('ch1').setAttribute('checked', 'checked');
             //document.getElementById('ch2').setAttribute('checked', 'checked');

             $(".ch1").attr('checked', true);
             $('.ch2').attr('checked', false);
         }
         function setcheck2(i) {
             document.getElementById('chhoghoghi').setAttribute('checked', 'checked');
             document.getElementById('chhaghighi').removeAttribute('checked');
             //$(".chhaghighi").attr('checked',false );
             //$('.chhoghoghi').attr('checked',true );
         }
         $("input[type=radio]").click(function () {
             if ($(this).is(':checked')) {
                 $('input[type=checkbox]').prop('checked', false);
                 $(this).prop('checked', true);
             }
         });
         function setcheckk() {
             $('#tabs-1').fadeIn(500);
             $('#tabs-2').fadeOut(500);
         }
         function setcheckk2() {
             $('#tabs-2').fadeIn(500);
             $('#tabs-1').fadeOut(500);
         }
</script>
</asp:Content>
