var AfterDeletBaseID = null;
var AppName = "SDB"
function DeleteItem(FileName, MasterCode, DelList)
{
	AskResult = confirm("حذف شود ؟")

	if(AskResult){
		window.onbeforeunload = '';
		window.location.href=FileName + '?DelList=' + DelList + '&Code=' + MasterCode
	}
}
function PrintJournal()
{
	window.print()
}
function DeleteFromEditForm(BaseID, DelCode)
{
    AskDel = confirm("آیا از حذف این رکورد مطمئن هستید ؟")
    if(AskDel)
    {
        DelUrl = '../jsGetBrowse.aspx?BaseID=' + BaseID + "&DelCode=" + DelCode 
        AfterDeletBaseID = BaseID
        startRequest(DelUrl, ShowDeleteComplete, 'GET', null, null);
    }

}
function ShowDeleteComplete()
{
    if(http_request != null)
    {
       if (http_request.readyState == 4) { 
           if (http_request.status == 200) { 
	            result = http_request.responseText
	            if(result=="DELETED")
	            {
	                alert('رکورد با موفقیت حذف شد')
	                if(AfterDeletBaseID != null)
	                    window.location.href = '../Main/Default.aspx?BaseID='+ AfterDeletBaseID
	                else
	                    window.location.href = '../Admin';
	            }
	            else if(result.indexOf("FK_")>0)
	                alert('این رکورد دارای اطلاعات مرتبط میباشد و قابل حذف نیست')
	            document.body.style.cursor='auto';
            }
       }
   }
}

