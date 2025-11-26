<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_DailySaleReport, App_Web_xijeoyc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
         <%--zahid Printpanel() function 21-07-2022--%>
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
            var printWindow = window.open('', '', 'left=0,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;font-size:smaller;} table.allSolid td { border: 1.5px solid black;}</style>');
            printWindow.document.write('</head><body style="margin:unset;font-size:smaller;">');

            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
        function PrintModal(str1) {
            
            var panel = document.getElementById("PopupContent_" + str1);
            
            var panel2 = document.getElementById("Company_details");
            var printWindow = window.open('', '', 'left=0,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>#eee1{width:124%;border:none;} #modhead11{visibility:hidden} table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;font-size:smaller;} table.allSolid td { border: 1.5px solid black;}</style>');
            printWindow.document.write('</head><body style="margin:unset;">');
            printWindow.document.write(panel2.innerHTML);
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {

                printWindow.print();

            }, 500);
            return false;
        }
        function PrintModal_Purchase(str1) {
            var panel = document.getElementById("PopupContentp_" + str1);
            var panel2 = document.getElementById("Company_details");
            var printWindow = window.open('', '', 'left=0,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>#eee1{width:124%;margin-right:50px;border:none;} #modhead11{visibility:hidden} table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;font-size:smaller;} table.allSolid td { border: 1.5px solid black;}</style>');
            printWindow.document.write('</head><body style="margin:unset;">');
            printWindow.document.write(panel2.innerHTML);
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {

                printWindow.print();

            }, 500);
            return false;
        }

    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/panel.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <%--<div class="panel-heading" style="text-align: center; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">বিক্রয় হিসাব পুস্তক (মূসক-১৭)</div>--%>
                        <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">Monthly Sales-Purchase Summary Report (Day Basis)</div>

                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">Date From :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="dtpDateFrom" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">Date To :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="dtpDateTo" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">

                                    <%--AutoPostBack="True" OnSelectedIndexChanged="drpUse_SelectedIndexChanged"--%>
                                    <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" Style="width: 80px"></asp:TextBox>
                                    <%--//zahid 24-07-22--%>
                                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="showReport_OnClick"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                                    <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                                    <%--zahid 21-07-2022--%>
                                    <asp:LinkButton ID="btnExportToExcel" runat="server" CssClass="btn btn-primary"><i class="fa fa-list"></i>  Excel</asp:LinkButton>
                                    <%--zahid 21-07-2022--%>
                                </div>

                            </div>

                        </div>
                    </div>


                    <div class="panel panel-primary" style="font-family: Nikosh">
                        <div class="panel panel-body" runat="server" id="print">
                            <%--zahid 21-07-2022--%>
                            <div class="col-md-12">
                                <div>
                                    <div class="row" style="margin-top: 1%; font-family: Nikosh; font-size: 12px">
                                        <asp:Panel ID="pnlContents" runat="server">
                                            <div class="row" style="font-size: 15px" id="Company_details">

                                                <p style="text-align: center">
                                                    <asp:Label Style="font-weight: bold; font-size: 25px;" runat="server" ID="TaxOrganizationName" />
                                                </p>
                                                <p style="text-align: center">
                                                    <asp:Label runat="server" ID="TaxOrganizationAddress" />
                                                </p>
                                                <p style="text-align: center">
                                                    <asp:Label runat="server" ID="TaxOrganizationBIN" />
                                                </p>

                                                <p style="text-align: center">
                                                    <strong>Monthly Sales-Purchase Summary Report (Day Basis) </strong>
                                                </p>
                                                <p style="text-align: center">
                                                    <asp:Label runat="server" ID="lblDate" />
                                                </p>
                                            </div>
                                            <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                                <tr>
                                                    <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                                        class="style4">Daily Sale Report
                                                    </th>
                                                </tr>


                                                <tr>
                                                    <asp:Label runat="server" ID="lblHeaderShow" Visible="false"></asp:Label>
                                                </tr>
                                            </table>
                                            <table border="1" class="table" style="width: 100%; border-collapse: collapse">

                                                <tr style="background-color: White">
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>SL</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Date</strong>
                                                    </td>
                                                    
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>No of Sale Vouchar(Local)</strong>
                                                    </td>

                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>No of Sale Vouchar(Export)</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong> Sale Amount</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong> VAT Amount</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong> SD Amount</strong>
                                                    </td>
                                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Total</strong>
                                                    </td>
                                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Action</strong>
                                                    </td>




                                                </tr>

                                                <tr>
                                                    <asp:Label runat="server" ID="lblleisureShow"></asp:Label>
                                                </tr>
                                            </table>


                                            <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                                <tr>
                                                    <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                                        class="style4">Daily Purchase Report
                                                    </th>
                                                </tr>


                                                <tr>
                                                    <asp:Label runat="server" ID="Label1" Visible="false"></asp:Label>
                                                </tr>
                                            </table>
                                            <table border="1" class="table" style="width: 100%; border-collapse: collapse">

                                                <tr style="background-color: White">
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>SL</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Date</strong>
                                                    </td>
                                                    
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>No of Purchase Vouchar(Local)</strong>
                                                    </td>

                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>No of Purchase Vouchar(Import)</strong>
                                                    </td>

                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Purchase Amount</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>VAT Amount</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong> SD Amount</strong>
                                                    </td>
                                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Total</strong>
                                                    </td>
                                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Action</strong>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <asp:Label runat="server" ID="lblPurchaseShow"></asp:Label>
                                                </tr>
                                            </table>

                                        </asp:Panel>
                                        <div id="PopupContainer" runat="server">
                                        </div>
                                        <div id="PopupContainerPurchase" runat="server">
                                        </div>
                                    </div>


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
