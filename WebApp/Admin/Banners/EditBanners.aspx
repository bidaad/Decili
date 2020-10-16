<%@ Page Language="C#" StylesheetTheme="Edit" ValidateRequest="false" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="True" Inherits="Banners_EditBanners" Title="Banners" CodeBehind="EditBanners.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
    <div>
        <AKP:MsgBox runat="server" ID="msgBox" />
    </div>
    <div>
        <table class="cTblOneRow">
            <tr>
                <td class="cFieldLeft">
                    <table class="cTblField2">
                        <tr>
                            <td class="cLabel">
                                <asp:Label ID="lblBanFile" runat="server" Text="فایل:"></asp:Label>
                            </td>
                            <td class="cCtrl">
                                <AKP:ExRadUpload jas="1" ID="uplBanFile" TargetFolder="~/Files/Banners/" runat="server"
                                    Skin="Vista" MaxFileSize="20971520" ControlObjectsVisibility="None" />
                                <br />
                                <asp:HyperLink ID="hplBanFile" runat="server"></asp:HyperLink>
                                <AKP:ExCheckBox ID="chkDeleteBanFile" runat="server" Text="حذف فایل" />
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
        <table class="cTblOneRow">
            <tr>
                <td class="cFieldLeft">
                    <table class="cTblField">
                        <tr>
                            <td class="cCtrl">
                                http://<AKP:ExTextBox ID="txtTargetUrl" SkinID="English" jas="1" MaxLength="200"
                                    runat="server" />
                            </td>
                            <td class="cLabel">
                                <asp:Label ID="lblTargetUrl" runat="server" Text="آدرس :"></asp:Label>
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
        <table class="cTblOneRow">
            <tr>
                <td class="cFieldLeft">
                    <table class="cTblField">
                        <tr>
                            <td class="cCtrl">
                                <AKP:ExTextBox ID="txtKeywords" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                    MaxLength="1000" runat="server" />
                            </td>
                            <td class="cLabel">
                                <asp:Label ID="lblKeywords" runat="server" Text="کلمات کلیدی:"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="cFieldRight">
                    <table class="cTblField">
                        <tr>
                            <td class="cCtrl">
                                <AKP:ExTextBox ID="txtText" jas="1" CssClass="cMultiLine" TextMode="MultiLine" MaxLength="1000"
                                    runat="server" />
                            </td>
                            <td class="cLabel">
                                <asp:Label ID="lblText" runat="server" Text="متن:"></asp:Label>
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
                                <AKP:Lookup ID="lkpPositionCode" jas="1" BaseID="BannerPositions" runat="server" />
                            </td>
                            <td class="cLabel">
                                <asp:Label ID="lblPositionCode" runat="server" Text="مکان نمایش:"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="cFieldRight">
                    <table class="cTblField">
                        <tr>
                            <td class="cCtrl">
                                <AKP:Combo ID="cboHCTypeCode" jas="1" AllowNull="false" BaseID="HCBannerTypes" runat="server" />
                            </td>
                            <td class="cLabel">
                                <asp:Label ID="lblHCTypeCode" runat="server" Text="نوع:"></asp:Label>
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
                                <AKP:NumericTextBox ID="txtViewNum" jas="1" NumericType="IntType" runat="server" />
                            </td>
                            <td class="cLabel">
                                <asp:Label ID="lblViewNum" runat="server" Text="تعداد نمایش:"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="cFieldRight">
                    <table class="cTblField">
                        <tr>
                            <td class="cCtrl">
                                <AKP:NumericTextBox ID="txtClickNum" jas="1" NumericType="IntType" runat="server" />
                            </td>
                            <td class="cLabel">
                                <asp:Label ID="lblClickNum" runat="server" Text="تعداد کلیک:"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    <div class="cHorSep">
    </div>
    <div class="clear">
    </div>
    <table class="cEditTabs" width="100%">
        <tr>
            <td>
                <div>
                </div>
            </td>
        </tr>
    </table>
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
    <div class="clear">
    </div>
</asp:Content>
