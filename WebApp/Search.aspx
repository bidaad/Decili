<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" CodeBehind="Search.aspx.cs" Inherits="Decili.Search" %>

<%@ Register Src="~/UserControls/Banner.ascx" TagName="UCBanner" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/AdsList.ascx" TagName="AdsList" TagPrefix="UCAdsList" %>
<%@ Register Src="~/UserControls/NormalLogin.ascx" TagName="NormalLogin" TagPrefix="UCLogin" %>
<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/UCSiteInfo.ascx" TagName="UCSiteInfo" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/AdKeywords.ascx" TagName="AdKeywords" TagPrefix="UCAdKeywords" %>
<%@ Register Src="~/UserControls/UCSearchWords.ascx" TagName="SearchWords" TagPrefix="UC" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="MainDataCont">

        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12 ">
                <UCLogin:NormalLogin ID="NormalLogin1" runat="server" />
                <UC:UCUserMenu ID="UCUserMenu1" runat="server" />
                <UC:UCSiteInfo ID="UCSiteInfo1" runat="server" />
                <UCAdKeywords:AdKeywords runat="server" ID="UCAdKeywords1" />
                <UC:SearchWords runat="server" ID="SearchWords1" />
            </div>
            <div class="col-lg-10 col-md-10 col-sm-8 col-xs-12 ">
                <div class="GreenHeader">
                    <div class="sortoption">
                        <div class="boldtext">حالت نمایش</div>
                        <a href="javascript:void(0);" class="listbtn"></a><a href="javascript:void(0);" class="gridbtn selected"></a>
                    </div>
                    <h3>
                        <asp:Literal ID="lblHeader" Text="آگهی ها " runat="server"></asp:Literal>
                    </h3>
                </div>
                
                <UCAdsList:AdsList runat="server" ID="AdsList1" />

            </div>
        </div>
    </div>
</asp:Content>
