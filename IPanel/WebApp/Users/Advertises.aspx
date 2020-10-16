<%@ Page Title="" Language="C#" MasterPageFile="~/UserRoot.Master" AutoEventWireup="true"
    Inherits="Users_Advertises" CodeBehind="Advertises.aspx.cs" %>

<%@ Register Src="~/UserControls/Toolbar.ascx" TagName="Toolbar" TagPrefix="Tlb" %>
<%@ Register Src="~/UserControls/Banner.ascx" TagName="Banner" TagPrefix="ADS" %>
<%@ Register Src="~/UserControls/Login.ascx" TagName="Login" TagPrefix="LG" %>
<%@ Register Src="~/UserControls/UserTools.ascx" TagName="UserTools" TagPrefix="UTL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CP1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="Marginer1">
                <div class="WinRadiusGray">
                    <div class="CatHeaderCont">
                        <h3 class="CatHeader">
                            <asp:Label ID="lblCatTitle" Text="آگهی ها "
                                runat="server"></asp:Label>
                        </h3>
                    </div>
                    <div class="clear">
                    </div>

                    <div class="Padder10">
                        
                        <div class="text-center MarginBot10">
                            <asp:HyperLink ID="hplNewAd" ImageUrl="~/images/PllaceAd.jpg" NavigateUrl="~/Users/EditAdvertise.aspx"
                                runat="server"></asp:HyperLink>
                        </div>
                        <div class="MyAds">
                            <asp:Repeater runat="server" EnableViewState="false" ID="rptAdvertises">
                                <HeaderTemplate>
                                    <table class="tblMyAds table table-striped">
                                        <tr>
                                            <th>ویرایش
                                            </th>
                                            <th>نوع
                                            </th>
                                            <th>بازدید
                                            </th>
                                            <th>وضعیت
                                            </th>
                                            <th>گروه
                                            </th>
                                            <th>عنوان
                                            </th>
                                            <th>انقضا
                                            </th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:HyperLink runat="server" NavigateUrl='<%#"~/Users/EditAdvertise.aspx?Code=" + Eval("Code") %>'>
                                                    <asp:Image runat="server" ImageUrl="~/images/Edit-32.gif" />
                                            </asp:HyperLink>
                                        </td>
                                        <td>
                                            <%#Eval("RateName") %>
                                        </td>
                                        <td>
                                            <%#Eval("ViewCount") %>
                                        </td>
                                        <td>
                                            <%#Eval("Status") %>
                                        </td>
                                        <td>
                                            <%#Eval("CatName") %>
                                        </td>
                                        <td>
                                            <div class="SingleAdver text-center RTL">
                                                <a href="EditAdvertise.aspx?Code=<%#DataBinder.Eval(Container.DataItem, "Code")%>">
                                                    <%#DataBinder.Eval(Container.DataItem, "Title")%></a>
                                            </div>
                                        </td>
                                        <td>
                                            <%#Tools.ChangeEnc( Eval("EDate").ToString()) %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="Clear">
                </div>
                <div class="Spacer1">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
