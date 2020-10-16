<%@ Page Language="C#" AutoEventWireup="true" Title="دسیلی :: پنل کاربری" MasterPageFile="~/UserRoot.Master"
    CodeBehind="Default.aspx.cs" Inherits="Decili.UsersFolder.Default" %>

<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <script type="text/javascript" src="../Scripts/jquery.stepper.min.js"></script>
    <div class="MainDataCont">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="صفحه کاربر"></asp:Label>
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
                    <asp:Panel runat="server" ID="pnlMembershipMessage" Visible="false" CssClass="cOkMessage Padder10 ">
                        <asp:Literal ID="ltrHeaderMessage" runat="server"></asp:Literal>
                    </asp:Panel>
                    <%--<div id="MainMsg" class="cOkMessage Padder10 NoDisp">
                        <h3>
                            <span class="fa fa-diamond Green"></span>
                            مزایای ویژه کردن آگهی
                        </h3>
                        آگهی های ویژه در صفحه اول سایت به نمایش در میآیند<br />
                        بدلیل نمایش آگهی های ویژه در صفحات متعدد سایت، این دسته آگهی ها بیشتر مورد بازدید قرار میگیرند <br />
                        هنگام مشاهده آگهی ، آگهی های ویژه همگروه با آن، بالاتر از بقیه نمایش داده میشوند
                    </div>--%>
                    <asp:Panel runat="server" ID="pnlMyAdsTitle" CssClass="Farsi Marginer5">
                        فهرست آگهی های من
                    </asp:Panel>
                    <div class="MyAds">
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                        <asp:Repeater runat="server" OnItemCommand="HandleRepeaterCommand" ID="rptAdvertises">
                            <ItemTemplate>
                                <div class="WinRadiusGray Padder10">
                                    <div class="SingleAdver">
                                        <a id="Ad<%#Eval("Code") %>" href="EditAdvertise.aspx?Code=<%#DataBinder.Eval(Container.DataItem, "Code")%>">
                                            <%#DataBinder.Eval(Container.DataItem, "Title")%></a>
                                    </div>
                                    <div class="SingleAdver Farsi">
                                        <%#Tools.ShowBriefText(Eval("Description"), 200)%>
                                    </div>
                                    <div class="Clear"></div>
                                    <div>
                                        <ul class="AdsButtons">
                                            <li>
                                                <asp:LinkButton ID="btnMakeSpecial" CommandName="MakeSpecial" CssClass="btn btn-info" runat="server">سفارش ویژه
                                                    <span class="fa fa-star "></span>
                                                </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ToolTip="ویرایش" CommandName="Edit" CssClass="btn btn-warning" runat="server">ویرایش
                                                    <span class="fa fa-edit fa-20 "></span>
                                                </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ToolTip="حذف" CssClass="btn btn-danger" OnClientClick="return confirm('آیا از حذف این آگهی اطمینان دارید؟');" runat="server" CommandName="Delete" ID="btnDelete" Code='<%#Eval("Code") %>'>حذف
                                                    <span class="fa fa-remove fa-20 "></span>
                                                </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ToolTip="بروزرسانی" CssClass="btn btn-success" runat="server" CommandName="Update" ID="btnUpdate" Code='<%#Eval("Code") %>'>بروزرسانی
                                                    <span class="fa fa-refresh fa-20 "></span>
                                                </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:Panel ID="pnlLink" Visible='<%#IsActivateLinkVis(Eval("Link"), Eval("LinkActivated"))%>' runat="server">
                                                    <asp:LinkButton ToolTip="فعال کردن لینک آگهی" CssClass="btn btn-primary" runat="server" CommandName="ActivateLink" ID="btnActivateLink" Code='<%#Eval("Code") %>'>فعال کردن لینک آگهی<span class="fa fa-link fa-20 "></span>
                                                    </asp:LinkButton>
                                                </asp:Panel>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="Clear"></div>
                                    <br />
                                    <div>
                                        <ul class="AdSmallTools">
                                            <li class="item">
                                                <div class="">
                                                    <span class="fa fa-calendar "></span>&nbsp;
                                                    تاریخ انقضا:
                                                    <asp:Label ID="lblExpDate" runat="server"><%#Tools.ChangeEnc( Eval("EDate").ToString()) %></asp:Label>
                                                </div>
                                            </li>
                                            <li class="item">
                                                <div class="">
                                                    <span class="fa fa-calendar "></span>&nbsp;
                                                    تاریخ بروزرسانی:
                                                    <asp:Label ID="lblUpdateDate" runat="server"><%#Tools.ChangeEnc( Eval("UDate").ToString()) %></asp:Label>
                                                </div>
                                            </li>
                                            <li class="item">
                                                <div class="">
                                                    <span class="fa fa-eye "></span>&nbsp;
                                                    تعداد مشاهده: <%#Eval("ViewCount") %>
                                                </div>
                                            </li>
                                            <li class="item">
                                                <div class="">
                                                    <span class="fa fa-check "></span>&nbsp;وضعیت:
                                                    <%#Eval("Status") %>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="Clear"></div>
                                    <AKP:MsgBox runat="server" ID="msgItem" />
                                    <asp:Panel runat="server" ID="pnlSpecialAds" Visible="false" CssClass="WinRadiusGray ">
                                        <div class="Marginer10">
                                            <ul class="DecilTool">
                                                <li>
                                                    <div class="DCItem">
                                                        <span class="fa fa-diamond DecilIcon"></span>
                                                    </div>
                                                </li>
                                                <li>
                                                    <asp:TextBox ID="txtDecilCount" CssClass="form-control DecilCounter" Width="40" Text="1" runat="server"></asp:TextBox>
                                                </li>
                                                <li>
                                                    <div class="DCItem">
                                                        دِسی
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="DCItem">
                                                        =
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="DCItem" id="Amount">۲۰۰۰۰ تومان</div>
                                                </li>
                                                <li>
                                                    <div class="DCItem" style="margin-right: 20px;">درگاه پرداخت</div>

                                                </li>
                                                <li>
                                                    <asp:DropDownList ID="ddlBankCode" CssClass="form-control" runat="server">

                                                        <%--<asp:ListItem Text="بانک سامان" Value="1"></asp:ListItem>--%>
                                                        <asp:ListItem Text="بانک پارسیان" Value="2"></asp:ListItem>
                                                        <%--<asp:ListItem Text="بانک ملت" Value="3"></asp:ListItem>--%>
                                                        <asp:ListItem Text="بانک ملی" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </li>
                                                <li>

                                                    <asp:LinkButton ID="btnPay" CommandName="MakePayment" CssClass="btn btn-success" runat="server">پرداخت
                                    <span class="fa fa-check-square "></span>
                                                    </asp:LinkButton>

                                                </li>

                                            </ul>
                                            <div class="Clear"></div>
                                            <script type="text/javascript">
                                                $('#txtDecilCount').stepper({
                                                    wheel_step: 1,
                                                    arrow_step: 1,
                                                    onStep: CalcAmount,
                                                    limit: [1, ]
                                                });

                                            </script>
                                            <div class="Farsi">
                                                دسی : دسی معیاری برای نحوه نمایش آگهی هاست. آگهی هایی که دسی بالاتری دارند در اولویت نمایش  می باشند.
                                                
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlActivateLink" Visible="false" CssClass="WinRadiusGray ">
                                        <div class="Marginer10">
                                            <ul class="DecilTool">
                                                <li>
                                                    <div class="DCItem RTL">٣۰۰۰ تومان </div>
                                                </li>
                                                <li>
                                                    <div class="DCItem" style="margin-right: 20px;">درگاه پرداخت</div>

                                                </li>
                                                <li>
                                                    <asp:DropDownList ID="ddlActivateLinkBankCode" CssClass="form-control" runat="server">

                                                        <%--<asp:ListItem Text="بانک سامان" Value="1"></asp:ListItem>--%>
                                                        <asp:ListItem Text="بانک پارسیان" Value="2"></asp:ListItem>
                                                        <%--<asp:ListItem Text="بانک ملت" Value="3"></asp:ListItem>--%>
                                                        <asp:ListItem Text="بانک ملی" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </li>
                                                <li>

                                                    <asp:LinkButton ID="btnPayLinkActivation" CommandName="MakeActivateLinkPayment" CssClass="btn btn-success" runat="server">پرداخت
                                    <span class="fa fa-check-square "></span>
                                                    </asp:LinkButton>

                                                </li>

                                            </ul>
                                            <div class="Clear"></div>

                                            <div class="Farsi">
                                                با فعال کردن لینک آگهی ، لینک بصورت فالو در صفحه آگهی شما به نمایش در می آید

                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="Clear"></div>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                    <div class="Clear">
                    </div>
                    <div class="Marginer20">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 ">
                                <input type="button" value="ارسال آگهی" onclick="window.location.href = '/Users/EditAdvertise.aspx'" class="btn-success btn btn-block" />
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 Farsi ">
                                ارسال و نمایش آگهی در "دسیلی" رایگان میباشد.
                            </div>
                        </div>
                    </div>



                    <br />
                </div>
            </div>
        </div>
    </div>
    <div class="Clear">
    </div>

    <script type="text/javascript">

        function CalcAmount(val, up) {
            try {
                var out = val * 20000;
                $('#Amount').html(ChangeEnc(out + ' تومان'));
            }
            catch (err) {
                alert(err);
            }
        }
        $(document).ready(function () {
            //setTimeout("$('#MainMsg').slideDown();", 2000);

        });
        
    </script>
</asp:Content>

