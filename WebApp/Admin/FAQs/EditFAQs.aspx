<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="FAQs_EditFAQs" Title="FAQs" Codebehind="EditFAQs.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">


    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox"/>
        </div>
    <div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtQuestion" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                        MaxLength="500" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblQuestion" runat="server" Text="سوال:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtAnswer" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                        runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblAnswer" runat="server" Text="پاسخ:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:NumericTextBox ID="txtShowOrder" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblShowOrder" runat="server" Text="ترتیب نمابش:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="text-align: right">
        <table class="tblEditButtons" cellpadding="2" cellspacing="4">
            <tr>
                <td>
                    <asp:ImageButton ID="imgBtnBack" Text=" بازگشت " SkinID="BackButton" OnClick="GoToList"
                        runat="server" />
                </td>
                <td>
                    <asp:ImageButton ID="imgBtnSave" Text=" ذخیره " SkinID="SaveButton" OnClick="DoSave"
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
