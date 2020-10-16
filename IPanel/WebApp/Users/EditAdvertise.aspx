<%@ Page Title="ارسال آگهی" Language="C#" MasterPageFile="~/UserRoot.Master" AutoEventWireup="true"
    Inherits="Users_EditAdvertise" CodeBehind="EditAdvertise.aspx.cs" %>

<%@ Register Src="~/UserControls/UCCatSelector.ascx" TagName="UCCatSelector" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CP1" runat="Server">
    <link href="https://static.parset.com/Styles/fileinput.min.css" media="all" rel="stylesheet" type="text/css" />
    <script src="https://static.parset.com/Scripts/fileinput.js" type="text/javascript"></script>
    <script src="https://static.parset.com/Scripts/fileinput_locale_fa.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/jquery.stepper.min.js"></script>
    <div class="row">
        <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12 ">
            <UC:UCUserMenu ID="UCUserMenu1" runat="server" />

        </div>
        <div class="col-lg-10 col-md-10 col-sm-8 col-xs-12 ">
            <div class="Page">
                <asp:Panel runat="server" Visible="false" ID="pnlMembershipMessage" CssClass="cOkMessage Padder10 ">
                        <asp:Literal ID="ltrHeaderMessage" runat="server"></asp:Literal>
                    </asp:Panel>
                    <asp:LinkButton ID="btnUpgradeMembership" Visible="false" CssClass="btn btn-info" OnClick="btnUpgradeMembership_Click" runat="server">ارتقای عضویت
                                    <span class="fa fa-star "></span>
                    </asp:LinkButton>

                <asp:Panel runat="server" ID="pnlSendAdver">
                    

                    <asp:Panel runat="server" ID="pnlAdTools" Visible="false" CssClass="WinRadiusGray ">
                        <asp:Panel runat="server" CssClass="AdsButCont">
                            <ul class="AdsButtons">
                                <li>
                                    <asp:LinkButton ID="btnMakeSpecial" CssClass="btn btn-info" OnClick="btnMakeSpecial_Click" runat="server">سفارش ویژه
                                    <span class="fa fa-star "></span>
                                    </asp:LinkButton>

                                </li>
                                <li>
                                    <asp:LinkButton ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" runat="server">بروز رسانی
                                    <span class="fa fa-refresh "></span>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="btnDelAds" OnClientClick="return confirm('آیا از حذف این آگهی اطمینان دارید؟');" CssClass="btn btn-danger" runat="server" OnClick="btnDelAds_Click">حذف آگهی
                                    <span class="fa fa-remove "></span>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="btnViewAds" CssClass="btn btn-primary" runat="server" OnClick="btnViewAds_Click">مشاهده آگهی
                                    <span class="fa fa-eye "></span>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <div class="ExpDate">
                                        تاریخ انقضا:
                                    <asp:Label ID="lblExpDate" CssClass="Val" runat="server" Text=""></asp:Label>
                                        <span class="fa fa-calendar "></span>
                                    </div>
                                </li>
                                <li>
                                    <div class="ExpDate">
                                        تاریخ ثبت اولیه:
                                    <asp:Label ID="lblCreateDate" CssClass="Val" runat="server" Text=""></asp:Label>
                                        <span class="fa fa-calendar "></span>
                                    </div>
                                </li>
                            </ul>
                            <div class="clear"></div>
                        </asp:Panel>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlSpecialAds" Visible="false" CssClass="WinRadiusGray ">
                        <div class="Marginer10">
                            <ul class="DecilTool">
                                <li>
                                    <div class="DCItem">
                                        <span class="fa fa-diamond DecilIcon"></span>
                                    </div>
                                </li>
                                <li>
                                    <asp:TextBox ID="txtDecilCount" CssClass="form-control DecilCounter" Width="40" ClientIDMode="Static" Text="1" runat="server"></asp:TextBox>
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

                                    <asp:LinkButton ID="btnPay" CssClass="btn btn-success" runat="server" OnClick="btnPay_Click">پرداخت
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
                                function CalcAmount(val, up) {
                                    try {
                                        var out = val * 20000;
                                        $('#Amount').html(ChangeEnc(out + ' تومان'));
                                    }
                                    catch (err) {
                                        alert(err);
                                    }
                                }
                            </script>
                            <div class="Farsi">
                                دسی : دسی معیاری برای نحوه نمایش آگهی هاست. آگهی هایی که دسی بالاتری دارند در اولویت نمایش  می باشند.

                            </div>
                        </div>
                    </asp:Panel>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <div class="WinRadiusGray">
                                <div class="CatHeaderCont">
                                    <h3 class="CatHeader">
                                        <asp:Label ID="lblHeader" Text="ایجاد آگهی جدید "
                                            runat="server"></asp:Label>
                                    </h3>
                                </div>
                                <div class="clear">
                                </div>
                                <AKP:MsgBox runat="server" ID="msgBox">
                                </AKP:MsgBox>

                                <asp:Panel runat="server" ID="pnlAdForm" CssClass="Marginer1 RTL">
                                    <div class="Box1">
                                        <div class="AdverForm">
                                            <div style="margin-bottom: 5px;">
                                            </div>
                                            <asp:Panel ID="pnlDeci" Visible="false" CssClass="Padder10" runat="server">
                                                آگهی ویژه:
                                                <div class="fa fa-diamond DeciIconAds">&nbsp;<asp:Label ID="lblDeciCount" runat="server" Text=""></asp:Label></div>
                                            </asp:Panel>
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <UC:UCCatSelector runat="server" ID="CatSelector1" />
                                                </div>
                                            </div>

                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <AKP:ExTextBox ID="txtTitle" CssClass="form-control EditAdTitle" placeholder="عنوان آگهی" MaxLength="200" runat="server"></AKP:ExTextBox>
                                                </div>

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
                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                    <div class="form-inline">
                                                        <div class="Padder5">
                                                            استان
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:DropDownList ID="cboHCStateCode" DataTextField="Name" AutoPostBack="true" DataValueField="Code" placeholder="موقعیت" CssClass="form-control" runat="server" OnSelectedIndexChanged="cboHCStateCode_SelectedIndexChanged">
                                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                                                <asp:ListItem Text="آذربايجان شرقي" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="آذربايجان غربي" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="اردبيل" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="اصفهان" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="ايلام" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="بوشهر" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="تهران" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="چهارمحال بختياري" Value="8"></asp:ListItem>
                                                                <asp:ListItem Text="خراسان جنوبي" Value="9"></asp:ListItem>
                                                                <asp:ListItem Text="خراسان رضوي" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="خراسان شمالي" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="خوزستان" Value="12"></asp:ListItem>
                                                                <asp:ListItem Text="زنجان" Value="13"></asp:ListItem>
                                                                <asp:ListItem Text="سمنان" Value="14"></asp:ListItem>
                                                                <asp:ListItem Text="سيستان و بلوچستان" Value="15"></asp:ListItem>
                                                                <asp:ListItem Text="فارس" Value="16"></asp:ListItem>
                                                                <asp:ListItem Text="قزوين" Value="17"></asp:ListItem>
                                                                <asp:ListItem Text="قم" Value="18"></asp:ListItem>
                                                                <asp:ListItem Text="البرز" Value="19"></asp:ListItem>
                                                                <asp:ListItem Text="كردستان" Value="20"></asp:ListItem>
                                                                <asp:ListItem Text="كرمان" Value="21"></asp:ListItem>
                                                                <asp:ListItem Text="كرمانشاه" Value="22"></asp:ListItem>
                                                                <asp:ListItem Text="كهكيلويه و بويراحمد" Value="23"></asp:ListItem>
                                                                <asp:ListItem Text="گلستان" Value="24"></asp:ListItem>
                                                                <asp:ListItem Text="گيلان" Value="25"></asp:ListItem>
                                                                <asp:ListItem Text="لرستان" Value="26"></asp:ListItem>
                                                                <asp:ListItem Text="مازندران" Value="27"></asp:ListItem>
                                                                <asp:ListItem Text="مركزي" Value="28"></asp:ListItem>
                                                                <asp:ListItem Text="هرمزگان" Value="29"></asp:ListItem>
                                                                <asp:ListItem Text="همدان" Value="30"></asp:ListItem>
                                                                <asp:ListItem Text="يزد" Value="31"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                    <div class="form-inline">
                                                        <div class="Padder5">
                                                            شهر
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:DropDownList ID="ddlCities" DataTextField="Name" DataValueField="Code" placeholder="شهر" CssClass="form-control" runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>




                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                    <div class="Padder5">
                                                        قیمت
                                                    </div>
                                                    <div class="form-group">
                                                        <AKP:ExTextBox ID="txtPrice" MaxLength="200" placeholder="قیمت" CssClass="form-control" runat="server"></AKP:ExTextBox>
                                                    </div>

                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                    <div class="form-inline">
                                                        <div class="Padder5">
                                                            مدت اعتبار
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:DropDownList ID="cboHCDurationCode" placeholder="اعتبار" CssClass="form-control" AllowNull="false" runat="server">
                                                                <asp:ListItem Text="یک هفته" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="یک ماه" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="دو ماه" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <AKP:ExTextBox ID="txtAddress" placeholder="آدرس" CssClass="form-control AdAddress" runat="server"></AKP:ExTextBox>
                                                </div>
                                            </div>
                                            <div class="Padder5">
                                                لینک آگهی (مبلغ نمایش لینک آگهی ٣۰۰۰ تومان میباشد)
                                            </div>
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <AKP:ExTextBox ID="txtLink" ClientIDMode="Static" placeholder="http://..." CssClass="form-control AdURL" runat="server"></AKP:ExTextBox>
                                                </div>
                                            </div>

                                            <asp:Panel runat="server" ID="pnlFileUpload" class="UploadCont">
                                                <div class="Padder5">
                                                    <asp:Label ID="Label13" runat="server" Text="عکس:"></asp:Label>
                                                </div>
                                                <div class="">
                                                    <asp:FileUpload ID="FileUpload1" ClientIDMode="Static" CssClass="file" runat="server" />
                                                </div>
                                                <script>
                                                    $("#FileUpload1").fileinput({
                                                        showUpload: false,
                                                        showCaption: false,
                                                        browseClass: "btn btn-primary btn-lg",
                                                        fileType: "any",
                                                        previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
                                                        language: 'fa',
                                                        uploadUrl: '#',
                                                        allowedFileExtensions: ['jpg', 'png', 'gif'],
                                                    });

                                                </script>
                                            </asp:Panel>
                                            <div>
                                            </div>
                                        </div>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel runat="server" ID="pnlUploadedImage" CssClass="text-center">

                                            <div class="Clear">
                                            </div>
                                            <div class="CropCont">
                                                <asp:Image ID="imgAdsPic" Visible="false" runat="server" />
                                            </div>
                                        </asp:Panel>
                                        <div class="Clear">
                                        </div>
                                        <asp:Panel runat="server" Visible="false" ID="pnlKeywordMessage" CssClass="cWarning">
                                            لطفا کلمات کلیدی پیشنهادی را مشاهده و در صورت نیاز تغییر دهید.
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlKeywords" Visible="false" CssClass="Win2">

                                            <div class="Clear" style="height: 30px;">
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="Win2Header">
                                                        <asp:Label ID="Label7" runat="server" Text="کلمات کلیدی"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:Repeater ID="rptKeywords" OnItemCommand="HandleRepeaterCommand" runat="server">
                                                            <ItemTemplate>
                                                                <div class="SingleKeyword">
                                                                    <div class="Right">
                                                                        <asp:LinkButton ID="btnDeleteKeyword" Text="حذف"
                                                                            CommandName="RemoveKeyword" runat="server">
                                                                <span class="fa fa-remove fa-20 Red"></span>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="Left">
                                                                        <%#Container.DataItem.ToString()%>
                                                                    </div>
                                                                </div>
                                                                <div class="Clear">
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <div class="Clear">
                                                    </div>
                                                    <div class="NewKeyword">
                                                        <table class="LTR">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnNewKeyword" OnClick="btnNewKeyword_Click" CssClass="btn btn-success" runat="server" Text="اضافه کردن کلمه کلیدی" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNewKeyword" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td class="Farsi">
                                                                    <asp:Label ID="Label11" runat="server" Text="کلمه کلیدی جدید:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="Clear">
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                        <div style="text-align: left; margin-top: 10px;">
                                            <%--                                        <asp:Button ID="btnEditAdsStep1" Text="اصلاح" CssClass="btn btn-danger" 
                                            runat="server" OnClick="btnEditAdsStep1_Click" />--%>
                                            <asp:Button ID="btnEditAds" CssClass="btn btn-warning btnLogins" Text="ذخیره تغییرات"
                                                runat="server" OnClick="btnEditAds_Click" />
                                            <%--<asp:Button ID="btnStep1" Visible="false" CssClass="btn btn-warning" Text="شروع ثبت" runat="server"
                                            OnClick="btnStep1_Click" />--%>
                                            <asp:Button ID="btnNewAds" CssClass="btn btn-success btnLogins" OnClientClick="this.style.visibility='hidden';" Text="ارسال"
                                                runat="server" OnClick="btnNewAds_Click" />
                                        </div>


                                    </div>
                                    <div class="Clear">
                                    </div>
                                </asp:Panel>
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnEditAds" />
                            <asp:PostBackTrigger ControlID="btnNewAds" />
                        </Triggers>

                    </asp:UpdatePanel>

                </asp:Panel>
                <br />
            </div>
        </div>
    </div>



</asp:Content>

