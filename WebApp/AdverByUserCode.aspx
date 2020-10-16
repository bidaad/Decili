<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" CodeBehind="AdverByUserCode.aspx.cs" Inherits="Decili.AdverByUserCode" %>
<%@ Register Src="~/UserControls/AdsList.ascx" TagName="AdsList" TagPrefix="UCAdsList" %>
<%@ Register Src="~/UserControls/ColAds.ascx" TagName="ColAds" TagPrefix="UCColAds" %>
<%@ Register Src="~/UserControls/UCSearchWords.ascx" TagName="SearchWords" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CP1" runat="Server">
    <div class="row">
        <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12">
            

            <UCColAds:ColAds runat="server" ID="LatestAds" />
        </div>
        <div class="col-lg-10 col-md-10 col-sm-8 col-xs-12">
            <div class="GreenHeader">
                <div class="sortoption">
                    <div class="boldtext">حالت نمایش</div>
                    <a href="javascript:void(0);" class="listbtn"></a><a href="javascript:void(0);" class="gridbtn selected"></a>
                </div>
                <h3>
                    <asp:Literal ID="lblHeader" Text="آگهی های گروهی " runat="server"></asp:Literal>
                </h3>
            </div>
            <div class="WinRadiusGray">
                <UCAdsList:AdsList runat="server" ID="AdsList1" />
            </div>
        </div>

    </div>

</asp:Content>
