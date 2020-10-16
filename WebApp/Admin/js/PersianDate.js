/*********************************************
Persian Calendar 
Written by Alireza Gorji
*********************************************/
var Lang = 1;
var CurrentLang = 1//1 for farsi, 0 for english. farsi default
var dtLDate = 0
var sFDate = 0

var MyYear = 0;
var MyMonth = 0;
var MyDay = 0;

var CurrentDay
var CurrentMonth
var CurrentYear
var FFN = null;
var InitDate = null;
var DayNumBGColor = "#86BEF9";
var CellBGColor = "#E0ECF9";
var HeadBGColor = "#01346D";
var FooterBGColor = "#01346D";


function ChangeLanguage()
{

	CurrentLang = 1 - CurrentLang	
    Init(CurrentLang);

}

function testfunc(e)
{
    alert('Thanks For Resizing');
}
function GetMonthName(MonthNum)
{
	MonthNum = parseInt(MonthNum, 10)

	if ( CurrentLang == 0)
	{
		switch(MonthNum)
		{
			case 1:
				return "January"
				break;
			case 2:
				return "February"
				break;
			case 3:
				return "March"
				break;
			case 4:
				return "April"
				break;
			case 5:
				return "May"
				break;
			case 6:
				return "June"
				break;
			case 7:
				return "July"
				break;
			case 8:
				return "August"
				break;
			case 9:
				return "September"
				break;
			case 10:
				return "October"
				break;
			case 11:
				return "November"
				break;
			case 12:
				return "December"
				break;
		}

	}

	switch(MonthNum)
	{
		case 1:
			return "فروردین"
			break;
		case 2:
			return "اردیبهشت"
			break;
		case 3:
			return "خرداد"
			break;
		case 4:
			return "تیر"
			break;
		case 5:
			return "مرداد"
			break;
		case 6:
			return "شهریور"
			break;
		case 7:
			return "مهر"
			break;
		case 8:
			return "آبان"
			break;
		case 9:
			return "آذر"
			break;
		case 10:
			return "دی"
			break;
		case 11:
			return "بهمن"
			break;
		case 12:
			return "اسفند"
			break;

	}
}
function ValidateDate(txtDate) {
    var EnteredDate = txtDate.value;
    var IsValid = true;
    if (EnteredDate != '') //Not empty
    {
        var dates_arr = EnteredDate.split("/");
        if (dates_arr.length != 3) {
            IsValid = false;
        }
        else {
            var year = parseInt(dates_arr[0], 10);
            var month = parseInt(dates_arr[1], 10);
            var day = parseInt(dates_arr[2], 10);
            if (isNaN(year) || isNaN(month) || isNaN(day) || year < 1287 || year > 1450 || month > 12 || month < 1 || day > 31 || day < 1 || (month > 6 && day > 30))
                IsValid = false;
            else {
                //سیستم کبیسه خورشیدی : باقیمانده تقسیم سال به 33 یکی از این عدد ها باشد : 1 و 5 و 9 و 13 و 17 و 22 و 26 و 30
                var kabise = year % 33;
                switch (kabise) {
                    case 1:
                    case 5:
                    case 9:
                    case 13:
                    case 17:
                    case 22:
                    case 26:
                    case 30:
                        break;
                    default: //kabise nist
                        if (month == 12 && day > 29) IsValid = false;
                        break;
                }
            }
        }

    }
    if (!IsValid) {
        alert('تاریخ وارد شده صحیح نیست. لطفاً دوباره وارد کنید');
        txtDate.value = '';
    }
    return IsValid;
}


function CurFDate()
{
    CurrentLDate = new Date()
    if (dtLDate == CurrentLDate) 
    	return dtLDate

    dtLDate = CurrentLDate

	nLDay = dtLDate.getDate()
    nLMonth = dtLDate.getMonth() + 1
    nLYear = dtLDate.getFullYear()

    nDays = 0
    for (N = 1999 ; N <= nLYear - 1; N++)
    {
            nDays = nDays + LYearDays(N);
    }

    for ( N = 1 ; N <= nLMonth - 1; N++)
    {
        nDays = nDays + LMonthDays(nLYear, N);
    }

    nDays = nDays + nLDay + 285;

    sFDate = FDateAddDay("13770101", nDays)
//    CurFDate = sFDate
	return sFDate//CurFDate

}
///////////////////////////////////////
function FToL(fYear, fMonth, fDay)
{
    nDays = 0
    for (N = 1377 ; N <= fYear- 1; N++)
    {
            nDays = nDays + FYearDays(N);
    }

    for ( N = 1 ; N <= fMonth - 1; N++)
    {
        nDays = nDays + FMonthDays(fYear, N);
    }

    nDays = nDays + fDay + 0;
    CurDate =  Date(1998, 3, 21)
	    
    //alert(nDays)
}

