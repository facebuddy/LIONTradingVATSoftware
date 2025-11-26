<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="AuditTrailLog, App_Web_qhrdyc5n" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head><body style="margin: 50px;">');
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">Trail Log Report</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label">From Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="fromDate" CssClass="form-control" DateFormat="dd/MM/yyyy" MaxLength="10" placeholder="DD/MM/YYYY" />
                                            <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="fromDate" />
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label">To Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="toDate" CssClass="form-control" DateFormat="dd/MM/yyyy" MaxLength="10" placeholder="DD/MM/YYYY" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="toDate" />
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label">Modified Table :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlModifiedTable" CssClass="form-control">
                                                <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                                <asp:ListItem Value="1">Purchase Master Table</asp:ListItem>
                                                <asp:ListItem Value="2">Purchase Detail Table</asp:ListItem>
                                                <asp:ListItem Value="3">Sale Master Table</asp:ListItem>
                                                <asp:ListItem Value="4">Sale Detail Table</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group form-group-sm">
                                        <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary btn-sm" OnClick="btnSearch_Click"><i class="fa fa-search-plus"></i> Search</asp:LinkButton> 
                                        
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-info btn-sm" OnClientClick="return PrintPanel();" />
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div runat="server" id="print">
                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <div class="col-sm-4"></div>
                            <div class="col-sm-4">
                                <center>
                                 <asp:Label runat="server" class="control-label" style="font-size:16px; font-weight:bold" Text="Audit Trail Log"/>
                                </center>
                            </div>
                            <div class="col-sm-4"></div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <div class="col-sm-8">
                                <asp:Label runat="server" class="control-label" Text="Operation Table :  "/>
                                <asp:Label runat="server" class="control-label" id="lblOperationTable"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:Label runat="server" class="control-label" Text="From  "/>&nbsp&nbsp&nbsp&nbsp
                                <asp:Label runat="server" ID="lfDate" class="control-label"/>&nbsp&nbsp&nbsp&nbsp
                                <asp:Label runat="server" class="control-label" Text="  To "/>&nbsp&nbsp&nbsp&nbsp
                                <asp:Label runat="server" ID="ltDate" class="control-label"/>
                               
                            </div>
                            <div class="col-sm-4"></div>
                        </div>

                    </div>
                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <div runat="server" id="purchaseMaster">
                                <div class="table-responsive">
                                <table class="table" border="1" style="background: none;border-collapse:collapse">
                                        <tr>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">SL. No.</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Operation</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Modified Date</td>
                                            <td colspan="5" style="text-align: center;font-weight:bold;">Original Data of Purchase Master Table</td>
                                            <td colspan="7" style="text-align: center;font-weight:bold;">Modified Data of Purchase Master Table</td>
                                        </tr>
                                        <tr>
                                            <%--<td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                            
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                            <%--<td style="text-align: center;font-weight:bold;">Purchase Type</td>--%>
                                            <%--<td style="text-align: center;font-weight:bold;">Payment</td>
                                            <td style="text-align: center;font-weight:bold;">Delete</td>--%>
                                            <%--<td style="text-align: center;font-weight:bold;">Vat Paid</td>--%>
                                            <td style="text-align: center;font-weight:bold;">LC No</td>
                                            <td style="text-align: center;font-weight:bold;">LC Date</td>
                                            <td style="text-align: center;font-weight:bold;">LC Amount</td>

                                            <%--<td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                            <td style="text-align: center;font-weight:bold;">IP Address</td>
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                           <%-- <td style="text-align: center;font-weight:bold;">Purchase Type</td>
                                            <td style="text-align: center;font-weight:bold;">Payment</td>
                                            <td style="text-align: center;font-weight:bold;">Delete</td>
                                            <td style="text-align: center;font-weight:bold;">Vat Paid</td>--%>
                                            <td style="text-align: center;font-weight:bold;">LC No</td>
                                            <td style="text-align: center;font-weight:bold;">LC Date</td>
                                            <td style="text-align: center;font-weight:bold;">LC Amount</td>
                                            <td style="text-align: center;font-weight:bold;">Modified Column</td>
                                        </tr>
                                    <tbody>
                                        <tr>
                                            <asp:Label runat="server" ID="lblPurchaseMaster" />
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            </div>
                            <div runat="server" id="saleMaster">
                                <div class="table-responsive">
                                <table class="table" border="1" style="background: none;border-collapse:collapse">
                                        <tr>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">SL. No.</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Operation</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Modified Date</td>
                                            <td colspan="7" style="text-align: center;font-weight:bold;">Original Data of Sale Master Table</td>
                                            <td colspan="9" style="text-align: center;font-weight:bold;">Modified Data of Sale Master Table</td>
                                        </tr>
                                        <tr>
                                            <%--<td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                            
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                            <td style="text-align: center;font-weight:bold;">Trans Type</td>
                                            <td style="text-align: center;font-weight:bold;">Year</td>
                                            <td style="text-align: center;font-weight:bold;">Payment</td>
                                            <td style="text-align: center;font-weight:bold;">Vat Paid</td>
                                            <td style="text-align: center;font-weight:bold;">SD Paid</td>
                                           <%-- <td style="text-align: center;font-weight:bold;">Delete</td>

                                            <td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                            <td style="text-align: center;font-weight:bold;">IP Address</td>
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                            <td style="text-align: center;font-weight:bold;">Trans Type</td>
                                            <td style="text-align: center;font-weight:bold;">Year</td>
                                            <td style="text-align: center;font-weight:bold;">Payment</td>
                                            <td style="text-align: center;font-weight:bold;">Vat Paid</td>
                                            <td style="text-align: center;font-weight:bold;">SD Paid</td>
                                            <%--<td style="text-align: center;font-weight:bold;">Delete</td>--%>
                                             <td style="text-align: center;font-weight:bold;">Modified Column</td>
                                        </tr>
                                    <tbody>
                                        <tr>
                                            <asp:Label runat="server" ID="lblSaleMaster" />
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            </div>
                            <div runat="server" id="purchaseDetail">
                                <div class="table-responsive">
                                <table class="table" border="1" style="background: none;border-collapse:collapse">
                                        <tr>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">SL. No.</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Operation</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Modified Date</td>
                                            <td colspan="14" style="text-align: center;font-weight:bold;">Original Data of Purchase Detail Table</td>
                                            <td colspan="16" style="text-align: center;font-weight:bold;">Modified Data of Purchase Detail Table</td>
                                        </tr>
                                        <tr>
                                            <%--<td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                           
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                            <%--<td style="text-align: center;font-weight:bold;">Row No</td>--%>
                                            <td style="text-align: center;font-weight:bold;">Item Name</td>
                                            <td style="text-align: center;font-weight:bold;">Quantity</td>
                                            <td style="text-align: center;font-weight:bold;">Unit Price</td>
                                            <td style="text-align: center;font-weight:bold;">Vat</td>
                                            <td style="text-align: center;font-weight:bold;">SD</td>
                                            <td style="text-align: center;font-weight:bold;">CD</td>
                                            <td style="text-align: center;font-weight:bold;">RD</td>
                                            <td style="text-align: center;font-weight:bold;">AIT</td>
                                            <td style="text-align: center;font-weight:bold;">ATV</td>
                                            <td style="text-align: center;font-weight:bold;">TTI</td>
                                            <td style="text-align: center;font-weight:bold;">VDS Amount</td>

                                           <%--<td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                            <td style="text-align: center;font-weight:bold;">IP Address</td>
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                            <%--<td style="text-align: center;font-weight:bold;">Row No</td>--%>
                                            <td style="text-align: center;font-weight:bold;">Item Name</td>
                                            <td style="text-align: center;font-weight:bold;">Quantity</td>
                                            <td style="text-align: center;font-weight:bold;">Unit Price</td>
                                            <td style="text-align: center;font-weight:bold;">Vat</td>
                                            <td style="text-align: center;font-weight:bold;">SD</td>
                                            <td style="text-align: center;font-weight:bold;">CD</td>
                                            <td style="text-align: center;font-weight:bold;">RD</td>
                                            <td style="text-align: center;font-weight:bold;">AIT</td>
                                            <td style="text-align: center;font-weight:bold;">ATV</td>
                                            <td style="text-align: center;font-weight:bold;">TTI</td>
                                            <td style="text-align: center;font-weight:bold;">VDS Amount</td>
                                             <td style="text-align: center;font-weight:bold;">Modified Column</td>
                                        </tr>
                                    <tbody>
                                        <tr>
                                            <asp:Label runat="server" ID="lblPurchaseDetail" />
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            </div>
                            <div runat="server" id="saleDeail">
                                <div class="table-responsive">
                                <table class="table" border="1" style="background: none;border-collapse:collapse">
                                        <tr>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">SL. No.</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Operation</td>
                                            <td rowspan="2" style="text-align: center;font-weight:bold;">Modified Date</td>
                                            <td colspan="9" style="text-align: center;font-weight:bold;">Original Data of Sale Detail Table</td>
                                            <td colspan="11" style="text-align: center;font-weight:bold;">Modified Data of Sale Detail Table</td>
                                        </tr>
                                        <tr>
                                            <%--<td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                           
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                            <td style="text-align: center;font-weight:bold;">Row No</td>
                                            <td style="text-align: center;font-weight:bold;">Item Name</td>
                                            <td style="text-align: center;font-weight:bold;">Quantity</td>
                                            <td style="text-align: center;font-weight:bold;">Unit Price</td>
                                            <td style="text-align: center;font-weight:bold;">Vat</td>
                                            <td style="text-align: center;font-weight:bold;">SD</td>
                                            <td style="text-align: center;font-weight:bold;">VDS Amount</td>

                                          <%-- <td style="text-align: center;font-weight:bold;">Challan ID</td>--%>
                                            <td style="text-align: center;font-weight:bold;">IP Address</td>
                                            <td style="text-align: center;font-weight:bold;">Challan No</td>
                                            <td style="text-align: center;font-weight:bold;">Challan Date</td>
                                            <td style="text-align: center;font-weight:bold;">Row No</td>
                                            <td style="text-align: center;font-weight:bold;">Item Name</td>
                                            <td style="text-align: center;font-weight:bold;">Quantity</td>
                                            <td style="text-align: center;font-weight:bold;">Unit Price</td>
                                            <td style="text-align: center;font-weight:bold;">Vat</td>
                                            <td style="text-align: center;font-weight:bold;">SD</td>
                                            <td style="text-align: center;font-weight:bold;">VDS Amount</td>
                                             <td style="text-align: center;font-weight:bold;">Modified Column</td>
                                        </tr>
                                    <tbody>
                                        <tr>
                                            <asp:Label runat="server" ID="lblSaleDetail" />
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            </div>
                            <%--<div class="table-responsive">
                                <table class="table" border="1" style="background: none">
                                    <thead>
                                        <tr>
                                            <th style="text-align: center">SL. No.</th>
                                            <th style="text-align: center">Operation</th>
                                            <th style="text-align: center">Modified Date</th>
                                            <th style="text-align: center">Original Data</th>
                                            <th style="text-align: center">Modified Data</th>
                                        </tr>

                                    </thead>
                                    <tbody>
                                        <tr>
                                            <asp:Label runat="server" ID="lblReportHtml" />
                                        </tr>
                                    </tbody>
                                </table>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
