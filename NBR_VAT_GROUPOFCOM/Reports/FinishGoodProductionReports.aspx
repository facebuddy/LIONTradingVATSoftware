<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="FinishGoodProductionReports.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.FinishGoodProductionReports" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>
     <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=bill.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold;
                    height: 30px; padding-top: 0px"> Finish Product (Production) Report</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="margin-top: 1%">
                        <div class="col-sm-4">
                            <asp:Label ID="Label2" runat="server" Text="Date From:" class="present-address-lbl" Style="margin-left: 5%"></asp:Label>
                            <asp:TextBox ID="dtpDateFrom" runat="server" Style="width: 70%; margin-left: 23%; height:27px"
                                class="present-address-tb" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                            <asp:Label ID="lblfromDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="Label1" runat="server" Text="Date To:" class="present-address-lbl" style="margin-left:48px"></asp:Label>
                            <asp:TextBox ID="dtpDateTo" runat="server" Style="width: 70%; margin-left: 28%;height:27px"
                                class="present-address-tb" DateFormat="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                            <asp:Label ID="lblToDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click"
                                Text="Search" Style="float: left;  margin-left: 25%" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom:3px">
                        <div class="col-sm-4">
                            <asp:Label ID="Label4" runat="server" class="present-address-lbl" Text="Finish Product:" style="margin-left:-3px"/>
                            <asp:DropDownList runat="server" ID="drpIngredient" Style="width: 70%; margin-left: 23%; height:27px;
                                text-align: left" class="present-address-tb">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="Label3" runat="server" class="present-address-lbl" Text="Challan Number:" />
                            <asp:TextBox runat="server" ID="txtChallanNumber" Style="width: 70%; margin-left: 28%;height:27px"
                                class="present-address-tb"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                             <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                            <asp:Button ID="btnShowReport" runat="server" CssClass="btn btn-primary" OnClick="btnShowReport_Click"
                                Text="Show Report" Style="background-color:#5CB85C;" />
                        </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator> 
                    </div>
                </div>
            </div>
            <div id="bill" runat="server" Visible="true"  class="container-fluid" style="margin-top:2%;font-family:Nikosh">
              <div class="row">
               <p style="text-align:center"><asp:Label runat="server" ID="lblOrgName" style="font-size:20px; font-weight:bold" /></p>
               <p style="text-align:center">BIN:&nbsp<asp:Label runat="server" ID="lblOrgBin"/></p>
               <p style="text-align:center;font-weight:bold">Finish Product(Production) Detail Report</p>
             </div>
             <div class="row" style="margin-top:3%">
               <p><asp:Label runat="server" ID="lblParamaters" /></p>
             </div>
             <div class="row" style="font-size:12px">
               <table class="table table-bordered" style="width:100%;background:none">
               <tr style="background-color:lightgray">
               <td style="text-align:center;font-weight:bold;font-size:11pt">চালান নং</td>
               <td style="text-align:center;font-weight:bold;font-size:11pt">চালান তারিখ</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">পণ্যের নাম</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">পণ্যের একক</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">পণ্যের পরিমাণ</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">একক মূল্য</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">মোট মূল্য</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">সম্পূরক শুল্ক</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">মূল্য সংযোজন কর</td>
                   <td style="text-align:center;font-weight:bold;font-size:11pt">মোট মূল্য (সম্পূরক শুল্ক ও মূসক সহ )</td>
                  </tr>
                  <tr>
                    <asp:Label runat="server" ID="lblFinishProductRpt" />
                  </tr>
                <%--  <tr>
                    <td colspan="6" style="text-align:left;border-right:none;padding-left: 20px;">মোট :</td>
                    <td style="text-align:center;border-bottom:1px solid gray;border-left:none; border-right:none"><asp:Label runat="server" ID="lblTotalPrice" /></td>
                    <td style="text-align:center;border-bottom:1px solid gray;border-left:none; border-right:none"><asp:Label runat="server" ID="lblTotalSD" /></td>
                    <td style="text-align:center;border-bottom:1px solid gray;border-left:none; border-right:none"><asp:Label runat="server" ID="lblTotalVAT" /></td>
                    <td style="text-align:center;border-bottom:1px solid gray;border-left:none; "><asp:Label runat="server" ID="lblTotalPriceVatSD" /></td>
                  </tr>--%>
                </table>
             </div>
            </div>
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-default" style="float:right" onclientclick="return PrintPanel();" />
        </div>
    </div>
</asp:Content>