//FToL(1380, 12, 29)
function LToF(lYear, lMonth, lDay)
{
	nLDay = lDay
    nLMonth = lMonth
    nLYear = lYear

    nDays = 0
    for (N = 1999 ; N <= nLYear - 1; N++)
    {
            nDays = nDays + LYearDays(N);
    }

    for ( N = 1 ; N <= nLMonth - 1; N++)
    {
        nDays = nDays + LMonthDays(nLYear, N);
    }

    nDays = nDays + nLDay + 285;

    sFDate = FDateAddDay("13770101", nDays)
//    CurFDate = sFDate
	return sFDate//CurFDate

}




//////////////////////////////////////
function LYearDays(niYear) 
{

    if ( IsLLeapYear(niYear) )
        return 366
    else
        return 365
}

function IsLLeapYear(niYear)
{

    if ( (niYear % 4) == 0 && (niYear % 100) != 0 || (niYear % 400) == 0 )
        return true
    else
        return false

}

function LMonthDays(niYear , niMonth)
{
//	alert(niYear , niMonth + ' ' + niMonth)
	switch(niMonth)
	{
	    case 1:
	        return 31
	        break;
	    case 3:
	        return 31
	        break;
	    case 5:
	        return 31
	        break;
	    case 7:
	        return 31
	        break;
	    case 8:
	        return 31
	        break;
	    case 10:
	        return 31
	        break;
	    case 12 :
	        return 31
	        break;
	    case 4:
	        return 30
	        break;
	    case 6:
	        return 30
	        break;
	    case 9:
	        return 30
	        break;
	    case 11 :
	        return 30
	        break;
    	case 2 :
	    	{
		        if ( IsLLeapYear(niYear) )
		            return 29
		        else
		            return 28
		        break;
	        }
	    default :
	    {
	        return 0;
	        }
	}
}


function FDateAddDay(siDate , niDays ) 
{
    if ( !IsValidFDate(siDate) )
    	return false;

    if ( niDays < 0 )
    	return false;
   
    dt = FDateSplit(siDate)


    if (dt[0] > 1 )
    {
        niDays = niDays + dt[0] - 1
        dt[0] = 1
    }

    while ( niDays >= FYearDays(dt[2]) )	
	{
        niDays = niDays - FYearDays(dt[2]);
        dt[2] = dt[2] + 1;
    }


    while ( niDays >= FMonthDays(dt[2], dt[1]) )
	{
        niDays = niDays - FMonthDays(dt[2], dt[1]);
        dt[1] = dt[1] + 1;
        if ( dt[1] > 12 )
        {
            dt[1] = 1
            dt[2] = dt[2] + 1
         }
    }



    dt[0] = niDays + dt[0]

    Result = FDateMerge(dt)
    return Result
}

function FDateSplit(siDate)
{
	var DateArray = new Array()
	DateArray[0] = parseInt(siDate.substr(6, 2), 10)
	DateArray[1] = parseInt(siDate.substr(4, 2), 10)
	DateArray[2] = parseInt(siDate.substr(0, 4), 10)

	return DateArray
}



function FDateMerge(dtiDate ) 
{
	if ( dtiDate[1] < 10 )
		RealMonth = '0' + dtiDate[1]
	else
		RealMonth = dtiDate[1]
	
	if ( dtiDate[0] < 10 )
		RealDay = '0' + dtiDate[0]
	else
		RealDay = dtiDate[0]

	RealYear = dtiDate[2]

    return (RealYear + '' + RealMonth + '' + RealDay)
}

