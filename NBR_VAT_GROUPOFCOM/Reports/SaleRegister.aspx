<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_SaleRegister, App_Web_y1tsx4fu" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />

<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=rpSaleReportSingle.ClientID %>");
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
    <script type = "text/javascript">
        function PrintPanelAll() {
            var panel = document.getElementById("<%=SaleReportAllItem.ClientID %>");
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
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
</script>

<style type="text/css">
        .style1
        {
            text-align: right;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="container-fluid">
    <div class="panel-group">
      <div class="panel panel-primary">
        <div class="panel-heading" style="text-align:center; font-size:21px; font-weight:bold; height:30px; padding-top:0px">Sale Register</div>
          <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
            <div class="row" style="margin-top:1%">
            <div class="col-sm-4">
                <fieldset class="scheduler-border-report" style="margin:-9px; padding:0em">
                <legend title="" class="scheduler-border-report">কর মেয়াদ</legend>
                <div class="col-sm-6" style="padding:0px">
                 <asp:Label ID="Label2" runat="server" Text="Date From:" class="present-address-lbl" style="margin-left:5%"></asp:Label>
                 <ww:jQueryDatePicker ID="dtpDateFrom" runat="server" style="width:60%; margin-left:38%" class="present-address-tb" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY"></ww:jQueryDatePicker>
                 <asp:Label runat="server" ID="lblFromDate" Font-Bold="true" Font-Size="Small" ForeColor="Red" ></asp:Label>
               </div>
               <div class="col-sm-6" style="padding:0px">
                 <asp:Label ID="Label1" runat="server" Text="Date To:" class="present-address-lbl"></asp:Label>
                 <ww:jQueryDatePicker ID="dtpDateTo" runat="server" style="width:60%; margin-left:26%" class="present-address-tb" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY"></ww:jQueryDatePicker>
                 <asp:Label runat="server" ID="lblToDate" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label>
               </div>
              </fieldset>
            </div>
            <div class="col-sm-4" style="padding:0px">
                 <asp:Label ID="Label3" runat="server" class="present-address-lbl" Text="Challan Number:"/>
                 <asp:TextBox runat="server" ID="txtChallanNumber" style="width:60%; margin-left:24%" class="present-address-tb"></asp:TextBox>
            </div>
            <div class="col-sm-4" style="padding:0px">
                 <asp:Label ID="Label6" runat="server" class="present-address-lbl" Text="Sale Type:" style="float:left"/>
                 <asp:DropDownList runat="server" ID="drpTrnsType" class="present-address-tb" style="float:left;width:37%">
                   <asp:ListItem>Purchase</asp:ListItem>
                   <asp:ListItem>Import</asp:ListItem>
                    <asp:ListItem>Manufacturing</asp:ListItem>
                 </asp:DropDownList>
                 <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" style="float:left;width:100px;margin-left:11%" />
            </div>    
            </div>
            <div class="row" style="margin-top:1%">
               <div class="col-sm-4">
                 <asp:Label ID="Label4" runat="server" class="present-address-lbl" Text="Products:"/>
                 <asp:DropDownList runat="server" AutoPostBack="true" ID="drpProduct" style="width:75%; margin-left:18%;text-align:left" class="present-address-tb">
                 </asp:DropDownList>
               </div>
               <div class="col-sm-4">
                    <asp:Label ID="Label5" runat="server" style="margin-left:2%" class="present-address-lbl" Text="Party Name:"/>
                 <asp:TextBox runat="server" ID="txtOrgName" style="margin-left:22%;width:65%" class="present-address-tb"></asp:TextBox>
               </div>
               <div class="col-sm-4">
                    <asp:Label ID="Label7" runat="server" style="margin-left: 0%;float:left" class="present-address-lbl" Text="Branch" />
                    <asp:TextBox runat="server" ID="txtBIN" class="present-address-tb" style="float:left;width:40%; margin-left:2%" visible ="false"></asp:TextBox>
                   
                    <asp:DropDownList runat="server" ID="drpBranchInformation" style="float:left;width:40%; margin-left:2%" Height = "25px" >
                 </asp:DropDownList>
                    <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show Report" style="float:left; margin-left:12%" />
               </div>
            </div>
          </div>
        </div>
        <div>
         <div id="rpSaleReportSingle" runat="server" Visible="false"  class="container-fluid" style="margin-top:2%">
             <div class="row">
              <p style="text-align:center;font-size:16px;font-weight:bold"><asp:Label runat="server" ID="lblOrgNameRP" /></p>
               <p style="text-align:center"><asp:Label runat="server" ID="lblOrgAddressRP" /></p>
               <p style="text-align:center"><asp:Label runat="server" ID="lblOrgBINRP" /></p>
             </div>
             <div class="row">
               <p>Item Name:<asp:Label runat="server" ID="lblProductName" style="margin-left:5px"></asp:Label>
                 </p>
               <table class="table table-bordered" style="width:100%;text-align:center;background:none">
                  <tr>
                   <td rowspan="2" style="text-align:center;font-weight:bold">Serial No</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">Sale Type</td>
                   <td colspan="5" style="text-align:center;font-weight:bold">Local/Export</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">VAT</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">SD</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">Price</td>
                  </tr>
                  <tr>
                    <td style="text-align:center;font-weight:bold">Challan No</td>
                    <td style="text-align:center;font-weight:bold">Sale Date</td>
                    <td style="text-align:center;font-weight:bold">Buyer Name</td>
                    <td style="text-align:center;font-weight:bold">Buyer BIN</td>
                    <td style="text-align:center;font-weight:bold">Quantity</td>
                  </tr>
                  <tr><asp:Label runat=server ID="lblSaleReportSingle"></asp:Label></tr>
               </table>
             </div>
            </div>
             <asp:Button ID="btnReportSingle" runat="server" Text="Print" CssClass="btn btn-default" style="float:right" onclientclick="return PrintPanel();" Visible="false" />
            </div>

            <div id="SaleReportAllItem" runat="server" Visible="false"  class="container-fluid" style="margin-top:2%">
             <div class="row">
              <p style="text-align:center;font-size:16px;font-weight:bold"><asp:Label runat="server" ID="lblOrgNameRP1" /></p>
               <p style="text-align:center"><asp:Label runat="server" ID="lblOrgAddressRP1" /></p>
               <p style="text-align:center"><asp:Label runat="server" ID="lblOrgBINRP1" /></p>
             </div>
             <div class="row">
               <table class="table table-bordered" style="width:100%;text-align:center;background:none">
                  <tr>
                   <td rowspan="2" style="text-align:center;font-weight:bold">Serial No</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">Sale Type</td>
                   <td colspan="6" style="text-align:center;font-weight:bold">Local/Export</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">VAT</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">SD</td>
                   <td rowspan="2" style="text-align:center;font-weight:bold">Price</td>
                  </tr>
                  <tr>
                   <td style="text-align:center;font-weight:bold">Challan No</td>
                   <td style="text-align:center;font-weight:bold">Sale Date</td>
                    <td style="text-align:center;font-weight:bold">Buyer Name</td>
                    <td style="text-align:center;font-weight:bold">Buyer BIN</td>
                    <td style="text-align:center;font-weight:bold">Item</td>
                    <td style="text-align:center;font-weight:bold">Quantity</td>
                  </tr>
                  <tr><asp:Label runat=server ID="lblSaleReportAll"></asp:Label></tr>
               </table>
             </div>
            </div>
            <asp:Button ID="btnReportAll" runat="server" Text="Print" CssClass="btn btn-default" style="float:right" onclientclick="return PrintPanelAll();" Visible="false" />
            <%--<asp:Button ID="btnCSV" runat="server" Text="CSV" CssClass="btn btn-info" style="float:right" onClick="btnCSVFormat_Click" />
            <asp:Button ID="csvToReportBTN" runat="server" Text="CSV to Report" CssClass="btn btn-info" style="float:right" onClick="btnCSVToReport_Click" />--%>
      </div>
      <uc2:MsgBox ID="msgBox" runat="server" />
  </div>
</asp:Content>

