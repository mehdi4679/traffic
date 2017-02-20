<%@ Page Title=""   Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs"  Inherits="TerraficPlan.Manage.WebForm3" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
 
		<meta name="description" content="" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/css/font-awesome.min.css" />

		<!-- page specific plugin styles -->
		<link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
<%--		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />--%>

		<!-- ace styles -->
		<%--<link rel="stylesheet" href="assets/css/ace.min.css" id="main-ace-style" />--%>

		<!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
		<link rel="stylesheet" href="assets/css/ace-skins.min.css" />
		<link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

		<!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- inline styles related to this page -->

		<!-- ace settings handler -->
		<script src="assets/js/ace-extra.min.js"></script>

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
  

		 
					<div class="ace-settings-container" id="ace-settings-container">
						<div class="btn btn-app btn-xs btn-warning ace-settings-btn" id="ace-settings-btn">
							<i class="ace-icon fa fa-cog bigger-150"></i>
						</div>

						<div class="ace-settings-box clearfix" id="ace-settings-box">
							<div class="pull-left width-50">
								<div class="ace-settings-item">
									<div class="pull-left">
										<select id="skin-colorpicker" class="hide">
											<option data-skin="no-skin" value="#438EB9">#438EB9</option>
											<option data-skin="skin-1" value="#222A2D">#222A2D</option>
											<option data-skin="skin-2" value="#C6487E">#C6487E</option>
											<option data-skin="skin-3" value="#D0D0D0">#D0D0D0</option>
										</select>
									</div>
									<span>&nbsp; انتخاب پوسته</span>
								</div>

								<div class="ace-settings-item">
									<%--<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-navbar" />--%>
									<label class="lbl" for="ace-settings-navbar"><a href="/New/News.aspx" >پنل عادی</a></label>
								</div>

								<div class="ace-settings-item">
									<%--<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-sidebar" />--%>
									<label class="lbl" for="ace-settings-sidebar"><a href="/Organ/PersonView.aspx"> پنل تخفیف</a></label>
								</div>

			<%--					<div class="ace-settings-item">
									<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-breadcrumbs" />
									<label class="lbl" for="ace-settings-breadcrumbs"> Fixed Breadcrumbs</label>
								</div>

								<div class="ace-settings-item">
									<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-rtl" />
									<label class="lbl" for="ace-settings-rtl"> Right To Left (rtl)</label>
								</div>

								<div class="ace-settings-item">
									<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-add-container" />
									<label class="lbl" for="ace-settings-add-container">
										Inside
										<b>.container</b>
									</label>
								</div>--%>


							</div><!-- /.pull-left -->

							<div class="pull-left width-50">
								<%--<div class="ace-settings-item">
									<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-hover" />
									<label class="lbl" for="ace-settings-hover"> Submenu on Hover</label>
								</div>

								<div class="ace-settings-item">
									<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-compact" />
									<label class="lbl" for="ace-settings-compact"> Compact Sidebar</label>
								</div>--%>

								<div class="ace-settings-item">
<%--									<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-highlight" />--%>
									<label class="lbl" for="ace-settings-highlight"><a href="/Manage/WebForm3.aspx">مدیریت خبر</a> </label>
								</div>
							</div><!-- /.pull-left -->
						</div><!-- /.ace-settings-box -->
					</div><!-- /.ace-settings-container -->

				 
						 
							<h1>مدیریت اخبار </h1>
						 

						<div class="row">
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS -->
								<h4 class="header green clearfix">
									محتوای خبر
									<span class="block pull-right">
										<small class="grey middle">انتخاب قالب: &nbsp;</small>

										<span class="btn-toolbar inline middle no-margin">
											<span data-toggle="buttons" class="btn-group no-margin">
												<label class="btn btn-sm btn-yellow">
													1
													<input type="radio" value="1" />
												</label>

												<label class="btn btn-sm btn-yellow active">
													2
													<input type="radio" value="2" />
												</label>

												<label class="btn btn-sm btn-yellow">
													3
													<input type="radio" value="3" />
												</label>

												<label class="btn btn-sm btn-yellow">
													4
													<input type="radio" value="4" />
												</label>
											</span>
										</span>
									</span>
								</h4>

								<div class="wysiwyg-editor editor1" id="editor1"></div>

								<div class="hr hr-double dotted"></div>

								 <div class="btn-group pull-right">
