//-----------------------------------------------------------
String.prototype.replaceAll = function (strTarget, strSubString) {
    var strText = this;
    var intIndexOfMatch = strText.indexOf(strTarget);
    while (intIndexOfMatch != -1) {
        strText = strText.replace(strTarget, strSubString)
        intIndexOfMatch = strText.indexOf(strTarget);
    }
    return (strText);
}

// این قسمت مختصات اشاره گر موس را ذخیره میکند
// Detect if the browser is IE or not.
// If it is not IE, we assume that the browser is NS.
var IE = document.all ? true : false
// If NS -- that is, !IE -- then set up for mouse capture
if (!IE) document.captureEvents(Event.MOUSEMOVE)
// Set-up to use getMouseXY function onMouseMove
document.onmousemove = getMouseXY;
// Temporary variables to hold mouse x-y pos.s
var mouseX = 0
var mouseY = 0
// Main function to retrieve mouse x-y pos.s
function getMouseXY(e) {
    try {
        if (IE) { // grab the x-y pos.s if browser is IE
            mouseX = event.clientX + document.body.scrollLeft
            mouseY = event.clientY + document.body.scrollTop
        } else {  // grab the x-y pos.s if browser is NS
            mouseX = e.pageX
            mouseY = e.pageY
        }
        // catch possible negative values in NS4
        if (mouseX < 0) { mouseX = 0 }
        if (mouseY < 0) { mouseY = 0 }
    }
    catch (e) {mouseX = 300;mouseY = 300; }
    return true
}

var AppName = "Decili";

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}

 
function isChild(s,d) {
	while(s) {
		if (s==d) 
			return true;
		s=s.parentNode;
	}
	return false;
}

function IsOnlyNumber()
{

var returnValue = false;
var keyCode = (window.event.which) ? window.event.which : window.event.keyCode;
if ( ((keyCode >= 48) && (keyCode <= 57)) ||
(keyCode == 8) ||
(keyCode == 9) ||
(keyCode == 46) || 
(keyCode == 46) || 
(keyCode == 13) ) 
returnValue = true;

if ( window.event.returnValue )
window.event.returnValue = returnValue;
return returnValue;
}
function IsOnlyNumberAndSlash()
{
var returnValue = false;
var keyCode = (window.event.which) ? window.event.which : window.event.keyCode;
if ( ((keyCode >= 47) && (keyCode <= 57)) ||
(keyCode == 8) || 
(keyCode == 9) || 
(keyCode == 13) ) 
returnValue = true;

if ( window.event.returnValue )
window.event.returnValue = returnValue;

return returnValue;
}

function GotoUrl(Url)
{
    window.location.href = Url
}

function getObj(objID)
{
    if (document.getElementById) {return document.getElementById(objID);}
    else if (document.all) {return document.all[objID];}
    else if (document.layers) {return document.layers[objID];}
}

/****************************************** LookUpTree ************************************************/


/****************************************** LookUpTree ************************************************/

var http_request = null;
var DelObj = null;
function startRequest(url, Func, Method, Param, UpdateObj) { 
    DelObj = UpdateObj;
    if (window.XMLHttpRequest) { 
       http_request = new XMLHttpRequest(); 
    } 
    else if (window.ActiveXObject) { 
       http_request = new ActiveXObject('Microsoft.XMLHTTP'); 
    } 
    url = url + '&rnd=' + Math.random();
    http_request.onreadystatechange = Func;
    http_request.open(Method, url, true); 
    if( Method == 'GET')
       http_request.send(null); 
    else
       http_request.send(Param); 
} 



function CorrectText(str)
{
    return str.replace('ی', 'ی').replace('ی', 'ی').replace('ى', 'ی').replace('ك', 'ک')
            .replace('٠', '۰').replace('١', '۱').replace('٢', '۲').replace('٣', '۳').replace('٤', '۴')
            .replace('٥', '۵').replace('٦', '۶').replace('٧', '۷').replace('٨', '۸').replace('٩', '۹')
}

function UnEnc(str) {
    str = str.replaceAll("۰", "0")
    str = str.replaceAll("۱", "1")
    str = str.replaceAll("۲", "2")
    str = str.replaceAll("۳", "3")
    str = str.replaceAll("۴", "4")
    str = str.replaceAll("۵", "5")
    str = str.replaceAll("۶", "6")
    str = str.replaceAll("۷", "7")
    str = str.replaceAll("۸", "8")
    str = str.replaceAll("۹", "9")
    return str;

}
function ChangeEnc(str) {
    str = str.replaceAll("0", "۰")
    str = str.replaceAll("1", "۱")
    str = str.replaceAll("2", "۲")
    str = str.replaceAll("3", "۳")
    str = str.replaceAll("4", "۴")
    str = str.replaceAll("5", "۵")
    str = str.replaceAll("6", "۶")
    str = str.replaceAll("7", "۷")
    str = str.replaceAll("8", "۸")
    str = str.replaceAll("9", "۹")
    return str;
}



