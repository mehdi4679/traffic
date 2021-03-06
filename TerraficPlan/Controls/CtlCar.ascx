﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlCar.ascx.cs" Inherits="TerraficPlan.Controls.CtlCar" %>
    <%@ Register src="CtlPelak.ascx" tagname="CtlPelak" tagprefix="uc1" %>
    <%@ Register src="CtlVIN.ascx" tagname="CtlVIN" tagprefix="uc2" %>
    <div >
     <asp:Label ID="LblParamCarID"  Visible="false" runat="server" Text="0" ></asp:Label> 
        <asp:Label ID="lblPersonID"  Visible="false" runat="server" Text="0" ></asp:Label>
        <asp:Label ID="lblCarOFcompanyID"  Visible="false" runat="server" Text="0" ></asp:Label>

    <asp:Button runat="server" ID="btnInsertLight"  text="افزودن"  SkinID="btnInsert"  Visible="false" />
    <asp:Button runat="server"  ID="btnSerachLight"  Text="جستجو" SkinID="hbtn-search-r"  Visible="false"/> 


        <asp:Label ID="LblCarid1"  Visible="false" runat="server" Text="0" ></asp:Label>
        <asp:Label ID="LblCarid2"  Visible="false" runat="server" Text="0" ></asp:Label>
        <asp:Label ID="lblchangComment"  Visible="false" runat="server" Text="0" ></asp:Label>


    </div >
    <div >
          <asp:Label runat="server" ID="LblNumber"  Font-Bold="True"  ForeColor="Green"  ></asp:Label> 
    </div >
  
       
<fieldset class="fieldsetdiv " style="padding:30px"><legend class="legenddiv">
    <asp:Label runat="server" ID="LblHeaderText" Text="ثبت خودرو-کاربر گرامی شما میتوانید خودروهای مورد نظر خود را ثبت نمایید" ></asp:Label></legend>
 
<table>
<tr><td>پلاک</td><td><uc1:CtlPelak ID="txtpelek" runat="server"  data-rel="tooltip" data-original-title="پلاک های ت,الف,جانبازان بالای 50 درصد و انتظامی معاف بوده و نیازی به خر ید طرح ترافیک ندارند"  /> </td><td></td><td>
</td><td>                 </td></tr><tr><td>نوع خودرو</td><td><asp:TextBox data-rel="tooltip" title="نام خودرو را وارد نمایید"  data-placement="left" runat="server" ID="DDCarType" ></asp:TextBox></td><td></td><td>
</td><td>                 </td></tr> <tr>
    <td>مدل خودرو</td>
                                                       <td><div style="padding-top:20px" >
                                                           <table ><tr>
                                                           <td>
    <fieldset class="fieldsetdiv" style="padding:25px"><legend><asp:RadioButton Checked="true" runat="server" Text="شمسی" GroupName="rr" Style="padding-right:10px" ID="rdSahmsi" />
        <asp:RadioButton runat="server" Text="میلادی"  GroupName="rr" ID="rdmilady"/></legend> 
    <asp:TextBox runat="server" data-rel="tooltip" title="در وارد کردن تاریخ شمسی یا میلادی دقت نمایید" data-placement="left" data-original-title="در وارد کردن تاریخ شمسی یا میلادی دقت نمایید" ID="DDCarModel" MaxLength="4" onkeyup="var Key = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode; if (Key==37 || Key==38 || Key==39 || Key==40 || Key==9) return false; " onkeypress="ValidateNumber(event); "></asp:TextBox></fieldset>    
</tr></table></div></td><td><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"    ValidationGroup="RVTbl_Car" 
                     ControlToValidate="DDCarModel" Display="Dynamic"  
                     ErrorMessage="مدل خودرو را 4 رقمی و صحیح وارد نمایید" ValidationExpression="^\d{4}$">    
                </asp:RegularExpressionValidator>
</td><td></td><td></td></tr><tr><td>رنگ</td><td><asp:textbox runat="server" ID="TXTCarColor" title="فقط حروف فارسی" data-rel="tooltip" data-placement="left" ></asp:textbox></td><td></td><td>
</td><td></td></tr><tr runat="server" visible="false"><td>ظرفیت سرنشین</td><td><asp:dropdownlist runat="server" ID="DDCarCapacity" >
    <asp:ListItem>1</asp:ListItem>
    </asp:dropdownlist></td><td></td><td>
