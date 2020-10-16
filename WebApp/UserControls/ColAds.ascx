<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_ColAds" CodeBehind="ColAds.ascx.cs" %>

<div class="panel danger">
    <div class="heading" style="width: 99%; float: right;">
        <div>
            <asp:HyperLink ID="hplColHeader" runat="server"></asp:HyperLink>
        </div>
    </div>
    <div class="Clear"></div>
    <div class=" Padder5">
        <asp:Repeater EnableViewState="false" ID="dtlAds" runat="server">
            <ItemTemplate>
                <div class="adSmall">
                    <h3 class="text-center">
                        <asp:HyperLink  runat="server" NavigateUrl='<%#"~/Ads/" + Eval("ID") + ".html"  %>'>
                    <%#Eval("Title") %>
                        </asp:HyperLink>
                    </h3>
                    <div class="text-center">
                        <asp:HyperLink runat="server" NavigateUrl='<%#"~/Ads/" + Eval("ID") + ".html"  %>'>
                            <asp:Image ImageUrl='<%#"https://cdn.Decili.ir/Files/Ads/" +  DataBinder.Eval(Container.DataItem, "SmallPicFile")%>'
                                runat="server" />
                        </asp:HyperLink>
                        <div>
                                <%#ShowTel(Eval("Tel")) %>
                        </div>
                        <div>
                            نام :
                                <%#Eval("Name") %>
                        </div>
                    </div>


                </div>
                <div class="Clear">
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

