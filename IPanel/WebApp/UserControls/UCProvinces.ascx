<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProvinces.ascx.cs" Inherits="Decili.UserControls.UCProvinces" %>
<div class="panel panel-default ">
    <div class="panel-heading ListTitle">
        <h3 class="panel-title BulletList">
            <asp:HyperLink ID="hplProvinces" NavigateUrl="~/Provinces.aspx" runat="server">استانها</asp:HyperLink>

        </h3>
    </div>
    <div class="Padder5 text-center">
        <asp:Repeater ID="rptProvinces" runat="server">
                    <HeaderTemplate>
                        <ul class="ProvincesCol">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink  NavigateUrl='<%#"~/?ProvinceCode=" + Eval("Code")  %>' runat="server"><%#Eval("Name") %></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>

                </asp:Repeater>
        <div class="clear">
        </div>
    </div>
</div>