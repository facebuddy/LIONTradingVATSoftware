<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="BillofEntry_Edit, App_Web_njc3mxew" %>
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
                <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">Bill of Entry Edit</div>
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
                            <asp:DropDownList ID="drpPartyM" runat="server" CssClass="present-address-tb" Style="width: 62%; text-align: left;margin-left:37%" AutoPostBack="True" >
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
                     <div class="row" style="margin-top: 5px; background-color: #E0EBF5">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label39" CssClass="present-address-lbl" Style="margin-left: 24%" runat="server"
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
                                <asp:Label ID="Label45" runat="server" Style="margin-left: 9%" CssClass="present-address-lbl"
                                    Text="Branch Address:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px; margin-left: 36px">
                                <asp:Label ID="Label54" Style="margin-left: 42%; margin-top: 4px" CssClass="present-address-lbl"
                                    runat="server" Text="BIN:"></asp:Label></div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top:1%">
                        <div class="col-sm-3" style="padding:0px;">
                            <asp:Label ID="Label30" style="margin-left:21px" runat="server" Text="Ref. Challan No:"></asp:Label>
                            <asp:TextBox ID="txtChallanNo" runat="server" style="margin-right: 24px;" class="boe-input" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px">
                            <asp:Label ID="Label3" style="margin-left: 52px;" runat="server" Text="Bill of Entry No:"></asp:Label>
                            <asp:TextBox ID="txtBLNo" class="boe-input" runat="server" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px">
                           <asp:Label ID="Label32" runat="server" style="margin-left:30px" Text="Bill of Entry Date:"></asp:Label>
                           <asp:DropDownList ID="drpChDtMin" class="boe-input" runat="server" style="width:40px;margin-right:9px" ReadOnly="true" >
                           </asp:DropDownList>
                           <asp:DropDownList ID="drpChDtHr" class="boe-input" runat="server" style="width:40px; " ReadOnly="true" >
                           </asp:DropDownList>
                           <asp:TextBox ID="dtpBillOfEntryDate" class="boe-input" runat="server" style="width:87px; " DateFormat="dd/MM/yyyy" ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpBillOfEntryDate"/>
                        </div>
                        <div class="col-sm-3" style="padding:0px">
                           <asp:Label ID="Label46" runat="server" style="margin-left:65px" Text="Port Code:"></asp:Label>
                           <asp:DropDownList ID="drpPortCode" class="boe-input" runat="server" style="margin-right:17px" ReadOnly="true" Enabled="true" AutoPostBack="True" >
                           </asp:DropDownList>
                        </div>
                   </div>
                   <div class="row" style="margin-top:1%">
                        <div class="col-sm-3" style="padding:0px; margin-top: -10px;">
                        <asp:Label ID="Label4" style="margin-left: 57px;" runat="server" Text="Port From:"></asp:Label>
                        <asp:TextBox ID="txtPortFrom" class="boe-input" runat="server" style="margin-right: 24px;" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top: -10px;" >
                        <asp:Label ID="Label5" style="margin-left:99px" runat="server" Text="Port To:"></asp:Label>
                        <asp:TextBox ID="txtPortTo" class="boe-input" runat="server" style="width:169px" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top: -10px;">
                           <asp:Label ID="Label7" runat="server" style="margin-left:93px" Text="LC NO:"></asp:Label>
                           <asp:TextBox ID="txtLCNo" class="boe-input" runat="server" style="margin-right:9px" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top: -10px;">
                        <asp:Label ID="Label14" style="margin-left:78px" runat="server" Text="LC Date:"></asp:Label>
                        <asp:TextBox ID="dtpLCDate" class="boe-input" runat="server" style="margin-right:17px" Enabled="true"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpLCDate"/>
                        </div>
                  </div>
                  <div class="row" style="margin-top:1%">
                        <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                        <asp:Label ID="Label10" style="margin-left: 24px;" runat="server" Text="LC Amount(Tk):"></asp:Label>
                        <asp:TextBox ID="txtLCAmount" class="boe-input" runat="server" style="margin-right:24px" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top:-11px">
                           <asp:Label ID="Label11" style="margin-left:39px" runat="server" Text="LC Value & Curr.:"></asp:Label>
                            <asp:DropDownList ID="drpCurrencyUnit" class="boe-input" runat="server" style="width:55px;"></asp:DropDownList>
                            <asp:TextBox ID="txtForeignAmount" class="boe-input" runat="server" style="width:114px;"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top:-11px">
                        <asp:Label ID="Label12" runat="server" style="margin-left:104px" Text="Bank:"></asp:Label>
                        <asp:DropDownList ID="drpBank" class="boe-input" runat="server" style="margin-right:9px" ReadOnly="true" Enabled="true" AutoPostBack="True" 
                                        OnSelectedIndexChanged="drpBank_SelectedIndexChanged">
                           </asp:DropDownList>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top:-11px">
                        <asp:Label ID="Label13" style="margin-left:84px" runat="server" Text="Branch:"></asp:Label>
                        <asp:DropDownList ID="drpBankBranch" class="boe-input" runat="server" style="width:52.5%; height:25px;margin-right:5%" 
                        ReadOnly="true" Enabled="true">
                         </asp:DropDownList>
                        </div>
                  </div>
                  <div class="row" style="margin-top:1%">
                        <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                        <asp:Label ID="Label15" style="margin-left:5px" runat="server" Text="Insurance Number:"></asp:Label>
                        <asp:TextBox ID="txtInsuranceNo" class="boe-input" runat="server" style="margin-right:24px" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top:-11px">
                        <asp:Label ID="Label16" style="margin-left: 4px;" runat="server" Text="Insurance Amount(Tk):"></asp:Label>
                        <asp:TextBox ID="txtInsuranceAmount" class="boe-input" runat="server" style="width: 169px; border:1px solid #C29925" Enabled="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top:-11px">
                            <asp:Label ID="Label6" runat="server" style="margin-left:47px" Text=<abbr title="Shipment Date and Time">Shipment D&T:</abbr></asp:Label>
                            <asp:DropDownList ID="drpShipDtMin" class="boe-input" runat="server" style="width:40px;margin-right:9px" ReadOnly="true" Enabled="true">
                           </asp:DropDownList>
                           <asp:DropDownList ID="drpShipDtHr" class="boe-input" runat="server" style="width:40px; " ReadOnly="true">
                           </asp:DropDownList>
                           <asp:TextBox ID="txtShipmentDate" class="boe-input" runat="server" style="width:87px; " DateFormat="dd/MM/yyyy"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txtShipmentDate"/>
                        </div>
                        <div class="col-sm-3" style="padding:0px;margin-top:-11px">
                        <asp:Label ID="Label33" style="margin-left: 50px;" runat="server" Text=<abbr title="Delivery Date and Time">Delivery D&T:</abbr></asp:Label>
                         <asp:DropDownList ID="drpDlDtMin" class="boe-input" runat="server" style="width:40px;margin-right:5%" ReadOnly="true" Enabled="true">
                           </asp:DropDownList>
                           <asp:DropDownList ID="drpDlDtHr" class="boe-input" runat="server" style="width:40px; " ReadOnly="true" >
                           </asp:DropDownList>
                           <asp:TextBox ID="txtDeliveryDate" class="boe-input" runat="server" style="width:27%; " DateFormat="dd/MM/yyyy"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDeliveryDate"/>
                        </div>
                  </div>
                  <div class="row" style="margin-top:1%">
                        <div class="col-sm-3" style="padding:0px; margin-top:-12px">
                            <asp:Label ID="Label21" style="margin-left:6px" runat="server" Text="Release Order No:"></asp:Label>
                            <asp:TextBox ID="txtReleaseOrderNo" class="boe-input" runat="server" style="margin-right:24px"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px; margin-top:-12px">
                            <asp:Label ID="Label17" style="margin-left:41px" runat="server" Text=<abbr title="Release Order Date">Rlsg Order Date:</abbr></asp:Label>
                            <asp:TextBox ID="txtReleaseOrderDate" class="boe-input" runat="server" Width="169px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy" TargetControlID="txtReleaseOrderDate"/>
                        </div>
                         <div class="col-sm-3" style="padding:0px; margin-top:-12px">
                       <asp:Label ID="Label18" runat="server" style="margin-left:45px" Text="Supplier Name:"></asp:Label>
                       <asp:DropDownList ID="drpParty" runat="server" AutoPostBack="True" 
                              onselectedindexchanged="drpParty_SelectedIndexChanged" style="width: 125px;height: 25px;margin-left:2.5px">
                          </asp:DropDownList>
                          <asp:Button ID="btnAddParty" runat="server" CssClass="button_sub" onclick="btnAddParty_Click" Text="New" style="width:40px" />
                          <br />
                          <asp:TextBox ID="txtPartyName" runat="server" Visible="False" style="width:170px;margin-left:45.8%"></asp:TextBox>
                       </div>
                       <div class="col-sm-3" style="padding:0px; margin-top:-12px">
                            <asp:Label ID="Label19" style="margin-left: 25px;" runat="server" Text="Supplier Country:"></asp:Label>
                            <asp:DropDownList ID="drpCountry" runat="server" class="boe-input" AutoPostBack="True" style="width:169px; height:25px; margin-right:5%">
                          </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="margin-top:1%">
                        <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                            <asp:Label ID="Label20" style="margin-left:12px" runat="server" Text="Supplier Address:"></asp:Label>
                            <asp:TextBox ID="txtAddress" class="boe-input" runat="server" Rows="1" TextMode="MultiLine" Style="margin-right:24px"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                            <asp:Label ID="Label22" style="margin-left:19px" runat="server" Text="Ultimate Destination:"></asp:Label>
                            <asp:TextBox ID="txtDestination" class="boe-input" runat="server" Rows="1"  TextMode="MultiLine" Width="169px"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                           <asp:Label ID="Label51" style="margin-left:17%" runat="server" Text=<abbr title="Tax Payment Date">Tax Pay Date:</abbr></asp:Label>
                            <asp:TextBox ID="txtTaxPayDate" class="boe-input" runat="server" style="width:169px; margin-right:5px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTaxPayDate"/>
                        </div>
                        <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                            <asp:Label ID="Label47" style="margin-left:74px" runat="server" Text="Remarks:"></asp:Label>
                            <asp:TextBox ID="txtMasterRemark" Rows="1" runat="server" TextMode="MultiLine" Width="169px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="test-label">
                        <asp:Label ID="Label49" runat="server" Text="Property:"></asp:Label><br />
                            <asp:DropDownList ID="drpServGoods" runat="server" class="dd" Height="27px" AutoPostBack="True" TabIndex="1">
                                <asp:ListItem>Goods</asp:ListItem>
                                <asp:ListItem>Service</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label25" runat="server" Text="Item Name:" style="margin-left:0px;"/><br />
                            <asp:DropDownList ID="drpItem" style="width:160px;background-color:#D7FBB1;height:27px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" TabIndex="2"/>
                            <asp:Label runat="server" ID="lblProductType" Visible="false"></asp:Label>
                            <asp:HiddenField ID="hdItemType" runat="server" />
                            <asp:HiddenField ID="hdBookId" runat="server" />
                            <asp:HiddenField ID="hdPageNo" runat="server" />
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label26" runat="server" Text="HS Code:"/><br />
                             <asp:TextBox ID="lblHSCode" runat="server" style="width:75px" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                             <asp:Label ID="Label27" runat="server" Text="Quantity:" style="margin-left: 11px;"/><br />
                             <asp:TextBox ID="txtQuantity" runat="server" style="width:70px;background-color:#D7FBB1" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="test-label">
                             <asp:Label ID="Label41" runat="server" Text="Unit:" style="margin-left: 0px;"/><br />
                             <asp:TextBox ID="lblUnit" runat="server" style="width:45px"></asp:TextBox>
                             <asp:Label runat="server" ID="lblUnitId" Visible="false" />
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label28" runat="server" Text="Unit Price:" style="margin-left:0px;"/><br />
                            <asp:TextBox ID="txtUnitPrice" style="width:75px;background-color:#D7FBB1" runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged" TabIndex="4"/>
                            <asp:Label ID="lblUnitPrice" runat="server" Text="" style="margin-left:0px;" Visible=false/>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVCD" runat="server" Text="CD:" style="margin-left:0px;" Visible="false"/><br />
                            <asp:TextBox ID="txtCD" style="width:50px" runat="server" AutoPostBack="True" TabIndex="5" Visible="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVRD" runat="server" Text="RD:" style="margin-left:0px;" Visible="false"/><br />
                            <asp:TextBox ID="txtRD" style="width:50px" runat="server" AutoPostBack="True" TabIndex="6" Visible="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVSD" runat="server" Text="SD:" style="margin-left:0px;" Visible="false"/><br />
                            <asp:TextBox ID="txtSD" style="width:50px" runat="server" AutoPostBack="True" TabIndex="7" Visible="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVVAT" runat="server" Text="VAT:" style="margin-left:0px;" Visible="false"/><br />
                            <asp:TextBox ID="txtVAT" style="width:50px" runat="server" AutoPostBack="True" TabIndex="8" Visible="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVaAT" runat="server" Text="AT:" style="margin-left:0px;" Visible="false"/><br />
                            <asp:TextBox ID="txtAT" style="width:50px" runat="server" AutoPostBack="True" TabIndex="9" Visible="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVAIT" runat="server" Text="AIT:" style="margin-left:0px;"  Visible="false"/><br />
                            <asp:TextBox ID="txtAIT" style="width:50px" runat="server" AutoPostBack="True" TabIndex="10"  Visible="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVATV" runat="server" Text="ATV:" style="margin-left:0px;" Visible="false"/><br />
                            <asp:TextBox ID="txtATV" style="width:50px" runat="server" AutoPostBack="True" TabIndex="11" Visible="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="lblVTTI" runat="server" Text="TTI:" style="margin-left:0px;" Visible="false"/><br />
                            <asp:TextBox ID="txtTTI" style="width:50px" runat="server" AutoPostBack="True" TabIndex="12" Visible="false"></asp:TextBox>
                        </div>
                        <div>
                        <asp:Label ID="Label44" runat="server" Text=<abbr title="Assessable Value">Assesed Value:</abbr></asp:Label><br />
                            <asp:TextBox ID="txtUnitPriceTotal" AutoPostBack="true" runat="server" style="font-size:12px;width:82px;height:26px" Font-Bold="false" Text="0.00" OnTextChanged="txtTotalPrice_TextChanged" TabIndex="13"></asp:TextBox>
                       </div>
                    </div>
                    <div class="row">
                        <div class="test-check">
                            <asp:Label ID="cd" runat="server" Text="CD:"></asp:Label>
                            <%--<asp:CheckBox ID="chkCD" runat="server" OnCheckedChanged="chkCD_CheckedChanged"/>--%>
                            <asp:CheckBox ID="chkCD" runat="server"/>
                            <asp:Label ID="lblCD" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="Label86" runat="server" Text="%"></asp:Label><br />
                        </div>
                        <div class="test-check">
                            <asp:Label ID="rd" runat="server" Text="RD:"></asp:Label>
                            <%--<asp:CheckBox ID="chkRD" runat="server" AutoPostBack="True" Enabled="true" OnCheckedChanged="chkRD_CheckedChanged" />--%>
                            <asp:CheckBox ID="chkRD" runat="server" AutoPostBack="True" Enabled="true" />
                            <asp:Label ID="lblRD" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="Label89" runat="server" Text="%"></asp:Label>
                        </div>
                        <div class="test-check">
                            <asp:Label ID="sd" runat="server" Text="SD:"></asp:Label>
                            <%--<asp:CheckBox ID="chkSD" runat="server" Enabled="true" OnCheckedChanged="chkSD_CheckedChanged" />--%>
                            <asp:CheckBox ID="chkSD" runat="server" Enabled="true"/>
                            <asp:Label ID="lblSD" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="Label84" runat="server" Text="%"></asp:Label>
                        </div>
                        <div class="test-check">
                            <asp:Label ID="vat" runat="server" Text="VAT:"></asp:Label>
                            <%--<asp:CheckBox ID="chkVAT" runat="server" AutoPostBack="true" OnCheckedChanged="chkVAT_CheckedChanged" />--%>
                            <asp:CheckBox ID="chkVAT" runat="server" AutoPostBack="true" />
                            <asp:Label ID="lblVAT" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="Label87" runat="server" Text="%"></asp:Label>
                        </div>

                        <div class="test-check">
                            <asp:Label ID="AT" runat="server" Text="AT"></asp:Label>
                            <asp:CheckBox ID="chkAT" runat="server" AutoPostBack="true" Visible="true"/>
                            <asp:Label ID="lblAT" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="lblATAAAAAA" runat="server" Text="%"></asp:Label>
                        </div>

                        <div class="test-check">
                            <asp:Label ID="ait" runat="server" Text="AIT:"></asp:Label>
                            <%--<asp:CheckBox ID="chkAIT" runat="server" AutoPostBack="true" Visible="true" OnCheckedChanged="chkAIT_CheckedChanged" />--%>
                            <asp:CheckBox ID="chkAIT" runat="server" AutoPostBack="true" Visible="true" />
                            <asp:Label ID="lblAIT" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="Label90" runat="server" Text="%"></asp:Label>
                        </div>
                        <div class="test-check">
                            <asp:Label ID="atv" runat="server" Text="ATV:"></asp:Label>
                            <%--<asp:CheckBox ID="chkATV" runat="server" OnCheckedChanged="chkATV_CheckedChanged" />--%>
                            <asp:CheckBox ID="chkATV" runat="server" />
                            <asp:Label ID="lblATV" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="Label85" runat="server" Text="%"></asp:Label>
                        </div>
                        <div class="test-check">
                            <asp:Label ID="tti" runat="server" Text=" TTI:"></asp:Label>
                            <%--<asp:CheckBox ID="chkTTI" runat="server" OnCheckedChanged="chkTTI_CheckedChanged" />--%>
                            <asp:CheckBox ID="chkTTI" runat="server" />
                            <asp:Label ID="lblTTI" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="Label88" runat="server" Text="%"></asp:Label>
                        </div>
                        <div class="test-check">
                            <asp:Label ID="lblShipment" runat="server" Visible=false></asp:Label>
                            <asp:Label ID="lblDelivery" runat="server" Visible=false></asp:Label>
                    
                             <asp:Label ID="lblRebatable" runat="server" Text="Rebatable:"></asp:Label>
                            <%--<asp:CheckBox ID="chkRebatable" runat="server" OnCheckedChanged="chkRebatable_CheckedChanged" />--%>
                            <asp:CheckBox ID="chkRebatable" runat="server" />

                             <asp:Label ID="Label53" runat="server" Text="Is Warranty:"></asp:Label>
                            <asp:CheckBox ID="chkIsWar" runat="server" />
                            <asp:Label ID="lblExempted" runat="server" Text="Exempted:" Visible="false"></asp:Label>
                            <asp:CheckBox ID="chkExempted" runat="server" Visible="false"/>
                        </div>
                        <div id="Div1" class="test-check" runat="server" visible="true">
                            <asp:Label ID="lblvds" runat="server" Text="VDS:" Visible = "false"></asp:Label>
                            <%--<asp:CheckBox ID="chkTaxDeducted" runat="server" OnCheckedChanged="chkTaxDeducted_CheckedChanged" Visible = "false"/>--%>
                            <asp:CheckBox ID="chkTaxDeducted" runat="server" Visible = "false"/>
                        </div>
                        <div class="test-check" style="margin-top: 4px;">
                           <asp:Label ID="lblvdstx" Style="margin-left: 185px; float: left;margin-top:3px" runat="server" Text="VDS Amount:" Visible="false"/>
                            <asp:TextBox ID="txtvdsamount" runat="server" CssClass="present-address-tb" Style="width: 90px;  margin-left: 3px; float: left; text-align: left;height:27px" Visible="false"></asp:TextBox>
                         </div>
                        <div class="test-check">
                            <asp:Label ID="Label93" runat="server"  Font-Size="Medium" Text="Total :"></asp:Label>
                            <asp:Label ID="lblTotal" runat="server" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="test-check">
                            <asp:Label ID="Label23" runat="server" Font-Size="Medium" Text="Total Tax :"></asp:Label>
                            <asp:Label ID="txtTotalTax" runat="server" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                       <%--<div class="test-remark">
                            <asp:Label ID="Label35" style="margin-left:15px;" runat="server" Text="Remarks :" CssClass="present-address-lbl"></asp:Label>
                            <asp:TextBox ID="singleRemarks" style="width:150px;height:27px;float: right;" runat="server" CssClass="present-address-tb" TextMode="MultiLine"></asp:TextBox>
                       </div>--%>
                       <div class="test-label">
                            <asp:Label ID="Label36" CssClass="present-address-lbl" style="margin-left:15px;" runat="server" Text=<abbr title="Document Processing Fee">DPF:</abbr></asp:Label>
                            <asp:TextBox ID="txtDPFee" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtDPFee_textChanged" AutoPostBack="true"></asp:TextBox>
                       </div>
                       <div class="test-label">
                            <asp:Label ID="Label37" CssClass="present-address-lbl" style="margin-left:15px;" runat="server" Text=<abbr title="Fines/Penalties/Other Cost">F/P:</abbr></asp:Label>
                            <asp:TextBox ID="txtOCost" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtOCost_textChanged" AutoPostBack="true"></asp:TextBox>
                       </div>
                       <div class="test-label">
                            <asp:Label ID="Label52" CssClass="present-address-lbl" style="margin-left:10px;" runat="server" Text="PSI:"></asp:Label>
                            <asp:TextBox ID="txtPSI" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtPSI_textChanged" AutoPostBack="true"></asp:TextBox>
                       </div>
                       <div class="test-label">
                            <asp:Label ID="Label38" CssClass="present-address-lbl" style="margin-left:10px;" runat="server" Text=<abbr title="Vat on C&F Commission">C&F VAT:</abbr></asp:Label>
                            <asp:TextBox ID="txtCnFVat" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtCnFVat_textChanged" AutoPostBack="true"></asp:TextBox>
                       </div>
                       <div class="test-label">
                            <asp:Label ID="Label50" CssClass="present-address-lbl"  style="margin-left:10px;" runat="server" Text=<abbr title="Income Tax C&F Commission">C&F Commission:</abbr></asp:Label>
                            <asp:TextBox ID="txtCnfCommission" CssClass="present-address-tb" runat="server" style="width:60px;height:25px;float:right" OnTextChanged="txtCnfCommissiont_textChanged" AutoPostBack="true"></asp:TextBox>
                       </div>
                       <div class="test-btn">
                            <asp:Button ID="btnSave" runat="server" class="test-btn-primary" Text="Update" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                  </div>
              </div>
              <div class="panel panel-primary" >
                            <div class="panel-body" >
                                <div class="" runat="server" id="gridviewPurchase" visible="true">
                                    <asp:GridView ID="gvImport" runat="server" AutoGenerateColumns="False" 
                                    OnSelectedIndexChanged="gvPurchase_SelectedIndexChanged" CssClass="sGrid" DataKeyNames="RowNo" Width="100%" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                           <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                            <asp:BoundField HeaderText="Challan No" DataField="ChallanNo" />
                                            <asp:BoundField HeaderText="Challan Date" DataField="ChallanDate" />
                                            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                                            <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                            <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" />
                                            <asp:BoundField HeaderText="Vatable Price" DataField="VatablePrice" />
                                            <asp:BoundField HeaderText="Vat" DataField="VAT" />
                                            <asp:BoundField HeaderText="SD" DataField="SD" />
                                            <asp:BoundField HeaderText="CD" DataField="CD" />
                                            <asp:BoundField HeaderText="RD" DataField="RD" />
                                            <asp:BoundField HeaderText="AT" DataField="AT" />
                                            <asp:BoundField HeaderText="AIT" DataField="AIT" />
                                            <asp:BoundField HeaderText="ATV" DataField="ATV" />
                                            <asp:BoundField HeaderText="TTI" DataField="TTI" />
                                            <asp:BoundField HeaderText="Exempted" DataField="IsExempted" />
                                            <asp:BoundField HeaderText="Rebatable" DataField="IsRebatable" />
                                            <asp:BoundField HeaderText="VDS" DataField="IsVDS" />
                                            <asp:BoundField HeaderText="vds amount" DataField="VDSAmount" />
                                        </Columns>
                                        <HeaderStyle Height="25px" />
                                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
        </div>
        <uc2:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>
