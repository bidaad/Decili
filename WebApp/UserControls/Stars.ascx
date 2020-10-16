<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_Stars" Codebehind="Stars.ascx.cs" %>
<asp:Repeater runat="server" ID="rptStars">
    <ItemTemplate>
        <asp:Image runat="server" AlternateText="On star" ImageUrl="~/images/star_on.gif" /></ItemTemplate>
</asp:Repeater>
<asp:Repeater runat="server" ID="rptOffstars">
    <ItemTemplate>
        <asp:Image ID="Image1" runat="server" AlternateText="Off star" ImageUrl="~/images/star_off.gif" /></ItemTemplate>
</asp:Repeater>
