<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="Repeat.aspx.cs" Inherits="TerraficPlan.Public.Repeat" %>
 <%@ Register Src="~/Controls/CtlDatePicker.ascx" TagName="CtlDatePicker" TagPrefix="uc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        .dselecttype {
        width:auto;
        float:right;
        background-color:#CDCDCD;
        padding:5px;
        border-style:solid;
        border-radius:5px;
        font-family:'mitrabold',Tahoma;
        margin:5px;
        
        }
    .wizard-steps li .title {

        margin-top:-10px;
    }
      
        .dselected {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;

        }
        
        .bahar {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:lightgreen;
    cursor: pointer; cursor: pointer;
        }   
        .tabestan {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:red;
    cursor: pointer; cursor: pointer;
        } 
        .payeez {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:lightyellow;
    cursor: pointer; cursor: pointer;
        } 
       .Zemestan {
    border-radius: 10px;
    border-style: solid;
    float: right;
    margin: 5px;
    padding: 5px;
    width: 200px;
    background-color:white;
    cursor: pointer; cursor: pointer;
        }
        div {

            font-family:'mitrabold','tahoma';
        }
         
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <asp:Label runat="server" ID="lblOwnerType" Text="1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="LblRequestID" Text="0" Visible="false" ></asp:Label>

   

       <fieldset><legend>خرید طرح</legend>

           <asp:Repeater runat="server" ID="rpSelectAllow">
               <ItemTemplate>
                    <a href="#" onclick='<%#  "ff("+ Eval("CatalogValue").ToString()+")"  %>'  Value='<%#Eval("CatalogValue").ToString() %>' class="dselecttype" ><div><%#Eval("CatalogName").ToString() %></div></a>
               </ItemTemplate>
           </asp:Repeater>

<%--           <a href="#" onclick="f();" Value="3" class="dselecttype" ><div>روزانه</div></a>
            <a href="#" onclick="f2();" Value="4"  class="dselecttype" ><div>ماهانه</div></a>
            <a href="#" onclick="f3();" Value="5"  class="dselecttype" ><div>فصلی</div></a>
            <a href="#" onclick="f4();" Value="6"  class="dselecttype" ><div>سالانه</div></a>
          --%>
 
<div  id="lightboxdiv" class="LightBoxDiv" >
<div id="lightinsert" class="Lightbox" >
            <div id="dselectDay" class="select selectday" runat="server">
               <table><tr>
                   <td><uc1:CtlDatePicker ID="CtlDatePicker1" runat="server" /></td><td><asp:DropDownList runat="server" ID="ddHalfDay">
                       <asp:ListItem Value="3">تمام روز</asp:ListItem>
                   <asp:ListItem Value="1">پاره وقت-صبح</asp:ListItem>
                   <asp:ListItem Value="2">پاره وقت عصر</asp:ListItem>
                   </asp:DropDownList> </td></tr></table> 
                <asp:Button runat="server" ID="btnInsertDay"  Text="ثبت" OnClick="btnInsertDay_Click"/>
            </div>
    </div>
<div id="lightinsert2" class="Lightbox" >
            <div id="dselectMonth" class="select selectmonth" runat="server">
                <a href="1" runat="server" onserverclick="MonthClick" ><div class="dmonth bahar">فروردین </div></a>
                <a href="2"  runat="server" onserverclick="MonthClick" ><div class="dmonth bahar">اریبهشت </div></a>
                <a href="3"  runat="server" onserverclick="MonthClick" ><div class="dmonth bahar">خرداد </div></a>
                <a href="4"  runat="server" onserverclick="MonthClick" ><div class="dmonth tabestan">تیر </div></a>
                <a href="5"  runat="server" onserverclick="MonthClick" ><div class="dmonth tabestan">مرداد  </div></a>
                <a href="6"  runat="server" onserverclick="MonthClick" ><div class="dmonth tabestan">شهریور </div></a>
                <a href="7"  runat="server" onserverclick="MonthClick" ><div class="dmonth payeez">مهر </div></a>
                <a href="8"  runat="server" onserverclick="MonthClick" ><div class="dmonth payeez">آبان </div></a>
                <a href="9"  runat="server" onserverclick="MonthClick" ><div class="dmonth payeez">آذر </div></a>
                <a href="10"  runat="server" onserverclick="MonthClick" ><div class="dmonth Zemestan">دی </div></a>
                <a href="11"  runat="server" onserverclick="MonthClick" ><div class="dmonth Zemestan">بهمن </div></a>
                <a href="12"  runat="server" onserverclick="MonthClick" ><div class="dmonth Zemestan">اسفند </div></a>
            </div>
    </div>
    <div id="lightinsert3" class="Lightbox" >
            <div id="dselectSeason" class="select selectsason">
                <a href="1" runat="server" onserverclick="MonthClick" ><div class="dmonth bahar">بهار </div></a>
                <a href="2"  runat="server" onserverclick="MonthClick" ><div class="dmonth tabestan">تابستان </div></a>
                <a href="3"  runat="server" onserverclick="MonthClick" ><div class="dmonth payeez"> پاییز</div></a>
               <a href="4"  runat="server" onserverclick="MonthClick" > <div class="dmonth Zemestan">زمستان </div></a>

            </div>
        </div>
    <div id="lightinsert4" class="Lightbox" >
            <div id="dselectYear" class="select selectyear">
                <asp:Repeater runat="server" ID="rpYear">
                    <ItemTemplate>
                    <a href='<%#Eval("CatalogValue") %>'   runat="server" onserverclick="MonthClick" ><div class="dmonth year"><%#Eval("CatalogName") %> </div></a>
                    </ItemTemplate>
                </asp:Repeater>
                
             <%--   <a href="1394"  runat="server" onserverclick="MonthClick" ><div class="dmonth year">1394 </div></a>
                <a href="1395"  runat="server" onserverclick="MonthClick" ><div class="dmonth year">1395 </div></a>
                <a href="1396"  runat="server" onserverclick="MonthClick" ><div class="dmonth year">1396 </div></a>--%>


            </div>
        </div>
        </fieldset>
        <fieldset><legend>طرح های انتخاب شده<br />
            </legend>
            <asp:Repeater runat="server" ID="dlistselect"  >
                <ItemTemplate>
                <div class='<%#Eval("ClassName").ToString() %>'  >
                    <a class="ADelete" href='<%#Eval("RequestRepeatID").ToString() %>' runat="server" onserverclick="RepeatDelete"></a>
                    <div><%#Eval("RepeatTypeIDName").ToString() %></div>
                    <div><%#Eval("TitelName").ToString() %></div>
                     <div style="visibility:hidden"> از: <%#Eval("PRstatrtDate").ToString() %> تا: <%#Eval("PREndDate").ToString() %></div>
                </div>
                    </ItemTemplate>
               
            </asp:Repeater>
        </fieldset>
    <div runat="server" id="dPrice">
    <fieldset><legend>جمع مبالغ جهت پرداخت</legend>

