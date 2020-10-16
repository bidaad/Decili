<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_ListItems" Codebehind="ListItems.ascx.cs" %>
<table border="0" dir=ltr cellpadding="2" cellspacing="0">
    <tr>
        <td style="width: 5px">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="cPersianContent" ReadOnly="true"></asp:TextBox></td>
        <td style="width: 5px">
            <asp:TextBox ID="txtCode" runat="server" CssClass="cPersianContent" Width="50px"></asp:TextBox></td>
        <td style="width: 5px">
            <asp:Image ID="imgList" runat="server" ImageUrl="~/images/BulList.gif" CssClass="cHand" />
            </td>
    </tr>
</table>
