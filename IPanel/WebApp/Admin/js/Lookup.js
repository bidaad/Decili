document.write("<div class=\"cHiddenDate\" id=\"LookupResults\"></div>");

var http_request = null;
var CellColor = "#ffffff";
var LeftOffset;
var TopOffset;
var TextWidth;
var LookupRowCounter = 1;
var SearchFeildName = "";
var objLookupText = null;
var LookupResultsObj = null;

function makeRequest(url, Func, Method, Param) 
{ 
   if (window.XMLHttpRequest) { 
       http_request = new XMLHttpRequest(); 
   } 
   else if (window.ActiveXObject) { 
       http_request = new ActiveXObject('Microsoft.XMLHTTP'); 
   } 
    if(url.indexOf("?") == -1)
        url = url + '?rnd=' + Math.random();
    else
        url = url + '&rnd=' + Math.random();

   //alert(url)
   http_request.onreadystatechange = UpdateVal;//Func

   http_request.open(Method, url, false); 
   if( Method == 'GET')
       http_request.send(null); 
   else
       http_request.send(Param); 

}

function UpdateVal()
{
    if(http_request != null)
    {
       if (http_request.readyState == 4) { 
           if (http_request.status == 200) { 
	            result = http_request.responseText
	            ResultPrefix = result.substring(0,8)
	            if(ResultPrefix == "Message:")
	            {
	                alert(result.split(':')[1])
	                return;
	            }

	            text = result;
    			//alert(result)
	            GenerateTable()

	            document.body.style.cursor='auto';
            }
       }
   }
}

function setStyle(obj, attrName, XMLAttrName)
{
    AttrVal = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute(XMLAttrName)
    if(AttrVal != null)
    {
        if(attrName == 'backgroundColor')
            obj.style.backgroundColor = AttrVal;
        if(attrName == 'direction')
            obj.setAttribute('dir',AttrVal);
        if(attrName == 'textAlign')
            obj.style.textAlign = AttrVal;
        if(attrName == 'width')
            obj.setAttribute('width',AttrVal);
        
        //eval('obj.' + attrName + ' = AttrVal');
    }
        
        
}



var AllDataCell = null;
var MainObj = null;

function GenerateTable()
{
    LookupRowCounter = 0;
    AllDataCell = document.createElement("DIV");
    if(AllDataCell.childNodes[0] != null)
        AllDataCell.childNodes[0].removeNode(true);


    TblObj = document.createElement("TABLE");
    TblObj.className = "VisatGrid"
    TblObj.setAttribute("width","100%")

    ConditionObj = document.getElementById("Condition");
    if(ConditionObj != null)
        ConditionCode = ConditionObj.options[ConditionObj.selectedIndex].value;
    else
        ConditionCode = '';        

    CurrentRow = 1
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM")
    xmlDoc.async="false"
    xmlDoc.loadXML(text)
    MainObj = xmlDoc.documentElement

    RecordCount = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:RecCount")
    CurPage = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:CurPage")
    RowsPerPage = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:RowsPerPage")
    FilterClm = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:FilterClm")
    CellNum = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes.length
    LabelName = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:LabelName")
    ViewName = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:ViewName")

    SearchFeildName = FilterClm;
    EditWidth = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:EditWidth")
    EditHeight = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].getAttribute("msprop:EditHeight")


    RowCount = TblObj.rows.length
    for(d=0 ; d < RowCount; d++)
    {
        TblObj.deleteRow(0);
    }

    for (i=1 ; i < MainObj.childNodes.length ; i++)
    {
	    newRow = TblObj.insertRow()
	    for (j=0 ; j < MainObj.childNodes[i].childNodes.length; j++)
	    {
		    FieldName = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("name")
            FieldWidth = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:Width")
		    CellText = MainObj.childNodes[i].childNodes[j].text
		    CellText = CellText.replace("_x0020_", " ")
		    DisplayMode = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:DisplayMode")
		    IsKey = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:IsKey")

	        if(FieldName == SearchFeildName || FieldName == "Code")
	        {

    		    newCell = newRow.insertCell()
                if(DisplayMode == "Hidden" )
                    newCell.style.display = 'none'

                if(CellText.indexOf("\n") >0)
                {
                    intFieldWidth = FieldWidth.replace("px","")
                    intFieldWidth = parseInt(intFieldWidth, 10)
                    LineBreakPos = CellText.indexOf("\n");
                    if(LineBreakPos < intFieldWidth)
                        CellText = CellText.substr(0,LineBreakPos) + "...";
                    else
                        CellText = CellText.substr(0,intFieldWidth) + "...";
                }
		        newCell.innerHTML = CellText
		        if(i == 1)
		            newCell.className = 'cHighlightedRow';
		        else
		            newCell.className = 'cGridDataCell';
		            

	            newCell.onclick = (
	            function(InnerI) 
	            {
	               return function()
                   {
                        //alert(InnerI)
                        LookupRowCounter = InnerI - 1;
                        SelectLookupItem(LookupRowCounter);
    	           }
                }
                )(i);
    			
                setStyle(newCell, 'backgroundColor', 'msprop:BgColor')
                setStyle(newCell, 'direction', 'msprop:Direction')
                setStyle(newCell, 'textAlign', 'msprop:Alignment')
            }
	    }
    }
    LookupResultsObj = getObj('LookupResults')
    LookupResultsObj.style.display = 'block'
    LookupResultsObj.innerHTML = "";
    LookupResultsObj.appendChild(TblObj);
    LookupResultsObj.style.left = LeftOffset;
    LookupResultsObj.style.top = TopOffset + 21;
    LookupResultsObj.style.width = TextWidth;
	//getObj('LookupResults').style.display='none';
	//alert(TblObj.innerHTML)
}

