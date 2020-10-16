<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserRoot.Master" Title="ارتقای عضویت :: دسیلی"  CodeBehind="UpgradeMembership.aspx.cs" Inherits="Decili.UsersFolder.UpgradeMembership" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">

    <div class="panel panel-default Marginer20 EditForm">
        <div class="panel-heading ListTitle">
            <h3 class="panel-title BulletList">ارتقای عضویت</h3>
        </div>
        <div class="Padder5">
            <AKP:MsgBox runat="server" ID="msgMessage">
            </AKP:MsgBox>
            <table class="table table-striped tblMembership">
                <tr>
                    <td>طلایی
                    </td>
                    <td>نقره ای
                    </td>
                    <td>برنزی
                    </td>
                    <td>عادی
                    </td>
                    <td>
                        <div class="btn-group">
                            <button id="btnMembership" type="button" class="btn btn-info">
                                <asp:Literal ID="Literal2" Text="مدت عضویت" runat="server"></asp:Literal>
                            </button>
                            <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="caret"></span>
                                <span class="sr-only">Toggle Dropdown</span>
                            </button>

                            <ul id="MembershipLenList" class="dropdown-menu">
                                <li><a href="#M1">یکماهه</a></li>
                                <li><a href="#M2">سه ماهه</a></li>
                                <li><a href="#M3">شش ماهه</a></li>
                                <li><a href="#M4">یکساله</a></li>
                            </ul>
                        </div>

                    </td>
                </tr>
                <tr class="success">
                    <td>نامحدود
                    </td>
                    <td>٢٠
                    </td>
                    <td>١٠
                    </td>
                    <td>٥
                    </td>
                    <td>تعداد آگهی
                    </td>
                </tr>
                <tr class="warning">
                    <td>تا پایان عضویت
                    </td>
                    <td>تا پایان عضویت
                    </td>
                    <td>تا پایان عضویت
                    </td>
                    <td>٣٠ روز
                    </td>
                    <td>مدت آگهی
                    </td>
                </tr>
                <tr class="info">
                    <td>٥٠،٠٠٠ تومان
                    </td>
                    <td>١٥،٠٠٠ تومان
                    </td>
                    <td>١٠،٠٠٠ تومان
                    </td>
                    <td>٠
                    </td>
                    <td>تعرفه
                    </td>
                </tr>
                <tr class="">
                    <td>
                        <asp:Button ID="btnGold" runat="server" CssClass="btn btn-success btn-block" Text="انتخاب" OnClick="btnGold_Click" />
                    </td>
                    <td><asp:Button ID="btnSilver" runat="server" CssClass="btn btn-warning btn-block" Text="انتخاب" OnClick="btnSilver_Click" />
                    </td>
                    <td><asp:Button ID="btnBronze" runat="server" CssClass="btn btn-info btn-block" Text="انتخاب" OnClick="btnBronze_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <div class="btn-group">
                            <button id="btnBankCode" type="button" class="btn btn-info">
                                <asp:Literal ID="Literal1" Text="انتخاب بانک" runat="server"></asp:Literal>
                            </button>
                            <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="caret"></span>
                                <span class="sr-only">Toggle Dropdown</span>
                            </button>
                           <ul id="BankList" class="dropdown-menu">
                                <li><a href="#B2">پارسیان</a></li>
                                <li><a href="#B4">ملی</a></li>
                            </ul>
                            </div>
                    </td>
                </tr>
            </table>

            <div class="clear"></div>
        </div>
    </div>
    <div class="clear"></div>

    <asp:HiddenField ID="HiddenMembershipLen" ClientIDMode="Static" Value="1" runat="server" />
    <asp:HiddenField ID="HiddenBankCode" ClientIDMode="Static" Value="2" runat="server" />

<script type="text/javascript">
    $("#MembershipLenList li").click(function () {
        $("#btnMembership").html($(this).text());
        FuelCode = $(this).children("a").attr("href").replace('#M', '');
        $("#HiddenMembershipLen").val(FuelCode);
    });

    $("#BankList li").click(function () {
        $("#btnBankCode").html($(this).text());
        BankCode = $(this).children("a").attr("href").replace('#B', '');
        $("#HiddenBankCode").val(BankCode);
    });

</script>
</asp:Content>