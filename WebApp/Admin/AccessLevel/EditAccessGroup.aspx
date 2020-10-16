<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master" AutoEventWireup="true" Inherits="AccessGroups_EditAccessGroups"
    Title="AccessGroups" Codebehind="~/Admin/AccessLevel/EditAccessGroup.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
<script language="javascript" type="text/javascript">
document.write("<div class=\"cHiddenDate\" id=\"AccessPanel\"></div>");
var AccessTable;
var AccessObj = document.getElementById("AccessPanel");
var ClickedX; 
var ClickedY;

function CreateAccessTable(CellText, AccCode, AccType)
{
    AccType = parseInt(AccType, 10)
    HasAccess = ((AccType & AccCode) == AccCode)

    if (HasAccess) {
        //chkObj = document.createElement("<input type=checkbox checked >");
        chkObj = document.createElement("INPUT");
        chkObj.setAttribute('type', 'checkbox');
        chkObj.setAttribute('checked', 'true');
    }
    else {
        //chkObj = document.createElement("<input type=checkbox >");
        chkObj = document.createElement("INPUT");
        chkObj.setAttribute('type', 'checkbox');
    }
    chkObj.setAttribute("AccessCode", AccCode);
    spanObj = document.createElement("SPAN");
    spanObj.innerHTML = CellText

    newRow = AccessTable.insertRow()
    newCell2 = newRow.insertCell()
    newCell2.appendChild(spanObj);
    newCell1 = newRow.insertCell()
    newCell1.appendChild(chkObj);

}

function UpdateResources()
{
    if(http_request != null)
    {
       if (http_request.readyState == 4) { 
           if (http_request.status == 200) { 
	            result = http_request.responseText
	            if(result == "Success")
	            {
	                document.getElementById('Message').innerHTML = 'عملیات با موفقیت انجام شد'
    			    getObj('AccessPanel').style.display='none';
	            }
	            else
	                alert(result);
	            document.body.style.cursor='auto';
            }
       }
   }

}

function AccessTypeIsReady()
{
    if(http_request != null)
    {
       if (http_request.readyState == 4) { 
           if (http_request.status == 200) { 
	            result = http_request.responseText
	            resultArray = result.split(';')
	            NodeCode = resultArray[0];
	            AccessType = resultArray[1];
	            if(result != "")
	            {
	                ShowEditForm(NodeCode, AccessType);
	            }
	            else
	                alert(result);
	            document.body.style.cursor='auto';
            }
       }
   }

}

function ReqSave(NodeCode)
{
    SumAccess = 0
    if(AccessTable.rows[0].cells[1].childNodes[0].checked)
        ApplyToChildNodes = 1;
    else
        ApplyToChildNodes = 0
    for (acRow = 0; acRow < AccessTable.rows.length - 1; acRow++) {
        //alert(parseInt(AccessTable.rows[acRow].cells[1].childNodes[0].getAttribute('AccessCode'), 10));
        if(AccessTable.rows[acRow].cells[1].childNodes[0].checked)
            SumAccess = SumAccess + parseInt(AccessTable.rows[acRow].cells[1].childNodes[0].getAttribute('AccessCode'),10);
    }
    SaveUrl = 'ajxGroupResources.aspx?GroupCode=<%=Code%>&ResourceCode=' + NodeCode + '&AccessType=' + SumAccess + '&ApplyToChildNodes=' + ApplyToChildNodes;
    startRequest(SaveUrl, UpdateResources, 'GET', null, null)
}

function GetAccessType(sender, eventArgs)
{
    if(event != null)
        event.cancelBubble=true;
    ClickedX =  window.event.clientX 
    ClickedY =  window.event.clientY
    var node = eventArgs.get_node();


    NodeCode = node.get_value();
    SaveUrl = 'ajxGroupResources.aspx?GroupCode=<%=Code%>&ResourceCode=' + NodeCode + '&AccessType=';
    //alert(SaveUrl)
    startRequest(SaveUrl, AccessTypeIsReady, 'GET', null, null)
}

