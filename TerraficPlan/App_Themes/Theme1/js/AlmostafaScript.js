function ScriptHelper() {
    this.ShowLightBox = ShowLightBox;
    this.CloseLightBox = CloseLightBox;
    this.showconfirm = showconfirm;
    this.ShowAlertIsNumberkey = ShowAlertIsNumberkey;
    this.ShowAlertScoreNumber = ShowAlertScoreNumber;
    this.ShowAlertScoreRange = ShowAlertScoreRange;
    this.ShowUpdateProgress = ShowUpdateProgress;
    this.ShowUpdateProgressNotValidate = ShowUpdateProgressNotValidate;
    this.ShowAlertIsHoursekey = ShowAlertIsHoursekey;
    this.CloseUpdateProgress = CloseUpdateProgress;
}
var scripthelper = new ScriptHelper();
//var divnameforlightbox = LigtParent;

function ShowLightBox(ChildDiv, inputlightbox, divnameforlightbox) {
    //    $(".menu").css("visibility", "hidden");
    
    $('#' + divnameforlightbox + ' #' + ChildDiv).append("<a  class='close_icon'  title='بستن' onclick=scripthelper.CloseLightBox('" + ChildDiv + "','" + inputlightbox + "','" + divnameforlightbox + "') ></a>");
    document.getElementById("FilterDivForLightBox").className = "DivFilterShow";
    document.getElementById(divnameforlightbox).className = "Display";
    $('#' + divnameforlightbox + ' #' + ChildDiv).css("visibility", "visible");
    $(document).keypress(function (key) {
        if (key.keyCode == 27) {
            scripthelper.CloseLightBox(ChildDiv, inputlightbox, divnameforlightbox);
        }
    });
    return false;
}
function CloseLightBox(ChildDiv, inputlightbox, divnameforlightbox) {

    //$(".menu").css("visibility", "visible");
    $('#' + divnameforlightbox + ' #' + ChildDiv).css("visibility", "hidden");
    document.getElementById("FilterDivForLightBox").className = "DivFilter";
    document.getElementById(divnameforlightbox).className = "Display";
    if (inputlightbox != undefined && inputlightbox != "undefined") {
        document.getElementById(inputlightbox).value = "0"
    }
    return false;
}
//////////////// confirm
function showconfirm(msg) {
    if (document.getElementById(divnameforlightbox) == null) {
        $(document.body).append('<div id="lightboxdiv"  ></div>');
    }
    var result
    if (document.getElementById(divnameforlightbox).style.display == "none") {
        scripthelper.ShowLightBox();
        result = confirm(msg)
        scripthelper.CloseLightBox();
    }
    else {
        result = confirm(msg)
    }
    if (result) {
        scripthelper.ShowUpdateProgressNotValidate();
    }
    return result
}
///////////////////////////////////////
function ShowAlertScoreRange(elem) {
    if (elem > 20) {
        alert('عدد را بین 0 تا 20 وارد نمایید');
        return false;
    }
    return true;
}
function ShowAlertIsNumberkey(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function ShowAlertIsHoursekey(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 58)
    { return false; }
    else { return true; }
}
function ShowAlertScoreNumber(elem) {
    //var numericExpression = /^[0-9]+$/;
    // scripthelper.ShowAlertScoreRange(elem);
    var numericExpression = /[-+]?([0-9]*\.[0-9]+|[0-9]+)/;
    if (elem.length != 0) {
        if (elem.match(numericExpression)) {
            return true;
        } else {
            alert(elem);

            return false;
        }
    }

}
////////////////////////////updateprogress
function ShowUpdateProgress(ValidationGroup, ErrorMessage) {
    var validate = 0;
    if (ValidationGroup == undefined) {
        if (Page_ClientValidate()) {
            document.getElementById("UpdateProgressDiv").style.display = "inherit";
            document.getElementById("UpdateProgressInDiv").style.display = "inherit";
            validate = 1;
            return true;
        }

    }
    else {
        if (Page_ClientValidate(ValidationGroup)) {
            document.getElementById("UpdateProgressDiv").style.display = "inherit";
            document.getElementById("UpdateProgressInDiv").style.display = "inherit";
            validate = 1;
            return true;
        }

    }
    if (validate == 0 && ErrorMessage != undefined) {
        alert(ErrorMessage);
    }
    return false;
}
function ShowUpdateProgressNotValidate() {
    document.getElementById("UpdateProgressDiv").style.display = "inherit";
    document.getElementById("UpdateProgressInDiv").style.display = "inherit";
}
function CloseUpdateProgress() {
    document.getElementById("UpdateProgressDiv").style.display = "none"
    document.getElementById("UpdateProgressInDiv").style.display = "none";
}
////////////////////////////////////////////////////////
//////////////////Expersion////////////////////////////
//////////////////////////////////////////////////////////
var expression = new Expression()
function Expression() {

}
function Sort(obj) {
}

//function getPrint(print_area) {
//    alert(print_area);

//    //    print_area = document.getElementById('<%=GridView1.clientID %>').value
//    print_area = document.getElementById('<%=GridView1.clientID %>').value

//    //print_area = document.getElementById(print_area).value
//   //Creating new page
//    var pp = window.open();
//    //Adding HTML opening tag with <HEAD> … </HEAD> portion 
//    pp.document.writeln('<HTML><HEAD><title>Print Preview</title><LINK href=Styles.css  type="text/css" rel="stylesheet">')
//    pp.document.writeln('<LINK href=PrintStyle.css  type="text/css" rel="stylesheet" media="print"><base target="_self"></HEAD>')
//    //Adding Body Tag
//    pp.document.writeln('<body MS_POSITIONING="GridLayout" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">');
//    //Adding form Tag
//    pp.document.writeln('<form  method="post">');
//    //Creating two buttons Print and Close within a table
//    pp.document.writeln('<TABLE width=100%><TR><TD></TD></TR><TR><TD align=right><INPUT ID="PRINT" type="button" value="Print" onclick="javascript:location.reload(true);window.print();"><INPUT ID="CLOSE" type="button" value="Close" onclick="window.close();"></TD></TR><TR><TD></TD></TR></TABLE>');
//    //Writing print area of the calling page
//    //pp.document.writeln(document.getElementById('<%=g.clientID %>').innerHTML);
//    pp.document.writeln(document.getElementById('<%=prn.clientID %>').innerHTML);
//    //pp.document.writeln(document.getElementById("prn").innerHTML);
//    //Ending Tag of </form>, </body> and </HTML>
//    pp.document.writeln('</form></body></HTML>');


//}
