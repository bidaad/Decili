<%@ Page Language="C#" AutoEventWireup="true" Title="اخبار" CodeBehind="Default.aspx.cs"
    MasterPageFile="~/MainRoot.Master" Inherits="Decili.NewsFolder.Default" %>

<%@ Register Src="~/UserControls/PagerToolbar.ascx" TagName="PagerToolbar" TagPrefix="Tlb" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div >
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="اخبار"></asp:Label>
                </li>
            </ul>
        </div>
        <div class="clearfix"></div>
        <div >
            <div class="NewsListFull Marginer20">
                <asp:Repeater ID="rptNews" EnableViewState="false" runat="server">
                    <ItemTemplate>
                        <div class="NewsItem">
                            <asp:HyperLink  NavigateUrl='<%#"~/News/ShowNews.aspx?Code=" + Eval("Code") %>'
                                runat="server"><%#Eval("NewsTitle") %></asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="Clear">
        </div>
        <div class="Clear">
        </div>
    </div>
    <div class="Clear">
    </div>
    <div>
        <Tlb:PagerToolbar runat="server" ID="pgrToolbar" />
    </div>
</asp:Content>
