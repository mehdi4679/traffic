<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlPersonSelect.ascx.cs" Inherits="TerraficPlan.Controls.CtlPersonSelect" %>
<style>
.pggoo
{
    width:50px;
    height:50px;
    }
</style>
<table><tr>
<td><asp:TextBox runat="server" ID="txtPersonSelect"></asp:TextBox></td>
<td><a href="#"><img class="pggoo" src="../App_Themes/Theme1/Images/arrow_left.gif" onclick="getPersnalID();" /></a></td>
<td><span   ID="lblPersonView"  runat="server" /></td>
<td><input runat="server" ID="lblperonalId" runat="server"  type="hidden" value="0"/></td>
<td><span id="Loading" /></td>
</tr>
</table>
<script type="text/javascript" >
    function getPersnalID() {
        Tbl_Prsonal_Get($('#<%= txtPersonSelect.ClientID %>').val());

     }


     function GoServer(_datatype, _type, _url, datao, onsuccess, lid) {
         var datao = JSON.stringify(datao);
         //  datao = datao.replace(/"/g, "'");
         jQuery.ajax({
             type: _type, url: GetUrlService(_url),
             contentType: 'application/json; charset=utf-8', dataType: _datatype, data: datao,
             success: function (d, s) { if (onsuccess != null) onsuccess(d, s); if (lid != null) lid.find('.loading').remove(); },
             beforeSend: function () { if (lid != null) { l = $('<img class="loading" src="/images/loading.gif">'); lid.append(l); } },
             error: function (xmlHttpRequest, status, err) { if (lid != null) lid.find(".loading").remove(); }
         });
     }

     function GetUrlService(url) {
         var qs = document.location.search.split('?')[1];
         return url + "?" + qs;
     }
     function LoadService(path, datao, onsuccess, lid) { GoServer('json', 'post', path, datao, onsuccess, lid); };

     function Tbl_Prsonal_Get(CodeMelli) {
         data = {};
         data.cl = {};
         data.cl.CodeMelli = CodeMelli;

         method = "get";
         LoadService("/Personal/Personal.aspx/" + method, data, function (data, status) {
             if (data.d != null) {
                 OnSuccess(data)
             }
         }, $('#Loading'));
     }

     function OnSuccess(response) {
         var xmlDoc = $.parseXML(response.d);
         var xml = $(xmlDoc);
         var i = 1;
         var Tbl_student = xml.find("tbl_person");
         $.each(Tbl_student, function () {
             var customer = $(this);
             $('#<%= lblPersonView.ClientID %>').html($(this).find("fullname").text());
            $('#<%= lblperonalId.ClientID %>').val($(this).find("PersonalID").text());
        });
        if ($('#<%= lblPersonView.ClientID %>').html() == '')
            $('#<%= lblPersonView.ClientID %>').html('هیچ فردی پیدا نشد.');
    }


</script>