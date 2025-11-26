<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_TurnOver_TurnOverTax, App_Web_tnq0bazs" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register src="../../UserControls/Sale.ascx" tagname="sale" tagprefix="uc1" %>--%>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
       
        
        .btn
        {
            padding: 5px;
            margin: 10px;
            text-decoration: none;
        }
        .btn-default
        {
            background: #ddd;
            color: #000;
        }
        .btn-danger
        {
            background: #F26363;
            color: #fff;
        }
        td
        {
            padding-right: 15px;
        }
        
        .zero-padding-top
        {
            padding-top: 0px;
        }
        .zero-padding-bottom
        {
            padding-bottom: 0px;
            height: 0px;
        }
        
        .modal_custom
        {
            background: #fff;
            padding: 10px;
        }
    </style>
    <style media="print">
        .noPrint
        {
            display: none;
        }
        @media print
        {
            table
            {
                width: 100%;
            }
            tr, td
            {
            }
            .full_width
            {
                width: 100%;
            }
        }
        .yesPrint
        {
            display: block !important;
        }
        input[type=text], select, textarea, .text_box
        {
            border: none;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:UpdatePanel ID="updatePanelchallan" runat="server">
        <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input"
                border="0px" width="100%">
              
                <tr>
                    <td class="page_title" colspan="5" align="center">
                        Turn Over Tax
                        <uc1:production ID="production" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
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
                        <asp:Label ID="lblOrgAddress" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right" class="style1">
                    </td>
                    <td class="style1">
                    </td>
                    <td align="right" colspan="2" class="style1">
                        <asp:Label ID="Label61" runat="server" Text="Item Type :"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:DropDownList ID="drpItemType" runat="server" OnSelectedIndexChanged="drpItemType_SelectedIndexChanged"
                            Width="200px">
                            <asp:ListItem Selected="True" Value="-99">-- Select --</asp:ListItem>
                            <asp:ListItem Value="P">Product</asp:ListItem>
                            <asp:ListItem Value="S">Service</asp:ListItem>
                            <asp:ListItem Value="U">Utility</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right" class="style2">
                        <asp:Label ID="Label30" runat="server" Text="DO/Challan No :"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtChallanNo" runat="server" Width="120px" Enabled="False"></asp:TextBox>
                        <asp:CheckBox ID="chkDiscard" runat="server" AutoPostBack="True" OnCheckedChanged="chkDiscard_CheckedChanged"
                            Text="Discard" />
                    </td>
                    <td align="right" colspan="2" class="style2">
                        <asp:Label ID="lblDiscardReason" runat="server" Text="Discard Reason :" Visible="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="drpDiscardReason" runat="server" Width="200px" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr>
               
                <tr>
                    <td valign="top" align="right">
                        <asp:Label ID="Label32" runat="server" Text="Challan Date Time:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtChallanDate" runat="server" Width="80px" DateFormat="dd/MM/yyyy"
                            ReadOnly="true"></asp:TextBox>
                        <asp:DropDownList ID="drpChDtHr" runat="server" Width="45px" ReadOnly="true" AutoPostBack="True"
                            OnSelectedIndexChanged="drpChDtHr_SelectedIndexChanged" Enabled="false">
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpChDtMin" runat="server" Width="45px" ReadOnly="true" Enabled="false"
                            AutoPostBack="True" OnSelectedIndexChanged="drpChDtMin_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" colspan="2">
                        <asp:Label ID="Label33" runat="server" Text="Delivery Date :"></asp:Label>
                    </td>
                    <td>
                        <ww:jQueryDatePicker ID="txtDeliveryDate" runat="server" Width="80px" DateFormat="dd/MM/yyyy"
                            OnTextChanged="txtDeliveryDate_TextChanged"></ww:jQueryDatePicker>
                        <asp:DropDownList ID="drpDlDtHr" runat="server" Width="45px" OnSelectedIndexChanged="drpDlDtHr_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpDlDtMin" runat="server" Width="45px" OnSelectedIndexChanged="drpDlDtMin_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left" colspan="2">
                        <asp:Label ID="lblChDtInWords" runat="server"></asp:Label>
                    </td>
                    <td align="center" colspan="3">
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
                        <asp:Button ID="btnAddParty" runat="server" CssClass="button_sub noPrint" OnClick="btnAddParty_Click"
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
                        <asp:TextBox ID="txtAddress" runat="server" Rows="1" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                    <td align="right" valign="top">
                        <asp:Label ID="Label34" runat="server" Text="Ultimate Destination :"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtDestination" runat="server" Rows="1" TextMode="MultiLine" Width="200px"></asp:TextBox>
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
               
                
                <%--Payment information--%>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdPriceID" runat="server" />
                    </td>
                    <td align="right" colspan="4">
                        <asp:HiddenField ID="hdUnitSDAmt" runat="server" />
                        <asp:HiddenField ID="hdUnitVATAmt" runat="server" />
                    </td>
                </tr>
            </table>
            <table>
                <table align="center" class="brd_tbl_input noPrint" width="960px">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td colspan='3'>
                            <%--Auto Complete--%>
                            <asp:TextBox ID="productName" AutoPostBack="true" Width="280px" placeholder="Search Product"
                                runat="server" OnTextChanged="productName_TextChanged"></asp:TextBox>
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
                    <!--Changed Design-->
                    <tr>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label4" runat="server" Text="Category :"></asp:Label>
                        </td>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label51" runat="server" Text="Sub Category :"></asp:Label>
                        </td>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label9" runat="server" Text="Item Name :"></asp:Label>
                        </td>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label54" runat="server" Text="HS Code :"></asp:Label>
                        </td>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label11" runat="server" Text="Quantity :"></asp:Label>
                        </td>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label13" runat="server" Text="Unit Price :"></asp:Label>
                        </td>
                        <td rowspan='4'>
                            <!-- Right Grid View-->
                            <table style="background: #fff; box-shadow: 4px 11px 7px #888888;">
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style5">
                                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Total Price :"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style5">
                                        <asp:Label ID="Label23" runat="server" Text="VAT Amount :" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblTotalVAT" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label60" runat="server" Font-Bold="True" Text="Total Sale Price :"></asp:Label>
                                    </td>
                                    <td align="right" class="style5">
                                        <asp:Label ID="lblTotalSalePrc" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- End Right Grid View-->
                        </td>
                    </tr>
                    <tr>
                        <td class="zero-padding-top">
                            <asp:DropDownList ID="drpCategory" runat="server" Width="100px" Height="27px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                AutoPostBack="True" TabIndex="1">
                            </asp:DropDownList>
                        </td>
                        <td class="zero-padding-top">
                            <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                                Width="100px" Height="27px" TabIndex="2">
                            </asp:DropDownList>
                        </td>
                        <td class="zero-padding-top">
                            <asp:DropDownList ID="drpItem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged"
                                Width="100px" Height="27px" TabIndex="3">
                            </asp:DropDownList>
                        </td>
                        <td class="zero-padding-top">
                            <asp:TextBox ID="lblHSCode" runat="server" Width="75px" Height="19px" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="zero-padding-top">
                            <asp:TextBox ID="txtQuantity" runat="server" Width="75px" Height="19px" AutoPostBack="True"
                                OnTextChanged="txtQuantity_TextChanged" TabIndex="4"></asp:TextBox>
                            <asp:Label ID="lblUnit" runat="server" Text="Unit " Font-Bold="True" Font-Size="Smaller"
                                Width="30px"></asp:Label>
                        </td>
                        <td class="zero-padding-top">
                            <asp:Label ID="lblUnitPrice" runat="server" Text="0.00" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtUnitPrice" runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged"
                                Width="75px" Height="19px" TabIndex="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>                        
                        
                        <td class="zero-padding-top">
                            
                            <asp:Label ID="lblProp2" runat="server" Text="Property 2" Visible="False"></asp:Label>
                        </td>
                        
                       
                        <td class="zero-padding-top">
                            <asp:DropDownList ID="drpProp2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp2_SelectedIndexChanged"
                                Visible="False" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblProp1" runat="server" Text="Property 1:" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpProp1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp1_SelectedIndexChanged"
                                Visible="False" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblProp4" runat="server" Text="Property 4" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpProp4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp4_SelectedIndexChanged"
                                Visible="False" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpProp3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp3_SelectedIndexChanged"
                                Visible="False" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblProp3" runat="server" Font-Bold="False" Text="Property 3" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label59" runat="server" Text="Available Stock :"></asp:Label>
                        </td>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label53" runat="server" Text="VAT(%) :"></asp:Label>
                        </td>
                        <td class="zero-padding-bottom">
                            <asp:Label ID="Label7" runat="server" Text="Remarks :"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="zero-padding-top">
                            <asp:Label ID="lblAvailStock" runat="server" Text="0.00"></asp:Label>
                        </td>
                        
                       
                        <td class="zero-padding-top">
                            <asp:Label ID="lblVAT" runat="server" Text="0.00"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="text_box"></asp:TextBox>

                            <asp:HiddenField ID="hdUnitID" runat="server" Visible="false" />
                        </td>
                       
                        <td>
                            <asp:Button ID="ClientButton" runat="server" Text="Add Payment" CssClass="button"
                                Height="30px" />
                            <asp:Panel ID="ModalPanel" runat="server" Width="800px" CssClass="modal_custom">
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <h2>
                                                Check your Payment Information:</h2>
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
                        <td align="right" >
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:HiddenField ID="hdItemType" runat="server" />
                                <asp:HiddenField ID="hdBookId" runat="server" />
                                <asp:HiddenField ID="hdPageNo" runat="server" />
                                <asp:Button ID="btnAdd" runat="server" CssClass="button_sub" OnClick="btnAddItem_Click"
                                    Text="Add Item" />
                                <asp:Button ID="btnClear" runat="server" CssClass="button_sub" OnClick="btnClear_Click"
                                    Text="Clear" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblProp5" runat="server" Text="Property 5" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpProp5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"
                                Visible="False" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--Remarks field was in top before--%>
                    <tr>
                        <td align="center" colspan="5">
                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </table>
            <div class="">
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
                        <asp:BoundField DataField="AvailStock" HeaderText="Current Stock" />
                        <asp:BoundField HeaderText="Unit Price" DataField="UnitPriceBDT" />
                        <asp:BoundField HeaderText="NBR Price" DataField="NBRPrice" />
                        <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" />
                        <asp:BoundField HeaderText="Total SD" DataField="SD" />
                        <asp:BoundField HeaderText="Total VAT" DataField="VAT" />
                        <asp:BoundField DataField="TotalSalePrice" HeaderText="Total Sale Price" />
                        <asp:BoundField HeaderText="Src VAT Deducted" DataField="IsSrcTAXDeduct" />
                        <asp:BoundField HeaderText="Exempted" DataField="IsExempted" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                </asp:GridView>
            </div>
            <table class="noPrint">
                <tr>
                    <td>
                    </td>
                    <td colspan="4" align="right">
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" Text="Refresh"
                                OnClick="btnRefreshChallan_Click" />
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Literal ID="ltCurrentId" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <uc2:MsgBox ID="msgBox" runat="server" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

