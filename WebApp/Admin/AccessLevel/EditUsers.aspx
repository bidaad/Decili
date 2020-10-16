<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="Users_EditUsers"
    Title="Users" CodeBehind="EditUsers.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">

    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label>
    </div>
    <div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox" />
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtID" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblID" runat="server" Text="شناسه:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExCheckBox ID="chkAutoLogin" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblAutoLogin" runat="server" Text="ورود خودکار:"></asp:Label>
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
                                    <AKP:ExTextBox ID="txtFirstName" jas="1" MaxLength="100" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblFirstName" runat="server" Text="نام:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtLastName" jas="1" MaxLength="100" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblLastName" runat="server" Text="نام خانوادگی:"></asp:Label>
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
                                    <AKP:ExTextBox ID="txtEmail" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblEmail" runat="server" Text="ایمیل:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtPassword" SkinID="English" TextMode="Password" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblPassword" runat="server" Text="کلمه عبور:"></asp:Label>
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
                                    <AKP:Combo ID="cboHCGenderCode" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCGenderCode" runat="server" Text="جنسیت:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox DisplayMode="ViewMode" ID="dteRegDate" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblCreateDate" runat="server" Text="تاریخ عضویت:"></asp:Label>
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
                                    <AKP:ExCheckBox ID="chkActive" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblActive" runat="server" Text="فعال:"></asp:Label>
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
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:Repeater runat="server" OnItemCommand="HandleRepeaterCommand" EnableViewState="true" ID="rptAdvertises">
            <HeaderTemplate>
                <table class="tblMyAds table table-striped">
                    <tr>
                        <th>نمایش
                        </th>

                        <th>وضعیت
                        </th>
                        <th>عنوان
                        </th>
                        <th>کاربر
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Button Text="نمایش" ToolTip="نمایش" CssClass="btn btn-default" ID="btnShowAds" Code='<%#Eval("Code") %>' CommandName="ShowAds" runat="server"></asp:Button>
                    </td>
                    <td>
                        <%#Eval("Status") %>
                    </td>

                    <td>
                        <div class="SingleAdver text-center RTL">
                            <a href="../Advertises/EditAdvertises.aspx?Code=<%#DataBinder.Eval(Container.DataItem, "Code")%>">
                                <%#DataBinder.Eval(Container.DataItem, "Title")%></a>
                        </div>
                    </td>
                    <td>
                        <%#Eval("FirstName") %>&nbsp;<%#Eval("LastName") %>
                    </td>
                </tr>
                <asp:Panel ID="pnlAdsInfo" CssClass="Marginer10" Visible="false" runat="server">
                    <tr>
                        <td colspan="4">
                            <div class="form-group">
                                <AKP:ExTextBox ID="txtTitle" CssClass="form-control EditAdTitle" placeholder="عنوان آگهی" MaxLength="200" runat="server"></AKP:ExTextBox>
                            </div>
                            <div class="form-inline">
                                <div class="form-group">
                                    <AKP:ExTextBox ID="txtDescription" CssClass="form-control AdText" placeholder="شرح آگهی" Height="150" TextMode="MultiLine" runat="server"></AKP:ExTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 ">
                                    <div class="form-group">
                                        <AKP:ExTextBox ID="txtTel" MaxLength="200" placeholder="تلفن" CssClass="form-control" runat="server"></AKP:ExTextBox>
                                    </div>

                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <div class="form-group">
                                        <AKP:ExTextBox ID="txtName" MaxLength="200" placeholder="نام" CssClass="form-control" runat="server"></AKP:ExTextBox>
                                    </div>

                                </div>
                            </div>
                            <div class="form-inline">
                                <div class="form-group">
                                    <AKP:ExTextBox ID="txtAddress" placeholder="آدرس" CssClass="form-control AdAddress" runat="server"></AKP:ExTextBox>
                                </div>

                            </div>
                            <div class="form-group">
                                <AKP:ExTextBox ID="txtPrice" MaxLength="200" placeholder="قیمت" CssClass="form-control" runat="server"></AKP:ExTextBox>
                            </div>
                            <div class="form-group">
                                <asp:HyperLink ID="hplLink" Target="_blank" runat="server"></asp:HyperLink>
                            </div>
                            <div>
                                <asp:Image ID="imgAdsPic" runat="server" />
                            </div>
                            <div class="Marginer10">
                                <asp:Button Text="تایید" ID="btnApprove" CommandName="Approve" CssClass="btn btn-success btn-block" runat="server"></asp:Button>
                            </div>
                        </td>
                    </tr>

                </asp:Panel>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>

    <div class="TabHeaderData">
        <telerik:RadTabStrip Style="margin-right: 8px;" dir="rtl" ID="tsUsers" runat="server"
            MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Vista" SkinsPath="~/RadControls/TabStrip/Skins">
            <Tabs>
                <telerik:RadTab ID="Tab1" runat="server" Text="گروه های کاربر">
                </telerik:RadTab>

                <telerik:RadTab ID="Tab2" runat="server" Text="تراکنش های کاربر">
                </telerik:RadTab>

            </Tabs>
        </telerik:RadTabStrip>
        <div class="cTabWrapper">
            <telerik:RadMultiPage ID="RadMultiPage1" SelectedIndex="0" runat="server">
                <telerik:RadPageView ID="PageView1" runat="server">
                    <div class="cDivSep">
                    </div>
                    <div class="cBrowseArea" id="UserGroups">
                    </div>
                    <div class="cDivSep">
                    </div>
                </telerik:RadPageView>

                <telerik:RadPageView ID="PageView2" runat="server">
                    <div class="cDivSep">
                    </div>
                    <div class="cBrowseArea" id="UserTransactions">
                    </div>
                    <div class="cDivSep">
                    </div>
                </telerik:RadPageView>

            </telerik:RadMultiPage>
        </div>
    </div>
    <div style="text-align: right">
        <table class="tblEditButtons" cellpadding="2" cellspacing="4">
            <tr>
                <td>
                    <asp:Button ID="btnLogAsUser" CssClass="btn btn-info" runat="server" Text="ورود به پنل کاربر" OnClick="btnLogAsUser_Click" />

                </td>
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
    <asp:HiddenField ID="hfPassword" runat="server" />
</asp:Content>
