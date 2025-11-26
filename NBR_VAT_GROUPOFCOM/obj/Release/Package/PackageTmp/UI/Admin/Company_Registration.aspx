<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Company_Registration, App_Web_bxnrqbtx" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            width: 164px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input">
            <tr>
                <td class="page_title" colspan="5">
                    Company Registration<uc1:admin ID="admin" runat="server" /></td>
            </tr>
            <tr>
                <td valign="top" style="text-align: right">
                    <asp:Label ID="Label1" runat="server" 
                        Text="Name of Organization / Individual :"></asp:Label>
                </td>
                <td valign="top" style="text-align: left" colspan="2">
                    <asp:TextBox ID="txtOrganizationName" runat="server" Width="150px" MaxLength="40" 
                        Rows="1"></asp:TextBox>
                </td>
                <td valign="top" style="text-align: right" class="style1">
                <asp:Label ID="Label69" runat="server" Text="Short Name :"></asp:Label>
                </td>
                <td valign="top" style="text-align: left">
                    <asp:TextBox ID="txtAbbrName" runat="server" Width="150px" MaxLength="40" 
                        Rows="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                    <asp:Label ID="Label8" runat="server" Text="Type of Organization :"></asp:Label>
                </td>
                <td valign="top" colspan="4">
                    <asp:RadioButton ID="rdoOrgTypeCorporatePrivat" runat="server" GroupName="OrgType" 
                        Text="Corporate (Private)" Checked="True" />
                    <asp:RadioButton ID="rdoOrgTypeCorporatePublic" runat="server" GroupName="OrgType" 
                        Text="Corporate (Public)" />
                    <asp:RadioButton ID="rdoOrgTypePartnership" runat="server" GroupName="OrgType" 
                        Text="Partnership" />
                    <asp:RadioButton ID="rdoOrgTypeProprietorship" runat="server" GroupName="OrgType" 
                        Text="Proprietorship" />
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                    <asp:Label ID="Label2" runat="server" 
                        Text="Name of Corporate or Group (if applicable) :"></asp:Label>
                </td>
                <td valign="top" colspan="2">
                    <asp:TextBox ID="txtCorporateName" runat="server" Rows="1" 
                    Width="150px"></asp:TextBox>
                </td>
                <td valign="top" style="text-align: right">
                <asp:Label ID="Label71" runat="server" Text="Registration Effective Date :"></asp:Label>
                </td>
                <td valign="top">
                <ww:jQueryDatePicker ID="dtRegistrationEffectiveDate" runat="server" Width="128px"></ww:jQueryDatePicker>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                <asp:Label ID="Label74" runat="server" Text="VAT Commissionerate :"></asp:Label>
                </td>
                <td valign="top" colspan="2">
                                    <asp:DropDownList ID="ddlVATCommissionerate" runat="server" 
                        Width="150px" 
                        onselectedindexchanged="ddlVATCommissionerate_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                </td>
                <td valign="top" align="right">
                <asp:Label ID="Label73" runat="server" Text="VAT Division :"></asp:Label>
                </td>
                <td valign="top">
                                    <asp:DropDownList ID="ddlVATDivision" runat="server" 
                        Width="150px" 
                        onselectedindexchanged="ddlVATDivision_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                <asp:Label ID="Label75" runat="server" Text="VAT Circle :"></asp:Label>
                </td>
                <td valign="top" colspan="2">
                                    <asp:DropDownList ID="ddlVATCircle" runat="server" 
                        Width="150px" 
                        onselectedindexchanged="ddlVATCircle_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                </td>
                <td valign="top" align="right">
                <asp:Label ID="Label76" runat="server" Text="VAT Area :"></asp:Label>
                </td>
                <td valign="top">
                                    <asp:DropDownList ID="ddlVATArea" runat="server" 
                        Width="150px">
                                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                <asp:Label ID="lblRegistrationType" runat="server" Text="Type of Registration :"></asp:Label>
                </td>
                <td valign="top" colspan="2">
                    <asp:RadioButton ID="rdoRegTypeCentral" runat="server" GroupName="RegistrationType" 
                        Text="Central (Franchise)" 
                        oncheckedchanged="rdoRegTypeCentral_CheckedChanged" AutoPostBack="True" />
                    <asp:RadioButton ID="rdoRegTypeUnit" runat="server" GroupName="RegistrationType" 
                        Text="Unit" Checked="True" 
                        oncheckedchanged="rdoRegTypeUnit_CheckedChanged" AutoPostBack="True" />
                </td>
                <td valign="top" align="right">
                                    <asp:Label ID="lblParentOrganization" runat="server" 
                        Text="Parent Organization :"></asp:Label>
                </td>
                <td valign="top">
                                    <asp:DropDownList ID="ddlParentOrganization" runat="server" 
                        Width="150px">
                                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                <asp:Label ID="Label36" runat="server" Text="TIN of Chairman/Director/Proprietor :"></asp:Label>
                </td>
                <td valign="top" colspan="2">
                <asp:TextBox ID="txtTINChairman" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td valign="top" class="style1">
                <asp:Label ID="Label64" runat="server" Text="TIN of Company (if any) :"></asp:Label>
                </td>
                <td valign="top">
                <asp:TextBox ID="txtTINCompany" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                    <asp:Label ID="Label7" runat="server" 
                        Text="Previous Registration No. (if any) :"></asp:Label>
                </td>
                <td valign="top" colspan="2">
                <asp:TextBox ID="txtPreviousRegNo" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td valign="top" class="style1">
                    <asp:Label ID="Label63" runat="server" 
                        Text="National ID No. of Chairman :"></asp:Label>
                </td>
                <td valign="top">
                <asp:TextBox ID="txtNationalIDChairman" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                    <asp:Label ID="Label77" runat="server" 
                        Text="BIN/Registration No. :"></asp:Label>
                </td>
                <td valign="top" colspan="2">
                                    <asp:TextBox ID="txtRegTypeBIN" runat="server" Width="150px" 
                                        ToolTip="Format : 99 99 9 99999 9"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="txtRegTypeBINMask" runat="server" TargetControlID = "txtRegTypeBIN" Mask="99$99$9$99999$9" ></ajaxToolkit:MaskedEditExtender>
                                  <%-- <ajaxToolkit:MaskedEditValidator ID="txtRegTypeBINMaskValid" runat="server" ControlExtender="txtRegTypeBINMask" 
                                   ControlToValidate="txtRegTypeBIN" ValidationExpression="^\d{2}\s\d{2}\s\d{1}\s\d{5}\s\d{1}"></ajaxToolkit:MaskedEditValidator>--%>
                </td>
                <td valign="top" class="style1">
                    &nbsp;</td>
                <td valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                    <asp:Label ID="Label78" runat="server" 
                        Text="Business Activities : "></asp:Label>
                </td>
                <td valign="top" colspan="4">
                                    <asp:TextBox ID="txtBusinessActivities" runat="server" 
                        Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" valign="top">
                    <asp:Label ID="Label79" runat="server" 
                        Text="Business Type :"></asp:Label>
                </td>
                <td valign="top" colspan="4">
                                    <asp:TextBox ID="txtBusinessType" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="5">
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" 
                        class="brd_tbl_input">
        <tr>
            <td class="page_sub_title" colspan="3">
                Taxpayer Classification</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label50" runat="server" Text="Tax Category " 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td valign="top" class="style2">
                    <asp:Label ID="Label51" runat="server" Text="Taxpayer Type" 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td class="input_field">
                    <asp:Label ID="Label52" runat="server" Text="Other Information" 
                    CssClass="lebel_title"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                    <asp:RadioButton ID="rdoTCVAT" runat="server" GroupName="TaxCategory" 
                        Text="VAT" Checked="True" AutoPostBack="True" 
                        oncheckedchanged="rdoTCVAT_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="rdoTCTurnoverTax" runat="server" GroupName="TaxCategory" 
                        Text="Turnover Tax" AutoPostBack="True" 
                        oncheckedchanged="rdoTCTurnoverTax_CheckedChanged" />
                    <br />
