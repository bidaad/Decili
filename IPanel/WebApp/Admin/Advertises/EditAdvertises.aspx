<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="True" Inherits="Advertises_EditAdvertises"
    Title="Advertises" CodeBehind="EditAdvertises.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
    <div style="text-align: center">
        <div>
            <table class="cTblEdit" bordercolor="#697077" border="1" align="center" cellpadding="0"
                cellspacing="0">
                <tr>
                    <th>
                        <div class="title">
                            <div>
                                <asp:Label runat="server" ID="lblSysName" Text="" />
                            </div>
                        </div>
                    </th>
                </tr>
                <tr>
                    <td class="cTDEdit">
                        <table cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td class="cEditRight">
                                    <div>
                                        <div>
                                            <AKP:MsgBox ID="msgBox" runat="server" CssClass="cError" />
                                        </div>
                                        <div>
                                            <table class="cTblOneRow">
                                                <tr>
                                                    <td class="cFieldLeft">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:ExTextBox ID="txtTitle" jas="1" Width="560" MaxLength="200" runat="server" />
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
                                                                    <AKP:ExTextBox ID="txtDescription" jas="1" Width="573" Height="300" CssClass="cMultiLine" TextMode="MultiLine"
                                                                        runat="server" />
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
                                                                    <AKP:ExTextBox ID="txtTel" jas="1" MaxLength="200" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblTel" runat="server" Text="تلفن:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="cFieldRight">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:ExTextBox ID="txtID" jas="1" MaxLength="200" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblID" runat="server" Text="شناسه:"></asp:Label>
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
                                                                    <AKP:Combo ID="cboHCDurationCode" AllowNull="false" jas="1" BaseID="HCAdvertiseDurations"
                                                                        runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblHCDurationCode" runat="server" Text="مدت اعتبار:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="cFieldRight">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:ExTextBox ID="txtPrice" jas="1" MaxLength="200" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblPrice" runat="server" Text="قیمت:"></asp:Label>
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
                                                                    <AKP:ExTextBox ID="txtName" jas="1" MaxLength="200" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblName" runat="server" Text="نام:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:Lookup ID="lkpCityCode" jas="1" BaseID="Cities" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblCityCode" runat="server" Text="شهر:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="cFieldRight">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:ExTextBox ID="txtAddress" jas="1" CssClass="cMultiLine" TextMode="MultiLine"
                                                                        MaxLength="200" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblAddress" runat="server" Text="آدرس:"></asp:Label>
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
                                                                    <AKP:ExTextBox ID="txtFishNo" jas="1" MaxLength="200" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblFishNo" runat="server" Text="شماره فیش:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="cFieldRight">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:NumericTextBox ID="txtAmount" jas="1" NumericType="IntType" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblAmount" runat="server" Text="مبلغ پرداختی:"></asp:Label>
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
                                                                    <asp:CheckBox ID="chkShowContactAdvetiserWin" jas="1" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblShowContactAdvetiserWin" runat="server" Text="پنجره تماس "></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="cFieldRight">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:NumericTextBox ID="txtRate" jas="1" NumericType="IntType" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblRate" runat="server" Text="اولویت:"></asp:Label>
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
                                                                    <AKP:ExTextBox ID="txtLink" jas="1" MaxLength="200" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblLink" runat="server" Text="آدرس سایت:"></asp:Label>
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
                                                                    <AKP:FarsiDate ID="dteCreateDate" jas="1" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblCreateDate" runat="server" Text="تاریخ ایجاد:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="cFieldRight">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:Combo ID="cboHCAdvertiseStatusCode" AllowNull="false" jas="1" BaseID="HCAdvertiseStatuses"
                                                                        runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblHCAdvertiseStatusCode" runat="server" Text="وضعیت:"></asp:Label>
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
                                                                    <AKP:FarsiDate ID="dteExpDate" jas="1" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblExpDate" runat="server" Text="تاریخ انقضا:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="cFieldRight"></td>
                                                </tr>
                                            </table>
                                        </div>
                                        
                                        <div class="clearfloat"></div>
                                        <div>
                                            <asp:Image ID="imgAdsPic" runat="server" />

                                        </div>
                                        
                                        <div class="clearfloat"></div>
                                        <div>
                                            <table class="cTblOneRow">
                                                <tr>
                                                    <td class="cFieldLeft"></td>
                                                    <td class="cFieldRight">
                                                        <table class="cTblField">
                                                            <tr>
                                                                <td class="cCtrl">
                                                                    <AKP:Lookup ID="lkpUserCode" jas="1"  BaseID="Users" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblUserCode" runat="server" Text="کاربر:"></asp:Label>
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
                                                                    <AKP:NumericTextBox ID="txtViewCount" jas="1" NumericType="IntType" runat="server" />
                                                                </td>
                                                                <td class="cLabel">
                                                                    <asp:Label ID="lblViewCount" runat="server" Text="تعداد نمایش:"></asp:Label>
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
                                    <div class="cHorSep">
                                    </div>
                                    <div style="text-align: left">
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
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