</td><td></td></tr><tr><td>VIN</td><td>
    <%--<uc2:CtlVIN ID="TXTVIN" runat="server" />--%>
    <asp:textbox runat="server" ID="TXTVIN" data-rel="tooltip" title="Vin را دقیق وارد نمایید" data-placement="right" data-orginal-title="Vin را دقیق وارد نمایید" ></asp:textbox>
  <%-- <span data-content="Warning! Best check yo self, you're not looking too good."
        title="" data-placement="left" data-rel="popover" class="btn btn-warning btn-sm popover-warning"
        data-original-title="&lt;i class='ace-icon fa fa-exclamation-triangle orange'&gt;&lt;/i&gt; Left Warning"
        aria-describedby="popover707846">Left</span>
    <div role="tooltip" class="popover fade left in"
         id="popover707846" style="top: 25.7px; left: -119px; display: block;">
        <div class="arrow" style=""></div><h3 class="popover-title">
            <i class="ace-icon fa fa-exclamation-triangle orange">

            </i> Left Warning</h3><div class="popover-content">Warning! Best check yo self, you're not looking too good.</div>

    </div>--%>
    <button type="button"  class="btn btn-inverse" onclick="ggg()">نمونه VIN</button>


<%--    <asp:RegularExpressionValidator ValidationGroup="RVTbl_Car" ValidationExpression="^[a-zA-Z0-9]{18}$" ID="MenuLabelVal" runat="server" ErrorMessage="هجده کارکتر و فقط از اعداد و حروف وارد نمایید." ControlToValidate="TXTVIN"  />--%>


                                   </td><td></td><td>
</td><td>                 <asp:RequiredFieldValidator ID="RqVIN" runat="server" 
ControlToValidate="txtVIN" ErrorMessage="لطفا پر کنبد" 
ValidationGroup="RVTbl_Car" ForeColor="Red">
</asp:RequiredFieldValidator></td></tr>
    <tr><td>پیوست کارت خودرو</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadCard" runat="server"  />
        </td><td>&nbsp;</td><td>
        &nbsp;</td><td>                 &nbsp;</td></tr>
    <tr><td>پیوست معاینه فنی</td><td style="margin-left: 80px">
        <asp:FileUpload ID="FileUploadFani" runat="server" />
        </td><td>&nbsp;</td><td>
        &nbsp;</td><td>                 &nbsp;</td></tr>
    <tr runat="server" id="sa1" visible="false"><td>نام و نام خانوادگی جانباز</td><td style="margin-left: 80px">
        <asp:TextBox ID="txtSacrificeName" runat="server" />
        </td><td>&nbsp;</td><td>
        &nbsp;</td><td>                 &nbsp;</td></tr>
    <tr runat="server" id="sa2" ><td>درصد جانباز</td><td style="margin-left: 80px">
        <asp:TextBox ID="txtSacrificePercent" runat="server" Text="0" />
        </td><td>&nbsp;</td><td>
        &nbsp;</td><td>                 &nbsp;</td></tr>


</table>
<asp:Button runat="server" Text="ثبت"  ID="BtnInsert" SkinID="btnInsert" 
  ValidationGroup="RVTbl_Car" OnClick="BtnInsert_Click2" />
</fieldset>

             <div style="width:100%;float:left">
                  
           <asp:Repeater runat="server" ID="GridView1"  >
               <ItemTemplate>
        <div id="dCar" class="CarView   "  >

            <div id="dcontentCar"></div>
            <table>
                <tr style="height:0px;">
                    <td>
            <a runat="server" id="adel" href='<%#Eval("CarID").ToString() %>' class="ADelete" onserverclick="DeleteItem"></a>

                    </td>
                    <td valign="top">
             <a href='<%#Eval("CarID").ToString() %>' runat="server" id="viewAttach" onserverclick="viewAttach_ServerClick" alt="مشاهده پیوست ها" ><img src="/App_Themes/Theme1/Images/pic.png"  style="width:24px;height:24px"/></a>

                    </td>
                </tr>
            </table>
            <div runat="server" visible="false" id="dseklecttt">
                <asp:CheckBox  CssClass="ch"  Text="انتخاب خودرو"  runat="server" ID="chSelect" AutoPostBack="false"  carid='<%#Eval("CarID").ToString() %>'  Checked= '<%# Convert.ToBoolean( Eval("checked")) %>'/>
               

            </div>
           <div id="dPelek">  <uc1:CtlPelak ID="CtlPelak11" Enable="false" runat="server" text='<%#Eval("Pelak").ToString() %>' /></div>
            <table>
                <tr style="height:0px"><td><%#Eval("CarTypeName").ToString() %> <span>مدل:</span><span><%#Eval("CarModelName").ToString() %></span></td></tr>
                <tr style="height:0px"><td><span>رنگ:</span><%#Eval("CarColor").ToString() %><%--ظرفیت:<%#Eval("CarCapacityName").ToString() %>--%></td></tr>
                <%--<tr style="height:0px"><td><span>VIN:</span><%#Eval("VIN").ToString() %></td></tr>--%>
                <tr style="height:0px"><td><span></span><%#Eval("saname").ToString() %></td></tr>

            </table>

        </div>
    </ItemTemplate>
           </asp:Repeater>
         
         </div>
