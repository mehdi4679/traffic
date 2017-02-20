<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewManageMaster.master" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="TerraficPlan.Manage.NewsManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <!-- include libraries(jQuery, bootstrap, fontawesome) -->
<%--<script src="//code.jquery.com/jquery-1.9.1.min.js"></script> --%>
<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.1/css/bootstrap.min.css"> 
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.1/js/bootstrap.min.js"></script> 
<link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.min.css">

<!-- include codemirror (codemirror.css, codemirror.js, xml.js, formatting.js) -->
<link rel="stylesheet" type="text/css" href="//cdnjs.cloudflare.com/ajax/libs/codemirror/3.20.0/codemirror.min.css" />
<link rel="stylesheet" type="text/css" href="//cdnjs.cloudflare.com/ajax/libs/codemirror/3.20.0/theme/monokai.min.css" />
<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/codemirror/3.20.0/codemirror.min.js"></script>
<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/codemirror/3.20.0/mode/xml/xml.min.js"></script>
<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/codemirror/2.36.0/formatting.min.js"></script>

<!-- include summernote css/js-->
<%--<link href="summernote.css" />
<script src="summernote.min.js"></script>--%>
    <link href="/App_Themes/Theme1/dist/summernote.css" rel="stylesheet" />
    <script src="/App_Themes/Theme1/dist/summernote.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <!DOCTYPE html>
<html>
<div id="summernote"    >dscvsdvvs</div> 
    <div style="height:500px"></div>

    </html>
    
    <script type="text/javascript">
        $(document).ready(function () {

            $('.summernote').summernote();
        });
</script>
    </asp:Content>
