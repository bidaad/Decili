<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainMenu.ascx.cs"
    Inherits="Decili.UserControls.MainMenu" %>

<%@ Register Src="~/UserControls/AdsCatSubMenu.ascx" TagName="AdsCatSubMenu" TagPrefix="UC" %>

<div class="VerMenu">
    <asp:panel runat="server" ID="pnlCatHir" CssClass="text-left LTR CatHir">
        <ul class="CatHirrarchy">
        <%=strCatHirarchy %>
            </ul>
    </asp:panel>
    <div class="clear"></div>
    <div class="MenuContent">
        <asp:Repeater ID="rptRootCats" runat="server">
            <ItemTemplate><div class="SubMenuCont"><div class="VMenuItem" id="mnuComputer"><asp:HyperLink NavigateUrl='<%#"~/Cats_" + Eval("Title") + "-" + Eval("Code") + CityCode + ".html" %>' runat="server"><%#ShowTitle(Eval("Title")) %><span class="arr"></span></asp:HyperLink></div></div></ItemTemplate>        </asp:Repeater>

    </div>
    <div class="SubMenu1">
        <div class="row">
            <UC:AdsCatSubMenu ID="AdsCatSubMenu1" runat="server" />
        </div>
        <div class="clear"></div>
    </div>

</div>

