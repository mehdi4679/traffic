﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TerraficPlan.New.WebForm1" %>




<!DOCTYPE html>
<html lang="en">
    <head runat="server">
        <meta charset="utf-8" />
        <title>jQuery UI Datepicker with Twitter Bootstrap Theme</title>
        <link rel="stylesheet" href="bootstrap.min.css" />
        <link rel="stylesheet" href="bootstrap-datepicker.min.css" />
        <style>body{margin:2em}</style>
                <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
        <script src="bootstrap-datepicker.js"></script>
        <script src="bootstrap-datepicker.fa.min.js"></script>

    </head>
    <body>
        <h1>jQuery UI Datepicker with Twitter Bootstrap Theme</h1>
        <form>
            <div class="control-group">
                <label class="control-label" for="datepicker0">Datepicker</label>
                <div class="controls">
                    <input id="datepicker0" type="text">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="datepicker1">Datepicker with bootstrap icon button</label>
                <div class="controls">
                    <div class="input-append">
                        <input id="datepicker1" class="input-small" type="text">
                        <button id="datepicker1btn" class="btn" type="button"><i class="icon-calendar"></i></button>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="datepicker2">Datepicker with other months selectable (jQuery option)</label>
                <div class="controls">
                    <input type="text" id="datepicker2" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="datepicker3">Datepicker with 3 months and button panel (jQuery option)</label>
                <div class="controls">
                    <input type="text" id="datepicker3" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="datepicker4">Datepicker with change month/year (jQuery option)</label>
                <div class="controls">
                    <input type="text" id="datepicker4" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="datepicker5">Datepicker with limited selection to within the next 14 days (jQuery option)</label>
                <div class="controls">
                    <input type="text" id="datepicker5" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="datepicker6">Datepicker with RTL and date format (jQuery option)</label>
                <div class="controls">
                    <input id="datepicker6" type="text">
                </div>
            </div>
        </form>
        <script>
            $(document).ready(function () {
                $("#datepicker0").datepicker({
                    multidate: true 
                });

                $("#datepicker1").datepicker();
                $("#datepicker1btn").click(function (event) {
                    event.preventDefault();
                    $("#datepicker1").focus();
                })

                $("#datepicker2").datepicker({
                  multidate: true
                });

                $("#datepicker3").datepicker({
                    numberOfMonths: 3,
                    showButtonPanel: true
                });

                $("#datepicker4").datepicker({
                    changeMonth: true,
                    changeYear: true
                });

                $("#datepicker5").datepicker({
                    minDate: 0,
                    maxDate: "+14D"
                });

                $("#datepicker6").datepicker({
                    isRTL: true,
                    dateFormat: "d/m/yy"
                });
            });
        </script>
    </body>
</html>
