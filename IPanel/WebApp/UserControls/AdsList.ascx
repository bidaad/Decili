<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_AdsList" CodeBehind="AdsList.ascx.cs" %>
<%@ Register Src="~/UserControls/PagerToolbar.ascx" TagName="PagerToolbar" TagPrefix="Tlb" %>
<%@ Register Src="~/UserControls/StaticPagerToolbar.ascx" TagName="StaticPagerToolbar" TagPrefix="Tlb" %>
<div class="clear">
</div>
<div class="Marginer1">
    <AKP:MsgBox runat="server" ID="msg" />
    <div class="row <%=ShowAdClass() %>">
        <asp:Repeater EnableViewState="false" ID="dtlAds" runat="server">
            <ItemTemplate><div class="AdListItem col-lg-4 col-md-4 col-sm-12 col-xs-12 "><div class="ad"><div class="row"><div class="ColText col-lg-7 col-md-7 col-sm-7 col-xs-12"><h3><asp:HyperLink runat="server" NavigateUrl='<%#ShowUrl("~/Ads/" + Eval("ID") + ".html" + CityCodeParam)  %>'><%#ShowText(Eval("Title")) %></asp:HyperLink></h3><div><%#ShowDeci(Eval("Rate")) %></div><div class="AdName"><%#Eval("Name") %></div><div class="AdTel"><%#ShowTel( Eval("Tel")) %></div><div class="AdDesc NoDisp"><%#ShowText( Eval("Description")) %></div></div><div class="ColImage col-lg-5 col-md-5 col-sm-5 col-xs-12"><asp:HyperLink runat="server" NavigateUrl='<%#ShowUrl("~/Ads/" + Eval("ID") + ".html" + CityCodeParam)  %>'><div class="adimage-cont"><asp:Image CssClass="cSmallADPic" AlternateText='<%#Eval("Title") %>' ImageUrl='<%#"~/Files/Ads/" +  DataBinder.Eval(Container.DataItem, "SmallPicFile")%>' runat="server" /></div></asp:HyperLink></div></div></div></div></ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="Farsi Padder5">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</div>
<div class="Clear"></div>
<p>
    <Tlb:PagerToolbar runat="server" ID="pgrToolbar" />
</p>
<Tlb:StaticPagerToolbar runat="server" ID="StaticPagerToolbar1" />
<script type="text/javascript">
    $(document).ready(function () {
        $(".listbtn").click(function () {
            $(".gridbtn").removeClass("selected");
            $(".listbtn").addClass("selected");

            $(".AdListItem").removeClass("col-lg-4 col-md-4 col-sm-12 col-xs-12");
            $(".AdListItem").addClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
            $(".AdDesc").removeClass("NoDisp");

            $(".ColText").removeClass("col-lg-7 col-md-7 col-sm-7 col-xs-12");
            $(".ColImage").removeClass("col-lg-5 col-md-5 col-sm-5 col-xs-12");

            $(".ColText").addClass("col-lg-10 col-md-10 col-sm-8 col-xs-12");
            $(".ColImage").addClass("col-lg-2 col-md-2 col-sm-4 col-xs-12 text-center Top5");
            createCookie("ViewType", "List", 7);
        });

        $(".gridbtn").click(function () {
            $(".listbtn").removeClass("selected");
            $(".gridbtn").addClass("selected");

            $(".AdListItem").removeClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
            $(".AdListItem").addClass("col-lg-4 col-md-4 col-sm-12 col-xs-12");
            $(".AdDesc").addClass("NoDisp");

            $(".ColText").removeClass("col-lg-10 col-md-10 col-sm-8 col-xs-12");
            $(".ColImage").removeClass("col-lg-2 col-md-2 col-sm-4 col-xs-12 text-center Top5");

            $(".ColText").addClass("col-lg-7 col-md-7 col-sm-7 col-xs-12");
            $(".ColImage").addClass("col-lg-5 col-md-5 col-sm-5 col-xs-12");

            createCookie("ViewType", "Grid", 7);
        });

        var CurrentViewType = readCookie("ViewType");
        if (CurrentViewType == "List") {
            $(".listbtn").click();
        }

    });



</script>
