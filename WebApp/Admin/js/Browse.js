document.write("<div class=\"cHiddenDate\" id=\"ListPanel\" style=\"width:290px\"><table border='0' cellpadding='0' cellspacing='0'><tr><td class='cWin6LeftTop'></td><td class='cWin6MiddleTop'></td><td class='cWin6RightTop'></td></tr><tr><td class='cWin6LeftMiddle'></td><td style='background-color:white' id='ListPanelTD'></td><td class='cWin6RightMiddle'></td></tr><tr><td class='cWin6LeftBot'></td><td class='cWin6MiddleBot'></td><td class='cWin6RightBot'></td></tr></table></div>");
document.write("<div class=\"cHiddenDate\" id=\"FilterPanel\"></div>");
document.write("<div class=\"cHiddenDate\" id=\"FieldPanel\"></div>");


function XMLBrowse(BID, SMode) {
    this.http_request = null;
    this.BaseID = null;
    this.OrderIndex = 1
    this.CurPage = 1;
    this.RowsPerPage = 10;
    this.Repeat = 1
    this.Order = "Code";
    this.OldOrder = -1
    this.CurrentRow = null
    this.CellColor = "#ffffff"
    this.text = ""
    this.MainObj = null;
    this.TblObj = null;
    this.TblPaging = null;
    this.BoardObj = null;
    this.Keyword = ""
    this.ActiveCell = 0
    this.TblDataPaging = null;
    this.AbsPath = '../';
    this.ShowMode = 'Browse';
    this.sUrl = ""
    this.LoadingObj = null;
    this.EditForm = null;
    this.ViewForm = null;
    this.CurrentForm = null;
    this.MasterCode = ""
    this._imagePath = "../images/";
    this.LabelName = ""
    this.ObjLable = null
    this.ShowLableName = true
    this.ClassInstanceName = "BrowseObj1";
    this.DisObj = null;
    this.AllDataCell = null;
    this.PagingCell = null;
    this.RecordCount = 0;
    this.SavedRepeat = null;
    this.CellNum = 0;
    this.DeleteMode = false;
    this.FilterObj = null;
    this.FilterTable = null;
    this.FilterIndex = ''
    this.FilterColumns = ''
    this.EditWidth = 500;
    this.EditHeight = 300;
    this.FieldObj = null;
    this.FieldTable = null;
    this.ReGenerateFields = false;
    this.ConditionCode = '';
    this.ViewEdit = 'Edit';
    this.SearchOperand = 'AND'
    this.CurReqUrl = ''
    this.ViewName = ''
    this.AccessVal = 0
    this.MessageCell = null;
    this.LoadingCell = null;
    this.ShowFieldList = ''
    this.CurCookie = null;
    this.CheckFieldCount = 0;
    this.TotalWidth = 0;
    this.BrowseWidth = null;
    this.BrowseHeight = null;
    this.ForceViewPage = 0;
    this.DataContainer = null;
    this.ChangeLangCell = null;
    this.ShowGoToPage = true;
    this.NewsFlowCode = '';
    this.IGroupCode = '';

    var ClassObj = this;
    this.UpdateVal = function () {
        if (ClassObj.http_request != null) {
            if (ClassObj.http_request.readyState == 4) {
                if (ClassObj.http_request.status == 200) {
                    if (ClassObj.LoadingCell != null)
                        ClassObj.LoadingCell.className = 'cHidden'

                    result = ClassObj.http_request.responseText
                    ResultPrefix = result.substring(0, 8)
                    if (ResultPrefix == "Message:") {
                        //alert(result.split(':')[1])
                        if (ClassObj.LoadingObj != null) {
                            ClassObj.LoadingObj.style.display = 'none'
                            return;
                        }
                        else {
                            //alert('بروز خطا')
                            return;
                        }
                    }

                    ClassObj.text = result;
                    if (ClassObj.LoadingObj != null)
                        ClassObj.LoadingObj.style.display = 'none'

                    ClassObj.GenerateTable(ClassObj)
                    ClassObj.GeneratePaging(ClassObj)

                    document.body.style.cursor = 'auto';
                }
            }
        }
    }


    if (SMode != undefined)
        this.ShowMode = SMode
    this.BaseID = BID;

    this.makeRequest = function (url, Func, Method, Param, Order) {
        //this.LoadingObj.style.display = 'block'
        if (window.XMLHttpRequest) {
            this.http_request = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            this.http_request = new ActiveXObject('Microsoft.XMLHTTP');
        }
        if (url.indexOf("?") == -1)
            url = url + '?rnd=' + Math.random();
        else
            url = url + '&rnd=' + Math.random();
        if (url.indexOf("&ViewName=") == -1)
            url = url + '&ViewName=' + ClassObj.ViewName

        if (!ClassObj.DeleteMode) {
            this.http_request.onreadystatechange = this.UpdateVal; //Func
            ClassObj.CurReqUrl = url;
        }
        else {

            this.http_request.onreadystatechange = this.DeleteDone;
            ClassObj.DeleteMode = false;
        }
        if (ClassObj.LoadingCell != null)
            ClassObj.LoadingCell.className = 'cGridLoading'

        this.http_request.open(Method, url, true);
        if (Method == 'GET')
            this.http_request.send(null);
        else
            this.http_request.send(Param);

    }

    this.Reload = function () {
        ClassObj.makeRequest(ClassObj.CurReqUrl, null, 'GET', null, null);
    }

    this.setStyle = function (obj, attrName, XMLAttrName) {
        AttrVal = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute(XMLAttrName)
        if (AttrVal != null) {
            if (attrName == 'backgroundColor')
                obj.style.backgroundColor = AttrVal;
            if (attrName == 'direction')
                obj.setAttribute('dir', AttrVal);
            if (attrName == 'textAlign')
                obj.style.textAlign = AttrVal;
            if (attrName == 'width')
                obj.setAttribute('width', AttrVal);

            //eval('obj.' + attrName + ' = AttrVal');
        }


    }

    this.GetRealColName = function (OrderIndex) {
        //ColName = MainObj.childNodes[1].childNodes[OrderIndex - 1].tagName
        ColName = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[OrderIndex - 1].getAttribute("name")
        return ColName;
    }
    this.ShowFilterToolbar = function () {
        if (ClassObj.TblObj.rows[1].className == 'cVisible')
            ClassObj.TblObj.rows[1].className = 'cHidden'
        else {
            ClassObj.TblObj.rows[1].className = 'cVisible'
            this.ObjLable.style.width = ClassObj.TblDataPaging.offsetWidth + "px";
            ClassObj.DisObj.scrollLeft = 1000;
        }
    }

    this.ShowFieldListToolbar = function () {
        ClassObj.FieldObj = document.getElementById("FieldPanel");
        if (event != null)
            event.cancelBubble = true;
        X = window.event.clientX
        Y = window.event.clientY

        ClassObj.FieldObj.style.left = X - 32 + document.body.scrollLeft;
        ClassObj.FieldObj.style.top = Y + 2 + document.body.scrollTop + document.documentElement.scrollTop;

        if (ClassObj.FieldObj != null) {
            if (ClassObj.FieldObj.childNodes.length > 0) {
                ChildLen = ClassObj.FieldObj.childNodes.length
                for (rem = 0; rem < ChildLen; rem++) {
                    ClassObj.FieldObj.childNodes[0].removeNode(true);
                }
            }
        }
        ClassObj.FieldObj.appendChild(ClassObj.FieldTable);
        ClassObj.FieldObj.style.display = "block"
    }


    this.CloseFilter = function () {
        document.getElementById('Filter').style.display = 'none';
        FilterIsVisible = 0;
        if (LastActiveCol != null) {
            for (i = 1; i < TblObj.rows.length; i++)
                TblObj.rows[i].cells[LastActiveCol].style.backgroundColor = '';
        }
    }

    this.findPos = function (obj) {
        var curleft = curtop = 0;
        if (obj.offsetParent) {
            curleft = obj.offsetLeft
            curtop = obj.offsetTop
            while (obj = obj.offsetParent) {
                curleft += obj.offsetLeft
                curtop += obj.offsetTop
            }
        }
        return curtop;
    }



    this.HasAccess = function (Val) {
        return (Val & ClassObj.AccessVal)
    }

    this.IsInCurrentFilter = function (ColumnName) {
        FilterColArray = ClassObj.FilterColumns.split(';');
        for (i = 0; i < FilterColArray.length; i++) {
            if (FilterColArray[i] == ColumnName)
                return true;
        }
        return false;
    }

    this.RemoveColFromFilter = function (ColumnName) {
        NewFilterColumns = "";
        NewKeyword = "";
        NewConditionCode = "";

        FilterColArray = ClassObj.FilterColumns.split(';');
        FilterKeywordArray = ClassObj.Keyword.split(';');
        FilterConditionCodeArray = (ClassObj.ConditionCode + '').split(';');

        for (i = 0; i < FilterColArray.length; i++) {
            if (FilterColArray[i] != ColumnName) {
                //alert(FilterColArray[i] + '   ' +  ColumnName);
                NewFilterColumns = NewFilterColumns + ';' + FilterColArray[i];
                NewKeyword = NewKeyword + ';' + FilterKeywordArray[i];
                NewConditionCode = NewConditionCode + ';' + FilterConditionCodeArray[i];
            }
        }
        ClassObj.FilterColumns = NewFilterColumns
        ClassObj.Keyword = NewKeyword;
        ClassObj.ConditionCode = NewConditionCode;
    }


    this.DoFilter = function (ConditionCode, Keyword) {
        //        ConditionObj = document.getElementById("Condition");
        //        ConditionCode = ConditionObj.options[ConditionObj.selectedIndex].value;
        //        Keyword = document.getElementById('txtKeyword').value
        //        ClassObj.sUrl = this.AbsPath + 'jsGetBrowse.aspx?BaseID=' + this.BaseID + '&Order=' + this.Order + '&OldOrder=' + this.OldOrder + '&Repeat=' + this.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + 1 + '&Keyword=' + escape(Keyword) + '&FilterClm=' + this.ActiveCell + '&Condition=' + ConditionCode + '&ShowMode=' + this.ShowMode + '&MasterCode=' + this.MasterCode
        //        this.makeRequest(ClassObj.sUrl , null, 'GET', null,this.CorrectOrderIndex)
        //        this.BoardObj.innerHTML = 'جستجو روی ستون ' + ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[this.ActiveCell].getAttribute("msprop:Caption") + ' برای کلمه ' + Keyword
        //        this.CloseFilter();


        if (Keyword == undefined)
            CurrentKeyword = ConvertNumbersToEnglish(CorrectText(ClassObj.TblObj.rows[1].cells[ClassObj.FilterIndex].childNodes[0].value));
        else
            CurrentKeyword = Keyword;




        if (ConditionCode == -1) {
            ClassObj.Keyword = '';
            ClassObj.FilterIndex = '';
            ClassObj.FilterColumns = '';
            ClassObj.sUrl = this.AbsPath + 'jsGetBrowse.aspx?BaseID=' + this.BaseID + '&Order=' + this.Order + '&OldOrder=' + this.OldOrder + '&Repeat=' + this.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + 1 + '&Keyword=' + '' + '&FilterClm=' + '' + '&Condition=' + '' + '&ShowMode=' + this.ShowMode + '&MasterCode=' + this.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            ClassObj.FilterObj.style.display = "none"
            this.makeRequest(ClassObj.sUrl, null, 'GET', null, this.CorrectOrderIndex)
        }
        else {
            ClassObj.ConditionCode = ConditionCode
            if (CurrentKeyword != "") {
                if (ClassObj.FilterColumns == '') {
                    NewFilterColumns = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[ClassObj.FilterIndex].getAttribute("name");
                    NewKeyword = CurrentKeyword;
                    NewConditionCode = ConditionCode;
                }
                else {
                    CurColName = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[ClassObj.FilterIndex].getAttribute("name");
                    if (ClassObj.IsInCurrentFilter(CurColName))
                        ClassObj.RemoveColFromFilter(CurColName);
                    NewFilterColumns = ClassObj.FilterColumns + ';' + ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[ClassObj.FilterIndex].getAttribute("name");
                    NewKeyword = ClassObj.Keyword + ';' + CurrentKeyword;
                    NewConditionCode = ClassObj.ConditionCode + ';' + ConditionCode;
                }

                ClassObj.FilterColumns = NewFilterColumns
                ClassObj.Keyword = NewKeyword;
                ClassObj.ConditionCode = NewConditionCode;

                ClassObj.sUrl = this.AbsPath + 'jsGetBrowse.aspx?BaseID=' + this.BaseID + '&Order=' + this.Order + '&OldOrder=' + this.OldOrder + '&Repeat=' + this.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + 1 + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + this.ShowMode + '&MasterCode=' + this.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
                ClassObj.FilterObj.style.display = "none"
                this.makeRequest(ClassObj.sUrl, null, 'GET', null, this.CorrectOrderIndex)
            }
            else
                alert(' ! کلمه جستجو خالی است')
        }
    }
    this.RemoveCols = function (ColDataType) {
        for (cc = 0; cc < ClassObj.FilterTable.rows.length; cc++) {
            ClassObj.FilterTable.rows[cc].style.display = 'block'
        }

        for (cc = 0; cc < ClassObj.FilterTable.rows.length; cc++) {
            if (ColDataType == "System.String") {
                if (cc == 3 || cc == 4 || cc == 5 || cc == 6 || cc == 7)
                    ClassObj.FilterTable.rows[cc].style.display = 'none'
            }
        }
    }
    this.CaptureKey = function (ColIndex, TextboxObj) {
        //	        ClassObj.FilterIndex = ColIndex
        //		    ClassObj.DoFilter(0, TextboxObj.value)

        switch (event.keyCode) {
            case 13: //Enter
                ClassObj.FilterIndex = ColIndex
                ClassObj.DoFilter(0, TextboxObj.value)
                break
        }

    }

    this.ShowFilterTable = function (ColIndex) {
        ColDataType = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[ColIndex].getAttribute("msprop:DataType")
        //        alert(ColDataType)
        ClassObj.FilterIndex = ColIndex
        X = window.event.clientX
        Y = window.event.clientY
        ClassObj.FilterObj = document.getElementById("FilterPanel");
        if (ClassObj.FilterObj.childNodes.length > 0) {
            ChildLen = ClassObj.FilterObj.childNodes.length
            for (rem = 0; rem < ChildLen; rem++) {
                ClassObj.FilterObj.childNodes[0].removeNode(true);
            }
        }

        ClassObj.RemoveCols(ColDataType)
        ClassObj.FilterObj.appendChild(ClassObj.FilterTable);
        ClassObj.FilterObj.style.left = X - 32 + document.body.scrollLeft;
        ClassObj.FilterObj.style.top = Y + 2 + document.body.scrollTop + document.documentElement.scrollTop;
        ClassObj.FilterObj.style.display = "block"

    }
    this.ChangeDisplayField = function (ChangeField, Disp) {
        for (r = 0; r < ClassObj.TblObj.rows.length; r++) {
            for (c = 0; c < ClassObj.CellNum; c++) {
                FieldName = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[c].getAttribute("name")
                if (FieldName == ChangeField) {
                    ClassObj.TblObj.rows[r].cells[c].style.display = Disp;
                    break;
                }
            }
        }
    }
    this.IsInFieldList = function (FName) {
        //alert(FName)
        FieldArray = ClassObj.ShowFieldList.split(',')
        for (i = 0; i < FieldArray.length; i++) {
            if (FName == FieldArray[i])
                return true;
        }
        return false;
    }
    this.RemoveFromShowFields = function (FName) {
        Result = ''
        FieldArray = ClassObj.ShowFieldList.split(',')
        for (i = 0; i < FieldArray.length; i++) {
            if (FName != FieldArray[i]) {
                if (Result == '')
                    Result = FieldArray[i];
                else
                    Result = Result + ',' + FieldArray[i]
            }
        }
        ClassObj.ShowFieldList = Result
    }
    this.ToggleField = function (FName, checkboxObj) {
        ClassObj.CheckFieldCount = 0
        for (i = 0; i < ClassObj.FieldTable.rows.length; i++) {
            if (ClassObj.FieldTable.rows[i].cells[1].childNodes[0].checked)
                ClassObj.CheckFieldCount++;
        }

        if (checkboxObj.checked) {
            if (!ClassObj.IsInFieldList(FName)) {
                if (ClassObj.ShowFieldList == '')
                    ClassObj.ShowFieldList = FName;
                else
                    ClassObj.ShowFieldList = ClassObj.ShowFieldList + ',' + FName
            }
            ClassObj.ChangeDisplayField(FName, "block")
        }
        else {
            if (ClassObj.CheckFieldCount == 0) {
                alert('حداقل یک ستون باید انتخاب شده باقی بماند')
                checkboxObj.checked = true
                return;
            }

            ClassObj.RemoveFromShowFields(FName);
            ClassObj.ChangeDisplayField(FName, "none")
        }
        createCookie(AppName + ClassObj.BaseID, ClassObj.ShowFieldList, 30);
        this.ObjLable.style.width = ClassObj.TblDataPaging.offsetWidth + "px";

    }

    this.ModifyFieldList = function (CookieFiledList) //corrects checkboxes based on cookie
    {
        for (i = 0; i < ClassObj.FieldTable.rows.length; i++) {
            if ((CookieFiledList + ",").indexOf(ClassObj.FieldTable.rows[i].cells[1].childNodes[0].getAttribute("FieldName")) >= 0)
                ClassObj.FieldTable.rows[i].cells[1].childNodes[0].checked = true
            else
                ClassObj.FieldTable.rows[i].cells[1].childNodes[0].checked = false
        }
    }

    this.CreateFieldList = function () {
        ClassObj.FieldTable = document.createElement("TABLE");
        ClassObj.FieldTable.className = 'cFieldListTable'

        for (j = 0; j < ClassObj.CellNum; j++) {
            var myObj = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j];
            CellText = myObj.getAttribute("msprop:Caption")
            FieldName = myObj.getAttribute("name")
            DisplayMode = myObj.getAttribute("msprop:DisplayMode")

            if (DisplayMode != "Hidden") {
                if (DisplayMode == "Visible") {
                    //chkObj = document.createElement("<input type=checkbox checked>");
                    chkObj = document.createElement("input");
                    chkObj.setAttribute("type", 'checkbox');
                    chkObj.setAttribute("checked", true);

                    if (ClassObj.ShowFieldList == '')
                        ClassObj.ShowFieldList = FieldName;
                    else
                        ClassObj.ShowFieldList = ClassObj.ShowFieldList + ',' + FieldName
                }
                else {
                    //chkObj = document.createElement("<input type=checkbox >");
                    chkObj = document.createElement("input");
                    chkObj.setAttribute("type", 'checkbox');
                }

                chkObj.setAttribute("FieldName", FieldName);
                chkObj.onclick = (
		        function (f, cobj) {

		            if (event != null)
		                event.cancelBubble = true;
		            return function () {
		                ClassObj.ToggleField(f, cobj)
		            }
		        }
                )(FieldName, chkObj);
                spanObj = document.createElement("SPAN");
                spanObj.innerHTML = CellText

                newRow = ClassObj.FieldTable.insertRow()
                newCell2 = newRow.insertCell()
                newCell2.appendChild(spanObj);
                newCell1 = newRow.insertCell()
                newCell1.appendChild(chkObj);
            }
        }
        ClassObj.ReGenerateFields = false;
    }
    this.CheckedField = function (FName) {
        for (h = 0; h < ClassObj.FieldTable.rows.length; h++) {
            if (ClassObj.FieldTable.rows[h].cells[1].childNodes[0].getAttribute("FieldName") == FName) {

                if (ClassObj.FieldTable.rows[h].cells[1].childNodes[0].checked)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
    this.GenerateTable = function () {
        if (ClassObj.AllDataCell.childNodes[0] != null)
            ClassObj.AllDataCell.childNodes[0].removeNode(true);


        ClassObj.TblObj = document.createElement("TABLE");
        ClassObj.TblObj.className = "VistaGrid"
        ClassObj.TblObj.setAttribute("width", "100%")

        ClassObj.FilterObj = document.createElement("DIV");
        ClassObj.FilterTable = document.createElement("TABLE");
        ClassObj.FilterTable.className = 'cFilterTable'
        ClassObj.CreateRow(ClassObj.FilterTable, -1, 'بدون فیلتر')
        ClassObj.CreateRow(ClassObj.FilterTable, 0, 'شامل')
        ClassObj.CreateRow(ClassObj.FilterTable, 1, 'برابر با')
        ClassObj.CreateRow(ClassObj.FilterTable, 2, 'بزرگتر از')
        ClassObj.CreateRow(ClassObj.FilterTable, 3, 'بزرگتر یا مساوی')
        ClassObj.CreateRow(ClassObj.FilterTable, 4, 'کوچکتر از')
        ClassObj.CreateRow(ClassObj.FilterTable, 5, 'کوچکتر از')
        ClassObj.CreateRow(ClassObj.FilterTable, 6, 'کوچکتر یا مساوی')
        ClassObj.CreateRow(ClassObj.FilterTable, 7, 'مخالف')
        ClassObj.CreateRow(ClassObj.FilterTable, 8, 'ندارد')
        //ClassObj.CreateRow(ClassObj.FilterTable , 9 , 'بین')
        ClassObj.CreateRow(ClassObj.FilterTable, 10, 'شروع شود با')
        ClassObj.CreateRow(ClassObj.FilterTable, 11, 'متنهی شود به')
        //ClassObj.FilterObj.appendChild(ClassObj.FilterTable);

        ConditionObj = document.getElementById("Condition");
        if (ConditionObj != null)
            ConditionCode = ConditionObj.options[ConditionObj.selectedIndex].value;
        else
            ConditionCode = '';

        ClassObj.CurrentRow = 2
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM")
        xmlDoc.async = "false"
        xmlDoc.loadXML(this.text)
        ClassObj.MainObj = xmlDoc.documentElement

        var myObj = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0];
        ClassObj.RecordCount = myObj.getAttribute("msprop:RecCount")
        ClassObj.CurPage = myObj.getAttribute("msprop:CurPage")
        ClassObj.Order = myObj.getAttribute("msprop:Order")
        ClassObj.SavedRepeat = myObj.getAttribute("msprop:CurRepeat")
        ClassObj.RowsPerPage = myObj.getAttribute("msprop:RowsPerPage")
        ClassObj.CellNum = myObj.childNodes[0].childNodes[0].childNodes.length
        ClassObj.EditForm = myObj.getAttribute("msprop:EditForm")
        ClassObj.ViewForm = myObj.getAttribute("msprop:ViewForm")
        ClassObj.LabelName = myObj.getAttribute("msprop:LabelName")
        ClassObj.ViewName = myObj.getAttribute("msprop:ViewName")
        ClassObj.AccessVal = myObj.getAttribute("msprop:AccessVal")

        ClassObj.EditWidth = myObj.getAttribute("msprop:EditWidth")
        ClassObj.EditHeight = myObj.getAttribute("msprop:EditHeight")
        if (!ClassObj.HasAccess(2))
            ClassObj.ViewEdit = 'View';

        if (ClassObj.CurrentForm == null) {
            if (ClassObj.ViewEdit == 'Edit')
                ClassObj.CurrentForm = ClassObj.EditForm
            else
                ClassObj.CurrentForm = ClassObj.ViewForm
        }
        if (ClassObj.CurrentForm == "")
            ClassObj.CurrentForm = ClassObj.EditForm

        //eraseCookie(AppName + ClassObj.BaseID);
        ClassObj.CurCookie = readCookie(AppName + ClassObj.BaseID);
        if (ClassObj.FieldObj == null || ClassObj.ReGenerateFields)
            ClassObj.CreateFieldList();
        if (ClassObj.CurCookie != null) {
            ClassObj.ShowFieldList = ClassObj.CurCookie
            ClassObj.ModifyFieldList(ClassObj.CurCookie)
        }


        if (this.ShowLableName)
            this.ObjLable.innerHTML = this.LabelName
        else
            this.ObjLable.className = 'cHidden'
        ClassObj.OldOrder = ClassObj.Order

        RowCount = ClassObj.TblObj.rows.length
        for (d = 0; d < RowCount; d++) {
            ClassObj.TblObj.deleteRow(0);
        }

        newRow = ClassObj.TblObj.insertRow()
        for (j = 0; j < ClassObj.CellNum; j++) {
            StyleStr = ""
            CorrectOrderIndex = j + 1;

            //CellText = MainObj.childNodes[1].childNodes[j].tagName
            //CellText = MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("name")
            CellText = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:Caption")
            FieldName = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("name")
            DisplayMode = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:DisplayMode")

            newCell = newRow.insertCell()

            newCell.className = 'cGridHeader'
            if (ClassObj.OldOrder == this.GetRealColName(CorrectOrderIndex)) {
                ClassObj.Repeat = 1 - ClassObj.Repeat
                ClassObj.passRepeat = ClassObj.Repeat
                ImgSrc = "arrowDown.gif"
            }
            else {
                ClassObj.passRepeat = 1
                ImgSrc = "arrowUp.gif"
            }

            if (FieldName == ClassObj.OldOrder) {
                if (ClassObj.SavedRepeat == 0)
                    ImgSrc = "arrowDown.gif"
                else
                    ImgSrc = "arrowUp.gif"

                CellText = CellText + '&nbsp;<img src=../images/' + ImgSrc + '>'
            }
            this.setStyle(newCell, 'backgroundColor', 'msprop:HeaderBgColor')
            this.setStyle(newCell, 'direction', 'msprop:Direction')
            this.setStyle(newCell, 'width', 'msprop:Width')
            this.setStyle(newCell, 'textAlign', 'msprop:Alignment')
            CellText = CellText.replace("_x0020_", " ")
            sUrl = ClassObj.AbsPath + 'jsGetBrowse.aspx?BaseID=' + ClassObj.BaseID + '&Order=' + ClassObj.GetRealColName(CorrectOrderIndex) + '&OldOrder=' + ClassObj.OldOrder + '&Repeat=' + ClassObj.passRepeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + ClassObj.CurPage + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + ClassObj.ShowMode + '&MasterCode=' + ClassObj.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            CurOrder = ClassObj.GetRealColName(CorrectOrderIndex)
            newCell.onclick = (
	        function (u, o) {
	            if (event != null)
	                event.cancelBubble = true;
	            return function () {
	                ClassObj.Order = o;
	                ClassObj.makeRequest(u, null, 'GET', null)
	            }
	        }
            )(sUrl, CurOrder);

            newCell.innerHTML = "<nobr>" + CellText + "</nobr>";
            ClassObj.Repeat = ClassObj.SavedRepeat

            if (!ClassObj.CheckedField(FieldName)) {
                if (DisplayMode == "Hidden" || (ClassObj.ShowFieldList + ",").indexOf(FieldName + ",") == -1)
                    newCell.style.display = 'none'
            }

        }

        //Filter Row
        newRow = ClassObj.TblObj.insertRow()
        if (ClassObj.Keyword == "")
            newRow.className = "cHidden"
        for (j = 0; j < ClassObj.CellNum; j++) {
            FieldName = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("name")
            DisplayMode = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:DisplayMode")

            InputObj = document.createElement("INPUT")
            InputObj.className = 'cInput';
            InputObj.size = '10'

            if (ClassObj.Keyword != "") {
                if (ClassObj.CurrentColIsFiltered(FieldName)) {
                    InputObj.value = ClassObj.GetColKeyword(FieldName);
                }
            }



            InputObj.onkeypress = (
		        function () {
		            FaKeyPressWithEnglishNumbers();
		        }
                );



            InputObj.onkeyup = (
		        function (fieldIndex, InputObj) {
		            return function () {
		                if (event != null)
		                    ClassObj.CaptureKey(fieldIndex, InputObj)
		            }
		        }
                )(j, InputObj);


            //            if(ClassObj.Keyword != "")
            //            {
            //                if(j == ClassObj.FilterIndex)
            //                {
            //                    InputObj.value = ClassObj.Keyword
            //                }
            //            }

            FilterImageObj = document.createElement("IMAGE")
            FilterImageObj.src = "../images/Filter.gif";
            FilterImageObj.onclick = (
		        function (fieldIndex) {
		            return function () {
		                if (event != null)
		                    event.cancelBubble = true;
		                ClassObj.ShowFilterTable(fieldIndex)
		            }
		        }
                )(j);


            newCell = newRow.insertCell()
            newCell.appendChild(InputObj)
            newCell.appendChild(FilterImageObj)
            IsFieldSelected = ClassObj.CheckedField(FieldName);
            if (DisplayMode != "Hidden" && IsFieldSelected) {
                newCell.className = 'cGridFilter'
                //                if( (ClassObj.ShowFieldList + ",").indexOf(FieldName+",") == -1 )
                //                {
                //                }
            }
            else
                newCell.style.display = 'none'
        }



        for (i = 1; i < ClassObj.MainObj.childNodes.length; i++) {
            newRow = ClassObj.TblObj.insertRow()
            for (j = 0; j < ClassObj.MainObj.childNodes[i].childNodes.length; j++) {
                newCell = newRow.insertCell()
                FieldName = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("name")
                FieldWidth = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:Width")
                CellText = ClassObj.MainObj.childNodes[i].childNodes[j].text
                CellText = CellText.replace("_x0020_", " ")
                DisplayMode = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:DisplayMode")
                IsKey = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[j].getAttribute("msprop:IsKey")


                ClassObj.TotalWidth = ClassObj.TotalWidth + parseInt(FieldWidth, 10)

                if (!ClassObj.CheckedField(FieldName)) {
                    if (DisplayMode == "Hidden" || (ClassObj.ShowFieldList + ",").indexOf(FieldName + ",") == -1)
                        newCell.style.display = 'none'
                }

                if (CellText.indexOf("\n") > 0) {
                    intFieldWidth = FieldWidth.replace("px", "")
                    intFieldWidth = parseInt(intFieldWidth, 10)
                    LineBreakPos = CellText.indexOf("\n");
                    if (LineBreakPos < intFieldWidth)
                        CellText = CellText.substr(0, LineBreakPos) + "...";
                    else
                        CellText = CellText.substr(0, intFieldWidth) + "...";
                }

                ValidCharCount = FieldWidth.replace("px", "") / 4.5
                ValidCharCount = parseInt(ValidCharCount, 10)
                //if(CellText.length > ValidCharCount)
                //    CellText = CellText.substring(0,ValidCharCount) + "..."


                newCell.innerHTML = CellText
                if (i == 1)
                    newCell.className = 'GridTDOver'
                else
                    newCell.className = 'cGridDataCell'
                newCell.onclick = function () {
                    event.cancelBubble = true;
                    ClassObj.ChangeColor(this)
                }
                newCell.ondblclick = (
	            function (InnerI) {
	                if (event != null)
	                    event.cancelBubble = true;
	                return function () {
	                    KeyCol = ClassObj.GetKeyCollection(this.parentNode.rowIndex)
	                    if (event != null)
	                        event.cancelBubble = true;
	                    ClassObj.DoUpdate(InnerI, KeyCol);
	                }
	            }
                )(i);



                //newCell.style.backgroundColor = this.CellColor

                //this.setStyle(newCell, 'backgroundColor', 'msprop:BgColor')
                this.setStyle(newCell, 'direction', 'msprop:Direction')
                this.setStyle(newCell, 'textAlign', 'msprop:Alignment')

                //newCell.onmousedown = new Function ("StartDrag(this)")
                //newCell.onmouseup = new Function ("EndDrag(this)")
            }
        }
        ClassObj.AllDataCell.appendChild(ClassObj.TblObj);
        getObj('FieldPanel').style.display = 'none';
        if (ClassObj.RecordCount == 0)
            ClassObj.DisObj.style.overflow = "hidden";


    }

    this.GetKeyCollection = function (RowIndex) {
        CorrectRowIndex = RowIndex - 1
        CurCodeList = ""
        for (r = 0; r < ClassObj.MainObj.childNodes[CorrectRowIndex].childNodes.length; r++) {
            IsKey = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[r].getAttribute("msprop:IsKey")
            CellText = ClassObj.MainObj.childNodes[CorrectRowIndex].childNodes[r].text
            CellText = CellText.replace("_x0020_", " ")
            //alert(CellText)
            if (IsKey == "1") {
                if (CurCodeList == "")
                    CurCodeList = CellText
                else
                    CurCodeList = CurCodeList + ";" + CellText
            }
        }
        return CurCodeList
    }

    this.GetNameListCollection = function (RowIndex) {
        NameList = ""
        for (r = 0; r < ClassObj.MainObj.childNodes[RowIndex].childNodes.length; r++) {
            IsListTitle = ClassObj.MainObj.childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[0].childNodes[r].getAttribute("msprop:IsListTitle")
            CellText = ClassObj.MainObj.childNodes[RowIndex].childNodes[r].text
            CellText = CellText.replace("_x0020_", " ")
            if (IsListTitle == "1") {
                if (NameList == "")
                    NameList = CellText
                else
                    NameList = NameList + " " + CellText
            }
        }
        return NameList
    }

    this.CurrentColIsFiltered = function (ColName) {
        ColArray = ClassObj.FilterColumns.split(';');
        for (i = 0; i < ColArray.length; i++) {
            if (ColName == ColArray[i]) {
                return true;
            }
        }
        return false;
    }
    this.GetColKeyword = function (ColName) {
        ColArray = ClassObj.FilterColumns.split(';');
        if (ClassObj.Keyword.toString().indexOf(';') >= 0) {
            KeyArray = ClassObj.Keyword.split(';');
            for (i = 0; i < ColArray.length; i++) {
                if (ColName == ColArray[i]) {
                    return KeyArray[i];
                }
            }
        }
        return "";
    }


    this.GetCorrectActiveCell = function (RowObj, ClickObj) //display none cells does not count in cellIndex
    {
        ResultVal = 0;
        for (c = 0; c < RowObj.cells.length; c++) {
            if (RowObj.cells[c] == ClickObj)
                break
            ResultVal++;
        }
        return ResultVal;
    }

    this.ChangeColor = function (Obj) {
        if (ClassObj.CurrentRow != null)
            for (i = 0; i < ClassObj.TblObj.rows[ClassObj.CurrentRow].cells.length; i++) {
                if (ClassObj.CurrentRow != 1)
                    ClassObj.TblObj.rows[ClassObj.CurrentRow].cells[i].className = 'cGridDataCell';
                //ClassObj.TblObj.rows[ClassObj.CurrentRow].cells[i].className = 'GridTDOut';
            }
        //	for(i=0; i < Obj.parentNode.cells.length; i++)
        //		Obj.parentNode.cells[i].style.backgroundColor = '#D4DAE4';
        //	Obj.style.backgroundColor = '#ABB7CB';

        for (i = 0; i < Obj.parentNode.cells.length; i++)
            Obj.parentNode.cells[i].className = 'GridTDOver';

        if (event != null)
            if (event.srcElement != null)
                this.ActiveCell = this.GetCorrectActiveCell(event.srcElement.parentNode, event.srcElement)
        ClassObj.CurrentRow = Obj.parentNode.rowIndex
        getObj('FilterPanel').style.display = 'none';
        getObj('FieldPanel').style.display = 'none';
        //alert(ClassObj.CurrentRow)
    }

    this.NewRecord = function () {
        Url = this.AbsPath + this.EditForm + "?BaseID=" + this.BaseID + "&Code=" + '&MasterCode=' + this.MasterCode + '&InstanceName=' + ClassObj.ClassInstanceName
        if (this.ShowMode == "List")
            OpenWin(Url, ClassObj.EditWidth, ClassObj.EditHeight)
        else {
            if (this.MasterCode == "")
                window.location.href = this.AbsPath + this.EditForm + "?BaseID=" + this.BaseID + "&Code=";
                //OpenWin(this.AbsPath + this.EditForm + "?BaseID=" + this.BaseID + "&Code=", ClassObj.EditWidth, ClassObj.EditHeight, true);
            else
                OpenWin(Url, ClassObj.EditWidth, ClassObj.EditHeight);
        }

    }

    this.DoUpdate = function (RowIndex, CodeList, ForceViewOrEditForm) {
        try {
            if (ClassObj.ForceViewPage == 1)
                ClassObj.CurrentForm = ClassObj.ViewForm;

            if (ClassObj.CurrentForm == "")
                ClassObj.CurrentForm = ClassObj.EditForm;


            if (ForceViewOrEditForm != undefined) {
                if (ForceViewOrEditForm != "")
                    ClassObj.CurrentForm = ForceViewOrEditForm;
            }

            if (ClassObj.CurrentForm != "") {

                Url = ClassObj.AbsPath + ClassObj.CurrentForm + "?BaseID=" + ClassObj.BaseID + "&Code=" + CodeList + '&MasterCode=' + ClassObj.MasterCode + '&InstanceName=' + ClassObj.ClassInstanceName + '&Keyword=' + ClassObj.Keyword + '&FilterColumns=' + ClassObj.FilterColumns + '&ConditionCode=' + ClassObj.ConditionCode
                if (ClassObj.ViewEdit == 'View')
                    Url = Url + '&ViewMode=1'

                if (this.ShowMode != "List") {

                    if(this.MasterCode == "")
                        window.location.href = Url
                     else
                    OpenWin(Url, ClassObj.EditWidth, ClassObj.EditHeight, true)
                }
                else {
                    FormFieldCode.value = CodeList
                    FormFieldName.value = this.GetNameListCollection(RowIndex)
                    //ClassObj.DisObj.style.display = "none"
                    document.getElementById('ListPanel').style.display = "none"

                    this.ShowMode = "Browse";
                }
            }
        }
        catch (e) {
            alert(e.description)
        }
    }


    this.ExportToExcel = function () {
        Params = ClassObj.CurReqUrl.replace('../jsGetBrowse.aspx?', '')
        Params = Params + '&ShowFieldList=' + this.ShowFieldList
        if (Params.indexOf("rnd=") == -1)
            Params = Params + '&rnd=' + Math.random();

        window.open('../ExportGrid.aspx?' + Params, 'ExportToExcel', 'width=900,height=600')
    }


    this.DeleteDone = function () {
        if (ClassObj.http_request.readyState == 4) {
            if (ClassObj.http_request.status == 200) {
                result = ClassObj.http_request.responseText
                if (result == "DELETED") {
                    //alert("رکورد با موفقیت حذف شد")
                    //ClassObj.TblObj.deleteRow(ClassObj.CurrentRow);
                    ClassObj.TblObj.rows[ClassObj.CurrentRow].className = 'cHidden'
                    ClassObj.CurrentRow = 1;
                }
                else if (result.indexOf("FK_") > 0)
                    alert('این رکورد دارای اطلاعات مرتبط میباشد و قابل حذف نیست')
                //ClassObj.TblObj.deleteRow(ClassObj.CurrentRow);
                if (ClassObj.LoadingCell != null)
                    ClassObj.LoadingCell.className = 'cHidden'
                document.body.style.cursor = 'auto';
            }
        }
    }



    this.GetLowerPageLimit = function (Offset) {
        Result = ClassObj.CurPage - Offset
        if (Result <= 0)
            Result = 1
        return Result
    }

    this.CreateRow = function (tblFil, Val, Text) {
        newRow = tblFil.insertRow()
        newCell = newRow.insertCell()
        newCell.innerHTML = Text
        newCell.value = Val
        newCell.onclick = (
		        function (td) {
		            return function () {
		                ClassObj.DoFilter(Val);
		            }
		        }
                )(this);
    }

    this.GoToPage = function (buttonobj) {
        PageNum = parseInt((ClassObj.RecordCount / ClassObj.RowsPerPage), 10)

        NewPageNum = buttonobj.parentNode.childNodes[1].value
        if (NewPageNum <= PageNum && PageNum > 0) {
            qStr = 'BaseID=' + ClassObj.BaseID + '&Order=' + ClassObj.Order + '&OldOrder=' + ClassObj.OldOrder + '&Repeat=' + ClassObj.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + NewPageNum + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + ClassObj.ShowMode + '&MasterCode=' + ClassObj.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            sUrl = ClassObj.AbsPath + 'jsGetBrowse.aspx?' + qStr;
            ClassObj.makeRequest(sUrl, null, 'GET', null)
        }
        else
            alert('صفجه درخواستی معتبر نیست');
    }

    this.GeneratePaging = function () {

        if (ClassObj.PagingCell.childNodes[0] != null)
            ClassObj.PagingCell.childNodes[0].removeNode(true);
        TblPaging = document.createElement("TABLE");
        //TblPaging.setAttribute("cellpadding","20")
        ConditionObj = document.getElementById("Condition");
        if (ConditionObj != null)
            ConditionCode = ConditionObj.options[ConditionObj.selectedIndex].value;
        else
            ConditionObj = '';

        RowCount = TblPaging.rows.length
        if (TblPaging.rows.length == 1)
            TblPaging.deleteRow(0);

        PageNum = parseInt((ClassObj.RecordCount / ClassObj.RowsPerPage), 10)
        if ((ClassObj.RecordCount % ClassObj.RowsPerPage) > 0)
            PageNum = parseInt(PageNum, 10) + 1

        PageNumPlus = parseInt(PageNum, 10) + 1
        CurPageMinus = parseInt(ClassObj.CurPage, 10) - 1
        CurPagePlus = parseInt(ClassObj.CurPage, 10) + 1

        newRow = TblPaging.insertRow()
        newRow.className = 'pager'


        //ClassObj.LoadingCell = newRow.insertCell()
        //ClassObj.LoadingCell.className = 'cHidden'


        ClassObj.MessageCell = newRow.insertCell()
        ClassObj.MessageCell.className = 'cMessageCell'


        RecordCountCell = newRow.insertCell()
        RecordCountCell.className = 'cPersianContent'
        RecordCountCell.setAttribute("NOBR", "");
        RecordCountCell.innerHTML = "<nobr>&nbsp;تعداد رکوردها:&nbsp;</nobr>" + ClassObj.RecordCount

        if (ClassObj.ShowGoToPage) {
            GoToPageCell = newRow.insertCell()
            GoToPageCell.className = 'cPersianContent'
            GoToPageCell.setAttribute("NOBR", "");
            GoToPageCell.innerHTML = "<nobr>&nbsp;صفحه:&nbsp;</nobr>" + "<input onkeypress = 'return IsOnlyNumber()' type='text' name='NewPageNum' value='" + ClassObj.CurPage + "' size='2' >&nbsp;";
            ButtonObj = document.createElement("INPUT");
            ButtonObj.value = '  برو  '
            ButtonObj.type = 'button';
            ButtonObj.onclick = (
        function (cobj) {

            return function () {
                ClassObj.GoToPage(cobj);
            }
        }
        )(ButtonObj);

            GoToPageCell.appendChild(ButtonObj);
        }
        if (ClassObj.CurPage > 1) {
            GoToFirstCell = newRow.insertCell()
            GoToFirstCell.className = 'cPersianContent'
            GoToFirstCell.innerHTML = " »» "
            sUrl = this.AbsPath + 'jsGetBrowse.aspx?BaseID=' + this.BaseID + '&Order=' + this.Order + '&OldOrder=' + this.OldOrder + '&Repeat=' + this.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + 1 + '&Keyword=' + escape(this.Keyword) + '&FilterClm=' + this.ActiveCell + '&Condition=' + this.ConditionCode + '&ShowMode=' + this.ShowMode + '&MasterCode=' + this.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            GoToFirstCell.onclick = (
	        function (u) {
	            if (event != null)
	                event.cancelBubble = true;
	            return function () {
	                ClassObj.makeRequest(u, null, 'GET', null)
	            }
	        }
            )(sUrl);


            GoToPreCell = newRow.insertCell()
            GoToPreCell.className = 'cPersianContent'
            GoToPreCell.innerHTML = " » "

            sUrl = ClassObj.AbsPath + 'jsGetBrowse.aspx?BaseID=' + ClassObj.BaseID + '&Order=' + ClassObj.Order + '&OldOrder=' + ClassObj.OldOrder + '&Repeat=' + ClassObj.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + CurPageMinus + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + ClassObj.ShowMode + '&MasterCode=' + ClassObj.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            GoToPreCell.onclick = (
		    function (u) {
		        if (event != null)
		            event.cancelBubble = true;
		        return function () {
		            ClassObj.makeRequest(u, null, 'GET', null)
		        }
		    }
            )(sUrl);

        }


        for (j = this.GetLowerPageLimit(4); j < this.GetLowerPageLimit(4) + 6; j++) {
            if (j > PageNum)
                break;
            newCell = newRow.insertCell()
            CellText = j

            //newCell.innerHTML = '<a href=#>' + GetPersianNumber(CellText) + '</a>'
            newCell.innerHTML = '<span>' + GetPersianNumber(CellText) + '</span>'
            if (j == ClassObj.CurPage)
                newCell.className = 'current'
            else
                newCell.className = 'cPersianContent'
            strPage = j;
            sUrl = ClassObj.AbsPath + 'jsGetBrowse.aspx?BaseID=' + ClassObj.BaseID + '&Order=' + ClassObj.Order + '&OldOrder=' + ClassObj.OldOrder + '&Repeat=' + ClassObj.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + strPage + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + ClassObj.ShowMode + '&MasterCode=' + ClassObj.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            newCell.onclick = (
		    function (u) {
		        return function () {
		            ClassObj.makeRequest(u, null, 'GET', null)
		        }
		    }
            )(sUrl);


        }
        if (ClassObj.CurPage < PageNum) {
            GoToNextCell = newRow.insertCell()
            GoToNextCell.className = 'cPersianContent'
            GoToNextCell.innerHTML = " « "
            sUrl = ClassObj.AbsPath + 'jsGetBrowse.aspx?BaseID=' + ClassObj.BaseID + '&Order=' + ClassObj.Order + '&OldOrder=' + ClassObj.OldOrder + '&Repeat=' + ClassObj.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + CurPagePlus + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + ClassObj.ShowMode + '&MasterCode=' + ClassObj.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            GoToNextCell.onclick = (
		    function (u) {
		        return function () {
		            ClassObj.makeRequest(u, null, 'GET', null)
		        }
		    }
            )(sUrl);


            GoToLastCell = newRow.insertCell()
            GoToLastCell.className = 'cPersianContent'
            GoToLastCell.innerHTML = " «« "
            sUrl = ClassObj.AbsPath + 'jsGetBrowse.aspx?BaseID=' + ClassObj.BaseID + '&Order=' + ClassObj.Order + '&OldOrder=' + ClassObj.OldOrder + '&Repeat=' + ClassObj.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + PageNum + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + ClassObj.ShowMode + '&MasterCode=' + ClassObj.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
            GoToLastCell.onclick = (
		    function (u) {
		        return function () {
		            ClassObj.makeRequest(u, null, 'GET', null)
		        }
		    }
            )(sUrl);

        }

        ExportExcelCell = newRow.insertCell()
        ExportExcelCell.className = 'cExportToExcel'
        LinkObj = document.createElement("IMG");
        LinkObj.setAttribute("src", "../images/spacer.gif");
        LinkObj.setAttribute("alt", "انتقال اطلاعات به اکسل");
        LinkObj.className = 'cExportToExcel'
        ExportExcelCell.appendChild(LinkObj)

        ExportExcelCell.onclick = function () { ClassObj.ExportToExcel() }


        RefreshCell = newRow.insertCell()
        LinkObj = document.createElement("IMG");
        LinkObj.setAttribute("src", "../images/spacer.gif");
        LinkObj.setAttribute("alt", "بازخوانی");
        LinkObj.className = 'cRefresh'
        RefreshCell.appendChild(LinkObj)
        RefreshCell.onclick = function () { ClassObj.Reload() }

        if (ClassObj.RecordCount > 0) {
            FilterCell = newRow.insertCell()
            LinkObj = document.createElement("IMG");
            LinkObj.setAttribute("src", "../images/spacer.gif");
            LinkObj.setAttribute("alt", "فیلتر");
            LinkObj.className = 'cFilter'
            FilterCell.appendChild(LinkObj)

            FilterCell.onclick = function () { ClassObj.ShowFilterToolbar() }
        }


        AddFieldCell = newRow.insertCell()
        LinkObj = document.createElement("IMG");
        LinkObj.setAttribute("src", "../images/spacer.gif");
        LinkObj.setAttribute("alt", "تغییر ستونها");
        LinkObj.className = 'cAddField'
        AddFieldCell.appendChild(LinkObj)

        AddFieldCell.onclick = function () { ClassObj.ShowFieldListToolbar() }


        if ((ClassObj.HasAccess(2) || ClassObj.HasAccess(4)) && ClassObj.RecordCount > 0 && ClassObj.ViewEdit == 'Edit') {
            DeleteCell = newRow.insertCell()
            LinkObj = document.createElement("IMG");
            LinkObj.setAttribute("src", "../images/spacer.gif");
            LinkObj.setAttribute("alt", "حذف");
            LinkObj.className = 'cBrowseDelete'
            DeleteCell.appendChild(LinkObj)
            DeleteCell.onclick = function () { ClassObj.DeleteRecord() }
        }

        if (ClassObj.RecordCount > 0) {
            ViewCell = newRow.insertCell()
            LinkObj = document.createElement("IMG");
            LinkObj.setAttribute("src", "../images/spacer.gif");
            LinkObj.setAttribute("alt", "نمایش");
            LinkObj.className = 'cViewIcon'
            ViewCell.appendChild(LinkObj)
            ViewCell.onclick = (
	                function (InnerI, VEForm) {
	                    if (event != null)
	                        event.cancelBubble = true;
	                    return function () {
	                        KeyCol = ClassObj.GetKeyCollection(ClassObj.CurrentRow)
	                        if (event != null)
	                            event.cancelBubble = true;

	                        ClassObj.DoUpdate(InnerI, KeyCol, VEForm);
	                    }
	                }
                    )(ClassObj.CurrentRow, ClassObj.ViewForm);

        }
        if (ClassObj.ViewEdit == 'Edit' && ClassObj.ViewEdit != 'NewOnly' && ClassObj.HasAccess(2)) {
            EditCell = newRow.insertCell()
            LinkObj = document.createElement("IMG");
            LinkObj.setAttribute("src", "../images/spacer.gif");
            LinkObj.setAttribute("alt", "ویرایش");
            LinkObj.className = 'cEdit'
            EditCell.appendChild(LinkObj)

            EditCell.onclick = (
	                function (InnerI, VEForm) {
	                    if (event != null)
	                        event.cancelBubble = true;
	                    return function () {
	                        KeyCol = ClassObj.GetKeyCollection(ClassObj.CurrentRow)
	                        if (event != null)
	                            event.cancelBubble = true;
	                        ClassObj.DoUpdate(InnerI, KeyCol, VEForm);
	                    }
	                }
                    )(ClassObj.CurrentRow, ClassObj.EditForm);

        }

        if (ClassObj.HasAccess(1) && (ClassObj.ViewEdit == 'Edit' || ClassObj.ViewEdit == 'NewOnly')) {
            NewRecordCell = newRow.insertCell()
            LinkObj = document.createElement("IMG");
            LinkObj.setAttribute("src", "../images/spacer.gif");
            LinkObj.setAttribute("alt", "ایجاد");
            LinkObj.className = 'cBrowseNewRec'
            NewRecordCell.appendChild(LinkObj)
            NewRecordCell.onclick = function () { ClassObj.NewRecord() }
        }


        if (ClassObj.Keyword != "" && ClassObj.RecordCount == 0) {
            //NoResultMessage = " هیچ نتیجه ای برای <b>" + ClassObj.Keyword + "</b> پیدا نشد ";
            NoResultMessage = " هیچ نتیجه ای پیدا نشد ";
            NoResultMessage = "<div class=\"cMsg\">" + NoResultMessage + "</div>";
            ClassObj.MessageCell.style.display = 'block';
            ClassObj.MessageCell.innerHTML = NoResultMessage;
        }
        ClassObj.PagingCell.appendChild(TblPaging);
        ClassObj.DisObj.scrollLeft = 1000;

        this.ObjLable.style.width = ClassObj.TblDataPaging.offsetWidth + "px";
    }

    this.CreateOnclick = function (CorrectOrderIndex, sUrl) {
        CorrectOrderIndex = this.cellIndex + 2
        sUrl = ClassObj.AbsPath + 'jsGetBrowse.aspx?BaseID=' + ClassObj.BaseID + '&Order=' + ClassObj.Order + '&OldOrder=' + ClassObj.OldOrder + '&Repeat=' + ClassObj.Repeat + '&RowsPerPage=' + ClassObj.RowsPerPage + '&CurPage=' + PageNum + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&ShowMode=' + ClassObj.ShowMode + '&MasterCode=' + ClassObj.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode;
        ClassObj.makeRequest(ClassObj.sUrl, null, 'GET', null, CorrectOrderIndex)
    }

    this.DeleteRecord = function () {
        AskDel = confirm("رکورد حذف شود ؟")
        if (!AskDel)
            return;
        KeyList = this.GetKeyCollection(ClassObj.CurrentRow)
        ClassObj.DeleteMode = true;
        this.makeRequest(this.AbsPath + 'jsGetBrowse.aspx?BaseID=' + this.BaseID + "&DelCode=" + KeyList + '&MasterCode=' + this.MasterCode + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode, new Function('ClassObj.DeleteDone()'), 'GET', new Function("ClassObj.UpdateVal()"), 1)
        //ClassObj.CurrentRow = 2
        //ClassObj.ChangeColor(ClassObj.TblObj.rows[2].cells[0])
        //ClassObj.TblObj.deleteRow(ClassObj.CurrentRow);
    }

    var FromRow = null;
    var ToRow = null;
    this.StartDrag = function (Obj) {
        //    ChangeColor(Obj);
        FromRow = Obj;
        document.body.style.cursor = 'move';
    }
    this.EndDrag = function (Obj) {
        ToRow = Obj;
        SavedFromRow = FromRow;
        SavedToRow = ToRow;
        if (FromRow != null) {
            try {
                for (j = 0; j < SavedFromRow.parentNode.parentNode.rows.length; j++) {
                    SavedFromRow.parentNode.parentNode.rows[j].cells[SavedFromRow.cellIndex].swapNode(SavedToRow.parentNode.parentNode.rows[j].cells[SavedToRow.cellIndex])
                    SavedFromRow = FromRow;
                    SavedToRow = ToRow;
                }
            }
            catch (e) {
                alert(e.message)
            }
        }
        FromRow = null;
        ToRow = null;
        document.body.style.cursor = '';
    }

    //document.onmouseup = new Function ("FromRow=null;EndDrag(null)") 
    //document.onselectstart=new Function ("return false") 

    this.CreateBrowse = function (BID, SMode, FilterCols, Keyword, ConditionCode, ViewEdit, BrowseWidth, BrowseHeight) {
        ClassObj.FilterIndex = '';
        ClassObj.FilterColumns = ''
        ClassObj.Keyword = '';
        ClassObj.ReGenerateFields = true;

        if (BrowseWidth != undefined)
            ClassObj.BrowseWidth = BrowseWidth;
        if (BrowseHeight != undefined)
            ClassObj.BrowseHeight = BrowseHeight;

        if (ViewEdit != undefined)
            ClassObj.ViewEdit = ViewEdit;

        if (ViewEdit == "")
            ClassObj.ViewEdit = 'Edit';


        if (FilterCols != undefined) {
            ClassObj.FilterColumns = FilterCols
            ClassObj.Keyword = Keyword
            ClassObj.ConditionCode = ConditionCode
        }

        if (SMode != undefined)
            this.ShowMode = SMode;
        this.BaseID = BID

        EditAreaObj = document.getElementById('EditArea')
        ClassObj.TblDataPaging = document.createElement("TABLE");
        if (this.ShowMode == "List") {
            X = window.event.clientX + document.body.scrollLeft;
            Y = window.event.clientY + document.body.scrollTop + document.documentElement.scrollTop;
            //DisObj = document.createElement("DIV");
            //DisObj.setAttribute("width", "100%");
            ClassObj.DisObj = document.getElementById('ListPanelTD')
            document.getElementById('ListPanel').style.left = X - 263 + document.body.scrollLeft;
            document.getElementById('ListPanel').style.top = Y + 13 + document.body.scrollTop;
            document.getElementById('ListPanel').style.display = "block"
        }
        else {
            //document.getElementById('ListPanel').style.display = "none"
            ClassObj.TblDataPaging.setAttribute("width", "100%");

            if (ClassObj.DisObj == null)
                ClassObj.DisObj = document.getElementById('DisplayArea')
            if (EditAreaObj) {
                if (EditAreaObj.childNodes[0] != null)
                    EditAreaObj.childNodes[0].removeNode(true)
            }
        }
        if (ClassObj.DisObj != null) {
            if (ClassObj.DisObj.childNodes[0] != null) {
                ChildLen = ClassObj.DisObj.childNodes.length
                for (rem = 0; rem < ChildLen; rem++) {
                    ClassObj.DisObj.childNodes[0].removeNode(true);
                }
            }
        }
        Row1 = ClassObj.TblDataPaging.insertRow()
        ClassObj.AllDataCell = Row1.insertCell();
        Row2 = ClassObj.TblDataPaging.insertRow()
        ClassObj.PagingCell = Row2.insertCell();
        ClassObj.PagingCell.className = 'cFooterPaging'

        Row3 = ClassObj.TblDataPaging.insertRow()
        ClassObj.LoadingCell = Row3.insertCell();
        ClassObj.LoadingCell.className = 'cHidden'


        //        this.LoadingObj = document.createElement("DIV");
        //        this.LoadingObj.className = 'cLoading'
        //        this.BoardObj = document.createElement("DIV");

        this.ObjLable = document.createElement("DIV");
        this.ObjLable.className = 'cBrowseLabel'
        //ClassObj.ObjLable.style.width = ClassObj.TotalWidth + "px";
        if (ClassObj.BrowseWidth != null)
            ClassObj.DisObj.style.width = ClassObj.BrowseWidth + "px";
        if (ClassObj.BrowseHeight != null)
            ClassObj.DisObj.style.height = ClassObj.BrowseHeight + "px";

        ClassObj.DisObj.appendChild(this.ObjLable);

        ClassObj.DisObj.appendChild(ClassObj.TblDataPaging);



        //alert(ClassObj.DisObj.scrollLeft);
        //        ClassObj.DisObj.appendChild(this.LoadingObj);
        //        ClassObj.DisObj.appendChild(this.BoardObj);
        //        
        this.makeRequest(this.AbsPath + 'jsGetBrowse.aspx?BaseID=' + this.BaseID + '&ShowMode=' + this.ShowMode + '&MasterCode=' + this.MasterCode + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&SearchOperand=' + ClassObj.SearchOperand + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode, new Function("ClassObj.UpdateVal()"), 'GET', new Function("ClassObj.UpdateVal()"), 1)
    }



    this.HandleBrowseKeypress = function () {
        try {
            var IsKeyCodeCaptured = false;
            switch (event.keyCode) {
                case 118: //F7 key (New)
                    ClassObj.NewRecord();
                    IsKeyCodeCaptured = true;
                    break;
                case 114: //F3 key (DELETE)
                    ClassObj.DeleteRecord();
                    IsKeyCodeCaptured = true;
                    break;

            }
            if (IsKeyCodeCaptured) {
                event.keyCode = 0;
                event.returnValue = false;
                event.cancelBubble = true;
                return false;
            }
        }
        catch (e) {
        }

    }

    this.ShowDetail = function (BID, MCodes, SPL, InstanceName, ViewEdit, BrowseWidth, BrowseHeight) {
        ClassObj.FilterIndex = '';
        ClassObj.FilterColumns = ''
        ClassObj.Keyword = '';
        ClassObj.ReGenerateFields = true;

        if (BrowseWidth != undefined)
            ClassObj.BrowseWidth = BrowseWidth;
        if (BrowseHeight != undefined)
            ClassObj.BrowseHeight = BrowseHeight;

        if (ClassObj.BrowseWidth == null)
            ClassObj.BrowseWidth = 580;


        if (ViewEdit != undefined)
            ClassObj.ViewEdit = ViewEdit
        if (InstanceName != undefined)
            ClassObj.ClassInstanceName = InstanceName
        if (SPL != undefined)
            ClassObj.ShowLableName = SPL;
        if (MCodes != undefined)
            ClassObj.MasterCode = MCodes
        ClassObj.TblDataPaging = document.createElement("TABLE");
        ClassObj.TblDataPaging.setAttribute("width", "100%");
        ClassObj.DisObj = document.getElementById(BID)
        if (ClassObj.DisObj.childNodes[0] != null) {
            ChildLen = ClassObj.DisObj.childNodes.length
            for (rem = 0; rem < ChildLen; rem++) {
                ClassObj.DisObj.childNodes[0].removeNode(true);
            }
        }

        ClassObj.className = 'cBrowseContainer'
        Row1 = ClassObj.TblDataPaging.insertRow()
        ClassObj.AllDataCell = Row1.insertCell();
        Row2 = ClassObj.TblDataPaging.insertRow()
        ClassObj.PagingCell = Row2.insertCell();
        ClassObj.PagingCell.className = 'cFooterPaging'
        ClassObj.LoadingObj = document.createElement("DIV");
        ClassObj.LoadingObj.className = 'cLoading'
        ClassObj.BoardObj = document.createElement("DIV");

        ClassObj.ObjLable = document.createElement("DIV");
        ClassObj.ObjLable.className = 'cBrowseLabel'
        ClassObj.DisObj.appendChild(ClassObj.ObjLable);

        ClassObj.DisObj.appendChild(ClassObj.TblDataPaging);
        ClassObj.DisObj.appendChild(ClassObj.LoadingObj);
        ClassObj.DisObj.appendChild(ClassObj.BoardObj);
        ClassObj.BaseID = BID
        //        alert('jsGetBrowse.aspx?BaseID=' + this.BaseID + '&ShowMode=' + this.ShowMode + '&MasterCode=' + this.MasterCode)


        if (ClassObj.BrowseWidth != null)
            ClassObj.DisObj.style.width = ClassObj.BrowseWidth + "px";
        if (ClassObj.BrowseHeight != null)
            ClassObj.DisObj.style.height = ClassObj.BrowseHeight + "px";

        ClassObj.makeRequest(this.AbsPath + 'jsGetBrowse.aspx?BaseID=' + this.BaseID + '&ShowMode=' + this.ShowMode + '&MasterCode=' + this.MasterCode + '&Keyword=' + escape(ClassObj.Keyword) + '&FilterClm=' + ClassObj.FilterColumns + '&Condition=' + ClassObj.ConditionCode + '&RowsPerPage=' + ClassObj.RowsPerPage + '&NewsFlowCode=' + this.NewsFlowCode + '&IGroupCode=' + this.IGroupCode, new Function("ClassObj.UpdateVal()"), 'GET', null, 1)


    }


    GetPersianNumber = function (str) {
        str = str + ''
        var Result = "";
        for (num = 0; num < str.length; num++) {
            Result = Result + String.fromCharCode(str.charCodeAt(num) + 1728);
        }
        return Result;
    }

}


var BrowseObj1 = new XMLBrowse()
var BrowseObj2 = new XMLBrowse()
var BrowseObj3 = new XMLBrowse()
var BrowseObj4 = new XMLBrowse()
var BrowseObj5 = new XMLBrowse()
var BrowseObj6 = new XMLBrowse()
var BrowseObj7 = new XMLBrowse()
var BrowseObj8 = new XMLBrowse()
var BrowseObj9 = new XMLBrowse()
var BrowseObj10 = new XMLBrowse()
var BrowseObj11 = new XMLBrowse()
var BrowseObj12 = new XMLBrowse()
var BrowseObj13 = new XMLBrowse()
var BrowseObj14 = new XMLBrowse()
var BrowseObj15 = new XMLBrowse()
var BrowseObj16 = new XMLBrowse()
var BrowseObj17 = new XMLBrowse()
var BrowseObj18 = new XMLBrowse()
var BrowseObj19 = new XMLBrowse()
var BrowseObj20 = new XMLBrowse()
var BrowseObjKeywords = new XMLBrowse()






if (document.addEventListener)
    document.addEventListener("onkeydown", BrowseObj1.HandleBrowseKeypress, false)
else if (document.attachEvent)
    document.attachEvent("onkeydown", BrowseObj1.HandleBrowseKeypress)
else if (document.getElementById)
    document.onkeydown = BrowseObj1.HandleBrowseKeypress