function ShowEditForm(NodeCode)
{ 
    if(AccessObj != null)
    {
        if(AccessObj.childNodes.length > 0)
        {
            ChildLen = AccessObj.childNodes.length
            for(rem = 0 ; rem < ChildLen; rem++)
            {
                AccessObj.childNodes[0].removeNode(true);
            }
        }
    }
    AccessTable = document.createElement("TABLE");
    AccessTable.className = 'cFieldListTable'
    CreateAccessTable("همه زیر مجموعه ها", 0, AccessType)
    CreateAccessTable("ایجاد", 1, AccessType)
    CreateAccessTable("ویرایش", 2, AccessType)
    CreateAccessTable("حذف", 4, AccessType)
    CreateAccessTable("نمایش", 8, AccessType)
    CreateAccessTable("چاپ", 16, AccessType)

    //saveObj = document.createElement("<input type=button value='ذخیره' >");
    saveObj = document.createElement("INPUT");
    saveObj.setAttribute('type', 'button');
    saveObj.setAttribute('value', 'ذخیره');

    saveObj.onclick = (
		        function(f) 
		        {
		            if(event != null)
    	                event.cancelBubble=true;
                    return function()
                    {
                        ReqSave(f)
                    }
                }
                )(NodeCode);
    
    newRow = AccessTable.insertRow()
    newCell1 = newRow.insertCell()
    newCell1.align = 'center';
    newCell1.setAttribute('colspan','2');
    newCell1.appendChild(saveObj);
    newCell2 = newRow.insertCell()
    
    AccessObj.appendChild(AccessTable);  
    

    AccessObj.style.left = ClickedX - 132 + document.body.scrollLeft;
    AccessObj.style.top = ClickedY + 2 + document.body.scrollTop + document.documentElement.scrollTop;
    AccessObj.style.display = "block"
    
} 

</script>
    <div style="text-align: center">
        <div style="width: 910;">
            <table class="cTblEdit" bordercolor="#697077" border="1" align="center" cellpadding="0"
                cellspacing="0">
                <tr>
                    <th>
                        <div style="width: 880px;">
                            <div style="width: 180px; float: left;">
                                
                            </div>
                            <div class="cSysName">
                                <asp:HyperLink runat="server" ID="hplSysName"></asp:HyperLink></div>
                        </div>
                    </th>
                </tr>
                <tr>
                    <td class="cTDEdit">
                        <table cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td class="cEditRight" style="width: 100%">
                                    <table class="cEditMain" width="100%">
                                        <tr>
                                            <td style="vertical-align: top;">
                                                <div class="cHeaderEditMain">
                                                    
                                                </div>
                                                <div class="cEditMainData">
                                                    <table align="center" width="100%">
                                                        <tr>
                                                            <td>
                                                                <div id="Message">
                                                                    <AKP:MsgBox ID="msgBox" runat="server"></AKA:MsgBox>
                                                                </div>
                                                                <div>
                                                                    <div>
                                                                        <table class="cTblOneRow">
                                                                            <tr>
                                                                                <td class="cFieldLeft">
                                                                                    <table class="cTblField">
                                                                                        <tr>
                                                                                            <td class="cCtrl">
                                                                                                <AKP:ExTextBox jas="1" ID="txtName" MaxLength="200" runat="server" />
                                                                                            </td>
                                                                                            <td class="cLabel">
                                                                                                <asp:Label ID="lblName" runat="server" Text="نام گروه:"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td class="cFieldRight">
                                                                                    
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div>
                                                                    </div>
                                                                </div>
                                                                <div style="text-align:right">
                                                                    <telerik:RadTreeView id="RadTree1" EnableViewState="false" runat="server" 
                                                                        skin="WebBlue" ImagesBaseDir="~/Images/TreeView/Outlook" OnClientNodeClicking="GetAccessType"
                                                                        showlineimages="true" expanddelay="3" 
                                                                        dir="rtl"  Width="600px"
                                                                        onnodeexpand="RadTree1_NodeExpand">
                                                                        
                                                                    </telerik:RadTreeView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="cHorSep">
                                    </div>
                                    
                                    <div style="text-align: left">
                                        <table cellpadding="2" cellspacing="4">
                                            <tr>
                                                
                                                <td>
                                                    <asp:LinkButton ID="imgBtnBack" SkinID="BackButton" Text=" بازگشت " OnClick="GoToList" runat="server" />
                                                </td>
                                                <td class="cVerBar1">
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="imgBtnSave" SkinID="SaveButton" Text=" ذخیره " OnClick="DoSave" runat="server" />
                                                </td>
                                                
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