<br />

<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox"   >
<asp:Repeater runat="server" ID="rpPic" >
    <ItemTemplate>
                <div id="dPicView" class="dpic" >
              <%--  <a id="ADel" class="ADelete apic"  href='<%# DataBinder.Eval(Container,"DataItem.AttachID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>--%>
                <img runat="server" class="picc" id="img" src='<%# "/upload/"+Eval("AttachID")+ System.IO.Path.GetExtension(Eval("AttachName").ToString()) %>' /><br />
                <asp:Label runat="server" ID="lbltype" Text='<%# Eval("TypeName") %>'></asp:Label><br />
              <%--  <%# DateConvert.m2sh(Eval("createDate").ToString())%>--%>
                <asp:Label runat="server" ID="lblAttachID" Visible="false" Text='<%# Eval("AttachID") %>'></asp:Label>
                </div> 
    </ItemTemplate>
</asp:Repeater>
</div>
    <div id="lightinsertVIN" class="Lightbox" >
 <div class="widget-box">
											<div class="widget-header">
												<h4 class="smaller">
                                                    نمونه VIN
                                                    </h4>
                                                </div>
     <div class="widget-body">
         <img src="/App_Themes/Theme1/Images/VIN.jpg" style="width:300px;height:300px"/>
     </div>
     </div>
</div>
</div>
  <input type="hidden"  id="LightBox" runat="server" /> 
  <input type="hidden"  id="LightBoxVIN" runat="server" /> 
<asp:Label runat="server" ID="Label1"></asp:Label>
<script type="text/javascript">
    $("input[type=checkbox]").click(function () {
            if ($(this).is(':checked')) {
                $('input[type=checkbox]').prop('checked', false);
                $(this).prop('checked', true);
            }
        });
         if (document.getElementById('<%= LightBox.ClientID %>').value == "1") {
            setTimeout(f, 0);
        }
          if (document.getElementById('<%= LightBoxVIN.ClientID %>').value == "1") {
            setTimeout(f2, 0);
          }
    function ggg() {
        document.getElementById('<%= LightBoxVIN.ClientID %>').value = "1";
        f2();
    }
    function g() {
        scripthelper.CloseLightBox("lightinsert");
        scripthelper.CloseLightBox("lightinsertVIN");
    }
    function f() {
        scripthelper.ShowLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv");
    }
    function f2() {
        scripthelper.ShowLightBox("lightinsertVIN", '<%= LightBoxVIN.ClientID %>', "lightboxdiv");
    }
    function back() {
        scripthelper.CloseLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv")
    }
    function back2() {
        scripthelper.CloseLightBox("lightinsertVIN", '<%= LightBoxVIN.ClientID %>', "lightboxdiv")
    }
    

 
    var validFilesTypes = ["jpg", "png", "gif", "bmp", "jpeg"];

    function ValidateFile()

    {

      var file = document.getElementById("<%=FileUploadCard.ClientID%>");

      var label = document.getElementById("<%=Label1.ClientID%>");

      var path = file.value;

      var ext=path.substring(path.lastIndexOf(".")+1,path.length).toLowerCase();

      var isValidFile = false;

      for (var i=0; i<validFilesTypes.length; i++)

      {

        if (ext==validFilesTypes[i])

        {

            isValidFile=true;

            break;

        }

      }

      if (!isValidFile)

      {

        label.style.color="red";

        label.innerHTML="Invalid File. Please upload a File with" +

         " extension:\n\n"+validFilesTypes.join(", ");

      }

      return isValidFile;

     }

 
   </script>

