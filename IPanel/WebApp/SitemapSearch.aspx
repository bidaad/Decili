<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SitemapSearch.aspx.cs" Inherits="Decili.SitemapSearch" %>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
        xmlns:image="http://www.google.com/schemas/sitemap-image/1.1"
        xmlns:video="http://www.google.com/schemas/sitemap-video/1.1">
<asp:Repeater runat="server" ID="rptAdvertises" EnableViewState="False">
<ItemTemplate>
    <url>
        <loc><%#"https://www.Decili.ir/?Keyword=" + Eval("Keyword") %></loc>
    </url>
</ItemTemplate>
</asp:Repeater>
</urlset>