function FMonthDays(niYear, niMonth) 
{
	if ( CurrentLang == 0 )
		return LMonthDays(niYear, niMonth)

    switch( niMonth)
    {
	    case 1:
	        return 31;
	        break;
	    case 2:
	        return 31;
	        break;
	    case 3:
	        return 31;
	        break;
	    case 4:
	        return 31;
	        break;
	    case 5:
	        return 31;
	        break;
	    case 6:
	        return 31;
	        break;
	    case 7:
	        return 30
	        break;
	    case 8:
	        return 30
	        break;
	    case 9:
	        return 30
	        break;
	    case 10:
	        return 30
	        break;
	    case 11:
	        return 30
	        break;
    	case 12 :
    		if( IsFLeapYear(niYear) )
    			return 30
    		else
    			return 29
	        break;
    }
}


function IsValidFDate(siDate ) 
{
//	alert(siDate )
    if ( siDate.length  != 8 )
    {
    	return false
	}
    if ( isNaN(siDate) )
    {
    	return false
	}
    dt = FDateSplit(siDate)

    if ( dt[2] <= 0 )
    {
    	return false
	}
    if ( dt[1] <= 0 || dt[1] > 12 )
    {
    	return false
	}
    if ( dt[0] <= 0 || dt[0] > FMonthDays(dt[2], dt[1]) )
    {
//		alert(siDate)
    	return false
   	}
    	

   	return true

}


function FYearDays(niYear) 
{
	if ( CurrentLang == 0 )
		return LYearDays(niYear) 
		
    if ( IsFLeapYear(niYear) )
        return 366
    else
        return 365
}


function IsFLeapYear(niYear )
{
	if ( CurrentLang == 0 )
		return IsLLeapYear(niYear)		 
    niYear = (niYear - 22) % 33

    if ( niYear == 32 )
        return false
    else if ( (niYear % 4) == 0 )
        return true
    else
        return false
}


function DayOfWeek(siDate )
{
    if ( !IsValidFDate(siDate) )
    {
        return -1
        return false
	}        

    lDayOfWeek = 0 // 13770101 was a saturday
    nYear = parseInt(siDate.substr(0, 4), 10)
    nMonth = parseInt(siDate.substr(4, 2), 10)
    nDay = parseInt(siDate.substr(6, 2), 10)

	if ( CurrentLang == 0 )
	{
		TempDate = new Date(nYear, nMonth - 1, 1)
		return (TempDate.getDay() + 1)%7
	}


    while ( nYear != 1377 )
    {
        if ( nYear < 1377 )
        {
           lDayOfWeek = lDayOfWeek - FYearDays(nYear)
           nYear = nYear + 1
        }
        else
        {
           lDayOfWeek = lDayOfWeek + FYearDays(nYear - 1)
           nYear = nYear - 1
        }
	}
	
    while ( nMonth > 1 )
    {
       lDayOfWeek = lDayOfWeek + FMonthDays(1377, nMonth - 1)
       nMonth = nMonth - 1
    }

    lDayOfWeek = lDayOfWeek + nDay - 1;

    lDayOfWeek = lDayOfWeek % 7

    if ( lDayOfWeek < 0 )
        lDayOfWeek = 7 + lDayOfWeek

    return lDayOfWeek
}

var SelectedCellObj = null
var CurrentDateCellObj = null

function FillCells(YearIndex, MonthIndex, DayIndex)
{
	RealDay = 1

	for (j=0; j < 42; j++)
	{
		document.getElementById("Cell" + j).style.backgroundColor = ''
		CellID  = document.getElementById("Cell" + j).innerHTML = "&nbsp;"
		document.getElementById("Cell" + j).style.cursor = ''
	}
    
	for (i=DayIndex; i < 42; i++)
	{
		if ( RealDay < 10 )
			TempDate = '0' + RealDay
		else
			TempDate = RealDay + ''

//		if ( MonthIndex < 10 )
//			TempDate = '0' + MonthIndex + TempDate
//		else
		TempDate = MonthIndex + '' + TempDate

		TempDate = YearIndex + '' + TempDate
			
		if( IsValidFDate(TempDate))
		{
			try{
				document.getElementById("Cell" + i).EngDate = RealDay;
				if(CurrentLang == 1)
				    document.getElementById("Cell" + i).innerText = GetPersianNumber(RealDay + '');
				else
				    document.getElementById("Cell" + i).innerText = RealDay ;
				document.getElementById("Cell" + i).style.cursor = 'hand'
				if( RealDay == MyDay )
				{
					document.getElementById("Cell" + i).style.backgroundColor = 'CCCCCC'
					CurrentDateCellObj = document.getElementById("Cell" + i)
					SelectedCellObj = CurrentDateCellObj
				}
			}
			catch(e)
			{
				alert(e.description)
			}
		}
		RealDay++;
	} 
	HeaderHtml = '<font face=Tahoma color=white size=2>' + GetMonthName(MyMonth) + '  ';
	if(CurrentLang == 1)
	    HeaderHtml = HeaderHtml + GetPersianNumber(MyYear + '') + '</font>'
	else
	    HeaderHtml = HeaderHtml + MyYear  + '</font>'
    CellID = document.getElementById("TitleCell").innerHTML = HeaderHtml
}

