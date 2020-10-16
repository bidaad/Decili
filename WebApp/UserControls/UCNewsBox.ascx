<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNewsBox.ascx.cs" Inherits="Decili.UserControls.NewsBox" %>
<div class="Padder5">
    <div class="NewsHeader">
        </div>
    <div class="NewsList">
        <asp:Repeater ID="rptNews" EnableViewState="false" runat="server">
            <ItemTemplate>
                <div class="NewsItem">
                    <asp:HyperLink ID="HyperLink1" Text='<%#Eval("NewsTitle") %>' NavigateUrl='<%#"~/News/ShowNews.aspx?Code=" + Eval("Code") %>'
                        runat="server"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="More">
        <asp:HyperLink ID="hplMore" NavigateUrl="~/News" runat="server"> بیشتر »</asp:HyperLink></div>
</div>
