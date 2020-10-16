<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeyGenTester.aspx.cs" Inherits="Decili.Admin.KeyGenTester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtStr" TextMode="MultiLine" Width="600" Height="400" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnGen" runat="server" Text="Gen" OnClick="btnGen_Click" />

        </div>
        <div>
            <asp:Repeater ID="rptKeywords" runat="server">
                <ItemTemplate>
                    <div class="SingleKeyword">

                        <div class="Left">
                            <%#Container.DataItem.ToString()%>
                        </div>
                    </div>
                    <div class="Clear">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
