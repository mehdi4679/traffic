<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="TerraficPlan.Public.ShoppingCart" %>

<%@ Register src="../Controls/CtlPelak.ascx" tagname="CtlPelak" tagprefix="uc1" %>
 
<%@ Register src="~/Controls/CtlPersonOnly.ascx" tagname="CtlPerson" tagprefix="ucperson" %>
 <%@ Register src="../Controls/CtlDatePicker.ascx" tagname="CtlDatePicker" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
  <%--  <a href="#" runat="server" id="dd2" onserverclick="dd2_ServerClick">درخواست طرح جدید</a>--%>
    <fieldset><legend>درخواست های ثبت شده</legend>    
    <asp:Repeater runat="server" ID="GridView1"  >
               <ItemTemplate>
        <div id="dCar" class="CarView    "  >
            <table>
                <tr style="height:0px;">
                    <td>
            <a runat="server" id="adel" href='<%#Eval("RequestTrafficID").ToString() %>' onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')" class="ADelete" onserverclick="DeleteItem"></a>

                    </td>
                      <td class="tda" >
<%--                         <a  href='<%#Eval("RequestTrafficID") %>' data-rel="tooltip" title="  پیوست تخفیف  " data-original-title="کلیه پیوست ها"   runat="server" id="AAttach" class="fa fa-picture-o" onserverclick="AAttach_ServerClick"></a>--%>
                    </td>
                    <td class="tda" >
                    </td>
                    <td class="tda" >
<%--                        <a  href='<%#Eval("PersonalID") %>'   data-rel="tooltip" title="مشخصات شخص" data-original-title="مشخصات شخص" runat="server" id="APerson" class="fa fa-user" onserverclick="APerson_ServerClick"></a>--%>
                    </td>
                    <td valign="top">
           <%--      <a href='<%#Eval("RequestTrafficID").ToString() %>' runat="server" id="viewAttach" onserverclick="UpItem" alt="ورود" ><img src="/App_Themes/Theme1/Images/pic.png"  style="width:24px;height:24px"/></a>--%>
                    <%#Eval("RequestStatusName").ToString() %>
                    </td>
                    <td>
                        <a id="apay"  onserverclick="Unnamed_ServerClick"  href='<%#Eval("RequestTrafficID") %>' class='<%# Eval("RequestStatus2").ToString()=="1" ? "ABuy":"" %>' runat="server"> </a>
                    </td>
                </tr>
            </table>
 
            
           <div id="dPelek">  <uc1:CtlPelak ID="CtlPelak11" Enable="false" runat="server" text='<%#Eval("Pelak").ToString() %>' /></div>
            <table>
                <tr style="height:0px"><td><%#Eval("CarTypeName").ToString() %> </td></tr>
                <tr style="height:0px"><td><span>قیمت:</span><span class="priceclass"><%#Eval("Price").ToString() %></span>  
                                            <a  href='<%#Eval("RequestTrafficID") %>'  data-rel="tooltip" title="ایام انتخابی" data-original-title="ایام انتخابی" runat="server" id="Aselect" class="fa fa-calendar" onserverclick="Aselect_ServerClick"></a>
                    <%--ظرفیت:<%#Eval("CarCapacityName").ToString() %>--%></td></tr>
                <tr style="height:0px"><td colspan="10"><span> </span><%#Eval("DiscountTypeName").ToString() %> <a  href='<%#Eval("RequestTrafficID") %>' data-rel="tooltip" title="  پیوست تخفیف  " data-original-title="کلیه پیوست ها"   runat="server" id="A1" class="fa fa-picture-o" onserverclick="AAttach_ServerClick"></a></td></tr>
                <tr><td colspan="10"><%# Eval("CreateTime").ToString() %></td></tr>
            </table>
        </div>
    </ItemTemplate>
           </asp:Repeater>
     </fieldset>
    <%--<asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" AllowPaging="True"
               AllowSorting="True" >
<Columns>
            <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate >
            <asp:Label runat="server"  ID="RowNum"   Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >
<asp:TemplateField HeaderText="ورود">
            <ItemTemplate>
                        <a id="AEdit" class="AEdit" href='<%# DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="ورود" onserverclick="UpItem" runat="server" ></a>
            </ItemTemplate>
             </asp:TemplateField>
<asp:TemplateField     HeaderText="وضعیت" >
        <ItemTemplate>
            <table>
                <tr><td><%#Eval("StatusRequest").ToString() %></td></tr>
           <tr><td><a id="apay"  onserverclick="Unnamed_ServerClick"  href='<%#Eval("RequestTrafficID") %>' class='<%# Eval("RequestStatus").ToString()=="1" ? "ABuy":"" %>' runat="server"></a></td></tr>

            </table>
        </ItemTemplate>
    </asp:TemplateField>
   <asp:BoundField DataField="RequestTrafficID"  HeaderText="ش فرآیند"   SortExpression="RequestTrafficID" />
   <asp:BoundField DataField="OwnerType"  HeaderText="نوع مالکیت:"   SortExpression="OwnerType" />
   <asp:BoundField DataField="DiscountType"  HeaderText="تخفیف"   SortExpression="DiscountType" />
   <asp:BoundField DataField="PersonalID"  HeaderText="مالک"   SortExpression="PersonalID" />
    <asp:TemplateField>
        <ItemTemplate>
            <table><tr>
                
                <td> <uc1:CtlPelak ID="CtlPelak1" runat="server" /></td>
                </tr><tr>
                <td><%#Eval("CarTypeName").ToString() %> <span>مدل:</span><span><%#Eval("CarModelName").ToString() %></span></td>

                   </tr></table>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="CarID"  HeaderText="خودرو"   SortExpression="CarID" />
   <asp:BoundField DataField="Price"  HeaderText="قیمت"   SortExpression="Price" ControlStyle-CssClass="priceclass" />
    

             </Columns>
</asp:GridView>--%>
   

        <div  id="lightboxdiv" class="LightBoxDiv" >

<div id="lightinsertPerson"   class="Lightbox">
    <ucperson:CtlPerson runat="server" ID="ctlperson" />
</div>
<div id="lightinsertCompany"  class="Lightbox" >
 </div>
<div id="lightinsertAttach" class="Lightbox"  >
   <asp:Repeater runat="server" ID="RepeaterPic">
    <ItemTemplate>
                <div id="dPicView" class="dpic" >
              <%--  <a id="ADel" class="ADelete apic"  href='<%# DataBinder.Eval(Container,"DataItem.AttachID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>--%>
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

            function fnazar(id) {
                document.getElementById('<%= LightBoxNazar.ClientID %>').value = "1";
              
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
