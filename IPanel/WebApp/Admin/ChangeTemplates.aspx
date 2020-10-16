<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" Inherits="Admin_ChangeTemplates" Codebehind="ChangeTemplates.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlTemplates" AutoPostBack="true" runat="server" 
            onselectedindexchanged="ddlTemplates_SelectedIndexChanged">
            <asp:ListItem Value="1" Text="SellFactor"></asp:ListItem>
            <asp:ListItem Value="2" Text="Recommend"></asp:ListItem>
            <asp:ListItem Value="3" Text="ProductComment"></asp:ListItem>
            <asp:ListItem Value="4" Text="RecommendProduct"></asp:ListItem>
            <asp:ListItem Value="5" Text="SuggestSite"></asp:ListItem>
            <asp:ListItem Value="6" Text="AdActivation"></asp:ListItem>
            <asp:ListItem Value="7" Text="SuggestProduct"></asp:ListItem>
            <asp:ListItem Value="14" Text="DeciliUserRegister"></asp:ListItem>
            <asp:ListItem Value="15" Text="DeciliForgotPassword"></asp:ListItem>
            
            
        </asp:DropDownList>
    </div>
    <div>
        <asp:TextBox ID="txtTemplate" TextMode="MultiLine" Rows="20" Width="600" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    </div>
    </form>
</body>
</html>