&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdoTCQuarterly" runat="server" GroupName="TurnoverTaxCategory" 
                        Text="Quarterly" Enabled="False" 
                        oncheckedchanged="rdoTCQuarterly_CheckedChanged" />
                    <asp:RadioButton ID="rdoTCMonthly" runat="server" GroupName="TurnoverTaxCategory" 
                        Text="Monthly" Checked="True" Enabled="False" 
                        oncheckedchanged="rdoTCMonthly_CheckedChanged" />
                    <asp:RadioButton ID="rdoTCYearly" runat="server" GroupName="TurnoverTaxCategory" 
                        Text="Yearly" Enabled="False" 
                        oncheckedchanged="rdoTCYearly_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="rdoTCCottageIndustry" runat="server" GroupName="TaxCategory" 
                        Text="Cottage Industry" AutoPostBack="True" 
                        oncheckedchanged="rdoTCCottageIndustry_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="rdoTCOther" runat="server" GroupName="TaxCategory" 
                        Text="Other" AutoPostBack="True" 
                        oncheckedchanged="rdoTCOther_CheckedChanged" />
            </td>
            <td valign="top" class="style2">
                    <asp:CheckBox ID="chkSupplierManufacturer" runat="server" 
                        Text="Supplier (Manufacturer)" Checked="True" />
                    <br />
                    <asp:CheckBox ID="chkSupplierTrader" runat="server" Text="Supplier (Trader)" />
                    <br />
                    <asp:CheckBox ID="chkServiceRenderer" runat="server" Text="Service Renderer" />
                    <br />
                    <asp:CheckBox ID="chkImporter" runat="server" Text="Importer" />
                    <br />
                    <asp:CheckBox ID="chkExporter" runat="server" Text="Exporter" />
            </td>
            <td>
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" 
                        class="brd_tbl_input">
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label53" runat="server" Text="Trade License No. :"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTradeLicenseNo" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label54" runat="server" Text="Authority :"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtAuthority" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label55" runat="server" Text="Fiscal Year From :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="dtFiscalYearFrom" runat="server" Width="70px"></ww:jQueryDatePicker>
            </td>
            <td>
                <asp:Label ID="Label70" runat="server" Text="To :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="dtFiscalYearTo" runat="server" Width="70px"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label56" runat="server" Text="Import Reg. No. :"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtImportRegNo" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top" style="text-align: right">
                <asp:Label ID="Label57" runat="server" Text="Export Reg. No. :"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtExportRegNo" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        </table>
            </td>
        </tr>
        </table>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="5">
                    <table align="center">
                        <tr>
                            <td>
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" 
                        class="brd_tbl_input">
        <tr>
            <td class="page_sub_title" colspan="2">
                Business Address</td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label27" runat="server" Text="Address :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBAddress" runat="server" Rows="2" TextMode="MultiLine" 
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label28" runat="server" Text="Phone # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBPhone" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label29" runat="server" Text="Fax # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBFax" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label30" runat="server" Text="Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBEmail" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        </table>
                            </td>
                            <td>
    <table align="left" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" 
                        class="brd_tbl_input">
        <tr>
            <td class="page_sub_title" colspan="2">
                Factory Address</td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label19" runat="server" Text="Address :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFAddress" runat="server" Rows="2" TextMode="MultiLine" 
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label20" runat="server" Text="Phone # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFPhone" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label21" runat="server" Text="Fax # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFFax" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label22" runat="server" Text="Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFEmail" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" 
                        class="brd_tbl_input">
        <tr>
            <td class="page_sub_title" colspan="2">
                Head Office Address (if any)</td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label23" runat="server" Text="Address :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtHOAddress" runat="server" Rows="2" TextMode="MultiLine" 
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label24" runat="server" Text="Phone # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtHOPhone" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label25" runat="server" Text="Fax # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtHOFax" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label26" runat="server" Text="Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtHOEmail" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        </table>
                            </td>
                            <td>
    <table align="left" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" 
                        class="brd_tbl_input">
        <tr>
            <td class="page_sub_title" colspan="2">
                Permanent Address of the Chairman/MD/Proprietor</td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label31" runat="server" Text="Address :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPAddress" runat="server" Rows="2" TextMode="MultiLine" 
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label32" runat="server" Text="Phone # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPPhone" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label33" runat="server" Text="Fax # :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPFax" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label34" runat="server" Text="Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPEmail" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <hr /></td>
            </tr>
            <tr>
                <td colspan="2">
                <asp:Label ID="lblOrganizationName" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="text-align: right" colspan="3">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" 
                    onclick="btnSave_Click" Text="Save" />
                    <asp:Button ID="btnRefresh" runat="server" CssClass="button" 
                    onclick="btnRefresh_Click" Text="Refresh" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <br />
                </td>
            </tr>
        </table>
        <br />
                    <asp:Panel ID="pnlRegistrationType" runat="server" 
            CssClass="brd_tbl_input" Visible="False">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label66" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegTypeUnitName" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label67" runat="server" Text="Address :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRegTypeAddress" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label68" runat="server" Text="BIN :"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" CssClass="button" onclick="btnAdd_Click" 
                                        Text="Add" />
                                    <asp:Button ID="btnRefreshRegistrationType" runat="server" CssClass="button" 
                                        onclick="btnRefreshRegistrationType_Click" Text="Refresh" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gvRegistrationType" runat="server" 
                                        AutoGenerateColumns="False" onrowcommand="gvRegistrationType_RowCommand" 
                                        onrowdatabound="gvRegistrationType_RowDataBound" 
                                        onrowdeleting="gvRegistrationType_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:BoundField DataField="bin" HeaderText="BIN" SortExpression="bin" />
                                            <asp:CommandField ShowSelectButton="True" />
                                            <asp:CommandField ShowDeleteButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
        <br />
    </div>

    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