function Init(CurrentLang)
{
    CurrentFarsiDate = CurFDate()
	var dt = new Array()

	dt = FDateSplit(CurrentFarsiDate)
	CurrentDay = dt[0]
	CurrentMonth = dt[1]
	CurrentYear = dt[2]

    if(InitDate != null)
    {
        InitYear = InitDate.substring(0, 4);
        InitMonth = InitDate.substring(5, 2);
        InitDay = InitDate.substring(InitDate.Length - 2, 2);
        StringDate = InitYear + InitMonth + InitDay;
        
        if(IsValidFDate(StringDate))
        {
                dt[2] = InitYear;
                dt[1] = InitMonth;
                dt[0] = InitDay;
        }
    }
    
	if ( dt[1] < 10 ) 
		StringMonth = '0' + parseInt(dt[1], 10)
	else
		StringMonth = dt[1]

	FirstMonthDay = dt[2] + '' + StringMonth + '01'
	DayIndex = DayOfWeek(FirstMonthDay)
	MyYear = dt[2];
	MyMonth = dt[1];
	MyDay = dt[0];


	if( CurrentLang == 1)
	{
		ImageLang.className = 'cDateFa'
		document.getElementById("Friday").innerText  = 'ج'
		document.getElementById("Thursday").innerText = 'پ'
		document.getElementById("Wednesday").innerText = 'چ'
		document.getElementById("Tuesday").innerText = 'س'
		document.getElementById("Monday").innerText = 'د'
		document.getElementById("Sunday").innerText = 'ی'
		document.getElementById("Saterday").innerText = 'ش'
	
//		Init();
	}
	else
	{
		ImageLang.className = 'cDateEn'

		document.getElementById("Friday").innerText = 'F'
		document.getElementById("Thursday").innerText = 'T'
		document.getElementById("Wednesday").innerText = 'W'
		document.getElementById("Thursday").innerText = 'T'
		document.getElementById("Tuesday").innerText = 'T'
		document.getElementById("Monday").innerText = 'M'
		document.getElementById("Sunday").innerText = 'S'
		document.getElementById("Saterday").innerText = 'S'

		CurrentLDate = new Date()
		MyDay = CurrentLDate.getDate()
		MyMonth = CurrentLDate.getMonth() + 1
		MyYear = CurrentLDate.getYear()

		CurrentDay = MyDay
		CurrentMonth = MyMonth
		CurrentYear = MyYear
	}

	FillCells(dt[2], StringMonth, DayIndex)

}

function AddOneMonth()
{
	MyMonth++;
	if( MyMonth > 12 ) 
	{
		MyMonth = 1
		MyYear++;
	}

	if ( MyMonth < 10 ) 
		StringMonth = '0' + MyMonth
	else
		StringMonth = MyMonth

	FirstMonthDay = MyYear + '' + StringMonth + '01'
	DayIndex = DayOfWeek(FirstMonthDay)

	FillCells(MyYear, StringMonth, DayIndex)

}

function SubOneMonth()
{
	MyMonth--;
	if( MyMonth <= 0 ) 
	{
		MyMonth = 12
		MyYear--;
	}

	if ( MyMonth < 10 ) 
		StringMonth = '0' + MyMonth
	else
		StringMonth = MyMonth

	FirstMonthDay = MyYear + '' + StringMonth + '01'
	DayIndex = DayOfWeek(FirstMonthDay)

	FillCells(MyYear, StringMonth, DayIndex)

}

