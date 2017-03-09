<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewDiscountMaster.master" AutoEventWireup="true" CodeBehind="CompanyYear.aspx.cs" Inherits="TerraficPlan.Organ.CompanyYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        .greens{background-color:green;width:100%;height:100%}
.yellows{background-color:yellow;width:100%;height:100%}
.visitrue{visibility:inherit;}
.visifalse{visibility:hidden;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label runat="server" ID="lblPersonID" Text="0" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblCompanyID" Text="0" Visible="false"></asp:Label>

<%--         <div>
    <input class="rdw"  type="radio" id="rd1" runat="server" name="rr"  value="حقیقی:جانبازان,ساکنین محدوده و ..." onclick="setcheckk();"    /> 
    <input class="rdw1" type="radio" id="rd2" runat="server" name="rr" value="حقوقی:ادارات,نهادها,موسسات,دفاتر و ... " onclick="setcheckk2();"  />
    </div>--%>
        <table>
<tr >
     <td>سال:</td><td><asp:DropDownList runat="server" ID="ddYear" AutoPostBack="True" OnSelectedIndexChanged="ddYear_SelectedIndexChanged"></asp:DropDownList></td></tr>
        <tr><td>خودرو:</td><td><asp:DropDownList runat="server" ID="ddCar"></asp:DropDownList></td></tr>
        <tr><td>سهمیه:</td><td><asp:DropDownList runat="server" ID="ddsahmie"></asp:DropDownList> </td></tr>

 
            <tr>
                <td colspan="100">

  
                </td&nbsp;</td>
            </tr>
 
    </table>


 




    <asp:Button runat="server" ID="btnAdd" Text="ثبت درخواست" OnClick="btnAdd_Click" CssClass="btn btn-large "/>
   
    <asp:DropDownList runat="server" ID="ddDefauleYear" style="position:center;float:left;" AutoPostBack="True" OnSelectedIndexChanged="ddDefauleYear_SelectedIndexChanged" OnTextChanged="ddDefauleYear_TextChanged"></asp:DropDownList>
    

               
    

               <asp:GridView CssClass="gv" runat="server" AutoGenerateColumns="false" ID="GridView1"   AllowSorting="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
                 >
                <Columns>
                <asp:TemplateField HeaderText="ردیف">
                <ItemTemplate>
                <asp:Label runat="server" ID="RowNum" Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="حذف"> 
                <ItemTemplate>
                <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.RequestTrafficID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="ADel_ServerClick" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField   >
                
                    <asp:TemplateField > 
                          <HeaderTemplate  >
                          <center>
                                  انتخاب<br />
       <input type="checkbox" ID="CheckBoxToSelectAll"   /></center>
   </HeaderTemplate>
                <ItemTemplate>
                   
                <div class="<%#Eval("PAid").ToString()=="1" ?"greens":"yellows" %>">     <div class='<%# Eval("visitrue").ToString()=="1" ?"ch":"visifalse" %>'><input type="checkbox" ID="chh" runat="server" class='<%#   Eval("visitrue").ToString()=="1" ?"ch":"visifalse" %>'     /></div>
               </div>
                     </ItemTemplate>
                </asp:TemplateField   >
                    
                    
   <asp:BoundField DataField="RequestTrafficID"  HeaderText="ش فرآیند"   SortExpression="RequestTrafficID" />
<asp:TemplateField HeaderText=" مبلغ "><ItemTemplate><asp:Label runat="server" ID="lblPricRow" Text='<%#Eval("PriceRequest").ToString() %>'></asp:Label></ItemTemplate></asp:TemplateField>
 <asp:TemplateField Visible="false"><ItemTemplate><asp:Label runat="server" ID="lblRequestTrafficID" Text='<%#Eval("RequestTrafficID").ToString() %>'></asp:Label></ItemTemplate></asp:TemplateField>

<%--   <asp:BoundField DataField="OwnerTypeName"  HeaderText="مالکیت"   SortExpression="OwnerTypeName" />

   <asp:BoundField DataField="DiscountTypeName"  HeaderText="نوع تخفیف"   SortExpression="DiscountTypeName" />--%>

   <asp:BoundField DataField="carname"  HeaderText="خودرو"   SortExpression="carname" />
   <asp:BoundField DataField="CompanyIDName"  HeaderText="شرکت"   SortExpression="CompanyIDName" />
   <asp:BoundField DataField="PersonalIDName"  HeaderText="فرد درخواست دهنده"   SortExpression="PersonalIDName" />

   <asp:BoundField DataField="SahmIDName"  HeaderText="سهمیه"   SortExpression="SahmIDName" />
<%-- <asp:TemplateField  HeaderText="تاریخ درخواست"   SortExpression="CreateDate" ><ItemTemplate> <%# TerraficPlanBLL.DateConvert.m2sh(Eval("CreateDate").ToString()).ToString() %> </ItemTemplate></asp:TemplateField>--%>
      

     <asp:BoundField DataField="RequestStatusName"  HeaderText="نظر مرکز"   SortExpression="RequestStatusName" />
      <asp:BoundField DataField="RequestStatusComment"  HeaderText="توضیحات مرکز"   SortExpression="RequestStatusComment" />
           
                </Columns>
                   </asp:GridView>    

    <input runat="server"  type="button" id="btnnpayy" onclick="f();" Text="پرداخت" value="پرداخت" class="btn" />
<div  id="lightboxdiv" class="LightBoxDiv"  >
<div id="lightinsert" class="Lightbox" style="padding:30px;text-align:center;position:fixed;height:200px"  >
 <center>
        <fieldset style="width:300px;padding:10px;height:150px">
        <legend>پرداخت به صورت
    <table style="text-align:center">
        <tr><td><asp:RadioButton runat="server" ID="rdonline" Checked="true" GroupName ="epaygrooup" Text="آنلاین"/></td><td colspan="10"></td></tr>
        </table>
            <table runat="server" visible="false" >
        <tr><td><asp:RadioButton runat="server" ID="rdcurrentSharj"   GroupName ="epaygrooup"/></td><td> </td><td><asp:Label CssClass="price" runat="server" Text="0" ID="lblShajCurrent"></asp:Label></td></tr>
        
    </table>
<asp:Button Width="80%" runat="server" ID="Button1" OnClick="btnPay_Click" Text="پرداخت" CssClass="btnpay btn-success  "  />
    </fieldset>
</center>
    
    </div>
        </div>
     <input type="hidden"  id="LightBox" runat="server" value="0" /> 

<script type="text/javascript">
    if (document.getElementById('<%= LightBox.ClientID %>').value == "1") {
        setTimeout(f, 0);
    }
    function g() {
        scripthelper.CloseLightBox("lightinsert");
    }
    function f() {
        scripthelper.ShowLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv");
    }
    function back() {
        scripthelper.CloseLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv")
    } 
    </script>
    <script>
            function dd(obj) {
            $("#trjanbaz").css("visibility", "hidden");
            $("#trSahmie").css("visibility", "hidden");

            if (obj.value == "1007")
                $("#trjanbaz").css("visibility", "inherit");

            if (obj.value == "2077")
                $("#trSahmie").css("visibility", "inherit");


        }
        $(document).ready(function () {
            $('.ddhaghighiornot').on('change', function () {

                dd(this);


            });

        if ($('#dropDownId').val()  == "1007")
        $("#trjanbaz").css("visibility", "inherit");
        if ($('#dropDownId').val()  == "1009")
            $("#trSahmie").css("visibility", "inherit");

        });

        
        $("#CheckBoxToSelectAll").click(function () {
            $('.ch').not(this).prop('checked', this.checked);
            var t = $('.ch:checked').length;
            if ($('.ch:checked').length > 0)
                $('.btnpay').attr("visibility", "inherit");
            else
                $('.btnpay').attr("visibility", "hidden");


        });




        //function CheckBtn() {
        //    if ($('input:checkbox .ch').prop('checked')) {
        //        $('.btn').attr("", "");

        //    }
        //}
</script>

</asp:Content>
