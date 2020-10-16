<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_Toolbar" Codebehind="Toolbar.ascx.cs" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:ImageButton CssClass="EmailLink" ImageUrl="~/images/Email.gif" ID="btnEmail"
                runat="server" OnClick="btnEmail_Click"></asp:ImageButton>
            <asp:Panel runat="server" ID="pnlMessage" Visible="false" class="ToolbarMessage">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </asp:Panel>
        </div>
        <asp:Panel ID="pnlSendEmail" CssClass="ToolbarContainer" Visible="false" runat="server">
            <div class="Marginer1">
                <asp:ImageButton runat="server" ID="btnCloseWin" ImageUrl="~/images/spacer.gif" class="Close"
                    OnClick="btnCloseWin_Click"></asp:ImageButton>
                <table cellspacing="2">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblSendPage" runat="server" Text="ارسال صفحه"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Green">
                            <asp:RequiredFieldValidator ValidationGroup="SendPage" ControlToValidate="txtFrom"
                                ID="RFV9" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                runat="server" ErrorMessage="نام خود را وارد کنید" ForeColor="Maroon"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFrom" Width="150" runat="server"></asp:TextBox>
                        </td>
                        <td class="cSendLabel">
                            <asp:Label ID="Label2" runat="server" Text="نام شما"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Green">
                            <asp:RequiredFieldValidator ValidationGroup="SendPage" ControlToValidate="txtFrom"
                                ID="RequiredFieldValidator1" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                runat="server" ErrorMessage="ایمیل خود را وارد کنید" ForeColor="Maroon"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFromEmail" Width="150" SkinID="English" CssClass="Eng" runat="server"></asp:TextBox>
                        </td>
                        <td class="cSendLabel">
                            <asp:Label ID="Label5" runat="server" Text="ایمیل شما"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Green">
                            <asp:RequiredFieldValidator ValidationGroup="SendPage" ControlToValidate="txtFrom"
                                ID="RequiredFieldValidator2" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                runat="server" ErrorMessage="نام دوست خود را وارد کنید" ForeColor="Maroon"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtTo" Width="150" runat="server"></asp:TextBox>
                        </td>
                        <td class="cSendLabel">
                            <asp:Label ID="Label3" runat="server" Text="نام دوست شما"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Green">
                            <asp:RequiredFieldValidator ValidationGroup="SendPage" ControlToValidate="txtFrom"
                                ID="RequiredFieldValidator3" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                runat="server" ErrorMessage="ایمیل دوست خود را وارد کنید" ForeColor="Maroon"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtToEmail" Width="150" SkinID="English" CssClass="Eng" runat="server"></asp:TextBox>
                        </td>
                        <td class="cSendLabel">
                            <asp:Label ID="Label1" runat="server" Text="ایمیل دوست شما"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Green">
                            <asp:TextBox ID="txtMessage" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                        </td>
                        <td class="cSendLabel">
                            <asp:Label ID="Label4" runat="server" Text="متن پیام"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div style="padding: 5px;">
                    <table>
                        <tr>
                            <td style="text-align: left">
                                <asp:LinkButton ID="btnSend" ValidationGroup="SendPage" Text="ارسال" CssClass="button" 
                                    runat="server" OnClick="btnSend_Click" />
                            </td>
                            <td style="text-align: right">
                                <asp:LinkButton ID="btnCancel" Text="انصراف"  CssClass="button"
                                     runat="server" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