function SubOneYear()
{
	MyYear--;

	if ( parseInt(MyMonth, 10) < 10 ) 
		StringMonth = '0' + parseInt(MyMonth, 10)
	else
		StringMonth = MyMonth

	FirstMonthDay = MyYear + '' + StringMonth + '01'
	DayIndex = DayOfWeek(FirstMonthDay)

	FillCells(MyYear, StringMonth, DayIndex)

}


function AddOneYear()
{
	MyYear++;

	if ( parseInt(MyMonth, 10) < 10 ) 
		StringMonth = '0' + parseInt(MyMonth, 10)
	else
		StringMonth = MyMonth

	FirstMonthDay = MyYear + '' + StringMonth + '01'
	DayIndex = DayOfWeek(FirstMonthDay)

	FillCells(MyYear, StringMonth, DayIndex)

}

function HighLight(CellID)
{
//	alert(document.getElementById(CellID).style.backgroundColor)
	if (document.getElementById(CellID).innerHTML != '&nbsp;' && document.getElementById(CellID).style.backgroundColor != '#cccccc')
	{
		SelectedCellObj.style.backgroundColor = ''
		
		document.getElementById(CellID).style.backgroundColor = 'BED6F1'
		SelectedCellObj = document.getElementById(CellID)
	}
}

function UnHighLight(CellID)
{
	if ( document.getElementById(CellID).style.backgroundColor != 'CCCCCC' && document.getElementById(CellID).style.backgroundColor != '#cccccc')
	{
		document.getElementById(CellID).style.backgroundColor = ''
	}
}

function SelectDate(CellID)
{
	
	var SelectedMonth = 0
	var SelectedDay = 0
	
	//SelectedDay = document.getElementById(CellID).innerHTML	
	SelectedDay = document.getElementById(CellID).EngDate	
	
	if(SelectedDay != '&nbsp;')
	{
		if( parseInt(SelectedDay, 10) < 10 )
			SelectedDay = '0' + SelectedDay

		if ( parseInt(MyMonth, 10) < 10)
			SelectedMonth = '0' + parseInt(MyMonth, 10)
		else
			SelectedMonth = '' + parseInt(MyMonth, 10)


		if (FFN != null) {

		    eval("document.getElementById('" + FFN + "').value = MyYear + '/' + SelectedMonth + '/' + SelectedDay ")
		    DatePan.style.display = "none"

		}
	}
	
}

function SelectCurrentDay()
{
	MyDay = CurrentDay;
	if (MyDay < 10)
		MyDay = '0' + MyDay

	MyMonth = CurrentMonth;
	if (MyMonth < 10)
		MyMonth = '0' + MyMonth

	MyYear = CurrentYear;

	YearMonthDay = MyYear + '' + MyMonth + '' + '01'
	DayIndex = DayOfWeek(YearMonthDay)

	FillCells(MyYear, StringMonth, DayIndex)
}



function keyHandler() {
	switch (event.keyCode) {
	case 37: //Left Arrow Key
		DoLeftArrow()
		break	
	case 38: //Up Arrow Key
		DoUpArrow()
		break	
	case 39: //Right Arrow Key
		DoRightArrow()
		break	
	case 40: //Down Arrow Key
		DoDownArrow()
		break
	case 13: //Enter
		SelectKeyDate()
		break	
	case 33: //PageUp
		if(event.ctrlKey)
			SubOneYear()
		else
			SubOneMonth()
		break	
	case 34: //PageDown
		if(event.ctrlKey)
			AddOneYear()
		else
			AddOneMonth()
		break	
	}

}

function SelectKeyDate()
{
	SelectedDay = SelectedCellObj.innerHTML	
	if(SelectedDay != '&nbsp;')
	{
		if( parseInt(SelectedDay, 10) < 10 )
			SelectedDay = '0' + SelectedDay

		if ( parseInt(MyMonth, 10) < 10)
			SelectedMonth = '0' + parseInt(MyMonth, 10)
		else
			SelectedMonth = '' + parseInt(MyMonth, 10)
		
		eval("opener.aspnetForm." + FFN + ".value = MyYear + '/' + SelectedMonth + '/' + SelectedDay")
		window.close()
	}

}

