

<%@ control language="C#" autoeventwireup="true" CodeBehind="MsgBoxs.ascx.cs" Inherits="NBR_VAT_GROUPOFCOM.UserControls.MsgBoxs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link rel="stylesheet" type="text/css" href='<%= this.ResolveClientUrl("~/Styles/Box_Border.css") %>' />
<link rel="stylesheet" type="text/css" href='<%= this.ResolveClientUrl("~/Styles/Main.css") %>' />

<asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <asp:Button ID="btnD" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Button ID="btnD2" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Panel ID="pnlMsg" runat="server" CssClass="brd_error_msg" BorderColor="#53f153" BorderWidth="3px"
            Style="width: auto;display:block;" >
            <div class="brd_error_msg_div">
            <asp:Panel ID="pnlMsgHD" runat="server" CssClass="brd_error_msg_header">
                &nbsp;Message
            </asp:Panel>
               
            <asp:GridView ID="grvMsg" runat="server" ShowHeader="false" Width="100%"  Font-Bold="true" ForeColor="#0066cc"
                AutoGenerateColumns="false" EnableTheming="False" GridLines="None" 
                    CssClass="brd_error_msg_body" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgErr" runat="server" ImageUrl="~/Images/cross.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Error) ? true : false %>' />
                                        <asp:Image ID="imgSuc" runat="server" ImageUrl="~/Images/accept.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Success) ? true : false %>' />
                                        <asp:Image ID="imgAtt" runat="server" ImageUrl="~/Images/attention.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Attention) ? true : false %>' />
                                        <asp:Image ID="imgInf" runat="server" ImageUrl="~/Images/information.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Info) ? true : false %>' />
                                    </td>
                                    <td>
                                        <%# Eval("MessageText")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
             
            </asp:GridView>
            <div class="brd_error_msg_footer">
                <asp:Button ID="btnOK" runat="server" Text="OK" CausesValidation="false" 
                    Width="60px" CssClass="button_sub" />
                <asp:Button ID="btnPostOK" runat="server" Text="OK" CausesValidation="false" 
                    OnClick="btnPostOK_Click" Visible="false" Width="60px" CssClass="button_sub" />
                <asp:Button ID="btnPostCancel" runat="server" Text="Cancel" 
                    CausesValidation="false" OnClick="btnPostCancel_Click" Visible="false" 
                    Width="60px" CssClass="button_sub" />
            </div>
        </asp:Panel>
        </div>
        <ajaxToolkit:ModalPopupExtender ID="mpeMsg" runat="server" TargetControlID="btnD"
            PopupControlID="pnlMsg" PopupDragHandleControlID="pnlMsgHD" BackgroundCssClass="mpBack"  OkControlID="btnOK">
        </ajaxToolkit:ModalPopupExtender>
    </ContentTemplate>
</asp:UpdatePanel>
