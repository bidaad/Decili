<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCities.ascx.cs" Inherits="Decili.UserControls.UCCities" %>
<div class="panel panel-default  ">
    <div class="panel-heading ListTitle">
        <h3 class="panel-title BulletList">
            <asp:Literal ID="ltrHeader" runat="server"></asp:Literal>
        </h3>
    </div>
    <div class="Padder5 text-center">
        <div class="SmallCities Padder5">
        <asp:Repeater ID="rptCities" runat="server">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-lg-6 col-md-6 col-sm-4 col-xs-6 text-left">
                    <asp:HyperLink NavigateUrl='<%#"~/Cities/" + Eval("Code") + ".html" %>' runat="server"><%#Eval("Name") %></asp:HyperLink>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        </div>
        
    </div>
</div>
