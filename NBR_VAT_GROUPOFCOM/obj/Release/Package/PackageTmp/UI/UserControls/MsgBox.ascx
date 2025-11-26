<%@ control language="C#" autoeventwireup="true" inherits="MsgBoxs, App_Web_nfyh4hej" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <asp:Button ID="btnD" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Button ID="btnD2" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Panel ID="pnlMsg" runat="server" CssClass="mpMsg" Style="width: auto;display:none;" >
            <asp:Panel ID="pnlMsgHD" runat="server" CssClass="table_title" Height="30px">
                &nbsp;Message
            </asp:Panel>
            <asp:GridView ID="grvMsg" runat="server" ShowHeader="false" Width="100%" AutoGenerateColumns="false" BackColor="LightGray">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgErr" runat="server" ImageUrl="~/Images/err.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Error) ? true : false %>' />
                                        <asp:Image ID="imgSuc" runat="server" ImageUrl="~/Images/suc.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Success) ? true : false %>' />
                                        <asp:Image ID="imgAtt" runat="server" ImageUrl="~/Images/att.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Attention) ? true : false %>' />
                                        <asp:Image ID="imgInf" runat="server" ImageUrl="~/Images/inf.png"
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
            <div class="mpClose">
                <asp:Button ID="btnOK" runat="server" Text="OK" CausesValidation="false" Width="60px" />
                <asp:Button ID="btnPostOK" runat="server" Text="OK" CausesValidation="false" OnClick="btnPostOK_Click" Visible="false" Width="60px" />
                <asp:Button ID="btnPostCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnPostCancel_Click" Visible="false" Width="60px" />
            </div>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mpeMsg" runat="server" TargetControlID="btnD"
            PopupControlID="pnlMsg" PopupDragHandleControlID="pnlMsgHD" BackgroundCssClass="mpBack" OkControlID="btnOK">
        </ajaxToolkit:ModalPopupExtender>
    </ContentTemplate>
</asp:UpdatePanel>
