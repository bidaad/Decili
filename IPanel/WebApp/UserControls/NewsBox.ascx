<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsBox.ascx.cs" Inherits="Iran24.UserControls.NewsBox" %>
<div>
    <table class="tblTemplate1">
        <tr>
            <th>
                <asp:Label ID="Label3" runat="server" Text="اخبار"></asp:Label>
            </th>
        </tr>
        <tr>
            <td>
                <div class="NewsList">
                    <asp:Repeater ID="rptNews" EnableViewState="false" runat="server">
                        <ItemTemplate>
                            <div>
                                <asp:HyperLink Text='<%#Tools.ShowBriefText(Eval("NewsTitle"), 30) %>' ToolTip='<%#Eval("NewsTitle") %>' NavigateUrl='<%#"~/News/ShowNews.aspx?Code=" + Eval("Code") %>'
                                    runat="server"></asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="More">
                    <asp:HyperLink ID="hplMore" NavigateUrl="~/News" runat="server"> بیشتر »</asp:HyperLink></div>
            </td>
        </tr>
    </table>
</div>
