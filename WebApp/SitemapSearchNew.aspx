<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SitemapSearchNew.aspx.cs" Inherits="Decili.SitemapSearchNew" %>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
        xmlns:image="http://www.google.com/schemas/sitemap-image/1.1"
        xmlns:video="http://www.google.com/schemas/sitemap-video/1.1">
<asp:Repeater runat="server" ID="rptAdvertises" EnableViewState="False">
<ItemTemplate>
    <url>
        <loc><%#"https://www.Decili.ir/s1-" + Eval("Keyword").ToString().Replace(" ", "%20").Replace("&", "")  + ".html" %></loc>
    </url>
</ItemTemplate>
</asp:Repeater>
</urlset>
