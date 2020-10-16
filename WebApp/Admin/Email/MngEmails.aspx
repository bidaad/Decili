<%@ Page Language="C#" MasterPageFile="~/Admin/Main.master" StylesheetTheme="Edit" ValidateRequest="false" AutoEventWireup="True" CodeBehind="MngEmails.aspx.cs" Inherits="Decili.Admin.Email.MngEmails" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
    <div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox">
            </AKA:MsgBox>
        </div>
        
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtEmailContent" TextMode="MultiLine" Width="300" Height="400" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="Label1" runat="server" Text="متن ایمیل:"></asp:Label>
                                </td>
                            </tr>
                           
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtEmailCount" Text="2000" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblTitle" runat="server" Text="تعداد ایمیل:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="cFieldRight">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>

    </div>
    <div class="cHorSep">
    </div>
    
    <div style="text-align: right">
        <table cellpadding="2" cellspacing="4">
            <tr>
                
                <td>
                    <asp:LinkButton ID="imgBtnBack" Text=" بازگشت " SkinID="BackButton" 
                        runat="server" />
                </td>
                <td class="cVerBar1">
                </td>
                <td>
                    <asp:LinkButton ID="imgBtnSave" Text=" ارسال ایمیل " SkinID="SaveButton" 
                        runat="server" onclick="imgBtnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