<%--											<input type="button" value="dddddd" onclick="getvalue();" runat="server" onserverclick="btnsave_ServerClick" />
                                     <asp:Button runat="server" ID="btnnn" Text="ذخیره خبر"	OnClick="btnsave_ServerClick" OnClientClick="getvalue();" />		--%>
<%--                                 <a  id="sssss"    onclick="getvalue();">sdsdssssssssss  </a> --%>
                                      <button runat="server" onclick="getvalue();" onserverclick="btnsave_ServerClick" class="btn btn-sm btn-danger btn-white btn-round" id="btnsave"    >
															<i class="ace-icon fa fa-floppy-o bigger-125"></i>
															ذخیره خبر
														</button>
                                    
													<%--	<button class="btn btn-sm btn-success btn-white btn-round">
															<i class="ace-icon fa fa-globe bigger-125"></i>

															Publish
															<i class="ace-icon fa fa-arrow-right icon-on-right bigger-125"></i>
														</button>--%>
													</div>

								<script type="text/javascript">
								    var $path_assets = "assets";//this will be used in loading jQuery UI if needed!
								</script>

								<!-- PAGE CONTENT ENDS -->
							</div><!-- /.col -->
						</div><!-- /.row -->
				 
    
			 

			<a href="wysiwyg.html#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
				<i class="ace-icon fa fa-angle-double-up icon-only bigger-110"></i>
			</a>
	<input runat="server" id="txtcontent" type="hidden" value=""/>
    <asp:Label runat="server" ID="lblNewsID" Text="0" Visible="false"></asp:Label>
		<!-- basic scripts -->

		<!--[if !IE]> -->
		<script src="assets/js/jquery.min.js"></script>

		<!-- <![endif]-->

		<!--[if IE]>
<script src="assets/js/jquery1x.min.js"></script>
<![endif]-->

		<!--[if !IE]> -->
		<script type="text/javascript">
		    window.jQuery || document.write("<script src='assets/js/jquery.min.js'>" + "<" + "/script>");
		</script>

		<!-- <![endif]-->

		<!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='assets/js/jquery1x.min.js'>"+"<"+"/script>");
