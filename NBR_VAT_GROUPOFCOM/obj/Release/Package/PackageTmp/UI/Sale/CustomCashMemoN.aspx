<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Sale_CustomCashMemo, App_Web_ud0pgtmp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var windowHeight = window.innerHeight;
            var windowWidth = window.innerWidth;
            var printWindow = window.open('', '', 'letf=0,top=0,height=' + windowHeight + ',width=' + windowWidth + ',toolbar=0,scrollbars=1,status=0');
            printWindow.document.write('<html><head><title>Customer Invoice</title>');
            printWindow.document.write('<link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />');
            printWindow.document.write('</head><body style="padding:5%">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            // printWindow.close();
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-info btn-sm" Style="float:right"  Text="Print" OnClientClick="PrintPanel();" />
            </div>
        </div>
        <div class="row" style="margin-top: 1%">
            <asp:Panel ID="pnlContents" runat="server"  Visible="false">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <div class="col-sm-4"></div>
                           <%-- <div class="col-sm-4">
                                <center>
                                    <label style="font-size:18pt; font-weight:bold">Invoice</label><br />
                                    <asp:Label style="font-size:11pt; font-weight:bold" runat="server" ID="lblServiceProviderName" /><br />
                                    <asp:Label runat="server" ID="lblServiceProviderAddress" /><br />
                                    <label>VAT REg. No. :</label>
                                    <asp:Label runat="server" ID="lblServiceProviderBIN" />
                                 </center>
                            </div>--%>
                            <div class="col-sm-4"></div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top:5px" >
                    <div class="col-md-4">
                        <label>Customer Code : </label>
                        <asp:Label runat="server" ID="Label1" />
                    </div>
                    <div class="col-md-4">
                        <label>Invoice No : </label>
                        <asp:Label runat="server" ID="lblInvoiceNo" />
                    </div>
                    <div class="col-md-4"></div>
                   
                </div>
                <div class="row" style="margin-top:2px">
                     <div class="col-md-4">
                        <label>Customer Name : </label>
                        <asp:Label runat="server" ID="lblparty" />
                    </div>
                     <div class="col-md-4">
                        <label>Invoice Date : </label>
                        <asp:Label runat="server" ID="lblInvoiceDate" />
                    </div>
                   <%-- <div class="col-md-12">
                        <label>Organization Name : </label>
                        <asp:Label runat="server" ID="lblOrganizationName" />
                    </div>--%>
                </div>
                <div class="row" style="margin-top:2px">
                     <div class="col-md-4">
                        <label>Address : </label>
                        <asp:Label runat="server" ID="lblparty_address" />
                    </div>
                     <div class="col-md-4">
                        <label>Depot : </label>
                        <asp:Label runat="server" ID="l" />
                    </div>
                   <%-- <div class="col-md-12">
                        <label>Organization Name : </label>
                        <asp:Label runat="server" ID="lblOrganizationName" />
                    </div>--%>
                </div>
                <div class="row" style="margin-top:2px">
                     <div class="col-md-4">
                        <label>Employee Name : </label>
                        <asp:Label runat="server" ID="lblparty_emp" />
                    </div>
                     <div class="col-md-4">
                        <label>D/A Name : </label>
                        <asp:Label runat="server" ID="lblEmployee" />
                    </div>
                   <%-- <div class="col-md-12">
                        <label>Organization Name : </label>
                        <asp:Label runat="server" ID="lblOrganizationName" />
                    </div>--%>
                </div>
                <div class="row" style="margin-top:2px">
                     <div class="col-md-4">
                        <label>Order No : </label>
                        <asp:Label runat="server" ID="lblorderno" />
                    </div>
                     <div class="col-md-4">
                        <label>Order Date : </label>
                        <asp:Label runat="server" ID="txtorderdate" />
                    </div>
                   <%-- <div class="col-md-12">
                        <label>Organization Name : </label>
                        <asp:Label runat="server" ID="lblOrganizationName" />
                    </div>--%>
                </div>
              
              <%--  <div class="row" style="margin-top:5px">
                    <table border=1 style="margin-left:15px;border-collapse:collapse;">
                       
                          <tr>
                              <td>Gross TP:</td>
                              <td>Less Discount on TP:</td>
                              <td>Add VAT on TP:</td>
                              <td>Net Payable:</td>
                              <td>Less Advanced:</td>
                              <td>Cash Paid:</td>
                              <td>Balance:</td>
                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="lbltotal"></asp:Label>
                        </tr>
                    </table>
                </div>--%>
                 <div class="row" style="margin-top:5px">
                    <table border=1 style="margin-left:15px;border-collapse:collapse;">
                        <tr>
                            <td colspan="4">Previous Credit Status:</td>
                        </tr>
                          <tr>
                              <td>Invoice no</td>
                              <td>Invoice Date</td>
                              <td>Pay mode</td>
                            <td>Out Standing</td>
                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="lbldueinfo"></asp:Label>
                        </tr>
                    </table>
                </div>
                <div class="row" style="margin-top:25px">
                    <div class="col-md-8"></div>
                    <div class="col-md-4">
                        <asp:Label runat="server" Text="........................................................." /><br />
                        <asp:Label runat="server" ID="lblOrganizationName"></asp:Label>
                    </div>
                </div>
            </asp:Panel>
        </div>
         <div>
         <div class="row" runat="server" id="templateArea">
       
         </div>

                     <div class="row" style="margin-top:5px">
                    <table border="1" style="margin-left:15px; border-collapse:collapse;">
                        <tr style="background:lightgrey">
                            <%--<td style="text-align:left; font-weight:bold;height:30px; font-size:11pt; padding:2px">Item</td>
                            <td style="text-align:left; font-weight:bold;font-size:11pt; padding:2px">Unit</td>
                            <td style="text-align:right; font-weight:bold;font-size:11pt; padding:2px">Quantity</td>
                            <td style="text-align:right; font-weight:bold;font-size:11pt; padding:2px">Rate</td>
                            <td style="text-align:right; font-weight:bold;font-size:11pt; padding:2px">VAT</td>
                            <td style="text-align:right; font-weight:bold;font-size:11pt; padding:2px">Amount</td>--%><%--02-10-2019--%>
                            <%--<td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">SL#</td>--%>
                            <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Product Code</td>
                            <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Product Name</td>
                            <%--<td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Pack Size</td>--%>
                            <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Quantity</td> 
                            <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Unit Price TP/SP</td>
                            <%--<td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Unit VAT</td>--%>
                            <%--<td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Unit Price With VAT</td>--%> 
                            <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Quantity</td>   
                             <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Total Space</td>                            
                            <%--<td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Discount on TP (TK)</td>--%>
                            <%--<td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Discount on TP (%)</td>--%>
                            <%--<td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Bonus</td>--%>
                           <%-- <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Total VAT</td>                           
                            <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Total TP/SP</td>
                            <td style="text-align:center; font-weight:bold;font-size:11pt; padding:2px">Net Bill</td>--%>
                            
                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="lblLoadInvoiceData"></asp:Label>
                        </tr>
                    </table>
                </div>
    </div>
</asp:Content>
