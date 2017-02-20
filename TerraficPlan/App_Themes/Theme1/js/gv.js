var Order ,OrderBy,pageid=1;

$(function () {
    var col = parseInt($("#gv").attr("col"));
    var colname = $("#gv").attr("colname").split(',');
    var j=0;
    var thead="<tr>";
    var tbody="<tr>";
    while(j<col)
    {
        var colid = colname[j].split(':');
        if (colid[1] != "" & col != (j+1) )
            thead += "<th class='Order' colid=" + colid[1] + " >" + colid[0] + " </th>"
        else
            thead += "<th  >" + colid[0] + " </th>"
        tbody+="<td></td>"
        j++;
    }
    var str = "<table  class='gv' id='gvTbl_student' >" + thead + "</tr>" + tbody + "</tr></table>";
    $("#gv").html(str);


    Tbl_student_Get(pageid);
});
$(".Pager .page").live("click", function () {
    pageid = parseInt($(this).attr('page'))
    Tbl_student_Get(pageid);
});
$(".Order").live("click", function () {
    if (Order == "" || Order == "desc")
        Order = "asc";
    else
        Order = "desc";
    OrderBy = $(this).attr("colid");
    Tbl_student_Get(pageid);
});

















function GoServer(_datatype, _type, _url, datao, onsuccess, lid) {
    var datao = JSON.stringify(datao);
    //  datao = datao.replace(/"/g, "'");
    jQuery.ajax({
        type: _type, url: GetUrlService(_url),
        contentType: 'application/json; charset=utf-8', dataType: _datatype, data: datao,
        success: function (d, s) { if (onsuccess != null) onsuccess(d, s); if (lid != null) lid.find('.loading').remove(); },
        beforeSend: function () { if (lid != null) { l = $('<img class="loading" src="/images/loading.gif">'); lid.append(l); } },
        error: function (xmlHttpRequest, status, err) { if (lid != null) lid.find(".loading").remove(); }
    });
}

function GetUrlService(url) {
    var qs = document.location.search.split('?')[1];
    return url + "?" + qs;
}
function LoadService(path, datao, onsuccess, lid) { GoServer('json', 'post', path, datao, onsuccess, lid); };






function del(id)
{
 //   alert(id);
    data = {};
    data.CLuser = {};
    data.CLuser.id = id;
    LoadService("gv.aspx/del", data, function (data, status) {
        if (data.d != null) {
            Tbl_student_Get(parseInt(1));
        }
    });
}

function Tbl_student_Get(pageIndex) {


    data = {};
    data.CLuser = {};
    data.CLuser.pageIndex = pageIndex;
    data.CLuser.Order = Order;
    data.CLuser.OrderBy = OrderBy;
    method = "Tbl_student_Get";
    LoadService("gv.aspx/" + method, data, function (data, status) {
        if (data.d != null) {
            OnSuccess(data)
        }
    });

    //$.ajax({
    //    type: "POST",
    //    url: "gv.aspx/Tbl_student_Get",
    //    data: '{pageIndex: ' + pageIndex + '}',
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: OnSuccess,
    //    failure: function (response) {
    //        alert(response.d);
    //    },
    //    error: function (response) {
    //        alert(response.d);
    //    }
    //});
}

function OnSuccess(response) {
    var xmlDoc = $.parseXML(response.d);
    var xml = $(xmlDoc);
    var i = 1;
    var Tbl_student = xml.find("Tbl_student");
    var row = $("[id*=gvTbl_student] tr:last-child").clone(true);
    $("[id*=gvTbl_student] tr").not($("[id*=gvTbl_student] tr:first-child")).remove();
    $.each(Tbl_student, function () {
        var customer = $(this);
        $("td", row).eq(0).html($(this).find("name").text());
        $("td", row).eq(1).html($(this).find("email").text());
        $("td", row).eq(2).html($(this).find("phone").text());
        $("td", row).eq(3).html('<img src="/images/edit16.png" title="Edit record." onclick="bindRecordToEdit(' + $(this).find("name").text() + ')" /><img src="/images/del16.png" title="delete." onclick="del(' + $(this).find("id").text() + ')" />');
        $("[id*=gvTbl_student]").append(row);
        row = $("[id*=gvTbl_student] tr:last-child").clone(true);
        i++;
    });
    var pager = xml.find("Pager");
    $(".Pager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(pager.find("PageIndex").text()),
        PageSize: parseInt(pager.find("PageSize").text()),
        RecordCount: parseInt(pager.find("RecordCount").text())
    });
};