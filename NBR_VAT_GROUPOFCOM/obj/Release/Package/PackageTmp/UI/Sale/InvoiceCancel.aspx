<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Sale_Invoice, App_Web_otqqrkum" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<style type="text/css">
 #grid-view-container
 {
  height:auto;
  overflow:scroll;
  max-height:350px;
 }
 .hiddencol{
     display:none;
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <center>
                 <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
               Invoice Detail Information
               </div>
                     </div>    
            </center>
            
            <br>
            <asp:Literal ID="lt_confirmMessage" runat="server"></asp:Literal>
            <div id="grid-view-container">
            <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="false" DataKeyNames="challan_id"
                OnRowCommand="gvInvoice_RowCommand" OnSelectedIndexChanged="gvInvoice_SelectedIndexChanged" Width="100%" >
                <Columns>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbRowDelete" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("challan_id") %>'
                                 OnClientClick="return confirm('Are you sure you want to Delete The invoice?');"> <asp:Image ImageUrl="~/Images/cross.png" runat="server"/></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select">
                                <asp:Image  ImageUrl="~/Images/detail.png" runat="server"/> Detail
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Row ID" Visible="false" DataField="challan_id" />
                    <asp:BoundField HeaderText="Invoice NO" DataField="challan_no" />
                    <asp:BoundField HeaderText="Pary Name" DataField="party_name" />
                    <asp:BoundField HeaderText="Total Price" DataField="total_price" DataFormatString="{0:n2}"/>
                    <asp:BoundField HeaderText="Challan Date" DataField="date_challan" />
                    <asp:BoundField HeaderText="Delivery Date" DataField="date_goods_delivery" />
                </Columns>
                <SelectedRowStyle BackColor="BurlyWood" Font-Bold="true" />
            </asp:GridView>
            </div>
            <br>
           
            <asp:Literal ID="ltProductDetailInfo" runat="server"></asp:Literal>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
