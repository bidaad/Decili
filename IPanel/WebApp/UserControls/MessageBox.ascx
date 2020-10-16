<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_MessageBox" Codebehind="MessageBox.ascx.cs" %>
<div class="Padder1">
<asp:Panel runat="server" EnableViewState="false" Width="100%" ID="pnlMessage" CssClass="cError"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></asp:Panel>
</div>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>