<div ><asp:Label runat="server" ID="lblprice" CssClass="priceclass" ></asp:Label></div>
       <%-- <asp:Label runat="server" ID="lblPriceFa"></asp:Label>--%>
    </fieldset>

    </div>
     <div class="wizard-actions">
 <%--           <a href='<%= prelink  %>' class="btn btn-prev">
            <i class="ace-icon fa fa-arrow-right"></i>
            مرحله قبلی
            </a>--%>

            <a href="#" runat="server"  onserverclick="Unnamed_ServerClick"   data-last="Finish" class="btn btn-success btn-next"  >
            مرحله بعدی
													
            <i class="ace-icon fa fa-arrow-left icon-on-left"></i></a>
            </div>
        
     <input type="hidden"  id="LightBox" runat="server" /> 
     <input type="hidden"  id="LightBox2" runat="server" /> 
     <input type="hidden"  id="LightBox3" runat="server" /> 
     <input type="hidden"  id="LightBox4" runat="server" /> 
     <input type="hidden"  id="LightBoxvalue" runat="server" value="0" /> 
        <script type="text/javascript">
        if (document.getElementById('<%= LightBox.ClientID %>').value == "1") 
        setTimeout(f, 0);
        if (document.getElementById('<%= LightBox2.ClientID %>').value == "1") 
        setTimeout(f2, 0);
        if (document.getElementById('<%= LightBox3.ClientID %>').value == "1") 
        setTimeout(f3, 0);
        if (document.getElementById('<%= LightBox4.ClientID %>').value == "1") 
        setTimeout(f4, 0);

            function ff(value) {
                if (value == "3" || value == "1" || value=="2")
                    f();
                if (value == "4")
                    f2();
                if (value == "5")
                    f3();
                if (value == "6")
                    f4();
            }

    function g() {
        scripthelper.CloseLightBox("lightinsert");
    }
 
    function f() {
        document.getElementById('<%= LightBox2.ClientID %>').value = "0";
        document.getElementById('<%= LightBox3.ClientID %>').value = "0";
        document.getElementById('<%= LightBox4.ClientID %>').value = "0";
        document.getElementById('<%= LightBoxvalue.ClientID %>').value = "3";
        scripthelper.ShowLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv");
      
    }
            function f2() {
                document.getElementById('<%= LightBox3.ClientID %>').value = "0";
                document.getElementById('<%= LightBox2.ClientID %>').value = "0";
                document.getElementById('<%= LightBox.ClientID %>').value = "0";
                document.getElementById('<%= LightBoxvalue.ClientID %>').value = "4";
        scripthelper.ShowLightBox("lightinsert2", '<%= LightBox2.ClientID %>', "lightboxdiv");
    }
            function f3() {
                document.getElementById('<%= LightBox4.ClientID %>').value = "0";
                document.getElementById('<%= LightBox.ClientID %>').value = "0";
                document.getElementById('<%= LightBox2.ClientID %>').value = "0";
  document.getElementById('<%= LightBoxvalue.ClientID %>').value = "5";
        scripthelper.ShowLightBox("lightinsert3", '<%= LightBox3.ClientID %>', "lightboxdiv");
    }
            function f4() {
                document.getElementById('<%= LightBox.ClientID %>').value = "0";
                document.getElementById('<%= LightBox2.ClientID %>').value = "0";
                document.getElementById('<%= LightBox3.ClientID %>').value = "0";
  document.getElementById('<%= LightBoxvalue.ClientID %>').value = "6";
        scripthelper.ShowLightBox("lightinsert4", '<%= LightBox4.ClientID %>', "lightboxdiv");
    }


    function back() {
        scripthelper.CloseLightBox("lightinsert", '<%= LightBox.ClientID %>', "lightboxdiv")
        scripthelper.CloseLightBox("lightinsert2", '<%= LightBox2.ClientID %>', "lightboxdiv")
        scripthelper.CloseLightBox("lightinsert3", '<%= LightBox3.ClientID %>', "lightboxdiv")
        scripthelper.CloseLightBox("lightinsert4", '<%= LightBox4.ClientID %>', "lightboxdiv")

    }
 


   </script>
</asp:Content>
