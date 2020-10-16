<%@ Page Language="C#" AutoEventWireup="true" Title=" دسیلی :: عضویت" MasterPageFile="~/MainRoot.Master"
    CodeBehind="Register.aspx.cs" Inherits="Decili.UsersFolder.Register" %>

<%@ Register Src="~/UserControls/UCRegister.ascx" TagName="UCRegister" TagPrefix="Reg" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="Hierarchy">
        <ul class="mnuHierarchy">
            <li class="IcHome">
                <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
            </li>
            <li class="Sep">&nbsp; </li>
            <li>
                <asp:Label ID="Label1" runat="server" Text="عضویت"></asp:Label>
            </li>
        </ul>
    </div>
    <div class="clearfix">
    </div>
    <h1 class="PageTitle text-center">
        <asp:Image ID="Image1" ImageUrl="~/images/register_icon.png" ToolTip="عضویت در دسیلی"
            runat="server" />
    </h1>
    <div class="row container">
        <div class="col-md-6 col-xs-6 col-sm-6 hidden-xs">
            <asp:Panel ID="pnlKeywords" CssClass="WinRadiusGray" runat="server">
                <div class="BlueHeader">
                    چند نکته هنگام ثبت نام
                </div>
                <div class="Clear">
                </div>
                <div class="Marginer10">
                    <ul class="RegNotes">
                        <li><span class="fa fa-chevron-left Gray"></span>&nbsp;ایمیل درج شده همان نام کاربری شما در سایت خواهد بود 
                        </li>
                        <li><span class="fa fa-chevron-left Gray"></span>&nbsp;کلیه مکاتبات سایت دسیلی از طریق ایمیل درج شده خواهد بود 
                        </li>
                        <li><span class="fa fa-chevron-left Gray"></span>&nbsp;هنگام درج رمز عبور به فارسی و یا انگلیسی بودن صفحه کلید دقت نمایید</li>
                        <li><span class="fa fa-chevron-left Gray"></span>&nbsp;پس از ثبت نام جهت ویرایش مشخصات فوق می توانید بعد از ورود به حساب کاربری از منوی سمت راست گزینه "اطلاعات کاربری" را انتخاب نمایید 
                    

                        </li>
                    </ul>
                </div>
            </asp:Panel>

            <asp:Panel ID="Panel1" CssClass="WinRadiusGray" runat="server">
                <div class="BlueHeader">
                    مزایای ثبت نام در دسیلی
                </div>
                <div class="Clear">
                </div>
                <div class="Marginer10">
                    <ul class="RegNotes">
                        <li><span class="fa fa-chevron-left Gray"></span>&nbsp;درج آگهی رایگان و ویژه 
                        </li>
                        <li><span class="fa fa-chevron-left Gray"></span>&nbsp;مشاهده پیام های رسیده از سوی بازدید کنندگان در مورد آگهی های ثبت شده شما 
                        </li>
                        <li><span class="fa fa-chevron-left Gray"></span>&nbsp;تولید خودکار کلمات کلیدی آگهی شما</li>
                        
                    </ul>
                </div>
            </asp:Panel>

        </div>
        <div class="col-md-6 col-xs-12 col-sm-6 container">
            <Reg:UCRegister runat="server" ID="UCRegister1" />

        </div>
    </div>


    <br />
</asp:Content>