function createCookie(name,value,days) {
	if (days) {
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "; expires="+date.toGMTString();
	}
	else var expires = "";
	document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) {
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
}

function eraseCookie(name) {
	createCookie(name,"",-1);
}

function ChangeEnc2(str)
{
    var Result = str;
/*
    Result = Result.replaceAll("0", "۰");
    Result = Result.replaceAll("1", "۱");
    Result = Result.replaceAll("2", "۲");
    Result = Result.replaceAll("3", "۳");
    Result = Result.replaceAll("4", "۴");
    Result = Result.replaceAll("5", "۵");
    Result = Result.replaceAll("6", "۶");
    Result = Result.replaceAll("7", "۷");
    Result = Result.replaceAll("8", "۸");
    Result = Result.replaceAll("9", "۹");
    */

    return Result;
} 



function ActivateTextBox(objTextBox) {
    objTextBox.className = 'ActiveTextBox'
    if (objTextBox.value == 'جستجو ...')
        objTextBox.value = '';
}

function updateClock() {
    var currentTime = new Date();

    var currentHours = currentTime.getHours();
    var currentMinutes = currentTime.getMinutes();
    var currentSeconds = currentTime.getSeconds();

    // Pad the minutes and seconds with leading zeros, if required
    currentMinutes = (currentMinutes < 10 ? "0" : "") + currentMinutes;
    currentSeconds = (currentSeconds < 10 ? "0" : "") + currentSeconds;

    // Choose either "AM" or "PM" as appropriate
    var timeOfDay = (currentHours < 12) ? "AM" : "PM";

    // Convert the hours component to 12-hour format if needed
    currentHours = (currentHours > 12) ? currentHours - 12 : currentHours;

    // Convert an hours component of "0" to "12"
    currentHours = (currentHours == 0) ? 12 : currentHours;

    // Compose the string for display
    var currentTimeString = ChangeEnc(currentHours) + ":" + ChangeEnc(currentMinutes) + ":" + ChangeEnc(currentSeconds); //  + " " + timeOfDay;

    // Update the time display
    //document.getElementById("clock").innerHTML = currentTimeString;
}

function loadBack2Up() {
    var pxShow = 300;
    var fadeInTime = 1000;
    var fadeOutTime = 1000;
    var scrollSpeed = 1000;
    $(window).scroll(function () {
        if ($(window).scrollTop() >= pxShow) {
            $("#backtotop").fadeIn(fadeInTime);
        } else {
            $("#backtotop").fadeOut(fadeOutTime);
        }
    });

    $('#backtotop a').click(function () {
        $('html, body').animate({ scrollTop: 0 }, scrollSpeed);
        return false;
    });
}

$(function () {
    $(document).ready(function () {
        loadBack2Up();

        window.focus();

    });
});


var IsLoadingMoreNews = false;
var LatestPageNo = 1;
function LoadMoreNews() {
    //return;
    if(IsLoadingMoreNews)
    return;

    var PreviuousPage = LatestPageNo;
    LatestPageNo++;

    $("#LoadMoreArea" + PreviuousPage).html("<img src='images/bigloading.gif' />");
    IsLoadingMoreNews = true;
    $.ajax({
        type: "POST",
        async: true,
        cache: false,
        dataType: "html",
        data: { PageNo: LatestPageNo },
        url: "postback/MoreNews.aspx",
        success: function (data) {
            IsLoadingMoreNews = false;
            $("#LoadMoreArea" + PreviuousPage).html(data);

            
        }
    });
}

function ScrollToItem(elementtoScrollToID) {
    $('html, body').animate({
        scrollTop: $("#News" + elementtoScrollToID).offset().top
    }, 2000);
}

function ShowMore(ContentID) {
    $("#" + ContentID).slideToggle("slow");
}



var SubMenuLoaded = 0;
var StaticShow = 0;

$(document).ready(function () {
    

    $('#txtKeyword').keydown(function (event) {
        if (event.keyCode == 13) {
            Keyword = $('#txtKeyword').val()
            Keyword = Keyword.replaceAll(" ", "%20");
            window.location.href = '/s1-' + Keyword + ".html";
            return false;
        }
    });

});


function showPass(b) {
    var a = b.closest("div").find("input");
    a.get(0).type = "text";
    b.css("background-color", "#FCEC63") 
}
function hidePass(b) {
    var a = b.closest("div").find("input");
    a.get(0).type = "password";
    b.css("background-color", "") 
};

function checkBrowser(e) {
    if (window.event)
        key = window.event.keyCode;     //IE
    else
        key = e.which; //firefox
    return key;
}

function SearchKeyword(Keyword) {
    Keyword = Keyword.replaceAll(" ", "%20");
    window.location.href = '/?Keyword=' + Keyword;
}
