<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="TerraficPlan.Manage.Manage" %>
<%@ Register src="~/Controls/CtlPelak.ascx" tagname="CtlPelak" tagprefix="uc1" %>
<%@ Register src="~/Controls/CtlCar.ascx" tagname="Ctlcar" tagprefix="uccar" %>
<%@ Register src="~/Controls/CtlPersonOnly.ascx" tagname="CtlPerson" tagprefix="ucperson" %>
<%@ Register src="~/Controls/CtlCompanyOnly.ascx" tagname="Ctlcompany" tagprefix="ucCompany" %>
<%@ Register src="../Controls/CtlDatePicker.ascx" tagname="CtlDatePicker" tagprefix="uc2" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        
    .Lightbox {
    background-color: White;
    border: 4px solid #444;
    color: Black;
    cursor: default;
    direction: rtl;
    font-size: 12px;
    left: 15%;
    margin-bottom: 12px;
    padding: 4px 6px 6px;
    position: absolute;
    text-align: right;
    top: 10%;
    visibility: hidden;
    width: 70%;
    z-index: 1100;
    position:fixed;
}
        .tda {
        
        padding-right:5px;
        }
        .CarView {
           background: linear-gradient(#f0efef, #ffffff 70%) repeat scroll 0 0 rgba(0, 0, 0, 0);
    border: 1px solid #d2d2d2;
    border-radius: 5px;
    box-shadow: 0.2em 0.2em 0.25em #cccccc;
    color: #222;
    direction: rtl;
    float: right;
    margin: 2px 5px 5px;
    min-height: 265px;
    padding: 25px 5px 5px;
    text-align: right;
    width: 200px;
    height:290px;
        
        }
        </style>
</asp:Content>
 <asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   
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
               <td>وضعیت</td>
               <td>
                   <asp:DropDownList runat="server" ID="ddRequestStatus" ></asp:DropDownList></td>
                   
           </tr>
<%--           <tr>
               <td>وضعیت پرداخت</td>
               <td>
                   <asp:DropDownList runat="server" ID="ddPay" ></asp:DropDownList></td>
                   
           </tr>--%>
           <tr>
               <td>
                   <asp:Button runat="server" ID="btnSearch" Text="جستجو" OnClick="btnSearch_Click" /></td>
           </tr>
       </table>
    
     <fieldset style="padding:30px"><legend>درخواست های ثبت شده</legend>    
    <asp:Repeater runat="server" ID="GridView1"  >
               <ItemTemplate>
        <div id="dCar" class="CarView    "  >
            <table>
           <tr  style="height:0px;">
               <td>                 <a id="ADel" class="ADelete  "  href='<%# DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  > </a> 
</td>
               <td>وضعیت:</td><td colspan="10">  <%#Eval("RequestStatusName").ToString() +" "+Eval("DelStatus").ToString() %>  </td></tr>
                <tr style="height:0px;">
                    <td>
                         
                    </td>
                    <td valign="top">
                        
                    </td>
                    <td>
                   
                     </td>
                    <td class="tda" >
                         <a  href='<%#Eval("CarID") %>' data-rel="tooltip" title=" پیوست تخفیف " data-original-title="کلیه پیوست ها"   runat="server" id="AAttach" class="fa fa-picture-o" onserverclick="AAttach_ServerClick"></a>
                    </td>
                    <td class="tda" >
                        <a  href='<%#Eval("RequestTrafficID") %>'  data-rel="tooltip" title="ایام انتخابی" data-original-title="ایام انتخابی" runat="server" id="Aselect" class="fa fa-calendar" onserverclick="Aselect_ServerClick"></a>
                    </td>
                    <td class="tda" >
                        <a  href='<%#Eval("PersonalID") %>'   data-rel="tooltip" title="مشخصات شخص" data-original-title="مشخصات شخص" runat="server" id="APerson" class="fa fa-user" onserverclick="APerson_ServerClick"></a>
                    </td>
                    <td class="tda" >
                        <a  href='<%#Eval("PersonalID") %>' data-rel="tooltip" title="مشخصات شخص حقوقی" data-original-title="مشخصات شخص حقوقی"  runat="server" id="ACompany" class="fa fa-cog" onserverclick="ACompany_ServerClick"></a>
                    </td>
                    <td class="tda" >
                             <a    data-rel="tooltip" title="اظهار نظر" data-original-title="اظهار نظر"   class="fa fa-comment" onclick="fnazar(<%#Eval("RequestTrafficID").ToString()%>,<%#Eval("PriceRequest").ToString() %> )" price='<%#Eval("PriceRequest").ToString() %>'   id="ANazar"   ></a>
               <%--         <a  href='<%#Eval("RequestTrafficID") %>' data-rel="tooltip" title="خودرو" data-original-title="خودرو"  runat="server" id="ACar" class="fa fa-car" onserverclick="ACar_ServerClick"></a>--%>
                    </td>

                    <td class="tda" >
                    <a  href='<%#Eval("PersonalMobile") %>' data-rel="tooltip" title="ارسال پیامک" data-original-title="ارسال پیامک"  runat="server" id="ASMS" class="fa fa-mobile" onserverclick="ASMS_ServerClick"></a>

                    </td>

                </tr>
            </table>
 
            
           <div id="dPelek">  <uc1:CtlPelak ID="CtlPelak11" Enable="false" runat="server" text='<%#Eval("Pelak").ToString() %>' /></div>
            <table>
                <tr style="height:0px"><td><%#Eval("CarTypeName").ToString() %> </td></tr>
                <tr style="height:0px"><td><span>قیمت:</span><span class="priceclass"><%#Eval("Price").ToString() %></span><%--ظرفیت:<%#Eval("CarCapacityName").ToString() %>--%></td></tr>
                <tr style="height:0px"><td colspan="10"><span></span><%#Eval("DiscountTypeName").ToString() %></td> </tr>
               <tr style="height:0px"><td><span>مالک:</span><%#Eval("OwnerName").ToString() %></td> </tr>
                <tr><td><%#Eval("CreateTime").ToString() %></td></tr>
            </table>
        </div>
    </ItemTemplate>
           </asp:Repeater>
     </fieldset>

    <div  id="lightboxdiv" class="LightBoxDiv" >

<div id="lightinsertPerson"   class="Lightbox">
    <ucperson:CtlPerson runat="server" ID="ctlperson" />
</div>
<div id="lightinsertCompany"  class="Lightbox" >
    <ucCompany:Ctlcompany runat="server" ID="ctlCompany" />
</div>
<div id="lightinsertAttach" class="Lightbox"  >
   <asp:Repeater runat="server" ID="RepeaterPic">
    <ItemTemplate>
                <div id="dPicView" class="dpic" >
                    
                <img runat="server" class="picc" id="img" src='<%# "/upload/"+Eval("AttachID")+ System.IO.Path.GetExtension(Eval("AttachName").ToString()) %>' /><br />
                <%--<asp:Label runat="server" ID="lbltype" Text='<%# Eval("TypeName") %>'></asp:Label><br />
                <%#  DateConvert.m2sh(Eval("createDate").ToString())%>--%>
                <asp:Label runat="server" ID="lblAttachID" Visible="false" Text='<%# Eval("AttachID") %>'></asp:Label>
                </div> 
    </ItemTemplate>
</asp:Repeater>
</div>
<div id="lightinsertRepeat" class="Lightbox" >
    <fieldset><legend>طرح های انتخاب شده<br />
            </legend>
            <asp:Repeater runat="server" ID="dlistselect"  >
                <ItemTemplate>
                <div class='<%#Eval("ClassName").ToString() %>'  >
                  <%--  <a class="ADelete" href='<%#Eval("RequestRepeatID").ToString() %>' runat="server" onserverclick="RepeatDelete"></a>--%>
                    <div><%#Eval("RepeatTypeIDName").ToString() %></div>
                    <div><%#Eval("TitelName").ToString() %></div>
                     <div> از: <%#Eval("PRstatrtDate").ToString() %> تا: <%#Eval("PREndDate").ToString() %></div>
                </div>
                    </ItemTemplate>
               
            </asp:Repeater>
        </fieldset>
</div>
<div id="lightinsertnazar" class="Lightbox" style="position:fixed">
            <input type="hidden" id="txtRequestParam" runat="server" value="0"/>
            <table>
                <tr>
                    <td >نظر مرکز:</td><td colspan="10"><asp:DropDownList runat="server" ID="ddnazar" ></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>توضیحات مرکز:</td><td><asp:TextBox runat="server" ID="txtnazar" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>مبلغ نهایی:</td><td><asp:TextBox runat="server" ID="txtPriceRequest"  ></asp:TextBox></td>
                </tr>
                <tr><td><asp:Button runat="server" ID="btnNazar" Text="نظر مرکـز هوشمند ترافیکــ" OnClick="btnNazar_Click" /></td></tr>
                </table>
        </div>
<div id="lightinsertSMS"  class="Lightbox" >
    <input type="hidden" runat="server" id="lblmobile" />
    <table>
        <tr>
            <td>متن پیامک</td>
            <td><asp:TextBox runat="server" ID="txtSMS" TextMode="MultiLine" ></asp:TextBox></td>
            <td><asp:Button runat="server" ID="btnSMS" Text="ارسال پیامک" OnClick="btnSMS_Click"/></td>
        </tr>
    </table>
</div>


  

        </div>




      <input type="hidden"  id="LightBoxPerson" runat="server"  value="0" /> 
     <input type="hidden"  id="LightBoxCompany" runat="server"  value="0" /> 
     <input type="hidden"  id="LightBoxAttach" runat="server"  value="0" /> 
     <input type="hidden"  id="LightBoxRepeat" runat="server"  value="0" /> 
     <input type="hidden"  id="LightBoxNazar" runat="server" value="0" /> 
     <input type="hidden"  id="LightBoxSMS" runat="server" value="0" /> 
        <script type="text/javascript">
            if (document.getElementById('<%= LightBoxPerson.ClientID %>').value == "1")
                setTimeout(f, 0);
            if (document.getElementById('<%= LightBoxCompany.ClientID %>').value == "1")
                setTimeout(f2, 0);
            if (document.getElementById('<%= LightBoxAttach.ClientID %>').value == "1")
                setTimeout(f3, 0);
            if (document.getElementById('<%= LightBoxRepeat.ClientID %>').value == "1")
                setTimeout(f4, 0);
            if (document.getElementById('<%= LightBoxNazar.ClientID %>').value == "1")
                setTimeout(f5, 0);
            if (document.getElementById('<%= LightBoxSMS.ClientID %>').value == "1")
                setTimeout(f6, 0);

            function fnazar(id,p) {
                document.getElementById('<%= LightBoxNazar.ClientID %>').value = "1";
                document.getElementById('<%= txtRequestParam.ClientID %>').value = id;
                document.getElementById('<%= txtPriceRequest.ClientID %>').value = p;

                f5();
            }
            function g() {
                scripthelper.CloseLightBox("lightinsert");
            }

            function f() {
                document.getElementById('<%= LightBoxCompany.ClientID %>').value = "0";
              document.getElementById('<%= LightBoxAttach.ClientID %>').value = "0";

              document.getElementById('<%= LightBoxNazar.ClientID %>').value = "0";
              scripthelper.ShowLightBox("lightinsertPerson", '<%= LightBoxPerson.ClientID %>', "lightboxdiv");

          }
          function f2() {
     <%--   document.getElementById('<%= LightBoxAttach.ClientID %>').value = "0";
        document.getElementById('<%= LightBoxRepeat %>').value = "0";
        document.getElementById('<%= LightBoxNazar.ClientID %>').value = "0";
        document.getElementById('<%= LightBoxPerson.ClientID %>').value = "0";--%>
                scripthelper.ShowLightBox("lightinsertCompany", '<%= LightBoxCompany.ClientID %>', "lightboxdiv");
            }
            function f3() {

                document.getElementById('<%= LightBoxNazar.ClientID %>').value = "0";
        document.getElementById('<%= LightBoxPerson.ClientID %>').value = "0";
        document.getElementById('<%= LightBoxCompany.ClientID %>').value = "0";

        scripthelper.ShowLightBox("lightinsertAttach", '<%= LightBoxAttach.ClientID %>', "lightboxdiv");
    }
    function f4() {
        document.getElementById('<%= LightBoxNazar.ClientID %>').value = "0";
                document.getElementById('<%= LightBoxPerson.ClientID %>').value = "0";
                document.getElementById('<%= LightBoxCompany.ClientID %>').value = "0";
                document.getElementById('<%= LightBoxAttach.ClientID %>').value = "0";

                scripthelper.ShowLightBox("lightinsertRepeat", '<%= LightBoxRepeat.ClientID %>', "lightboxdiv");
            }
            function f5() {
                document.getElementById('<%= LightBoxRepeat.ClientID %>').value = "0";
                document.getElementById('<%= LightBoxPerson.ClientID %>').value = "0";
                document.getElementById('<%= LightBoxCompany.ClientID %>').value = "0";
                document.getElementById('<%= LightBoxAttach.ClientID %>').value = "0";

                scripthelper.ShowLightBox("lightinsertnazar", '<%= LightBoxNazar.ClientID %>', "lightboxdiv");
            }
            function f6() {
                scripthelper.ShowLightBox("lightinsertSMS", '<%= LightBoxSMS.ClientID %>', "lightboxdiv");
            }

            function back() {
                scripthelper.CloseLightBox("lightinsertPerson", '<%= LightBoxPerson.ClientID %>', "lightboxdiv")
                scripthelper.CloseLightBox("lightinsertCompany", '<%= LightBoxCompany.ClientID %>', "lightboxdiv")
                scripthelper.CloseLightBox("lightinsertAttach", '<%= LightBoxRepeat.ClientID %>', "lightboxdiv")
                scripthelper.CloseLightBox("lightinsertRepeat", '<%= LightBoxAttach.ClientID %>', "lightboxdiv")
                scripthelper.CloseLightBox("lightinsertnazar", '<%= LightBoxNazar.ClientID %>', "lightboxdiv")
                scripthelper.CloseLightBox("lightinsertSMS", '<%= LightBoxSMS.ClientID %>', "lightboxdiv")

            }






   </script>
</asp:Content>

