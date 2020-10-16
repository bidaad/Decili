<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserRoot.Master" Title="پروفایل کاربر" CodeBehind="Profile.aspx.cs" Inherits="Decili.UsersFolder.Profile" %>

<%@ Register Src="~/UserControls/UCUserMenu.ascx" TagName="UCUserMenu" TagPrefix="UC" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="Hierarchy">
        <ul class="mnuHierarchy">
            <li class="IcHome">
                <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
            </li>
            <li class="Sep">&nbsp; </li>
            <li>
                <asp:Label ID="Label1" runat="server" Text="ویرایش اطلاعات شخصی"></asp:Label>
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

                    <div class="">
                        <div class="form-group ">
                            <asp:DropDownList ID="cboGenderCode" DataTextField="Name" DataValueField="Code" CssClass="form-control"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group ">
                            <asp:TextBox runat="server" ID="txtFirstName" placeholder="نام" CssClass="form-control" />
                        </div>
                        <div class="form-group ">
                            <asp:TextBox ID="txtLastName" runat="server" placeholder="نام خانوادگی" CssClass="form-control" />
                        </div>
                        <div class="form-group ">
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="ایمیل" CssClass="form-control LTR Email" />
                        </div>
                        <div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="cReq"
                                ValidationGroup="ValidateRegister" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="txtEmail" ErrorMessage="ایمیل معتبر نیست"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group ">
                            <asp:TextBox ID="txtPassword" runat="server" SkinID="English" TextMode="Password"
                                placeholder="کلمه عبور" CssClass="form-control LTR Password" />
                        </div>
                        <div class="form-group  Relative">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" SkinID="English" TextMode="Password"
                                placeholder="تکرار کلمه عبور" CssClass="form-control LTR Password" />
                            <span onmouseup="hidePass($(this))" onmousedown="showPass($(this))" class="viewpass">
                                <img src="../images/viewpassword.png"></span>
                        </div>
                        <div style="margin-right: 200px;">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="ValidateRegister"
                                runat="server" Text="ثبت تغییرات" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>


                <div class="Clear">
                </div>
                <br />
            </div>
        </div>
    </div>



</asp:Content>
