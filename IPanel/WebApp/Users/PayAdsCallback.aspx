<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayAdsCallback.aspx.cs" MasterPageFile="~/UserRoot.Master" Inherits="Decili.UsersFolder.PayAdsCallback" %>


<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="MainDataCont">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="نتیجه تراکنش بانک"></asp:Label>
                </li>
            </ul>
        </div>
        <div class="Clear">
        </div>
        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12 ">
                <UC:UCUserMenu ID="UCUserMenu1" runat="server" />

            </div>
            <div class="col-lg-10 col-md-10 col-sm-8 col-xs-12 ">
                <div class="Page">


                    <div class="">
                        <AKP:MsgBox runat="server" ID="msgMessage">
                        </AKP:MsgBox>
                    </div>
                    
                    <div class="Clear">
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <div class="Clear">
    </div>
</asp:Content>

