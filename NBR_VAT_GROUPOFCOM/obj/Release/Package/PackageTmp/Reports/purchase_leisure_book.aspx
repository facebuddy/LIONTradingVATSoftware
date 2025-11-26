<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_purchase_leisure_book, App_Web_y1tsx4fu" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/str.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                            Payable Ledger Book
                        </div>
                        <div class="panel-body" style="padding-bottom: 5px">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">From Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="dtpFromDate" DateFormat="dd/MM/yyyy" />
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpFromDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">To Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="dtpToDate" DateFormat="dd/MM/yyyy" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpToDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>Party Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpPartyName" runat="server" class="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpPartyName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><%--<span class="required" style="color:red"> * </span>--%>Challan No :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpChallanNo" runat="server" class="form-control select2"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><%--<span class="required" style="color:red"> * </span>--%>Payment Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="paymentType" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="showBTN" runat="server" CssClass="btn-btn" Style="background-color: #3B7CB5;float: right; margin-right: 2%" Text="Search" OnClick="showBTN_Click" />
                                    <asp:Button ID="btnPrint" CssClass="btn btn-warning btn-sm" Style="float: right" runat="server" Text="Print" OnClientClick="return PrintPanel();"/>
                               <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px;float: right"></asp:TextBox>
                                      </div>
                              
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="precisionTxtBox" runat="server"
                                ErrorMessage="Precision has to be a number between 0 to 12"
                                ForeColor="Red"
                                ValidationExpression="\d+">
                            </asp:RegularExpressionValidator>

                            <div class="row" style="font-family:Nikosh;font-size:12px">
                                <asp:Panel ID="pnlContents" runat="server">
                                    <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <tr>
                                            <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                                class="style4">
                                                <asp:Label ID="lblPartyName" runat="server" />
                                                - Payable Ledger Book
                                            </th>
                                        </tr>
                                         <tr style="background-color: White">
                                             <td class="style10" align="center" style="width: 5%;">
                                                <strong>SI No.</strong>
                                            </td>

                                            <td class="style10" align="center" style="width: 20%;">
                                                <strong>Party Name</strong>
                                            </td>

                                            <td class="style10" align="center" style="width: 10%;">
                                                <strong>Item</strong>
                                            </td>

                                            <td class="style10" align="center" style="width: 10%;">
                                                <strong>Challan No</strong>
                                            </td>

                                            <td class="style11" align="center" style="width: 10%;">
                                                <strong>Quantity</strong>
                                            </td>

                                            <td class="style14" align="center" style="width: 10%;">
                                                <strong>Price</strong>
                                            </td>

                                            <td class="style13" align="center" style="width: 5%;">
                                                <strong>VAT</strong>
                                            </td>
                                               <td class="style13" align="center" style="width: 5%;">
                                                <strong>SD</strong>
                                            </td>
                                                <td class="style13" align="center" style="width: 5%;">
                                                <strong>AIT</strong>
                                            </td>
                                               <td class="style13" align="center" style="width: 5%;">
                                                <strong>VDS</strong>
                                            </td>
                                            <td class="style13" align="center" style="width: 10%;">
                                                <strong>Vatable Price</strong>
                                            </td>
                                             <td class="style13" align="center" style="width:10%;">
                                                <strong>Total</strong>
                                            </td>
                                        </tr>

                                        <tr>
                                            <asp:Label runat="server" ID="lblHeaderShow" ></asp:Label>
                                        </tr>
                                    </table>
                                    <table border="1" class="table" style="width: 100%; border-collapse: collapse">

                                        <tr style="background-color: White" id="challanTable" runat="server">
                                            <td class="style10" align="center" style="width: 10%;">
                                                <strong>Challan Date</strong>
                                            </td>

                                            <td class="style10" align="center" style="width: 10%;">
                                                <strong>Challan No</strong>
                                            </td>

                                            <td class="style10" align="center" style="width: 10%;">
                                                <strong>Particulars</strong>
                                            </td>

                                            <td class="style11" align="center" style="width: 10%;">
                                                <strong>Credit</strong>
                                            </td>

                                            <td class="style14" align="center" style="width: 10%;">
                                                <strong>Debit</strong>
                                            </td>

                                            <%--below column is added by sabbir 13/2/20--%>
                                            <td class="style14" align="center" style="width: 10%;">
                                                <strong>Balance</strong>
                                            </td>


                                            <td class="style11" align="center" style="width: 10%;">
                                                <strong>Payable VDS</strong>
                                            </td>

                                            <td class="style14" align="center" style="width: 10%;">
                                                <strong>Payable AIT</strong>
                                            </td>


                                          <%--  <td class="style13" align="center" style="width: 10%;">
                                                <strong>Balance Due</strong>
                                            </td>--%>

                                        <td class="style13" align="center" style="width: 10%;">
                                                <strong>Payment Date</strong>
                                            </td>
                                        </tr>

                                        <tr>
                                            <asp:Label  runat="server" ID="lblleisureShow"></asp:Label>
                                        </tr>
                                    </table>
                                    <div>
                                        <asp:Label style="background-color: White" runat="server" ID="multiChallanTables"></asp:Label>
                                    </div>
                                    

                      
                            <div class="" runat="server" id="gridviewtransactionhistory" visible="true">
                                <asp:GridView ID="gvtransactionhistory" runat="server" AutoGenerateColumns="False" 
                                    CssClass="sGrid"  Width="100%" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                       
                                        
                                        <asp:BoundField HeaderText="Challan No" DataField="challan_no" />                                       
                                        <asp:BoundField HeaderText="Current Balance" DataField="current_balance" />
                                        <asp:BoundField HeaderText="Payment Amount" DataField="payment_amount" />
                                        <asp:BoundField HeaderText="Due" DataField="balance_due" />
                                        <asp:BoundField HeaderText="Payment Date" DataField="payment_date" />
                                       
                                        
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>
                 
                                    <div class="col-md-12" style="margin-top: 5px">
                                        <div class="form-group form-group-sm">
                                            <asp:Label runat="server" Text="System User: "></asp:Label>
                                            <asp:Label runat="server" ID="lblUser"></asp:Label>
                                            <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                            <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                        </div>
                                    </div>
                                </asp:Panel>

                            </div>
                         
                        </div>

                    </div>
                    <uc2:MsgBox ID="msgBox" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>


</asp:Content>
