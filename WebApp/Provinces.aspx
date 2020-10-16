<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" Title="استانها" CodeBehind="Provinces.aspx.cs" Inherits="Decili.Provinces" %>

<%@ Register Src="~/UserControls/Banner.ascx" TagName="UCBanner" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/AdsList.ascx" TagName="AdsList" TagPrefix="UCAdsList" %>
<%@ Register Src="~/UserControls/NormalLogin.ascx" TagName="NormalLogin" TagPrefix="UCLogin" %>
<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/UCSiteInfo.ascx" TagName="UCSiteInfo" TagPrefix="UC" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="MainDataCont">
        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12 ">
                <UCLogin:NormalLogin ID="NormalLogin1" runat="server" />
                <UC:UCUserMenu ID="UCUserMenu1" runat="server" />
                <UC:UCSiteInfo runat="server" />
            </div>
            <div class="col-lg-10 col-md-10 col-sm-8 col-xs-12 ">
                <div class="GreenHeader">
                    <h3>
                        <asp:Label ID="lblHeader" Text="استان ها " runat="server"></asp:Label>
                    </h3>
                </div>
                <div class="Marginer20">
                <asp:Repeater ID="rptProvinces" runat="server">
                    <HeaderTemplate>
                        <ul class="Provinces">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><span class="arr"></span>
                            <asp:HyperLink NavigateUrl='<%#"~/Provinces/" + Eval("Code")  + ".html"%>' runat="server"><%#Eval("Name") %></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>

                </asp:Repeater>
                    </div>

            </div>
        </div>
    </div>
</asp:Content>
