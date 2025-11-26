<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="SaleReportsNew.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.SaleReportsNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/muktadir.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <link href="../../Styles/mqmm.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <style media="print">
        .hiddencol {
            display: none;
        }

        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            tr, td {
            }

            .full_width {
                width: 100%;
            }
        }

        .yesPrint {
            display: block !important;
        }

        input[type=text], select, textarea, .text_box {
            border: none;
        }
    </style>
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
        0% { transform: rotate(0deg); }
        100% { transform: rotate(360deg); }
    }
</style>
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
    <div id="loadingMessage">
    <div class="spinner"></div>
    Loading, please wait...
</div>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Periodic Sale Report
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top: 1%">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="dtpFromDate" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpFromDate" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="dtpToDate" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpToDate" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Sale Type :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="drpSaleType" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Category :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="drpCategory" CssClass="form-control select2" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Sub Category :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="drpSubCategory" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Item :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlItem" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Item Category Type :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="drpItemCategory" AutoPostBack="true" OnSelectedIndexChanged="SelectedItemCategoryType_Changed" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Customer :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlSupplier" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Agreement No :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlAggrementNo" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">VAT Rate :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="txtVATRate" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                        runat="server" Enabled="True" TargetControlID="txtVATRate"
                                        ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">SD Rate :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="txtSDRate" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                        runat="server" Enabled="True" TargetControlID="txtSDRate"
                                        ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <%-- <label class="col-sm-5 control-label text-right">Registration Type :</label>--%>
                                <label class="col-sm-5 control-label text-right">Registration Type :</label>
                                <asp:Label runat="server" ID="Label5" Visible="false" Text="false" />
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpRegType" runat="server" CssClass="form-control select2">
                                        <asp:ListItem Value="-99">-- SELECT --</asp:ListItem>
                                        <asp:ListItem Value="1">Regular Registered (VAT)</asp:ListItem>
                                        <asp:ListItem Value="4">Registered For Turnover</asp:ListItem>
                                        <asp:ListItem Value="5">Not Registered</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Additional Property :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpProperty" runat="server" ReadOnly="true" AutoPostBack="true" OnSelectedIndexChanged="PropertyItem_SelectedIndexChanged" class="form-input select2">
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Major Area of Economic Activity :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpTypeofBusiness" runat="server" ReadOnly="true" class="form-input select2">
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">SKU :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlSKU" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Property :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="Property" runat="server" ReadOnly="true" class="form-input select2">
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Branch Name :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="drpBranch" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                   <label class="col-sm-5 control-label">District :</label>
                                <div class="col-sm-7">
                                   <asp:DropDownList ID="DropDownList1" runat="server" ReadOnly="true" class="form-input">
                                </asp:DropDownList>
                               
                                </div>
                            </div>
                        </div>--%>
                </div>
                <div class="col-md-12" style="text-align: right">
                    <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" Style="width: 80px"></asp:TextBox>
                    <asp:LinkButton ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" OnClick="btnExportToExcel_Click"><i class="fa fa-list"></i>  Excel</asp:LinkButton>
                    <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-success" OnClientClick="showLoading();" OnClick="showBTN_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>

                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    ControlToValidate="precisionTxtBox" runat="server"
                    ErrorMessage="Precision has to be a number between 0 to 12"
                    ForeColor="Red"
                    ValidationExpression="\d+">
                </asp:RegularExpressionValidator>

            </div>
            <div class="panel panel-primary" style="font-family: Nikosh">
                <div class="panel panel-body">
                    <div runat="server" id="pnlContents">
                        <div class="row">
                            <div class="col-md-12 text-center" style="text-align:center">
                                <label class="control-label text-center" style="font-size: 10px">Periodic Sale Report</label><br />
                                <asp:Label runat="server" Font-Bold="true" class="control-label text-center" ID="orgId" Style="margin-top: 15px;"></asp:Label><br />
                                <b>BIN:</b>
                                <asp:Label runat="server" ID="OrgBin" /><br />
                              
                                <b>Period:</b>
                                <asp:Label runat="server" class="control-label text-center" ID="lblFromDate"></asp:Label>
                                <b>To</b>
                                <asp:Label runat="server" class="control-label text-center" ID="lblToDate"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <table border="1" style="width: 100%; border-collapse: collapse;font-size: 12px"; border: 1px solid #000000">
                                    <thead style="text-align: center; font-weight: bold">
                                        <tr>
                                            <td>Voucher Date</td>
                                            <td>Party Name</td>
                                            <td>Challan No</td>
                                            <td>Agreement No</td>
                                            <td>Item</td>
                                            <td>SKU</td>
                                            <td>Quantity</td>
                                            <td>Unit Price</td>
                                            <td>VAT</td>
                                            <td>SD</td>
                                            <td>Value</td>
                                            <td>Value(consolidated)</td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <asp:Label runat="server" ID="lblleisureShow"></asp:Label>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <asp:Button ID="btnPrint" CssClass="btn-btn" Style="background-color: #65C2DD; float: right" runat="server" Text="Print" OnClientClick="return PrintPanel();"
                Width="64px" />
            <%--  </div>--%>
        </div>
 
    </div>



</asp:Content>

