<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="UserControls_SmallAdsList" CodeBehind="SmallAdsList.ascx.cs" %>
<%@ Register Src="~/UserControls/PagerToolbar.ascx" TagName="PagerToolbar" TagPrefix="Tlb" %>
<%@ Register Src="~/UserControls/StaticPagerToolbar.ascx" TagName="StaticPagerToolbar" TagPrefix="Tlb" %>

<div class="panel warning">
    <div class="heading">
        <asp:Label ID="lblColHeader" runat="server"></asp:Label>
    </div>
    <div class="content">

        <asp:Repeater EnableViewState="false" ID="rptAds" runat="server">
            <ItemTemplate>
                <div class="row Padder10">
                    <div class="<%=ShowAdClass() %>">
                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12 text-center ">
                            <div>
                                <%#ShowPrettyDate(Eval("UpdateDate")) %>
                            </div>
                            <div>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/Ads/" + Eval("ID") + ".html" + CityCodeParam  %>'>
                                    <asp:Image CssClass="cSmallADPic" AlternateText='<%#Eval("Title") %>'  BorderWidth="1" ImageUrl='<%#"~/Files/Ads/" +  DataBinder.Eval(Container.DataItem, "SmallPicFile")%>'
                                        runat="server" />
                                </asp:HyperLink>
                            </div>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-9 col-xs-12 ">
                            <h3>
                                <asp:HyperLink runat="server" NavigateUrl='<%#"~/Ads/" + Eval("ID") + ".html" + CityCodeParam  %>'>
                                <%#ShowDeci( Eval("Rate")) %><%#Eval("Title") %>
                                </asp:HyperLink>
                            </h3>
                            <div class="RTL text-justify">
                                <%#Tools.ShowBriefText(Eval("Description"), 400) %>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="Clear">
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<div>
    <Tlb:PagerToolbar runat="server" ID="pgrToolbar" />
</div>
<Tlb:StaticPagerToolbar runat="server" ID="StaticPagerToolbar1" />
