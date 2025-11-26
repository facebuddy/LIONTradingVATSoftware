<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="SaleChallan_6_3, App_Web_lqwzozjx" maintainscrollpositiononpostback="false" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register src="../../UserControls/Sale.ascx" tagname="sale" tagprefix="uc1" %>--%>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
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
                <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold;
                    height: 30px; padding-top: 0px">
                    Sale Challan / কর চালানপত্র (মূসক-৬.৩)</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="background-color: #E0EBF5">
                        <div class="col-sm-4" style="padding-top: 0px">
                            <div class="col-sm-3" style="padding-top: 0px">
                                <asp:Label ID="Label1" Style="margin-left: 66%" runat="server" Text="Name:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding-top: 0px">
                                <asp:Literal ID="lt_companyName" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding-top: 0px">
                            <div class="col-sm-3" style="padding-top: 0px">
                                <asp:Label ID="Label2" Style="margin-left: 32%" runat="server" Text="Address:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding-top: 0px">
                                <asp:Literal ID="It_companyAddress" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding-top: 0px">
                            <div class="col-sm-3" style="padding-top: 0px">
                                <asp:Label ID="Label8" Style="margin-left: 74%" runat="server" Text="BIN:"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding-top: 0px">
                                <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <%-- <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>--%>
                            <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px">
                            </asp:DropDownList>
                            <asp:Label ID="lblOrgAddress" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                    <%-- **********************************Party part**************************** --%>
                    <div class="row" style="margin-top: 5px; background-color: #E0EBF5">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label26" CssClass="present-address-lbl" Style="margin-left: 24%" runat="server"
                                    Text="Branch Name:">
                                </asp:Label></div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:DropDownList ID="drpBranchName" runat="server" Style="margin-left: 11px; height: 27px;
                                    text-align: left" CssClass="present-address-tb" AutoPostBack = "true" 
                                    onselectedindexchanged="drpBranchName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label28" runat="server" Style="margin-left: 11%" CssClass="present-address-lbl"
                                    Text="Branch Address:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px; margin-left: 36px">
                                <asp:Label ID="Label34" Style="margin-left: 42%; margin-top: 4px" CssClass="present-address-lbl"
                                    runat="server" Text="BIN:"></asp:Label></div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 5px">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label3" CssClass="present-address-lbl" Style="margin-left: 72%" runat="server"
                                    Text="Name:">
                                </asp:Label></div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:DropDownList ID="drpParty" runat="server" Style="margin-left: 11px; height: 27px;
                                    text-align: left" CssClass="present-address-tb" AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Button ID="btnAddParty" runat="server" Style="float: left; margin-left: 11px"
                                    OnClick="btnAddParty_Click" Text="New" Width="60px" />
                            </div>
                            <br />
                            <asp:TextBox ID="txtPartyName" runat="server" Visible="False" Style="width: 42%;
                                height: 27px; margin-left: 27%" class="present-address-tb"></asp:TextBox>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label4" runat="server" Style="margin-left: 20%" CssClass="present-address-lbl"
                                    Text="Party Address:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox class="present-address-tb" ID="txtAddress" runat="server" Style="height: 27px;
                                    width: 75%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label12" Style="margin-left: 42%; margin-top: 4px" CssClass="present-address-lbl"
                                    runat="server" Text="Party BIN:"></asp:Label></div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:TextBox ID="txtPartyBIN" runat="server" CssClass="present-address-tb" Style="width: 221%;
                                    height: 27px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 5px">
                        <div class="col-sm-4">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label30" CssClass="present-address-lbl" Style="margin-left: 11%;"
                                    runat="server" Text="DO/Challan No:"></asp:Label>
                            </div>
                            <div class="col-sm-6" style="padding: 0px">
                                <asp:TextBox ID="txtChallanNo" CssClass="present-address-tb" runat="server" Style="width: 88%;
                                    height: 27px" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:CheckBox ID="chkDiscard" Style="margin-left: -16px" runat="server" AutoPostBack="True"
                                    OnCheckedChanged="chkDiscard_CheckedChanged" Text="Discard" />
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblDiscardReason" CssClass="present-address-lbl" Style="margin-left: 13px"
                                    runat="server" Text="Discard Reason:" Visible="False"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpDiscardReason" CssClass="present-address-tb" runat="server"
                                    Style="width: 75%; height: 27px" Visible="False">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <div class="col-sm-5" style="padding: 0px">
                                </div>
                            </div>
                        </div>
                        <%--<div class="col-sm-4" style="padding:0px">
                <div class="col-sm-3" style="padding:0px"><asp:Label ID="Label28" runat="server" style="margin-left:20%" CssClass="present-address-lbl" Text="Party Address:"></asp:Label></div>
                <div class="col-sm-9" style="padding:0px">
                <asp:TextBox class="present-address-tb" ID="TextBox3" runat="server" style="height:27px;width:75%"></asp:TextBox>
                </div>
             </div>--%>
                        <%--<div class="col-sm-4" style="padding:0px">
               <div class="col-sm-3" style="padding:0px"><asp:Label ID="Label34" style="margin-left:42%; margin-top:4px" CssClass="present-address-lbl" runat="server" Text="Party BIN:"></asp:Label></div>
               <div class="col-sm-3" style="padding:0px">
               <asp:TextBox ID="TextBox4" runat="server" CssClass="present-address-tb" style="width:221%; height:27px"></asp:TextBox>
               </div>
            </div>--%>
                    </div>
                    <%--************************************ --%>
                    <div class="row" style="margin-top: 5px">
                        <div class="col-sm-4">
                        </div>
                    </div>
                    <%--************************************************* --%>
                    <div class="row" style="margin-top: 5px">
                        <div class="col-sm-4">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label32" CssClass="present-address-lbl" runat="server" Style="margin-left: 23%"
                                    Text="Challan Date:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <div class="col-sm-5" style="padding: 0px">
                                    <asp:TextBox ID="txtChallanDate" CssClass="present-address-tb" runat="server" Style="width: 73%;
                                        margin-left: 5px; height: 27px" DateFormat="dd/MM/yyyy" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-sm-2" style="padding: 0px">
                                    <asp:DropDownList ID="drpChDtHr" CssClass="present-address-tb" runat="server" Style="width: 88%;
                                        height: 27px; margin-left: -33px" ReadOnly="true" AutoPostBack="True" OnSelectedIndexChanged="drpChDtHr_SelectedIndexChanged"
                                        Enabled="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2" style="padding: 0px">
                                    <asp:DropDownList ID="drpChDtMin" CssClass="present-address-tb" runat="server" Style="width: 45px;
                                        height: 27px; margin-left: -39px" ReadOnly="true" Enabled="false" AutoPostBack="True"
                                        OnSelectedIndexChanged="drpChDtMin_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%--<div class="col-sm-4">
               <div class="col-sm-3"><asp:Label ID="Label32" CssClass="present-address-lbl" runat="server" style="margin-left:11px" Text="Challan Date:"></asp:Label></div>
               <div class="col-sm-9">
               <asp:TextBox ID="txtChallanDate" CssClass="present-address-tb" runat="server" style="width:80px; margin-left:2px" DateFormat="dd/MM/yyyy" ReadOnly="true"></asp:TextBox>
               <asp:TextBox ID="drpChDtHr" CssClass="present-address-tb" runat="server" style="width:40px;" ReadOnly="true" AutoPostBack="True" Enabled="false">
               </asp:TextBox>
               <asp:TextBox ID="drpChDtMin" CssClass="present-address-tb" runat="server" style="width:40px;" ReadOnly="true" Enabled="false" AutoPostBack="True">
               </asp:TextBox>
               </div>
            </div>--%>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label33" CssClass="present-address-lbl" Style="margin-left: 29px;"
                                    runat="server" Text="Delivery Date:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <div class="col-sm-4" style="padding: 0px">
                                    <ww:jQueryDatePicker ID="txtDeliveryDate" CssClass="present-address-tb" runat="server"
                                        Style="width: 120%; height: 27px" DateFormat="dd/MM/yyyy" OnTextChanged="txtDeliveryDate_TextChanged"></ww:jQueryDatePicker>
                                </div>
                                <div class="col-sm-2" style="padding: 0px">
                                    <asp:DropDownList ID="drpDlDtHr" CssClass="present-address-tb" runat="server" Style="width: 105%;
                                        height: 27px; margin-left: 51%" OnSelectedIndexChanged="drpDlDtHr_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2" style="padding: 0px">
                                    <asp:DropDownList ID="drpDlDtMin" CssClass="present-address-tb" runat="server" Style="width: 101%;
                                        height: 27px; margin-left: 57%" OnSelectedIndexChanged="drpDlDtMin_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label CssClass="present-address-lbl" Style="margin-left: 24px" ID="Label5" runat="server"
                                    Text="Ultimate Dest:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox CssClass="present-address-tb" Style="width: 74%; height: 27px" ID="txtDestination"
                                    runat="server"></asp:TextBox></div>
                        </div>
                    </div>
                    <%-- *************************************Chalan Date Time***************************--%>
                    <div class="row" style="margin-top: 5px">
                        <div class="col-sm-4">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label29" CssClass="present-address-lbl" Style="margin-left: 41px"
                                    runat="server" Text="Sale Type:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpSaleType" CssClass="present-address-tb" runat="server" Style="width: 59%;
                                    text-align: left; margin-left: 4px; height: 27px">
                                    <asp:ListItem Selected="True">WholeSale</asp:ListItem>
                                    <asp:ListItem>Retail</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label31" CssClass="present-address-lbl" Style="margin-left: 7px" runat="server"
                                    Text="Transaction Type:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpTransaction" CssClass="present-address-tb" runat="server"
                                    Style="width: 75%; height: 27px" AutoPostBack="true" OnSelectedIndexChanged="drpTransaction_CheckedChanged">
                                    <asp:ListItem Selected="True">Local</asp:ListItem>
                                    <asp:ListItem>Export</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:DropDownList ID="drpTransaction2" CssClass="present-address-tb" runat="server"
                                Style="margin-left: 26%; width: 56%; height: 27px">
                                <asp:ListItem  Value="S">Service</asp:ListItem>
                                <asp:ListItem Selected="True" Value="G">Goods</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 5px">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label27" CssClass="present-address-lbl" Style="margin-left: 29%" runat="server"
                                    Text="Vehicle Type:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpVehicleType" CssClass="present-address-tb" runat="server"
                                    Style="width: 55%; margin-left: 3%; height: 27px; text-align: left">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label35" CssClass="present-address-lbl" Style="margin-left: 42px;"
                                    runat="server" Text="Vehicle No:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox ID="txtVehicleNo" CssClass="present-address-tb" runat="server" Style="margin-left: 5px;
                                    height: 27px; width: 75%"></asp:TextBox></div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label14" CssClass="present-address-lbl" Style="margin-left: 51px"
                                    runat="server" Text="Remarks:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox ID="txtRemarks" CssClass="present-address-tb" runat="server" Style="width: 74%;
                                    margin-left: 7px; height: 27px"></asp:TextBox></div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 5px">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblExpDt" Style="margin-left: 35px" CssClass="present-address-lbl"
                                    runat="server" Text="Export Date:" Visible="False"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <ww:jQueryDatePicker ID="txtExportDate" CssClass="present-address-tb" runat="server"
                                    DateFormat="dd/MM/yyyy" OnTextChanged="txtChallanDate_TextChanged" Style="width: 180px;
                                    height: 27px; margin-left: 11px" Visible="False"></ww:jQueryDatePicker>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblExpBillNo" CssClass="present-address-lbl" Style="margin-left: 24px"
                                    runat="server" Text="Export Bill No:" Visible="False"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox ID="txtExpBillNo" CssClass="present-address-tb" runat="server" Style="width: 180px;
                                    margin-left: 5px; height: 27px" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-2" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBank" CssClass="present-address-lbl" Style="margin-left: 20px"
                                    runat="server" Text="Bank:" Visible="False"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpBank" CssClass="present-address-tb" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="drpBank_SelectedIndexChanged" Style="width: 145px; height: 27px"
                                    Visible="False">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="lblBranch" CssClass="present-address-lbl" runat="server" Text="Branch:"
                                    Visible="False"></asp:Label>
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:DropDownList ID="drpBranch" CssClass="present-address-tb" runat="server" Style="width: 145px;
                                    height: 27px" Visible="False">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <asp:HiddenField ID="hdPriceID" runat="server" />
                            <asp:HiddenField ID="hdUnitSDAmt" runat="server" />
                            <asp:HiddenField ID="hdUnitVATAmt" runat="server" />
                        </div>
                    </div>
                    <div class="row" style="margin-top: 0px">
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label runat="server" Text="Instalment:" CssClass="present-address-lbl" Style="margin-left: 41%" />
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox runat="server" ID="txtInstallment" CssClass="present-address-tb" Style="width: 55%;
                                    margin-left: 3%" />
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label25" runat="server" Text="Discount:" CssClass="present-address-lbl"
                                    Style="margin-left: 41%" />
                            </div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:TextBox runat="server" ID="TextBox1" CssClass="present-address-tb" Style="width: 75%;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="test-label">
                                <asp:Label ID="Label7" runat="server" Text="Category :"></asp:Label><br />
                                <asp:DropDownList ID="drpCategory" CssClass="present-address-tb" runat="server" Style="width: 160px;
                                    height: 27px; margin-left: 0px; text-align: left" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                    AutoPostBack="True" TabIndex="1">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label15" runat="server" Text="Sub Cat:"></asp:Label><br />
                                <asp:DropDownList ID="drpSubCategory" CssClass="present-address-tb" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                                    Style="width: 160px; height: 27px; margin-left: 0px; text-align: left" TabIndex="2">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label40" runat="server" Text="Search Product:" /><br />
                                <asp:TextBox ID="productName" CssClass="present-address-tb" AutoPostBack="true" Style="width: 160px;
                                    height: 27px; margin-left: 0px; text-align: left" placeholder="Search Product"
                                    runat="server" OnTextChanged="productName_TextChanged" TabIndex="3" />
                                <div id="listPlacement" style="height: 100px; overflow: scroll;">
                                </div>
                                <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName"
                                    ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement" MinimumPrefixLength="1"
                                    EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetSaleProductByProductName">
                                </ajaxToolkit:AutoCompleteExtender>
                                <%--<ajaxToolkit:AutoCompleteExtender runat="server" ID="accProductName" TargetControlID="productName"
                     ServiceMethod="GetProductByProductName" ServicePath="~/WebService.asmx" MinimumPrefixLength="1"
                     CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement"
                     CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                     DelimiterCharacters=";, :" ShowOnlyCurrentWordInCompletionListItem="true">
                </ajaxToolkit:AutoCompleteExtender>--%>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label16" runat="server" Text="Item Name:" Style="margin-left: 0px;" /><br />
                                <asp:DropDownList ID="drpItem" CssClass="present-address-tb" Style="width: 160px;
                                    margin-left: 0px; text-align: left" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged"
                                    Height="27px" TabIndex="4" />
                                <asp:Label runat="server" ID="lblProductType" Visible="false" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                <asp:TextBox ID="lblHSCode" CssClass="present-address-tb" runat="server" Style="width: 75px;
                                    height: 27px; margin-left: 0px" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label18" runat="server" Text="Quantity:" Style="margin-left: 11px;" /><br />
                                <asp:TextBox ID="txtQuantity" CssClass="present-address-tb" Style="height: 27px;
                                    width: 75px; margin-left: 0px" runat="server" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"
                                    TabIndex="5"></asp:TextBox>
                                <asp:Label ID="Label13" Style="margin-left: -60px" runat="server" Text="Avail Stock:"></asp:Label>
                                <asp:Label ID="lblAvailStock" runat="server"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label41" runat="server" Text="Unit:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="lblUnit" CssClass="present-address-tb" runat="server" Style="width: 35px;
                                    height: 27px; margin-left: 0px" TabIndex="6"></asp:TextBox>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label22" runat="server" Text="Unit Price:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtUnitPrice" CssClass="present-address-tb" Style="width: 75px;
                                    height: 27px; margin-left: 0px" runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged"
                                    TabIndex="7" />
                                <asp:Label ID="lblUnitPrice" runat="server" Text="" Style="margin-left: 0px;" Visible="false" />
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label42" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="tbTotalVAT" CssClass="present-address-tb" Style="width: 55px; height: 27px;
                                    margin-left: 0px" runat="server" AutoPostBack="True" TabIndex="8"></asp:TextBox>
                                <asp:Label ID="lblVAT" runat="server" Text="" /><asp:Label ID="Label9" runat="server"
                                    Text="%"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="Label43" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                <asp:TextBox ID="txtTotalSD" CssClass="present-address-tb" Style="width: 55px; height: 27px;
                                    margin-left: 0px" runat="server" AutoPostBack="True" TabIndex="9"></asp:TextBox>
                                <asp:Label ID="lblSD" runat="server" Text="" /><asp:Label ID="Label11" runat="server"
                                    Text="%"></asp:Label>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblVDS" runat="server" Text="VDS:" Style="margin-left: 0px;" Visible="false" /><br />
                                <asp:TextBox ID="txtVDS" CssClass="present-address-tb" Style="width: 55px; height: 27px;
                                    margin-left: 0px" Visible="false" runat="server" AutoPostBack="True" TabIndex="10"></asp:TextBox>
                            </div>
                            <div style="text-align: right; float: left; font-size: 14px; margin-left: 2px; border: 1px solid #ff00ff">
                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="Sub Total:" />
                                <asp:Label ID="lblTotalPrice" runat="server" Style="font-size: 12px;" Font-Bold="false"
                                    Text="0.00" /><br />
                                <asp:Label ID="Label37" runat="server" Text="VAT Amount:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblTotalVAT" runat="server" Style="font-size: 12px; margin-right: 0px"
                                    Text="0.00" Font-Bold="false"></asp:Label><br />
                                <asp:Label ID="Label24" runat="server" Text="SD Amount:" Font-Bold="True" />
                                <asp:Label ID="lblTotalSD" runat="server" Style="font-size: 12px; margin-right: 0px"
                                    Text="0.00" Font-Bold="false" /><br />
                                <asp:Label ID="Label44" runat="server" Font-Bold="True" Text="Total Price:"></asp:Label>
                                <asp:Label ID="lblTotalSalePrc" runat="server" Style="font-size: 12px;" Font-Bold="false"
                                    Text="0.00"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 1%">
                            <div class="test-label">
                                <asp:Label ID="lblProp11" runat="server" Text="Color:" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="drpProp11" CssClass="present-address-tb" Style="margin-left: 0px;
                                    width: 120px; height: 27px" runat="server" Visible="false" AutoPostBack="True"
                                    OnSelectedIndexChanged="drpProp1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblProp22" runat="server" Text="Company:" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="drpProp22" CssClass="present-address-tb" Style="margin-left: 0px;
                                    width: 120px; height: 27px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp2_SelectedIndexChanged"
                                    Visible="false">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblProp33" runat="server" Font-Bold="False" Text="Grade:" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="drpProp33" CssClass="present-address-tb" Style="margin-left: 0px;
                                    width: 120px; height: 27px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp3_SelectedIndexChanged"
                                    Visible="false">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblProp44" runat="server" Text="Size:" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="drpProp44" CssClass="present-address-tb" Style="margin-left: 0px;
                                    width: 120px; height: 27px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp4_SelectedIndexChanged"
                                    Visible="false">
                                </asp:DropDownList>
                            </div>
                            <div class="test-label">
                                <asp:Label ID="lblProp55" runat="server" Text="Spacification:" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="drpProp55" CssClass="present-address-tb" Style="margin-left: 0px;
                                    width: 120px; height: 27px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"
                                    Visible="false">
                                </asp:DropDownList>
                            </div>
                            <div class="test-check">
                                <asp:Label ID="Label23" runat="server" Visible="false"></asp:Label><br />
                                <asp:CheckBox ID="chkTaxDeducted" runat="server" OnCheckedChanged="chkTaxDeducted_CheckedChanged"
                                    Text="VDS" AutoPostBack="true" />
                            </div>
                            <div class="test-check">
                                <asp:Label ID="Label21" runat="server" Visible="false"></asp:Label><br />
                                <asp:CheckBox ID="chkExempted" runat="server" Text="Exempted" AutoPostBack="True"
                                    Enabled="False" OnCheckedChanged="chkExempted_CheckedChanged" />
                            </div>
                            <div class="test-check">
                                <asp:Label ID="Label19" runat="server" Visible="false"></asp:Label><br />
                                <asp:CheckBox ID="chkRebatable" runat="server" Enabled="False" Text="Rebatable" />
                            </div>
                            <div class="test-check">
                                <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label><br />
                                <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" AutoPostBack="true"
                                    OnCheckedChanged="chkZeroRate_CheckedChanged" Visible="false" />
                            </div>
                            <div class="test-check">
                                <asp:Label runat="server" Visible="false"></asp:Label><br />
                                <asp:CheckBox ID="chkInexplicitExport" runat="server" AutoPostBack="true" Text="Deemed Export"
                                    Visible="false" OnCheckedChanged="chkInexplicitExport_CheckedChanged" />
                            </div>
                            <div>
                                <asp:Label ID="Label10" Style="margin-left: 15px; float: left;" runat="server" Text="Remarks:"></asp:Label><br />
                                <asp:TextBox ID="singleRemarks" TextMode="MultiLine" runat="server" Style="float: left;
                                    width: 250px; text-align: left" CssClass="present-address-tb"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 1%">
                            <%--<div class="test-check">
                <asp:CheckBox ID="chkTaxDeducted" runat="server" OnCheckedChanged="chkTaxDeducted_CheckedChanged" Text="VDS" />
            </div>
            <div class="test-check">
                <asp:CheckBox ID="chkExempted" runat="server" Text="Exempted" AutoPostBack="True"
                    Enabled="False" OnCheckedChanged="chkExempted_CheckedChanged" />
            </div>
            <div class="test-check">
                <asp:CheckBox ID="chkRebatable" runat="server" Enabled="False" Text="Rebatable" />
            </div>
            <div class="test-check">
                <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" AutoPostBack="true"
                    OnCheckedChanged="chkZeroRate_CheckedChanged" Visible="false" />
            </div>
            <div class="test-check">
                <asp:CheckBox ID="chkInexplicitExport" runat="server" AutoPostBack="true" Text="Deemed Export"
                                Visible="false" OnCheckedChanged="chkInexplicitExport_CheckedChanged" />
            </div>
           <div>
                 <asp:Label ID="Label10" style="margin-left: 15px; float: left;" runat="server" Text="Remarks :"></asp:Label>
                 <asp:TextBox ID="singleRemarks" TextMode="MultiLine" runat="server" style="float:left; width:250px" CssClass="present-address-tb"></asp:TextBox>
           </div>--%>
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
                                <%--<asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>--%>
                            </div>
                            <div class="test-btn">
                                <asp:Button ID="btnSave" runat="server" class="test-btn-primary" Text="Save" OnClick="btnSave_Click" />
                            </div>
                            <div class="test-btn">
                                <asp:Button ID="btnClear" runat="server" class="test-btn-primary" OnClick="btnClear_Click"
                                    Text="Clear" />
                            </div>
                        </div>
                        <div class="row" style="margin-top: 1%">
                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                            <uc2:MsgBox ID="msgBox" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="">
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                            DataKeyNames="RowNo" Width="100%"  OnRowDeleting="gvItem_RowDeleting">
                            <Columns>
                                
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
                                <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" />
                                <asp:BoundField HeaderText="SD" DataField="SD" />
                                <asp:BoundField HeaderText="VAT" DataField="VAT" />
                                <asp:BoundField DataField="TotalSalePrice" HeaderText="Total Sale Price" />
                                <asp:BoundField HeaderText="VDS" DataField="IsSrcTAXDeduct" />
                                <asp:BoundField HeaderText="Exempted" DataField="IsExempted" />
                                <asp:BoundField HeaderText="Deemed Exp" DataField="isInexplicitExport" />
                                <asp:BoundField HeaderText="Trns Type" DataField="TransactionType" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                            </Columns>
                            <HeaderStyle Height="25px" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                        </asp:GridView>
                    </div>
                </div>
                <asp:Button ID="btnPrint" CssClass="btn btn-info" runat="server" Style="float: right;
                    margin: 5px" AutoPostBack="True" Text="Report" OnClick="btnPrint_Click"></asp:Button>
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
                    </td></div>
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
</asp:Content>
