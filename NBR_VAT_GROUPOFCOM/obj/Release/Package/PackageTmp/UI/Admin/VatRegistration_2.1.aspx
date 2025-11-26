<%@ page title="Organization Setup" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="VatRegistration, App_Web_z1w3wddp" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <style type="text/css">
    hr {
        padding: 0px;
        margin-top: 0px;
        margin-bottom: 5px
    }
    .hiddencol{
        display:none;
    }
    .PnlDesign {
        border: solid 0.5px #E0E0E0;
        height: 100px;
        width: 115%;
        overflow: scroll;
        background-color: White;
        font-size: 11px;
        font-family: Arial;
    }

    .PnlDesign2 {
        border: solid 0.5px #E0E0E0;
        height: 100px;
        width: 100%;
        overflow: scroll;
        background-color: White;
        font-size: 11px;
        font-family: Arial;
    }
    </style>
    <script type="text/javascript">
        function FormatIt(obj) {

            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }

        function a() {
            alert("ModalPanel");
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }



        function isAlfa(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }

        function on(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9\b]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function bankAccount(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9\b]|[.]|\-/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                        মূল্য সংযোজন কর নিবন্ধন ও টার্ণওভার কর তালিকাভুক্তির আবেদনপত্র
                    </div>
                    <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="panel-heading" style="font-size: 15px; font-weight: bold; height: 30px; padding-top: 0px">
                                            <label style="color:#3366cc"><span class="required" style="color:red"> * </span> A.REGISTRATION BASICS</label> </div>
                                        <div class="col-md-3">
                                            <asp:Label ID="CheckBox5" runat="server" Text="A1.Registration Category" AutoPostBack="True" />
                                        </div>
                                        <%--<div class="col-md-3">
                                            <asp:CheckBox ID="chkNew" runat="server" Text="New" AutoPostBack="True" />
                                            <asp:CheckBox ID="chkRereg" runat="server" Text="Re-Registration" AutoPostBack="True" />
                                        </div>--%>
                                        <div class="col-md-3">
                                            <asp:RadioButton ID="chkNew" runat="server" Text="New" GroupName="registrationCatagory"/>
                                            &emsp;
                                            <asp:RadioButton ID="chkRereg" runat="server" Text="Re-Registration" GroupName="registrationCatagory" />
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label33" runat="server" Text="BIN No:" class="col-sm-5 control-label text-right" />
                                                <div class="col-sm-5" style="padding:0px">
                                                    <asp:TextBox ID="txtOldbin" runat="server" class="form-control onlyNumber" placeholder="13 Digit BIN" MaxLength="13" data-error="txtOldbinMsg"></asp:TextBox>
                                                    <span id="txtOldbinMsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-3">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right">Name of Company:</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtCompName" runat="server" class="form-control" AutoPostBack="True" MaxLength="149"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="col-md-12 row" style="margin-bottom:5px;">
                                            <div class="form-inline row">
                                                <label class="col-sm-2 control-label">Name of the Company:</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtCompName" runat="server" class="form-control" AutoPostBack="True" MaxLength="149" style="width:100%;"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color:#3366cc">
                                                B. BUSINESS INFORMATION
                                            </label>
                                        </div>
                                        <br />
                                        <div class="col-md-12">
                                            <span class="required" style="color:red"> * </span><label>
                                                B1. Type of ownership
                                            </label>
                                        </div>
                                        <br />
                                        <div class=" dropdown col-sm-10">
                                            <asp:DropDownList ID="drpTypeofBusiness" runat="server" ReadOnly="true" class="form-input select2" data-toggle="dropdown" Visible="false">
                                            </asp:DropDownList>
                                            <asp:Panel ID="Panel1" runat="server" CssClass="PnlDesign" style="height:auto;">
                                                <asp:RadioButtonList ID="chklistTypeofBusiness" runat="server" RepeatDirection="Horizontal" BorderStyle="None" style="width:100%" OnSelectedIndexChanged="chklistTypeofBusiness_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:RadioButtonList>
                                            </asp:Panel>
                                        </div>
                                    
                                        <%--<div class="col-md-12">
                                            <span class="required" style="color:red"> * </span> <label>
                                                B2. Are you a Withholding Entity
                                            </label>
                                        </div>
                                        <div class="col-md-6" style="text-align:center">
                                            <div class="col-sm-5" style="padding:0px">
                                                <asp:CheckBox ID="chkYes" runat="server" Text="Yes" AutoPostBack="True" />
                                            </div>
                                            <div class="col-sm-5" style="padding:0px">
                                                <asp:CheckBox ID="chkNo" runat="server" Text="No" AutoPostBack="True" />
                                            </div>
                                        </div>--%>
                                        <br />
                                        <div class="col-md-12" ID="spbusiness" runat="server">
                                            <div class="col-md-7">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-sm-5 rqrd"> Please Specify: </label>
                                                    <div class="col-sm-6">
                                                      <asp:TextBox runat="server" ID="typbusinessspecify"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                      <div class="col-md-2">
                                            <asp:Button runat="server" ID="btnbAdd" Text="Add" class="btn-btn" Style="background-color:#05f1f5;color:black;" OnClick="btnbAdd_Click"/>
                                            </div>
                                       <div class="col-md-3">
                                           <asp:TextBox runat="server" ID="txtotherb"> </asp:TextBox>
                                             <asp:TextBox runat="server" ID="txtotherb1" Visible="false"> </asp:TextBox>
                                            </div>
                                        </div>   
                                        <div class="col-md-12">
                                            <div class="col-md-7">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-sm-5 rqrd"> B2. Are you a Withholding Entity </label>
                                                    <div class="col-sm-6">
                                                        <asp:RadioButton ID="chkYes" runat="server" Text="Yes" AutoPostBack ="true" GroupName="withholdingEntityGroup" />
                                                        &emsp;
                                                        <asp:RadioButton ID="chkNo" runat="server" Text="No" AutoPostBack ="true" GroupName="withholdingEntityGroup" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color:#3366cc">
                                                C. GENERAL INFORMATION
                                            </label>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label ID="labelTxtlicense" runat="server" CssClass="control-label col-sm-5 text-right">C1. Trade License No (if applicable):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtlicense" runat="server" class="col-md-12" MaxLength="25" data-error="txtlicenseErrmsg"></asp:TextBox>
                                                    <span id="txtlicenseErrmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label ID="labelTxtlicensedate" runat="server" CssClass="control-label col-sm-5">Issue Date:</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox runat="server" ID="txtlicensedate" class="col-md-12"> </asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtlicensedate" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label ID="lblTxtrjscno" runat="server" CssClass="control-label col-sm-5"> C2. RJSC Incorporation number (if any):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtrjscno" runat="server" CssClass="col-md-12" MaxLength="25" data-error="txtrjscnoErrmsg"></asp:TextBox>
                                                    <span id="txtrjscnoErrmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label ID="lblTxtrjscdate" runat="server" CssClass="control-label col-sm-5">Issue Date:</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox runat="server" ID="txtrjscdate" CssClass="col-md-12"> </asp:TextBox>
                                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtrjscdate" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label ID="lblTxtginfoetin" runat="server" CssClass="control-label col-sm-5"> C3.e-TIN (As in e-TIN):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtginfoetin" runat="server" CssClass="col-md-12 onlyNumber" MaxLength="12" data-error="txtginfoetinErrmsg"></asp:TextBox>
                                                    <span id="txtginfoetinErrmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"> C4.Name of the Company (if applicable):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtcmpname" runat="server" class="col-md-12"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label ID="lblTxtcmpdifname" runat="server" CssClass="control-label col-sm-5"> C5.Name of the Company (if different than in e-TIN):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtcmpdifname" runat="server" CssClass="col-md-12"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">C6.Trading Brand (if any):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtbrand" runat="server" class="col-md-12"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5 rqrd"> C7.Registration Type:</asp:label>
                                                <div class="col-sm-12">
                                                    <%--<asp:CheckBox ID="chkVAT" runat="server" Text="VAT" AutoPostBack="True" style="margin-left:220px" />
                                                    <asp:CheckBox ID="chkTTax" runat="server" Text="Turnover Tax" AutoPostBack="True" />--%>
                                                    <asp:RadioButton ID="chkVAT" runat="server" Text="VAT" AutoPostBack="True" style="margin-left:220px" GroupName="RegistrationType"/>
                                                    &nbsp;
                                                    <asp:RadioButton ID="chkTTax" runat="server" Text="Turnover Tax" AutoPostBack="True" GroupName="RegistrationType"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5 rqrd">C8.Equity Information:</asp:label>
                                                <div class="col-sm-12">
                                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Text="100% Local" AutoPostBack="True" style="margin-left:120px" />
                                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="100% Foreign" AutoPostBack="True" />
                                                    <asp:CheckBox ID="CheckBox3" runat="server" Text="Join Venture Local Share (%)" AutoPostBack="True" />--%>
                                                    <asp:RadioButton ID="CheckBox1" GroupName="equityInformationGroup" runat="server" Text="100% Local" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" style="margin-left:120px" />
                                                    <asp:RadioButton ID="CheckBox2" GroupName="equityInformationGroup" runat="server" Text="100% Foreign" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                                    <asp:RadioButton ID="CheckBox3" GroupName="equityInformationGroup" runat="server" Text="Join Venture Local Share (%)" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
                                                </div>
                                            </div>
                                            <div class="col-md-6" id="localShareDiv" runat="server" visible="false">
                                                <asp:label runat="server" ID="lblLocalSharePercentage" CssClass="control-label col-sm-5">Local Share(%):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox runat="server" ID="localSharePercentage" CssClass="form-control col-md-12"> </asp:TextBox>
                                                    <ajaxToolkit:MaskedEditExtender Mask="99.99" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" ID="localSharePercentageMaskedEditExtender" runat="server" TargetControlID="localSharePercentage" />
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-12">
                                            <div class="col-md-4">
                                                <asp:label runat="server" class="control-label col-sm-5" style="margin-left:75px">100% Local</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox runat="server" ID="txtlocal" class="col-md-12"> </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:label runat="server" class="control-label col-sm-5">100% Foreign</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtforeign" runat="server" class="col-md-12"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:label runat="server" class="control-label col-sm-5">Join Venture Local Share (%)</asp:label>
                                                <div class="col-sm-5">
                                                    <asp:TextBox runat="server" ID="txtjv" class="col-md-12"> </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"> C9.BIDA Registration Number (if any):</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtbidano" runat="server" class="col-md-12 onlyNumber" MaxLength="25" data-error="txtbidanoErrmsg"></asp:TextBox>
                                                    <span id="txtbidanoErrmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">Issue Date:</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtbidadate" runat="server" class="col-md-12"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtbidadate" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6"> D.CONTACT INFORMATION</label>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>D1.Factory/Business Operations Address :</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtregaddress" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div>
                                                <div class="col-md-6">
                                                    <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>D7.e-Mail:</asp:label>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox ID="txt_Email" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>D2.District:</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList ID="drpDistrict" runat="server" class="form-control select2" AutoPostBack="True" onselectedindexchanged="drpBranchDistrict_SelectedIndexChanged1">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"> D8.Fax Number (if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txt_Fax" runat="server" class="form-control onlyMobile" MaxLength="15" data-error="txt_FaxErrmsg"></asp:TextBox>
                                                    <span id="txt_FaxErrmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span> D3.Police Station:</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList ID="drpThana" runat="server" class="form-control select2" data-toggle="dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div>
                                                <div class="col-md-6">
                                                    <asp:label runat="server" class="control-label col-sm-5">D9.Web Address (if any):</asp:label>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox ID="txt_Website" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>D4.Post Code:</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList ID="drpPostCode" runat="server" class="form-control select2"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"> D10.Registered HQ Address [If different than address of D1](If any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="hqaddress" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-1">
                                                    <asp:CheckBox ID="isD10sameAsD1" runat="server" AutoPostBack="true" ToolTip="Check if same as D1" OnCheckedChanged="isD10sameAsD1_CheckedChanged" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">D5.Land Telephone Number (if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtLand_Phone_no1" runat="server" class="form-control onlyMobile" data-error="txtLand_Phone_no1Msg" MaxLength="15"></asp:TextBox>
                                                    <span id="txtLand_Phone_no1Msg" style="color:red;"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"> D11.Registered HQ Address outside Bangladesh[for 100% foreign ownership](if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="registered" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span> D6.Mobile Telephone Number (if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txt_Mobile_no1" runat="server" class="form-control onlyMobile" MaxLength="11" data-error="txt_Mobile_no1Errmsg"></asp:TextBox>
                                                    <span id="txt_Mobile_no1Errmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                            <div runat="server" visible="false"> 
                                                <div class="col-md-6">
                                                    <asp:label runat="server" class="control-label col-sm-5">HQ Address outside Bangladesh[for 100% foreign ownership](if any):</asp:label>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox ID="hqforeign" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6"> E.LIST OF BRANCH UNITS YOU WISH TO BRING UNDER CENTRAL REGISTRATION</label>
                                        </div>
                                        <br />
                                        <div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label34" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required" style="color:red"> * </span>Branch Address:</asp:Label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label36" runat="server" Text="" class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>Branch Name:</asp:Label>
                                                    <div class="col-sm-7 " style="padding:0px">
                                                        <asp:TextBox ID="txtBranch" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label42" runat="server" Text="Category:" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtCtg" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label43" runat="server" Text="Annual Turnover:" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtTurnover" runat="server" class="form-control onlyFloat" MaxLength="12" data-error="txtTurnoverErrmsg"></asp:TextBox>
                                                        <span id="txtTurnoverErrmsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label2" runat="server" Text="BIN (If any):" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtBIN" runat="server" class="form-control onlyNumber" MaxLength="13" data-error="txtBINMsg"></asp:TextBox>
                                                        <span id="txtBINMsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:HiddenField runat="server" ID="gveconomicIndex"/>
                                                <asp:Button ID="btneconomic" class="btn-btn" Style="background-color:#05f1f5;color:black;float: right" runat="server" Text="Add" OnClick="btnbranch_Click" CausesValidation="False" />
                                                <asp:Button ID="btneconomicUpdate" class="btn btn-info btn-sm" Style="float: right" runat="server" Text="Update" OnClick="btneconomicUpdate_OnClick" CausesValidation="False" Visible="False" />
                                            </div>
                                        </div>
                                        <asp:GridView ID="gveconomic" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gveconomic_OnSelectedIndexChanging" OnRowDeleting="gveconomic_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
                                                <asp:BoundField HeaderText="Branch Address" DataField="Org_branch_address" />
                                                <asp:BoundField HeaderText="Branch Name" DataField="Branch_unit_name" />
                                                <asp:BoundField HeaderText="Category" DataField="Branch_reg_category" />
                                                <asp:BoundField HeaderText="Annual Turnover" DataField="Branch_turnover" />
                                                <asp:BoundField HeaderText="BIN (If any)" DataField="Branch_unit_bin" />
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color:#3366cc"><span class="required" style="color:red"> * </span>F.MAJOR AREA OF ECONOMIC ACTIVITY</label>
                                        </div>
                                        <br />
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                <asp:CheckBox ID="chkmanufact" runat="server" AutoPostBack="True" OnCheckedChanged="chkmanufact_CheckedChanged" />
                                                <asp:Label runat="server" Text="F1.Manufacturing"></asp:Label>
                                                <asp:CheckBox ID="chkmanuf1" runat="server" CssClass="hiddencol" />
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                <asp:CheckBox ID="chkserv" runat="server" AutoPostBack="True" OnCheckedChanged="chkserv_CheckedChanged" />
                                                <asp:Label runat="server" Text="F2.Services"></asp:Label>
                                                <asp:CheckBox ID="chkserv1" runat="server" CssClass="hiddencol" />
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                <asp:CheckBox ID="chkimport" runat="server" OnCheckedChanged="chkimport_CheckedChanged" AutoPostBack="True" />
                                                <asp:Label runat="server" Text="F3.Imports"></asp:Label>
                                                <asp:CheckBox ID="chkimp1" runat="server" CssClass="hiddencol" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">IRC Number:</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="imp_irc" runat="server" class="col-md-12"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:label runat="server" class="control-label col-sm-5">Issue Date:</asp:label>
                                                <div class="col-sm-5">
                                                    <asp:TextBox ID="imp_date" runat="server" class="col-md-12"> </asp:TextBox>
                                                    <cc1:CalendarExtender ID="cc1" runat="server" Format="dd/MM/yyyy" TargetControlID="imp_date" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                <asp:CheckBox ID="chkexport" runat="server" OnCheckedChanged="chkexport_CheckedChanged" AutoPostBack="True" />
                                                <asp:Label runat="server" Text="F4.Exports"></asp:Label>
                                                <asp:CheckBox ID="chkexp1" runat="server" CssClass="hiddencol" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">ERC Number:</asp:label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="exp_irc" runat="server" class="col-md-12"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:label runat="server" class="control-label col-sm-5">Issue Date:</asp:label>
                                                <div class="col-sm-5">
                                                    <asp:TextBox ID="exp_date" runat="server" class="col-md-12"> </asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="exp_date" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                <asp:CheckBox ID="chkother" runat="server" OnCheckedChanged="chkother_CheckedChanged" AutoPostBack="true" />
                                                <asp:Label runat="server" Text="F5.Others"></asp:Label>
                                                <asp:CheckBox ID="chkother1" runat="server" CssClass="hiddencol" />
                                            </div>
                                             <div class="col-md-6">
                                           <asp:label runat="server" class="control-label col-sm-5">Please Specify:</asp:label>
                                            <div class="col-sm-4">
                                                    <asp:TextBox ID="specification" runat="server" class="col-md-12"></asp:TextBox>
                                             </div>
                                       </div>
                                       </div>
                                        <div runat="server" class="col-md-12" id="otherchkDiv">
                                            <div class="col-md-2">
                                                                                                                                           
                                        </div>  
                                 <div class="col-md-6">
                                           <asp:label runat="server" class="control-label col-sm-5">Sale%:</asp:label>
                                            <div class="col-sm-4">
                                                    <asp:TextBox ID="txtsale_pct" runat="server" class="col-md-12"></asp:TextBox>
                                             </div>
                                       </div>
                                              <div class="col-md-4">
                                                <asp:label runat="server" class="control-label col-sm-5 ">Rebatable:</asp:label>
                                                <div class="col-sm-5">
                                                    <asp:RadioButton ID="chkrbtY" runat="server" Text="Yes" AutoPostBack ="true" GroupName="Rebatable" />
                                              &emsp;
                                        <asp:RadioButton ID="chkrbtN" runat="server" Text="No" AutoPostBack ="true" GroupName="Rebatable" />
                                                </div>
                                            </div>
                                                               
                                 </div>            
                                      <div class="col-md-12" style="text-align:right">                                      
                                      <asp:Button runat="server" ID="btnecoAdd" Text="Add" class="btn-btn" Style="background-color:#05f1f5;color:black;" OnClick="btnecoAdd_Click"/>                                 
                                     </div>
                
                                   
                                    <asp:GridView ID="gveconomicSpecification" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gveconomic_OnSelectedIndexChanging" OnRowDeleting="gveconomic_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
                                                <asp:BoundField HeaderText="Specification" DataField="Specification" />
                                                <asp:BoundField HeaderText="Sale%" DataField="Sale_pct" />
                                                <asp:BoundField HeaderText="Rebatable" DataField="IsRebatable" />
                                                </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                          
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView> 
                                       
                                       <%-- <div class="col-sm-5">
                                  <asp:TextBox runat="server" ID="txtEcoOther" class="col-md-12"> </asp:TextBox>
                                  <asp:TextBox runat="server" ID="txtEcoOther1" Visible="false"> </asp:TextBox>
                                </div>--%>
                               
                            </div>
                                           
                                  
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group" id="gPanel" runat="server">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6">G.AREA OF MANUFACTURING [MANDATORY IF TAXPAYER SELECT "MANUFACTURING" IN FIELD F1]</label>
                                        </div>
                                        <br />
                                        <div class=" dropdown col-sm-12">
                                            <asp:DropDownList ID="drpManufacture" runat="server" ReadOnly="true" class="form-input select2" height="35px" data-toggle="dropdown" Visible="false">
                                            </asp:DropDownList>
                                            <asp:Panel ID="Panel2" runat="server" CssClass="PnlDesign2">
                                                <asp:CheckBoxList ID="CheckBoxListManufacture" runat="server" style="width:100%" RepeatColumns="5" OnSelectedIndexChanged="CheckBoxListManufacture_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:CheckBoxList>
                                            </asp:Panel>
                                        </div>
                                              <div class="col-md-12" ID="Div1" runat="server">
                                            <div class="col-md-7">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-sm-5 rqrd"> Please Specify: </label>
                                                    <div class="col-sm-6">
                                                       <asp:TextBox runat="server" ID="manufactSpecify" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                 <div class="col-md-2">
                                      <asp:Button runat="server" ID="btnmanuAdd" Text="Add" class="btn-btn" Style="background-color:#05f1f5;color:black;" OnClick="btnmanuAdd_Click"/>
                                 </div>
                                <div class="col-md-3">
                                  <asp:TextBox runat="server" ID="txtaddmanuf"> </asp:TextBox>
                                  <asp:TextBox runat="server" ID="txtaddmanuf1" Visible="false"> </asp:TextBox>
                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group" id="hPanel" runat="server">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6">H.AREA OF SERVICE [MANDATORY IF TAXPAYER SELECT "SERVICE" IN FIELD F2]</label>
                                        </div>
                                        <br />
                                        <div class=" dropdown col-sm-12">
                                            <asp:DropDownList ID="drpService" runat="server" ReadOnly="true" class="form-input select2" height="25px" data-toggle="dropdown" Visible="false">
                                            </asp:DropDownList>
                                            <asp:Panel ID="Panel3" runat="server" CssClass="PnlDesign2">
                                                <asp:CheckBoxList ID="CheckBoxListService" runat="server" style="width:100%" RepeatColumns="5" OnSelectedIndexChanged="CheckBoxListService_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:CheckBoxList>
                                            </asp:Panel>
                                        </div>
                                              <div class="col-md-12" ID="Div2" runat="server">
                                            <div class="col-md-7">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-sm-5 rqrd"> Please Specify: </label>
                                                    <div class="col-sm-6">
                                                       <asp:TextBox runat="server" ID="servSpecify"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                         <div class="col-md-2">
                                            <asp:Button runat="server" ID="btnAddServ" Text="Add" class="btn-btn" Style="background-color:#05f1f5;color:black;" OnClick="btnAddServ_Click"/>
                                        </div>
                                       <div class="col-md-3">
                                           <asp:TextBox runat="server" ID="txtaddserv"> </asp:TextBox>
                                           <asp:TextBox runat="server" ID="txtaddserv1" Visible="false"> </asp:TextBox>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6">I.BUSINESS CLASSIFICATION CODE [MANDATORY IF TAXPAYER SELECT "MANUFACTURING" IN FIELD F1]</label>
                                        </div>
                                        <br />
                                        <div>
                                            <div class="col-md-3">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label44" CssClass="col-sm-5 control-label text-right" runat="server">Commercial Description of Supply:</asp:Label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtsupply" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label45" runat="server" CssClass="col-sm-5 control-label text-right">H.S/Service Code:</asp:label>
                                                    <div class="col-sm-7 " style="padding:0px">
                                                        <asp:DropDownList ID="drpsvcode" runat="server" class="form-control select2"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label47" runat="server" CssClass="col-sm-5 control-label text-right"> Description Of H.S/Service Code:</asp:label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtdescode" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Button ID="btnbusiness" class="btn-btn" Style="background-color:#05f1f5;color:black;float: right" runat="server" Text="Add" OnClick="btnbusiness_Click" CausesValidation="false" />
                                            </div>
                                            <asp:GridView ID="gvbusiness" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnRowDeleting="gvbusiness_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Commercial Description of Supply" DataField="com_description" />
                                                    <asp:BoundField HeaderText="H.S/Service Code" DataField="hs_code" />
                                                    <asp:BoundField HeaderText="Description of H.S/Service Code" DataField="hs_description" />
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color:#3366cc">J.BANK ACCOUNT DETAILS</label>
                                        </div>
                                        <br />
                                        <div>
                                            <div class="col-md-3">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="zz" CssClass="col-sm-5 control-label text-right" runat="server"> <span class="required" style="color:red"> * </span>Account Name :</asp:label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtAccountName_Bank_Info" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label49" runat="server" class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>Bank Name: </asp:label>
                                                    <div class="col-sm-7 " style="padding:0px">
                                                        <asp:DropDownList ID="drpBankName_Bank_Info" runat="server" AutoPostBack="True" class="form-control select2" OnSelectedIndexChanged="drpBankName_Bank_Info_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label51" runat="server" CssClass="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>Branch:</asp:label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:DropDownList ID="drpBranchName_Bank_Info" runat="server" class="form-control select2">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label50" runat="server" class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>Account Number:</asp:label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtAccountNumber_Bank_Info" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:HiddenField runat="server" ID="gvOrgBankInfoIndex"/>
                                                <asp:Button ID="btnBankInformation" class="btn-btn" Style="background-color:#05f1f5;color:black;float: right" runat="server" Text="Add" OnClick="btnBankInformation_Click" CausesValidation="false" />
                                                <asp:Button ID="btnBankInformationUpdate" class="btn btn-info btn-sm" Style="float: right" runat="server" Text="Update" OnClick="btnBankInformationUpdate_OnClick" CausesValidation="false" Visible="False" />
                                            </div>
                                        </div>
                                        <asp:GridView ID="gvOrgBankInfo" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gvOrgBankInfo_OnSelectedIndexChanging" OnRowDeleting="gvOrgBankInfo_RowDeleting" OnPreRender="gvOrgBankInfo_PreRender" OnRowDataBound="gvOrgBankInfo_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
                                                <asp:BoundField HeaderText="Account Name" DataField="strAccountName" />
                                                <asp:BoundField HeaderText="Bank Name" DataField="Bank_name" />
                                                <asp:BoundField HeaderText="Branch" DataField="bankBranch" />
                                                <asp:BoundField HeaderText="Account Number" DataField="strAccountNo" />
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6">K.INFORMATION ABOUT OWNERS/DIRECTORS/HEAD of Entity</label>
                                        </div>
                                        <br />
                                        <div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label52" CssClass="col-sm-5 control-label text-right" runat="server" Text="Full Name :" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtFullName" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label53" runat="server" Text="Share(%):" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7 " style="padding:0px">
                                                        <asp:TextBox ID="txtSharePercentage_Owner_Type" runat="server" class="form-control onlyNumber"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label55" runat="server" Text="e-TIN:" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txteTIN" runat="server" class="form-control onlyNumber" MaxLength="12" data-error="txteTINErrmsg"></asp:TextBox>
                                                        <span id="txteTINErrmsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label54" runat="server" Text="NID:" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtNIDNumber_Owner_Type" runat="server" class="form-control onlyNumber" MaxLength="18" data-error="txtNIDNumberErrmsg"></asp:TextBox>
                                                        <span id="txtNIDNumberErrmsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="lb" runat="server" Text="Passport Number:" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtpassport_Owner_Type" runat="server" class="form-control" MaxLength="9"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label" runat="server" Text="Passport Issuing Country:" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:DropDownList ID="drpissuing_country" runat="server" class="form-control select2"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:HiddenField runat="server" ID="gvOwnerTypeIndex"/>
                                            <asp:Button ID="btnAddOwnerType" class="btn-btn" Style="background-color:#05f1f5;color:black;float: right" runat="server" Text="Add" OnClick="btnAddOwnerType_Click" CausesValidation="false" />
                                            <asp:Button ID="btnAddOwnerTypeUpdate" class="btn btn-info btn-sm" Style="float: right" runat="server" Text="Update" OnClick="btnAddOwnerTypeUpdate_OnClick" CausesValidation="false" Visible="False" />
                                        </div>
                                    </div>
                                    <asp:GridView ID="gvOwnerType" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gvOwnerType_OnSelectedIndexChanging" OnRowDeleting="gvOwnerType_RowDeleting" OnPreRender="gvOwnerType_PreRender" OnRowDataBound="gvOwnerType_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:BoundField HeaderText="Full Name" DataField="Owner_name" />
                                            <asp:BoundField HeaderText="Share (%)" DataField="Share_percentage" />
                                            <asp:BoundField HeaderText="e-Tin" DataField="E_tin" />
                                            <asp:BoundField HeaderText="NID" DataField="Nid_no" />
                                            <asp:BoundField HeaderText="Passport Number" DataField="Passport_no" />
                                            <asp:BoundField HeaderText="Passport Issuing Country" DataField="Passport_issue_contry" />
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-group">
                        <div class="panel panel-primary">
                            <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                <div class="container-fluid">
                                    <div class="col-md-12">
                                        <label style="color:#3366cc"> L.BUSINESS OPERATIONS</label>
                                    </div>
                                    <br />

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:label runat="server" CssClass="col-sm-5 control-label text-right">L1.Taxable turnover in past 12 months period(if applicable)</asp:label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox40" runat="server" class="form-control onlyNumber"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:label ID="lblTextBox41" runat="server" CssClass="col-sm-5 control-label text-right">L2.Projrcted turnover in next 12 months period</asp:label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox41" runat="server" class="form-control onlyNumber"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:label ID="lblTextBox42" runat="server" CssClass="col-sm-5 control-label text-right">L3.No of Employees</asp:label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox42" runat="server" class="form-control onlyNumber"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:label runat="server" CssClass="col-sm-5 control-label text-right rqrd"> L4.Are you making any zero rated supply </asp:label>
                                                <%--<div class="col-sm-3">
                                                    <asp:CheckBox ID="CheckBox12" runat="server" Text="Yes" AutoPostBack="True" />
                                                </div>
                                                <div class="col-sm-2">
                                                    <asp:CheckBox ID="CheckBox13" runat="server" Text="No" AutoPostBack="True" />
                                                </div>--%>

                                                <%--<div class="col-sm-3">
                                                    <asp:RadioButton id="rb12" runat="server" GroupName="zeroRatedSupply" Text="Yes"></asp:RadioButton>
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:RadioButton id="rb13" runat="server" GroupName="zeroRatedSupply" Text="No"></asp:RadioButton>
                                                </div>--%>

                                                <div class="col-sm-6">
                                                    <asp:RadioButtonList ID="zeroRatedSupply" runat="server" RepeatDirection="Horizontal" BorderStyle="None">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <%--<asp:RequiredFieldValidator ID="zeroRatedSupplyValidator" runat="server"
                                                        ControlToValidate="zeroRatedSupply" ErrorMessage="L.4 Field is Required">
                                                    </asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:label runat="server" CssClass="col-sm-5 control-label text-right rqrd"> L5.Are you making any VAT exempted supply </asp:label>
                                                <%--<div class="col-sm-3">
                                                    <asp:CheckBox ID="CheckBox14" runat="server" Text="Yes" AutoPostBack="True" />
                                                </div>
                                                <div class="col-sm-2">
                                                    <asp:CheckBox ID="CheckBox15" runat="server" Text="No" AutoPostBack="True" />
                                                </div>--%>

                                                <%--<div class="col-sm-3">
                                                    <asp:RadioButton id="rb14" runat="server" GroupName="vatExemptedSupply" Text="Yes"></asp:RadioButton>
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:RadioButton id="rb15" runat="server" GroupName="vatExemptedSupply" Text="No"></asp:RadioButton>
                                                </div>--%>

                                                <div class="col-sm-6">
                                                    <asp:RadioButtonList ID="vatExemptedSupply" runat="server" RepeatDirection="Horizontal" BorderStyle="None">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <%--<asp:RequiredFieldValidator ID="vatExemptedSupplyValidator" runat="server"
                                                        ControlToValidate="vatExemptedSupply" ErrorMessage="L.5 Field is Required">
                                                    </asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:label runat="server" CssClass="col-sm-5 control-label text-right"> L6.Major Capital Machinery (IF APPLICABLE) </asp:label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label56" CssClass="col-sm-5 control-label text-right" runat="server" Text="Description :" />
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label57" CssClass="col-sm-5 control-label text-right" runat="server" Text="Quantity :" />
                                                <div class="col-sm-7 ">
                                                    <asp:TextBox ID="txtQuantity" runat="server" class="form-control onlyNumber" data-error="txtQuantityMsg"></asp:TextBox>
                                                    <span id="txtQuantityMsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label58" CssClass="col-sm-5 control-label text-right" runat="server" Text="H.S.Code :" />
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtHscode" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label59" runat="server" Text="Value in BDT:" CssClass="col-sm-5 control-label text-right" />
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtValue" runat="server" class="form-control onlyFloat" data-error="txtValueMsg"></asp:TextBox>
                                                    <span id="txtValueMsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label60" runat="server" Text="Production Capacity" CssClass="col-sm-5 control-label text-right" />
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtCapacity" runat="server" class="form-control onlyFloat" data-error="txtCapacityMsg"></asp:TextBox>
                                                    <span id="txtCapacityMsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label61" runat="server" Text="Physical Condition" CssClass="col-sm-5 control-label text-right" />
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtPhycondition" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:HiddenField runat="server" ID="gvCapitalMchnIndex"/>
                                            <asp:Button ID="btnCaptalMchn" class="btn-btn" Style="background-color:#05f1f5;color:black;float: right" runat="server" Text="Add" OnClick="btnCaptalMchn_Click" />
                                            <asp:Button ID="btnCaptalMchnUpdate" class="btn btn-info btn-sm" Style="float: right" runat="server" Text="Update" OnClick="btnCaptalMchnUpdate_OnClick" Visible="False" />
                                        </div>
                                        <asp:GridView ID="gvCapitalMchn" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gvCapitalMchn_OnSelectedIndexChanging" OnRowDeleting="gvCapitalMchn_RowDeleting" OnPreRendGridView1er="gvCapitalMchn_PreRender" OnRowDataBound="gvCapitalMchn_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
                                                <asp:BoundField HeaderText="Description" DataField="Description" />
                                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                                <asp:BoundField HeaderText="H.S Code" DataField="HSCode" />
                                                <asp:BoundField HeaderText="Value in BDT" DataField="ValueinBDT" />
                                                <asp:BoundField HeaderText="Production Capacity" DataField="ProductionCapacity" />
                                                <asp:BoundField HeaderText="Physical Condition" DataField="PhysicalCondition" />
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:label runat="server" CssClass="col-sm-5 control-label text-right"> L7.Input-Output Data (IF APPLICABLE) </asp:label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label62" CssClass="col-sm-6 control-label text-right" runat="server" Text="Com. Description of Output" />
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtdesOutput" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label63" CssClass="col-sm-6 control-label text-right" runat="server" Text="HS/Service Code of Output" />
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtsrvcodeOutput" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label64" CssClass="col-sm-6 control-label text-right" runat="server" Text="Selling Unit" />
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtsellUnit" runat="server" class="form-control onlyNumber" data-error="txtsellUnitMsg"></asp:TextBox>
                                                    <span id="txtsellUnitMsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label1" CssClass="col-sm-6 control-label text-right" runat="server" Text="Description of Major Inputs" />
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtdesInput" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label65" CssClass="col-sm-6 control-label text-right" runat="server" Text="HS/Service Code of Inputs" />
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtsrvcodeInput" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <asp:Label ID="label66" CssClass="col-sm-6 control-label text-right" runat="server" Text="Qnty of input used per unit of output" />
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtinputusdoutput" runat="server" class="form-control onlyNumber" data-error="txtinputusdoutputMsg"></asp:TextBox>
                                                    <span id="txtinputusdoutputMsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:HiddenField runat="server" ID="gvInputOutputIndex"/>
                                            <asp:Button ID="btnInputOutput" class="btn-btn" Style="background-color:#05f1f5;color:black;float: right;" runat="server" Text="Add" OnClick="btnInputOutput_Click" />
                                            <asp:Button ID="btnInputOutputUpdate" class="btn btn-info btn-sm" Style="float: right;" runat="server" Text="Update" OnClick="btnInputOutputUpdate_OnClick" Visible="False" />
                                        </div>
                                    </div>
                                    <asp:GridView ID="gvInputOutput" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gvInputOutput_OnSelectedIndexChanging" OnRowDeleting="gvInputOutput_RowDeleting" OnPreRendGridView1er="gvInputOutput_PreRender" OnRowDataBound="gvInputOutput_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:BoundField HeaderText="Commercial Description of Output" DataField="OutputDescription" />
                                            <asp:BoundField HeaderText="H.S / Service Code of Output" DataField="OutputCode" />
                                            <asp:BoundField HeaderText="Selling Unit" DataField="SellingUnit" />
                                            <asp:BoundField HeaderText="Description of Major Input" DataField="InputDescription" />
                                            <asp:BoundField HeaderText="H.S / Service Code of Input" DataField="InputCode" />
                                            <asp:BoundField HeaderText="Quantity of input used per unit of output" DataField="InputQuantity" />
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color:#3366cc">M.AUTHORIZED PERSONS INFORMATION FOR ONLINE ACTIVITY</label>
                                        </div>
                                        <br />
                                        <div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label68" CssClass="col-sm-5 control-label text-right" runat="server" Text="Name" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label69" runat="server" Text="Designation" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7 ">
                                                        <asp:TextBox ID="txtdesignation" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label70" runat="server" Text="NID" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtnid" runat="server" class="form-control onlyNumber" MaxLength="18" data-error="txtnidMsg"></asp:TextBox>
                                                        <span id="txtnidMsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label71" runat="server" Text="Mobile No" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control onlyMobile" MaxLength="11" data-error="txtmobileMsg"></asp:TextBox>
                                                        <span id="txtmobileMsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label72" runat="server" Text="E-mail" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label73" runat="server" Text="Purpose" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtpurpose" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:HiddenField runat="server" ID="gvAuthorizePersonIndex"/>
                                                <asp:Button ID="btnauthPerson" class="btn-btn" Style="background-color:#05f1f5;color:black; float: right;margin-right:15px" runat="server" Text="Add" OnClick="btnauthPerson_Click" />
                                                <asp:Button ID="btnauthPersonUpdate" class="btn btn-info btn-sm" Style="float: right;margin-right:15px" runat="server" Text="Update" OnClick="btnauthPersonUpdate_OnClick" Visible="False" />
                                            </div>
                                            <asp:GridView ID="gvAuthorizePerson" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gvAuthorizePerson_OnSelectedIndexChanging" OnRowDeleting="gvAuthorizePerson_RowDeleting" OnRowDataBound="gvAuthorizePerson_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Name" DataField="Name" />
                                                    <asp:BoundField HeaderText="Designation" DataField="Designation" />
                                                    <asp:BoundField HeaderText="NID" DataField="NID" />
                                                    <asp:BoundField HeaderText="Mobile No" DataField="Mobile" />
                                                    <asp:BoundField HeaderText="E-mail" DataField="Email" />
                                                    <asp:BoundField HeaderText="Purpose" DataField="Purpose" />
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-group">
                            <div class="panel panel-primary">
                                <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                                    <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color:#3366cc">N.DECLARATION</label>
                                            <p>All the details and information provided in this form are true and complete. I am aware that any untrue/incomplete statement may result in delay in BIN issuance
                                                and I amay be subjected to full penalty under The Value Added Tax and Supplementary Duty Act, 2012 or any other applicable Act prevailing at present.
                                            </p>
                                        </div>
                                        <br />
                                      <%--  <div class="col-md-12" style="width:50%;text-align:right;margin-right:100px">
                                            <label style="text-align:right">FULL NAME:</label>
                                            <asp:TextBox runat="server"></asp:TextBox>
                                           
                                            <br />
                                        </div>

                                        <div class="col-md-12">
                                            <label>SIGNATURE OF AUTHORIZED PERSON(For manual submission only)</label>
                                            <br />
                                        </div>
                                        <div class="col-md-12" style="width:50%;text-align:right">
                                            <label>DESIGNATION:</label>
                                            <asp:TextBox runat="server"></asp:TextBox>
                                          
                                            <br />
                                        </div>--%>
                                        <div class="col-md-12"> 
                                         <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label3" CssClass="col-sm-5 control-label text-right rqrd" runat="server" Text="FULL NAME:" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtFullNameReg" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                         <div class="col-md-4">                                              
                                            </div>
                                         <div class="col-md-4">                                               
                                            </div>
                                            </div>
                                         
                                            <div class="col-md-12"> 
                                         <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label5" CssClass="col-sm-5 control-label text-right  rqrd" runat="server" Text="DESIGNATION:" />
                                                    <div class="col-sm-7">
                                                        <asp:DropDownList ID="drpDesignation" runat="server" class="form-control select2">
                                                  </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                                <div class="col-md-4">                                              
                                            </div>
                                         <div class="col-md-4">                                               
                                            </div>
                                            </div>
                                         <div class="col-md-12"> 
                                         <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label4" CssClass="col-sm-12 control-label text-right" runat="server" Text="SIGNATURE OF AUTHORIZED PERSON (For manual submission only):" />
                                                   <%-- <div class="col-sm-2">
                                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                                    </div>--%>
                                                </div>
                                            </div>
                                                <div class="col-md-4">                                              
                                            </div>
                                         <div class="col-md-4">                                               
                                            </div>
                                            </div>
                                        <%--<div class="row">
                                          <div class="col-md-12">
                                              <fieldset class="scheduler-border" runat="server" id="fldbtnSave">
                                                  <div class="col-sm-2" style="float: right">
                                                      <asp:Button ID="btnSave" Style="float: left;margin-left:-45px; width: 205px;  height: 30px" class="mktdr-btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />
                                                  </div>
                                              </fieldset>
                                              <div style="width:auto; padding-left:3%">
                                                  <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                              </div>
                                              <div style="width:auto; padding-left:3%">
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate_Owner_Type" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ErrorMessage="Invalid date format in Start Date(DD/MM/Year)." CssClass="litMessage" />
                                              </div>
                                              <div style="width:auto; padding-left:3%; color :Red">
                                                  <asp:Label ID="lblSave" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                              </div>
                                              <div style="width:auto; padding-left:3%">
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEndDate_Owner_Type" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ErrorMessage="Invalid date format in End Date(DD/MM/Year)." CssClass="litMessage" />
                                              </div>
                                              <div style="width:auto; padding-left:3%">
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Email in present address Email." ControlToValidate="txtPr_Email" SetFocusOnError="True" style="color :red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                  </asp:RegularExpressionValidator>
                                              </div>
                                              <div style="width:auto; padding-left:3%">
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid Email in parmanent address Email." ControlToValidate="txtPar_Email" SetFocusOnError="True" style="color :red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                  </asp:RegularExpressionValidator>
                                              </div>
                                              <div style="width:auto; padding-left:3%">
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Email in branch unit address Email." ControlToValidate="txtBranch_Email" SetFocusOnError="True" style="color :red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                  </asp:RegularExpressionValidator>
                                              </div>
                                              <div style="width:auto; padding-left:3%">
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRegistrationDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ErrorMessage="Invalid date format in Registration Date(DD/MM/Year)." CssClass="litMessage" />
                                              </div>
                                          </div>
                                        </div>--%>
                                      </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="btnsave" class="btn-btn" Style="background-color:#4CAF50;float: right;margin-right:15px" runat="server" Text="Save" OnClick="btnsave_Click" />
                        </div>
                    </div>
                   <%-- <div style="width:100%; height:auto">
                        <uc2:MsgBox ID="msgBox" runat="server" />
                    </div>--%>
                </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>