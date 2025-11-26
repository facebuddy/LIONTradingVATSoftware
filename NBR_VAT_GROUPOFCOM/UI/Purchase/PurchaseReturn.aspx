<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Purchase_PurchaseReturn, App_Web_njc3mxew" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src="~/UserControls/Production.ascx" tagname="production" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
 function showTotalReturn(txtQty) {
        var jsDgvItem = document.getElementById("<%=dgvItem.ClientID%>");
        var rowCount = jsDgvItem.rows.length;
        var totalReturn = 0;
        for (var i = 1; i < rowCount; i++) {

            if (jsDgvItem.rows[i].cells[9].getElementsByTagName('input')[0].value != "") {
                var rowRetrun = parseFloat(jsDgvItem.rows[i].cells[9].getElementsByTagName('input')[0].value);
                totalReturn = totalReturn + rowRetrun;
            }

            var totalItemStock = jsDgvItem.rows[i].cells[8].getElementsByTagName('input')[0].value;
            var totalItemReturn=jsDgvItem.rows[i].cells[9].getElementsByTagName('input')[0].value;

            if (Number(totalItemStock) < Number(totalItemReturn)) {
                alert('মোট পণ্য ফেরতের পরিমাণ অবশ্যই মোট মজুদের চেয়ে কম হতে হবে। \n মোট মজুদের পরিমাণ ঃ ' + totalItemStock + ' মোট ফেরতের পরিমাণ ' + totalItemReturn);
                jsDgvItem.rows[i].cells[9].getElementsByTagName('input')[0].value = 0;
                jsDgvItem.rows[i].cells[9].getElementsByTagName('input')[0].focus();
            }
        }
        document.getElementById("<%=txtTotalReturn.ClientID%>").value = parseFloat(totalReturn).toFixed(2);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  
    <br />
<br />
<br />
    <div>
        <table align="center" class="brd_tbl_input" border="0px">
            <tr>
                <td class="page_title" colspan="4" align="center">
                    ক্রয় পণ্য ফেরত <uc1:production ID="production" runat="server" /></td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <asp:Label ID="lblBillofEntryNo" runat="server" 
                        Text="ব্যবসা প্রতিষ্ঠানের নাম :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrgName" runat="server" Width="170px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlOrgName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblPortFrom" runat="server" Text="করদাতা সনাক্তকরণ সংখ্যা :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOrgTin" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <asp:Label ID="lblPortCode" runat="server" Text="ঠিকানা :"></asp:Label>
                </td>
                <td rowspan="2" valign="top">
                    <asp:Label ID="lblOrgAddress" runat="server"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label ID="lblShipmentDate" runat="server" Text="টেলিফোন নং :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOrgPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" class="style1" align="right">
                    <asp:HiddenField ID="hfRowNo" runat="server" />
                    <asp:HiddenField ID="hfUnitId" runat="server" Visible="False" />
                </td>
                <td class="style1" align="right">
                    <asp:Label ID="lblPortTo" runat="server" Text="ফ্যাক্স নং :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOrgFax" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" class="style1" align="right" colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td valign="top" class="style1" align="right">
                    <asp:Label ID="lblLCNo" runat="server" Text="বিক্রেতার নাম :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSalePartyName" runat="server" AutoPostBack="True" 
                         Width="170px" 
                        onselectedindexchanged="ddlSalePartyName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="lblPortFrom0" runat="server" Text="করদাতা সনাক্তকরণ সংখ্যা :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPartyTin" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" class="style1" align="right">
                    <asp:Label ID="lblPortCode0" runat="server" Text="ঠিকানা :"></asp:Label>
                </td>
                <td valign="top">
                    <asp:Label ID="lblPartyAddress" runat="server"></asp:Label>
                </td>
                <td class="style1" align="right">
                    <asp:HiddenField ID="hfChallanId" runat="server" Visible="False" />
                    <asp:HiddenField ID="hfDetailID" runat="server" Visible="False" />
                </td>
                <td>
                    <asp:HiddenField ID="hfItemId" runat="server" Visible="False" />
                </td>
            </tr>
            <tr>
                <td valign="top" style="text-align: right" colspan="4">
                    <hr/>
                </td>
            </tr>
            <tr>
                <td valign="top" style="text-align: right">
                    <asp:Label ID="Label1" runat="server" 
                        Text="চালানপত্রের ক্রমিক সংখ্যা ও তারিখ :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlChallanNoDate" runat="server" Width="170px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlChallanNoDate_SelectedIndexChanged" 
                        style="height: 22px">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top" style="text-align: right">
                    <asp:Label ID="Label15" runat="server" 
                        Text="ফেরত চালানপত্রের ক্রমিক :"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtChallanNo" runat="server" Width="163px" 
                    CssClass="text_box"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Label16" runat="server" 
                        Text="ফেরত চালানপত্রের তারিখ :"></asp:Label>
                </td>
                <td>
                <ww:jQueryDatePicker ID="dtpDate" runat="server" Width="130px" 
                    DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                </td>
            </tr>
            <tr>
                <td valign="top" style="text-align: right" colspan="4">
                    <asp:GridView ID="dgvItem" runat="server" AutoGenerateColumns="False" 
                        onrowdatabound="dgvItem_RowDataBound" style="text-align: center">
                        <Columns>
                            <asp:BoundField DataField="item_name" HeaderText="পণ্যের নাম">
                            <ItemStyle CssClass="grid_row_style" />
                            </asp:BoundField>
                            <asp:BoundField DataField="quantity" HeaderText="পরিমাণ">
                            <ItemStyle CssClass="grid_row_style" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="একক মূল্য">
                                <ItemTemplate>
                                    <asp:Label ID="lblActualPrice" runat="server" 
                                        Text='<%# Bind("actual_price") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("actual_price") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle CssClass="grid_row_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="এস, ডি,">
                                <ItemTemplate>
                                    <asp:Label ID="lblSD" runat="server" Text='<%# Bind("sd") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("sd") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle CssClass="grid_row_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ভ্যাট">
                                <ItemTemplate>
                                    <asp:Label ID="lblVAT" runat="server" Text='<%# Bind("vat") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("vat") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle CssClass="grid_row_style" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="total_price" HeaderText="মোট মূল্য">
                            <ItemStyle CssClass="grid_row_style" />
                            </asp:BoundField>
                            <asp:BoundField DataField="purchase_qty" HeaderText="মোট ক্রয়">
                            <ItemStyle CssClass="grid_row_style" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sale_qty" HeaderText="মোট বিক্রয়">
                            <ItemStyle CssClass="grid_row_style" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="মজুদ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStock" runat="server" BackColor="Transparent" 
                                        ReadOnly="True" style="text-align: center" Text='<%# Bind("stock_qty") %>' 
                                        Width="60px"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStock" runat="server" Enabled="False" 
                                        Text='<%# Bind("stock_qty") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle CssClass="grid_row_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ফেরতের পরিমাণ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" runat="server" Width="80px" onblur="showTotalReturn(this)">0.00</asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="grid_row_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ফেরত এস, ডি,">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSD" runat="server" Width="80px">0.00</asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="grid_row_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ফেরত ভ্যাট">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVAT" runat="server" Width="80px">0.00</asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="grid_row_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lot No" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblLotNo" runat="server" Text='<%# Bind("lot_no") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("lot_no") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("item_id") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("item_id") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitId" runat="server" Text='<%# Bind("unit_id") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("unit_id") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetailId" runat="server" Text='<%# Bind("detail_id") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("detail_id") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td valign="top" style="text-align: right">
                    <asp:Label ID="Label14" runat="server" Text="পণ্য ফেরতের কারণ :"></asp:Label>
                </td>
                <td valign="bottom" align="left">
                    <asp:TextBox ID="txtRemark" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td valign="top" align="left">
                    <asp:Label ID="Label17" runat="server" Text="মোট পণ্য ফেরতের পরিমাণ :"></asp:Label>
                </td>
                <td valign="top" align="left">
                <asp:TextBox ID="txtTotalReturn" runat="server" Width="75px" 
                    CssClass="text_box" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="right" colspan="3">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Button ID="btnRefresh" runat="server" CssClass="button" 
                            Text="Refresh" onclick="btnRefresh_Click" />
                        <asp:Button ID="btnSave" runat="server" CssClass="button" 
                            Text="Save" onclick="btnSave_Click"
                             />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
        </table>
    </div>

    <uc2:Msgbox ID="msgBox" runat="server" />
</asp:Content>

