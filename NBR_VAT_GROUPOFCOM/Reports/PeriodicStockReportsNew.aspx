<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="PeriodicStockReportsNew.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.PeriodicStockReportsNew" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/mqmm.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />

    <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="../../Styles/muktadir.css" rel="stylesheet" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=printPNL.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />');
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
    <script type="text/javascript">
        function showLoading() {
            // Display a loading message or spinner
            document.getElementById('loadingMessage').style.display = 'block';
        }
    </script>
    <style>
        /* CSS for the loading message */
        #loadingMessage {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: rgba(0, 0, 0, 0.7);
            color: white;
            padding: 2px 10px; /* Make the shape more rectangular */
            border-radius: 10px;
            z-index: 1000; /* Ensure it's on top */
            text-align: center;
        }

        /* CSS for the spinner */
        .spinner {
            border: 6px solid rgba(255, 255, 255, 0.3);
            border-top: 6px solid #3498db;
            border-radius: 50%;
            width: 30px;
            height: 30px;
            animation: spin 1s linear infinite;
            margin: 0 auto 1px auto; /* Center the spinner */
        }

        /* Animation for the spinner */
        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="loadingMessage">
                <div class="spinner"></div>
                Loading, please wait...
            </div>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">Periodic Stock Report</div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-5 text-right">Date From :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtFDate" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtTransferOrderDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFDate" />

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-5 text-right">Date To :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right"><span class="required">* </span>Item Type:</label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="drpProductType" runat="server" CssClass="form-control" Style="padding: 0px; height: 27px" OnSelectedIndexChanged="drpProductType_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="">--select--</asp:ListItem>
                                                        <asp:ListItem Value="R">Raw Material</asp:ListItem>
                                                        <asp:ListItem Value="F">Goods</asp:ListItem>
                                                        <asp:ListItem Value="P">Finished Product</asp:ListItem>
                                                        <asp:ListItem Value="C">Finished Product (Production)</asp:ListItem>
                                                        <asp:ListItem Value="W">Real-estate Property</asp:ListItem>
                                                        <asp:ListItem Value="M">Medicine</asp:ListItem>
                                                        <asp:ListItem Value="A">Asset</asp:ListItem>
                                                        <asp:ListItem Value="E">Spare Parts</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right"><span class="required">* </span>Item :</label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList runat="server" ID="drpItem" CssClass="form-control select2" Style="font-size: 11pt" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="drpBranch" CssClass="form-control select2"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-2 control-label text-right">Report Field :</label>
                                        <div class="col-sm-10">
                                            <asp:CheckBox runat="server" ID="chk1" Text="Opening Balance" />&nbsp
                                            <asp:CheckBox runat="server" ID="chk2" Text="Purchase" />&nbsp
                                             <asp:CheckBox runat="server" ID="chk3" Text="Production" />&nbsp
                                             <asp:CheckBox runat="server" ID="chk4" Text="Sale/Transfer" />&nbsp
                                             <asp:CheckBox runat="server" ID="chk5" Text="Closing Balance" />
                                            <asp:CheckBox runat="server" ID="chk6" Text="Weight wise Balance" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="row" style="margin-top: 10px; text-align: right">
                                    <div class="col-sm-12">
                                        <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" Style="width: 80px"></asp:TextBox>
                                        <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" OnClientClick="showLoading();" OnClick="btnSearch_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                                        <asp:LinkButton ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" OnClick="btnExportToExcel_Click"><i class="fa fa-list"></i>  Excel</asp:LinkButton>
                                        <%--<asp:LinkButton
                                            ID="LinkButtonTest" runat="server" CssClass="btn btn-success" OnClientClick="window.open('PdfViewer.aspx', '_blank'); return false;"><i class="fa fa-search-plus"></i> Generate
                                        </asp:LinkButton>--%>

                                        <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>


                                        <asp:TextBox class="col-sm-5 control-label text-right hiddencol" runat="server" ID="production"></asp:TextBox>
                                        <asp:TextBox class="col-sm-5 control-label text-right hiddencol" runat="server" ID="productionsd"></asp:TextBox>
                                        <asp:TextBox class="col-sm-5 control-label text-right hiddencol" runat="server" ID="productionVAT"></asp:TextBox>
                                    </div>
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
                    <div class="panel panel-primary" style="font-family: Nikosh">
                        <div class="panel panel-body">
                            <div class="col-md-12">
                                <div runat="server" id="printPNL">
                                    <div class="row">
                                        <div class="col-md-12 text-center">
                                            <label class="control-label text-center" style="font-size: 16px">Periodic Stock Report</label><br />
                                            <asp:Label runat="server" Font-Bold="true" class="control-label text-center" ID="orgId" Style="margin-top: 15px;"></asp:Label><br />
                                            <b>BIN:</b>
                                            <asp:Label runat="server" ID="OrgBin" /></label><br />
                                           <%-- <b>Branch Name:</b>
                                            <asp:Label runat="server" ID="OrgBranchName" /></label><br />
                                            <b>Branch Address:</b>
                                            <asp:Label runat="server" ID="OrgBranchAddress" /></label><br />--%>
                                            <b>Period:</b>
                                            <asp:Label runat="server" class="control-label text-center" ID="lblFromDate"></asp:Label>
                                            <b>To</b>
                                            <asp:Label runat="server" class="control-label text-center" ID="lblToDate"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <table border="1" class="allSolid" style="width: 100%; border-collapse: collapse; border: 1px solid #000000">
                                            <thead style="text-align: center; font-weight: bold">
                                                <tr>
                                                    <td rowspan="2">S/N</td>
                                                    <td rowspan="2">Item Name</td>
                                                    <td rowspan="2">Unit</td>
                                                    <td colspan="2" style="height: 35px;" id="col1" runat="server">Opening Balance</td>
                                                    <td colspan="4" id="col2" runat="server">Purchase</td>
                                                    <td colspan="4" id="col3" runat="server">Production</td>
                                                    <td colspan="4" id="col4" runat="server">Sale/Transfer/Dispose</td>
                                                    <td colspan="2" id="col5" runat="server">Closing Balance</td>
                                                    <td id="col6" runat="server">Weight-wise Balance</td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px;" id="col11" runat="server">Quantity</td>
                                                    <td id="col12" runat="server">Value</td>
                                                    <td id="col21" runat="server">Quantity</td>
                                                    <td id="col22" runat="server">Value</td>
                                                    <td id="col23" runat="server">Supplementary Duty</td>
                                                    <td id="col24" runat="server">VAT</td>
                                                    <td id="col31" runat="server">Quantity</td>
                                                    <td id="col32" runat="server">Value</td>
                                                    <%--<td>কর যোগ্য মূল্য</td>--%>
                                                    <td id="col33" runat="server">Supplementary Duty</td>
                                                    <td id="col34" runat="server">VAT</td>
                                                    <td id="col41" runat="server">Quantity</td>
                                                    <td id="col42" runat="server">Value</td>
                                                    <%--<td>কর যোগ্য মূল্য</td>--%>
                                                    <td id="col43" runat="server">Supplementary Duty</td>
                                                    <td id="col44" runat="server">VAT</td>
                                                    <td id="col51" runat="server">Quantity</td>
                                                    <td id="col52" runat="server">Value</td>
                                                    <td id="col53" runat="server">Quantity</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <asp:Label runat="server" ID="lblReportData"></asp:Label>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div id="PopupContainer" runat="server"></div>
            <div id="PopupContainer1" runat="server"></div>
            <asp:Button ID="btnHiddenForImport" runat="server" Style="display: none" />
         <%--   <uc1:MsgBox runat="server" ID="msgBox" />--%>
            <uc1:MsgBoxs runat="server" ID="msgBox" />

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>