</script>
<![endif]-->
		<script type="text/javascript">
		    if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		<script src="assets/js/bootstrap.min.js"></script>

		<!-- page specific plugin scripts -->
		<script src="assets/js/jquery-ui.custom.min.js"></script>
		<script src="assets/js/jquery.ui.touch-punch.min.js"></script>
		<script src="assets/js/markdown/markdown.min.js"></script>
		<script src="assets/js/markdown/bootstrap-markdown.min.js"></script>
		<script src="assets/js/jquery.hotkeys.min.js"></script>
		<script src="assets/js/bootstrap-wysiwyg.min.js"></script>
		<script src="assets/js/bootbox.min.js"></script>

		<!-- ace scripts -->
		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>

		<!-- inline scripts related to this page -->
		<script type="text/javascript">
		    jQuery(function ($) {

		        function showErrorAlert(reason, detail) {
		            var msg = '';
		            if (reason === 'unsupported-file-type') { msg = "Unsupported format " + detail; }
		            else {
		                //console.log("error uploading file", reason, detail);
		            }
		            $('<div class="alert"> <button type="button" class="close" data-dismiss="alert">&times;</button>' +
                     '<strong>File upload error</strong> ' + msg + ' </div>').prependTo('#alerts');
		        }

		        //$('#editor1').ace_wysiwyg();//this will create the default editor will all buttons

		        //but we want to change a few buttons colors for the third style
		        (function ($) {
		            $(document).ready(function () {
		                //$("#editor1").val(document.getElementById('txtcontent'));
		                $('.editor1').html(document.getElementById('<%= txtcontent.ClientID %>').value)
		            });
		        })(jQuery);
                
	


		        $('#editor1').ace_wysiwyg({
		            toolbar:
                    [
                        'font',
                        null,
                        'fontSize',
                        null,
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        { name: 'insertImage', className: 'btn-success' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ],
		            'wysiwyg': {
		                fileUploadError: showErrorAlert
		            }
		        }).prev().addClass('wysiwyg-style2');


		        /**
                //make the editor have all the available height
                $(window).on('resize.editor', function() {
                    var offset = $('#editor1').parent().offset();
                    var winHeight =  $(this).height();
                    
                    $('#editor1').css({'height':winHeight - offset.top - 10, 'max-height': 'none'});
                }).triggerHandler('resize.editor');
                */


		        $('#editor2').css({ 'height': '200px' }).ace_wysiwyg({
		            toolbar_place: function (toolbar) {
		                return $(this).closest('.widget-box')
                               .find('.widget-header').prepend(toolbar)
                               .find('.wysiwyg-toolbar').addClass('inline');
		            },
		            toolbar:
                    [
                        'bold',
                        { name: 'italic', title: 'Change Title!', icon: 'ace-icon fa fa-leaf' },
                        'strikethrough',
                        null,
                        'insertunorderedlist',
                        'insertorderedlist',
                        null,
                        'justifyleft',
                        'justifycenter',
                        'justifyright'
                    ],
		            speech_button: false
		        });




		        $('[data-toggle="buttons"] .btn').on('click', function (e) {
		            var target = $(this).find('input[type=radio]');
		            var which = parseInt(target.val());
		            var toolbar = $('#editor1').prev().get(0);
		            if (which >= 1 && which <= 4) {
		                toolbar.className = toolbar.className.replace(/wysiwyg\-style(1|2)/g, '');
		                if (which == 1) $(toolbar).addClass('wysiwyg-style1');
		                else if (which == 2) $(toolbar).addClass('wysiwyg-style2');
		                if (which == 4) {
		                    $(toolbar).find('.btn-group > .btn').addClass('btn-white btn-round');
		                } else $(toolbar).find('.btn-group > .btn-white').removeClass('btn-white btn-round');
		            }
		        });




		        //RESIZE IMAGE

		        //Add Image Resize Functionality to Chrome and Safari
		        //webkit browsers don't have image resize functionality when content is editable
		        //so let's add something using jQuery UI resizable
		        //another option would be opening a dialog for user to enter dimensions.
		        if (typeof jQuery.ui !== 'undefined' && ace.vars['webkit']) {

		            var lastResizableImg = null;
		            function destroyResizable() {
		                if (lastResizableImg == null) return;
		                lastResizableImg.resizable("destroy");
		                lastResizableImg.removeData('resizable');
		                lastResizableImg = null;
		            }

		            var enableImageResize = function () {
		                $('.wysiwyg-editor')
                        .on('mousedown', function (e) {
                            var target = $(e.target);
                            if (e.target instanceof HTMLImageElement) {
                                if (!target.data('resizable')) {
                                    target.resizable({
                                        aspectRatio: e.target.width / e.target.height,
                                    });
                                    target.data('resizable', true);

                                    if (lastResizableImg != null) {
                                        //disable previous resizable image
                                        lastResizableImg.resizable("destroy");
                                        lastResizableImg.removeData('resizable');
                                    }
                                    lastResizableImg = target;
                                }
                            }
                        })
                        .on('click', function (e) {
                            if (lastResizableImg != null && !(e.target instanceof HTMLImageElement)) {
                                destroyResizable();
                            }
                        })
                        .on('keydown', function () {
                            destroyResizable();
                        });
		            }

		            enableImageResize();

		            /**
                    //or we can load the jQuery UI dynamically only if needed
                    if (typeof jQuery.ui !== 'undefined') enableImageResize();
                    else {//load jQuery UI if not loaded
                        $.getScript($path_assets+"/js/jquery-ui.custom.min.js", function(data, textStatus, jqxhr) {
                            enableImageResize()
                        });
                    }
                    */
		        }


		    });



		    function getvalue() {
		        var r =   $('.wysiwyg-editor').html();
		        //alert(r);
		        document.getElementById('<%= txtcontent.ClientID %>').value = r;
		        return;
		    }
		</script>
	 
</asp:Content>
