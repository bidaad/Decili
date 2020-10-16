<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_SuggestToFriend"
    CodeBehind="SuggestToFriend.ascx.cs" %>
<div>
    <div class="WinBlue1">
        <div class="WinBlue1Header">
            <div style="padding-right: 10px; padding-top: 3px;">
                <asp:Label ID="Label5" runat="server" Text="معرفی به دوستان"></asp:Label></div>
        </div>
        <div style="padding: 7px; direction: rtl;">
            <table style="direction: ltr;" >
                <tr>
                    <td style="text-align: right;">
                        <asp:TextBox ID="txtYourName" Width="100" runat="server"></asp:TextBox>
                    </td>
                    <td style="direction: rtl; text-align: left;">
                        <asp:Label ID="Label2" runat="server" Text="نام شما:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <asp:TextBox ID="txtFromEmail" SkinID="English" runat="server"></asp:TextBox>
                    </td>
                    <td style="direction: rtl; text-align: left;">
                        <asp:Label ID="Label1" runat="server" Text="ایمیل شما:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtToEmail" SkinID="English" runat="server"></asp:TextBox>
                        
                    </td>
                    <td style="direction: rtl;">
                         <asp:Label ID="Label6" runat="server" Text="ایمیل دوست شما:"></asp:Label>
                        
                    </td>
                    
                </tr>
                <tr>
                <td colspan="2" >
                       <asp:Button ID="btnSend" runat="server" Text="ارسال" OnClick="btnSend_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox">
            </AKA:MsgBox>
        </div>
    </div>
</div>
