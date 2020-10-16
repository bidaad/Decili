<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SitemapCats.aspx.cs" Inherits="Decili.SitemapCats" %>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
        xmlns:image="http://www.google.com/schemas/sitemap-image/1.1"
        xmlns:video="http://www.google.com/schemas/sitemap-video/1.1">
<asp:Repeater runat="server" ID="rptCats" EnableViewState="False">
<ItemTemplate>
    <url>
        <loc><%#"https://www.Decili.ir/Cats_" + Eval("Title") + "-" + Eval("Code") +  ".html" %></loc>
    </url>
</ItemTemplate>
</asp:Repeater>
</urlset>