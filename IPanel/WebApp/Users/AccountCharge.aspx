<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserRoot.Master" Title="شارژ حساب" CodeBehind="AccountCharge.aspx.cs" Inherits="Decili.UsersFolder.AccountCharge" %>

<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="Hierarchy">
        <ul class="mnuHierarchy">
            <li class="IcHome">
                <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
            </li>
            <li class="Sep">&nbsp; </li>
            <li>
                <asp:Label ID="Label1" runat="server" Text="شارژ حساب"></asp:Label>
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
            <div class="Page text-left">
                <AKP:MsgBox runat="server" ID="msgMessage">
                </AKP:MsgBox>

                <div>
                    موجودی:
                            <asp:Label ID="lblAccountBalance" runat="server"></asp:Label>
                </div>
                <div>
                    <table class="tblCharge">
                        <tr>
                            <td>
                                <asp:Button ID="btnUpdateAccount" CssClass="btn btn-primary" OnClientClick="HideButton(this);"
                                    runat="server" Text="افزایش اعتبار" OnClick="btnUpdateAccount_Click" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBankCode" CssClass="form-control" runat="server">
                                    <%--<asp:ListItem Text="بانک سامان" Value="1"></asp:ListItem>--%>
                                    <asp:ListItem Text="بانک پارسیان" Value="2"></asp:ListItem>
                                    <%--<asp:ListItem Text="بانک ملت" Value="3"></asp:ListItem>--%>
                                    <asp:ListItem Text="بانک ملی" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label211" runat="server" Text="ریال"></asp:Label>
                            </td>
                            <td>
                                <AKP:ExTextBox ID="txtAmount" CssClass="form-control" runat="server"></AKP:ExTextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="مبلغ شارژ"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="Clear">
                </div>
                <br />
            </div>
        </div>
    </div>



</asp:Content>
