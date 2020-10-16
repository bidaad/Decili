<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="Articles_EditArticles"
    Title="Articles" Codebehind="EditArticles.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">

    <script language="javascript" type="text/javascript">
        var SelTab = <%=SelectedTabIndex%>;
        function ClientTabSelectedHandler(sender, eventArgs)
        {
          var tabStrip = sender;
          SelTab = tabStrip.SelectedIndex
        }
        function GoToPage()
        {
            window.location.href = 'EditArticles.aspx?SelectedTab=' + SelTab + '&Code=<%=Code%>'
        }
    </script>

    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
    <div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox"></AKA:MsgBox>
        </div>
        <div>
            <table class="cTblField">
                <tr>
                    <td class="cCtrl">
                        <AKP:ExTextBox ID="txtTitle" jas="1" Width="300" MaxLength="200" runat="server" />
                    </td>
                    <td class="cLabel">
                        <asp:Label ID="lblTitle" runat="server" Text="عنوان:"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblField">
                <tr>
                    <td class="cCtrl">
                        <AKP:ExRadEditor ID="txtArticleContent" Width="700" Height="800" jas="1" 
                            TextMode="MultiLine" runat="server" />
                    </td>
                    <td class="cLabel">
                        <asp:Label ID="lblArticleContent" runat="server" Text="متن:"></asp:Label>
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
                                    <AKP:FarsiDate ID="dteArticleDate" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblArticleDate" runat="server" Text="تاریخ:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboHCArticleCatCode" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCArticleCatCode" runat="server" Text="گروه:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="text-align: right">
        <table cellpadding="2" cellspacing="4">
            <tr>
                <td>
                    <a class="button2" onclick="ChangeLang()">فارسی </a>
                </td>
                <td class="cVerBar1">
                </td>
                <td>
                    <asp:LinkButton ID="imgBtnBack" Text=" بازگشت " SkinID="BackButton" OnClick="GoToList"
                        runat="server" />
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