function DoLeftArrow()
{
	CellIndex = SelectedCellObj.cellIndex
	if(CellIndex > 0)
	{
		RowObj = SelectedCellObj.parentNode

		if(RowObj.cells[CellIndex - 1].innerHTML != '&nbsp;')
		{
			if(SelectedCellObj != CurrentDateCellObj)
				SelectedCellObj.style.backgroundColor = ''
			else
				SelectedCellObj.style.backgroundColor = 'CCCCCC'
	
	
			SelectedCellObj = RowObj.cells[CellIndex - 1]
			SelectedCellObj.style.backgroundColor = '9999FF'
		}
	}
	else
	{
		CellIndex = SelectedCellObj.parentNode.cells.length

		RowIndex = SelectedCellObj.parentNode.rowIndex
		RowObj = SelectedCellObj.parentNode.parentNode.rows[RowIndex + 1]
		if(RowObj.cells[CellIndex - 1].innerHTML != '&nbsp;')
		{
			if(SelectedCellObj != CurrentDateCellObj)
				SelectedCellObj.style.backgroundColor = ''
			else
				SelectedCellObj.style.backgroundColor = 'CCCCCC'
	
	
			SelectedCellObj = RowObj.cells[CellIndex - 1]
			SelectedCellObj.style.backgroundColor = '9999FF'
		}
	}
}

function DoRightArrow()
{
	CellIndex = SelectedCellObj.cellIndex
	if(CellIndex < SelectedCellObj.parentNode.cells.length - 1)
	{
		RowObj = SelectedCellObj.parentNode
		if(RowObj.cells[CellIndex + 1].innerHTML != '&nbsp;')
		{
			if(SelectedCellObj != CurrentDateCellObj)
				SelectedCellObj.style.backgroundColor = ''
			else
				SelectedCellObj.style.backgroundColor = 'CCCCCC'
	
			SelectedCellObj = RowObj.cells[CellIndex + 1]
			SelectedCellObj.style.backgroundColor = '9999FF'
		}
	}
	else
	{
		CellIndex = 0

		RowIndex = SelectedCellObj.parentNode.rowIndex
		RowObj = SelectedCellObj.parentNode.parentNode.rows[RowIndex - 1]
		if(RowObj.cells[0].innerHTML != '&nbsp;')
		{
			if(SelectedCellObj != CurrentDateCellObj)
				SelectedCellObj.style.backgroundColor = ''
			else
				SelectedCellObj.style.backgroundColor = 'CCCCCC'
	
			SelectedCellObj = RowObj.cells[0]
			SelectedCellObj.style.backgroundColor = '9999FF'
		}
	}
	
}

function DoDownArrow()
{
	CellIndex = SelectedCellObj.cellIndex
	RowIndex = SelectedCellObj.parentNode.rowIndex
	if(RowIndex < SelectedCellObj.parentNode.parentNode.rows.length)
	{
		RowObj = SelectedCellObj.parentNode

		if(SelectedCellObj.parentNode.parentNode.rows[RowIndex+1].cells[CellIndex].innerHTML != '&nbsp;')
		{
			if(SelectedCellObj != CurrentDateCellObj)
				SelectedCellObj.style.backgroundColor = ''
			else
				SelectedCellObj.style.backgroundColor = 'CCCCCC'
	
	
			SelectedCellObj = SelectedCellObj.parentNode.parentNode.rows[RowIndex+1].cells[CellIndex]
			SelectedCellObj.style.backgroundColor = '9999FF'
		}
	}
}

function DoUpArrow()
{
	CellIndex = SelectedCellObj.cellIndex
	RowIndex = SelectedCellObj.parentNode.rowIndex
	if(RowIndex > 0)
	{
		RowObj = SelectedCellObj.parentNode

		if(SelectedCellObj.parentNode.parentNode.rows[RowIndex-1].cells[CellIndex].innerHTML != '&nbsp;')
		{
			if(SelectedCellObj != CurrentDateCellObj)
				SelectedCellObj.style.backgroundColor = ''
			else
				SelectedCellObj.style.backgroundColor = 'CCCCCC'
	
	
			SelectedCellObj = SelectedCellObj.parentNode.parentNode.rows[RowIndex-1].cells[CellIndex]
			SelectedCellObj.style.backgroundColor = '9999FF'
		}
	}
}
function isChild(s,d) {
	while(s) {
		if (s==d) 
			return true;
		s=s.parentNode;
	}
	return false;
}

