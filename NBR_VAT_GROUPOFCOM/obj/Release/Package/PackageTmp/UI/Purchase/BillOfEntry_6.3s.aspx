
<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="BillOfEntry_6.3s.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Purchase.BillOfEntry_6__3s" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" Runat="Server">
 
    <style type="text/css">
        .hiddencol {
            display: none;
        }
       .wrapper1, .wrapper2 { width: 100%; overflow-x: scroll; overflow-y: hidden; }
        .wrapper1 { height: 20px; }
        .div1 { height: 20px; }
        .div2 { overflow:none; }
    </style>

      <script>
            $(function () {
                $('.wrapper1').on('scroll', function (e) {
                    $('.wrapper2').scrollLeft($('.wrapper1').scrollLeft());
                });
                $('.wrapper2').on('scroll', function (e) {
                    $('.wrapper1').scrollLeft($('.wrapper2').scrollLeft());
                });
            });
            $(window).on('load', function (e) {
                $('.div1').width($('table').width());
                $('.div2').width($('table').width());
            });
        </script>
    <script type = "text/javascript">
      
        function confirmPayment() {
            var total = $("[id*=txtTotalImportPrice]").val();
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

            //if (extra > 0) {
            //    alert("WARNING !! You have given " + extra + " taka extra !");
            //} else {
            //    if (extra < 0) {
            //        alert("WARNING !! You have to pay " + (extra * (-1)) + " taka more !");
            //    } else {
            //        alert("Payment Complete");
            //    }
            //}

            if ($("[id*=chkCheque]").prop("checked") && $("[id*=txt_transaction_id]").val() == "") {

                alert("Please fill up Payment Info");
                $("[id*=div_N]").show();
                
                return;
            }
            else {
                $("[id*=div_N]").hide();
            }
            if (extra > 0) {
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
            var total = $("[id*=txtTotalImportPrice]").val();
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
            }
            else {
                $("[id*=txtCashAmount]").hide();
                $("[id*=txtCashAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkPayOrder]").prop("checked")) {
                if (!$("[id*=txtPayOrderAmount]").val()) { $("[id*=txtPayOrderAmount]").val(remains); }
                $("[id*=txtPayOrderAmount]").show();
            }
            else {
                $("[id*=txtPayOrderAmount]").hide();
                $("[id*=txtPayOrderAmount]").val("");
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

            if ($("[id*=chkRocket]").prop("checked")) {
                if (!$("[id*=txtRocketAmount]").val()) { $("[id*=txtRocketAmount]").val(remains); }
                $("[id*=txtRocketAmount]").show();
            }
            else {
                $("[id*=txtRocketAmount]").hide();
                $("[id*=txtRocketAmount]").val("");
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

            if ($("[id*=chkTR]").prop("checked")) {
                if (!$("[id*=txtTR]").val()) { $("[id*=txtTR]").val(remains); }
                $("[id*=txtTR]").show();
            }
            else {
                $("[id*=txtTR]").hide();
                $("[id*=txtTR]").val("");
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

            if ($("[id*=chkDeferred]").prop("checked")) {
                if (!$("[id*=txtDeferredAmount]").val()) { $("[id*=txtDeferredAmount]").val(remains); }
                $("[id*=txtDeferredAmount]").show();
            }
            else {
                $("[id*=txtDeferredAmount]").hide();
                $("[id*=txtDeferredAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkAtSight]").prop("checked")) {
                if (!$("[id*=txtAtSightAmount]").val()) { $("[id*=txtAtSightAmount]").val(remains); }
                $("[id*=txtAtSightAmount]").show();

            }
            else {
                $("[id*=txtAtSightAmount]").hide();
                $("[id*=txtAtSightAmount]").val("");
            }
        }

        $(function () {
            var selectedValues = 0;
            $("[id*=chkLstQuestion2] input").click(function () {
                selectedValues = $(this).val();
                if (selectedValues == 5) {
                    if ($(this).is(":checked"))
                        $("[id*=txtQuestion2]").show();
                    else
                        $("[id*=txtCashAmount]").hide()
                }
            });
        });
        function PrintPanel() {
            var panel = document.getElementById("<%=boePrint.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body style="margin: 50px;font-family: "Times New Roman", Times, serif; font-size:16px">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <script type = "text/javascript">
        function Confirm() {
            var status = document.getElementById('<%=chkRebatable.ClientID %>');
            var confirm_value = "";
            
            if (status.checked) {

            } else {
               
                //if (document.forms[0].appendChild(confirm_value) != "") {
                //    document.forms[0].removeChild(confirm_value);
                //}
              
                confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to Check Rebatable Checkbox?")) {
                    confirm_value.value = "Yes";
                    document.getElementById("<%=chkrbt.ClientID%>").value = "Yes";
                } else {
                    confirm_value.value = "No";
                    document.getElementById("<%=chkrbt.ClientID%>").value = "No";
                }
                //document.getElementById("<%=chkrbt.ClientID%>").value = confirm_value.value;
               // alert(confirm_value.value);
               //document.forms[0].removeChild(confirm_value);
               //document.forms[0].appendChild(confirm_value);
              
             
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
        <div class="panel-group">
         <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center;font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">
               Bill of Entry / আমদানি চালানপত্র</div>
                <div class="panel-body" style="padding-top:8px; padding-bottom:0px ">
                    <div class="row hiddencol"  style="background-color: #FFD9C3;">
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
                                            <asp:Label ID="lblOrgTIN" runat="server"></asp:Label>
                                             <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    <div class="row hiddencol">
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
                                <asp:Label ID="Label3" class="col-sm-5 control-label text-right" runat="server"><span class="required">*</span>Bill of Entry No:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtChallanNo" CssClass="form-control" runat="server" Enabled="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>               
                   <div class="col-md-4">
                     <div class="form-group form-group-sm"> 
                        <asp:Label ID="Label8" class="col-sm-5 control-label text-right" runat="server">Bill of Entry Date:</asp:Label>
                         <div class="col-sm-7"> 
                          <asp:TextBox ID="dtpBillOfEntryDate" runat="server" Style="width: 50%; float: left" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpBillOfEntryDate"/>
                             <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server" ></asp:DropDownList>
                             <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                         </div> 
                      </div>
                   </div>
             
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                         <asp:Label ID="Label46" class="col-sm-5 control-label text-right" runat="server"  Text="Port Code:"></asp:Label>
                            <div class="col-sm-7">
                             <asp:DropDownList ID="drpPortCode" CssClass="form-control select2" runat="server" AutoPostBack="True" ></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>     
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label4" class="col-sm-5 control-label text-right" runat="server" Text="Port From:"></asp:Label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtPortFrom" CssClass="form-control" runat="server"  Enabled="true"></asp:TextBox>
                            </div>
                        </div> 
                   </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label7" class="col-sm-5 control-label text-right" runat="server" Text="LC No:"></asp:Label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtLCNo" CssClass="form-control" runat="server"  Enabled="true"></asp:TextBox>
                            </div>
                        </div>     
                   </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label9" class="col-sm-5 control-label text-right" runat="server" Text="LC Date:"></asp:Label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="dtpLCDate" CssClass="form-control" runat="server" style="width:235px;"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpLCDate"/>
                            </div>
                        </div>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-md-4">
                         <div class="form-group form-group-sm">
                             <asp:Label ID="Label10" class="col-sm-5 control-label text-right"  runat="server"><span class="required">*</span>LC Amount(Tk):</asp:Label>
                             <div class="col-sm-7">          
                             <asp:TextBox ID="txtLCAmount" CssClass="form-control" runat="server"  Enabled="true" OnTextChanged="txtLCAmount_Click" AutoPostBack="true"></asp:TextBox>
                             <ajaxToolkit:FilteredTextBoxExtender ID="txtLCAmount_FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtLCAmount"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                             </div>
                         </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm"> 
                          <asp:Label ID="lblLC" class="col-sm-5 control-label text-right"  runat="server" Text=""><span class="required">*</span>LC Value & Curr.:</asp:Label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtForeignAmount" Style="width: 50%; float: left" CssClass="form-control" runat="server" ></asp:TextBox>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="txtForeignAmount_FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtForeignAmount"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:DropDownList ID="drpCurrencyUnit" Style="width: 50%; float: left" CssClass="form-control" runat="server" ></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">
                            <asp:Label ID="Label1" class="col-sm-5 control-label text-right" runat="server"  Text="" ><span class="required">*</span>Exc. Rate:</asp:Label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtExchangeRate" CssClass="form-control" runat="server"  Enabled="true" OnTextChanged="txtExchangeRate_Click" AutoPostBack="true"></asp:TextBox>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="txtExchangeRate_FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtExchangeRate"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                 </div>
                        </div>
                    </div>
                </div>
                     <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label12" class="col-sm-5 control-label text-right" runat="server" title="LC Bank:" ><span class="required">*</span>Bank:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpBank" CssClass="form-control select2" runat="server" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged ="drpBank_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                           </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label13" class="col-sm-5 control-label text-right" runat="server" title="LC Branch:"><span class="required">*</span>Branch:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpBankBranch" CssClass="form-control select2" runat="server" Enabled="true"></asp:DropDownList>
                                </div>
                           </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label15" class="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Insurance Number:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtInsuranceNo" CssClass="form-control" runat="server" Enabled="true"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
               <div class="row">
                   <div class="col-md-4">
                       <div class="form-group form-group-sm">
                        <asp:Label ID="Label2" class="col-sm-5 control-label text-right"  runat="server" Text="No. of item :"></asp:Label>
                           <div class="col-sm-7">
                           <asp:TextBox ID="txtNoofItem" CssClass="form-control" runat="server" Enabled="true"></asp:TextBox><%--style="width:170px"--%>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9"
                                                        runat="server" Enabled="True" TargetControlID="txtNoofItem"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                           </div>
                       </div>
                   </div>
                   <div class="col-md-4">
                       <div class="form-group form-group-sm">
                         <asp:Label ID="Label5" class="col-sm-5 control-label text-right" runat="server" Text="Total Pack :"></asp:Label>
                           <div class="col-sm-7">
                               <asp:TextBox ID="txtTotalPack" class="form-control" runat="server"  Enabled="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10"
                                                        runat="server" Enabled="True" TargetControlID="txtTotalPack"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                           </div>
                       </div>
                   </div>
                    <div class="col-md-4">
                       <div class="form-group form-group-sm">
                        <asp:Label ID="Label51" class="col-sm-5 control-label text-right" runat="server"><span class="required">*</span> Tax Pay Date:</asp:Label>
                           <div class="col-sm-7">
                           <asp:TextBox ID="txtTaxPayDate" CssClass="form-control" runat="server" style="width:235px;" ></asp:TextBox>
                               <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTaxPayDate"/>
                           </div>
                       </div>
                    </div>
               </div>
                   
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm"> 
                                <asp:Label ID="Label16" class="col-sm-5 control-label text-right" runat="server"> <span class="required">*</span>Insurance Amount(Tk):</asp:Label>
                                <div class="col-sm-7"> 
                                    <asp:TextBox ID="txtInsuranceAmount" CssClass="form-control" runat="server" style="border:1px solid #C29925" Enabled="true"></asp:TextBox>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="txtInsuranceAmount_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtInsuranceAmount"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>                        
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label14" runat="server" class="col-sm-5 control-label text-right" Text=<abbr title="Shipment Date and Time">Shipment D&T:</abbr></asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtShipmentDate" CssClass="form-control" runat="server" Style="width: 50%; float: left" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtShipmentDate"/>
                                    <asp:DropDownList ID="drpShipDtHr" CssClass="form-control" runat="server" Style="width: 25%; float: left"></asp:DropDownList>
                                    <asp:DropDownList ID="drpShipDtMin" CssClass="form-control" runat="server" Style="width: 25%; float: left" Enabled="true"></asp:DropDownList>                                
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label30" class="col-sm-5 control-label text-right" runat="server">Delivery D&T:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtDeliveryDate" CssClass="form-control" runat="server" style="width:50%; float: left" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDeliveryDate"/>
                                    <asp:DropDownList ID="drpDlDtHr" CssClass="form-control" runat="server" style="width:25%; float: left" Enabled="true"></asp:DropDownList>
                                    <asp:DropDownList ID="drpDlDtMin" CssClass="form-control" runat="server" style="width:25%; float: left"></asp:DropDownList>
                                </div>
                            </div>
                        </div>                           
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label21" class="col-sm-5 control-label text-right" runat="server"><span class="required">*</span>Release Order No:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtReleaseOrderNo" CssClass="form-control" runat="server" ></asp:TextBox>
                                </div>
                           </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label6" runat="server" class="col-sm-5 control-label text-right" Text=<abbr title="Release Order Date">Rlsg Order Date:</abbr></asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtReleaseOrderDate" CssClass="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtReleaseOrderDate"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label18" runat="server" class="col-sm-5 control-label text-right" Text=""><span class="required">*</span>Supplier Name:</asp:Label>
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="drpParty" runat="server" AutoPostBack="True" 
                                     OnSelectedIndexChanged="drpParty_SelectedIndexChanged" CssClass="form-control select2">
                                    </asp:DropDownList>
                                    
                                    <asp:TextBox ID="txtPartyName" runat="server" Visible="False"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnAddParty" runat="server" CssClass="button_sub" onclick="btnAddParty_Click" Text="New"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label20" class="col-sm-5 control-label text-right" runat="server" Text="">Supplier Address:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" Rows="1" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label19" class="col-sm-5 control-label text-right" runat="server" Text="Country of Origin :"></asp:Label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpCountry" runat="server" class="form-control select2" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                       </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <asp:Label ID="Label22" class="col-sm-5 control-label text-right" runat="server" Text="Ultimate Destination:"></asp:Label>
                                 <div class="col-sm-7">
                                     <asp:TextBox ID="txtDestination"  CssClass="form-control" runat="server" Rows="1"  TextMode="MultiLine"></asp:TextBox>
                                 </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                      <div class="form-group form-group-sm">
                          <asp:Label ID="Label47" class="col-sm-5 control-label text-right" runat="server" Text="Remarks:"></asp:Label>
                          <div class="col-sm-7">
                              <asp:TextBox ID="txtMasterRemark" Rows="1" runat="server"  CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                          </div>
                      </div>
               </div>
                            <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Receive Challan Date :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox ID="txtChallanDate" CssClass="form-control" Style="width: 50%; float: left" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                           <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate"/>
                                            <asp:DropDownList ID="drpRefChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server" ></asp:DropDownList>
                                            <asp:DropDownList ID="drpRefChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server" ></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                     
                     <div class="col-md-4">
                      <div class="form-group form-group-sm">
                          <asp:Label ID="Label45" class="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>CPC:</asp:Label>
                          <div class="col-sm-7">
                              <asp:DropDownList ID="drpCPC"  runat="server"  CssClass="form-control select2"  ></asp:DropDownList>
                          </div>
                      </div>
               </div>
             </div>
                     <br />   
              <%--        <div class="row" style="margin-top:1%">
                
                <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                    <asp:Label ID="Label1" style="margin-left:12px" runat="server" Text="Mobile No. :"></asp:Label>
                    <asp:TextBox ID="txtMobileNo" class="boe-input" runat="server" Rows="1" AutoPostBack="true" OnTextChanged="txtMobileNo_TextChanged" Style="margin-right:24px"></asp:TextBox>
                </div>
                <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                    <asp:Label ID="Label2" style="margin-left:19px" runat="server" Text="National Id :"></asp:Label>
                    <asp:TextBox ID="txtNationalId" class="boe-input" runat="server" Rows="1" Width="169px" ReadOnly="true" ></asp:TextBox>
                </div>
                <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                   <asp:Label ID="Label8" style="margin-left:12px" runat="server" Text="Registration Type :"></asp:Label>
                      <asp:DropDownList ID="drpRegType" runat="server" class="boe-input" AutoPostBack="True" style="width:169px; height:25px; margin-right:5%" Enabled="false">
                   <asp:ListItem Value="0">Select</asp:ListItem>

                                                <asp:ListItem Value="1">Regular Registered(Vat)</asp:ListItem>
                                                <asp:ListItem Value="4">Registered ForTurnover</asp:ListItem>
                                                <asp:ListItem Value="5">Not Registered</asp:ListItem>
                      </asp:DropDownList>
                </div>
                <div class="col-sm-3" style="padding:0px; margin-top:-11px">
                   
                </div>
             </div>--%>
           </div>
         </div>

         <div class="panel panel-primary">
         <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
             <div class="container-fluid">
                 <div class="row" >
                      <div class="col-md-4"></div>
                      <div class="col-md-4">
                      <asp:RadioButton runat="server" ID="chkManualInput" Text="Manual Input" Visible="false" GroupName="manual" OnCheckedChanged="chkManualInput_OnCheckedChanged" AutoPostBack="true" Checked="true" />
                      <asp:RadioButton runat="server" ID="chkExcelImport" Text="Import from Excel" Visible="false" GroupName="manual" OnCheckedChanged="chkExcelImport_OnCheckedChanged" AutoPostBack="true"/>
                      </div>
                     <div class="col-md-4"></div>
                 </div>

                <div class="row" runat="server" id="part_a">
                    <div class="test-label">
                    <asp:Label ID="Label49" Font-Bold="true" runat="server" Text="Property:"></asp:Label><br />
                        <asp:DropDownList ID="drpServGoods" runat="server" class="dd" Height="27px" OnSelectedIndexChanged="drpServGoods_SelectedIndexChanged" 
                        AutoPostBack="True" TabIndex="1">
                        <asp:ListItem>Goods</asp:ListItem>
                        <asp:ListItem>Service</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="Label23" Font-Bold="true" runat="server" Text="Category:"></asp:Label><br />
                        <asp:DropDownList ID="drpCategory" runat="server" style="background-color:#D7FBB1; width:80px;height:27px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" 
                        AutoPostBack="True" TabIndex="2"></asp:DropDownList>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="Label24" Font-Bold="true" runat="server" Text="Sub Cat:"></asp:Label><br />
                        <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                        class="dd" Height="27px" TabIndex="3"></asp:DropDownList>
                    </div>
                    <div class="test-label" style="display:none;">
                       <asp:Label ID="Label40" Font-Bold="true" runat="server" Text="Search Product:" /><br />
                       <asp:TextBox ID="productName" CssClass="search-product" AutoPostBack="true" style="width:155px" placeholder="Search Product" runat="server" OnTextChanged="productName_TextChanged" TabIndex="4"/>
                       <div id="listPlacement" style="height:100px; overflow:scroll;" ></div>
                        <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName" ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement"
                             MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetProductByProductName" >
                        </ajaxToolkit:AutoCompleteExtender>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="Label25" Font-Bold="true" runat="server" Text="Item Name & SKU:" style="margin-left:0px;"/>
                        <asp:Label ID="lblSku" runat="server"></asp:Label><br />
                        <asp:DropDownList ID="drpItem" CssClass="select2" style="width:160px;background-color:#D7FBB1;height:27px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" TabIndex="5"/>
                        <asp:Label runat="server" ID="lblProductType" Visible="false"></asp:Label>
                         <asp:HiddenField ID="hdItemType" runat="server" />
                                <asp:HiddenField ID="hdBookId" runat="server" />
                                <asp:HiddenField ID="hdPageNo" runat="server" />
                          <asp:Label runat="server" ID="itemId" Visible="false" />
                    </div>

                    <div class="test-label">
                        <asp:Label ID="Label26" Font-Bold="true" runat="server" Text="HS Code:"/><br />
                         <asp:TextBox ID="lblHSCode" runat="server" style="width:85px" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                         <asp:Label ID="Label27" Font-Bold="true" runat="server" Text="Quantity:" style="margin-left: 11px;"/><br />
                         <asp:TextBox ID="txtQuantity" runat="server" style="width:70px;background-color:#D7FBB1" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged" TabIndex="6"></asp:TextBox><br />
                           <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                        <%-- <asp:Label ID="lblAvailStock" runat="server" Text="Avl Stock :"></asp:Label>--%>
                         <asp:Label runat="server" ID="aa" Text="avl qnt: " Visible="false"/><asp:Label runat="server" ID="lblAvailableQuantity" Visible="false" />
                    </div>
                    <div class="test-label">
                         <asp:Label ID="Label41" Font-Bold="true" runat="server" Text="Unit:" style="margin-left: 0px;"/><br />
                         <asp:TextBox ID="lblUnit" runat="server" style="width:45px"></asp:TextBox>
                         <asp:Label runat="server" ID="lblUnitId" Visible="false" />
                    </div>
                    <div class="test-label">
                        <asp:Label ID="Label28" Font-Bold="true" runat="server" Text="Unit Price:" style="margin-left:0px;"/><br />
                        <asp:TextBox ID="txtUnitPrice" style="width:75px;background-color:#D7FBB1" runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged" TabIndex="7"/>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                        runat="server" Enabled="True" TargetControlID="txtUnitPrice"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                         <asp:Label ID="lblUnitPrice" runat="server" Text="" style="margin-left:0px;" Visible=false/>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVCD" runat="server"  style="margin-left:0px;" Visible="false" Text=<abbr title="CD%*Assesed Value">CD:</abbr> </asp:Label><br />
                        <asp:TextBox ID="txtCD" style="width:80px" runat="server" AutoPostBack="True" TabIndex="8" Visible="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVRD" runat="server"  style="margin-left:0px;" Visible="false" Text=<abbr title="RD%*Assesed Value">RD:</abbr> </asp:Label><br />
                        <asp:TextBox ID="txtRD" style="width:80px" runat="server" AutoPostBack="True" TabIndex="9" Visible="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVSD" runat="server"  style="margin-left:0px;" Visible="false" Text=<abbr title="(CD+RD+Assesed Value)*SD%">SD:</abbr> </asp:Label><br />
                        <asp:TextBox ID="txtSD" style="width:80px" runat="server" AutoPostBack="True" TabIndex="10" Visible="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVVAT" runat="server"  style="margin-left:0px;" Visible="false" Text=<abbr title="(CD+RD+Assesed Value+SD)*VAT%">VAT:</abbr> </asp:Label><br />
                        <asp:TextBox ID="txtVAT" style="width:80px" runat="server" AutoPostBack="True" TabIndex="11" Visible="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVaAT" runat="server"  style="margin-left:0px;" Visible="false" Text=<abbr title="(CD+RD+Assesed Value+SD)*AT%">AT:</abbr> </asp:Label><br />
                        <asp:TextBox ID="txtAT" style="width:80px" runat="server" AutoPostBack="True" TabIndex="12" Visible="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVAIT" runat="server"  style="margin-left:0px;"  Visible="false" Text=<abbr title="Assesed Value*AIT%">AIT:</abbr> </asp:Label><br />
                        <asp:TextBox ID="txtAIT" style="width:80px" runat="server" AutoPostBack="True" TabIndex="13"  Visible="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVATV" runat="server" Text="ATV:" style="margin-left:0px;" Visible="false"/><br />
                        <asp:TextBox ID="txtATV" style="width:80px" runat="server" AutoPostBack="True" TabIndex="14" Visible="false"></asp:TextBox>
                    </div>
                    <div class="test-label">
                        <asp:Label ID="lblVTTI" runat="server" Text="TTI:" style="margin-left:0px;" Visible="false"/><br />
                        <asp:TextBox ID="txtTTI" style="width:80px" runat="server" AutoPostBack="True" TabIndex="15" Visible="false"></asp:TextBox>
                    </div>
                     <div class="test-label">
                    <asp:Label ID="Label32" Font-Bold="true" runat="server" Text=<abbr title="Imported Value">Impt Value:</abbr></asp:Label><br />
                        <asp:TextBox ID="txtImportValue" AutoPostBack="true" runat="server" style="font-size:12px;width:82px;height:26px" Font-Bold="false" Text="0.00" OnTextChanged="txtImportValue_TextChanged" TabIndex="15"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11"
                                                        runat="server" Enabled="True" TargetControlID="txtImportValue"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                     </div>
                    <div class="test-label">
                    <asp:Label ID="Label44" Font-Bold="true" runat="server" Text=<abbr title="Assessable Value">Assesed Value:</abbr></asp:Label><br />
                        <asp:TextBox ID="txtUnitPriceTotal" AutoPostBack="true" runat="server" style="font-size:12px;width:82px;height:26px" Font-Bold="false" Text="0.00" OnTextChanged="txtTotalPrice_TextChanged" TabIndex="15"></asp:TextBox>
                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                        runat="server" Enabled="True" TargetControlID="txtUnitPriceTotal"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                   
            </div>
           <div class="row">
               
                     <div class="test-remark">
            <asp:Label ID="Label35"  runat="server" Text="Remarks :" CssClass="present-address-lbl"></asp:Label>
            <asp:TextBox ID="singleRemarks" style="width:100px;height:27px;float: right;" runat="server" CssClass="present-address-tb" TextMode="MultiLine"></asp:TextBox>
           </div> 
                <div class="test-label">
                   <asp:Label ID="lblvdstx" Style="float: left;margin-top:3px" runat="server" Text="VDS Amount:" Visible="false"/>
                    <asp:TextBox ID="txtvdsamount" runat="server" CssClass="present-address-tb" Style="width: 90px;  margin-left: 3px; float: left; text-align: left;height:27px" Visible="false"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12"
                                                         runat="server" Enabled="True" TargetControlID="txtvdsamount"
                                                         ValidChars=".0123456789">
                    </ajaxToolkit:FilteredTextBoxExtender>
                 </div>
                 <div class="test-label">
            <asp:Label ID="Label36" CssClass="present-address-lbl" style="margin-left:10px;" runat="server" Text=<abbr title="Document Processing Fee">DPF:</abbr></asp:Label>
            <asp:TextBox ID="txtDPFee" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtDPFee_textChanged" AutoPostBack="true"></asp:TextBox>
                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                        runat="server" Enabled="True" TargetControlID="txtDPFee"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
           </div>
           <div class="test-label">
            <asp:Label ID="Label37" CssClass="present-address-lbl" style="margin-left:15px;" runat="server" Text=<abbr title="Fines/Penalties/Other Cost">F/P:</abbr></asp:Label>
            <asp:TextBox ID="txtOCost" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtOCost_textChanged" AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                        runat="server" Enabled="True" TargetControlID="txtOCost"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
           <div class="test-label">
            <asp:Label ID="Label52" CssClass="present-address-lbl" style="margin-left:10px;" runat="server" Text=<abbr title="Pre Shipment Inspection Fees">PSI:</abbr></asp:Label>
            <asp:TextBox ID="txtPSI" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtPSI_textChanged" AutoPostBack="true"></asp:TextBox>
                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                                        runat="server" Enabled="True" TargetControlID="txtPSI"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
           </div>
           <div class="test-label">
            <asp:Label ID="Label42" CssClass="present-address-lbl" style="margin-left:10px;" runat="server" Text=<abbr title="C&F Commission">C&F Commission:</abbr></asp:Label>
            <asp:TextBox ID="txtCommission" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtCnFVat_textChanged" AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13"
                                                        runat="server" Enabled="True" TargetControlID="txtCnFVat"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
           <div class="test-label">
            <asp:Label ID="Label38" CssClass="present-address-lbl" style="margin-left:10px;" runat="server" Text=<abbr title="Vat on C&F Commission">C&F VAT:</abbr></asp:Label>
            <asp:TextBox ID="txtCnFVat" runat="server" CssClass="present-address-tb" style="width:60px;height:25px;float:right" OnTextChanged="txtCnFVat_textChanged" AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                                        runat="server" Enabled="True" TargetControlID="txtCnFVat"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
           <div class="test-label">
            <asp:Label ID="Label50" CssClass="present-address-lbl"  style="margin-left:10px;" runat="server" Text=<abbr title="Income Tax on C&F Commission">C&F Income Tax:</abbr></asp:Label>
            <asp:TextBox ID="txtCnfCommission" CssClass="present-address-tb" runat="server" style="width:60px;height:25px;float:right" OnTextChanged="txtCnfCommissiont_textChanged" AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8"
                                                        runat="server" Enabled="True" TargetControlID="txtCnfCommission"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
           <div class="test-label">
            <asp:Label ID="Label43" CssClass="present-address-lbl"  style="margin-left:10px;" runat="server" Text=<abbr title="Container Scanning Fee">CSF:</abbr></asp:Label>
            <asp:TextBox ID="txtCSF" CssClass="present-address-tb" runat="server" style="width:60px;height:25px;float:right" OnTextChanged="txtCnfCommissiont_textChanged" AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14"
                                                        runat="server" Enabled="True" TargetControlID="txtCnfCommission"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
           </div>
            <div class="row" runat="server" id="part_b">
              
                <div class="test-check">
                    <asp:Label ID="cd" runat="server" Text=<abbr title="Customs Duty">CD:</abbr></asp:Label>
                    <asp:CheckBox ID="chkCD" runat="server" OnCheckedChanged="chkCD_CheckedChanged" AutoPostBack="True"/>
                    <asp:Label ID="lblCD" runat="server" Text="0.00"></asp:Label>
                     <asp:Label ID="lblFxdCD" runat="server"  Visible="false"></asp:Label><br />
                    <asp:Label ID="Label86" runat="server" Text="%"></asp:Label><br />
                </div>
                <div class="test-check">
                    <asp:Label ID="rd" runat="server" Text=<abbr title="Regularity Duty">RD:</abbr></asp:Label>
                    <asp:CheckBox ID="chkRD" runat="server" AutoPostBack="True" Enabled="true" OnCheckedChanged="chkRD_CheckedChanged" />
                    <asp:Label ID="lblRD" runat="server" Text="0.00"></asp:Label>
                    <asp:Label ID="Label89" runat="server" Text="%"></asp:Label><br />
                    <%--<asp:Label ID="Label79" runat="server" Text="Total :"></asp:Label>
                    <asp:Label ID="lblActRD" runat="server"></asp:Label>--%>
                </div>
                <div class="test-check">
                    <asp:Label ID="sd" runat="server" Text=<abbr title="Supplementary Duty">SD:</abbr></asp:Label>
                    <asp:CheckBox ID="chkSD" runat="server" Enabled="true" OnCheckedChanged="chkSD_CheckedChanged" />
                    <asp:Label ID="lblSD" runat="server" Text="0.00"></asp:Label>
                    <asp:Label ID="Label84" runat="server" Text="%"></asp:Label><br />
                    <%--<asp:Label ID="Label74" runat="server" Text="Total :"></asp:Label>
                    <asp:Label ID="lblActSD" runat="server"></asp:Label>--%>
                </div>
                <div class="test-check">
                    <asp:Label ID="vat" runat="server" Text=<abbr title="Value Added Tax">VAT:</abbr></asp:Label>
                    <asp:CheckBox ID="chkVAT" runat="server" AutoPostBack="true" OnCheckedChanged="chkVAT_CheckedChanged" />
                    <asp:Label ID="lblVAT" runat="server" Text="0.00"></asp:Label>
                    <asp:Label ID="Label87" runat="server" Text="%"></asp:Label><br />
                    <%--<asp:Label ID="Label77" runat="server" Text="Total :"></asp:Label>
                    <asp:Label ID="lblActVAT" runat="server"></asp:Label>--%>
                </div>

                <div class="test-check">
                    <asp:Label ID="AT" runat="server" Text=<abbr title="Advance Tax">AT:</abbr></asp:Label>
                    <asp:CheckBox ID="chkAT" OnCheckedChanged="chkAT_CheckedChanged" runat="server" AutoPostBack="true" Visible="true"/>
                    <asp:Label ID="lblAT" runat="server" Text="0.00"></asp:Label>
                    <asp:Label ID="lblATAAAAAA" runat="server" Text="%"></asp:Label><br />
                    
                    
                </div>

                <div class="test-check">
                    <asp:Label ID="ait" runat="server" Text=<abbr title="Advance Income Tax">AIT:</abbr></asp:Label>
                    <asp:CheckBox ID="chkAIT" runat="server" AutoPostBack="true" Visible="true" OnCheckedChanged="chkAIT_CheckedChanged" />
                    <asp:Label ID="lblAIT" runat="server" Text="0.00"></asp:Label>
                    <asp:Label ID="Label90" runat="server" Text="%"></asp:Label><br />
                    <%--<asp:Label ID="Label80" runat="server" Text="Total :"></asp:Label>
                    <asp:Label ID="lblActAIT" runat="server"></asp:Label>--%>
                </div>
                <div class="test-check" style="display:none;">
                    <asp:Label ID="atv" runat="server" Text=<abbr title="Advance Tread VAT">ATV:</abbr></asp:Label>
                    <asp:CheckBox ID="chkATV" runat="server" OnCheckedChanged="chkATV_CheckedChanged" />
                    <asp:Label ID="lblATV" runat="server" Text="0.00"></asp:Label>
                    <asp:Label ID="Label85" runat="server" Text="%"></asp:Label><br />
                    <%--<asp:Label ID="Label75" runat="server" Text="Total :"></asp:Label>
                    <asp:Label ID="lblActATV" runat="server"></asp:Label>--%>
                </div>
                <div class="test-check" style="display:none;">
                    <asp:Label ID="tti" runat="server" Text=" TTI:"></asp:Label>
                    <asp:CheckBox ID="chkTTI" runat="server" OnCheckedChanged="chkTTI_CheckedChanged" />
                    <asp:Label ID="lblTTI" runat="server" Text="0.00"></asp:Label>
                    <asp:Label ID="Label88" runat="server" Text="%"></asp:Label><br />
                    <%--<asp:Label ID="Label78" runat="server" Text="Total :"></asp:Label>
                    <asp:Label ID="lblActTTI" runat="server"></asp:Label>--%>
                </div>
                <div class="test-check">
                    <asp:Label ID="lblShipment" runat="server" Visible=false></asp:Label>
                    <asp:Label ID="lblDelivery" runat="server" Visible=false></asp:Label>
                    
                    <asp:Label ID="lblRebatable" runat="server" Text="Rebatable:"></asp:Label>
                    <asp:CheckBox ID="chkRebatable" runat="server"/>
                    <asp:TextBox ID="chkrbt" runat="server"  CssClass="hiddencol"></asp:TextBox>
                    <asp:Label ID="Label53" runat="server" Text="Is Warranty:"></asp:Label>
                    <asp:CheckBox ID="chkIsWar" runat="server" />

                    <asp:Label ID="lblExempted" runat="server" Text="Exempted:" Visible="false"></asp:Label>
                    <asp:CheckBox ID="chkExempted" runat="server" Visible="false"/>
                </div>
                <div class="test-check" runat="server" visible="true">
                    <asp:Label ID="lblvds" runat="server" Text="VDS:" Visible = "false"></asp:Label>
                    <asp:CheckBox ID="chkTaxDeducted" runat="server" OnCheckedChanged="chkTaxDeducted_CheckedChanged" Visible = "false"/>
                </div>
               
                <div class="test-check">
                     <asp:CheckBox ID="chkIsFixed" runat="server" Text="Fixed VAT" AutoPostBack="true" Enabled="false" />
                   </div>
                <div class="test-check">
                     <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" AutoPostBack="true" Enabled="False" />
                   </div>
                <div class="test-check">
                 <asp:CheckBox ID="chkExcel" runat="server" AutoPostBack="true" ForeColor="green"  OnCheckedChanged="ChckedChanged" Text="Add Additional Information?"/>
                 <asp:CheckBox ID="chkRebateCurrent" runat="server" AutoPostBack="true" ForeColor="green" Text="Current Month Rebate Adjust?"/>
                </div>
                          
           </div>
            <div class="row">
  <div class="test-check">
                    <asp:Label ID="Label93" runat="server"  Font-Size="Medium" Text="Total :"></asp:Label>
                    <asp:Label ID="lblTotal" runat="server" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="test-check">
                    <asp:Label ID="Label17" runat="server" Font-Size="Medium" Text=<abbr title="CD+RD+SD+VAT+AT+AIT">Total Tax:</abbr></asp:Label>
                    <asp:Label ID="txtTotalTax" runat="server" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="test-check">
                    <asp:Label ID="Label31" runat="server" Font-Size="Medium" style="color:red" Text=<abbr title="Assesed Value+CD+RD+SD+VAT">Cost:</abbr> </asp:Label>
                    <asp:Label ID="lblTotalCost" runat="server" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="test-check">
                    <asp:Label ID="Label39" runat="server" Font-Size="Medium" style="color:red" Text=<abbr title="Assesed Value+CD+RD+SD">Purchase Price :</abbr></asp:Label>
                    <asp:Label ID="lblPurchaseUnitPrice" runat="server" Font-Size="Medium" CssClass="hiddencol"></asp:Label>
                      <asp:Label ID="lblPurchaseUnitPrice1" runat="server" Font-Size="Medium" ></asp:Label>
                </div>
                 <div class="test-check">
                    <asp:Label ID="Label34" runat="server" Font-Size="Medium" Text="Refund Amt. :"></asp:Label>
                    <asp:Label ID="lblRefund" runat="server" Font-Size="Medium"></asp:Label>
                </div>
</div>
            <div class="row" runat="server" id="propertyDIV" visible="false">
               <div class="test-label">
                  <asp:HiddenField ID="hdProp1" runat="server" />
                  <%--<asp:Label ID="lblProperty1" runat="server" Text="Size:" Visible="false"/><br />--%>
                   <asp:Label ID="lblProperty1" runat="server" Visible="false"/><br />
                 <%-- <asp:DropDownList ID="drpProperty1" runat="server"  OnSelectedIndexChanged="drpProp1_SelectedIndexChanged"
                        CssClass="category" Visible="false" style="height:27px;text-align:left">
                  </asp:DropDownList>--%>
                   <asp:DropDownList ID="drpProperty1" runat="server" CssClass="category" Visible="false" style="height:27px;text-align:left" OnSelectedIndexChanged="drpProperty1_SelectedIndexChanged">
                   </asp:DropDownList>
               </div>
                 <div class="test-label">
                 <asp:HiddenField ID="hdProp2" runat="server" />
                 <%--<asp:Label ID="lblProperty2" runat="server" Text="Color:" Visible="false"/><br />--%>
                     <asp:Label ID="lblProperty2" runat="server" Visible="false"/><br />
                <%-- <asp:DropDownList ID="drpProperty2" runat="server"  OnSelectedIndexChanged="drpProp2_SelectedIndexChanged"
                            CssClass="category"  Visible="false" style="height:27px;text-align:left">
                </asp:DropDownList>--%>
                     <asp:DropDownList ID="drpProperty2" runat="server"  CssClass="category"  Visible="false" style="height:27px;text-align:left" OnSelectedIndexChanged="drpProperty2_SelectedIndexChanged">
                     </asp:DropDownList>
              </div>
                 <div class="test-label">
                  <asp:HiddenField ID="hdProp3" runat="server" />
                  <%--<asp:Label ID="lblProperty3" runat="server" Text="Grade:" Visible="false"/><br />--%>
                     <asp:Label ID="lblProperty3" runat="server" Visible="false"/><br />
                <%-- <asp:DropDownList ID="drpProperty3" runat="server"  OnSelectedIndexChanged="drpProp3_SelectedIndexChanged"
                       CssClass="category" Visible="false" style="height:27px;text-align:left">
                 </asp:DropDownList>--%>
                      <asp:DropDownList ID="drpProperty3" runat="server" CssClass="category" Visible="false" style="height:27px;text-align:left" OnSelectedIndexChanged="drpProperty3_SelectedIndexChanged">
                 </asp:DropDownList>
              </div>
               <div class="test-label">
                   <asp:HiddenField ID="hdProp4" runat="server" />
                   <%--<asp:Label ID="lblProperty4" runat="server" Text="Box:" Visible="false"/><br />--%>
                   <asp:Label ID="lblProperty4" runat="server" Visible="false"/><br />
                   <%--<asp:DropDownList ID="drpProperty4" runat="server"  OnSelectedIndexChanged="drpProp4_SelectedIndexChanged"
                    Visible="false" CssClass="category" style="height:27px; text-align:left"></asp:DropDownList>--%>
                   <asp:DropDownList ID="drpProperty4" runat="server" Visible="false" CssClass="category" style="height:27px; text-align:left" OnSelectedIndexChanged="drpProperty4_SelectedIndexChanged">
                   </asp:DropDownList>
               </div>
              <div class="test-label">
                 <asp:HiddenField ID="hdProp5" runat="server" />
                 <%--<asp:Label ID="lblProperty5" runat="server" Text="Specification:" Visible="false"/><br />--%>
                  <asp:Label ID="lblProperty5" runat="server" Visible="false"/><br />
                <%-- <asp:DropDownList ID="drpProperty5" runat="server"  OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"
                             CssClass="category"   Visible="false" style="height:27px;text-align:left">
                 </asp:DropDownList>--%>
                  <asp:DropDownList ID="drpProperty5" runat="server" CssClass="category"   Visible="false" style="height:27px;text-align:left"  OnSelectedIndexChanged="drpProperty5_SelectedIndexChanged">
                  </asp:DropDownList>
              </div>
            </div>
            <div class="row" runat="server" id="part_c">
             <div class="test-btn">
                <asp:Button ID="btnAdd" runat="server" class="btn-btn" style="background-color:#B681B7" OnClick="btnAddItem_Click" Text="Add Item" OnClientClick = "Confirm()" />
            </div>
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
                                         <asp:CheckBox ID="chkCash" runat="server" Text="Cash" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                         </td>
                                         <td> 
                                         <asp:TextBox ID="txtCashAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                         <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" TargetControlID="txtCashAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                         </td>
                                         <td>
                                         <asp:CheckBox ID="chkPayOrder" runat="server" Text="Pay Order" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                         </td>
                                         <td> <asp:TextBox ID="txtPayOrderAmount" runat="server" CssClass="form-control onlyFloat payment"  style="display:none;width:150px;"></asp:TextBox></td>
                                         <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtPayOrderAmount" FilterType="Numbers" FilterMode="ValidChars">
                                           </cc1:FilteredTextBoxExtender>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkCheque" runat="server" Text="Cheque" Visible="false" onclick="chkCheckedEvent(this);" style="margin-left:10px" />
                                        </td>
                                         <td> 
                                         <asp:TextBox ID="txtChequeAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True" TargetControlID="txtChequeAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                         
                                              </td>
                                        <td>
                                            <asp:CheckBox ID="chkRocket" runat="server" Text="Rocket (DBBL Mobile)" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                         <td> 
                                         <asp:TextBox ID="txtRocketAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                         <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtRocketAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                         </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkBkash" runat="server" Text="bKash" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);" /> 
                                        </td>
                                         <td> 
                                        <asp:TextBox ID="txtbKashAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                         <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="txtbKashAmount" FilterType="Numbers" FilterMode="ValidChars">
                                         </cc1:FilteredTextBoxExtender>--%>
                                              </td>
                                        <td>
                                            <asp:CheckBox ID="chkTT" runat="server" Text="Telephone Transfer" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                         <td> 
                                         <asp:TextBox ID="txtTPTAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                         <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True" TargetControlID="txtTPTAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                         </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkEFT" runat="server" Text="EFT" Visible="false" onclick="chkCheckedEvent(this);" style="margin-left:10px"/>
                                        </td>
                                         <td> 
                                         <asp:TextBox ID="txtEFTAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True" TargetControlID="txtEFTAmount" FilterType="Numbers" FilterMode="ValidChars">
                                         </cc1:FilteredTextBoxExtender>--%>
                                         </td>
                                        <td>
                                            <asp:CheckBox ID="CheDebitCard" runat="server" Text="Dr./Cr. Card" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);"/>
                                        </td>
                                         <td> 
                                         <asp:TextBox ID="txtDebitCartAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                         <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" Enabled="True" TargetControlID="txtDebitCartAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                         </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkAtSight" runat="server" Text="At Sight" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                         <td> 
                                         <asp:TextBox ID="txtAtSightAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                         <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" Enabled="True" TargetControlID="txtAtSightAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender>--%>
                                         </td>
                                        <td>
                                            <asp:CheckBox ID="chkDeferred" runat="server" Text="Deferred" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);"/> 
                                        </td>
                                         <td>
                                             <asp:TextBox ID="txtDeferredAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                         <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" Enabled="True" TargetControlID="txtDeferredAmount" FilterType="Numbers" FilterMode="ValidChars">
                                         </cc1:FilteredTextBoxExtender> --%>
                                         </td>
                                    </tr>
                                    <tr>
                                      <td>
                                       <asp:CheckBox ID="ChkOther" runat="server" Text="Other" Visible="false" style="margin-left:10px" onclick="chkCheckedEvent(this);" />
                                    </td>
                                         <td> 
                                          <asp:TextBox ID="txtOthersAmount" runat="server" CssClass="form-control onlyFloat payment" style="display:none;width:150px;"></asp:TextBox>
                                        <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" Enabled="True" TargetControlID="txtOthersAmount" FilterType="Numbers" FilterMode="ValidChars">
                                          </cc1:FilteredTextBoxExtender> --%>
                                         </td>
                                    <td>
                                    </td>
                                         <td> 
                                         
                                         </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           <asp:Label ID="lbl_transaction_id" style="display:none;" runat="server" Text="Payment Info" ForeColor="red"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_transaction_id" style="display:none;" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </td>
                                        <%--<td></td>
                                        <td></td>--%>
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
                                                         <asp:Button ID="OKButton" runat="server" CssClass="btn-btn" style="background-color: #4CAF50;" Text="OK" Width="50px" OnClientClick="confirmPayment()" OnClick="OKButton_Click" />
                                                          <asp:Button ID="btnItemSCancel" runat="server" Style="background-color: #D9534F;" CssClass="btn-btn" Text="Cancel" />
                                                    </td>
                                               
                                    </tr>
                                </table>
                                
                                 <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton" BackgroundCssClass="modalPopup" PopupControlID="ModalPanel"/>
                            </asp:Panel>
                           
                               
            </div>
                 <div class="test-btn">
                  <asp:Button ID="ClientButton" runat="server" Style="background-color:#9C987B" Text="Add Payment" class="btn-btn"/>
            </div>
            <div class="test-btn">
                 <asp:Button ID="btnSave" runat="server" style="background-color:#4CAF50" class="btn-btn" Text="Save" OnClick="btnSave_Click" />
            </div>
           <div class="test-btn">
               <asp:Button ID="btnUpdateTransaction" runat="server" style="background-color:#4CAF50" class="btn-btn" Text="Update Transaction" OnClick="btnUpdateTransaction_Click" />
            </div>
            <div class="test-btn">
                <asp:Button ID="btnClear" runat="server" style="background-color: #4CAF50" class="btn-btn" OnClick="btnClear_Click" Text="Refresh" />
            </div>
            <div class="test-btn">
                <asp:Button ID="btnReport" style="background-color:#5CB85C;" runat="server" class="btn-btn" OnClick="btnReport_Click" Text="Show Report" />
            </div>
              <div class="test-btn">                                     
              <asp:HyperLink class="btn-btn" style="background-color:#4CAF50;text-align:center" Height="25px" Width="100px" NavigateUrl="~/UI/Purchase/ImportBillofEntryfromExcel.aspx" runat="server">Import Excel</asp:HyperLink>
              </div>
        </div>
            <div class="row" runat="server" id="part_e">
                    <div class="row" style="padding-left: 25px; padding-right: 18px;" runat="server" id="divexcelProp">

                               <div class="test-label">
                                                                             
                                        <asp:Label ID="Label11" runat="server" ForeColor="Green" Font-Bold="true"  >Enter the Additional Property in Excel Header: </asp:Label>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty1" runat="server" />                                       
                                        <asp:Label ID="prop1" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label> &nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty2" runat="server" />                                       
                                        <asp:Label ID="prop2" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label>&nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty3" runat="server" />                                      
                                        <asp:Label ID="prop3" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label>&nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty4" runat="server" />                                      
                                        <asp:Label ID="prop4" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label>&nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty5" runat="server" />                                       
                                        <asp:Label ID="prop5" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ></asp:Label>
                                       
                                    </div>
                              
                                
                            </div>
                    <div class="col-sm-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" Style="background: #E0EBF5" />
                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />
                        <asp:Label ID="Label29" runat="server"></asp:Label>
                        <%--<asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn-btn"  style="background-color:#4CAF50"/>--%>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            <div class="row" style="margin-top:1%">
            <div class="col-sm-4">
                
            </div>
            <div class="col-sm-4">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                
            </div>
            <div class="col-sm-4">
                <asp:HiddenField ID="hfItemUnit" runat="server" />
                <asp:HiddenField ID="hdUnitID" runat="server" />
                <asp:HiddenField ID="HiddenIsTruncated" runat="server" />
            </div>
            </div>
             </div>
            </div>
         </div>
         <div class="panel panel-primary">
         <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
             <div class="container-fluid">
                <div class="row" style="margin-top:1%">
                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                     CssClass="sGrid" DataKeyNames="RowNo" 
                      onselectedindexchanged="gvItem_SelectedIndexChanged" Width="100%" 
                      onprerender="gvItem_PreRender" onrowdatabound="gvItem_RowDataBound" 
                      onrowdeleting="gvItem_RowDeleting" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                      <Columns>
                          <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                              SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />--%>
                           <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                          <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                          <asp:BoundField DataField="SubCategoryName" HeaderText="Sub Category" />
                          <asp:BoundField DataField="ItemName" HeaderText="Item" />

                          <asp:BoundField DataField="PropertyID1" HeaderText="Property1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                          <asp:BoundField DataField="PropertyID2" HeaderText="Property2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                          <asp:BoundField DataField="PropertyID3" HeaderText="Property3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                          <asp:BoundField DataField="PropertyID4" HeaderText="Property4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                          <asp:BoundField DataField="PropertyID5" HeaderText="Property5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                          <asp:BoundField DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                          <asp:BoundField DataField="UnitPriceBDT" HeaderText="Unit Price" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="CD" HeaderText="CD" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="RD" HeaderText="RD" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="SD" HeaderText="SD" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="VAT" HeaderText="VAT" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="AIT" HeaderText="AIT" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="AT"  HeaderText="AT" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="DocumentProcessingFee"  HeaderText="DPF" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="OthersPrice"  HeaderText="F/P" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="PSI"  HeaderText="PSI" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="CnFVat"  HeaderText="C&F VAT" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="CnFCommission"  HeaderText="C&F Commission " DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="TTI" HeaderText="TTI" Visible="false" />
                          <asp:BoundField DataField="Rebatable" HeaderText="Rebatable" />
                          <asp:BoundField HeaderText="Is Fixed VAT" DataField="Fixed" />
                          <asp:BoundField HeaderText="Is Zero Rate" DataField="ZeroRate" />
                          <asp:BoundField DataField="isWarStr" HeaderText="Warranty" />
                          <asp:BoundField DataField="UnitPriceTotal" HeaderText="Assessable Value" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="OthersPrice" HeaderText="Others" />
                          <asp:BoundField DataField="DocumentProcessingFee" HeaderText="Document Fee" />
                          <asp:BoundField HeaderText="Is Reduced" DataField="Truncated" />
                          <asp:BoundField DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:n2}"/>
                          <asp:BoundField DataField="Property1" HeaderText="Property1" />
                          <asp:BoundField DataField="Property2" HeaderText="Property2" />
                          <asp:BoundField DataField="Property3" HeaderText="Property3" />
                          <asp:BoundField DataField="Property4" HeaderText="Property4" />
                          <asp:BoundField DataField="Property5" HeaderText="Property5" />
                           <asp:BoundField HeaderText="Remarks" DataField="RemarksDetail" />
                          <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                      </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                      <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" 
                            ForeColor="White" />
                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="style3" />
                      <RowStyle CssClass="style3"/>
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
               

                     <div class="gridDiv table-responsive paddingsmall">
                                <asp:GridView ID="gvApprvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                    DataKeyNames="ItemID,RowNo,ChallanID" Width="100%" OnSelectedIndexChanged="gvApprvItem_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />                                        
                                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" />                                       
                                        <asp:BoundField HeaderText="Quantity" DataField="TempQuantity" DataFormatString="{0:n2}"/>
                                        <%--<asp:BoundField HeaderText="Unit" DataField="TempUnitCode" />--%>
                                        <asp:BoundField HeaderText="Unit Price" DataField="TempUnitPrice" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="Vatable Price" DataField="TotalPrice" DataFormatString="{0:n2}" />
                                        <asp:BoundField HeaderText="SD" DataField="PurchaseSD" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="VAT" DataField="PurchaseVAT" DataFormatString="{0:n2}"/>
                                        <asp:BoundField HeaderText="AIT" DataField="AIT_Amount" DataFormatString="{0:n2}"/>
                                        <asp:BoundField DataField="TotalPurchasePrice" HeaderText="Total Purchase Price" DataFormatString="{0:n2}" />
                                        <asp:BoundField HeaderText="VDS" DataField="SrcTAXDeduct" />
                                        <asp:BoundField HeaderText="Exempted" DataField="Exempted" />
                                        <asp:BoundField HeaderText="Deemed Exp" DataField="DeemedExport" />
                                        <asp:BoundField HeaderText="Vat Rate" DataField="VATRate" Visible="false" />
                                        <asp:BoundField HeaderText="Rebatable" DataField="Rebatable" />
                                        <asp:BoundField HeaderText="Is Zero Rate" DataField="ZeroRate" />                                                                                                     
                                        <asp:BoundField HeaderText="Is Fixed VAT" DataField="Fixed" />
                                        <asp:BoundField HeaderText="Is Reduced" DataField="Truncated" />
                                        <asp:BoundField HeaderText="Is MRP" DataField="Mrp" />                                       
                                         <asp:BoundField HeaderText="Remarks" DataField="RemarksDetail" />
                                        
                                       
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>


                 <div style="height: 5px"></div>
                 <div style="text-align: right" class="hiddencol">
                     <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Small" Text="Total Import Amount :"></asp:Label> <asp:TextBox ID="txtTotalImportPrice" Width="130px" runat="server"></asp:TextBox>
                 </div>
            </div>
        </div>
    </div>
       <div class="row">
        <div class="panel panel-primary">
            <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                <div class="container-fluid">
                  <div class="gridDiv table-responsive paddingsmall" runat="server">
                                <div class="wrapper1">
                                    <div class="div1"></div>
                                 </div>
                              <div class="wrapper2">
                                   <div class="div2">
                                 <asp:GridView ID="gvExcelFile"  runat="server" AutoGenerateColumns="false" CellPadding="4" Width="100%"
                                       DataKeyNames="Item_id"  OnRowDataBound="gvExcelFile_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
                                     <Columns>

                                  <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="rowNo" Value='<%# Eval("rowNo") %>' runat="server" />
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
                                </div>
                           </div>
                </div>
            </div>
        </div>
    </div>
         <div class="container" style="height:auto" runat="server" id="boePrint" visible="false">
    <div class="row">
      <p style="text-align:center;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
      <p style="text-align:center; padding:0px">জাতীয় রাজস্ব বোর্ড</p>
      <p style="text-align:center;margin-left: 80px;">কর চালানপত্র  <b style="border:1px solid #000; margin-left:1%; float:right">মূসক-৬.৩</b></p>
      <p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (গ) ও দফা (চ) দ্রষ্টব্য]</p>
    </div>
    
    <div class="row" style="width:100%; height:0px;">
     <div class="col-sm-4" style="width:33%; height:150px; float:left">
        <p >Supplier Name: <asp:Label runat="server" ID="lblSupplierName" /></p>
        <p>LC No: <asp:Label runat="server" ID="lblLCNo" /></p>
        <p>LC Value & Currency: <asp:Label runat="server" ID="lblLCValue" /></p>
        <p >Shipment Date: <asp:Label runat="server" ID="lblShippmentDate" /></p>
     </div>
     <div class="col-sm-4" style="width:32%; height:150px; float:left">
        <p >Supplier Country: <asp:Label runat="server" ID="lblSupplierCountry" /></p>
        <p>LC Date: <asp:Label runat="server" ID="lblLCDate" /></p>
         <p>Bill of Entry No: <asp:Label runat="server" ID="lblBoENo" /></p>
         <p >Release Order No: <asp:Label runat="server" ID="lblReleaseOrderNo" /></p>
     </div>
     <div class="col-sm-4" style="width:32%; height:150px; float:left">
       <p>Challan No: <asp:Label runat="server" ID="lblChallanNo" /></p>
       <p>LC Amount: <asp:Label runat="server" ID="lblLCAmount" />  Tk.</p>
       <p>Bill of Entry Date: <asp:Label runat="server" ID="lblBoEDate" /></p>
       <p >Release Order Date: <asp:Label runat="server" ID="lblReleaseOrderDate" /></p>
     </div>
    </div>
        <br />
    <div class="row" style="padding:1px">
      <table class="table table-bordered" style="width:auto; text-align:center;background:none; border-collapse:collapse;">
        <tr style="text-align:center">
          <th scope="row" style="width:5%;text-align:center;border:1px solid gray">Serial No</th>
          <th style="width:15%;text-align:left;border:1px solid gray">Item Name</th>
          <th style="width:5%;text-align:center;border:1px solid gray">Quantity</th>
          <th style="width:2%;text-align:center;border:1px solid gray">Unit</th>
          <th style="width:15%;text-align:center;border:1px solid gray">UnitPrice</th>
          <th style="width:5%;text-align:center;border:1px solid gray">CD</th>
          <th style="width:5%;text-align:center;border:1px solid gray">RD</th>
          <th style="width:5%;text-align:center;border:1px solid gray">SD</th>
          <th style="width:5%;text-align:center;border:1px solid gray">VAT</th>
          <th style="width:2%;text-align:center;border:1px solid gray">ATV</th>
          <th style="width:2%;text-align:center;border:1px solid gray">TTI</th>
          <th style="width:2%;text-align:center;border:1px solid gray">AIT</th>
          <th style="width:5%;text-align:center;border:1px solid gray">Others</th>
          <th style="width:5%;text-align:center;border:1px solid gray">Document Fee</th>
          <th style="width:10%;text-align:center;border:1px solid gray">Assessable Value</th>
          <th style="width:15%;text-align:center;border:1px solid gray">Total Value</th>
        </tr>
        <tr>
          <asp:Label runat="server" ID="lblBillofEntryReport" />
        </tr>
        </table>
    </div>
</div>
<div class="row">
<asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-info" style="float:right" OnClientClick="return PrintPanel()" Visible="false"/>
</div>
</div>
<%--<uc2:MsgBox ID="msgBox" runat="server" />--%>
                <uc1:MsgBoxs runat="server" ID="MsgBoxs" />
</div>
            
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
