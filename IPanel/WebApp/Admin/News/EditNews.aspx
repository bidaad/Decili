<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="News_EditNews" Title="News" Codebehind="EditNews.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">


    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
    <div class="Padder1">
        <div>
            <AKP:MsgBox runat="server" ID="msgBox" />
           
        </div>
        <div>
            <table class="cTblField">
                <tr>
                    <td class="cCtrl">
                        <AKP:ExTextBox ID="txtNewsTitle" jas="1" Width="600" MaxLength="1000" runat="server" />
                    </td>
                    <td class="cLabel">
                        <asp:Label ID="lblNewsTitle" runat="server" Text="عنوان:"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblField">
                <tr>
                    <td class="cCtrl">
                        <AKP:ExTextBox ID="txtDescription" jas="1" Width="600" Height="100" CssClass="cMultiLine" TextMode="MultiLine"
                            runat="server" />
                    </td>
                    <td class="cLabel">
                        <asp:Label ID="lblDescription" runat="server" Text="توضیحات:"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align:center;">
            <fieldset style="direction: rtl;width:630px;">
                <legend>&nbsp;<asp:Label runat="server" Text="فایل" ID="lblPicFile" />&nbsp;</legend>
                <table class="cTblOneRow">
                    <tr>
                        <td class="cFieldLeft">
                            <div class="cPic">
                                <AKP:ExRadUpload ID="uplPicFile" jas="1" runat="server" AllowedFileExtensions=".gif,.jpg,.jpeg,.png,.bmp"
                                    TargetFolder="~/Files/News/" Skin="Vista" MaxFileSize="200000" ControlObjectsVisibility="None" />
                                <br />
                                <asp:CheckBox ID="chkDeletePicFile" runat="server" Text="حذف فایل" />
                            </div>
                        </td>
                        <td class="cFieldRight">
                            <asp:HyperLink rel="lightbox" EnableViewState="false" Target="_blank" runat="server"
                                ID="hplPicFile" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboHCNewsCatCode" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="Label1" runat="server" Text="گروه:"></asp:Label>
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
                                    <AKP:FarsiDate ID="dteNewsDate" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblNewsDate" runat="server" Text="تاریخ:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtResource" jas="1" 
                                        MaxLength="500" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblResource" runat="server" Text="منبع:"></asp:Label>
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
                                    <AKP:ExTextBox ID="txtShortDesc" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                        MaxLength="4000" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblShortDesc" runat="server" Text="توضیحات کوتاه:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtPicDesc" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                        MaxLength="1000" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblPicDesc" runat="server" Text="توضیحات عکس:"></asp:Label>
                                </td>
                            </tr>
                        </table>
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
