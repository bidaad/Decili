<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PicLinks.ascx.cs" Inherits="IONS.UserControls.PicLinks" %>
<asp:HyperLink ID="hplUpperLink" Visible="false" runat="server"></asp:HyperLink>

<div >
<div class="Box1" >
    <div class="Box1Header" >
        <div class="Box1HeaderCaption">
            <asp:Label ID="ltrCaption" runat="server" Text="سایتهای مرتبط"></asp:Label></div>
    </div>
    <div class="Box1Content" style="background-color: White;<">
        <asp:Repeater ID="rptRandLinks" EnableViewState="false" runat="server">
            <ItemTemplate>
                <div class="LinkPic">
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%#Eval("Url") %>' Target="_blank" ToolTip='<%#Eval("Description") %>'>
                        <%#ShowPropItem(Eval("FileName"),Eval("Title")) %>
                        <%--<asp:Image runat="server" ImageUrl='<%#"~" + Eval("FileName") %>' Width="175" />--%>
                        </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clearfloat">
</div>
    </div>
</div>
</div>
<asp:HyperLink ID="hplBottomLink" runat="server"></asp:HyperLink>
<div class="clearfloat">
</div>
<asp:Panel runat="server" CssClass="btnEditModule" ID="pnlEdit" Visible="false">
    <asp:HyperLink ID="hplEdit" Target="_blank" runat="server">
        ویرایش
        <asp:Image ID="Image1" ImageUrl="~/Admin/images/icon_edit_item.gif" runat="server" />
    </asp:HyperLink>
</asp:Panel>