function getObj(objID)
{
    if (document.getElementById) {return document.getElementById(objID);}
    else if (document.all) {return document.all[objID];}
    else if (document.layers) {return document.layers[objID];}
}

function Left(obj)
{
	var curleft = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curleft += obj.offsetLeft
			obj = obj.offsetParent;
		}
	}
	else if (obj.x)
		curleft += obj.x;
	return curleft;
}

function Top(obj)
{
	var curtop = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curtop += obj.offsetTop
			obj = obj.offsetParent;
		}
	}
	else if (obj.y)
		curtop += obj.y;
	return curtop;
}

function checkClick(e) {
	e?evt=e:evt=event;
	CSE=evt.target?evt.target:evt.srcElement;
	if( getObj('LookupResults'))
	{
        if(!isChild(CSE,getObj('LookupResults')))
        {
            getObj('LookupResults').style.display='none';
        }	
	}
	
	if (getObj('DatePanel'))
		if (!isChild(CSE,getObj('DatePanel')))
		{
		    try
		    {
			    getObj('DatePanel').style.display='none';
			    if(!isChild(CSE,getObj('ListPanel')))
			    {
			        if(!isChild(CSE,getObj('FilterPanel')) && !isChild(CSE,getObj('FieldPanel')) )
    			        getObj('ListPanel').style.display='none';
			        getObj('FilterPanel').style.display='none';
			    }
			    if(!isChild(CSE,getObj('FieldPanel')))
			    {
    			    getObj('FieldPanel').style.display='none';
			    }
			    if(!isChild(CSE,getObj('AccessPanel')))
			    {
    			    getObj('AccessPanel').style.display='none';
			    }
			    
			    
			}
			catch(e)
			{
			    //alert(e.description);
			}
    	}
}

