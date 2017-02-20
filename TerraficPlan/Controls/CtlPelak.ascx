<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlPelak.ascx.cs" Inherits="TerraficPlan.Controls.CtlPelak" %>
<style>
.ww{height:34px;}
</style>

<style>
    .tdd {
   
    
    }
    .btnpelak {
    background-color:gray;
    
    }
</style>
<span title="" data-rel="tooltip" class="btnpelak" data-original-title="پلاک های ت,الف,جانبازان بالای 50 درصد و انتظامی معاف بوده و نیازی به خر ید طرح ترافیک ندارند">
<div style="background-image: url('/App_Themes/Theme1/Images/White.gif '); background-repeat: no-repeat; background-size: 180px 50px; float: right; width: 180px;">
<table id="tblpellak" style="position:relative;top:-4px;top:12px" >
<tr>
<td class="tdd"> 
 
</td>
<td class="tdd" style="padding-left:10px;padding-right:8px">
<asp:TextBox runat="server" ID="txt16" TabIndex="5" Text="16"   onkeyup="var Key = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if (Key==37 || Key==38 || Key==39 || Key==40 || Key==9) return false; " onkeypress="ValidateNumber(event); "
        CssClass="ww t16"  style="width:25px" MaxLength="2">


</asp:TextBox><br />
  <asp:RequiredFieldValidator ID="RqNationalCode" runat="server"  ControlToValidate="txt16" ErrorMessage="*" ValidationGroup="RVPelek" ForeColor="Red">  </asp:RequiredFieldValidator>

</td>
<td class="tdd"  >
<asp:Label  Text="IR" runat="server" ID="txtIR" TabIndex="4" Enabled="false"  CssClass="ww" style="width:20px" Visible="false"></asp:Label>
</td>
<td class="tdd">
<asp:TextBox runat="server" ID="txt3" TabIndex="3" style="width:35px" CssClass="ww t3"  onkeyup="var Key = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if (Key==37 || Key==38 || Key==39 || Key==40 || Key==9) return false; " onkeypress="ValidateNumber(event); "
        MaxLength="3" ></asp:TextBox><br />
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txt3" ErrorMessage="*" ValidationGroup="RVPelek" ForeColor="Red">  </asp:RequiredFieldValidator>

</td>
<td class="tdd" valign="top">
<asp:DropDownList  runat="server" ID="ddAlphabet" TabIndex="2"  CssClass="ww ta" style="width:50px;">
<asp:ListItem Text="" Value="" Selected ="True"   ></asp:ListItem>
    <%--<asp:ListItem value="ا">الف</asp:ListItem>--%>
					<asp:ListItem value="ب">ب</asp:ListItem>
					<%--<asp:ListItem value="ت">ت</asp:ListItem>--%>
					<asp:ListItem value="ج">ج</asp:ListItem>
					<asp:ListItem value="د">د</asp:ListItem>
					<asp:ListItem value="س">س</asp:ListItem>
					<asp:ListItem value="ص">ص</asp:ListItem>
					<asp:ListItem value="ط">ط</asp:ListItem>
					<asp:ListItem value="ع">ع</asp:ListItem>
					<asp:ListItem value="ق">ق</asp:ListItem>
					<asp:ListItem value="ل">ل</asp:ListItem>
					<asp:ListItem value="م">م</asp:ListItem>
					<asp:ListItem value="ن">ن</asp:ListItem>
					<asp:ListItem value="ه">ه</asp:ListItem>
					<asp:ListItem value="و">و</asp:ListItem>
					<asp:ListItem value="ي">ي</asp:ListItem>
    <asp:ListItem value="چ"></asp:ListItem>
     <asp:ListItem></asp:ListItem>
</asp:DropDownList>
   
    <br />
<%--<asp:RequiredFieldValidator InitialValue="" ID="Req_ID" Display="Dynamic" 
    ValidationGroup="RVPelek" runat="server" ControlToValidate="ddAlphabet"
    Text="*" ErrorMessage="ErrorMessage"></asp:RequiredFieldValidator>--%>


</td>

<td class="tdd">
     
<asp:TextBox    runat="server" ID="txt2" TabIndex="1" CssClass="ww t2" style="width:25px" onkeyup="var Key = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if (Key==37 || Key==38 || Key==39 || Key==40 || Key==9) return false; " onkeypress="ValidateNumber(event); "
        MaxLength="2"></asp:TextBox>
 <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator222" runat="server"  ControlToValidate="txt2" ErrorMessage="*" ValidationGroup="RVPelek" ForeColor="Red">  </asp:RequiredFieldValidator>
</td>





</tr>
</table>
</div>

</span>
 

<script>
    function ValidateNumber(e) {
        var Key = e.keyCode ? e.keyCode : e.which ? e.which : e.charCode;

        if (!{ 48: 1, 49: 1, 50: 1, 51: 1, 52: 1, 53: 1, 54: 1, 55: 1, 56: 1, 57: 1, 8: 1, 46: 1, 35: 1, 36: 1 }[e.which || e.keyCode])
            e.preventDefault ? e.preventDefault() : e.returnValue = false;
    }

</script>