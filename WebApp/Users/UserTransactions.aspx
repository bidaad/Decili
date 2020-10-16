<%@ Page Language="C#" AutoEventWireup="true" Title="دسیلی :: مشاهده تراکنشها" MasterPageFile="~/UserRoot.Master" CodeBehind="UserTransactions.aspx.cs" Inherits="Decili.UsersFolder.UserTransactionsPage" %>

<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="Hierarchy">
                    <ul class="mnuHierarchy">
                        <li class="IcHome">
                            <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                        </li>
                        <li class="Sep">&nbsp; </li>
                        <li>
                            <asp:Label ID="Label1" runat="server" Text="مشاهده تراکنشها"></asp:Label>
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

                
                <div>
                    <asp:Repeater ID="rptTransList" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped">
                                <tr class="warning">
                                    <th>وضعیت
                                    </th>
                                    <th>مبلغ
                                    </th>
                                    <th>تاریخ
                                    </th>
                                    <th>نوع
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="<%#ShowClass(Eval("Amount")) %>">
                                <td>
                                    <%#Eval("TransStatus")%>
                                </td>
                                <td>
                                    <%#ShowAmount(Eval("Amount")) %>
                                </td>
                                <td>
                                    <%#Tools.ChangeEnc(Eval("ChrgDate"))%>
                                </td>
                                <td>
                                    <%#ShowPayDirection(Eval("Amount")) %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="<%#ShowClass(Eval("Amount")) %>">
                                <td>
                                    <%#Eval("TransStatus")%>
                                </td>
                                <td>
                                    <%#ShowAmount(Eval("Amount")) %>
                                </td>
                                <td>
                                    <%#Tools.ChangeEnc(Eval("ChrgDate"))%>
                                </td>
                                <td>
                                    <%#ShowPayDirection(Eval("Amount")) %>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="Clear">
                </div>
                <br />
            </div>
        </div>
    </div>



</asp:Content>
