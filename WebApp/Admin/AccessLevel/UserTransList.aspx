<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTransList.aspx.cs" MasterPageFile="~/Admin/Main.master" Inherits="Decili.Admin.AccessLevel.UserTransList" %>
<%@ Register Src="~/UserControls/PagerToolbar.ascx" TagName="PagerToolbar" TagPrefix="Tlb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphMain">
    <div class="homeBox">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <AKP:MsgBox runat="server" ID="msgMessage" />
                </div>
                <div>
                    <asp:Repeater runat="server" ID="rptUserTransactions">
                        <HeaderTemplate>
                            <table class="tblMyAds table table-striped">
                                <tr>
                                    <th>آگهی
                                    </th>
                                    <th>بانک
                                    </th>
                                    <th>تاریخ
                                    </th>
                                    <th>وضعیت
                                    </th>

                                    <th>مبلغ
                                    </th>
                                    <th>ایمیل
                                    </th>
                                    <th>کاربر
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="hplAdver" NavigateUrl='<%#"~/Admin/Advertises/EditAdvertises.aspx?Code=" + Eval("ItemCode") %>' runat="server">آگهی</asp:HyperLink>
                                </td>
                                <td>
                                    <%#Eval("BankName") %>
                                </td>
                                <td>
                                    <%#Eval("ChrgDate") %>
                                </td>
                                <td>
                                    <%#Eval("TransStatus") %>
                                </td>
                                <td>
                                    <%#Eval("Amount") %>
                                </td>

                                <td>
                                    <%#Eval("Email") %>
                                </td>
                                <td>
                                    <%#Eval("FirstName") %>&nbsp;<%#Eval("LastName") %>
                                </td>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>
                <div>
                    
    <Tlb:PagerToolbar runat="server" ID="pgrToolbar" />
    
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