function SelectLookupItem(RowNum)
{
    objLookupText.parentNode.parentNode.parentNode.rows[0].cells[1].childNodes[0].value =  TblObj.rows[RowNum].cells[0].innerHTML
    objLookupText.parentNode.parentNode.parentNode.rows[0].cells[0].childNodes[0].value =  TblObj.rows[RowNum].cells[1].innerHTML
    LookupResultsObj.style.display = 'none'
    LookupRowCounter = 0;

}

function stopRKey(evt) {
  var evt = (evt) ? evt : ((event) ? event : null);
  var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
  if ((evt.keyCode == 13) && (node.type=="text"))  {return false;}
}

document.onkeypress = stopRKey;
function SearchLookup(BID, FldName, Obj)
{
    if(FldName != '')
        SearchFeildName = FldName;        
    else
        SearchFeildName = "";
    objLookupText = Obj
    var keyCode = (window.event.which) ? window.event.which : window.event.keyCode;
    
    switch(keyCode)
    {
        case 13: //Enter key
        SelectLookupItem(LookupRowCounter);
        break;
        case 40: //Down key
        if(LookupRowCounter < TblObj.rows.length - 1)
        {
            LookupRowCounter++;
            HightlightRow(LookupRowCounter);
        }
        break;
        case 38: //Up key
        if(LookupRowCounter > 0)
        {
            LookupRowCounter--;
            HightlightRow(LookupRowCounter);
        }
        break;
        default:  
        
        
        LeftOffset = GetRealLeftOffset(Obj) + 2;
        TopOffset  = GetRealTopOffset(Obj);
        TextWidth = Obj.offsetWidth - 2
        //alert(LeftOffset)
        ReqUrl = "../jsLookup.aspx?BaseID=" + BID + "&Keyword=" + escape(Obj.value) + "&Condition=9&FilterClm=" + SearchFeildName;
        //alert(ReqUrl);
        makeRequest(ReqUrl, UpdateVal, "GET",null)
            break;
    }
}

function getPosition(e) {
    e = e || window.event;
    var cursor = {x:0, y:0};
    if (e.pageX || e.pageY) {
        cursor.x = e.pageX;
        cursor.y = e.pageY;
    } 
    else {
        var de = document.documentElement;
        var b = document.body;
        cursor.x = e.clientX + 
            (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
        cursor.y = e.clientY + 
            (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
    }
    return cursor.x
    //return cursor;
}


function GetRealLeftOffset(CurObj)
{
    r = 0;
    while(CurObj=CurObj.offsetParent)
    {
    //alert(CurObj.tagName + '     ' + CurObj.offsetLeft)
    r+=CurObj.offsetLeft;
    }
    return r;
}
function GetRealTopOffset(CurObj)
{
    r = 0;
    while(CurObj=CurObj.offsetParent)r+=CurObj.offsetTop;
    return r;
}

function HightlightRow(RowNum)
{
    for(i = 0 ; i < TblObj.rows.length; i++)
    {
        for(j = 0 ; j < TblObj.rows[i].cells.length; j++)
        {
            TblObj.rows[i].cells[j].className = 'cGridDataCell'
        }
    }
    
    for(j = 0 ; j < TblObj.rows[RowNum].cells.length; j++)
    {
        TblObj.rows[RowNum].cells[j].className = 'cHighlightedRow'
    }
    objLookupText.value = TblObj.rows[RowNum].cells[1].innerHTML

}

