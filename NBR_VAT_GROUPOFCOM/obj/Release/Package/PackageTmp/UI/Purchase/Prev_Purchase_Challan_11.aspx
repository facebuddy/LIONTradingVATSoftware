<%@ page title="Prev Local Purchase" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Prev_LocalPurchase, App_Web_attcokcq" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Scripts/select2.min.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>
    
    <script type="text/javascript">

        function confirmPayment() {
            var total = $("[id*=txtTotalPurchasePrice]").val();
            total = !isNaN(total) ? Number(Math.round(parseFloat(total).toFixed(8) * 100) / 100) : 0;

            var given = 0;
            $.each($(".onlyFloat.payment"), function (index, value) {
                var amount = !isNaN($(value).val()) ? Number($(value).val()) : 0;
                if (amount > 0) {
                    given += amount;
                }
            });

            var extra = given - total;
            extra = Math.round(parseFloat(extra).toFixed(8) * 100) / 100;
            $("[id*=txtTotalPaid]").val(given);
            $("[id*=txtExtraPaid]").val(extra);
            if ($("[id*=chkCheque]").prop("checked") && $("[id*=txt_transaction_id]").val=="") {
                
                alert("Please fill up Payment Info");
                $("[id*=div_N]").show();
                return;
            }
           

            if (extra > 0) {
                alert("WARNING !! You have given " + extra + " taka extra !");
                $("[id*=div_N]").show();
                return;
            } else {
                if (extra < 0) {
                    alert("WARNING !! You have to pay " + (extra * (-1)) + " taka more !");
                } else {
                    alert("Payment Complete");
                    $("[id*=div_N]").hide();
                    return;
                }
            }
        }

        function chkCheckedEvent() {
            var total = $("[id*=txtTotalPurchasePrice]").val();
            total = !isNaN(total) ? Number(total) : 0;

            var paid = 0;

            var payments = $(".onlyFloat.payment");
            $.each(payments, function (index, value) {
                var amount = !isNaN($(value).val()) ? Number($(value).val()) : 0;
                paid += amount;
            });

            var remaining = total - paid;
            var remains = Math.round(parseFloat(remaining).toFixed(8) * 100) / 100;
            if ($("[id*=chkCash]").prop("checked")) {
                if (!$("[id*=txtCashAmount]").val()) { $("[id*=txtCashAmount]").val(remains); }
                $("[id*=txtCashAmount]").show();
            }
            else {
                $("[id*=txtCashAmount]").hide();
                $("[id*=txtCashAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkCredit]").prop("checked")) {
                if (!$("[id*=txtCreditAmount]").val()) { $("[id*=txtCreditAmount]").val(remains); }
                $("[id*=txtCreditAmount]").show();
            }
            else {
                $("[id*=txtCreditAmount]").hide();
                $("[id*=txtCreditAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkCheque]").prop("checked")) {
                if (!$("[id*=txtChequeAmount]").val()) { $("[id*=txtChequeAmount]").val(remains); }
                $("[id*=txtChequeAmount]").show();
                $("[id*=lbl_transaction_id]").show();
                $("[id*=txt_transaction_id]").show();
            }
            else {
                $("[id*=txtChequeAmount]").hide();
                $("[id*=lbl_transaction_id]").hide();
                $("[id*=txt_transaction_id]").hide();
                $("[id*=txtChequeAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkBkash]").prop("checked")) {
                if (!$("[id*=txtbKashAmount]").val()) { $("[id*=txtbKashAmount]").val(remains); }
                $("[id*=txtbKashAmount]").show();
            }
            else {
                $("[id*=txtbKashAmount]").hide();
                $("[id*=txtbKashAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkTT]").prop("checked")) {
                if (!$("[id*=txtTPTAmount]").val()) { $("[id*=txtTPTAmount]").val(remains); }
                $("[id*=txtTPTAmount]").show();
            }
            else {
                $("[id*=txtTPTAmount]").hide();
                $("[id*=txtTPTAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkEFT]").prop("checked")) {
                if (!$("[id*=txtEFTAmount]").val()) { $("[id*=txtEFTAmount]").val(remains); }
                $("[id*=txtEFTAmount]").show();
            }
            else {
                $("[id*=txtEFTAmount]").hide();
                $("[id*=txtEFTAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=CheDebitCard]").prop("checked")) {
                if (!$("[id*=txtDebitCartAmount]").val()) { $("[id*=txtDebitCartAmount]").val(remains); }
                $("[id*=txtDebitCartAmount]").show();
            }
            else {
                $("[id*=txtDebitCartAmount]").hide();
                $("[id*=txtDebitCartAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkPayOrder]").prop("checked")) {
                if (!$("[id*=txtPayOrder]").val()) { $("[id*=txtPayOrder]").val(remains); }
                $("[id*=txtPayOrder]").show();
            }
            else {
                $("[id*=txtPayOrder]").hide();
                $("[id*=txtPayOrder]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=ChkOther]").prop("checked")) {
                if (!$("[id*=txtOthersAmount]").val()) { $("[id*=txtOthersAmount]").val(remains); }
                $("[id*=txtOthersAmount]").show();
            }
            else {
                $("[id*=txtOthersAmount]").hide();
                $("[id*=txtOthersAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkRocket]").prop("checked")) {
                if (!$("[id*=txtRocketAmount]").val()) { $("[id*=txtRocketAmount]").val(remains); }
                $("[id*=txtRocketAmount]").show();
            }
            else {
                $("[id*=txtRocketAmount]").hide();
                $("[id*=txtRocketAmount]").val("");
            }
        }

        function calculation(selectedgrid) {
            var jsGvItem = document.getElementById("<%=gvVoucher.ClientID%>");
            var rowCount = jsGvItem.rows.length;
            var rows = selectedgrid.parentNode.parentNode;
            var quantity = parseFloat(rows.cells[2].getElementsByTagName('input')[0].value);
            var Prate = parseFloat(rows.cells[3].getElementsByTagName('input')[0].value);
            var Crate = parseFloat(rows.cells[4].getElementsByTagName('input')[0].value);
            var discount = Crate - Prate;
            rows.cells[5].getElementsByTagName('input')[0].value = discount.toFixed(2);
            var tax = parseFloat(rows.cells[6].getElementsByTagName('input')[0].value);
            var difference = parseFloat(discount) * 100 / Prate;
            rows.cells[8].getElementsByTagName('input')[0].value = Math.round(difference) + '%';

            var x = parseFloat(quantity) * parseFloat(Crate);
            var total = parseFloat(x) + parseFloat(tax);
            rows.cells[7].getElementsByTagName('input')[0].value = total;
        }

        function File_OnChange(sender) {
            val = sender.value.split('\\');
            document.getElementById('<%= lblFileName.ClientID %>').value = val[val.length - 1];
        }
    </script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                            Previous Purchase / পূর্ববর্তী চালানপত্র
                        </div>
                         <div class="panel-body">
                             <div class="row" style="background-color: #FFD9C3; margin-top: -1.15%;">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Name :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Literal ID="lblOrgName" runat="server"></asp:Literal>
                                            <asp:Label runat="server" ID="orgVDS" Visible="false" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Address :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Literal ID="lblOrgAddress" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. BIN :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Name :</label>
                                        <div class="col-sm-7">
                                           <asp:DropDownList ID="drpBranchName" runat="server" CssClass="form-control" AutoPostBack="True"
                                                onselectedindexchanged="drpBranchName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch BIN :</label>
                                        <div class="col-sm-7">
                                             <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Registration Type :</label>
                                         <asp:Label runat="server" ID="Label5" Visible="false" Text="false" />
                                        <div class="col-sm-7">
                                           <asp:DropDownList ID="drpRegType" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpRegType_SelectedIndexChanged" >
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Regular Registered (VAT)</asp:ListItem>
                                                <asp:ListItem Value="4">Registered For Turnover</asp:ListItem>
                                                <asp:ListItem Value="5">Not Registered</asp:ListItem>
                                      
                                         <asp:ListItem Value="7">Procurement Provider</asp:ListItem>
                                        <asp:ListItem Value="8">Trader</asp:ListItem>
                                      
                                            </asp:DropDownList>
                                        </div>
                                      
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">NID No. :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox runat="server" ID="txtNationalId" CssClass="form-control" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                                  <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Business Info :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtBusinessInfo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                             </div>
                             <div class="row">
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                     
                                         <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Supplier Name :</label>
                                         <asp:Label runat="server" ID="partyVDS" Visible="false" Text="false" />
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnAddParty" runat="server" OnClick="btnAddParty_Click" Text="New"/>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Supplier Address :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox class="form-control" ID="txtAddress" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Supplier BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtPartyBIN" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                             </div>
                               <div class="row">
                                    <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                      <label class="col-sm-5 control-label text-right">Category Type</label>
                                        <div class="col-sm-7">
                                         <asp:DropDownList ID="drpType" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpType_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem >Service</asp:ListItem>
                                                <asp:ListItem Selected="True">Goods</asp:ListItem>
                                              <asp:ListItem >Both</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                              
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Economic Activity :</label>
                                        <div class="col-sm-7">
                                              <asp:TextBox ID="txtMajorEcoActivity" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Area of Manufacturing :</label>
                                        <div class="col-sm-7">
                                          <asp:TextBox ID="txtAreaOfMfg" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Ref.Challan No 6.3 :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtChallanNo" CssClass="form-control" runat="server" placeholder="Party Challan No"></asp:TextBox></div>
                                        </div>
                                    </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Challan Date :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox ID="txtChallanDate" CssClass="form-control" Style="width: 50%; float: left" runat="server" DateFormat="dd/MM/yyyy" ></asp:TextBox>
                                           <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate"/>
                                            <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                         <label class="col-sm-5 control-label text-right">Receive Scroll No :</label>
                                        <div class="col-sm-7">
                                             <asp:TextBox ID="txtScrollNo" CssClass="form-control" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                </div>
                             <div class="row">
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <div class="col-sm-7">
                                          
                                        </div>
                                    </div>
                                </div>
                                   <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <div class="col-sm-7">
                                            
                                        </div>
                                    </div>
                                </div>
                                  <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                     
                                        <div class="col-sm-7">
                                            
                                        </div>
                                    </div>
                                </div>
                             </div>
                             <div class="row">
                                 <div class="col-md-4" style="display:none;">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpVehicleType" CssClass="form-control" runat="server">
                                              </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                   <div class="col-md-4" style="display:none;">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle No :</label>
                                        <div class="col-sm-7">
                                             <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                  <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                       
                                        <div class="col-sm-7">
                      
                                        </div>
                                    </div>
                                </div>
                             </div>
                            <div class="row">
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Agreement No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtAgreement" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                   <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                       
                                        <label class="col-sm-5 control-label text-right">Ultimate Destination :</label>
                                        <div class="col-sm-7">
                                           
                                            <asp:TextBox ID="txtDestination" CssClass="form-control" runat="server"></asp:TextBox></div>
                                        </div>
                                    </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Remarks :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="write your comment here"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                </div>
                                  <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"></label>
                                        <div class="col-sm-7">
                                           
                                        </div>
                                    </div>
                             </div>
                         </div>
                             <div class="row">
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <div class="col-sm-7">
                                             <asp:HiddenField ID="hdPriceID" runat="server" />
                                            <asp:HiddenField ID="hdUnitSDAmt" runat="server" />
                                            <asp:HiddenField ID="hdUnitVATAmt" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                   <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <div class="col-sm-7">
                                           
                                        </div>
                                    </div>
                                </div>
                                  <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                      
                                        <div class="col-sm-7">
                                          
                                        </div>
                                    </div>
                             </div>

                                <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                     
                                        <div class="col-sm-7">
                                           
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                       
                                        <div class="col-sm-7">
                                        
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                    
                                        <div class="col-sm-7">
                                         
                                        </div>
                                    </div>
                                </div>
                            </div>
                         
                    </div>
                </div>
                    <div class="panel panel-primary">
                        <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                            <div class="container-fluid">
                                <div class="row" >
                                    <div class="col-md-4"></div>
                                    <div class="col-md-4">
                                        <asp:RadioButton runat="server" ID="chkManualInput" Text="Manual Input" GroupName="manual" OnCheckedChanged="chkManualInput_OnCheckedChanged" AutoPostBack="true" Checked="true" />
                                        <asp:RadioButton runat="server" ID="chkExcelImport" Text="Import from Excel" GroupName="manual" OnCheckedChanged="chkExcelImport_OnCheckedChanged" AutoPostBack="true"/>
                                        <asp:RadioButton runat="server" ID="chkVoucherNo" Text="Add By Voucher No" GroupName="manual" OnCheckedChanged="chkVoucherNo_CheckedChanged" AutoPostBack="true"/>
                                    </div>
                                    <div class="col-md-4"></div>
                                  </div>
                                <div class="row" runat="server" id="part_a">
                                    <div class="test-label">
                                        <asp:Label ID="Label7" runat="server" Text="Category :"></asp:Label><br />
                                        <asp:DropDownList ID="drpCategory" Style="text-align: left" runat="server" CssClass="category" Width="130px"
                                            OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label15" runat="server" Text="Sub Cat:"></asp:Label><br />
                                        <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged" Width="130px"
                                            CssClass="sub-category">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label" style="display:none;">
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
                                        <asp:DropDownList ID="drpItem" CssClass="item select2"  runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpItem_SelectedIndexChanged" Width="200px" />
                                        <asp:Label runat="server" ID="lblProductType" Visible="false" />
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                        <asp:TextBox ID="lblHSCode" runat="server" Style="width:100px; height: 27px" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label18" runat="server" Text="Qnty:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged" Width="100px"></asp:TextBox><br />
                                        <asp:Label ID="lblAvailStock" runat="server" Visible="false" Text="Avl Stock :"></asp:Label>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label41" runat="server" Text="Unit:" Style="margin-left: 0px;" /><br />
                                        <asp:DropDownList ID="drpUnit" CssClass="unit" runat="server" style="width:72px;text-align:left" OnSelectedIndexChanged="drpUnit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:Label runat ="server" ID="lblCValue" Visible="false"/>
                                        <asp:Label runat ="server" ID="lblUID" Visible="false"/>
                                        <asp:Label runat ="server" ID="lblUnitCode" Visible="false"/>
                                    </div>
                                    <div class="test-label">
                                       
                                        <asp:Label ID="Label22" runat="server" Style="margin-left: 0px;" Text=<abbr title="Purchase Unit Price With VAT and SD">Unit Price(P):</abbr></asp:Label><br />
                                        <asp:TextBox ID="txtPurchaseUnitPrice" CssClass="category" Style="background-color: #CAFDD2"
                                            runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged" Width="130px"/>
                                        <asp:Label ID="lblPurchaseUnitPrice" runat="server" Text="" Style="margin-left: 0px;"
                                            Visible="false" />
                                        
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                        runat="server" Enabled="True" TargetControlID="txtPurchaseUnitPrice"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                       <asp:Label ID="Label36" runat="server" Style="margin-left: 0px;" Text=<abbr title="Purchase Unit Price Without VAT and SD">Price:</abbr></asp:Label><br />
                                      
                                        <asp:TextBox ID="txtTotalPrice" CssClass="category" Style="background-color: #CAFDD2" runat="server" ReadOnly="true" Width="130px"/>
                                   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                        runat="server" Enabled="True" TargetControlID="txtTotalPrice"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                     <div class="test-label">
                                       <asp:Label ID="Label1" runat="server" Style="margin-left: 0px;" Text=<abbr title="Purchase Unit Price With VAT and SD">Price(Inc. VAT):</abbr></asp:Label><br />
                                        <asp:TextBox ID="txtPriceIncludingVat" CssClass="category" Style="background-color: #CAFDD2" OnTextChanged="txtPriceIncludingVat_TextChanged" AutoPostBack="True" runat="server" Width="130px" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                        runat="server" Enabled="True" TargetControlID="txtPriceIncludingVat"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label21" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtPurchaseVAT" CssClass="quantity" Style="background-color: #CAFDD2"
                                            runat="server" AutoPostBack="True" ReadOnly="true" Width="100px"></asp:TextBox>
                                        <asp:Label ID="vdsAmount" runat="server" Visible="false" />
                                        <asp:Label ID="lblPurchaseVAT" runat="server" Text="" /><asp:Label ID="Label25" runat="server"
                                            Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                        runat="server" Enabled="True" TargetControlID="txtPurchaseVAT"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label26" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtPurchaseSD" CssClass="quantity" Style="background-color: #CAFDD2"
                                            runat="server" AutoPostBack="True" ReadOnly="true" Width="100px"></asp:TextBox>
                                        <asp:Label ID="lblPurchaseSD" runat="server" Text="" /><asp:Label ID="Label33" runat="server"
                                            Text="%"></asp:Label>
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                                        runat="server" Enabled="True" TargetControlID="txtPurchaseSD"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                
                                     <div class="test-label">
                                        <asp:Label ID="Label2" runat="server" Text="AIT:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtPurchaseAIT" CssClass="quantity" Style="background-color: #CAFDD2"
                                            runat="server" AutoPostBack="True" ReadOnly="true" Width="100px"></asp:TextBox>
                                        <asp:Label ID="lblPurchaseAIT" runat="server" Text="" /><asp:Label ID="Label4" runat="server"
                                            Text="%"></asp:Label>
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12"
                                                        runat="server" Enabled="True" TargetControlID="txtPurchaseAIT"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                    
                                    
                                   
                                    <div class="test-label">
                                    <asp:CheckBox ID="chkSaleValue" runat="server" Text="Add Sale Value" ForeColor="green" OnCheckedChanged="chkSaleValue_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="row" runat="server" id="part_b">

                                 <div class="test-label">
                                        <asp:Label ID="lblSaleUnitPrice" runat="server" Text="Unit Price(S):" Style="margin-left: 0px;" Visible="false" /><br />
                                        <asp:TextBox ID="txtSaleUnitPrice" CssClass="category" runat="server" AutoPostBack="True" Style="background-color: #D4FCFF"
                                            OnTextChanged="txtSaleUnitPrice_TextChanged" Visible="false" Width="130px"/>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleUnitPrice"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                       <%-- <asp:Label ID="lblSaleUnitPrice" runat="server" Text="" Style="margin-left: 0px;"
                                            Visible="false" />--%>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="lblSaleVatablePrice" runat="server" Text="Total(P):" Style="margin-left: 0px;" Visible="false" /><br />
                                        <asp:TextBox ID="txtSaleVatablePrice" CssClass="category" Style="background-color: #D4FCFF"
                                            runat="server" AutoPostBack="True" OnTextChanged="txtVatablePrice_TextChanged" Visible="false" Width="130px"/>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleVatablePrice"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                    <div class="test-label">
                                        <asp:Label ID="lblSalesVat" runat="server" Text="VAT:" Style="margin-left: 0px;" Visible="false" /><br />
                                        <asp:TextBox ID="txtSaleVat" CssClass="quantity" Style="background-color: #D4FCFF"
                                            runat="server" AutoPostBack="True" Visible="false" Width="100px"></asp:TextBox>
                                        <asp:Label ID="lblSaleVat" runat="server" Text="" Visible="false" /><asp:Label ID="lblVatPercent" runat="server"
                                            Text="%" Visible="false"></asp:Label>
                                          <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleVat"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="lblSalesSD" runat="server" Text="SD:" Style="margin-left: 0px;" Visible="false" /><br />
                                        <asp:TextBox ID="txtSaleSD" CssClass="quantity" Style="background-color: #D4FCFF"
                                            runat="server" AutoPostBack="True" Visible="false" Width="100px"></asp:TextBox>
                                        <asp:Label ID="lblSaleSD" runat="server" Text="" Visible="false"/><asp:Label ID="lblSDPercent" runat="server"
                                            Text="%" Visible="false"></asp:Label>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleSD"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>

                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp1" runat="server" />
                                       
                                        <asp:Label ID="lblProperty1" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty1" runat="server" AutoPostBack="True" 
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp2" runat="server" />
                                        
                                        <asp:Label ID="lblProperty2" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty2" runat="server" AutoPostBack="True"                                             
                                            Visible="false" CssClass="category" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp3" runat="server" />
                                      
                                        <asp:Label ID="lblProperty3" runat="server" Visible="false"><span id="ddd" class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty3" runat="server" AutoPostBack="True"                                             
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty3_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp4" runat="server" />
                                        
                                        <asp:Label ID="lblProperty4" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty4" runat="server" AutoPostBack="True" 
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty4_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp5" runat="server" />
                                        <asp:Label ID="lblProperty5" runat="server" Text="" Visible="false"><span class="required"> * </span>:</asp:Label><br />
                                        <asp:DropDownList ID="drpProperty5" runat="server" AutoPostBack="True" 
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty5_SelectedIndexChanged">
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
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11"
                                                        runat="server" Enabled="True" TargetControlID="txtvdsamount"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
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
                                <div class="row" style="margin-top: 1%" runat="server" id="part_c">
                                 <div class="test-check" style="margin-top:-15px">
                                        <asp:CheckBox ID="chkTaxDeducted" runat="server" OnCheckedChanged="chkTaxDeducted_CheckedChanged" Text="VDS" />
                                        <asp:CheckBox ID="chkExempted" style="margin-top:0px" runat="server" Text="Exempted" AutoPostBack="True"  Enabled="False" OnCheckedChanged="chkExempted_CheckedChanged" />
                                        <asp:CheckBox ID="chkRebatable" runat="server" Enabled="true" Text="Rebatable" />
                                        <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" AutoPostBack="true" Enabled="False" OnCheckedChanged="chkZeroRate_CheckedChanged" />
                                        <asp:CheckBox ID="chkIsFixed" runat="server" Text="Fixed VAT" AutoPostBack="true" Enabled="false" />
                                        <asp:CheckBox ID="chkMrp" runat="server" Text="MRP" AutoPostBack="true" Enabled="false" />
                                        <asp:HiddenField ID="hdZerorate" runat="server" />
                                        <asp:HiddenField ID="hdrebatable" runat="server" />
                                        <asp:HiddenField ID="HiddenIsTruncated" runat="server" />
                                    </div>
                                </div>
                                <div class="row"  runat="server" id="part_d">
                                    <asp:Label ID="lblMessage" runat="server" style="font-size:20px" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    
                                    <div class="test-btn">
                                        
                                         <div class="test-btn" id="div_N">
                                         <asp:Panel ID="ModalPanel" runat="server" Width="800" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td colspan="4">
                                                        <h2 style="color:white;text-align:center;font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;font:bold;background-color:cornflowerblue;">
                                                            Check Payment Information</h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkCash" runat="server" Text="Cash" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtCashAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox>
                                                      
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkCredit" runat="server"  style="margin-left:10px" Text="Credit" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                     <td> <asp:TextBox ID="txtCreditAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                         <asp:CheckBox ID="chkCheque" runat="server" Text="Cheque" style="margin-left:10px"  onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtChequeAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox>
                                                      
                                                    </td>
                                                    
                                                    <td>
                                                       <asp:CheckBox ID="chkRocket" runat="server" Text="Rocket (DBBL Mobile)"  style="margin-left:10px" onclick="chkCheckedEvent(this);"/>
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtRocketAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox>
                                                      
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                       <asp:CheckBox ID="chkBkash" runat="server" Text="bKash"  style="margin-left:10px" onclick="chkCheckedEvent(this);"/>
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtbKashAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox>
                                                        
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkTT" runat="server" Text="Telephone Transfer" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtTPTAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkEFT" runat="server" Text="EFT"  style="margin-left:10px"  onclick="chkCheckedEvent(this);" ToolTip="Electronic Fund Transfer"/>
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtEFTAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox>
                                                       
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="CheDebitCard" runat="server" style="margin-left:10px" Text="Dr./Cr. Card" onclick="chkCheckedEvent(this);"/>
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtDebitCartAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;"></asp:TextBox>
                                                         
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkPayOrder" runat="server"  style="margin-left:10px" Text="Pay Order" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td> 
                                                       <asp:TextBox ID="txtPayOrderAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;" ></asp:TextBox>
                                                     
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="ChkOther" runat="server" Text="Other" style="margin-left:10px" onclick="chkCheckedEvent(this);"/>
                                                    </td>
                                                    <td> 
                                                        <asp:TextBox ID="txtOthersAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:130px;" ></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                        <td>
                                           <asp:Label ID="lbl_transaction_id" style="display:none;" runat="server" Text="Payment Info" ForeColor="red"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_transaction_id" style="display:none;" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </td>
                                       
                                    </tr>
                                                <tr>
                                                    <td>
                                                        
                                                    </td>
                                                    <td>
                                                     
                                                    </td>
                                                    <td>
                                                     
                                                    </td>
                                                    <td>
                                                     
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        
                                                    </td>
                                                    <td>
                                                       
                                                    </td>
                                                     <td>
                                                       
                                                    </td>
                                                     <td style="text-align:right;">
                                                         <asp:HiddenField runat="server" ID="txtTotalPaid"/>
                                                         <asp:HiddenField runat="server" ID="txtExtraPaid"/>
                                                          <asp:Button ID="OKButton" runat="server" CssClass="button" Text="OK" Width="50px" OnClick="OKButton_Click" OnClientClick="confirmPayment()"/>
                                                    </td>
                                                </tr>
                                            </table>
                                           
                                        </asp:Panel>
                                             </div>
                                        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton" BackgroundCssClass="modalPopup" PopupControlID="ModalPanel"/>
                                        <asp:HiddenField ID="hdItemType" runat="server" />
                                        <asp:HiddenField ID="hdBookId" runat="server" />
                                        <asp:HiddenField ID="hdPageNo" runat="server" />
                                        <asp:HiddenField ID="hdIsExempted" runat="server" />
                                    </div>

                                    <div class="test-btn">
                                        <asp:Button ID="btnAdd" runat="server" class="btn-btn" style="background-color:#B681B7" OnClick="btnAddItem_Click" Text="Add Item" />&nbsp
                                    </div>
                                     <div class="test-btn">
                                      <asp:Button ID="ClientButton" runat="server" Style="background-color:#9C987B" Text="Add Payment" class="btn-btn" />
                                       
                                    </div>
                                    <div class="test-btn">
                                        <asp:Button ID="btnSave" runat="server" style="background-color:#4CAF50" class="btn-btn" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                    <div class="test-btn">
                                        <asp:Button ID="btnClear" runat="server"  style="background-color:#908F8D" class="btn-btn" OnClick="btnClear_Click" Text="Clear" />
                                    </div>
                                </div>
                                <div class="row" runat="server" id="part_e">
                                    <div class="col-md-12">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6">
                                           
                                                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="File_OnChange(this)"  style="background:#E0EBF5" />
                                                    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />
                                                    <asp:Label runat="server" ID="Label11"></asp:Label>
                                                    <asp:HiddenField ID="lblFileName" runat="server"></asp:HiddenField> 
                                                    <asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn btn-primary btn-sm" />
                                               
                                           
                                        </div>
                                        <div class="col-sm-3"></div>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="part_v">
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-4">
                                                <label class="col-sm-5 control-label text-right">Voucher No :</label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList runat="server" ID="ddlVoucher" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVoucher_SelectedIndexChanged" />
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <label class="col-sm-5 control-label text-right">GRN No :</label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList runat="server" ID="ddlGRNNo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGRNNo_SelectedIndexChanged" />
                                                </div>
                                            </div>
                                             <div class="col-sm-4">
                                                 <asp:Button runat="server" ID="btnShowDataByVoucher" CssClass="btn btn-success btn-sm" Text="Search" OnClick="btnShowDataByVoucher_Click" />
                                                 <asp:Button runat="server" ID="btnGRNVoucherSave" CssClass="btn btn-primary btn-sm" Text="Save" OnClick="btnGRNVoucherSave_Click" />
                                               
                                             </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary panel-primary-custom">
                        <div class="panel-body">
                            <div class="gridDiv table-responsive paddingsmall">
                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                    DataKeyNames="ItemID,RowNo" Width="100%" OnSelectedIndexChanged="gvItem_SelectedIndexChanged"
                                     OnRowDeleting="gvItem_RowDeleting">
                                    <Columns>
                                         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                        <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                                        <asp:BoundField HeaderText="Property1" DataField="IntProperty1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                                        <asp:BoundField HeaderText="Property2" DataField="IntProperty2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                                        <asp:BoundField HeaderText="Property3" DataField="IntProperty3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Property4" DataField="IntProperty4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Property5" DataField="IntProperty5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Quantity" DataField="TempQuantity" />
                                        <asp:BoundField HeaderText="Unit" DataField="TempUnitCode" />
                                        <asp:BoundField HeaderText="Unit Price" DataField="TempUnitPrice" />
                                        <asp:BoundField HeaderText="Vatable Price" DataField="TotalPrice" />
                                        <asp:BoundField HeaderText="SD" DataField="PurchaseSD" />
                                        <asp:BoundField HeaderText="VAT" DataField="PurchaseVAT" />
                                        <asp:BoundField HeaderText="AIT" DataField="AIT_Amount" />
                                        <asp:BoundField DataField="TotalPurchasePrice" HeaderText="Total Purchase Price" />
                                        <asp:BoundField HeaderText="VDS" DataField="SrcTAXDeduct" />
                                        <asp:BoundField HeaderText="Exempted" DataField="Exempted" />
                                        <asp:BoundField HeaderText="Deemed Exp" DataField="DeemedExport" />
                                        <asp:BoundField HeaderText="Vat Rate" DataField="VATRate" Visible="false" />
                                        <asp:BoundField HeaderText="Rebatable" DataField="Rebatable" />
                                        <asp:BoundField HeaderText="Is Zero Rate" DataField="ZeroRate" />
                                        <asp:BoundField HeaderText="Is Fixed VAT" DataField="Fixed" />
                                        <asp:BoundField HeaderText="Is Reduced" DataField="Truncated" />
                                        <asp:BoundField HeaderText="Is MRP" DataField="Mrp" />
                                        <asp:BoundField HeaderText="Property1" DataField="Property1"/>
                                        <asp:BoundField HeaderText="Property2" DataField="Property2" />
                                        <asp:BoundField HeaderText="Property3" DataField="Property3" />
                                        <asp:BoundField HeaderText="Property4" DataField="Property4" />
                                        <asp:BoundField HeaderText="Property5" DataField="Property5" />
                                         <asp:BoundField HeaderText="Remarks" DataField="RemarksDetail" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                       
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>
                            <div class="gridDiv table-responsive paddingsmall">
                                 <asp:GridView ID="gvExcelFile"  runat="server" AutoGenerateColumns="false" CellPadding="4" OnRowDataBound="Test_OnRowDataBound" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
                                     <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="itemID" Value='<%# Eval("ItemID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="SizeID" Value='<%# Eval("IntProperty1") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="ColorID" Value='<%# Eval("IntProperty2") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="GradeID" Value='<%# Eval("IntProperty3") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="CompanyID" Value='<%# Eval("IntProperty4") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="SpecificationID" Value='<%# Eval("IntProperty5") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="CDStatus" Value='<%# Eval("CDStatus") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="RDStatus" Value='<%# Eval("RDStatus") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="SDStatus" Value='<%# Eval("SDStatus") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="VATStatus" Value='<%# Eval("VATStatus") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="AT_Status" Value='<%# Eval("AT_Status") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="AITStatus" Value='<%# Eval("AITStatus") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="ATVStatus" Value='<%# Eval("ATVStatus") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="TTIStatus" Value='<%# Eval("TTIStatus") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                 </Columns>  
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />  
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                                </asp:GridView>  
                            </div>
                            <div class="gridDiv table-responsive paddingsmall">
                                <asp:GridView runat="server" ID="gvVoucher" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvVoucher_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="ItemID" Value='<%# Eval("item_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Item">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="ItemName" Text='<%# Eval("item_name") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="UnitID" Value='<%# Eval("unit_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Unit">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="UnitName" Text='<%# Eval("unit_code") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" onkeyup="calculation(this)" style="text-align:right" ID="txtgvQuantity" Text='<%# Eval("quantity") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Prev. Rate">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" style="text-align:right" ID="txtgvPrevRate" Text='<%# Eval("unit_price") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Current Rate">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" onkeyup="calculation(this)" style="text-align:right" ID="txtgvCurrentRate" Text='<%# Eval("unit_price") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText ="Dis. Amount">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" onkeyup="calculation(this)" style="text-align:right" ID="txtgvDisAmount" Text='<%# Eval("discount") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText ="Tax">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" onkeyup="calculation(this)" style="text-align:right" ID="txtgvTax" Text='<%# Eval("tax") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Amount">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" style="text-align:right" ID="txtgvAmount" Text='<%# Eval("total_amount") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Difference in %">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" style="text-align:right" ID="txtgvDifference" Text='<%# Eval("Difference") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        <div style="height: 5px"></div>
                        <div style="text-align: right">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" Text="Total Purchase Amount :"></asp:Label> <asp:TextBox ID="txtTotalPurchasePrice" Width="130px" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
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
                 <uc2:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
</asp:Content>
