<%@ Page Language="C#" MasterPageFile="~/Admin/Main.master" AutoEventWireup="true"
    Inherits="HardCode_HardCodes" Title="تنظیمات" Codebehind="HardCodes.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script language="javascript" type="text/javascript">
function ShowList( Obj)
{
    BaseID = Obj.baseid
    BrowseObj1.ViewEdit = 'Edit'
    BrowseObj1.CreateBrowse(BaseID)
}
    </script>

    <div style="width: 96%; background-color: white">
        <br />
        <table border="0" cellpadding="0" cellspacing="0" width="60%">
            <tr>
                <td class="cWin6LeftTop">
                </td>
                <td class="cWin6MiddleTop">
                </td>
                <td class="cWin6RightTop">
                </td>
            </tr>
            <tr>
                <td class="cWin6LeftMiddle">
                    <img alt="" src="../images/spacer.gif" />
                </td>
                <td>
                    <asp:DataList ID="dlHardCodes" CssClass="ctblHardCodes" RepeatColumns="3" runat="server">
                        <ItemStyle Width="33%" HorizontalAlign="Right" Height="21" />
                        <ItemTemplate>
                            <nobr>
                    <a href="#" onclick="ShowList(this)" baseid="<%#DataBinder.Eval(Container.DataItem, "EngName") %>">
                        <%#DataBinder.Eval(Container.DataItem, "Name") %></a></nobr>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td class="cWin6RightMiddle">
                </td>
            </tr>
            <tr>
                <td class="cWin6LeftBot">
                </td>
                <td class="cWin6MiddleBot">
                </td>
                <td class="cWin6RightBot">
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
