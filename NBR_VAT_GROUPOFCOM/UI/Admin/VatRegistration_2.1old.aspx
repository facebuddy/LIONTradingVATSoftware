
<%@ page title="Organization Setup" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_VatRegistration_2_1old, App_Web_fxp4hfg1" %>


<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
     <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />

    <style type="text/css">
        
        hr
        {
           padding :0px;
           margin-top:0px;
           margin-bottom:5px
        }
        .PnlDesign
        {
            border: solid 0.5px #E0E0E0;
            height: 100px;
            width: 115%;
            overflow:scroll;
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
            <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold;
                height: 30px; padding-top: 0px">
                মূল্য সংযোজন কর নিবন্ধন ও টার্ণওভার কর তালিকাভুক্তির আবেদনপত্র</div>
            <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                <div class="row" style="margin-top: 1%">
                    <div class="col-md-3">
                        <div class="form-group form-group-sm">
                             <label class="col-sm-3 control-label text-right"><span style="color:red">*</span>E-TIN :</label>
                        <%--<asp:Label ID="label1" runat="server" Text="E-TIN:" class="mktdr-label mktdr-col-5"  style = "margin-left:-34px"/>--%>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtetin" runat="server" class="form-control" onkeypress="return isNumberKey(event)" MaxLength="12"></asp:TextBox>
                        </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-3 control-label text-right"><span style="color:red">*</span>BIN :</label>
                        <%--<asp:Label ID="label36" runat="server" Text="BIN:" class="mktdr-label mktdr-col-5" style = "margin-left : -150px" />--%>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtOrganizationBIN" runat="server" class="form-control" onkeypress="return isNumberKey(event)"  MaxLength="12"></asp:TextBox>
                        </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label text-right"><span style="color:red">*</span>Organization Name :</label>
                        <%--<asp:Label ID="Label2" runat="server" Text="Organization Name:" class="mktdr-label mktdr-col-5" style = "margin-left:-170px" />--%>
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtRegisterPersonName" runat="server" class="form-control" OnTextChanged="txtRegisterPersonName_TextChanged"
                            placeholder="Enter Organization Name"  onkeypress="return isAlfa(event)"  AutoPostBack="True" MaxLength="149"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <fieldset class="scheduler-border">
                        <legend class="scheduler-border">Present Address</legend>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5"><span style="color:red">*</span>Holding:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Holding" placeholder="Enter Holding No" MaxLength="49"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5"><span style="color:red">*</span>Road:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Road" 
                                    onkeypress="return isAlfa(event)"    placeholder="Enter Road" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:label runat = "server"  class="control-label col-sm-5">
                                    <span style="color:red">*</span>Block/Area:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Block_Area"
                                     placeholder="Enter Block/Area" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5">
                                    <span style="color:red">*</span>District:</asp:label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpPresentDistrict" runat="server" ReadOnly="true" class="form-control"
                                        data-toggle="dropdown" AutoPostBack="True" 
                                        onselectedindexchanged="drpPresentDistrict_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5">
                                    <span style="color:red">*</span>Upazila:</asp:label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpPresentUpazila" runat="server" ReadOnly="true" 
                                        class="form-input">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5">
                                    <span style="color:red">*</span>Thana:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpPresentThana" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5">
                                    Post Code:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpPresentPostCode" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown" Visible = "false"></asp:DropDownList>
                                       <asp:TextBox runat="server" type="text" class="form-input" ID="txtPresentPostCode" 
                                        placeholder="Enter Post Code" MaxLength="4" onkeypress="return isNumberKey(event)"></asp:TextBox> 
                                        
                                    
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5">
                                    <span style="color:red">*</span>Road No:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Road_No" 
                                        placeholder="Enter Road No" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5">
                                    Moza name:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_MozaName" 
                                     onkeypress="return isAlfa(event)"   placeholder="Enter Moza Name" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:label runat = "server" class="control-label col-sm-5">
                                    <span style="color:red">*</span>Phone No1:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Phone_no1" 
                                      onkeypress="return isNumberKey(event)"  placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Phone No2:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Phone_no2" 
                                    onkeypress="return isNumberKey(event)"  placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Mobile No1:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Mobile_no1"
                                      onkeypress="return isNumberKey(event)"  placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Mobile No2:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Mobile_no2"
                                      onkeypress="return isNumberKey(event)"  placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    E-Mail:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Email" 
                                        placeholder="Enter Email" MaxLength="99"></asp:TextBox>
                                </div>
                                 
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Website:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Website" 
                                        placeholder="Enter Website" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Fax:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Fax" 
                                        placeholder="Enter Fax" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                
                <div class="row">

                <asp:CheckBox ID="chkCopy" style = "margin-left: 16px" runat="server" 
                            Text="Same As Above" oncheckedchanged="chkCopy_CheckedChanged" 
                            AutoPostBack="True" />

                </div>

                <div class="row">
                
                    <fieldset class="scheduler-border" id = "testID" runat ="server">
                    <div>
                    
                    </div>
                        <legend class="scheduler-border">Permanent Address</legend>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Para/Mohalla:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Para" 
                                   onkeypress="return isAlfa(event)"     placeholder="Enter Para/Moholla" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Village:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Village" 
                                     onkeypress="return isAlfa(event)"   placeholder="Enter Village" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>District:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpPermanentDistrict" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown" AutoPostBack="True" 
                                        onselectedindexchanged="drpPermanentDistrict_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Upazila:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpPermanentUpazila" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Thana:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpPermanentThana" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Post Code:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpPermanentPost" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>

                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPermanentPost" 
                                    placeholder="Enter Post Code" MaxLength="4" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Road No:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Road_no" 
                                        placeholder="Enter Road No" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Moza name:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Moza" 
                                     onkeypress="return isAlfa(event)"   placeholder="Enter Moza Name" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Phone No1:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Phone_no1"
                                     onkeypress="return isNumberKey(event)"   placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Phone No2:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Phone_no2"
                                     onkeypress="return isNumberKey(event)"   placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Mobile No1:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Mobile_no1"
                                     onkeypress="return isNumberKey(event)"   placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Mobile No2:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Mobile_no2"
                                      onkeypress="return isNumberKey(event)"  placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    E-Mail:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Email" 
                                        placeholder="Enter Email" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Website:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Website" 
                                        placeholder="Enter Website" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Fax:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Fax" 
                                        placeholder="Enter Fax" MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Registration Type</legend>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Registration Type:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpRegistrationType" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown" Height="35px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-6">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Yearly Turnover</legend>
                            <div class="col-sm-6">
                                <asp:Label ID="label3" runat="server" class="mktdr-label mktdr-col-5"><span style="color:red">*</span>Amount:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtAmount_Yearly_Turnover" 
                                        onkeypress="return on(event)" runat="server" class="form-input" 
                                        MaxLength="6"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <asp:Label ID="Label4" runat="server" Text="Inword:" class="mktdr-label mktdr-col-5" />
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtAmount_Yearly_Turnover_InWord" 
                                        onkeypress="return isAlfa(event)" runat="server" class="form-input" 
                                        MaxLength="99"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-3">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Registration Date</legend>
                            <div class="form-group">
                                <asp:Label ID="Label35" class="control-label col-sm-5" runat = "server">
                                   <span style="color:red">*</span>Registration Date:</asp:label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtRegistrationDate" MaxLength="10" Format="dd/MM/yyyy"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender runat="server" ID="non1" TargetControlID="txtRegistrationDate" Format="dd/MM/yyyy"/>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Type of Business</legend>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Type of Business:</asp:Label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpTypeofBusiness" runat="server" ReadOnly="true" class="form-input" height = "35px"
                                        data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>
                                      <asp:Panel ID="Panel1" runat="server" CssClass="PnlDesign">
                                    <asp:CheckBoxList ID="chklistTypeofBusiness" runat="server" style="width:100%" >
                                    </asp:CheckBoxList>
                                    </asp:Panel>
                                    
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-3">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Other Tax Collection</legend>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Other Tax Collection:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <%--multiple selection in dropdown--%>
                                    <asp:DropDownList ID="drpOtherTaxCollection" runat="server" ReadOnly="true" class="form-input"
                                       height = "35px" data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>
                                     <asp:Panel ID="Panel2" runat="server" CssClass="PnlDesign">
                                    <asp:CheckBoxList ID="chkliOtherTaxCollection" runat="server">
                                    </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-3">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Vat Deducted at Source</legend>
                            <asp:RadioButton ID="rdbYesVatDeducted" runat="server" GroupName="VatDeductedSource"
                                Text="Yes" AutoPostBack="True" OnCheckedChanged="rdbYesVatDeducted_CheckedChanged" />
                            <asp:RadioButton ID="rdbNoVatDeducted" runat="server" GroupName="VatDeductedSource"
                                Text="No" AutoPostBack="True" OnCheckedChanged="rdbNoVatDeducted_CheckedChanged" />
                            <div class="form-group">
                                
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpVatDeductedSource" height = "35px" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>
                                    <asp:Panel ID="PnlCust" runat="server" CssClass="PnlDesign" style = " margin-left:80px">
                                    <asp:CheckBoxList ID="chkListVatDeductedSource" runat="server" style="width:100%;">
                                    </asp:CheckBoxList>
                                    </asp:Panel>

                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-3">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Nature of Application</legend>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    Nature of Application:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <%--multiple selection in dropdown--%>
                                    <asp:DropDownList CssClass="form-input" ID="drpNatureOfApplication" runat="server"
                                     height = "35px"   ReadOnly="true" class="form-input" data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>
                                     <asp:Panel ID="Panel3" runat="server" CssClass="PnlDesign">
                                    <asp:CheckBoxList ID="chkliNatureOfApplication" runat="server">
                                    </asp:CheckBoxList>
                                    </asp:Panel>

                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Business Process Activities</legend>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    BP Activities:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpBusinessProcessActivites" runat="server" ReadOnly="true"
                                      height = "35px"  class="form-input" data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>

                                  <asp:Panel ID="Panel5" runat="server" CssClass="PnlDesign" style = "margin-left:-27px;">  
                                      <asp:CheckBoxList ID="chkliBusinessProcessActivites" runat="server" style="width:100%"> </asp:CheckBoxList>
                                   </asp:Panel>

                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-4">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Economic Process Activities</legend>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    EP Activities:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpEconomicalProcessActivities" runat="server" ReadOnly="true"
                                      height = "35px"  class="form-input" data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>

                                     <asp:Panel ID="Panel4" runat="server" CssClass="PnlDesign" style = "margin-left:-27px; width:172">
                                    <asp:CheckBoxList ID="chkliEconomicalProcessActivities" runat="server">
                                    </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                       <div class="col-sm-4">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Circle</legend>
                            <div class="form-group">
                                <asp:Label class="control-label col-sm-5" runat = "server">
                                    <span style="color:red">*</span>Circle:</asp:label>
                                <div class=" dropdown col-sm-7">
                                    <asp:DropDownList ID="drpCircle" runat="server" ReadOnly="true" class="form-input"
                                        data-toggle="dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>

                <div class="row">
                    <fieldset class="scheduler-border">
                        <legend class="scheduler-border">Nature of Application & Branch Unit Address</legend>
                        <asp:CheckBox ID="chkNewApplication" runat="server" Text="New Application" OnCheckedChanged="chkNewApplication_CheckedChanged"
                            AutoPostBack="True" />
                        <asp:CheckBox ID="chkOldApplication" runat="server" Text="Old Application" OnCheckedChanged="chkOldApplication_CheckedChanged"
                            AutoPostBack="True" />
                        <div class="col-md-12">
                            <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="label19" CssClass="col-sm-5 control-label text-right" runat="server" Text="Org. Name:"/>
                                    <div class="col-sm-7" style="padding:0px">
                                        <asp:TextBox ID="txtOrganizationName_N_O_A" runat="server" class="form-control" placeholder="Enter Organization Name"></asp:TextBox>
                                    </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="label20" runat="server" Text="Branch Name:" class="col-sm-5 control-label text-right" />
                                    <div class="col-sm-7 " style="padding:0px">
                                        <asp:TextBox ID="txtBranchName_N_O_A" runat="server" class="form-control" placeholder="Enter Branch Name" MaxLength="99"></asp:TextBox>
                                    </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="label21" runat="server" Text="Old BIN No:" class="col-sm-5 control-label text-right" />
                                    <div class="col-sm-7" style="padding:0px">
                                        <asp:TextBox ID="txtOldBinNumber_N_O_A" runat="server" class="form-control" onkeypress="return isNumberKey(event)"   placeholder="Enter Old BIN No" MaxLength="12"></asp:TextBox>
                                    </div>
                                    </div>
                                </div>
                                <div class="col-md-3" >
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="label22" runat="server" Text="New BIN No:" CssClass="col-sm-5 control-label text-right" />
                                    <div class="col-sm-7" style="padding:0px">
                                        <asp:TextBox ID="txtNewBinNumber_N_O_A" runat="server" 
                                          onkeypress="return isNumberKey(event)"  class="form-control" placeholder="Enter New BIN No" MaxLength="12"></asp:TextBox>
                                    </div>
                                    
                                    </div>
                                 
                                </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label6" class="control-label col-sm-5 text-right" runat = "server">
                                    Holding:</asp:Label>
                                <div class="col-sm-7" style="padding-left:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Holding"
                                    onkeypress="return isNumberKey(event)"  placeholder="Enter Holding No" MaxLength="49" Width="100%"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label1" class="control-label col-sm-5 text-right" runat = "server">
                                    Road:</asp:Label>
                                <div class="col-sm-7" style="padding-left:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Road" 
                                      onkeypress="return isAlfa(event)"  placeholder="Enter Road" MaxLength="99"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label2" class="control-label col-sm-5 text-right" runat = "server">
                                    Block/Area:</asp:Label>
                                <div class="col-sm-7" style="padding-left:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Block" 
                                     placeholder="Enter Block/Area" MaxLength="99"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label7" class="control-label col-sm-5 text-right" runat = "server">
                                    Moza name:</asp:Label>
                                <div class="col-sm-7" style="padding-left:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Moza" 
                                     onkeypress="return isAlfa(event)"   placeholder="Enter Moza Name" MaxLength="99"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label8" class="control-label col-sm-5 text-right" runat = "server">
                                    District:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                    <asp:DropDownList ID="drpBranchDistrict" runat="server" class="form-control"
                                        AutoPostBack="True" onselectedindexchanged="drpBranchDistrict_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label23" class="control-label col-sm-5 text-right" runat = "server">
                                    Upazila:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                    <asp:DropDownList ID="drpBranchUpazila" runat="server" class="form-control" data-toggle="dropdown">
                                    </asp:DropDownList>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label24" class="control-label col-sm-5 text-right" runat = "server">
                                    Thana:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                   <asp:DropDownList ID="drpBranchThana" runat="server" class="form-control" data-toggle="dropdown">
                                    </asp:DropDownList>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label28" class="control-label col-sm-5 text-right" runat = "server">
                                    Post Code:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                   <asp:DropDownList ID="drpBranchPost" runat="server" class="form-control" Visible="false">
                                    </asp:DropDownList>

                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranchPost" 
                                        placeholder="Enter Post Code" MaxLength="4" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label25" class="control-label col-sm-5 text-right" runat = "server">
                                    Road No:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Road_No"
                                        placeholder="Enter Road No" MaxLength="49"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label26" class="control-label col-sm-5 text-right" runat = "server">
                                    Phone No1:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Phone_No1"
                                        placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label27" class="control-label col-sm-5 text-right" runat = "server">
                                    Phone No2:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Phone_No2"
                                        placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label29" class="control-label col-sm-5 text-right" runat = "server">
                                     Mobile No1:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Mobile_No1"
                                        placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label30" class="control-label col-sm-5 text-right" runat = "server">
                                     Mobile No2:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                     <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Mobile_No2" placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label31" class="control-label col-sm-5 text-right" runat = "server">
                                     E-Mail:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                     <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Email" 
                                        placeholder="Email" MaxLength="99"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-sm">
                                    <asp:Label ID="Label32" class="control-label col-sm-5 text-right" runat = "server">
                                     Fax:</asp:Label>
                                <div class="col-sm-7" style="padding:0px">
                                     <asp:TextBox runat="server" type="text" class="form-control" ID="txtBranch_Fax" 
                                        placeholder="Enter Fax" MaxLength="99"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnAddBranchUnit" class="btn btn-primary btn-sm" Style ="float: right" runat="server" Text="Add Branch" OnClick="btnAddBranchUnit_Click" />
                                    
                                <asp:Button ID="btnNoBranch" class="btn btn-warning btn-sm" Style ="float: right" runat="server" Text="No Branch" onclick="btnNoBranch_Click" />
                            </div>
                        </div>
                        
                        <div class="row">
                                
                                <div class="col-sm-12">
                                <asp:Button ID="btnAddNatureofApplication"  Width="120px" 
                                        Style="float: right;margin-right :34px" class="btn mktdr-btn-success"
                                    runat="server" Text="No Need" Height="30px" 
                                        OnClick="btnAddNatureofApplication_Click" Visible="False" />
                            </div>
                                
                                <asp:GridView ID="gvNatureOfApplication" runat="server" AutoGenerateColumns="False"
                                    CssClass="sGrid" DataKeyNames="IntRowNo" Width="100%" Style="width: 95.5%; margin-left: 29px"
                                    OnRowDeleting="gvNatureOfApplication_RowDeleting" OnPreRender="gvNatureOfApplication_PreRender"
                                    OnRowDataBound="gvNatureOfApplication_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <Columns>
                                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                                        <asp:BoundField HeaderText="Organization Name" DataField="Organization_name" />
                                        <asp:BoundField HeaderText="Branch Name" DataField="Branch_name" />
                                        <asp:BoundField HeaderText="Old BIN No" DataField="Old_bin_number" />
                                        <asp:BoundField HeaderText="New BIN No" DataField="New_bin_number" />
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
                        </div >
                        
   
                <div class="row">
                    <asp:GridView ID="gvBranchUnitAddress" runat="server" AutoGenerateColumns="False"
                        CssClass="sGrid" DataKeyNames="IntRowNo" Width="100%" Style="width: 95.5%; margin-left: 29px"
                        OnRowDeleting="gvBranchUnitAddress_RowDeleting" OnPreRender="txtRegisterPersonName_TextChanged"
                        OnRowDataBound="gvBranchUnitAddress_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <Columns>
                            <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                            <asp:BoundField HeaderText="Organization Name" DataField="Organization_name" />
                            <asp:BoundField HeaderText="Branch Name" DataField="Branch_name" />
                            <asp:BoundField HeaderText="Old BIN No" DataField="Old_bin_number" />
                            <asp:BoundField HeaderText="New BIN No" DataField="New_bin_number" />
                            <asp:BoundField HeaderText="Holding" DataField="Holding" />
                            <asp:BoundField HeaderText="Upazila" DataField="Upazila_name" />
                            <asp:BoundField HeaderText="Moza Name" DataField="Moza_Name" />
                            <asp:BoundField HeaderText="Mobile no2" DataField="Mobile_no2" />
                            <asp:BoundField HeaderText="Road" DataField="Road" />
                            <asp:BoundField HeaderText="Thana" DataField="Thana_name" />
                            <asp:BoundField HeaderText="Phone no1" DataField="Phone_no1" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:BoundField HeaderText="Block/Area" DataField="Block_area" />
                            <asp:BoundField HeaderText="Post Office" DataField="Post_code" />
                            <asp:BoundField HeaderText="Phone no2" DataField="Phone_no2" />
                            <asp:BoundField HeaderText="Fax" DataField="Fax" />
                            <asp:BoundField HeaderText="District_id" DataField="District" />
                            <asp:BoundField HeaderText="Road_no" DataField="Road_no" />
                            <asp:BoundField HeaderText="Mobile no1" DataField="Mobile_no1" />
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

            <fieldset id = "fldBtnTopInfo" class="scheduler-border" runat = "server">
                  <div class = "row">
                <div class="col-sm-2" style = "float: right">
                    <asp:Button ID="btnSaveUpperInformation" Style="float: left;margin-left:-45px; width: 205px;  height: 30px"
                        class="mktdr-btn-success" runat="server" Text="Save" 
                        OnClick="btnSaveUpperInformation_Click" />
                </div>
               
              
                 </div>
                   </fieldset>
            <div class = "row" >
            
          

            </div>

            <div class="row">
                <div class="col-md-12">
                     <fieldset id = "fldBankInformation" class="scheduler-border" runat = "server">
                    <legend class="scheduler-border">Bank Information</legend>
                    <div class="col-md-3" style="padding: 0px">
                        <div class="form-group form-group-sm">
                            <asp:Label runat="server" CssClass="col-sm-5 control-label text-right" Text="Organization Name:"/>
                            <div class="col-sm-7" style="padding: 0px">
                                <asp:TextBox runat="server" type="text" class="form-input" ID="txtOrganizationName_Bank_Info" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label37" class="control-label col-sm-5 text-right" runat = "server" >Bank Name:</asp:Label>
                                    <div class="col-sm-7" style="padding: 0px">
                                <asp:DropDownList ID="drpBankName_Bank_Info" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="drpBankName_Bank_Info_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                       
                    </div>
                    <div class="col-md-3" style="padding: 0px">
                       <div class="form-group form-group-sm">
                         <asp:Label ID="Label5" runat="server"  Text="Org. Branch:" CssClass="col-sm-5 control-label text-right"/>
                            <div class="col-sm-7" style="padding: 0px">
                                <asp:DropDownList ID="drpBranchBankInfo" runat="server" ReadOnly="true" class="form-control"
                                    data-toggle="dropdown">
                                </asp:DropDownList>

                            </div>
                        </div>
                        
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label38" class="control-label col-sm-5 text-right" runat = "server">Bank Branch:</asp:label>
                            <div class="col-sm-7" style="padding: 0px">
                                <asp:DropDownList ID="drpBranchName_Bank_Info" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                       
                    </div>
                    <div class="col-md-3" style="padding: 0px">
                       <div class="form-group form-group-sm">
                            <asp:Label ID="Label40" class="control-label col-sm-5 text-right" runat = "server">Account Type:</asp:Label>
                            <div class="col-sm-7" style="padding: 0px">
                                <asp:DropDownList ID="drpAccountType" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label41" class="control-label col-sm-5 text-right" runat = "server"> Account Number:</asp:Label>
                            <div class="col-sm-7" style="padding: 0px">
                               <asp:TextBox runat="server" type="text" class="form-control" onkeypress="return bankAccount(event)"   ID="txtAccountNumber_Bank_Info" MaxLength="99"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label39" class="control-label col-sm-5 text-right" runat = "server">
                                A/C Holder Name:</asp:label>
                            <div class="col-sm-7" style="padding: 0px">
                                <asp:TextBox runat="server" type="text" class="form-control" 
                                  onkeypress="return isAlfa(event)"  ID="txtAccountName_Bank_Info" MaxLength="99"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <div class="col-sm-12" style="padding:0px">
                                <asp:Button ID="btnBankInformation"  Style="float: right;" class="btn btn-primary btn-sm"
                                    runat="server" Text="Add" OnClick="btnBankInformation_Click" />
                            </div>
                        </div>
                    </div>
                </fieldset>
                <asp:GridView ID="gvOrgBankInfo" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    DataKeyNames="IntRowNo" Width="100%" Style="width: 95.5%; margin-left: 29px"
                    OnRowDeleting="gvOrgBankInfo_RowDeleting" OnPreRender="gvOrgBankInfo_PreRender"
                    OnRowDataBound="gvOrgBankInfo_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                        <asp:BoundField HeaderText="Organization Name" DataField="Organization_name" />
                        <asp:BoundField HeaderText="Branch Name" DataField="Branch" />
                        <asp:BoundField HeaderText="Account Name" DataField="AccountName" />
                        <asp:BoundField HeaderText="Account Number" DataField="AccountNo" />
                        <asp:BoundField HeaderText="Bank Name" DataField="Bank_Name" />
                        <asp:BoundField HeaderText="Bank Branch" DataField="BankBranch" />
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
            <div class="row">
                <div class="col-md-12">
                     <fieldset class="scheduler-border" id = "fldOwnerInfo" runat = "server">
                    <legend class="scheduler-border">Owner Type</legend>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <asp:Label class="control-label col-sm-5 text-right" runat = "server">
                                Owner Type:</asp:label>
                            <div class="col-sm-7">
                                <asp:DropDownList ID="drpOwnerType" runat="server" class="form-control"
                                    data-toggle="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label9" runat="server" Text="Organization Name:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" type="text" class="form-control" ID="txtOrganizationName_Owner_Type"
                                    placeholder="Enter Organization Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label12" runat="server" Text="Branch Name:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:DropDownList ID="drpBranchOwerInfo" runat="server" class="form-control"
                                    data-toggle="dropdown">
                                </asp:DropDownList>
                       
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label13" runat="server" Text="Director Name:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" type="text" class="form-control" ID="txtDirectorName_Owner_Type"
                                onkeypress="return isAlfa(event)"    placeholder="Enter Director Name" MaxLength="99"></asp:TextBox> 
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label10" runat="server" Text="Designation:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtDesignation_Owner_Type" runat="server" class="form-control" 
                                  onkeypress="return isAlfa(event)"  MaxLength="49"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label14" runat="server" Text="Start Date:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtStartDate_Owner_Type" runat="server" class="form-control" MaxLength="10" Format="dd/MM/yyyy"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtStartDate_Owner_Type" Format="dd/MM/yyyy"/>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label15" runat="server" Text="End Date:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtEndDate_Owner_Type" runat="server" class="form-control" MaxLength="10" Format="dd/MM/yyyy"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtEndDate_Owner_Type" Format="dd/MM/yyyy"/>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label11" runat="server" Text="Share Percentage:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtSharePercentage_Owner_Type" runat="server" 
                                  onkeypress="return isNumberKey(event)"  class="form-control" MaxLength="3"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label16" runat="server" Text="NID No:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtNIDNumber_Owner_Type" runat="server" class="form-control" 
                                  onkeypress="return isNumberKey(event)"  MaxLength="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label17" runat="server" Text="Passport No:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtPassportNumber_Owner_Type" runat="server" 
                                   onkeypress="return isNumberKey(event)" class="form-control" MaxLength="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <asp:Label ID="label18" runat="server" Text="Passport issue Country:" class="control-label col-sm-5 text-right" />
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtPassportIssueCountry_Owner_Type" onkeypress="return isAlfa(event)" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <div class="col-sm-12">
                                <asp:Button ID="btnAddOwnerType" Width="120px" Style="float: left; margin-left:255px" class="btn btn-primary btn-sm"
                                    runat="server" Text="Add" Height="30px" OnClick="btnAddOwnerType_Click" />
                            </div>
                        </div>
                    </div>
                </fieldset>
                <asp:GridView ID="gvOwnerType" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    DataKeyNames="IntRowNo" Width="100%" Style="width: 95.5%; margin-left: 29px"
                    OnRowDeleting="gvOwnerType_RowDeleting" OnPreRender="gvOwnerType_PreRender" OnRowDataBound="gvOwnerType_RowDataBound"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3">
                    <Columns>
                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                        <asp:BoundField HeaderText="Organization Name" DataField="Organization_name" />
                        <asp:BoundField HeaderText="Owner Type" DataField="Owner_type_name" />
                        <asp:BoundField HeaderText="Designation" DataField="Designation" />
                        <asp:BoundField HeaderText="Nid Number" DataField="Nid_no" />
                        <asp:BoundField HeaderText="Start Date" DataField="Start_date" />
                        <asp:BoundField HeaderText="End Date" DataField="End_date" />
                        <asp:BoundField HeaderText="Passport No" DataField="Passport_no" />
                        <asp:BoundField HeaderText="Branch Name" DataField="Branch_name" />
                        <asp:BoundField HeaderText="Director Name" DataField="Director_name" />
                        <asp:BoundField HeaderText="Share Percentage" DataField="Share_percentage" />
                        
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
            <div class="row">
                <div class="col-md-12">
                    <fieldset class="scheduler-border" id = "fldDeclaretion" runat = "server">
                        <legend class="scheduler-border">Declaration</legend>
                        <div class="form-group">
                            <asp:Label ID="Label46" runat="server" class="control-label col-sm-3"><span style="color:red">*</span>Declaration:</asp:Label>
                            <div class=" dropdown col-sm-7">
                                <asp:DropDownList ID="drpDeclaretion" runat="server" Width="50%" 
                                    ReadOnly="true" class="drop-down" data-toggle="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                </div>
                    
                </div>
            
            <div class="row">
                <div class="col-md-12">
                    <fieldset class="scheduler-border" runat = "server" id = "fldbtnSave">

                    <div class="col-sm-2" style = "float: right">
                        <asp:Button ID="btnSave" Style="float: left;margin-left:-45px; width: 205px;  height: 30px"
                            class="mktdr-btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                    </fieldset>
                    <div style = "width:auto; padding-left:3%";">
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </div>
                    <div style = "width:auto; padding-left:3%";">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate_Owner_Type"
                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                            ErrorMessage="Invalid date format in Start Date(DD/MM/Year)." CssClass="litMessage" />
                    </div>
                    <div style = "width:auto; padding-left:3%; color :Red";">
                     <asp:Label ID="lblSave" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                    </div>
                    <div style = "width:auto; padding-left:3%";">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEndDate_Owner_Type"
                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                            ErrorMessage="Invalid date format in End Date(DD/MM/Year)." CssClass="litMessage" />
                    
                    </div>
                    <div style = "width:auto; padding-left:3%";">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Email in present address Email." ControlToValidate="txtPr_Email"
                 SetFocusOnError="True" style = "color :red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                 </asp:RegularExpressionValidator>
                </div>
                    <div style = "width:auto; padding-left:3%";">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid Email in parmanent address Email." ControlToValidate="txtPar_Email"
                 SetFocusOnError="True" style = "color :red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                 </asp:RegularExpressionValidator>
                </div>
                    <div style = "width:auto; padding-left:3%";">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Email in branch unit address Email." ControlToValidate="txtBranch_Email"
                 SetFocusOnError="True" style = "color :red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                 </asp:RegularExpressionValidator>
                </div>
                    <div style = "width:auto; padding-left:3%";">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRegistrationDate"
                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                            ErrorMessage="Invalid date format in Registration Date(DD/MM/Year)." CssClass="litMessage" />

                </div>
               </div>
            </div>
        </div>
        <div style = "width:100%; height:auto">
        <uc2:MsgBox ID="msgBox" runat="server" />
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
