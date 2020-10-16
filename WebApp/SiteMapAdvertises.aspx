<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteMapAdvertises.aspx.cs" Inherits="Deciliv91._1.SiteMapProducts" %><?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
        xmlns:image="http://www.google.com/schemas/sitemap-image/1.1"
        xmlns:video="http://www.google.com/schemas/sitemap-video/1.1">
<asp:Repeater runat="server" ID="rptAdvertises" EnableViewState="False">
<ItemTemplate>
    <url>
        <loc><%#"https://www.Decili.ir/Ads/" + Eval("ID") + ".html"%></loc>
        <image:image>
            <image:loc><%#"https://cdn.Decili.ir/Files/Ads/" + Eval("LargePicFile") %></image:loc> 
        </image:image>
    </url>
</ItemTemplate>
</asp:Repeater>
</urlset>