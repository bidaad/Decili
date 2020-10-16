<%@ Page Language="C#" AutoEventWireup="True" EnableEventValidation="false" CodeBehind="Panel.aspx.cs" Inherits="BudgetWebApp.Panel"
    MasterPageFile="~/Admin/Main.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphMain">
    <div class="homeBox">
        <div class="homeIconTable">
            <div onmouseout="this.className='homeIconBox'" onmouseover="this.className='homeIconBox homeIconBoxHover'"
                class="homeIconBox">
                <asp:HyperLink runat="server" NavigateUrl="~/Admin/News/EditNews.aspx">
                    <asp:Image runat="server" ImageUrl="~/Admin/images/Site/addNews.png" />
                    <h4>
                        ثبت خبر جدید
                    </h4>
                </asp:HyperLink>
            </div>
            <div onmouseout="this.className='homeIconBox'" onmouseover="this.className='homeIconBox homeIconBoxHover'"
                class="homeIconBox">
                <asp:HyperLink runat="server" NavigateUrl="~/Admin/Main/Default.aspx?BaseID=News">
                    <asp:Image runat="server" ImageUrl="~/Admin/images/Site/newsList.png" />
                    <h4>
                        اخبار ثبت شده</h4>
                </asp:HyperLink>
            </div>
            <div onmouseout="this.className='homeIconBox'" onmouseover="this.className='homeIconBox homeIconBoxHover'"
                class="homeIconBox">
                <asp:HyperLink ID="hplBanners" runat="server" NavigateUrl="~/Admin/Main/Default.aspx?BaseID=Banners">
                    <asp:Image runat="server" ImageUrl="~/Admin/images/Site/addPage.png" />
                    <h4>
                        بنرها
                    </h4>
                </asp:HyperLink>
            </div>
            <div onmouseout="this.className='homeIconBox'" onmouseover="this.className='homeIconBox homeIconBoxHover'"
                class="homeIconBox">
                <asp:HyperLink ID="hplLinks" runat="server" NavigateUrl="~/Admin/Main/Default.aspx?BaseID=Links">
                    <asp:Image runat="server" ImageUrl="~/Admin/images/Site/addPage.png" />
                    <h4>
                        پیوندهای مرتبط
                    </h4>
                </asp:HyperLink>
            </div>

            <div onmouseout="this.className='homeIconBox'" onmouseover="this.className='homeIconBox homeIconBoxHover'"
                class="homeIconBox">
                <asp:HyperLink runat="server" NavigateUrl="~/Admin/HardCode/HardCodes.aspx?ResourceName=HardCodes">
                    <asp:Image runat="server" ImageUrl="~/Admin/images/Site/config.png" />
                    <h4>
                        تنظیمات سایت</h4>
                </asp:HyperLink>
            </div>
            <div onmouseout="this.className='homeIconBox'" onmouseover="this.className='homeIconBox homeIconBoxHover'"
                class="homeIconBox">
                <a href="Logout.aspx">
                    <asp:Image runat="server" ImageUrl="~/Admin/images/Site/SignOut.png" />
                    <h4>خروج</h4>
                </a>
            </div>
            <br class="clearfloat" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <AKP:MsgBox runat="server" ID="msgMessage" />
                </div>
                <div>
                    <asp:Repeater runat="server" OnItemCommand="HandleRepeaterCommand" ID="rptAdvertises">
                        <HeaderTemplate>
                            <table class="tblMyAds table table-striped">
                                <tr>
                                    <th>نمایش
                                    </th>

                                    <th>وضعیت
                                    </th>
                                    <th>عنوان
                                    </th>
                                    <th>کاربر
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Button Text="نمایش" ToolTip="نمایش" CssClass="btn btn-default" ID="btnShowAds" Code='<%#Eval("Code") %>' CommandName="ShowAds" runat="server"></asp:Button>
                                </td>
                                <td>
                                    <%#Eval("Status") %>
                                </td>

                                <td>
                                    <div class="SingleAdver text-center RTL">
                                        <a href="../Advertises/EditAdvertises.aspx?Code=<%#DataBinder.Eval(Container.DataItem, "Code")%>">
                                            <%#DataBinder.Eval(Container.DataItem, "Title")%></a>
                                    </div>
                                </td>
                                <td>
                                    <%#Eval("FirstName") %>&nbsp;<%#Eval("LastName") %>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlAdsInfo" CssClass="Marginer10" Visible="false" runat="server">
                                <tr>
                                    <td colspan="4">
                                        <div class="form-group">
                                            <AKP:ExTextBox ID="txtTitle" CssClass="form-control EditAdTitle" placeholder="عنوان آگهی" MaxLength="200" runat="server"></AKP:ExTextBox>
                                        </div>
                                        <div class="form-inline">
                                            <div class="form-group">
                                                <AKP:ExTextBox ID="txtDescription" CssClass="form-control AdText" placeholder="شرح آگهی" Height="150" TextMode="MultiLine" runat="server"></AKP:ExTextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 ">
                                                <div class="form-group">
                                                    <AKP:ExTextBox ID="txtTel" MaxLength="200" placeholder="تلفن" CssClass="form-control" runat="server"></AKP:ExTextBox>
                                                </div>

                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group">
                                                    <AKP:ExTextBox ID="txtName" MaxLength="200" placeholder="نام" CssClass="form-control" runat="server"></AKP:ExTextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="form-inline">
                                            <div class="form-group">
                                                <AKP:ExTextBox ID="txtAddress" placeholder="آدرس" CssClass="form-control AdAddress" runat="server"></AKP:ExTextBox>
                                            </div>

                                        </div>
                                        <div class="form-group">
                                            <AKP:ExTextBox ID="txtPrice" MaxLength="200" placeholder="قیمت" CssClass="form-control" runat="server"></AKP:ExTextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:HyperLink ID="hplLink" Target="_blank" runat="server"></asp:HyperLink>
                                        </div>
                                        <div class="form-group">
                                            <asp:HyperLink ID="hplEdit" Target="_blank" runat="server"></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:Image ID="imgAdsPic" runat="server" />
                                        </div>
                                        <div class="Marginer10">
                                            <asp:Button Text="تایید" ID="btnApprove" CommandName="Approve" CssClass="btn btn-success btn-block" runat="server"></asp:Button>
                                        </div>
                                    </td>
                                </tr>

                            </asp:Panel>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
