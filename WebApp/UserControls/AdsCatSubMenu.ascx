<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdsCatSubMenu.ascx.cs" Inherits="Decili.UserControls.AdsCatSubMenu" %>
<asp:Repeater ID="rptMenuItems" runat="server">
    <HeaderTemplate>
        <ul class="navSubMenu">
    </HeaderTemplate>
    <ItemTemplate>
        <li><asp:HyperLink NavigateUrl=<%# "~/AdsByCatCode.aspx?C=" + Eval("Code") %> runat="server"><%#Eval("Title") %></asp:HyperLink></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
