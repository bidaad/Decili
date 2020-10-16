<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_SiteLogin2" Codebehind="SiteLogin2.ascx.cs" %>
<div class="cLogin2">
    <table>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Image ID="Image1" ImageUrl="~/images/lblUsers2.gif" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtUsername" SkinID="English" Width="140" runat="server"></asp:TextBox>
            </td>
            <td class="cUsername2">
                <asp:Label ID="Label1" runat="server" Text="نام کاربری"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtPassword" SkinID="English" TextMode="Password" Width="140" runat="server"></asp:TextBox>
            </td>
            <td class="cPassword2">
                <asp:Label ID="Label3" runat="server" Text="کلمه عبور"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="cForgotPass">
                <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/BtnLogin2.jpg" runat="server"
                    OnClick="ImageButton1_Click" />&nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/ForgotPassword.aspx">کلمه عبور را فراموش کرده ام</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label runat="server" ID="lblMessage" CssClass="cPersianContent" ForeColor="white"></asp:Label>
            </td>
        </tr>
    </table>
</div>
