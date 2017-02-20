var Order="desc" ,OrderBy="CaID", pageid = 1;

$(function () {
    var col = parseInt($("#gv").attr("col"));
    var colname = $("#gv").attr("colname").split(',');
    var j = 0;
    var thead = "<tr>";
    var tbody = "<tr>";
    while (j < col) {
        var colid = colname[j].split(':');
        if (colid[1] != "" & col != (j + 1))
            thead += "<th class='Order' colid=" + colid[1] + " >" + colid[0] + " </th>"
        else
            thead += "<th  >" + colid[0] + " </th>"
        tbody += "<td></td>"
        j++;
    }
    var str = "<table  class='gv' id='gvTbl_student' >" + thead + "</tr>" + tbody + "</tr></table>";
    $("#gv").html(str);


    Tbl_Catalog_Get(pageid);
});
$(".Pager .page").on("click", function () {
    pageid = parseInt($(this).attr('page'))
    Tbl_Catalog_Get(pageid);
});
$(".Order").on("click", function () {
    if (Order == "" || Order == "desc")
        Order = "asc";
    else
        Order = "desc";
    OrderBy = $(this).attr("colid");
    Tbl_Catalog_Get(pageid);
});

function SetData(caid) {
  
    data = {};
    data.cl = {};
    data.cl.CID = caid;
    data.cl.PageIndex = pageid;
    method = "get";
    LoadService("Catalog.aspx/" + method, data, function (data, status) {
        if (data.d != null) {
            var xmlDoc = $.parseXML(data.d);
            var xml = $(xmlDoc);
            var Tbl_student = xml.find("Tbl_Catalog");
            $.each(Tbl_student, function () {
                var customer = $(this);
                $("#txtcaid").val($(this).find("CaID").text());
                $('#txttitle').val($(this).find("CatalogName").text());
                $('.txtCatalogType option:selected').val($(this).find("CatalogTypeID").text());

            }) ;
        }
        
    });
    openlight(caid)
         
}
function openlight(txtcaid) {
       //  document.getElementById('lightbox').value = '1';
        document.getElementById('txtcaid').value = txtcaid;
     //    setTimeout(scripthelper.ShowLightBox("lightinsert", 'lightbox', "lightboxdiv"),0)
    }  
 


function SendData(id) {
      Order = "desc", OrderBy = "CaID", pageid = 1;
    data = {};
    data.cl = {};
    data.cl.CID = $("#txtcaid").val();
    data.cl.CatalogTypeID = $('.txtCatalogType option:selected').val().replace(/'/gi, "\\'");
    data.cl.CatalogName = $('#txttitle').val().replace(/'/gi, "\\'");
    method = "Create";
    LoadService("Catalog.aspx/" + method, data, function (data, status) {
        try {
            ShowMessage("<span class='OKMessage'>" + data.d + "</span>");
            Tbl_Catalog_Get(pageid);
        }
        catch (err) {
            ShowMessage("خطا در درج اطلاعات");
        }
    }, $('#Loading'));
    document.getElementById('txtcaid').value = '0';
}




function ShowMessage(m) {
   // $("#Message").html(m);
    $("#SpanMessage").html(m)
//    $("#Message").dialog({
//        modal: true,
//        width: 400,
//        buttons: {
//            "OK": function () {
//                $(this).dialog('close');
//            }
//        }
//    });
    return false;
}







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





function defaultid(id) {
    
    data = {};
    data.cl = {};
    data.cl.CID = id;
    LoadService("Catalog.aspx/Default", data, function (data, status) {
        if (data.d != null) {
            Tbl_Catalog_Get(parseInt(1));

        }
    });
}
function del(id) {
    if (!confirm('اطلاعات مربوط  حذف خواهد شد !!  آیا مطمئن هستید ؟'))
        return;
    data = {};
    data.cl = {};
    data.cl.CID = id;
    LoadService("Catalog.aspx/delete", data, function (data, status) {
        if (data.d != null) {
            Tbl_Catalog_Get(parseInt(1));

        }
    });
}

function Tbl_Catalog_Get(PageIndex) {
    data = {};
    data.cl = {};
    data.cl.PageIndex = PageIndex;
     data.cl.OrderDirection = Order;
     data.cl.OrderBy = OrderBy;
     data.cl.CatalogTypeID = $('.txtCatalogType option:selected').val();
    method = "get";
    LoadService("Catalog.aspx/" + method, data, function (data, status) {
        if (data.d != null) {
            OnSuccess(data)
        }
    });


}

function run(el){
    data = {};
    data.cl = {};
    data.cl.PageIndex = pageid;
    data.cl.OrderDirection = Order;
    data.cl.OrderBy = OrderBy;
    data.cl.CatalogTypeID = el.options[el.selectedIndex].value;
    method = "get";
    LoadService("Catalog.aspx/" + method, data, function (data, status) {
        if (data.d != null) {
            OnSuccess(data)
        }
    });
}

function OnSuccess(response) {
    var xmlDoc = $.parseXML(response.d);
    var xml = $(xmlDoc);
    var i = 1;
    var Tbl_student = xml.find("Tbl_Catalog");
    var row = $("[id*=gvTbl_student] tr:last-child").clone(true);
    $("[id*=gvTbl_student] tr").not($("[id*=gvTbl_student] tr:first-child")).remove();
    $.each(Tbl_student, function () {
        var customer = $(this);
        $("td", row).eq(0).html($(this).find("CatalogName").text());
        $("td", row).eq(1).html($(this).find("CatalogValue").text());
        $("td", row).eq(2).html($(this).find("EntityName").text());
        $("td", row).eq(3).html('<a class="AEdit" title="Edit record." href=#' + $(this).find("CaID").text() + ' onclick="SetData(' + $(this).find("CaID").text() + ')" /><a class="ADelete"  href=#' + $(this).find("CaID").text() + ' title="delete." onclick="del(' + $(this).find("CaID").text() + ')" /><a class="' + $(this).find("atrue").text() + '" href=#' + $(this).find("CaID").text() + ' title="پیش فرض" onclick="defaultid(' + $(this).find("CaID").text() + ')" />');
       // $("td", row).eq(3).html('<img src="/images/edit16.png" title="Edit record." onclick="bindRecordToEdit(' + $(this).find("CaID").text() + ')" /><img src="/images/del16.png" title="delete." onclick="del(' + $(this).find("CaID").text() + ')" />');
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