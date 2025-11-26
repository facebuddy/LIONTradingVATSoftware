<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="VatBranchRegistration, App_Web_bxnrqbtx" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function FormatIt(obj) {
            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function AccountNumber(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9\b]|[.]|\-/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }




        function isAlfa(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }

        function fun_AllowOnlyAmountAndDot(txt) {
            if (event.keyCode > 47 && event.keyCode < 58 || event.keyCode == 46) {
                var txtbx = document.getElementById(txt);
                var amount = document.getElementById(txt).value;
                var present = 0;
                var count = 0;

                if (amount.indexOf(".", present) || amount.indexOf(".", present + 1));
                {
                    // alert('0');
                }

                /*if(amount.length==2)
                {
                if(event.keyCode != 46)
                return false;
                }*/
                do {
                    present = amount.indexOf(".", present);
                    if (present != -1) {
                        count++;
                        present++;
                    }
                }
                while (present != -1);
                if (present == -1 && amount.length == 0 && event.keyCode == 46) {
                    event.keyCode = 0;
                    //alert("Wrong position of decimal point not  allowed !!");
                    return false;
                }

                if (count >= 1 && event.keyCode == 46) {

                    event.keyCode = 0;
                    //alert("Only one decimal point is allowed !!");
                    return false;
                }
                if (count == 1) {
                    var lastdigits = amount.substring(amount.indexOf(".") + 1, amount.length);
                    if (lastdigits.length >= 2) {
                        //alert("Two decimal places only allowed");
                        event.keyCode = 0;
                        return false;
                    }
                }
                return true;
            }
            else {
                event.keyCode = 0;
                //alert("Only Numbers with dot allowed !!");
                return false;
            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid" style="margin-left: 5%">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">
                        মূল্য সংযোজন করের অধীন শাখা ইউনিট নিবন্ধনের আবেদনপত্র
                    </div>
                    <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                        <div class="row" style="margin-top: 1%">
                            <fieldset class="scheduler-border">
                                <legend class="scheduler-border">Central Unit</legend>
                                <div class="col-sm-4">
                                    <div class="control-label col-sm-5 label-font">
                                        <asp:Label ID="Label1" runat="server" Text="BIN:" />
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpBIN" runat="server" Width="100%" ReadOnly="true" AutoPostBack="True"
                                            class="drop-down" data-toggle="dropdown" OnSelectedIndexChanged="drpBIN_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="control-label col-sm-3 label-font">
                                        <asp:Label ID="Label2" runat="server" Text="Name:" />
                                    </div>
                                    <div class="col-sm-9">
                                        <asp:Label ID="lblName" runat="server" class="form-input"></asp:Label>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <fieldset class="scheduler-border">
                                <legend class="scheduler-border">Branch Unit</legend>
                                <div class="col-sm-4">
                                    <div class=" control-label col-sm-5 label-font">
                                        <asp:Label ID="Label5" runat="server" Text="BIN:" />
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtBranchBin" runat="server" type="text" class="form-input"
                                            placeholder="Enter BIN No" onkeypress="return isNumberKey(event)" MaxLength="12"></asp:TextBox>
                                        <%-- <input type="text" class="form-input" id="branchBIN" name="branchBIN" placeholder="Enter BIN No" />--%>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class=" control-label col-sm-3 label-font">
                                        <asp:Label ID="Label6" runat="server" Text="Name:" />
                                    </div>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtBranchName" runat="server" type="text" class="form-input"
                                            placeholder="Enter Branch" AutoPostBack="True"
                                            OnTextChanged="txtBranchName_TextChanged" MaxLength="99"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="col-sm-12">
                                        <asp:Button ID="btnAddBranchUnit" Width="120px" Style="float: right" class="btn btn-success"
                                            runat="server" Text="Add" Height="30px" OnClick="btnAddBranchUnit_Click" Visible="False" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <asp:GridView ID="gvBranchUnitName" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                DataKeyNames="IntRowNo" Width="100%" Style="width: 97%; margin-left: 15px" OnRowDeleting="gvBranchUnitName_RowDeleting"
                                OnPreRender="gvBranchUnitName_PreRender" OnRowDataBound="gvBranchUnitName_RowDataBound"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="3">
                                <Columns>
                                    <asp:BoundField HeaderText="BIN" DataField="Branch_unit_bin" />
                                    <asp:BoundField HeaderText="Branch Name" DataField="Branch_unit_name" />
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
                        <div class="row">
                            <div class="col-sm-8">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Yearly Turnover</legend>
                                    <div class="col-sm-4">
                                        <div class="control-label col-sm-5 label-font">
                                            <asp:Label ID="label3" runat="server" Text="Amount:" />
                                        </div>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtamount" onkeypress="return isNumberKey(event)" runat="server" class="form-input"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-8">
                                        <div class="control-label col-sm-5 label-font">
                                            <asp:Label ID="Label4" runat="server" Text="Inword:" />
                                        </div>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtinword" runat="server" onkeypress="return isAlfa(event)" class="form-input"></asp:TextBox>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-sm-4">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Registration Date</legend>
                                    <div class="form-group">
                                        <div class="control-label col-sm-5 label-font">
                                            <asp:Label ID="Label7" runat="server" Text="Registration Date:" />
                                        </div>
                                        <div class="col-sm-7" style="padding: 0px">
                                            <asp:TextBox ID="txtRegistrationDate" class="form-input" runat="server" Width="133px" MaxLength="10" Format="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" ID="kjf" TargetControlID="txtRegistrationDate" Format="dd/MM/yyyy" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row">
                            <fieldset class="scheduler-border">
                                <legend class="scheduler-border">Present Address</legend>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label8" runat="server" Text="Holding:" class="present-address-lbl"
                                            Style="margin-left: 21px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrholding"
                                                name="holding" placeholder="Enter Holding No" MaxLength="49" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" Text="Road:"
                                            class="present-address-lbl" Style="margin-left: 34px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrroad"
                                                onkeypress="return isAlfa(event)" name="holding" placeholder="Enter Road Name" MaxLength="99" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label10" runat="server" Text="Block/Area:" class="present-address-lbl" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrarea"
                                                onkeypress="return isAlfa(event)" name="holding" placeholder="Enter Area Name" MaxLength="99" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" Text="District:" class="present-address-lbl"
                                            Style="margin-left: 23px;" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:DropDownList ID="drpPresentDistrict" runat="server" ReadOnly="true" AutoPostBack="True"
                                                class="present-address-tb" data-toggle="dropdown" OnSelectedIndexChanged="drpPresentDistrict_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label12" runat="server" Text="Upazila:" class="present-address-lbl"
                                            Style="margin-left: 41px;" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:DropDownList ID="drpPresentUpazila" runat="server" ReadOnly="true" class="present-address-tb"
                                                data-toggle="dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label13" runat="server" Text="Thana:" class="present-address-lbl"
                                            Style="margin-left: 49px;" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:DropDownList ID="drpPresentThana" runat="server" ReadOnly="true" class="present-address-tb"
                                                data-toggle="dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label14" runat="server" Text="Post Code:" class="present-address-lbl"
                                            Style="margin-left: 23px;" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:TextBox ID="drpPresentPostCode" runat="server" onkeypress="return isNumberKey(event)" class="present-address-tb" MaxLength="4">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label15" runat="server" Text="Road No:" class="present-address-lbl"
                                            Style="margin-left: 34px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrroadno"
                                                name="holding" placeholder="Enter Road No" MaxLength="49" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label16" runat="server" Text="Moza Name:" class="present-address-lbl"
                                            Style="margin-left: 23px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrmouza"
                                                onkeypress="return isAlfa(event)" name="holding" placeholder="Enter Mouza Name"
                                                MaxLength="49" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label17" runat="server" Text="Phone No1:" class="present-address-lbl"
                                            Style="margin-left: 27px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrphone1"
                                                name="holding" placeholder="Enter Phone No1" MaxLength="15" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label18" runat="server" Text="Phone No2:" class="present-address-lbl"
                                            Style="margin-left: 29px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrphone2"
                                                name="holding" placeholder="Enter Phone No2" MaxLength="15" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label19" runat="server" Text="Mobile No1:" class="present-address-lbl"
                                            Style="margin-left: 28px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrmobile1"
                                                name="holding" placeholder="Enter Mobile No1" MaxLength="15" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label20" runat="server" Text="Mobile No2:" class="present-address-lbl"
                                            Style="margin-left: 23px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrmobile2"
                                                name="holding" placeholder="Enter Mobile No2" MaxLength="15" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label21" runat="server" Text="E-mail:" class="present-address-lbl"
                                            Style="margin-left: 52px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPremail"
                                                name="holding" placeholder="Enter Email Address" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label22" runat="server" Text="Website:" class="present-address-lbl"
                                            Style="margin-left: 41px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrwebsite"
                                                name="holding" placeholder="Enter Website Address" MaxLength="99" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label23" runat="server" Text="Fax:" class="present-address-lbl" Style="margin-left: 67px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" type="text" class="present-address-tb" ID="txtPrfax"
                                                name="holding" placeholder="Enter Fax No" MaxLength="99" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">

                            <asp:CheckBox ID="chkCopy" Style="margin-left: 16px" runat="server"
                                Text="Same As Above" OnCheckedChanged="chkCopy_CheckedChanged"
                                AutoPostBack="True" />

                        </div>
                        <div class="row">
                            <fieldset class="scheduler-border">
                                <legend class="scheduler-border">Permanent Address</legend>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label24" runat="server" Text="Moholla:" CssClass="present-address-lbl"
                                            Style="margin-left: 19px" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbPara" ID="txtParPara" class="present-address-tb"
                                                placeholder="Para/Moholla" MaxLength="49" onkeypress="return isAlfa(event)" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label25" runat="server" Text="Village:" CssClass="present-address-lbl"
                                            Style="margin-left: 25px" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbVillage" ID="txtParillage" class="present-address-tb"
                                                onkeypress="return isAlfa(event)" placeholder="Village" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label26" runat="server" Text="District:" CssClass="present-address-lbl"
                                            Style="margin-left: 23px" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:DropDownList ID="drpPermanentDistrict" runat="server" ReadOnly="true" AutoPostBack="True"
                                                class="present-address-tb" data-toggle="dropdown" OnSelectedIndexChanged="drpPermanentDistrict_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label27" runat="server" Text="Upazila:" CssClass="present-address-lbl"
                                            Style="margin-left: 21px" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:DropDownList ID="drpPermanentUpazila" runat="server" ReadOnly="true" class="present-address-tb"
                                                data-toggle="dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label28" runat="server" Text="Thana:" class="present-address-lbl"
                                            Style="margin-left: 49px" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:DropDownList ID="drpPermanentThana" runat="server" ReadOnly="true" data-toggle="dropdown"
                                                class="present-address-tb">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label29" runat="server" Text="Post Code:" class="present-address-lbl"
                                            Style="margin-left: 23px" />
                                        <div class=" dropdown col-sm-7" style="padding: 0px;">
                                            <asp:TextBox ID="drpPermanentPostCode" runat="server" onkeypress="return isNumberKey(event)" class="present-address-tb" MaxLength="4">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label30" runat="server" Text="Road No:" class="present-address-lbl"
                                            Style="margin-left: 34px" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbRoadNo" ID="txtParRoadNo" class="present-address-tb"
                                                placeholder="Road No" MaxLength="49" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label31" runat="server" Text="Moza Name:" class="present-address-lbl"
                                            Style="margin-left: 14px" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbMozaName" ID="txtParMozaName" class="present-address-tb"
                                                onkeypress="return isAlfa(event)" placeholder="Moza Name" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label32" runat="server" Text="Phone No1:" class="present-address-lbl"
                                            Style="padding: 0px; margin-left: 28px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbPhone1" ID="txtParPhone1" class="present-address-tb"
                                                placeholder="Phone No-1" MaxLength="15" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label33" runat="server" Text="Phone No2:" class="present-address-lbl"
                                            Style="padding: 0px; margin-left: 28px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbPhone2" ID="txtParPhone2" class="present-address-tb"
                                                placeholder="Phone No-2" MaxLength="15" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label34" runat="server" Text="Mobile No1:" class="present-address-lbl"
                                            Style="padding: 0px; margin-left: 28px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbMobile1" ID="txtParMobile1" class="present-address-tb"
                                                placeholder="Mobile No-1" MaxLength="15" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label35" runat="server" Text="Mobile No2:" class="present-address-lbl"
                                            Style="padding: 0px; margin-left: 28px;" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbMobile2" ID="txtParMobile2" class="present-address-tb"
                                                placeholder="Mobile No-2" MaxLength="15" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label36" runat="server" Text="E-mail:" class="present-address-lbl"
                                            Style="margin-left: 52px" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbEmail" ID="txtPartbEmail" class="present-address-tb"
                                                placeholder="E-mail Address" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label37" runat="server" Text="Website:" class="present-address-lbl"
                                            Style="margin-left: 41px" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbWebsite" ID="txtParWebsite" class="present-address-tb"
                                                placeholder="Web Address" MaxLength="99" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label38" runat="server" Text="Fax:" class="present-address-lbl" Style="margin-left: 67px" />
                                        <div class="col-sm-7" style="padding: 0px;">
                                            <asp:TextBox runat="server" name="tbFax" ID="txtParFax" class="present-address-tb"
                                                placeholder="fax number" MaxLength="99" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <fieldset class="scheduler-border">
                                <legend class="scheduler-border">Bank Information</legend>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label39" runat="server" Text="Org. Name:" CssClass="col-sm-5 control-label text-right"/>
                                        <div class="col-sm-7" style="padding-left:0px">
                                            <asp:TextBox runat="server" name="tbOrganizationName" ID="txtBankOrganizationName"
                                                class="form-control" placeholder="Organization name" ReadOnly="True" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label43" runat="server" Text="Acc. Number:" CssClass="col-sm-5 control-label text-right"/>
                                        <div class="col-sm-7" style="padding-left:0px">
                                            <asp:TextBox runat="server" name="tbAccountNumber" ID="txtBankAccountNumber" class="form-control"
                                                onkeypress="return AccountNumber(event)" placeholder="a/c number" />
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label40" runat="server" Text="Branch Name:" CssClass="col-sm-5 control-label text-right"/>
                                        <div class="col-sm-7" style="padding-left:0px">
                                            <asp:TextBox runat="server" name="tbBranchName" ID="txtBankBranchName" class="form-control" placeholder="Branch name" Enabled="False" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label44" runat="server" Text="Bank Name:" CssClass="col-sm-5 control-label text-right"/>
                                        <div class="col-sm-7" style="padding-left:0px">
                                            <asp:DropDownList ID="drpBankName" runat="server" AutoPostBack="True" class="form-control"
                                                data-toggle="dropdown" OnSelectedIndexChanged="drpBankName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label41" runat="server" Text="Account Type:" CssClass="col-sm-5 control-label text-right"/>
                                        <div class="col-sm-7" style="padding-left:0px">
                                            <asp:DropDownList ID="drpAccountType" runat="server" ReadOnly="true" class="form-control"
                                                data-toggle="dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Label45" runat="server" Text="Bank Branch:" CssClass="col-sm-5 control-label text-right"/>
                                        <div class="col-sm-7" style="padding-left:0px">
                                            <asp:DropDownList ID="drpBranchName" runat="server" ReadOnly="true" class="form-control"
                                                data-toggle="dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label42" runat="server" Text="Account name:" CssClass="col-sm-5 control-label text-right"/>
                                        <div class="col-sm-7" style="padding-left:0px">
                                            <asp:TextBox runat="server" name="tbAccountName" ID="txtBankAccountName" class="form-control"
                                                onkeypress="return isAlfa(event)" placeholder="a/c name" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                            <asp:Button ID="btnBankInformation" Style="float: right; height: 30px; width: 50%"
                                                class="btn mktdr-btn-success" runat="server" Text="Add" OnClick="btnBankInformation_Click" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <asp:GridView ID="gvBankInformation" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                DataKeyNames="IntRowNo" Width="100%" Style="width: 97%; margin-left: 15px" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnPreRender="gvBankInformation_PreRender"
                                OnRowDataBound="gvBankInformation_RowDataBound" OnRowDeleting="gvBankInformation_RowDeleting">
                                <Columns>
                                    <asp:BoundField HeaderText="Account Number" DataField="AccountNo" />
                                    <asp:BoundField HeaderText="Account Name" DataField="AccountName" />
                                    <asp:BoundField HeaderText="Bank Name" DataField="Bank_name" />
                                    <asp:BoundField HeaderText="Branch" DataField="BankBranch" />
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
                        <div class="row">
                            <fieldset class="scheduler-border">
                                <legend class="scheduler-border">Declaration</legend>
                                <div class="form-group">
                                    <asp:Label ID="Label46" runat="server" Text="Declaration:" class="control-label col-sm-3" />
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpDeclaration" runat="server" Width="50%" ReadOnly="true"
                                            class="drop-down" data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <fieldset class="scheduler-border">
                                <asp:Button ID="btnSave" Style="float: right; height: 30px; width: 17%; margin-right: 12px"
                                    class="btn mktdr-btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </fieldset>
                        </div>
                        <div class="row">
                            <div style="width: auto">
                                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            </div>
                            <div style="width: auto">
                                <asp:Label ID="lblSave" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                            </div>
                            <div style="width: auto">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRegistrationDate"
                                    ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                    ErrorMessage="Invalid date format in Registration Date." CssClass="litMessage" />
                            </div>
                            <div class="row">
                                <div style="width: auto; color: Red">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtamount"
                                        runat="server" ErrorMessage="Only Numbers allowed in yearly turnover Amount"
                                        ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                </div>

                                <div style="width: auto; color: Red">

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtBranchBin"
                                        runat="server" ErrorMessage="Only Numbers allowed in Branch BIN"
                                        ValidationExpression="\d+"></asp:RegularExpressionValidator>

                                </div>

                                <div style="width: auto; color: Red">

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                        ErrorMessage="Invalid Email in Present Email" ControlToValidate="txtPremail" Style="color: red"
                                        SetFocusOnError="True"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>

                                </div>

                                <div style="width: auto; color: Red">

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                        ErrorMessage="Invalid Email in Parmanent Email" ControlToValidate="txtPartbEmail" Style="color: red"
                                        SetFocusOnError="True"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <uc2:MsgBox ID="msgBox" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