function IsOnlyNumber()
{

var returnValue = false;
var keyCode = (window.event.which) ? window.event.which : window.event.keyCode;
if ( ((keyCode >= 48) && (keyCode <= 57)) ||
(keyCode == 8) || 
(keyCode == 9) || 
(keyCode == 46) || 
(keyCode == 45) || 
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


function ConfirmUnload()
{
    event.returnValue = "تغییرات نادیده گرفته شود؟";
}
function GetInfo(InputObj, BaseID)
{
	Code = InputObj.value
	document.body.style.cursor='wait';
	
	// Create an instance of the XML HTTP Request object
	var oXMLHTTP = new ActiveXObject( "Microsoft.XMLHTTP" );
		
	// Prepare the XMLHTTP object for a HTTP POST to our validation ASP page
	var sURL = "../Seminars/GetInfo.asp?Code=" + Code + '&BaseID=' + BaseID
	oXMLHTTP.open( "POST", sURL, false );
	
	// Execute the request
	oXMLHTTP.send();
	
	rsl = oXMLHTTP.responseText
	InputObj.parentNode.parentNode.cells(2).childNodes(0).value = rsl
	if(rsl == 'رکورد مورد نظر یافت نشد')
		InputObj.parentNode.parentNode.cells(1).childNodes(0).value = ''
	document.body.style.cursor='auto';
	
}
function ImgOver(ImgObj)
{
	ImgObj.style.borderWidth = 1
	ImgObj.style.borderColor = 'black'
}
function ImgOut(ImgObj)
{
	ImgObj.style.borderWidth = 0
}

function DoPrint()
{
	window.print()
}
function AskDelete(Code)
{
	AskResult = confirm("رکورد حذف شود؟")
	if(AskResult){
		form1.DelValue.value = Code;
		form1.action = "index.aspx"
		form1.submit()
	}
}

function AskDeleteDetail(FromAction, MasterCode, Code)
{
	AskResult = confirm("رکورد حذف شود؟")
	if(AskResult){
		window.onbeforeunload = '';
		form1.DelList.value = Code;
		form1.Code.value = MasterCode ;
		form1.action = FromAction
		form1.submit()
	}
}

function GotoLink(FormAction)
{
	if( FormAction != "undefined")
		form1.action = FormAction
	form1.submit();
}

function GotoUrl(Url)
{
    window.location.href = Url
}

function PickDate(DateFieldName, InitVal, Section)
{
	InitVal = InitVal.replace("/", "");
	InitVal = InitVal.replace("/", "");
	
	X =  window.event.clientX
	Y =  window.event.clientY + 100
	if ( InitVal.length != 8)
		InitVal = '';
	whn = 	window.open('../DatePicker.asp?FFN=' + DateFieldName + '&InitDate=' + InitVal + '&Section=' + Section,'DatePicker','width=200,height=185,menubar=no,status=no,titlebar=no,resizable=no,top=' + Y + ',left=' + X );
}

function UploadPic(FileName)
{
		whList = window.open(FileName + '?' + FieldName + '=' +  Code,'','width=580,height=150,menubar=no,status=no,titlebar=no,resizable=no,top=200,left=150');
}

function ShowTree(FileName, BaseID, FFN, InitCode)
{
		whList = window.open(FileName + '?BaseID=' + BaseID + '&FFN=' + FFN + '&InitGroup=' + InitCode,'PersonTree','width=580,height=450,menubar=no,status=no,titlebar=no,resizable=no,top=200,left=150');
}

function ShowFile(FileName, FieldName, Code)
{
		whList = window.open(FileName + '?' + FieldName + '=' +  Code,'','width=620,height=450,menubar=no,status=no,titlebar=no,resizable=no,scrollbars,top=200,left=150');
}

function ShowFile3(FileName, FieldName, Code)
{
		whList = window.open(FileName + '?' + FieldName + '=' +  Code,'','width=620,height=450,menubar=yes,status=no,titlebar=no,resizable=no,scrollbars,top=200,left=150');
}

function ShowFile2(PathName)
{
	whList = window.open(PathName,'','width=620,height=450,menubar=no,status=no,titlebar=no,resizable=no,scrollbars,top=200,left=150');
}

function ShowSizedFile(FileName, FieldName, Code,w, h)
{
	whList = window.open(FileName + '?' + FieldName + '=' +  Code,'','width='+ w + ',height=' + h + ',menubar=no,status=no,titlebar=no,resizable=no,top=200,left=150');
}

function OpenList(BaseID, ImgObj)
{
    var LookupObj = new XMLBrowse()

	if( getObj('LookupResults'))
	{
        getObj('LookupResults').style.display='none';
	}
    ShowMode = 'List';
    FormFieldCode = ImgObj.parentNode.parentNode.parentNode.parentNode.rows[0].cells[1].childNodes[0];
    FormFieldName = ImgObj.parentNode.parentNode.parentNode.parentNode.rows[0].cells[0].childNodes[0];
    LookupObj.ViewEdit = 'Edit'
    LookupObj.CreateBrowse(BaseID, ShowMode);
    //BrowseObj = new XMLBrowse(BaseID, ShowMode);

//	whList = window.open('../List.aspx?BaseID=' + BaseID + '&FFC=' + FormFieldCode + '&FFN=' + FormFieldName ,'','scrollbars=yes, width=650,height=450,menubar=no,status=no,titlebar=no,resizable=yes,top=200,left=150');
}

function OpenListMaster(BaseID, ImgObj, MasterCode)
{
    if(MasterCode == '')
    {
        alert('لطفا ابتدا شرکت بیمه را انتخاب کنید')
        return false;
    }
        FormFieldCode = ImgObj.parentNode.parentNode.parentNode.parentNode.rows[0].cells[1].childNodes[0].name;
        FormFieldName = ImgObj.parentNode.parentNode.parentNode.parentNode.rows[0].cells[0].childNodes[0].name;

		whList = window.open('../List.aspx?MasterCode=' + MasterCode + '&BaseID=' + BaseID + '&FFC=' + FormFieldCode + '&FFN=' + FormFieldName ,'','scrollbars=yes, width=650,height=450,menubar=no,status=no,titlebar=no,resizable=yes,top=200,left=150');
}

function OpenTree(BaseID, ImgObj)
{
        FormFieldCode = ImgObj.parentNode.parentNode.parentNode.parentNode.rows[0].cells[1].childNodes[0].name;
        FormFieldName = ImgObj.parentNode.parentNode.parentNode.parentNode.rows[0].cells[0].childNodes[0].name;

		whList = window.open('../GetTree.aspx?GetVal=1&BaseID=' + BaseID + '&FFC=' + FormFieldCode + '&FFN=' + FormFieldName ,'','width=450,height=450,menubar=no,status=no,titlebar=no,resizable=yes,scrollbars,top=200,left=150');
}

function OpenTree2(BaseID, Width, Height,GroupCode)
{
		whList = window.open('../GetTree.aspx?MultiSelect=1&BaseID=' + BaseID + '&GroupCode=' + GroupCode ,'','width=' + Width + ',height=' + Height + ',menubar=no,status=no,titlebar=no,resizable=no,top=200,left=150');
}

function List2(BaseID, FormFieldName,Section, FN, FV)
{
		whList = window.open('../Admin/List.asp?BaseID=' + BaseID + '&FFN=' + FormFieldName + '&Section=' + Section + '&FN=' + FN + '&FV=' + FV,'','width=450,height=450,menubar=no,status=no,titlebar=no,resizable=no,top=200,left=150');
}

function ListMulti(BaseID, FormFieldName,Section)
{
		whList = window.open('../Admin/ListMulti.asp?BaseID=' + BaseID + '&FFN=' + FormFieldName + '&Section=' + Section ,'','width=450,height=450,menubar=no,status=no,titlebar=no,resizable=no,top=200,left=150');
}


function ShowList(FileName, BaseID, FilterCols, FilterVals)
{
	if(FilterCols == undefined)
		FilterCols = ""
	if(FilterVals == undefined)
		FilterVals = ""
		whList = window.open(FileName + '?BaseID=' + BaseID + '&FN=' + FilterCols + '&FV=' + FilterVals,'','width=500,height=450,menubar=no,status=no,titlebar=no,resizable=no,top=200,left=150');
}

function GetLeftCenter(WinHeight, WinHeight)
{

	if (screen.width == 1024)
	{
		RTop = (768 - WinHeight) / 2
		Result = "top=" + RTop + ",left=213"
	}
	else
	{
		RTop = (600 - WinHeight) / 2
		Result = "top=" + RTop + ",left=20"
	}
		return Result
}



function ShowBrowse(BaseID, MasterID, Section)
{
	if(MasterID == '')
		alert('ابتدا ذخیره کنید')
	else
			//window.location.href = '../Browse.aspx?BaseID=' + BaseID + '&MasterCode=' + MasterID + '&Section=' + Section;
			whList = window.open('../BrowsePopup.aspx?BaseID=' + BaseID + '&MasterCode=' + MasterID + '&Section=' + Section,'','width=790,height=420,menubar=no,status=no,titlebar=no,scrollbars,resizable=no,top=200,left=150');
}

function ShowGeneralList(BaseID, MasterID, Section)
{
	if(MasterID == '')
		alert('ابتدا ذخیره کنید')
	else
			whList = window.open('../GeneralList.asp?BaseID=' + BaseID + '&MasterCode=' + MasterID + '&Section=' + Section,'','width=700,height=370,menubar=no,status=no,titlebar=no,resizable=no,scrollbars,top=200,left=150');
}


function ShowPics(BaseID, MasterID, MediaType)
{
		whList = window.open('Album.asp?BaseID=' + BaseID + '&MasterCode=' + MasterID + '&MediaType=' + MediaType,'','width=600,height=510,menubar=no,status=no,titlebar=no,resizable=no,top=100,left=150');
}

function DoMask(MaskFormat, str,textbox,loc,delim)
{
//	try{
	
	DoNothing = 0

	CurrentPos = textbox.value.length;
	var locs = loc.split(',');	

	KeyCode = event.keyCode
	if (!window.event.shiftKey && !window.event.ctrlKey && !window.event.altKey) {
		if ((KeyCode > 47 && KeyCode < 58) || (KeyCode > 95 && KeyCode < 106)) {
			MaxL = MaskFormat.length + locs.length 
			if (textbox.value.length >= MaxL) {
					event.returnValue = false
					return false;
			}
			if (KeyCode > 95) KeyCode -= (95-47);
		} else if (KeyCode != 8 && KeyCode != 46 ) {
			event.returnValue = false
			return false;
		}
	}

	CurrentChar = String.fromCharCode(KeyCode)

	for (var i = 0; i <= locs.length; i++){
		for (var k = 0; k <= str.length; k++){
		 if (k == locs[i]){
		  if (str.substring(k, k+1) != delim){
		    str = str.substring(0,k) + delim + str.substring(k,str.length)
			textbox.value = str
		  }
		 }
		}
	 }

	if(CurrentPos < MaskFormat.length + locs.length)
	{
		if(MaskFormat.charAt(CurrentPos) == 'N')
		{
			if( !isNaN(CurrentChar))
			{
				DoNothing = 0
			}
			else
			{
				DoNothing = 1
			}
		}
		else if(MaskFormat.charAt(CurrentPos) == '/')
		{
			if( CurrentChar == '/')
			{
				DoNothing = 0
			}
			else
			{
				DoNothing = 1
			}
		}
		else if(MaskFormat.charAt(CurrentPos) == 'L')
		{
			if( !isNaN(CurrentChar))
			{
				DoNothing = 1
			}
			else
			{
				DoNothing = 0
			}
		}

	}	
	else
		DoNothing = 1
	

	if(DoNothing == 1)
		event.keyCode = 0
	return true;
//	}
//	catch(e)
//	{
//	}
}


function OpenDate(DivObj, ShowTime) {
    //alert(DivObj.parentNode.parentNode.childNodes[2].childNodes[1].tagName);

    InitVal = DivObj.parentNode.parentNode.childNodes[2].childNodes[1].value;
    FFN = DivObj.parentNode.parentNode.childNodes[2].childNodes[1].id;
    InputDateID = DivObj.parentNode.parentNode.childNodes[2].childNodes[1].id;

    InitVal = InitVal.replace("/", "");
    InitVal = InitVal.replace("/", "");
    X = window.event.clientX
    Y = window.event.clientY
    if (InitVal.length != 8)
        InitVal = '';

    DatePan.style.left = X - 32 + document.body.scrollLeft + 'px';
    DatePan.style.top = Y + 2 + document.body.scrollTop + document.documentElement.scrollTop + 'px';
    DatePan.style.display = "block"
    objTimeRow = document.getElementById('TimeRow');
    if (objTimeRow != null) {
        if (ShowTime == 'False')
            objTimeRow.style.display = 'none';
    }

    Init(1)
}


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
//    alert(url)
    http_request.onreadystatechange = Func;
    http_request.open(Method, url, true); 
    if( Method == 'GET')
       http_request.send(null); 
    else
       http_request.send(Param); 
} 

function DelComplete()
{
    if(http_request != null)
    {
       if (http_request.readyState == 4) { 
           if (http_request.status == 200) { 
	            result = http_request.responseText
	            if(result == "Success")
	                DelObj.style.display = 'none';
	            else
	                alert(result);
	            document.body.style.cursor='auto';
            }
       }
   }
}


function CallPrint(strid)
{
 var prtContent = document.getElementById(strid);
 var WinPrint = window.open('','','letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=1,status=0');
 WinPrint.document.write("<link href=\"../styles/main.css\" rel=\"stylesheet\" type=\"text/css\">" +  prtContent.innerHTML);
 WinPrint.document.close();
 WinPrint.focus();

//alert(WinPrint.document.getElementById("ctl00_cphMain_tblList").offsetHeight)
WinPrint.resizeTo(document.getElementById("ctl00_cphMain_tblList").offsetWidth + 30,document.getElementById("ctl00_cphMain_tblList").offsetHeight + 180 );
 WinPrint.print();
 WinPrint.close();
}

function OpenWin(Link, Width, Height)
{
//	X =  window.event.clientX
//	Y =  window.event.clientY + 100
//alert(screen.width)
leftVal = (screen.width - Width) / 2;
topVal = (screen.height - Height) / 2;

	window.open(Link,'','width=' + Width + ',height=' + Height + ',menubar=no,status=no,titlebar=no,scrollbars=yes,resizable=yes,top=' + topVal + ',left=' + leftVal );
}
function ResizeWin()
{
    MainEditObj = document.getElementById('dvMainEdit');
    var w=MainEditObj.offsetWidth;
    var h=MainEditObj.offsetHeight;
    alert(h)
    if ((w!=null) && (h!=null))
    {
    window.resizeTo(w,h);
//    var winX = (screen.width - w) / 2;
//    var winY = (screen.height - h) / 2;
//    window.moveTo(winX,winY);
    }

}

function OnClicking(sender, eventArgs)
{ 
    NodeVal = eventArgs.get_item().get_value();
	if (NodeVal != "") 
	{
	    switch(NodeVal)
	    {
	    
	        case "Resources":
	            window.location.href = '../AccessLevel/ResourceTree.aspx';
	            break;
	        case "ProductCats":
	            window.location.href = '../Products/ProductCatsTree.aspx';
	            break;
	        case "UpdateProList":
	            window.location.href = '../Products/UpdateProList.aspx';
	            break;
	        case "UpdateOrderStatus":
	            window.location.href = '../Orders/UpdateOrderStatus.aspx';
	            break;
	        case "rptOrders":
	            window.location.href = '../Reports/rptOrders.aspx';
	            break;
	        case "rptOrdersList":
	            window.location.href = '../Reports/rptOrdersList.aspx';
	            break;
	        case "UserTransList":
	            window.location.href = '../Admin/AccessLevel/UserTransList.aspx';
	            break;
	            	            

//	        case "GarbageWords":
//	            window.location.href = '../GarbageWords/EditGarbageWords.aspx';
//	            break;	            

	            
	        default :
	        {
	            if(NodeVal != undefined)
	                window.location.href = '../Main/Default.aspx?BaseID=' + NodeVal
        	    //BrowseObj1.CreateBrowse(eventArgs.Item.Value)
	        }
	    } 
	    return false;
	}
} 

function ShowHideTop()
{
    TopObj = document.getElementById('TopHeader')
    if(TopObj.style.display != 'none')
    {
        TopObj.style.display = 'none'
        document.getElementById('TDMainTD').className = ''
        document.getElementById('TDMain').className = 'cTblMainTD2'
    }
    else
    {
        TopObj.style.display = 'block'
        document.getElementById('TDMainTD').className = 'cTblMainTD'
        document.getElementById('TDMain').className = 'cTblMainEdit'
    }            
    
}

function CorrectText(str)
{
    return str.replace('ی', 'ی').replace('ی', 'ی').replace('ى', 'ی').replace('ك', 'ک')
            .replace('٠', '۰').replace('١', '۱').replace('٢', '۲').replace('٣', '۳').replace('٤', '۴')
            .replace('٥', '۵').replace('٦', '۶').replace('٧', '۷').replace('٨', '۸').replace('٩', '۹')
}
var lblUpdateObj = null;
function ShowLabel(FeildName, Code)
{
    lblUpdateObj = event.srcElement;
    startRequest('ShowLabel.aspx?FullFieldName=' + Fieldname + '&DetailCode=' + Code, PutLabelString, 'GET', null, lblUpdateObj);
}
function PutLabelString()
{
    if(http_request != null)
    {
       if (http_request.readyState == 4) { 
           if (http_request.status == 200) { 
	            result = http_request.responseText
	            if(lblUpdateObj != null)
	                lblUpdateObj.innerHTML = result;
	            document.body.style.cursor='auto';
            }
       }
   }
}

function PrintStr()
{
    CallPreviewPrint('PrintArea');
}

function PrintPage(btnObj)
{
    btnObj.style.visibility = 'hidden'
    window.print();
}

function CallPreviewPrint(strid)
{
 var prtContent = document.getElementById(strid);
 var WinPrint = window.open('','PrintPage','letf=0,top=0,width=950,height=800,toolbar=0,scrollbars=1,status=0,resizeable=true');
 
 StrBody = "<body style=\"background-color:white\" dir=rtl>";
 StrBody += "<link id=\"ctl00_Link1\" href=\"../styles/main.css\" rel=\"stylesheet\" type=\"text/css\" />";
 StrBody += "<script src=\"../js/main.js\" type=\"text/javascript\"></script>";
 StrBody += "<div id=\"PrintArea\">" + prtContent.innerHTML + "</div><br /><a href=\"#\" class=\"cPrint2\" onclick=\"CallPrint('PrintArea')\"><img src=\"../images/spacer.gif\" alt=\"Print\" class=\"cPrint2\" /></a></body>"
 WinPrint.document.write(StrBody);
 WinPrint.document.close();
 WinPrint.focus();

}


function CallPrint(strid)
{
 var prtContent = document.getElementById(strid);
 var WinPrint = window.open('','','letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=1,status=0');
 WinPrint.document.write("<body dir=rtl>" + prtContent.innerHTML + "</body>");
 WinPrint.document.close();
 WinPrint.focus();

//alert(WinPrint.document.getElementById("grdPrint").offsetHeight)
//WinPrint.resizeTo(document.getElementById("grdPrint").offsetWidth + 30,document.getElementById("grdPrint").offsetHeight + 180 );
WinPrint.print();
WinPrint.close();
}

function ToggleSelection(ChkObj)
{
    tblObj = ChkObj.parentNode.parentNode.childNodes[1]
    for(i=0; i < tblObj.rows.length; i++)
    {
        for(j=0; j < tblObj.rows[i].cells.length; j++)
        {
             CurCheckBox = tblObj.rows[i].cells[j].childNodes[0]   
             if(ChkObj.checked)
                CurCheckBox.checked = true;
             else
                CurCheckBox.checked = false;
                     
        }
    }

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

function ConvertNumbersToEnglish(str) {
    return str.replace('۰', '0').replace('۱', '1').replace('۲', '2').replace('۳', '3').replace('۴', '4')
            .replace('۵', '5').replace('۶', '6').replace('۷', '7').replace('۸', '8').replace('۹', '9');

}
