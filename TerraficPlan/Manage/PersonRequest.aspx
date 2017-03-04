<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="PersonRequest.aspx.cs" Inherits="TerraficPlan.Manage.PersonRequest" %>
<%@ Register src="~/Controls/CtlPelak.ascx" tagname="CtlPelak" tagprefix="uc1" %>
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
   
       

          <fieldset style="padding:30px"><legend>درخواست های ثبت شده</legend>  
              <asp:DropDownList runat="server" ID="ddDefauleYear" AutoPostBack="True" OnSelectedIndexChanged="ddDefauleYear_SelectedIndexChanged" ></asp:DropDownList>
              <asp:GridView CssClass="gv" AutoGenerateColumns="false" runat="server" ID="grid1" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="grid1_PageIndexChanging" OnSorting="grid1_Sorting">
                  <Columns>
                <asp:TemplateField HeaderText="ردیف">
            <ItemTemplate>
                <asp:Label runat="server" ID="RowNum" Text='<%# Convert.ToString(Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))+1) %> '></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
<%--<asp:TemplateField HeaderText="حذف"> 
               <ItemTemplate>
                        <a id="ADel" class="ADelete"  href='<%# DataBinder.Eval(Container,"DataItem.CarID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>
                </ItemTemplate>
                </asp:TemplateField >--%>

            <asp:BoundField DataField="CompanyName"  HeaderText="نهاد"   SortExpression="CompanyName" />
<%--            <asp:BoundField DataField="DiscountTypeName"  HeaderText="تخفیف"   SortExpression="DiscountTypeName" />--%>
<asp:TemplateField HeaderText="کل درخواست ها"   SortExpression="c"><ItemTemplate><a href='<%# "/Manage/Manage.aspx?sid=-1&pid="+ Eval("pid").ToString() +"&companyID="+ Eval("CompanyIDdd").ToString()  %>'    > <%#Eval("c").ToString() %> </a></ItemTemplate></asp:TemplateField>     
<asp:TemplateField HeaderText="در انتظار"   SortExpression="DarEntezar"><ItemTemplate><a href='<%#"/Manage/Manage.aspx?sid=0&pid=" + Eval("pid") +"&companyID="+ Eval("CompanyIDdd").ToString() %>'       > <%#Eval("DarEntezar").ToString() %> </a></ItemTemplate></asp:TemplateField>     
<asp:TemplateField HeaderText="تایید شده"   SortExpression="taeeidshode"><ItemTemplate><a href='<%#"/Manage/Manage.aspx?sid=1&pid="+ Eval("pid") +"&companyID="+ Eval("CompanyIDdd").ToString() %>'      > <%#Eval("taeeidshode").ToString() %> </a></ItemTemplate></asp:TemplateField>     
    <asp:TemplateField HeaderText="رد شده"   SortExpression="radshodeh"><ItemTemplate><a href='<%#"/Manage/Manage.aspx?sid=2&pid="+ Eval("pid") +"&companyID="+ Eval("CompanyIDdd").ToString() %>'     > <%#Eval("radshodeh").ToString() %> </a></ItemTemplate></asp:TemplateField>     
                  
                     <%-- 
                             <asp:BoundField DataField="c"  HeaderText="کل درخواست ها"   SortExpression="c" />
            <asp:BoundField DataField="DarEntezar"  HeaderText="در انتظار"   SortExpression="DarEntezar" />
            <asp:BoundField DataField="taeeidshode"  HeaderText="تایید شده"   SortExpression="taeeidshode" />
            <asp:BoundField DataField="radshodeh"  HeaderText="رد شده"   SortExpression="radshodeh" />--%>



                  </Columns>
              </asp:GridView>



              </fieldset>
</asp:Content>
