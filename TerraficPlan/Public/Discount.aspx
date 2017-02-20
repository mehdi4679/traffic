<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WizardDashboard.master" AutoEventWireup="true" CodeBehind="Discount.aspx.cs" Inherits="TerraficPlan.Public.Discount" %>

<%@ Register Src="../Controls/CtlDatePicker.ascx" TagName="CtlDatePicker" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        .dOwnertype {
            background-color: red;
        }

        .CarView {
            border-radius: 10px;
            border-style: solid;
            float: right;
            margin: 5px;
            padding: 5px;
            width: 200px;
        }

        .dpic {
            position: relative;
            float: right;
            padding: 5px;
            text-align: center;
        }

        .picc {
            width: 200px;
            height: 200px;
            border-radius: 10px;
        }

        .apic {
            position: absolute;
            top: 0px;
            right: 0px;
        }

        .dselecttype {
            width: 250px;
            float: right;
            background-color: #CDCDCD;
            padding: 5px;
            border-style: solid;
            border-radius: 5px;
            font-family: 'B Mitra',Tahoma;
            margin: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div style="min-height: 650px;">
        <asp:Label runat="server" ID="lblOwnerType" Text="1" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="LblRequestID" Text="0" Visible="false"></asp:Label>
        <div style="width: 100%">
            <div class="dselecttype ">
                <input style="padding-right: 10px" class="rdw1" type="radio" runat="server" name="dis" id="rbWhithOutDiscount" value="بدون تخفیف">بدون تخفیف</input></div>
            <div class="dselecttype ">
                <input style="padding-right: 10px" type="radio" name="dis" runat="server" id="rbWhithDiscount" value="با تخفیف" class="rdw" checked>با تخفیف</input></td></tr></table>


            </div>


        </div>
      <br /><br />
        <div id="DivDisount"  >
            <div class="alert alert-danger" style="height:50px;"> 
											<button data-dismiss="alert" class="close" type="button">
												<i class="ace-icon fa fa-times"></i>
											</button>

											<%--<strong>
												<i class="ace-icon fa fa-bullhorn"></i>
												توجه!
											</strong>--%>

                                                <table>
                                                <tr>
                                                <td>متقاضی:</td>
                                                <td>
                                                <asp:Label runat="server" ID="lblownerTypeNamee"></asp:Label></td>
                                                </tr>
                                                </table>
											<br>
										</div>
            
            <div style="width:100%">
                <fieldset>
                    <legend>نوع  و مدارک تخفیف</legend>
                    <div>توجه:به درخواست های تخفیف بدون ارایه مدرک ترتیب اثر داده نخواهد شد</div>

                    <table>
                        <tr>
                            <td>نوع تخفیف</td>

                            <td>

                                <asp:DropDownList runat="server" ID="DDDiscountType" CssClass="selecttt" style="width:100%"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                             
                            <td colspan="10">
                                <div class="alert alert-warning">
											<%--<button data-dismiss="alert" class="close" type="button">
												<i class="ace-icon fa fa-times"></i>
											</button>--%>
											<strong>مدارک مورد نیاز!</strong>

											  <div id="dalarm">
                                    <asp:Label runat="server" ID="lblalarmDiscountType"></asp:Label></div>
											 
										</div>
                               

                            </td>
                        </tr>
                        <tr>
                            <td >مدرک</td>
                            <td colspan="10">
                                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                        </tr>
                    </table>

                </fieldset>

                <asp:Button runat="server" ID="btnInsert" Text="ثبت" OnClick="btnInsert_Click" />
                <asp:Label runat="server" ID="lblDIscountID" Visible="false" Text="" ></asp:Label>
            </div>
            <div id="dPic">
                <asp:Repeater runat="server" ID="rpPic">
                    <ItemTemplate>
                        <div id="dPicView" class="dpic">
                            <%--  <a id="ADel" class="ADelete apic"  href='<%# DataBinder.Eval(Container,"DataItem.AttachID")%>' title="حذف"  onclick="return confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟')"  onserverclick="DeleteItem" runat="server"  ></a>--%>
                            <img runat="server" class="picc" id="img" src='<%# "/upload/"+Eval("AttachID")+ System.IO.Path.GetExtension(Eval("AttachName").ToString()) %>' /><br />
                            <%--<asp:Label runat="server" ID="lbltype" Text='<%# Eval("TypeName") %>'></asp:Label><br />
                <%#  DateConvert.m2sh(Eval("createDate").ToString())%>--%>
                            <asp:Label runat="server" ID="lblAttachID" Visible="false" Text='<%# Eval("AttachID") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <asp:Label runat="server" ID="lbltakhfif" Text="0" Visible="false"></asp:Label>
        <script>




            $(".rdw").on("click", function (event) {
                $('#DivDisount').fadeIn(1000);
            });
            $(".rdw1").on("click", function (event) {
                $('#DivDisount').fadeOut(1000);
            });

            if ($(".rdw").attr("checked") == "checked") {
                $('#DivDisount').fadeIn(1000);
            }
            if ($(".rdw1").attr("checked") == "checked") {
                $('#DivDisount').fadeOut();
            }
            $('.selecttt').on('change', function () {
                $('#dalarm').fadeOut(500);
                $('#dalarm').fadeIn(500);

                if (this.value == "1007")
                    $('#dalarm').html('ارایه تصویر کارت جانبازی الزامی است');
                if (this.value == "1008")
                    $('#dalarm').html('ارسال تصویر سند ملکی یا قولنامه با کد رهگیری و فیش برق منزل الزامی است');
                if (this.value == "1009")
                    $('#dalarm').html('استفاده از مرجع اطلاعاتی ,بدون نیاز به مدرک');

            })
            if ($('.selecttt').value == "1007")
                $('#dalarm').html('ارایه تصویر کارت جانبازی الزامی است');
            if ($('.selecttt').value == "1008")
                $('#dalarm').html('ارسال تصویر ملکی یا قولنامه با کد رهگیری و فیش برق منزل الزامی است');
            if ($('.selecttt').value == "1009")
                $('#dalarm').html('استفاده از مرجع اطلاعاتی ,بدون نیاز به مدرک');
        </script>

        <div class="wizard-actions">
            <a href="Car.aspx" class="btn btn-prev">
                <i class="ace-icon fa fa-arrow-right"></i>
                مرحله قبلی
            </a>

            <a href="#" runat="server" onserverclick="nextlink" data-last="Finish" class="btn btn-success btn-next">مرحله بعدی
													
            <i class="ace-icon fa fa-arrow-left icon-on-left"></i></a>
        </div>

    </div>
</asp:Content>
