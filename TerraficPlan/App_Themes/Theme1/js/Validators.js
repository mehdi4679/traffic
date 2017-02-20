function ValidateNumber(event,id)
{             
    var key = event.keyCode || event.which;
    var article = $('#'+id); 
    if(navigator.appName == "Microsoft Internet Explorer" ||navigator.appName == "Opera")
    {
        if( ((112 <= key) && (key <= 125)) ) return false;
    }        
    else if( ((112 <= key) && (key <= 125)) )
    {
        article.attr("readonly","readonly");
        return true;
    }             
    if ((48 <= key  && key <= 57) ||(key == 13)|| (key == 8)|| (key == 9)||(37 == key  || key == 39)|| (key == 35)|| (key == 36)||key==46) 
    {   
        return true;
    }
    else return false;     
}
function Remove(id)
{
    $("#"+id).removeAttr('readonly');
}  
function UserAndPass(event,id)  
{
   var key = event.keyCode || event.which;
    var article = $('#'+id);
    if ((97 <= key && key <= 125) || (48 <= key && key <= 57) || (65 <= key && key <= 90) || (key == 13) || (key == 8) || (key == 46) || (key == 45) || (key == 95) || (key == 9) || (37 == key || key == 39) || (key == 35) || (key == 36)) 
    {                               
        return true;
    }
    else return false;
}
function ValidateEmail(event, id) {
    var key = event.keyCode || event.which;
    var article = $('#' + id);
    if ((48 <= key && key <= 57) || (97 <= key && key <= 125) || (65 <= key && key <= 90) || (key == 13) || (key == 64) || (key == 45) || (key == 95) || (key == 8) || (key == 46) || (key == 9) || (37 == key || key == 39) || (key == 35) || (key == 36)) {
        return true;
    }
    else return false;   
}
function ValidateScriptFarsi(event, id) {
    var key = event.keyCode || event.which;
    var article = $('#' + id);
    if ((key == 13) || (key == 32) || (1570 <= key) || (key == 8) || (key == 46) || (key == 9) || (37 == key || key == 39) || (key == 35) || (key == 36)) {
        return true;
    }
    else return false;
}
function ValidateScript(event,id)
{ 
    var key = event.keyCode || event.which;
    var article = $('#'+id);
    if ((97 <= key  && key <= 125)||(65 <= key  && key <= 90)||(key == 13)||(key == 32)||(1570 <= key) || (key == 8)||(key==46)|| (key == 9)||(37 == key  || key == 39)|| (key == 35)|| (key == 36)) 
    {                               
        return true;
    }
    else return false;                        
}

function CheckLengthDate(id)
{
    var value = $('#'+id).val();
    if(value != "")
    {
        if(value.length < 2)
            $('#'+id).val("0"+value);
        if((id == "txtDay" ||id == "txtDayStart"||id == "txtDayEnd") && 32 <= value)
            $('#'+id).val("31");
        if((id == "txtmonth"||id == "txtmonthStart"||id == "txtmonthEnd") && 13 <= value)
            $('#'+id).val("12");
        var year = new Date().getFullYear();
        if((id == "txtyear") && ((year-621) < value ))
        {                    
            $('#'+id).val(year-621);
        }                
    }           
}
function CheckTime(id)
{            
    var value = $('#'+id).val();
    if(value != "")
    {
         if(id == "txtHours" ||id == "txtHoursStart" ||id == "txtHoursEnd")
         {
            if(24 <= value )
                $('#'+id).val('23');
         }
         else
         {
            if(60 <= value )
                $('#'+id).val('59');
         }                 
    }
    CheckLengthDate(id);            
}