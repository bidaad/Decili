<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSearchWords.ascx.cs" Inherits="Decili.UserControls.UCSearchWords" %>
<asp:Panel ID="pnlKeywords" CssClass="panel success" runat="server">
    <div class="heading">
        <asp:Literal ID="ltrHeader" runat="server"></asp:Literal>
    </div>
    <div class="Clear">
    </div>
    <div class="content">
        <asp:Repeater EnableViewState="false" ID="rptKeywordList" runat="server">
            <HeaderTemplate>
                <div class="KeywordList">
            </HeaderTemplate>
            <ItemTemplate>
                <div>
                    <asp:HyperLink runat="server" Text='<%#Eval("Keyword") %>' NavigateUrl='<%#"~/Key/" + Eval("KeywordCode") + ".html" %>'>
                                        <%#Eval("Keyword") %>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Panel>
