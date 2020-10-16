<%@ Page Language="C#" AutoEventWireup="true" Inherits="MemberLogin" Codebehind="MemberLogin.aspx.cs" %>
<%@ Register Src="~/UserControls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link1" runat="server" href="~/styles/main.css" rel="stylesheet" type="text/css" />
    <title>ورود به سیستم</title>
    <style>
        .cPersianContent
        {
            font-family: Tahoma;
            font-size: 8pt;
            direction: rtl;
        }
        table.ctblLogin td
        {
            font-family: Tahoma;
            font-size: 8pt;
        }
    </style>
</head>
<body onload="document.getElementById('Login1_txtUsername').focus();">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align: center">
        <div class="cLoginBox">
            <uc1:Login ID="Login1" Mode="AdminUser" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
