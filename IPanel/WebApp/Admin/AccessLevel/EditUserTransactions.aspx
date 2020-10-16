<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/EditPopup.master"
    AutoEventWireup="true" Inherits="UserTransactions_EditUserTransactions"
    Title="UserTransactions" Codebehind="EditUserTransactions.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
    <div>
        <div>
            <AKP:MsgBox ID="msgBox" runat="server" CssClass="cError" />
        </div>
        <div>
            <table class="cTblOneRowPopup">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboChargeTypeCode" BaseID="HCChargeTypes" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblChargeTypeCode" runat="server" Text="نوع شارژ:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:FarsiDate ID="dteChargeDate" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblChargeDate" runat="server" Text="تاریخ تراکنش:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRowPopup">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboHCTransStatusCode" BaseID="HCUserTransStatuses" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCTransStatusCode" runat="server" Text="وضعیت:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtDigitalSignature" jas="1" MaxLength="20" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblDigitalSignature" runat="server" Text="امضای دیجیتال:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRowPopup">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtBankName" jas="1" MaxLength="100" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblBankName" runat="server" Text="بانک:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtBankState" jas="1" MaxLength="100" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblBankState" runat="server" Text="شعبه بانک:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRowPopup">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtComment" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                        MaxLength="1000" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblComment" runat="server" Text="توضیحات:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtFishNo" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblFishNo" runat="server" Text="شماره فیش:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRowPopup">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:FarsiDate ID="dtePayDate" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblPayDate" runat="server" Text="تاریخ پرداخت:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtUserIP" SkinID="English" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblUserIP" runat="server" Text="IP کاربر:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRowPopup">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboBankCode" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblBankCode" runat="server" Text="کد بانک:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtAuthority" jas="1" MaxLength="100" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblAuthority" runat="server" Text="Authority:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRowPopup">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtDescription" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                        runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblDescription" runat="server" Text="توضیحات:"></asp:Label>
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
    <div class="cPopupToolbar">
        <table cellpadding="2" cellspacing="4">
            <tr>
                <td>
                    <a class="button2" onclick="ChangeLang()">فارسی </a>
                </td>
                <td class="cVerBar1">
                </td>
                <td>
                    <asp:LinkButton ID="imgBtnBack" Text=" بستن پنجره " OnClientClick="window.close()"
                        SkinID="BackButton" runat="server" />
                </td>
                <td class="cVerBar1">
                </td>
                <td>
                    <asp:LinkButton ID="imgBtnSave" Text=" ذخیره " SkinID="SaveButton" OnClick="DoSave"
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
