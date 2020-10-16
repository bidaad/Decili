<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCatSelector.ascx.cs" Inherits="Decili.UserControls.UCCatSelector" %>

<asp:Panel ID="pnlCatSelect" onclick='$("#CatSelectorTool").slideDown("slow");' ClientIDMode="Static" CssClass="form-control" runat="server">
    <asp:Literal ID="ltrCatName" runat="server"></asp:Literal>
</asp:Panel>
<asp:Panel runat="server" id="CatSelectorTool" ClientIDMode="Static" CssClass="NoDisp" >
    <asp:Panel runat="server" ID="pnlBacktoMasterCat" CssClass="CatSelectorCaption">
        <asp:LinkButton ID="btnMasterCat" runat="server" CssClass="Blue1" OnClick="btnMasterCat_Click"><span class="fa fa-hand-o-right"></span>&nbsp;بازگشت به گروه بالاتر </asp:LinkButton>
        &nbsp;<asp:Label ID="lblCurCat" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlCats" CssClass="CatSelectorCont">
        <asp:Repeater ID="rptCats" OnItemCommand="HandleRepeaterCommand" runat="server">
            <HeaderTemplate>
                <ul class="CatSelector">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="btnCat" CatCode='<%#Eval("Code") %>' CommandName="SelectCat" runat="server"><%#ShowTitle(Eval("Title")) %></asp:LinkButton>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <div class="clear"></div>
    </asp:Panel>

</asp:Panel>