document.write("<div class=\"cHiddenDate\" id=\"DatePanel\">" +
"<table id=\"table4\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td><img src=\"../images/wing_01.gif\" width=\"21\" height=\"88\" alt=\"\"></td><td height=\"88\" style=\" background-repeat: repeat-x; background-position: center bottom\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" id=\"table5\"><tr><td width=1% background=\"../images/wingtop1.gif\" style=\"background-image: url('../images/wingtop1.gif'); background-repeat: repeat-x; background-position-y: bottom\">&nbsp;</td><td width=\"89\"><img border=\"0\" style=\"z-index:-1\" id=imgArrow src=\"../images/wing_03.gif\" width=\"89\" height=\"88\"></td><td background=\"../images/wingtop1.gif\" style=\"background-image: url('../images/wingtop1.gif'); background-repeat: repeat-x; background-position-y: bottom\">&nbsp;</td></tr></table></td><td><img src=\"../images/wing_05.gif\" width=\"22\" height=\"88\" alt=\"\"></td></tr><tr><td style=\"background-image: url('../images/wingleft.gif'); background-repeat: repeat-y; background-position: right center\" height=\"98\">&nbsp;</td><td bgcolor=white >" +
"<table border=\"0\" id=\"tblDateCells\" class=\"PersTD\" width=\"200\" style=\"border-collapse: collapse\" bordercolor=\"#111111\">        <tr>            <td colspan=\"7\" id=\"tdHead\" width=\"100%\" align=\"center\">                <table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">                    <tr>                        <td width=\"20\" align=\"center\">                            <a class=\"cCalBut\" style=\"background: url(../images/Calendar.gif) no-repeat 98% -63px;\" onclick=\"SubOneYear()\" title=\"سال قبل\"><img width=\"14\" height=\"14\" src=\"../images/spacer.gif\"></a></td>                        <td width=\"30\" align=\"center\">                            <a class=\"cCalBut\" style=\"background: url(../images/Calendar.gif) no-repeat 98% -20px;\" onclick=\"SubOneMonth()\" title=\"ماه قبل\"><img width=\"14\" height=\"14\" src=\"../images/spacer.gif\"></a></td>                        <td align=\"center\" id=\"TitleCell\">                            <font face=\"Tahoma\" color=\"white\" size=\"2\">F</font></td>                        <td width=\"30\" align=\"center\">                            <a class=\"cCalBut\" style=\"background: url(../images/Calendar.gif) no-repeat 98% 0px;\" onclick=\"AddOneMonth()\" title=\"ماه بعد\"><img width=\"14\" height=\"14\" src=\"../images/spacer.gif\"></a></td>                        <td width=\"20\" height=\"25\" align=\"center\">                            <a class=\"cCalBut\" style=\"background: url(../images/Calendar.gif) no-repeat 98% -42px;\" onclick=\"AddOneYear()\" title=\"سال بعد\"><img width=\"14\" height=\"14\" src=\"../images/spacer.gif\"></a></td>                    </tr>                </table>            </td>        </tr>        <tr id=\"trHeader\" class=\"cPersian2\">            <td height=\"25\"  width=\"14%\" align=\"center\">                <font id=\"Friday\">ج</font></td>            <td  width=\"14%\" align=\"center\">                <font id=\"Thursday\">پ</font></td>            <td  width=\"14%\" align=\"center\">                <font id=\"Wednesday\">چ</font></td>            <td  width=\"14%\" align=\"center\">                <font id=\"Tuesday\">س</font></td>            <td  width=\"14%\" align=\"center\">                <font id=\"Monday\">د</font></td>            <td  width=\"14%\" align=\"center\">                <font id=\"Sunday\">ی</font></td>            <td  width=\"14%\" align=\"center\">                <font id=\"Saterday\">ش</font></td>        </tr>");
Result = "";
for (I = 1; I <= 6; I++)
{
    Result += "<tr>\n";
    for ( J = 6; J >= 0; J--)
        Result += "<td height=15 bgcolor=\"" + CellBGColor + "\"  class=\"cPershand\" onclick=\"SelectDate('Cell" + ((I - 1) * 7 + J) + "')\" onmouseover=\"HighLight('Cell" + ((I - 1) * 7 + J) + "')\" onmouseout=\"UnHighLight('Cell" + ((I - 1) * 7 + J) + "')\" id=Cell" + ((I - 1) * 7 + J) + " align=center width=14% >&nbsp;</td>";
    Result += "</tr>";
}
document.write(Result)
document.write("<tr>            <td colspan=\"7\" id=\"tdFooter\" width=\"100%\" align=\"center\">                <table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">                    <tr>                        <td align=\"left\"><img src=\"../images/today.gif\" class=\"cImage\" style=\"float:right\" alt=\"امروز\" border=\"0\" onclick=\"SelectCurrentDay()\"><img id=ImageLang onclick=\"ChangeLanguage()\" class=\"cDateFa\" ></td>                        <td width=\"20\" align=\"center\">                            </td>                    </tr>                </table>            </td>        </tr>    </table>" + 
"</td><td width=\"22\" background=\"../images/wingright.gif\">&nbsp;</td></tr><tr><td><img src=\"../images/wing_09.gif\" width=\"21\" height=\"22\" alt=\"\"></td><td background=\"../images/wingbottom.gif\" height=\"22\">&nbsp;</td><td><img src=\"../images/wing_11.gif\" width=\"22\" height=\"22\" alt=\"\"></td></tr></table>" +
"</div>")

if(CurrentLang == 0)
    document.getElementById("tblDateCells").style.direction = 'rtl'
Init(Lang)
//alert( document.getElementById("bod").innerHTML)
for(i = 0; i < document.getElementById("trHeader").cells.length; i++)
    document.getElementById("trHeader").cells[i].style.backgroundColor = DayNumBGColor
document.getElementById("tdHead").style.backgroundColor = HeadBGColor
document.getElementById("tdFooter").style.backgroundColor = FooterBGColor

var DatePan = document.getElementById("DatePanel")
document.all?document.attachEvent('onclick',checkClick):document.addEventListener('click',checkClick,false);
document.all?document.body.attachEvent('onresize',checkClick):document.addEventListener('resize',checkClick,false);


