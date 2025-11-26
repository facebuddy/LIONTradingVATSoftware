<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="SaleAccountingBook_6_2, App_Web_pj2ymx2u" %>
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
        var panel = document.getElementById("<%=rpSaleAccountingBook.ClientID %>");
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
        <div class="panel-heading" style="text-align:center; font-size:21px; font-weight:bold; height:30px; padding-top:0px">বিক্রয় হিসাব পুস্তক (মূসক-৬.২)</div>
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
                 <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" CssClass="test-btn-primary" style="float:left;width:100px;margin-left:11%" />
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
                    <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show Report" CssClass="test-btn-primary" style="float:left; margin-left:12%;width: 100px;" />
               </div>
            </div>
          </div>
        </div>
         <div id="rpSaleAccountingBook" runat="server" Visible="false"  class="container-fluid" style="margin-top:2%">
             <div class="row">
               <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
               <p style="text-align:center">জাতীয় রাজস্ব বোর্ড</p>
               <p style="text-align:right;"><strong style="text-align:center; border:1px solid gray; margin-right:5%">মূসক-৬.২</strong></p>
               <p style="text-align:center">বিক্রয় হিসাব পুস্তক</p>
               <p style="text-align:center">(সরবরাহযোগ্য পণ্যের হিসাব)</p>
               <p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (খ) ও বিধি ৪১ এর দফা (ক) দ্রষ্টব্য]</p>
             </div>
             <div class="row">
               <p>পণ্যের নাম:<asp:Label runat="server" ID="lblProductName" style="margin-left:5px"></asp:Label>
                 </p>
               <table class="table table-bordered" style="width:100%;text-align:center;background:none">
                  <tr>
                   <td rowspan="2">ক্রমিক সংখ্যা </td>
                   <td rowspan="2">তারিখ</td>
                   <td rowspan="2">মজুদ উপকরণের প্রারম্ভিক জের</td>
                   <td colspan="4">আমদানি/উৎপাদন/ক্রয় </td>
                   <td rowspan="2">মোট</td>
                   <td rowspan="2">বিক্রয়</td>
                   <td rowspan="2">সমাপনী জের</td>
                   <td rowspan="2">মন্তব্য</td>
                  </tr>
                  <tr>
                   <td >চালান... বিল অব এন্ট্রির নম্বর </td>
                    <td >তারিখ </td>
                     <td >ক্রেতার নাম ও বিআইএন </td>
                      <td >পরিমাণ</td>
                  </tr>
                  <tr>
                    <td>(১)</td>
                    <td>(২)</td>
                    <td>(৩)</td>
                    <td>(৪)</td>
                    <td>(৫)</td>
                    <td>(৬)</td>
                    <td>(৭)</td>
                    <td>(৮=৩+৭)</td>
                    <td>(৯)</td>
                    <td>(১০=৮-৯)</td>
                    <td>(১১)</td>
                  </tr>
                  <tr><asp:Label runat=server ID="lblSaleAccountingBook"></asp:Label></tr>
               </table>
             </div>
            </div>
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="test-btn-primary" style="float:right" onclientclick="return PrintPanel();" Visible="false" />
           <%-- <asp:Button ID="btnCSV" runat="server" Text="CSV" CssClass="btn btn-info" style="float:right" onClick="btnCSVFormat_Click" />
            <asp:Button ID="csvToReportBTN" runat="server" Text="CSV to Report" CssClass="btn btn-info" style="float:right" onClick="btnCSVToReport_Click" />--%>
      </div>
      <uc2:MsgBox ID="msgBox" runat="server" />
  </div>
</asp:Content>
