<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Sale_ApproveSaleChallan, App_Web_lqwzozjx" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    .
     <link href="../../Styles/panel.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <style>
        .m {
            padding-top: 6px;
            font-size: 12px;
        }

        .hiddencol {
            display: none;
        }
    </style>
    <script>
        $(document).ready(function () {

        });
        function check(id) {
            document.getElementById("<%= chkTaxDeducted.ClientID %>").style.color = "black";
        }
        function ShowModalPopup() {
            var panel = document.getElementById("<%=mpe.ClientID%>");           
            panel.setAttribute('style', 'display:block;');
            //$find("ModalPanel").show();
            //alert("abc");
            //$("[id*=ModalPanel]").show();
            //$("[id*=mpe]").show();
            return false;
        }
        function confirmPayment() {
            var total = $("[id*=txtTotalSalePrice]").val();
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
           if ($("[id*=chkCheque]").prop("checked") && $("[id*=txt_transaction_id]").val() == "") {
             
               alert("Please fill up Payment Info");            
               $("[id*=div_N]").show();
               return;
           }
           else {
               $("[id*=div_N]").hide();
           }
           if (given == 0) {
               alert("Payment Incomplete");
               $("[id*=div_N]").show();
               return;
           }
           else if (extra > 0) {
                alert("WARNING !! You have given " + extra + " taka extra !");
                $("[id*=div_N]").show();
                return;
            }
            else {

                //if (extra < 0) {
                //    alert("WARNING !! You have to pay " + (extra * (-1)) + " taka more !");
                //    $("[id*=div_c]").show();
                //    return;
                //}

                //else {
                   
                    alert("Payment Complete");
                    $("[id*=div_N]").hide();
                }
            //}
            return true;
        }

        function chkCheckedEvent() {
            //var cash = $("#chkCash").val();

            var total = $("[id*=txtTotalSalePrice]").val();
            total = !isNaN(total) ? Number(total) : 0;

            var paid = 0;

            var payments = $(".onlyFloat.payment");
            $.each(payments, function (index, value) {
                var amount = !isNaN($(value).val()) ? Number($(value).val()) : 0;
                paid += amount;
            });



            var remaining = total - paid;
            var remains = Math.round(parseFloat(remaining).toFixed(8) * 100) / 100;
            // if (remaining < 0) { remaining = 0; } // for making remaining value 0;

            if ($("[id*=chkCash]").prop("checked")) {
                if (!$("[id*=txtCashAmount]").val()) { $("[id*=txtCashAmount]").val(remains); }
                $("[id*=txtCashAmount]").show();
            } else {
                $("[id*=txtCashAmount]").hide();
                $("[id*=txtCashAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkCheque]").prop("checked")) {
                if (!$("[id*=txtChequeAmount]").val()) { $("[id*=txtChequeAmount]").val(remains); }
                $("[id*=txtChequeAmount]").show();
                $("[id*=lbl_transaction_id]").show();
                $("[id*=txt_transaction_id]").show();
            } else {
                $("[id*=txtChequeAmount]").hide();
                $("[id*=lbl_transaction_id]").hide();
                $("[id*=txt_transaction_id]").hide();
                $("[id*=txtChequeAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkBkash]").prop("checked")) {
                if (!$("[id*=txtbKashAmount]").val()) { $("[id*=txtbKashAmount]").val(remains); }
                $("[id*=txtbKashAmount]").show();
            } else {
                $("[id*=txtbKashAmount]").hide();
                $("[id*=txtbKashAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkTT]").prop("checked")) {
                if (!$("[id*=txtTPTAmount]").val()) { $("[id*=txtTPTAmount]").val(remains); }
                $("[id*=txtTPTAmount]").show();
            } else {
                $("[id*=txtTPTAmount]").hide();
                $("[id*=txtTPTAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkEFT]").prop("checked")) {
                if (!$("[id*=txtEFTAmount]").val()) { $("[id*=txtEFTAmount]").val(remains); }
                $("[id*=txtEFTAmount]").show();
            } else {
                $("[id*=txtEFTAmount]").hide();
                $("[id*=txtEFTAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=CheDebitCard]").prop("checked")) {
                if (!$("[id*=txtDebitCartAmount]").val()) { $("[id*=txtDebitCartAmount]").val(remains); }
                $("[id*=txtDebitCartAmount]").show();
            } else {
                $("[id*=txtDebitCartAmount]").hide();
                $("[id*=txtDebitCartAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkPayOrder]").prop("checked")) {
                if (!$("[id*=txtPayOrderAmount]").val()) { $("[id*=txtPayOrderAmount]").val(remains); }
                $("[id*=txtPayOrderAmount]").show();
            } else {
                $("[id*=txtPayOrderAmount]").hide();
                $("[id*=txtPayOrderAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=ChkOther]").prop("checked")) {
                if (!$("[id*=txtOthersAmount]").val()) { $("[id*=txtOthersAmount]").val(remains); }
                $("[id*=txtOthersAmount]").show();
            } else {
                $("[id*=txtOthersAmount]").hide();
                $("[id*=txtOthersAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkCredit]").prop("checked")) {
                if (!$("[id*=txtCreditAmount]").val()) { $("[id*=txtCreditAmount]").val(remains); }
                $("[id*=txtCreditAmount]").show();
            } else {
                $("[id*=txtCreditAmount]").hide();
                $("[id*=txtCreditAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkRoccket]").prop("checked")) {
                if (!$("[id*=txtRocketAmount]").val()) { $("[id*=txtRocketAmount]").val(remains); }
                $("[id*=txtRocketAmount]").show();
            } else {
                $("[id*=txtRocketAmount]").hide();
                $("[id*=txtRocketAmount]").val("");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                            <%--Sale Challan / বিক্রয় চালানপত্র (মূসক-১১)--%>
                            Pre Approval Sale Challan / বিক্রয় চালানপত্র (মূসক-৬.৩)
                        </div>
                        <div class="panel-body">
                            <div class="row" style="background-color: #FFD9C3; margin-top: -1.15%;">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Name :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="lt_companyName" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="orgVDS" Visible="false" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Address :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="It_companyAddress" runat="server"></asp:Label>
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
                                            <asp:DropDownList ID="drpBranchName" runat="server" CssClass="form-control" AutoPostBack="true"
                                                OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged">
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
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Registration Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpRegType" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpRegType_SelectedIndexChanged">
                                                <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                <asp:ListItem Value="1">Regular Registered (VAT)</asp:ListItem>
                                                <asp:ListItem Value="4">Registered For Turnover</asp:ListItem>
                                                <asp:ListItem Value="5">Not Registered</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <%-- <div class="col-sm-2">
                                            <asp:Button ID="Button1" runat="server" Style="float: left;" OnClick="btnAddParty_Click" Text="New" />
                                        </div>--%>
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
                                        <label class="col-sm-5 control-label text-right">Category Type</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpTransaction2" CssClass="form-control select2" runat="server" OnSelectedIndexChanged="drpTransaction2_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="S">Service</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="G">Goods</asp:ListItem>
                                                <asp:ListItem Value="B">Both</asp:ListItem>
                                                <%--//08/01/2020 added by the instruction of ruhul vai--%>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <%--<label class="col-sm-5 control-label text-right">Customer Name :</label>--%>
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Customer Name :</label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtPartyName" runat="server" Visible="False" class="form-control"></asp:TextBox>
                                            <asp:Label runat="server" ID="partyVDS" Visible="false" Text="false" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnAddParty" runat="server" Style="float: left;" OnClick="btnAddParty_Click" Text="New" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer Address :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox class="form-control" ID="txtAddress" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtPartyBIN" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Business Info :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtBusinessInfo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                        <%--<label class="col-sm-5 control-label text-right">DO/Challan No 6.3 :</label>--%>
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>DO/Challan No 6.3 :</label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtChallanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-2" style="padding-left: 0px; padding-right: 0px;">
                                            <asp:CheckBox ID="chkDiscard" runat="server" AutoPostBack="True" OnCheckedChanged="chkDiscard_CheckedChanged" Text="Discard" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Challan Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtChallanDate" Style="width: 50%; float: left" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy" Enabled="false"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate" />
                                            <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                                            <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Delivery Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtDeliveryDate" CssClass="form-control" runat="server"
                                                Style="width: 50%; float: left" DateFormat="dd/MM/yyyy" OnTextChanged="txtDeliveryDate_TextChanged"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDeliveryDate" />
                                            <asp:DropDownList ID="drpDlDtHr" CssClass="form-control" runat="server" Style="width: 25%; float: left" OnSelectedIndexChanged="drpDlDtHr_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="drpDlDtMin" CssClass="form-control" runat="server" Style="width: 25%; float: left" OnSelectedIndexChanged="drpDlDtMin_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <%-- <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Service Charge :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtServiceCharge" CssClass="form-control" placeholder="Enter Percent (if 10%, write 10)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>--%>



                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Sale Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpSaleType" CssClass="form-control select2" runat="server">
                                                <asp:ListItem Selected="True" Value="S">--SELECT--</asp:ListItem>
                                                <%--//13/02/2020 added by the instruction of ruhul vai--%>

                                                <asp:ListItem Value="W">WholeSale</asp:ListItem>
                                                <asp:ListItem Value="R">Retail</asp:ListItem>
                                                <asp:ListItem Value="P">Procurement Provider</asp:ListItem>
                                                <%--//08/01/2020 added by the instruction of ruhul vai--%>
                                                <asp:ListItem Value="T">Trader</asp:ListItem>
                                                <%--//13/01/2020 added by the instruction of ruhul vai--%>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Transaction Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpTransaction" CssClass="form-control select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpTransaction_CheckedChanged">
                                                <asp:ListItem Selected="True">Local</asp:ListItem>
                                                <asp:ListItem>Export</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Ultimate Destination :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox CssClass="form-control" ID="txtDestination" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Agreement No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtAggrementNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdPriceID" runat="server" />
                                            <asp:HiddenField ID="hdUnitSDAmt" runat="server" />
                                            <asp:HiddenField ID="hdUnitVATAmt" runat="server" />
                                            <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblOrgAddress" runat="server" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Discount :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtdiscountm" CssClass="form-control" />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                runat="server" Enabled="True" TargetControlID="txtdiscountm"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Discount % :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtdiscountPctm" CssClass="form-control" />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11"
                                                runat="server" Enabled="True" TargetControlID="txtdiscountPctm"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>

                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpVehicleType" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <%-- <label class="col-sm-5 control-label text-right">Remarks :</label>--%>
                                        <div class="col-sm-7">
                                            <%-- <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Remarks :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                             
                              <div class="row" runat="server" id="div_installment">
                               <hr style="border: 1px solid;" />
                                 <div class="row">
                                  
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>No of Installment :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtnoofInstalment" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>                              
                                <div class="col-md-4 hiddencol">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Total:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtTotalSchedule" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                          
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Total Payment:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtTotalPayment" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Down Payment:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtDownPayment" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                 </div>
                               </div>
                           
                                 
                            <div class="row">
                               <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Total VAT:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtTotalVATSchedule" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                        <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Total SD:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtTotalSdSchedule" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                          <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Total AIT:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtTotalAITSchedule" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                          </div>
                            <div class="row">
                                      <div class="col-md-12">
                                  <div class="test-btn">
                                        <asp:Button ID="btnGenerate" runat="server" Style="background-color: #4CAF50" class="btn-btn" Text="Generate Schedule" OnClick="btnGenerate_Click"  />
                                    </div>
                                           </div>
                                       </div>                    
                            <asp:GridView ID="grdInstalment" runat="server" AutoGenerateColumns="False"
                            CssClass="mydatagrid" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Schedule No" DataField="scheduleNo"/>
                               <asp:BoundField HeaderText="Rest Amount" DataField="restAmount"  DataFormatString="{0:n}"/>
                                <asp:BoundField HeaderText="VAT" DataField="restvat"  DataFormatString="{0:n}"/>
                                <asp:BoundField HeaderText="SD" DataField="restsd"  DataFormatString="{0:n}"/>
                                <asp:BoundField HeaderText="AIT" DataField="restait"  DataFormatString="{0:n}"/>
                                <asp:BoundField HeaderText="Date" DataField="tenurePeriod" DataFormatString="{0:dd/MM/yyyy}"/>                          
                            </Columns>
                        </asp:GridView>
                      </div>
                        
                            <hr style="border: 1px solid;" />
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Purchase Order No:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtPurchaseOrderNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Delivery Challan No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtDeliveryChallanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <%-- <label class="col-sm-5 control-label text-right">Remarks :</label>--%>
                                        <div class="col-sm-7">
                                            <%-- <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">MRP No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtMrpNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Project Details:</label>
                                        <div class="col-sm-7">
                                            <Textarea ID="txtProjectDetails" style="width:240px;" CssClass="form-control" runat="server"></Textarea>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">To the order of:</label>
                                        <div class="col-sm-7">
                                            <Textarea ID="txtClientContactPerson" style="width:240px;" CssClass="form-control" runat="server"></Textarea>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <%-- <label class="col-sm-5 control-label text-right">Remarks :</label>--%>
                                        <div class="col-sm-7">
                                            <%-- <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div>
                                 
                                
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Contact Person :</label>
                                        <div class="col-sm-7">
                                            <Textarea  ID="txtOwnContactPerson" style="width:240px;" CssClass="form-control" runat="server"></Textarea>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Approval Reference No:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtApprovalRefNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                
                            </div>                            
                            <div class="test-check" style="padding-left:30px;display:none;">
                                 <asp:Label ID="lblstao" runat="server" Visible="false"></asp:Label><br />
                                 <asp:CheckBox ID="isApprroval" runat="server" Text="Send to Authorized officer" AutoPostBack="true"/>
                            </div>
                            <div class="row">                               

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="lblDiscardReason" CssClass="col-sm-5 control-label text-right" Style="font-weight: bold" runat="server" Text="Discard Reason :" Visible="False"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpDiscardReason" CssClass="form-control select2" runat="server" Visible="False">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="lblExpDt" CssClass="col-sm-5 control-label text-right" Style="font-weight: bold" runat="server" Text="Export Date :" Visible="False"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtExportDate" CssClass="form-control" runat="server"
                                                DateFormat="dd/MM/yyyy" OnTextChanged="txtChallanDate_TextChanged" Visible="False"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtExportDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="lblExpBillNo" CssClass="col-sm-5 control-label text-right" Style="font-weight: bold" runat="server" Text="Export Bill No :" Visible="False"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtExpBillNo" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="lblBank" CssClass="col-sm-5 control-label text-right" Style="font-weight: bold" runat="server" Text="Bank :" Visible="False"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpBank" CssClass="form-control select2" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="drpBank_SelectedIndexChanged" Visible="False">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="lblBranch" CssClass="col-sm-5 control-label text-right" Style="font-weight: bold" runat="server" Text="Branch :" Visible="False"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpBranch" CssClass="form-control select2" runat="server" Visible="False">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--   commented on 28-07-2019--%>
                            <div class="row">
                                <%-- <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Instalment :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtInstallment" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                            <%--   commented on 28.07.2019--%>
                            <%--    <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Mobile No. :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtMobileNo" AutoPostBack="true" OnTextChanged="txtMobileNo_TextChanged" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">National Id :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtNationalId" CssClass="form-control" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Registration Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpRegType" runat="server" CssClass="form-control" Enabled="false">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Regular Registered(Vat)</asp:ListItem>
                                                <asp:ListItem Value="4">Registered ForTurnover</asp:ListItem>
                                                <asp:ListItem Value="5">Not Registered</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px">
                            <div class="container-fluid">
                               
                                <div class="row" runat="server" id="div_a">
                                    <div class="test-label">
                                        <asp:Label ID="Label7" runat="server" Text="Category :"></asp:Label><br />
                                        <asp:DropDownList ID="drpCategory" CssClass="present-address-tb select2" runat="server" Style="width: 130px; height: 27px; margin-left: 0px; text-align: left"
                                            OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                            AutoPostBack="True" TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label15" runat="server" Text="Sub Cat:"></asp:Label><br />
                                        <asp:DropDownList ID="drpSubCategory" CssClass="present-address-tb select2" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                                            Style="width: 130px; height: 27px; margin-left: 0px; text-align: left" TabIndex="2">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label" style="display: none;">
                                        <asp:Label ID="Label40" runat="server" Text="Search Product:" /><br />
                                        <asp:TextBox ID="productName" CssClass="present-address-tb" AutoPostBack="true" Style="width: 160px; height: 27px; margin-left: 0px; text-align: left"
                                            placeholder="Search Product"
                                            runat="server" OnTextChanged="productName_TextChanged" TabIndex="3" />
                                        <div id="listPlacement" style="height: 100px; overflow: scroll;">
                                        </div>
                                        <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName"
                                            ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement" MinimumPrefixLength="1"
                                            EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetSaleProductByProductName">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label16" runat="server" Text="Item Name:" Style="margin-left: 0px;" /><br />
                                        <asp:DropDownList ID="drpItem" CssClass="present-address-tb select2" Style="width: 250px; margin-left: 0px; text-align: left"
                                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged"
                                            Height="27px" TabIndex="4" />
                                        <asp:Label runat="server" ID="lblProductType" Visible="false" /><br />
                                        <asp:Label ID="Label38" Style="margin-left: 0px" runat="server" Text="SKU :"></asp:Label>
                                        <asp:Label ID="lblSku" runat="server"></asp:Label>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField runat="server" ID="txtSpecification" />

                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                        <asp:TextBox ID="lblHSCode" CssClass="present-address-tb" runat="server" Style="width: 100px; height: 27px; margin-left: 0px"
                                            Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label25" runat="server" Text="Batch No" /><br />
                                        <asp:DropDownList ID="txtBatchNo" CssClass="present-address-tb select2" Style="width: 100px; margin-left: 0px; text-align: left"
                                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtBatchNo_SelectedIndexChanged"
                                            Height="27px" TabIndex="4" />
                                        <%--<asp:TextBox ID="txtBatchNo" CssClass="present-address-tb select2" Style="width: 75px; margin-left: 0px; text-align: left"
                                                          runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtBatchNo_SelectedIndexChanged"
                                                          Height="27px" TabIndex="4" />--%>
                                        <%--<asp:TextBox ID="txtBatchNo" CssClass="present-address-tb" Style="width: 75px; margin-left: 0px; text-align: left"                                                          runat="server"
                                                          Height="27px" TabIndex="4" ></asp:TextBox>
                                        --%>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label18" runat="server" Text="Quantity:" Style="margin-left: 11px;" /><br />
                                        <asp:TextBox ID="txtFinalQuantity" CssClass="present-address-tb" Style="height: 27px; width:100px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"
                                            TabIndex="5"></asp:TextBox>
                                        <asp:Label ID="lblQuantityPrp" runat="server" class="hiddencol"  />
                                        <asp:Label ID="Label13" Style="margin-left: -60px;color: #008000;font-weight:bold" runat="server" Text="Avl. Stock:"></asp:Label>
                                        <asp:Label ID="lblAvailStock" Style="color: #008000;font-weight:bold"  runat="server" CssClass="hiddencol"></asp:Label>
                                         <asp:Label ID="lblavlStock" Style="color: #008000;font-weight:bold"  runat="server"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                            runat="server" Enabled="True" TargetControlID="txtQuantity"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                     <div class="test-label hiddencol">
                                    <asp:Label ID="Label29" runat="server" Text="" Style="margin-left: 0px;" />
                                    <asp:TextBox ID="txtQuantity" CssClass="category" runat="server"/>                                   
                                </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label41" runat="server" Text="Unit:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="lblUnit" CssClass="present-address-tb hiddencol" runat="server" Style="width: 70px; height: 27px; margin-left: 0px"
                                            TabIndex="6"></asp:TextBox>
                                         <asp:DropDownList ID="drpUnit" CssClass="unit select2" runat="server" Style="width: 80px" OnSelectedIndexChanged="drpUnit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label22" runat="server" Text="Unit Price:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtUnitPrice" CssClass="present-address-tb" Style="width:100px; height: 27px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged"
                                            TabIndex="7" />
                                        <asp:Label ID="lblUnitPrice" runat="server" Text="" Style="margin-left: 0px;" Visible="false" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                            runat="server" Enabled="True" TargetControlID="txtUnitPrice"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label5" runat="server" Text="Price:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtTotalPrice" CssClass="category" Style="background-color: #CAFDD2; width:130px;" runat="server" ReadOnly="true" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                            runat="server" Enabled="True" TargetControlID="txtTotalPrice"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label6" runat="server" Text="Price(Inc. VAT)" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtPriceIncludingVat" CssClass="category" Style="background-color: #CAFDD2; width: 130px;" OnTextChanged="txtPriceIncludingVat_TextChanged" AutoPostBack="True" runat="server" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                            runat="server" Enabled="True" TargetControlID="txtPriceIncludingVat"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label42" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="tbTotalVAT" CssClass="present-address-tb" Style="width: 100px; height: 27px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" TabIndex="8"></asp:TextBox>
                                       <asp:Label ID="lblfxdVT" runat="server" Text="" /> <asp:Label ID="lblVAT" runat="server" Text="" /><asp:Label ID="Label9" runat="server"
                                            Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                            runat="server" Enabled="True" TargetControlID="tbTotalVAT"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label43" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtTotalSD" CssClass="present-address-tb" Style="width:100px; height: 27px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" TabIndex="9"></asp:TextBox>
                                        <asp:Label ID="lblSD" runat="server" Text="" /><asp:Label ID="Label11" runat="server"
                                            Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                            runat="server" Enabled="True" TargetControlID="txtTotalSD"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>

                                    <div class="test-label">
                                        <asp:Label ID="Label4" Style="margin-left: 0px;" runat="server" Text="Dis. Amt"></asp:Label><br />
                                        <asp:TextBox ID="txtDiscount" runat="server" Style="width: 100px; height: 27px; margin-left: 0px" OnTextChanged="txtdiscountpct_TextChanged" AutoPostBack="true"
                                            CssClass="present-address-tb"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8"
                                            runat="server" Enabled="True" TargetControlID="txtDiscount"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label8" runat="server" Style="margin-left: 0px;" Text="Dis.(%) :"></asp:Label><br />
                                        <asp:TextBox ID="txtdiscountpct" runat="server" Style="width: 100px; height: 27px; margin-left: 0px" OnTextChanged="txtdiscount_TextChanged" AutoPostBack="true"
                                            CssClass="present-address-tb"></asp:TextBox>
                                        <asp:Label ID="lbldispct" runat="server" Text="" /><asp:Label ID="Label14" runat="server"
                                            Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" Enabled="True" TargetControlID="txtdiscountpct" ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>


                                    <div class="test-label">
                                        <asp:Label ID="Label26" runat="server" Style="margin-left: 0px;" Text="AIT"></asp:Label><br />
                                        <asp:TextBox ID="txtAIT" runat="server" Style="width: 100px; height: 27px; margin-left: 0px" 
                                                     CssClass="present-address-tb"></asp:TextBox>
                                        <asp:Label ID="lblAIT" runat="server" Text="" /><asp:Label ID="Label28" runat="server" Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" Enabled="True" TargetControlID="txtAIT" ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    
                                    
                                    <%--itemSerialInputs--%>
                                    <div class="test-label">
                                        <asp:Label ID="Label30" runat="server" Style="margin-left: 0px;" Text="Serial Codes :"></asp:Label><br />
                                        <asp:TextBox ID="txtItemSerials" TextMode="MultiLine" runat="server" Style="float: left; width: 250px; text-align: left"
                                            CssClass="present-address-tb"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" Enabled="True" TargetControlID="txtdiscountpct" ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                     <div class="test-label" runat="server" id="divHlthChrg" visible="false">
                                        <asp:Label ID="Label31" runat="server" Style="margin-left: 0px;" Text="Health Surcharge"></asp:Label><br />
                                        <asp:TextBox ID="txthlthcharge" runat="server" Style="width: 100px; height: 27px; margin-left: 0px" 
                                                     CssClass="present-address-tb"></asp:TextBox>
                                        <asp:Label ID="lblhlthcharge" runat="server" Text="" /><asp:Label ID="Label32" runat="server" Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" Enabled="True" TargetControlID="txtAIT" ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>


                                    <div class="test-label">
                                        <asp:Label ID="lblVDS" runat="server" Text="VDS:" Style="margin-left: 0px;" Visible="false" /><br />
                                        <asp:TextBox ID="txtVDS" CssClass="present-address-tb" Style="width: 100px; height: 27px; margin-left: 0px"
                                            Visible="false" runat="server" AutoPostBack="True" TabIndex="10"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="row" style="float:right;margin-right:10px;margin-top:10px">
                                    <div style="text-align: right; float: left; font-size: 14px;  border: 1px solid #ff00ff;">
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
                                </div>

                                <div class="row" style="margin-top: 1%" runat="server" id="div_b">
                                    <div class="test-label">
                                        <%--<asp:Label ID="lblProp11" runat="server" Text="" Visible="false"><span class="required"> * </span>Size:</asp:Label>--%><br />
                                        <asp:Label ID="lblProp11" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:Label ID="lblprpstk" runat="server" class="hiddencol"></asp:Label>
                                       <%-- <asp:DropDownList ID="drpProp11" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                            runat="server" Visible="false" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpProp1_SelectedIndexChanged">
                                        </asp:DropDownList>--%>
                                        <asp:DropDownList ID="drpProp11" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                                          runat="server" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="drpProp1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <%--<asp:Label ID="lblProp22" runat="server" Text="" Visible="false"><span class="required"> * </span>Color:</asp:Label>--%><br />
                                        <asp:Label ID="lblProp22" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                       <%-- <asp:DropDownList ID="drpProp22" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp2_SelectedIndexChanged"
                                            Visible="false">
                                        </asp:DropDownList>--%>
                                        <asp:DropDownList ID="drpProp22" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                                          runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="drpProp2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                       <%-- <asp:Label ID="lblProp33" runat="server" Font-Bold="False" Text="Grade:" Visible="false"><span class="required"> * </span>Grade:</asp:Label><br />--%>
                                        <asp:Label ID="lblProp33" runat="server" Font-Bold="False" Visible="false"><span class="required"> * </span></asp:Label><br />
                                       <%-- <asp:DropDownList ID="drpProp33" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp3_SelectedIndexChanged"
                                            Visible="false">
                                        </asp:DropDownList>--%>
                                        <asp:DropDownList ID="drpProp33" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                                          runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="drpProp3_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <%--<asp:Label ID="lblProp44" runat="server" Text="" Visible="false"><span class="required"> * </span>Box:</asp:Label><br />--%>
                                        <asp:Label ID="lblProp44" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <%--<asp:DropDownList ID="drpProp44" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp44_SelectedIndexChanged"
                                            Visible="false">
                                        </asp:DropDownList>--%>
                                        <asp:DropDownList ID="drpProp44" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                                          runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="drpProp44_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="lblBoxQty" runat="server" Text="No. of Box:" Visible="false"></asp:Label><br />
                                        <asp:TextBox ID="txtBoxQty" CssClass="present-address-tb" Style="width: 65px; height: 27px; margin-left: 0px"
                                            Visible="false" runat="server" AutoPostBack="True" OnTextChanged="txtBoxQty_TextChanged"></asp:TextBox>
                                    </div>
                                   
                                    <div class="test-label">
                                        <%--<asp:Label ID="lblProp55" runat="server" Text="" Visible="false"><span class="required"> * </span>Spacification:</asp:Label><br />--%>
                                        <asp:Label ID="lblProp55" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <%--<asp:DropDownList ID="drpProp55" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"
                                            Visible="false">
                                        </asp:DropDownList>--%>
                                        <asp:DropDownList ID="drpProp55" CssClass="present-address-tb" Style="margin-left: 0px; width: 120px; height: 27px"
                                                          runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"> 
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-check">
                                        <asp:Label ID="Label23" runat="server" Visible="false"></asp:Label><br />
                                        <asp:CheckBox ID="chkTaxDeducted" runat="server" onchange="check(this)" OnCheckedChanged="chkTaxDeducted_CheckedChanged"
                                            Text="VDS" AutoPostBack="true" />
                                    </div>
                                    <div class="test-check">
                                        <asp:Label ID="Label21" runat="server" Visible="false"></asp:Label><br />
                                        <%--<asp:CheckBox ID="chkExempted" runat="server" Text="Exempted" AutoPostBack="True"
                                            Enabled="False" OnCheckedChanged="chkExempted_CheckedChanged" />--%>
                                        <asp:CheckBox ID="chkExempted" runat="server" Text="Exempted" AutoPostBack="True"
                                            OnCheckedChanged="chkExempted_CheckedChanged" />
                                    </div>
                                    <div class="test-check">
                                        <asp:Label ID="Label27" runat="server" Visible="false"></asp:Label><br />
                                        <asp:CheckBox ID="chkReduced" runat="server" Text="Reduced" AutoPostBack="True"
                                        OnCheckedChanged="chkReduced_CheckedChanged" />
                                    </div>
                                    <div class="test-check">
                                        <asp:Label ID="Label19" runat="server" Visible="false"></asp:Label><br />
                                        <asp:CheckBox ID="chkRebatable" runat="server" Text="Rebatable" />
                                    </div>
                                    <div class="test-check">
                                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label><br />
                                        <asp:CheckBox ID="chkIsFixed" runat="server" Text="Fixed VAT" AutoPostBack="true" Enabled="false" />
                                    </div>
                                    <div class="test-check">
                                        <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label><br />
                                        <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" AutoPostBack="true" Enabled="False" OnCheckedChanged="chkZeroRate_CheckedChanged" />
                                    </div>
                                    <div class="test-check">
                                        <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label><br />
                                        <asp:CheckBox ID="chkMrp" runat="server" Text="MRP" AutoPostBack="true" Enabled="False" />
                                    </div>
                                   
                                     <div class="test-check">
                                        <asp:Label runat="server" Visible="false"></asp:Label><br />
                                        <asp:CheckBox ID="chkInexplicitExport" runat="server" AutoPostBack="true" Text="Deemed Export"
                                            Visible="false" OnCheckedChanged="chkInexplicitExport_CheckedChanged" />
                                    </div>
                                     <div>
                                        <asp:Label ID="Label10" Style="margin-left: 15px; float: left;" runat="server" Text="Remarks:"></asp:Label><br />
                                        <asp:TextBox ID="singleRemarks" TextMode="MultiLine" runat="server" Style="float: left; width: 250px; text-align: left"
                                            CssClass="present-address-tb"></asp:TextBox>
                                    </div>
                                     <div class="test-check" runat="server" id="partVDS">
                                        <asp:Label ID="lblvdstx" Style="float: left; margin-top: 3px"
                                            runat="server" Text="VDS Amount:"  />
                                        <asp:TextBox ID="txtvdsamount" runat="server" CssClass="present-address-tb" Style="width: 90px;
                                            margin-left: 3px; float: left; text-align: left; height: 27px" ></asp:TextBox>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12"
                                                        runat="server" Enabled="True" TargetControlID="txtvdsamount"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                     <div class="test-label">
                                        <asp:Label ID="lblMfgDate" runat="server" Text="Mfg. Date:" Visible="false"></asp:Label><br />
                                        <asp:TextBox ID="txtMfgDate" CssClass="present-address-tb" Style="width: 80px; height: 27px; margin-left: 0px"
                                            Visible="false" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                     <div class="test-label">
                                        <asp:Label ID="lblExpiryDate" runat="server" Text="Exp. Date:" Visible="false"></asp:Label><br />
                                        <asp:TextBox ID="txtExpiryDate" CssClass="present-address-tb" Style="width: 80px; height: 27px; margin-left: 0px"
                                            Visible="false" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </div>

                                     
                                </div>
                                 <div class="row" style="margin-top: 1%">
                                   
                                </div>
                                <div class="row" style="margin-top: 1%" runat="server" id="div_c">
                                   
                                    <div class="test-btn" id="div_N">
                                       
                                        <asp:Panel ID="ModalPanel" runat="server" Width="800" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td colspan="4">
                                                        <h2 style="color: white; text-align: center; font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; font: bold; background-color: cornflowerblue;">Check Payment Information</h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" Style="color: #0066ff">Total Sale Amount : </asp:Label>
                                                        <asp:Label runat="server" Style="color: #0066ff" ID="lblSaleamnt"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" Style="color: #0066ff">Credit Limit:</asp:Label>
                                                        <asp:Label runat="server" Style="color: #0066ff" ID="lblLimit"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" Style="color: #0066ff">Due:</asp:Label>
                                                        <asp:Label runat="server" Style="color: #0066ff" ID="lblDue"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkCash" runat="server" Text="Cash" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCashAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" TargetControlID="txtCashAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                        
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkCredit" runat="server" Text="Credit" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCreditAmount" runat="server" CssClass="form-control onlyFloat payment"  Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" Enabled="True" TargetControlID="txtCreditAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                        <asp:Label ID="lblcredlmt" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkCheque" runat="server" Text="Cheque" Visible="false" onclick="chkCheckedEvent(this);" Style="margin-left: 10px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChequeAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True" TargetControlID="txtChequeAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkRoccket" runat="server" Text="Rocket (DBBL Mobile)" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRocketAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" Enabled="True" TargetControlID="txtRocketAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkBkash" runat="server" Text="bKash" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtbKashAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" Enabled="True" TargetControlID="txtbKashAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkTT" runat="server" Text="Telephone Transfer" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTPTAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True" TargetControlID="txtTPTAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkEFT" runat="server" Text="EFT" Visible="false" onclick="chkCheckedEvent(this);" Style="margin-left: 10px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEFTAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%--   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True" TargetControlID="txtEFTAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="CheDebitCard" runat="server" Text="Dr./Cr. Card" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDebitCartAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtDebitCartAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkPayOrder" runat="server" Text="Pay Order" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPayOrderAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" Enabled="True" TargetControlID="txtPayOrderAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="ChkOther" runat="server" Text="Other" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOthersAmount" runat="server" CssClass="form-control onlyFloat payment" Style="display: none; width: 150px;"></asp:TextBox>
                                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtOthersAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_transaction_id" Style="display: none;" runat="server" Text="Payment Info" ForeColor="red"></asp:Label>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txt_transaction_id" Style="display: none;" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                    
                                                    </td>
                                                    <%--<td></td>
                                        <td></td>--%>
                                                </tr>


                                                <tr>
                                                    <td> </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td style="text-align: right;">
                                                        <asp:HiddenField runat="server" ID="txtTotalPaid" />
                                                        <asp:HiddenField runat="server" ID="txtExtraPaid" />
                                                        <asp:TextBox ID="chkrbt" runat="server"  CssClass="hiddencol"></asp:TextBox>
                                                        <%--<asp:Button ID="OKButton" runat="server" CssClass="button" Text="OK" Width="50px" OnClick="OKButton_Click"/>--%>
                                                        <asp:Button ID="OKButton" runat="server" CssClass="button" Text="OK" Width="50px" OnClick="OKButton_Click" OnClientClick="confirmPayment()"/>
                                                    </td>

                                                </tr>
                                            </table>

                                        </asp:Panel>
                                        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton"
                                            BackgroundCssClass="modalPopup" PopupControlID="ModalPanel" BehaviorID="RequoteModal"/>
                                        <asp:HiddenField ID="hdItemType" runat="server" />
                                        <asp:HiddenField ID="hdBookId" runat="server" />
                                        <asp:HiddenField ID="hdPageNo" runat="server" />
                                        <asp:HiddenField ID="Hiddentype_p" runat="server" />
                                        <%--<asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>--%>
                                   
                                         </div>
                                    
                                    <div class="test-btn">
                                        <asp:Button ID="btnAdd" runat="server" class="btn-btn" Style="background-color: #B681B7" OnClick="btnAddItem_Click" Text="Add Item" />
                                    </div>
                                          <div class="test-btn">
                                     <asp:Button ID="ClientButton" runat="server" Text="Add Payment"
                                            class="btn-btn" Style="background-color: #9C987B" />
                                    </div>
                                     <div class="test-btn">
                                        <asp:Button ID="btnApprove" runat="server" Style="background-color: #4CAF50" class="btn-btn" Text="Approve" OnClick="btnApprove_Click" />
                                    </div>
                                    <div class="test-btn">
                                        <asp:Button ID="btnSave" runat="server" Style="background-color: #4CAF50" class="btn-btn" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                    <div class="test-btn">
                                        <asp:Button ID="btnClear" runat="server" Style="background-color:  #4CAF50" class="btn-btn" OnClick="btnClear_Click"
                                            Text="Refresh" />
                                    </div>
                                      <div class="test-btn">
                                       <asp:CheckBox ID="chkInstallment" runat="server" Text="Installmen Payment" AutoPostBack="true" OnCheckedChanged="chkInstallment_CheckedChanged" />&nbsp&nbsp
                                      </div>
                                </div>
                              
                                <div class="row" style="margin-top: 1%">
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            <div class="table table-responsive">
                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid"
                                    HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                                    DataKeyNames="RowNo" Width="100%" OnRowDeleting="gvItem_RowDeleting" OnSelectedIndexChanged="gvItem_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                                        <asp:BoundField HeaderText="Batch No." DataField="BatchNo" />
                                        <asp:BoundField HeaderText="Property1" DataField="PropertyID1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Property2" DataField="PropertyID2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Property3" DataField="PropertyID3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Property4" DataField="PropertyID4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Property5" DataField="PropertyID5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                     <%--   <asp:BoundField HeaderText="Quantity" DataField="Quantity" DataFormatString="{0:n2}"/>
                                       --%>   
                                        <asp:BoundField HeaderText="Quantity" DataField="SaleQuantity" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                                        <asp:BoundField HeaderText="Unit Price" DataField="UnitPriceBDT" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="SD" DataField="SD" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="VAT" DataField="VAT" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="AIT" DataField="AIT" DataFormatString="{0:n2}"/>
                                        <asp:BoundField DataField="TotalSalePrice" HeaderText="Total Sale Price" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="VDS" DataField="SrcTAXDeduct" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Exempted" DataField="Exempted" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Deemed Exp" DataField="DeemedExport" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Is Fixed VAT" DataField="Fixed" />
                                        <asp:BoundField HeaderText="Is Zero Rate" DataField="ZeroRate" />
                                        <asp:BoundField HeaderText="Is Reduced" DataField="Truncated" />
                                        <asp:BoundField HeaderText="Is MRP" DataField="Mrp" />
                                        <asp:BoundField HeaderText="Is Rebatable" DataField="Rebatable" />
                                        <asp:BoundField HeaderText="Trns Type" DataField="TransactionType" />
                                        <asp:BoundField HeaderText="Vat Rate" DataField="VATRate" Visible="false" />
                                        <asp:BoundField HeaderText="type_p" DataField="type_p" Visible="false" />

                                        <asp:BoundField HeaderText="Property1" DataField="Property1" />
                                        <asp:BoundField HeaderText="Property2" DataField="Property2" />
                                        <asp:BoundField HeaderText="Property3" DataField="Property3" />
                                        <asp:BoundField HeaderText="Property4" DataField="Property4" />
                                        <asp:BoundField HeaderText="Property5" DataField="Property5" />

                                        <asp:BoundField HeaderText="Discount (TK)" DataField="Discount" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Discount (%)" DataField="Discount_pct" />
                                        <asp:BoundField HeaderText="Net Bill" DataField="Net_bill" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Remarks" DataField="RemarksDetail" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="White" />
                                </asp:GridView>
                            </div>
                     
                            <div style="text-align: right" class="hiddencol">
                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" Text="Total Sale Amount :"></asp:Label>
                                <asp:TextBox ID="txtTotalSalePrice" Width="130px" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <%--pending audit sale challans --%>

                    <div class="panel panel-primary">
            
                        <div class="panel-heading" style="text-align: center; font-size: 25px; font-weight: bold;
                    height: 30px; padding-top: 0px">
                                <b>Audit Sale Challans</b>
                            </div>
                    <div class="full_body_readyform">
                    <div class="clear_fix">
                    </div>

                    <asp:Panel ID="pnInput" CssClass="input-table tablefull center paddinglrb"  runat="server"  ScrollBars="Vertical">
                    <asp:GridView ID="Gv_audit_salechallans" CssClass="table" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                     DataKeyNames="ChallanID"  OnSelectedIndexChanged="Gv_audit_salechallans_SelectedIndexChanged"  AutoGenerateSelectButton="True" BackColor="White" 
                          
                         BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >  
                      <Columns>   
                         <%-- <asp:BoundField HeaderText="Adjustment ID"  DataField="ChallanID"/>--%> 
                          <asp:BoundField HeaderText="Adjustment No"  DataField="ChallanNo"/>  
                          <%-- <asp:BoundField  HeaderText="File Name" /> 
                          <asp:BoundField  HeaderText="Adjustment Date" /> --%> 
                            <asp:ImageField  ControlStyle-Height="75" ControlStyle-Width="75" HeaderText="Images" />  
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
                        </asp:Panel>

                    </div>
                </div>

                    <%--pending audit sale challans--%>

                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <div class="col-sm-4">
                                <asp:Literal ID="cashMemo" runat="server"></asp:Literal>
                            </div>

                            <div class="col-sm-4">
                                <asp:Button ID="btnPrint" CssClass="btn btn-info" runat="server" Style="margin-left: 15px" AutoPostBack="True" Text="Challan" OnClick="btnPrint_Click" Visible="false"></asp:Button>

                            </div>
                            <div class="col-sm-4">
                                <asp:Literal ID="ltCustomCashMemo" runat="server"></asp:Literal>
                            </div>

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
                            <asp:HiddenField ID="HiddenIsTruncated" runat="server" />
                        </div>
                    </div>
                    <div class="row" style="margin-top: 1%">
                        <div class="col-sm-2 col-xs-2 col-lg-2">
                            <asp:Literal ID="ltCurrentId" runat="server"></asp:Literal>
                        </div>
                        <div class="col-sm-2 col-xs-2 col-lg-2">
                            <%--<asp:Literal ID="cashMemo" runat="server"></asp:Literal>--%>
                    </td>
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
          
        </asp:UpdatePanel>

    </div>
</asp:Content>
