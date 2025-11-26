<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Purchase_Challan_6_3, App_Web_njc3mxew" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 25px;
        }
        .style3
        {
            height: 24px;
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

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px"> Purchase Challan / কর চালানপত্র</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="background-color: #E0EBF5">
                        <div class="col-sm-4">
                            <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                            <asp:Literal ID="lblOrgName" runat="server"></asp:Literal>
                            <asp:Label runat="server" ID="orgVDS" Visible="false" />
                        </div>
                        <div class="col-sm-6">
                            <asp:Label class="col-sm-2" ID="Label2" runat="server" Text="Address:"></asp:Label>
                            <asp:Literal ID="lblOrgAddress" runat="server"></asp:Literal>
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="Label8" runat="server" Text="BIN:"></asp:Label>
                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <%-- <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>--%>
                            <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px">
                            </asp:DropDownList>
                            <asp:Label ID="lblOrgAddress1" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>

                    <div class="row" style="margin-top: 5px; background-color: #E0EBF5">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label6" CssClass="present-address-lbl" Style="margin-left: 21%" runat="server"
                                    Text="Branch Name:">
                                </asp:Label></div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:DropDownList ID="drpBranchName" runat="server" Style="margin-left: 11px; height: 27px;
                                    text-align: left" CssClass="present-address-tb" 
                                    onselectedindexchanged="drpBranchName_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label28" runat="server" Style="margin-left: 8%" CssClass="present-address-lbl"
                                    Text="Branch Address:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px; margin-left: 36px">
                                <asp:Label ID="Label19" Style="margin-left: 37%; margin-top: 4px" CssClass="present-address-lbl"
                                    runat="server" Text="BIN:"></asp:Label></div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>


                    <div class="row" style="margin-top: 1%">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label3" Style="margin-left: 31%;" CssClass="present-address-lbl" runat="server"
                                    Text="Party Name:"></asp:Label>
                                    <asp:Label runat="server" ID="partyVDS" Visible="false" Text="false" />
                            </div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:DropDownList ID="drpParty" runat="server" CssClass="present-address-tb" Style="width: 178px;
                                    height: 27px; text-align: left" AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-2" style="padding: 0px">
                                <asp:Button ID="btnAddParty" runat="server" OnClick="btnAddParty_Click" Text="New"
                                    Style="width: 60px; height: 28px" />
                            </div>
                            <div class="col-sm-4" style="padding: 0px">
                                <asp:TextBox ID="txtPartyName" runat="server" Visible="False" CssClass="present-address-tb"
                                    Style="width: 176px; margin-left: 116px" placeholder="enter company name"></asp:TextBox></div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label4" Style="margin-left: 18%" runat="server" class="present-address-lbl"
                                    Text="Party Address:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox class="present-address-tb" Style="text-align: left; width: 69%; height: 27px"
                                    ID="txtAddress" runat="server" placeholder="address here"></asp:TextBox>
                            </div>
                            <br />
                            <asp:TextBox ID="TextBox3" runat="server" Visible="False" Width="200px"></asp:TextBox>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label12" Style="margin-left: 38%;" runat="server" Text="Party BIN:"
                                    class="present-address-lbl"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox ID="txtPartyBIN" runat="server" Style="width: 69%; height: 27px" class="present-address-tb"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%--************************************************* --%>
                    <div class="row" style="margin-top: 3px;">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label30" Style="margin-left: 11%;" CssClass="present-address-lbl"
                                    runat="server" Text="Ref. Challan No:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox ID="txtChallanNo" CssClass="present-address-tb" runat="server" Style="width: 54%;
                                    height: 27px" Enabled="true" placeholder="Party Challan No"></asp:TextBox></div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label32" CssClass="present-address-lbl" runat="server" Style="margin-left: 26%"
                                    Text="Challan Date:"></asp:Label></div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:TextBox ID="txtChallanDate" CssClass="present-address-tb" runat="server" Style="width: 65%;
                                    margin-left: 3%; height: 27px" DateFormat="dd/MM/yyyy" ReadOnly="false"></asp:TextBox></div>
                            <div class="col-sm-2" style="padding: 0px">
                                <asp:DropDownList ID="drpChDtHr" CssClass="present-address-tb" runat="server" Style="width: 72%;
                                    height: 27px; margin-left: -79%" ReadOnly="true" AutoPostBack="True" OnSelectedIndexChanged="drpChDtHr_SelectedIndexChanged"
                                    Enabled="false">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-2" style="padding: 0px">
                                <asp:DropDownList ID="drpChDtMin" CssClass="present-address-tb" runat="server" Style="width: 72%;
                                    height: 27px; margin-left: -105%" ReadOnly="true" Enabled="false" AutoPostBack="True"
                                    OnSelectedIndexChanged="drpChDtMin_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label Style="margin-left: 17%" ID="Label5" runat="server" Text="Ultimate Dest:"
                                    CssClass="present-address-lbl"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox CssClass="present-address-tb" Style="width: 69%; height: 27px" ID="txtDestination"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- *************************************Chalan Date Time***************************--%>
                    <div class="row" style="margin-top: 3px">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label29" CssClass="present-address-lbl" Style="margin-left: 4%" runat="server"
                                    Text="Transaction Type:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpTransactionType" CssClass="present-address-tb" runat="server"
                                    Style="width: 55%; height: 27px; margin-left: 4px">
                                    <asp:ListItem Selected="True">Bulk</asp:ListItem>
                                    <asp:ListItem>Retail</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label31" CssClass="present-address-lbl" Style="margin-left: 16%" runat="server"
                                    Text="Purchase Type:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpPurchaseType" CssClass="present-address-tb" runat="server"
                                    Style="width: 69%; height: 27px;" AutoPostBack="true">
                                    <asp:ListItem Selected="True">Local</asp:ListItem>
                                    <asp:ListItem>Import</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:DropDownList ID="drpType" CssClass="present-address-tb" runat="server" Style="margin-left: 26%;
                                height: 27px; width: 52%">
                                <asp:ListItem >Service</asp:ListItem>
                                <asp:ListItem Selected="True">Goods</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 3px">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label23" CssClass="present-address-lbl" Style="margin-left: 0px" runat="server"
                                    Text="Receive Scroll No:" Visible="true"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox ID="txtScrollNo" CssClass="present-address-tb" runat="server" Style="width: 55%;
                                    height: 27px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label27" CssClass="present-address-lbl" Style="margin-left: 27%" runat="server"
                                    Text="Vehicle Type:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpVehicleType" CssClass="present-address-tb" runat="server"
                                    Style="width: 69%; height: 27px; margin-left: 4px; text-align: left">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label35" Style="margin-left: 33%" CssClass="present-address-lbl" runat="server"
                                    Text="Vehicle No:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox ID="txtVehicleNo" CssClass="present-address-tb" runat="server" Style="margin-left: 4px;
                                    width: 69%; height: 27px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 3px">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBank" Style="margin-left: 31%" CssClass="present-address-lbl" runat="server"
                                    Text="Bank Name:" Visible="true"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpBank" CssClass="present-address-tb" Style="width: 55%; height: 27px;
                                    text-align: left" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpBank_SelectedIndexChanged"
                                    Visible="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBranch" Style="margin-left: 26%" CssClass="present-address-lbl"
                                    runat="server" Text="Bank Branch:" Visible="true"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpBranch" runat="server" CssClass="present-address-tb" Style="width: 69%;
                                    height: 27px;text-align:left" Visible="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label14" CssClass="present-address-lbl" Style="margin-left: 42%" runat="server"
                                    Text="Remarks:"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="present-address-tb" Style="width: 207%;
                                    margin-left: 6%; height: 27px" placeholder="write your comment here"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 3px">
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblExpDt" Style="margin-left: 12px" runat="server" Text="Purchase Date :"
                                Visible="False"></asp:Label>
                            <ww:jQueryDatePicker ID="txtExportDate" runat="server" DateFormat="dd/MM/yyyy" OnTextChanged="txtChallanDate_TextChanged"
                                Style="width: 170px; margin-left: 4px" Visible="False"></ww:jQueryDatePicker>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblExpBillNo" Style="margin-left: 5px" runat="server" Text="Purchase Bill No :"
                                Visible="False"></asp:Label>
                            <asp:TextBox ID="txtExpBillNo" runat="server" Style="width: 183px; margin-left: 3px"
                                Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:HiddenField ID="hdPriceID" runat="server" />
                            <asp:HiddenField ID="hdUnitSDAmt" runat="server" />
                            <asp:HiddenField ID="hdUnitVATAmt" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                    <div class="container-fluid">
                        <div class="row" >
                            <div class="test-label">
                                <asp:Label ID="Label7" runat="server" Text="Category :"></asp:Label><br />
                                <asp:DropDownList ID="drpCategory" Style="text-align: left" runat="server" CssClass="category"
                                    OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label15" runat="server" Text="Sub Cat:"></asp:Label><br />
                                <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                                    CssClass="sub-category">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label40" runat="server" Text="Search Product:" /><br />
                                <asp:TextBox ID="productName" AutoPostBack="true" CssClass="search-product" placeholder="Search Product"
                                    runat="server" OnTextChanged="productName_TextChanged" />
                                <div id="listPlacement" style="height: 100px; overflow: scroll;">
                                </div>
                                <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName"
                                    ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement" MinimumPrefixLength="1"
                                    EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetProductByProductName">
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label16" runat="server" Text="Item Name:" Style="margin-left: 0px;" /><br />
                                <asp:DropDownList ID="drpItem" CssClass="item" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="drpItem_SelectedIndexChanged" />
                                <asp:Label runat="server" ID="lblProductType" Visible="false" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                <asp:TextBox ID="lblHSCode" runat="server" Style="width: 70px; height: 27px" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label18" runat="server" Text="Qnty:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox><br />
                                <asp:Label ID="lblAvailStock" runat="server" Visible="false" Text="Avl Stock :"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label41" runat="server" Text="Unit:" Style="margin-left: 0px;" /><br />
                                <asp:DropDownList ID="drpUnit" CssClass="unit" runat="server" style="width:72px;text-align:left" OnSelectedIndexChanged="drpUnit_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label runat ="server" ID="lblCValue" Visible="false"/>
                                <asp:Label runat ="server" ID="lblUID" Visible="false"/>
                                <asp:Label runat ="server" ID="lblUnitCode" Visible="false"/>
                            </div>
                            <div class="test-label">
                                <%--<asp:Label ID="Label22" runat="server" Text="Unit Price(P):" Style="margin-left: 0px;" />--%>
                                <asp:Label ID="Label22" runat="server" Style="margin-left: 0px;" Text=<abbr title="Purchase Unit Price With VAT and SD">Unit Price(P):</abbr></asp:Label><br />
                                <asp:TextBox ID="txtPurchaseUnitPrice" CssClass="category" Style="background-color: #CAFDD2"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged" />
                                <asp:Label ID="lblPurchaseUnitPrice" runat="server" Text="" Style="margin-left: 0px;"
                                    Visible="false" />
                                <asp:Label ID="Label45" runat="server" Text="Total Price(Vat+SD) Per Unit :" Style="margin-left: -172px" /><asp:Label
                                    ID="lblPerUnitTotal" runat="server"></asp:Label>
                            </div>
                            <div class="test-label">
                               <asp:Label ID="Label36" runat="server" Style="margin-left: 0px;" Text=<abbr title="Purchase Unit Price Without VAT and SD">Price:</abbr></asp:Label><br />
                               <asp:TextBox ID="txtPurchaseUnitPriceNonVat" CssClass="category" Style="background-color: #CAFDD2" runat="server" ReadOnly="true"/>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label21" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtPurchaseVAT" CssClass="quantity" Style="background-color: #CAFDD2"
                                    runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="vdsAmount" runat="server" Visible="false" />
                                <asp:Label ID="lblPurchaseVAT" runat="server" Text="" /><asp:Label ID="Label25" runat="server"
                                    Text="%"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label26" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtPurchaseSD" CssClass="quantity" Style="background-color: #CAFDD2"
                                    runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="lblPurchaseSD" runat="server" Text="" /><asp:Label ID="Label33" runat="server"
                                    Text="%"></asp:Label>
                            </div>
                            <div class="test-label">
                            <asp:CheckBox ID="chkSaleValue" runat="server" Text="Add Sale Value" OnCheckedChanged="chkSaleValue_CheckedChanged" AutoPostBack="true"/>
                            </div>
                             
                            <%--<div class="test-label">
                                <asp:Label ID="Label13" runat="server" Text="Unit Price(S):" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleUnitPrice" CssClass="category" runat="server" AutoPostBack="True"
                                    OnTextChanged="txtSaleUnitPrice_TextChanged" />
                                <asp:Label ID="lblSaleUnitPrice" runat="server" Text="" Style="margin-left: 0px;"
                                    Visible="false" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label34" runat="server" Text="Vatable(P):" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleVatablePrice" CssClass="category" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtVatablePrice_TextChanged" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label42" runat="server" Text="Vat:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleVat" CssClass="quantity" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True"></asp:TextBox>
                                <asp:Label ID="lblSaleVat" runat="server" Text="" /><asp:Label ID="Label9" runat="server"
                                    Text="%"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label43" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtSaleSD" CssClass="quantity" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True"></asp:TextBox>
                                <asp:Label ID="lblSaleSD" runat="server" Text="" /><asp:Label ID="Label11" runat="server"
                                    Text="%"></asp:Label>
                            </div>--%>
                        </div>
                        <div class="row">

                         <div class="test-label">
                                <asp:Label ID="lblSaleUnitPrice" runat="server" Text="Unit Price(S):" Style="margin-left: 0px;" Visible="false" /><br />
                                <asp:TextBox ID="txtSaleUnitPrice" CssClass="category" runat="server" AutoPostBack="True" Style="background-color: #D4FCFF"
                                    OnTextChanged="txtSaleUnitPrice_TextChanged" Visible="false" />
                               <%-- <asp:Label ID="lblSaleUnitPrice" runat="server" Text="" Style="margin-left: 0px;"
                                    Visible="false" />--%>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblSaleVatablePrice" runat="server" Text="Vatable(P):" Style="margin-left: 0px;" Visible="false" /><br />
                                <asp:TextBox ID="txtSaleVatablePrice" CssClass="category" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtVatablePrice_TextChanged" Visible="false" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblSalesVat" runat="server" Text="VAT:" Style="margin-left: 0px;" Visible="false" /><br />
                                <asp:TextBox ID="txtSaleVat" CssClass="quantity" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True" Visible="false"></asp:TextBox>
                                <asp:Label ID="lblSaleVat" runat="server" Text="" Visible="false" /><asp:Label ID="lblVatPercent" runat="server"
                                    Text="%" Visible="false"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblSalesSD" runat="server" Text="SD:" Style="margin-left: 0px;" Visible="false" /><br />
                                <asp:TextBox ID="txtSaleSD" CssClass="quantity" Style="background-color: #D4FCFF"
                                    runat="server" AutoPostBack="True" Visible="false"></asp:TextBox>
                                <asp:Label ID="lblSaleSD" runat="server" Text="" Visible="false"/><asp:Label ID="lblSDPercent" runat="server"
                                    Text="%" Visible="false"></asp:Label>
                            </div>

                            <div class="test-label">
                                <asp:HiddenField ID="hdProp1" runat="server" />
                                <asp:Label ID="lblProperty1" runat="server" Text="Size:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp1_SelectedIndexChanged"
                                    CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp2" runat="server" />
                                <asp:Label ID="lblProperty2" runat="server" Text="Color:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp2_SelectedIndexChanged"
                                    Visible="false" CssClass="category" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp3" runat="server" />
                                <asp:Label ID="lblProperty3" runat="server" Text="Grade:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp3_SelectedIndexChanged"
                                    CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp4" runat="server" />
                                <asp:Label ID="lblProperty4" runat="server" Text="Company:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp4_SelectedIndexChanged"
                                    CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:HiddenField ID="hdProp5" runat="server" />
                                <asp:Label ID="lblProperty5" runat="server" Text="Specification:" Visible="false" /><br />
                                <asp:DropDownList ID="drpProperty5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"
                                    CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="Label10" Style="margin-left: 15px; float: left" runat="server" Text="Remarks:"></asp:Label><br />
                                <asp:TextBox ID="remarks2" runat="server" CssClass="present-address-tb" Style="width: 13%;
                                    margin-left: 3px; float: left; text-align: left" placeholder="write your comment here" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="test-check" style="margin-top: 4px;">
                                <asp:CheckBox ID="chkDeemedExport" runat="server" Text="Deemed Export" AutoPostBack="true"
                                    Visible="false" OnCheckedChanged="chkDeemedExport_CheckedChanged" />
                                <asp:HiddenField ID="hdDeemedExport" runat="server" />
                            </div>
                            <div class="test-check" style="margin-top: 4px;">
                                <asp:CheckBox ID="chkInexplicitExport" runat="server" AutoPostBack="true" Text="Deemed Export"
                                    Visible="false" OnCheckedChanged="chkInexplicitExport_CheckedChanged" />
                            </div>
                            <div class="test-check" style="">
                                <asp:Label ID="lblvdstx" Style="float: left; margin-top: 3px"
                                    runat="server" Text="VDS Amount:" Visible="false" />
                                <asp:TextBox ID="txtvdsamount" runat="server" CssClass="present-address-tb" Style="width: 90px;
                                    margin-left: 3px; float: left; text-align: left; height: 27px" Visible="false"></asp:TextBox>
                            </div>
                            <div style="text-align: right; float: right; font-size: 14px; margin-right: 2%; border: 1px solid #ff00ff;margin-top:-17px">
                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="Sub Total:" />
                                <asp:Label ID="lblTotalPrice" runat="server" Style="font-size: 12px;" Font-Bold="false" Text="0.00" /><br />
                                <asp:Label ID="Label37" runat="server" Text="VAT Amount:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblTotalVAT" runat="server" Style="font-size: 12px; margin-right: 0px" Text="0.00" Font-Bold="false"></asp:Label><br />
                                <asp:Label ID="Label24" runat="server" Text="SD Amount:" Font-Bold="True" />
                                <asp:Label ID="lblTotalSD" runat="server" Style="font-size: 12px; margin-right: 0px" Text="0.00" Font-Bold="false" /><br />
                                <asp:Label ID="Label44" runat="server" Font-Bold="True" Text="Total Price:"></asp:Label>
                                <asp:Label ID="lblTotalPurchasePrc" runat="server" Style="font-size: 12px;" Font-Bold="false" Text="0.00"></asp:Label>
                            </div>
                            <div class="test-check">
                               <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Grand Total:" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 1%">
                         <div class="test-check" style="margin-top:-15px">
                                <asp:CheckBox ID="chkTaxDeducted" runat="server" OnCheckedChanged="chkTaxDeducted_CheckedChanged" Text="VDS" />
                                <asp:CheckBox ID="chkExempted" style="margin-top:0px" runat="server" Text="Exempted" AutoPostBack="True"  Enabled="False" OnCheckedChanged="chkExempted_CheckedChanged" />
                                <asp:CheckBox ID="chkRebatable" runat="server" Enabled="true" Text="Rebatable" />
                                <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" AutoPostBack="true" Enabled="False" OnCheckedChanged="chkZeroRate_CheckedChanged" />
                                <asp:HiddenField ID="hdZerorate" runat="server" />
                                <asp:HiddenField ID="hdrebatable" runat="server" />
                            </div>
                        </div>
                        <div class="row" style="margin-top: 1%">
                            <asp:Label ID="lblMessage" runat="server" style="font-size:20px" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                            <uc2:MsgBox ID="msgBox" runat="server" />
                            <div class="test-btn">
                                <asp:Button ID="btnAdd" runat="server" class="test-btn-primary" OnClick="btnAddItem_Click"
                                    Text="Add Item" />
                            </div>
                            <div class="test-btn">
                                <asp:Button ID="ClientButton" runat="server" Style="width: 100px" Text="Add Payment"
                                    class="test-btn-primary" />
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
                                                <asp:CheckBox ID="chkCredit" runat="server" Text="Credit" AutoPostBack="true" OnCheckedChanged="payment_CheckedChanged" />
                                            </td>
                                            <td>
                                                <asp:Button ID="OKButton" runat="server" CssClass="button" Text="OK" Width="50px" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton"
                                    BackgroundCssClass="modalPopup" PopupControlID="ModalPanel" OkControlID="OKButton" />
                                <asp:HiddenField ID="hdItemType" runat="server" />
                                <asp:HiddenField ID="hdBookId" runat="server" />
                                <asp:HiddenField ID="hdPageNo" runat="server" />
                                <asp:HiddenField ID="hdIsExempted" runat="server" />
                            </div>
                            <div class="test-btn">
                                <asp:Button ID="btnSave" runat="server" class="test-btn-primary" Text="Save" OnClick="btnSave_Click" />
                            </div>
                            <div class="test-btn">
                                <asp:Button ID="btnClear" runat="server" class="test-btn-primary" OnClick="btnClear_Click"
                                    Text="Clear" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="">
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                            DataKeyNames="ItemID,RowNo" Width="100%" OnSelectedIndexChanged="gvItem_SelectedIndexChanged"
                             OnRowDeleting="gvItem_RowDeleting">
                            <Columns>
                                <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                                <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                                <asp:BoundField HeaderText="Item" DataField="ItemName" />
                                <asp:BoundField HeaderText="Property1" DataField="IntProperty1" Visible="true" />
                                <asp:BoundField HeaderText="Property2" DataField="IntProperty2" Visible="true" />
                                <asp:BoundField HeaderText="Property3" DataField="IntProperty3" Visible="true" />
                                <asp:BoundField HeaderText="Property4" DataField="IntProperty4" Visible="true" />
                                <asp:BoundField HeaderText="Property5" DataField="IntProperty5" Visible="true" />
                                <asp:BoundField HeaderText="Quantity" DataField="TempQuantity" />
                                <asp:BoundField HeaderText="Unit" DataField="TempUnitCode" />
                                <asp:BoundField HeaderText="Unit Price" DataField="TempUnitPrice" />
                                <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" />
                                <asp:BoundField HeaderText="SD" DataField="PurchaseSD" />
                                <asp:BoundField HeaderText="VAT" DataField="PurchaseVAT" />
                                <asp:BoundField DataField="TotalPurchasePrice" HeaderText="Total Purchase Price" />
                                <asp:BoundField HeaderText="VDS" DataField="IsSrcTAXDeduct" />
                                <asp:BoundField HeaderText="Exempted" DataField="IsExempted" />
                                <asp:BoundField HeaderText="Deemed Exp" DataField="IsDeemedExport" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                            </Columns>
                            <HeaderStyle Height="25px" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                        DataKeyNames="ItemID" Width="100%" OnSelectedIndexChanged="gvItem_SelectedIndexChanged"
                        OnPreRender="gvItem_PreRender" OnRowDataBound="gvItem_RowDataBound" OnRowDeleting="gvItem_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="itemName" HeaderText="Item" />
                            <asp:BoundField DataField="itemQuantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="itemUnit" HeaderText="Unit" />
                            <asp:BoundField DataField="itemUnitPrice" HeaderText="Unit Price" />
                            <asp:BoundField DataField="itemVat" HeaderText="Vat" />
                            <asp:BoundField DataField="itemSD" HeaderText="SD" />
                            <asp:BoundField DataField="totalPrice" HeaderText="Total Price" />
                            <asp:CommandField ShowEditButton="true" />
                            <asp:CommandField ShowDeleteButton="true" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-2">
                        <asp:Label ID="lblNBRPrice" runat="server" Text="0.00" Visible="false"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-2">
                        <asp:HiddenField ID="hdUnitID" runat="server" Visible="false" />
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-2 col-xs-2 col-lg-2">
                        <asp:Literal ID="ltCurrentId" runat="server"></asp:Literal></div>
                    <div class="col-sm-2 col-xs-2 col-lg-2">
                        <asp:Literal ID="cashMemo" runat="server"></asp:Literal>
                        </div>
                    <div class="col-sm-2 col-xs-2 col-lg-2">
                        <asp:Literal ID="allSaleChallanPrint" runat="server" Visible="false"></asp:Literal>
                    </div>
                    <div class="col-sm-2 col-xs-2 col-lg-2">
                    </div>
                    <div class="col-sm-2 col-xs-2 col-lg-2">
                    </div>
                    <div class="col-sm-2 col-xs-2 col-lg-2">
                    </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
