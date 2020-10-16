<%@ Page Language="C#" AutoEventWireup="true" Title="تماس با دسیلی" MasterPageFile="~/MainRoot.Master"
    CodeBehind="ContactUs.aspx.cs" Inherits="Decili.ContactUs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div id="contact" class="">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="تماس با ما"></asp:Label>
                </li>
            </ul>
        </div>
        <div class="InnerPage">
            <div class="title RTL RightAlign">
                <ul class="AboutUsItems" >
                    <li><span lang="FA">شنبه تا چهارشنبه ساعت 9 صبح تا 5 بعدازظهر</span><span> </span>
                    </li>
                    <li><span lang="FA">پنجشنبه ساعت 9 صبح تا 14 بعدازظهر</span><span> </span></li>
                    <li><span lang="FA">تلفن : ٢٦٧٠٣٨٥٢-٠٢١</span></li>
                    <li><span lang="FA">ایمیل : </span><a href="mailto:support@Decili.com"><span>support@Decili.ir</span></a><span>
                    </span></li>
                </ul>
                <div>
                    <span lang="FA">تهران، خیابان جمهوری، بین فخر رازی و 12 فروردین پاساژ تجارت
                        طبقه دوم اداری واحد 2402</span>
                </div>
                <%--<span lang="FA">فکس : 66476024-021</span>--%></div>
            <div class="Line1">
            </div>
        </div>
    </div>
    <div class="Clear">
    </div>
    <AKP:MsgBox runat="server" ID="msgBox" />
    <div class="panel panel-default Marginer20">
        <div class="panel-heading ListTitle">
            <h3 class="panel-title BulletList">
                تماس با ما</h3>
        </div>
        <div class="Padder5">
            <AKP:MsgBox runat="server" ID="msgMessage">
            </AKP:MsgBox>
            <asp:Panel runat="server" ID="pnlSend" CssClass="" >
                <div class="form-group ">
                    <asp:TextBox runat="server" ID="txtFullName"  placeholder="نام" CssClass="form-control" />
                    
                </div>
                <div class="form-group ">
                    <asp:TextBox ID="txtEmail" runat="server"  placeholder="ایمیل" CssClass="form-control LTR" />
                    
                </div>
                <div class="form-group ">
                    <asp:TextBox ID="txtComment" TextMode="MultiLine" Height="200"  runat="server"
                        placeholder="متن پیام" CssClass="form-control" />
                    
                </div>
                <div class=" ">
                    <div class="">
                        <telerik:RadCaptcha ID="RadCaptcha1" CssClass="Capt" CaptchaImage-ImageCssClass="CaptImg1"
                            CaptchaTextBoxCssClass="form-control" ValidationGroup="ValidateSend" runat="server"
                            ErrorMessage="" CaptchaTextBoxLabel="">
                        </telerik:RadCaptcha>
                    </div>
                    
                </div>
                <div style="margin-right: 380px;">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="ValidateSend"
                        OnClick="btnSend_Click" runat="server" Text="ارسال" />
                </div>
            </asp:Panel>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
