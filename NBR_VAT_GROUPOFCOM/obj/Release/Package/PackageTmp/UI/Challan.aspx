<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Challan, App_Web_3zc1d3oi" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%--<%@ Register src="../UserControls/Purchase.ascx" tagname="purchase" tagprefix="uc1" %>--%>
<%@ Register Src="~/UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1 {
            height: 20px;
        }

        .style2 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:UpdateProgress ID="UpdateProgress" runat="server">
<ProgressTemplate>
    <div class="div_loading">
        <asp:Image ID="Image1" ImageUrl="~/Images/waiting.gif" AlternateText="Processing..." runat="server" />
    </div>
</ProgressTemplate>
</asp:UpdateProgress>

<ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />--%>
    <asp:UpdatePanel ID="updatePanelchallan" runat="server">
        <%-- <Triggers>        
    <asp:PostBackTrigger ControlID="btnAdd" />
    
</Triggers>--%>
        <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input"
                border="0px">
                <tr>
                    <td class="page_title" colspan="5" align="center">Purchase Challan
                        <uc1:production ID="production" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        <asp:Label ID="Label5" runat="server" Text="Organization Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:Literal ID="lt_companyName" runat="server"></asp:Literal>

                    </td>
                    <td align="right" colspan="2">
                        <asp:Label ID="Label8" runat="server" Text="BIN :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                        <asp:Label ID="Label56" runat="server" Text="Unit :" Visible="False"></asp:Label>
                        <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right" class="style1">&nbsp;
                    </td>
                    <td class="style1">
                        <asp:Label ID="lblOrgName" runat="server" Text="Technohaven Co Ltd" Visible="False"></asp:Label>
                    </td>
                    <td align="right" colspan="2" class="style1">&nbsp;
                    </td>
                    <td class="style1">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right" class="style2">
                        <asp:Label ID="Label30" runat="server" Text="Challan No :"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtChallanNo" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td align="right" colspan="2" class="style2">
                        <asp:Label ID="Label6" runat="server" Text="Address :"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Label ID="lblOrgAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right" style="display: none">
                        <asp:Label ID="Label29" runat="server" Text="Challan Type :" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdoPurchase" runat="server" Checked="True" GroupName="ChallanType"
                            Text="Purchase" Visible="False" />
                        <asp:RadioButton ID="rdoSale" runat="server" GroupName="ChallanType" Text="Sale"
                            Visible="False" />
                    </td>
                    <td align="right" colspan="2">
                        <asp:Label ID="Label31" runat="server" Text="Transaction Type :" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdoLocal" runat="server" Checked="True" GroupName="TransactionType"
                            Text="Local" Visible="False" />
                        <asp:RadioButton ID="rdoImport" runat="server" GroupName="TransactionType" Text="Import"
                            Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        <asp:Label ID="Label32" runat="server" Text="Challan Date Time:"></asp:Label>
                    </td>
                    <td>
                        <ww:jQueryDatePicker ID="txtChallanDate" runat="server" Width="80px" DateFormat="dd/MM/yyyy"
                            AutoPostBack="True" OnTextChanged="txtChallanDate_TextChanged"></ww:jQueryDatePicker>
                        <asp:DropDownList ID="drpChDtHr" runat="server" Width="45px" AutoPostBack="True"
                            OnSelectedIndexChanged="drpChDtHr_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpChDtMin" runat="server" Width="45px" AutoPostBack="True"
                            OnSelectedIndexChanged="drpChDtMin_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" colspan="2">
                        <asp:Label ID="Label33" runat="server" Text="Delivery Date :"></asp:Label>
                    </td>
                    <td>
                        <ww:jQueryDatePicker ID="txtDeliveryDate" runat="server" Width="80px" DateFormat="dd/MM/yyyy"
                            OnTextChanged="txtDeliveryDate_TextChanged" AutoPostBack="True"></ww:jQueryDatePicker>
                        <asp:DropDownList ID="drpDlDtHr" runat="server" Width="45px" AutoPostBack="True"
                            OnSelectedIndexChanged="drpDlDtHr_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpDlDtMin" runat="server" Width="45px" AutoPostBack="True"
                            OnSelectedIndexChanged="drpDlDtMin_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left" colspan="2">
                        <asp:Label ID="lblChDtInWords" runat="server"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label ID="lblDelDtInWords" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        <asp:Label ID="Label1" runat="server" Text="Party Name :"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpParty" runat="server" Width="150px" AutoPostBack="True"
                            OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Button ID="btnAddParty" runat="server" CssClass="button_sub" OnClick="btnAddParty_Click"
                            Text="New" Width="50px" />
                        <br />
                        <asp:TextBox ID="txtPartyName" runat="server" Visible="False" Width="200px"></asp:TextBox>
                    </td>
                    <td align="right" colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="Party BIN :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPartyBIN" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="style1" align="right">
                        <asp:Label ID="Label2" runat="server" Text="Party Address :"></asp:Label>
                    </td>
                    <td class="style1" colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" Rows="2" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                    <td align="right" valign="top">
                        <asp:Label ID="Label34" runat="server" Text="Ultimate Destination :"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtDestination" runat="server" Rows="2" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="style1" align="right">
                        <asp:Label ID="Label27" runat="server" Text="Vehicle Type :"></asp:Label>
                    </td>
                    <td class="style1" colspan="2">
                        <asp:DropDownList ID="drpVehicleType" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label35" runat="server" Text="Vehicle No :"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtVehicleNo" runat="server" Width="200px" CssClass="text_box"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td valign="top" class="style1" align="right">
                        <asp:Label ID="Label7" runat="server" Text="Remarks :"></asp:Label>
                    </td>
                    <td class="style1" colspan="4">
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="text_box" Width="588px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1" valign="top" colspan="5">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table align="center" class="brd_tbl_input">
                            <tr>
                                <td></td>
                                <td></td>
                                <td colspan='3'>
                                    <%--Auto Complete--%>
                                    <asp:TextBox ID="productName" AutoPostBack="true" Width="280px" placeholder="Search Product" runat="server" OnTextChanged="productName_TextChanged"></asp:TextBox>
                                    <!-- Auto complete Product name search-->
                                    <ajaxToolkit:AutoCompleteExtender runat="server" ID="accProductName" TargetControlID="productName"
                                        ServiceMethod="GetProductByProductName" ServicePath="~/WebService.asmx" MinimumPrefixLength="1"
                                        CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                        DelimiterCharacters=";, :" ShowOnlyCurrentWordInCompletionListItem="true">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <%--End Auto Complete--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Category :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label51" runat="server" Text="Sub Category :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Item Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label54" runat="server" Text="HS Code :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Quantity :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Unit Price :"></asp:Label>
                                </td>
                                <td> <asp:Label ID="Label12" runat="server" Text="Sale Price :"></asp:Label></td>

                                <td rowspan="4">
                                    <table style="background: #fff; box-shadow: 4px 11px 7px #888888;">
                                        <tr>
                                            <td align="right" style="width: 100px;">
                                                <asp:Label ID="Label57" runat="server" Font-Bold="True" Text="Total Price :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="SD Amount :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalSD" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="VAT Amount :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalVAT" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label58" runat="server" Font-Bold="True" Text="Total Purchase Price :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalPurchsPrc" runat="server" Width="90px" AutoPostBack="True"
                                                    OnTextChanged="txtTotalPurchsPrc_TextChanged" TabIndex="6"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>


                            </tr>

                            <tr>

                                <td class="zero-padding-top">
                                    <asp:DropDownList ID="drpCategory" runat="server" Width="100px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                        AutoPostBack="True" TabIndex="1">
                                    </asp:DropDownList>
                                </td>

                                <td class="zero-padding-top">
                                    <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                                        Width="100px" TabIndex="2">
                                    </asp:DropDownList>
                                </td>

                                <td class="zero-padding-top">
                                    <asp:DropDownList ID="drpItem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged"
                                        Width="100px" TabIndex="3">
                                    </asp:DropDownList>
                                </td>

                                <td class="zero-padding-top">
                                    <asp:Label ID="lblHSCode" runat="server" BorderStyle="Solid" BorderWidth="1px" Text="."
                                        Height="17px"></asp:Label>
                                    <asp:Label ID="lblExempted" runat="server" Font-Size="Smaller" Text=" (Exempted)"
                                        Visible="False"></asp:Label>
                                </td>

                                <td class="zero-padding-top">
                                    <asp:TextBox ID="txtQuantity" runat="server" Width="90px" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"
                                        TabIndex="4"></asp:TextBox>
                                    <asp:Label ID="lblUnit" runat="server" Font-Bold="True" Font-Size="Smaller" Text="Unit "
                                        Width="30px"></asp:Label>
                                </td>

                                <td class="zero-padding-top">
                                    <asp:Label ID="lblUnitPrice" runat="server" Text="0.00" Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtUnitPrice" runat="server" Width="90px" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged"
                                        TabIndex="5"></asp:TextBox>
                                </td>
                                 <td class="zero-padding-top">                                   
                                    <asp:TextBox ID="txtSalePrice" runat="server" Width="90px" AutoPostBack="True"
                                        TabIndex="5"></asp:TextBox>
                                </td>

                                <td align="left" class="style5" style="width: 10px">
                                    <asp:Label ID="lblProp4" runat="server" Text="Property 4" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 10px">
                                    <asp:DropDownList ID="drpProp4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp4_SelectedIndexChanged"
                                        Visible="False" Width="100px">
                                    </asp:DropDownList>
                                </td>


                            </tr>
                            <tr>

                                <td class="style8">
                                    <asp:CheckBox ID="chkTaxDeducted" runat="server" Text="VAT Deducted at Source" OnCheckedChanged="chkTaxDeducted_CheckedChanged" Visible="false" />
                                </td>

                                <td class="style9">
                                    <asp:CheckBox ID="chkRebatable" runat="server" Text="Rebatable" />
                                </td>
                                <td class="style5" align="right">
                                    <asp:Label ID="Label52" runat="server" Text="SD(%) :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSDRate" runat="server" Text="0.00"></asp:Label>
                                </td>
                                <td align="right" class="style5">
                                    <asp:Label ID="Label53" runat="server" Text="VAT(%) :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVATRate" runat="server" Text="0.00"></asp:Label>
                                </td>


                                <td class="style6" align="right" style="width: 10px">
                                    <asp:Label ID="lblProp1" runat="server" Text="Property 1:" Visible="False"></asp:Label>
                                </td>
                                <td class="style7" style="width: 10px">
                                    <asp:DropDownList ID="drpProp1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp1_SelectedIndexChanged"
                                        Visible="False" Width="100px">
                                    </asp:DropDownList>
                                </td>

                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblProp5" runat="server" Text="Property 5" Visible="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpProp5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"
                                        Visible="False" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblProp3" runat="server" Text="Property 3" Visible="False"></asp:Label>
                                </td>
                                <td align="center" class="style3">
                                    <asp:DropDownList ID="drpProp3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp3_SelectedIndexChanged"
                                        Visible="False" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td align="center" class="style5">
                                    <asp:Label ID="lblProp2" runat="server" Text="Property 2" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpProp2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp2_SelectedIndexChanged"
                                        Visible="False" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="Remarks :"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtRemarksDetail" runat="server" CssClass="text_box" Width="100%"
                                        TabIndex="7"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:HiddenField ID="hdUnitID" runat="server" />

                                    <asp:Button ID="ClientButton" runat="server" Text="Payment Information" CssClass="button"
                                        Height="30px" />
                                    <asp:Panel ID="ModalPanel" runat="server" Width="800px" CssClass="modal_custom">
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                    <h2>Check your Payment Information:</h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkCash" runat="server" Text="Cash" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkPayOrder" runat="server" Text="Pay Order" AutoPostBack="true"
                                                        OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkBkash" runat="server" Text="bKash" AutoPostBack="true" OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkRocket" runat="server" Text="Rocket (DBBL Mobile)" AutoPostBack="true"
                                                        OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkCheque" runat="server" Text="Cheque" AutoPostBack="true" OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkTT" runat="server" Text="Telephone Transfer" AutoPostBack="true"
                                                        OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkEFT" runat="server" Text="Electronic Fund Transfer" AutoPostBack="true"
                                                        OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheDebitCard" runat="server" Text="Debit Card" AutoPostBack="true"
                                                        OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkTR" runat="server" Text="Treasury Challan" AutoPostBack="true"
                                                        OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ChkOther" runat="server" Text="Other" AutoPostBack="true" OnCheckedChanged="payment_CheckedChanged" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="lbl_transaction_id" Visible="false" runat="server" Text="Payment information(eg: Transaction Id, Mobile No,Check No,Bank Name, Challan No etc)"></asp:Label></b>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_transaction_id" Visible="false" Width="500px" TextMode="MultiLine"
                                                        Rows="2" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="OKButton" runat="server" CssClass="button" Text="OK" Width="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton"
                                        BackgroundCssClass="modalPopup" PopupControlID="ModalPanel" OkControlID="OKButton" />
                                </td>
                                <td align="right" colspan="4">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="button_sub" Text="Add Item" OnClick="btnAddItem_Click" />
                                        <asp:Button ID="btnClear" runat="server" CssClass="button_sub" Text="Clear" OnClick="btnClear_Click" />
                                    </asp:Panel>
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdPriceID" runat="server" />
                    </td>
                    <td align="right" colspan="4">
                        <asp:HiddenField ID="hdIsExempted" runat="server" />
                        <asp:HiddenField ID="hdItemType" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                            DataKeyNames="ItemID,RowNo" Width="100%" OnSelectedIndexChanged="gvItem_SelectedIndexChanged"
                            OnPreRender="gvItem_PreRender" OnRowDataBound="gvItem_RowDataBound" OnRowDeleting="gvItem_RowDeleting">
                            <Columns>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                                    ShowSelectButton="True" />
                                <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                                <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                                <asp:BoundField HeaderText="Item" DataField="ItemName" />
                                <asp:BoundField HeaderText="Property1" DataField="Property1" Visible="False" />
                                <asp:BoundField HeaderText="Property2" DataField="Property2" Visible="False" />
                                <asp:BoundField HeaderText="Property3" DataField="Property3" Visible="False" />
                                <asp:BoundField HeaderText="Property4" DataField="Property4" Visible="False" />
                                <asp:BoundField HeaderText="Property5" DataField="Property5" Visible="False" />
                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                                <asp:BoundField HeaderText="Unit Price" DataField="UnitPriceBDT" />
                                <asp:BoundField HeaderText="SD" DataField="SD" />
                                <asp:BoundField HeaderText="VAT" DataField="VAT" />
                                <asp:BoundField DataField="TotalPrice" HeaderText="Total Purchs Prc" />
                                <asp:BoundField HeaderText="Src VAT Deducted" DataField="IsSrcTAXDeduct" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                            </Columns>
                            <HeaderStyle Height="25px" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                            <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" Text="Refresh"
                                OnClick="btnRefreshChallan_Click" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <uc2:MsgBox ID="msgBox" runat="server" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
