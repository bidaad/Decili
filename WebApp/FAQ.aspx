<%@ Page Language="C#" AutoEventWireup="true" Title="دسیلی :: سوالات متداول" MasterPageFile="~/MainRoot.Master"
    CodeBehind="FAQ.aspx.cs" Inherits="Decili.FAQ" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <script>
        $(document).ready(function () {

            $('.FAQ li').click(function (e) {  // inserted callback param "e" meaning "event"
                e.stopPropagation(); // stop click from bubbling up
                $(this).children('.Answer').slideToggle('slow');
            });
        });
    </script>
    <asp:Panel ID="pnlScrollToItem" runat="server">

    <script>
        $(document).ready(function () {
            $('html, body').animate({
                scrollTop: $("#Ques<%=strCode %>").offset().top
            }, 2000);

        });
    </script>
    </asp:Panel>

    <div class="Hierarchy">
        <ul class="mnuHierarchy">
            <li class="IcHome">
                <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
            </li>
            <li class="Sep">&nbsp; </li>
            <li>
                <asp:Label ID="Label1" runat="server" Text="سوالات متداول"></asp:Label>
            </li>
        </ul>
    </div>
    <div class="Clear"></div>
    <div class="RTL RightAlign Marginer20" style="width:97%;">
        <ul class="FAQ">
            <asp:Repeater ID="rptFAQs" runat="server" 
                onitemdatabound="rptFAQs_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <div id="Ques<%#Counter %>" class="Question">
                            <%#Tools.ChangeEnc(Counter.ToString()) %>&nbsp;-
                            <%#Eval("Question") %>
                        </div>
                        <div class="Answer">
                            <%#Eval("Answer") %>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>


</asp:Content>
