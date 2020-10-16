<%@ Page Title="" Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true"
    Inherits="Ads_ShowAds" CodeBehind="ShowAds.aspx.cs" %>

<%@ Register Src="~/UserControls/AdKeywords.ascx" TagName="AdKeywords" TagPrefix="UCAdKeywords" %>
<%@ Register Src="~/UserControls/ColAds.ascx" TagName="ColAds" TagPrefix="UCColAds" %>
<%@ Register Src="~/UserControls/SmallAdsList.ascx" TagName="SmallAdsList" TagPrefix="UCSmallAdsList" %>
<%@ Register Src="~/UserControls/UCSearchWords.ascx" TagName="SearchWords" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/ShareTools.ascx" TagName="ShareTools" TagPrefix="UCST" %>
<%@ Register Src="~/UserControls/UCCities.ascx" TagName="UCCities" TagPrefix="UC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CP1" runat="Server">
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">

            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-6 col-xs-12 hidden-xs">
                    <UCAdKeywords:AdKeywords runat="server" ID="UCAdKeywords1" />
                </div>
                <div class="col-lg-12 col-md-12 col-sm-6 col-xs-12 hidden-xs">
                    <UC:SearchWords runat="server" ID="SearchWords1" />
                </div>
                <div class="col-lg-12 col-md-12 col-sm-6 col-xs-12">
                    <UCColAds:ColAds runat="server" ID="ColAds1" />
                </div>
                <div class="col-lg-12 col-md-12 col-sm-6 col-xs-12 hidden-xs">
                    <UCColAds:ColAds runat="server" ID="RelatedAds" />
                </div>
            </div>
            <UC:UCCities ID="UCCities1" runat="server" />

        </div>
        <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
            <AKP:MsgBox runat="server" ID="msgBox">
            </AKP:MsgBox>
            <div class="WinRadiusGray Padder10">
                <div class="ShowAdsForm">
                    <asp:Panel runat="server" ID="pnlExpired"></asp:Panel>
                    <ul class="AdSmallTools">
                        <li class="item">
                            <div class="">
                                <span class="fa fa-user "></span>&nbsp;
                                <asp:Label ID="lblSenderName" runat="server" Text=""></asp:Label>
                            </div>
                        </li>
                        <li class="item">
                            <div class="">
                                <span class="fa fa-phone "></span>&nbsp;
                                <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                            </div>
                        </li>
                        <li class="item">
                            <div class="">
                                <span class="fa fa-eye "></span>&nbsp;
                                <asp:Label ID="lblViewCount" runat="server" Text=""></asp:Label>
                            </div>
                        </li>
                        <li class="item">
                            <div class="">
                                <span class="fa fa-calendar "></span>&nbsp;
                                <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                            </div>
                        </li>
                        <li class="item">
                            <div class="">
                                <span class="fa fa-map-marker "></span>&nbsp;
                                <asp:HyperLink ID="hplSenderCity" runat="server"></asp:HyperLink>
                            </div>
                        </li>
                        <li class="item">
                            <div class="">
                                <asp:Literal ID="lblCat" runat="server"></asp:Literal>

                            </div>
                        </li>
                    </ul>
                    <div class="Clear">
                    </div>

                    <div class="AdTitle">
                        <h3>
                            <asp:Literal ID="lblTitle" runat="server"></asp:Literal></h3>
                    </div>
                    <div class="Clear">
                    </div>
                    <asp:Panel ID="pnlLink" Visible="false" CssClass="Padder10" runat="server">
                        <asp:HyperLink ID="hplLink" Target="_blank" runat="server"></asp:HyperLink>
                        <span class="Farsi">لینک آگهی</span><span class="fa fa-link fa-20 "></span>
                    </asp:Panel>
                    <div class="Clear">
                    </div>
                    <asp:Panel ID="pnlDeci" Visible="false" CssClass="DeciCont" runat="server">
                        <div class="fa fa-diamond DecilIcon">
                            &nbsp;
                            <span>
                                <asp:Literal ID="ltrDeci" runat="server"></asp:Literal></span>
                        </div>
                    </asp:Panel>
                    <div class="Clear">
                    </div>
                    <div class="AdDesc">
                        <asp:Panel ID="pnlPic" runat="server" class="AdsPic">
                            <asp:Image ID="imgAdsPic" BorderWidth="1" CssClass="img-responsive" EnableViewState="false" runat="server" />
                        </asp:Panel>
                        <asp:Label ID="lblDescription" EnableViewState="false" runat="server"></asp:Label>
                    </div>
                    <div class="Clear">
                    </div>
                </div>
            </div>
            <div class="WinRadiusGray">
                <div class="Padder10">
                    <asp:Repeater EnableViewState="false" runat="server" ID="rptGenTitleKeys" >
                        <HeaderTemplate>
                            <ul class="TitleKeys">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="hplNum" NavigateUrl='<%# "~/s1-" + Container.DataItem.ToString().Replace(" ","%20") + ".html" %>'
                                    runat="server"><%#Container.DataItem %></asp:HyperLink></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="clear"></div>
                </div>

            </div>
            <div class="WinRadiusGray">
                <UCST:ShareTools ID="ShareTools1" runat="server"></UCST:ShareTools>

            </div>


            <asp:Panel runat="server" ID="pnlGoogleMap" CssClass="WinRadiusGray Padder10">
                <div id="map"></div>
                <script>

                    var map;
                    function initMap() {
                        var myLatLng = {lat: <%=LatX%>, lng: <%=LatY%>};

                        map = new google.maps.Map(document.getElementById('map'), {
                            center: { lat: <%=LatX%>, lng: <%=LatY%> },
                            zoom: 16
                        });
                        var marker = new google.maps.Marker({
                            position: myLatLng,
                            map: map,
                            title: '<%=AdTitle%>'
                        });

                    }

                </script>
                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBNopLzSBGXq9Z-ppYKoU_p9czpmm89I54&callback=initMap"
                    async defer></script>
            </asp:Panel>
            <div class="Marginer5">
                <div class="row">
                    <div class="col-lg-5 col-sm-5 col-md-5 col-xs-12 text-center ">
                        <div class="panel">
                            <div class="heading">
                                مشخصات آگهی دهنده
                            </div>
                            <div class="content Padder10">

                                <asp:Panel runat="server" ID="pnlAdsInfo" CssClass="WinRadiusGray Padder10 AdsOwnerInfo">
                                    <div class="row">
                                        <asp:Panel ID="pnlEmail" runat="server">
                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label1" runat="server" Text="ایمیل:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Image ID="imgEmail" runat="server" />
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>

                                        <asp:Panel ID="pnlName" runat="server">
                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label4" runat="server" Text="نام:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel ID="pnlTel" runat="server">

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label5" runat="server" Text="تلفن:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Label ID="lblTel" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel ID="pnlPrice" runat="server">

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label6" runat="server" Text="قیمت:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Label ID="lblPrice" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel ID="pnlAdsDate" runat="server">

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label10" runat="server" Text="انقضا:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Label ID="lblAdsDate" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel ID="pnlStateName" runat="server">

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label9" runat="server" Text="موقعیت:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Label ID="lblStateName" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel ID="pnlCity" Visible="false" runat="server">

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label2" runat="server" Text="موقعیت:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Label ID="lblCityProvince" CssClass="AdAddress" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel ID="pnlAddress" runat="server">

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 text-right RTL">
                                                <asp:Label ID="Label8" runat="server" Text="آدرس:"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 text-left">
                                                <asp:Label ID="lblAddress" CssClass="AdAddress" runat="server"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                    <div class="clearfix"></div>

                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-7 col-sm-7 col-md-7 col-xs-12 text-center ">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel runat="server" CssClass="panel" ID="pnlContactAdvertiser">
                                    <div class="heading">
                                        تماس با آگهی دهنده
                                    </div>
                                    <div class="content Padder10">
                                        <AKP:MsgBox runat="server" ID="msgMessage">
                                        </AKP:MsgBox>

                                        <div class="row">
                                            <div class="col-lg-4 col-sm-4 col-md-4 col-xs-12 ">
                                                <div class="form-inline">
                                                    <div class="form-group">

                                                        <AKP:ExTextBox runat="server" ID="txtName" CssClass="form-control" placeholder="نام" MaxLength="70" TabIndex="2" />

                                                    </div>
                                                </div>
                                                <div class="form-inline">
                                                    <div class="form-group">


                                                        <AKP:ExTextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="ایمیل شما" MaxLength="70" TabIndex="2" />

                                                    </div>
                                                </div>
                                                <div class="">
                                                    <telerik:RadCaptcha ID="RadCaptcha1" CssClass="Capt" CaptchaImage-ImageCssClass="CaptImg"
                                                        CaptchaTextBoxCssClass="form-control" runat="server"
                                                        ErrorMessage="" CaptchaTextBoxLabel="">
                                                    </telerik:RadCaptcha>
                                                </div>
                                                <div class="form-inline">
                                                    <div class="form-group">
                                                        <asp:LinkButton ID="btnSendToAdvertiser" CssClass="btn btn-success btn-block" Text="ارسال" runat="server" OnClick="btnSendToAdvertiser_Click" />

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-8 col-sm-8 col-md-8 col-xs-12 ">
                                                <div class="form-inline">
                                                    <div class="form-group">


                                                        <AKP:ExTextBox ID="txtQuestion" TextMode="MultiLine" Height="200" runat="server" CssClass="form-control" placeholder="پرسش"
                                                            MaxLength="32" TabIndex="2" />

                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </asp:Panel>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnSendToAdvertiser" />
                            </Triggers>

                        </asp:UpdatePanel>

                    </div>

                </div>
            </div>

            <UCSmallAdsList:SmallAdsList runat="server" ID="UCSmallAdsList1" />

            <div class="WinRadiusGray">
                <asp:Panel runat="server" ID="pnlRelatedNews">
                    <div class="GreenHeader">
                        <h3>
                            <asp:Label ID="lblHeader" Text="اخبار مرتبط" runat="server"></asp:Label>
                        </h3>
                    </div>
                    <div class="Win2">
                        <div class="AdsRelatedNews">
                            <asp:Repeater ID="rptRelatedNews" EnableViewState="false" runat="server">
                                <ItemTemplate>
                                    <div>
                                        <asp:Image runat="server" CssClass="ImgNewsResource" ImageUrl='<%#"https://static.parset.com/Resources/" + Eval("ResouseSiteCode") + ".png" %>' />
                                        <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%#"http://www.parset.com/FaNews/" + Eval("Code")  + "_.html"%>'>
                                            <%#Eval("Title") %>
                                        </asp:HyperLink>
                                        &nbsp;<span class="NewsDate"><%#ShowDate( Eval("NewsDate")) %></span>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </div>

    </div>
</asp:Content>
