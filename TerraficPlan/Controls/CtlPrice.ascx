<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlPrice.ascx.cs" Inherits="TerraficPlan.Controls.CtlPrice" %>
<style type="text/css">
    .style1
    {
        height: 26px;
    }
</style>
<%--
<input id="Price" type="text"   onkeyup="this.value = SplitNumber(this.value)" style="width: 100px" />
<input     id="Text1" type="text" />--%>
<div >
<table>
<tr><td class="style1">    <asp:TextBox ID="txtPrice"  runat="server" style="width: 128px"  ValidationGroup="RFV"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server"  ValidationGroup="RFV"
        ImageUrl="~/images/langFA.gif" /></td><td></td></tr>
        
</table>

<asp:Label ID="LblPrice" runat="server"></asp:Label>
</div>


<script type="text/javascript" >

    function ReplaceAll(stri, from, to) {
        var str = stri.toString();
        var idx = str.indexOf(from);
        while (idx > -1) {
            str = str.replace(from, to);
            idx = str.indexOf(from);
        }
        return str;
    }

    function SplitNumber(amount) {
        amount = ReplaceAll(amount, ",", "");
        var str = new Array();
        while (amount != "") {
            str.push(amount.substring(amount.length - 3, amount.length));
            amount = amount.substring(0, amount.length - 3);
        }
        var j = 0;
        var newstr = new Array();
        for (i = str.length - 1; i >= 0; i--) {
            newstr[j] = str[i];
            j++;
        }
        return newstr;
    }
</script>
