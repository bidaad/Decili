<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSupport.ascx.cs" Inherits="Decili.UserControls.UCSupport" %>
<asp:UpdatePanel runat="server">
    <contenttemplate>
<asp:Panel runat="server" ID="pnlSupport">
    <table class="tblTemplate1">
        <tr>
            <th>
                <asp:Label ID="Label4" runat="server" Text="پشتیبانی"></asp:Label>
            </th>
        </tr>
        <tr>
            <td>
                <div>
                    <table>
                        <tr>
                            <td colspan="2">
                                <AKP:MsgBox runat="server" ID="msgBox"></AKA:MsgBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <AKP:ExTextBox ID="txtEmail" Width="140" SkinID="English" runat="server"></AKA:ExTextBox>
                            </td>
                            <td class="lbl">
                                <asp:Label ID="Label1" runat="server" Text="ایمیل شما:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <AKP:ExTextBox ID="txtTel" CssClass="Eng" SkinID="English" runat="server"></AKA:ExTextBox>
                            </td>
                            <td class="lbl">
                                <asp:Label ID="Label2" runat="server" Text="تلفن شما:"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <AKP:ExTextBox ID="txtComment" Width="140" Height="100" TextMode="MultiLine" MaxLength="240" runat="server"></AKA:ExTextBox>
                            </td>
                            <td class="lbl">
                                <asp:Label ID="Label5" runat="server" Text="متن پیام:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadCaptcha ID="RadCaptcha1" CssClass="Capt" CaptchaImage-Width="150" CaptchaTextBoxCssClass="CaptText" CaptchaImage-ImageCssClass="CaptImg2"
                                     ValidationGroup="ValidateSendSupport" runat="server"
                                    ErrorMessage="" CaptchaTextBoxLabel="">
                                </telerik:RadCaptcha>
                            </td>
                            <td class="lbl">
                                <asp:Label ID="Label6" runat="server" Text="کد امنیتی:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSend" CssClass="input-button" ValidationGroup="ValidateSendSupport" runat="server" 
                                    Text="ارسال" onclick="btnSend_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Panel>
</contenttemplate>
</asp:UpdatePanel>
