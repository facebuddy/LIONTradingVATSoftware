<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="APIPurchase, App_Web_1kre2rwf" %>
<%@Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="False"
                            CssClass="sGrid" DataKeyNames="challan_id" Width="100%" Style="width: 97%; margin-left: 15px" OnSelectedIndexChanged="gvPurchase_SelectedIndexChanged"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                            <Columns>
                                                              
                                <asp:BoundField HeaderText="Challan Date" DataField="date_challan" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                                <asp:BoundField HeaderText="Item Name" DataField="item_name" />                               
                                <asp:BoundField HeaderText="Unit" DataField="unit_code" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Quantiy" DataField="quantity" />
                                <asp:BoundField HeaderText="Unit Price" DataField="purchase_unit_price" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Price" DataField="Price" DataFormatString="{0:n}"  ItemStyle-HorizontalAlign="Right"/>
                                <asp:BoundField DataField="purchase_vat" HeaderText="VAT" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="SD" DataField="purchase_sd" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right"/>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/suc.png" ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right"/>
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
    <asp:Panel ID="pnYesNoModal" runat="server" Width="350" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
   
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">  
                <b><asp:Label ID="lblMessage" runat="server" ></asp:Label></b>                         
                
                <div class="clearfix"></div>

            </div>
           <div class="panel-body">
               <div style="text-align:center">
                    <asp:Button ID="btnOK" runat="server" Text="OK" class="button_sub" Width="60px" OnClick="btnOkToReload" />                    
                </div>
           </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnHideButton" runat="server" Text="Close" CssClass="hide"  />
    
    <ajaxToolkit:ModalPopupExtender ID="mpeYesNoModal" runat="server" 
        PopupControlID="pnYesNoModal" TargetControlID="btnHideButton" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>
    <uc2:MsgBox ID="msgBox" runat="server" OnClick="btnOkToReload" />

</asp:Content>