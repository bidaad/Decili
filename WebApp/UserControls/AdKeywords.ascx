<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_AdKeywords" CodeBehind="AdKeywords.ascx.cs" %>
<asp:Panel ID="pnlKeywords" CssClass="panel success" runat="server">
    <div class="heading">
        <asp:Literal ID="ltrHeader" Text="کلمات کلیدی آگهی" runat="server"></asp:Literal>
    </div>
    <div class="Clear">
    </div>
    <div class="content">
        <asp:Repeater EnableViewState="false" ID="rptKeywordList" runat="server">
            <HeaderTemplate>
                <div class="KeywordList">
            </HeaderTemplate>
            <ItemTemplate>
                <div><asp:HyperLink runat="server" Text='<%#Eval("Keyword") %>' NavigateUrl='<%#"~/s1-" + Eval("Keyword").ToString().Replace(" ", "%20") + ".html" %>'><%#Eval("Keyword") %></asp:HyperLink>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Panel>
