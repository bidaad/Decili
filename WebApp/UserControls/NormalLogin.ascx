<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NormalLogin.ascx.cs"
    Inherits="IONS.UserControls.NormalLogin" %>
<div class="panel panel-default ">
    <div class="panel-heading ListTitle">
        <h3 class="panel-title BulletList">
            ورود به حساب کاربری</h3>
    </div>
    <div class="Padder5 text-center">
        <AKP:MsgBox runat="server" ID="msgMessage">
        </AKP:MsgBox>
        <div class="">
            <div class="form-group ">
                <asp:TextBox ID="txtEmail" runat="server" placeholder="ایمیل" CssClass="form-control LTR Email" />
            </div>
            <div class="form-group PassCont ">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="کلمه عبور"
                    CssClass="form-control LTR Password" />
                <span onmouseup="hidePass($(this))" onmousedown="showPass($(this))" class="viewpass">
                    <img alt="مشاهده کلمه عبور" src="../images/viewpassword.png"></span>
            </div>
            <div>
                به خاطر بسپار
                <asp:CheckBox ID="chkRemember" Enabled="true" runat="server" />
            </div>
            <div style="margin-right: 0px; margin-top: 5px;">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary  btnLogins" runat="server" Text="ورود"
                    OnClick="btnSubmit_Click" />
            </div>
            <div style="margin-right: 0px; margin-top: 5px;">
                <asp:Button ID="btnReg" CssClass="btn btn-info btnLogins" runat="server" Text="عضویت"
                    OnClick="btnReg_Click" />
            </div>
            <div class="form-group RegField ">
                <asp:HyperLink ID="HyperLink1" NavigateUrl="http://ipanel.decili.ir/Users/ForgotPassword.aspx" runat="server">رمز عبور را فراموش کرده ام</asp:HyperLink>
            </div>
            <div class="Clear">
            </div>
            
        </div>
        <div class="clear">
        </div>
    </div>
</div>
