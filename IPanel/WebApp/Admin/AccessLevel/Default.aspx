<%@ Page Language="C#" MasterPageFile="~/Admin/Main.master" AutoEventWireup="true" Inherits="UI_AccessLevels_Default" Codebehind="Default.aspx.cs" %>

<%@ Register Src="~/UserControls/CheckAccess.ascx" TagName="CheckAccess" TagPrefix="uc1" %>
<asp:Content runat="server" ID=content1 ContentPlaceHolderID=cphMain>
    <table align="center" border="1" bordercolor="#a3a3a3" class="cNormalTable" width="327">
        <tr>
            <td bgcolor="#f5f5f5">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td background="../images/MBBack2.jpg" style="width: 324px; height: 24px">
                            <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="cPersianContent" nowrap="nowrap" style="height: 24px" width="100%">
                                        <strong>بانکهای اطلاعاتی</strong></td>
                                    <td style="height: 24px" width="22">
                                        <asp:Image runat="server" ID=img1 ImageUrl="~/images/MBBul1.jpg" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" style="width: 324px">
                            <table align="center" cellpadding="0" width="90%">
                                <tr>
                                    <td class="cPersianContent" style="height: 13px">
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Browse.aspx?BaseID=Users">کاربران</asp:HyperLink></td>
                                    <td align="center" style="height: 13px" width="10">
                                        <asp:Image runat="server" ID=img2 ImageUrl="~/images/MBBul2.jpg" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" style="width: 324px"><table align="center" cellpadding="0" width="90%">
                            <tr>
                                <td class="cPersianContent" style="height: 13px">
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Browse.aspx?BaseID=AccessGroups">گروه های دسترسی</asp:HyperLink></td>
                                <td align="center" style="height: 13px" width="10">
                                    <asp:Image runat="server" ID=Image1 ImageUrl="~/images/MBBul2.jpg" /></td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" style="width: 324px"><table align="center" cellpadding="0" width="90%">
                            <tr>
                                <td class="cPersianContent" style="height: 13px">
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MenuTree.aspx">فیلدهای سیستم</asp:HyperLink></td>
                                <td align="center" style="height: 13px" width="10">
                                    <asp:Image runat="server" ID=Image2 ImageUrl="~/images/MBBul2.jpg" /></td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</asp:Content>