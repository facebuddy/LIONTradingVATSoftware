<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Purchase_Edit, App_Web_njc3mxew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
</asp:Content >

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">Purchase Edit</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="margin-top: 1%">
                        <div class="col-sm-6">
                                <div class="col-sm-4" style="padding: 0px">
                                    <asp:Label ID="Label2" runat="server" Text="Date From:" class="present-address-lbl" Style="margin-left: 1%; margin-top: 5px"></asp:Label>
                                    <asp:TextBox ID="dtpDateFrom" runat="server" Style="width: 65%;margin-left:35%" class="present-address-tb" DateFormat="dd/MM/yyyy" placeholder="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                                    <asp:Label ID="lblfromDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    
 		                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="dtpDateFrom"
 		                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
 		                            ErrorMessage="Invalid date format in From Date." CssClass="litMessage" />
                                </div>
                                <div class="col-sm-4" style="padding: 0px">
                                    <asp:Label ID="Label1" runat="server" Text="Date To:" class="present-address-lbl" Style="margin-top: 5px; margin-left: 1%"></asp:Label>
                                    <asp:TextBox ID="dtpDateTo" runat="server" Style="width: 65%;margin-left:28% " class="present-address-tb" DateFormat="dd/MM/yyyy" placeholder="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                                    <asp:Label ID="lblToDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
 		                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="dtpDateTo"
 		                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
 		                            ErrorMessage="Invalid date format in To Date." CssClass="litMessage" />

                                </div>
                                <div class="col-sm-4" style="padding: 0px">
                                   <asp:Label ID="lblChallan" runat="server" class="present-address-lbl" Text="Challan No:" Style="float: left; margin-top: 5px" />
                                    <asp:DropDownList runat="server" ID="drpChallan" class="present-address-tb" Style="float: left;width: 64%;text-align:left">
                                    </asp:DropDownList>
                                     <asp:Label ID="lblChallanID" runat="server" Visible = "false"/>
                                     <asp:Label ID="lblRowNo" runat="server" Visible = "false"/>
                                     <asp:Label ID="lblDetailID" runat="server" Visible = "false"/>
                                </div>
                        </div>
                        <div class="col-sm-6" style="padding: 0px; ">
                         <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="Label8" Style="margin-top: 5px;" CssClass="present-address-lbl" runat="server" Text="Party Name:" ></asp:Label>
                            <asp:DropDownList ID="drpPartyM" runat="server" CssClass="present-address-tb" Style="width: 62%; text-align: left;margin-left:37%" AutoPostBack="True" OnSelectedIndexChanged="drpPartyM_SelectedIndexChanged">
                            </asp:DropDownList>
                         </div>
                          <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="Label9" Style="margin-top: 5px;margin-left:11px" CssClass="present-address-lbl" runat="server" Text="Party BIN:"></asp:Label>
                            <asp:DropDownList ID="drpBINM" runat="server" CssClass="present-address-tb" Style="width: 62%; text-align: left;margin-left:36%" AutoPostBack="True">
                            </asp:DropDownList>
                         </div>
                         <div class="col-sm-4" style="padding: 0px">
                            <asp:Button ID="btnSearch" runat="server" CssClass="test-btn-primary" OnClick="btnSearch_Click" Text="Search" Style="float: left; width: 38%; margin-left: 1%; margin-top: -2px" />
                            <asp:Button ID="btnShow" runat="server" CssClass="test-btn-primary" OnClick="btnShow_Click" Text="Show History" Style="float: left; width: 50%; margin-left: 1%; margin-top: -2px" />
                         </div>
                        </div>
                    </div>
                </div>
               </div>
           <div class="panel panel-primary">
              <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                 <div class="row" style=" background-color: #E0EBF5">
                        <div class="col-sm-4" style="padding: 0px;margin-top:2px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label3" CssClass="present-address-lbl" Style="margin-left: 21%" runat="server"
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
                        <div class="col-sm-4" style="padding: 0px;margin-top:2px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label28" runat="server" Style="margin-left: 8%" CssClass="present-address-lbl"
                                    Text="Branch Address:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px;margin-top:2px">
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
                                <asp:Label ID="Label4" Style="margin-left: 31%;" CssClass="present-address-lbl" runat="server"
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
                                <asp:Label ID="Label5" Style="margin-left: 18%" runat="server" class="present-address-lbl"
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
                                    margin-left: 3%; height: 27px" DateFormat="dd/MM/yyyy" ReadOnly="false"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate"/>
                            </div>
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
                                <asp:Label Style="margin-left: 17%" ID="Label7" runat="server" Text="Ultimate Dest:"
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
                <div class="row" style="margin-top:1%;padding-left:15px; padding-bottom:30px">
                            <div class="test-label">
                                <asp:Label ID="Label16" runat="server" Text="Item Name:" Style="margin-left: 0px;" /><br />
                                <asp:DropDownList ID="drpItem" CssClass="item" runat="server" AutoPostBack="True" />
                                <asp:Label runat="server" ID="lblProductType" Visible="false" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                <asp:TextBox ID="lblHSCode" runat="server" Style="width: 70px; height: 27px" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label18" runat="server" Text="Qnty:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label41" runat="server" Text="Unit:" Style="margin-left: 0px;" /><br />
                                <asp:DropDownList ID="drpUnit" CssClass="unit" runat="server" style="width:72px;text-align:left" OnSelectedIndexChanged="drpUnit_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label runat ="server" ID="lblCValue" Visible="false"/>
                                <asp:Label runat ="server" ID="lblUID" Visible="false"/>
                                <asp:Label runat ="server" ID="lblUnitCode" Visible="false"/>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label22" runat="server" Style="margin-left: 0px;" Text=<abbr title="Purchase Unit Price With VAT and SD">Unit Price(P):</abbr></asp:Label><br />
                                <asp:TextBox ID="txtPurchaseUnitPrice" CssClass="category" Style="background-color: #CAFDD2" runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged" />
                                <asp:Label ID="lblPurchaseUnitPrice" runat="server" Text="" Style="margin-left: 0px;"
                                    Visible="false" />
                                <asp:Label ID="Label45" runat="server" Text="Total Price(Vat+SD) Per Unit :" Style="margin-left: -172px" /><asp:Label
                                    ID="lblPerUnitTotal" runat="server"></asp:Label>
                            </div>
                            <div class="test-label">
                               <asp:Label ID="Label36" runat="server" Style="margin-left: 0px;" Text=<abbr title="Purchase Unit Price Without VAT and SD">Price:</abbr></asp:Label><br />
                               <asp:TextBox ID="txtPurchaseUnitPriceNonVat" CssClass="category" Style="background-color: #CAFDD2" runat="server"/>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label21" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtPurchaseVAT" CssClass="quantity" Style="background-color: #CAFDD2"
                                    runat="server" AutoPostBack="True"></asp:TextBox>
                                <asp:Label ID="vdsAmount" runat="server" Visible="false" />
                                <asp:Label ID="lblPurchaseVAT" runat="server" Text="" /><asp:Label ID="Label25" runat="server"
                                    Text="%"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label26" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtPurchaseSD" CssClass="quantity" Style="background-color: #CAFDD2" runat="server" AutoPostBack="True"></asp:TextBox>
                                <asp:Label ID="lblPurchaseSD" runat="server" Text="" /><asp:Label ID="Label33" runat="server" Text="%"></asp:Label>
                            </div>
                            <div class="test-label" style="padding-top: 22px;padding-left: 5px;">
                            <asp:CheckBox ID="chkSaleValue" runat="server"  Text="Add Sale Value" OnCheckedChanged="chkSaleValue_CheckedChanged" AutoPostBack="true"/>
                            </div>
                            <div class="test-label" style="margin-left:5px">
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
                                 <asp:Button ID="btnUpdate" runat="server" CssClass="test-btn-primary" Text="Update" OnClick="btnUpdate_Click" Style="float: left; width: 100%; margin-left: 5%; margin-top: 18px" />
                            </div>
                   </div>
                   <div class="row" style="padding-bottom:5px">
                            <div class="test-check" style="margin-top: 4px;">
                                <asp:CheckBox ID="chkDeemedExport" runat="server" Text="Deemed Export" AutoPostBack="true" Visible="false" OnCheckedChanged="chkDeemedExport_CheckedChanged" />
                                <asp:HiddenField ID="hdDeemedExport" runat="server" />
                            </div>
                            <div class="test-check" style="margin-top: 4px;">
                                <asp:CheckBox ID="chkVDS" runat="server" AutoPostBack="true" Text="VDS" Visible="false" OnCheckedChanged="chkVDS_CheckedChanged" />
                            </div>
                            <div class="test-check" style="margin-top: 4px;">
                                <asp:CheckBox ID="chkExampted" runat="server" AutoPostBack="true" Text="Exempted" Visible="false"/>
                            </div>
                            <div class="test-check" style="margin-top: 4px;">
                                <asp:CheckBox ID="chkRebatable" runat="server" AutoPostBack="true" Text="Rebatable" Visible="false"/>
                            </div>
                            <div class="test-check" style="">
                                <asp:Label ID="lblvdstx" Style="float: left; margin-top: 3px" runat="server" Text="VDS Amount:" Visible="false" />
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
                   </div>
                   <div class="row">  <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="True" ForeColor="Red" Text="" /></div>
                </div>
            </div>
            <div id="Div1" class="row" style="margin-top: 1%;padding-top: 0px; padding-bottom: 0px;margin-left:1px;margin-right:1px" runat="server">
                        <div class="panel panel-primary" >
                            <div class="panel-body" >
                                <div class="" runat="server" id="gridviewPurchase" visible="true">
                                    <asp:GridView ID="gvLocalPurchase" runat="server" AutoGenerateColumns="False" 
                                    OnSelectedIndexChanged="gvPurchase_SelectedIndexChanged" CssClass="sGrid" DataKeyNames="RowNo" Width="100%" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                           <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                            <asp:BoundField HeaderText="Challan No" DataField="ChallanNO" />
                                            <asp:BoundField HeaderText="Challan Date" DataField="ChallanDate" />
                                            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                                            <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                            <asp:BoundField HeaderText="Unit Price" DataField="PUnitPrice" />
                                            <asp:BoundField HeaderText="Vatable Price" DataField="PVatablePrice" />
                                            <asp:BoundField HeaderText="Vat" DataField="PVat" />
                                            <asp:BoundField HeaderText="SD" DataField="PSD" />
                                            <%--<asp:TemplateField HeaderText="quantity">
                                             <ItemTemplate>
                                                  <asp:TextBox ID="quantity" runat="server" Text= '<%# Eval("quantity") %>' style="width:55px" ></asp:TextBox>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                             <%--<asp:TemplateField HeaderText="Unit Name">
                                             <ItemTemplate>
                                                  <asp:DropDownList ID="unit_code" runat="server" Text= '<%# Eval("unit_code") %>' style="width:auto" ></asp:DropDownList>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                             <%--<asp:TemplateField HeaderText="unit_price">
                                             <ItemTemplate>
                                                  <asp:TextBox ID="purchase_unit_price" runat="server" Text= '<%# Eval("purchase_unit_price") %>' style="width:100px" ></asp:TextBox>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                            <%-- <asp:TemplateField HeaderText="Vatable Price">
                                             <ItemTemplate>
                                                  <asp:TextBox ID="price" runat="server" Text= '<%# Eval("price") %>' style="width:auto" ></asp:TextBox>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                              <%--<asp:TemplateField HeaderText="Vat">
                                             <ItemTemplate>
                                                  <asp:TextBox ID="purchase_vat" runat="server" Text= '<%# Eval("purchase_vat") %>' style="width:100px" ></asp:TextBox>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                              <%--<asp:TemplateField HeaderText="SD">
                                             <ItemTemplate>
                                                  <asp:TextBox ID="purchase_sd" runat="server" Text= '<%# Eval("purchase_sd") %>' style="width:100px" ></asp:TextBox>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                            <asp:BoundField HeaderText="Exempted" DataField="IsExempted" />
                                            <asp:BoundField HeaderText="Rebatable" DataField="IsRebatable" />
                                            <asp:BoundField HeaderText="VDS" DataField="IsVDS" />
                                            <asp:BoundField HeaderText="vds amount" DataField="VDSAmount" />
                                            <%-- <asp:TemplateField HeaderText="vds amount">
                                             <ItemTemplate>
                                                  <asp:TextBox ID="vds_amount" runat="server" Text= '<%# Eval("vds_amount") %>' style="width:100px" ></asp:TextBox>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                        </Columns>
                                        <HeaderStyle Height="25px" />
                                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>

        </div>
        <uc2:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>