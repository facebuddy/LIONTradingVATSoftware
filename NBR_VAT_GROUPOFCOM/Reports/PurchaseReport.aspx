<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_PurchaseReport, App_Web_y1tsx4fu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/panel.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <style media="print">
        {
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
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Periodic Purchase Report
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top: 1%">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="dtpFromDate" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpFromDate" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="dtpToDate" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpToDate" />
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
                                                <asp:ListItem Value="-99">---Select---</asp:ListItem>
                                                <asp:ListItem Value="1">Regular Registered (VAT)</asp:ListItem>
                                                <asp:ListItem Value="4">Registered For Turnover</asp:ListItem>
                                                <asp:ListItem Value="5">Not Registered</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                       <%-- <div class="col-sm-2">
                                          
                                        </div>--%>
                                    </div>
                                </div>
                    </div>
                    <div  class="row">

                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Category :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="drpCategory" CssClass="form-control select2"    OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
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
                                <label class="col-sm-5 control-label text-right">Vendor/Supplier :</label>
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
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Purchase Type :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="purchase" AutoPostBack="true" OnSelectedIndexChanged="SelectedPurchaseType_Changed" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Tax Type :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="tax" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

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
                        <%--  <div class="col-md-4">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-sm" Style="float: right" Text="Search" OnClick="showBTN_Click" />
                        </div>--%>
            
                         <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                   <label class="col-sm-5 control-label">Major Area of Economic Activity :</label>
                                <div class="col-sm-7">
                                   <asp:DropDownList ID="drpTypeofBusiness" runat="server" ReadOnly="true" class="form-input select2" >
                                </asp:DropDownList>
                               
                                </div>
                            </div>
                        </div>
                          <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                   <label class="col-sm-5 control-label">Additional Property :</label>
                                <div class="col-sm-7">
                                   <asp:DropDownList ID="drpAdtnProp" runat="server"  class="form-input select2" >
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
                        <%-- <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                   <label class="col-sm-5 control-label">District :</label>
                                <div class="col-sm-7">
                                   <asp:DropDownList ID="DropDownList1" runat="server" ReadOnly="true" class="form-input" >
                                </asp:DropDownList>
                               
                                </div>
                            </div>
                        </div>--%>
                        <%--  <div class="col-md-4">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-sm" Style="float: right" Text="Search" OnClick="showBTN_Click" />
                        </div>--%>
                    </div>
                    <%--<div class="container-fluid row">
                        <div class="col-sm-2 col-sm-offset-5">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-sm" Text="Search" OnClick="showBTN_Click" />
                        </div>
                    </div>--%>
                  

                            <div class="col-md-12" style="text-align:right">
                               <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                              <asp:LinkButton ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" OnClick="btnExportToExcel_Click"><i class="fa fa-list"></i>  Excel</asp:LinkButton>
                             <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-success" OnClick="showBTN_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>   
                        </div>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>   

                    <div class="row" style="margin-top: 1%; overflow:auto;font-family:Nikosh;font-size:12px">
                        <asp:Panel ID="pnlContents" runat="server">

                            <div class="col-md-10">
                                <asp:Label Visible="false" runat="server" ID="purchaseTypelbl" Font-Bold="true"></asp:Label>

                                <asp:Label Visible="false" runat="server" ID="vendorlbl" Font-Bold="true"></asp:Label>

                                <asp:Label Visible="false" runat="server" ID="fromdatelbl" Font-Bold="true"></asp:Label>

                                <asp:Label Visible="false" runat="server" ID="todatelbl" Font-Bold="true"></asp:Label>
                            </div>

                            <table border="1" class="table" style="width: 100%; border-style: solid; border-width: 2px; border-collapse: collapse">
                                <tr>
                                    <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                        class="style4">Periodic Purchase Report
                                    </th>
                                </tr>


                                <tr>
                                    <asp:Label runat="server" ID="lblHeaderShow" Visible="false"></asp:Label>
                                </tr>
                            </table>


                            <table border="1"  class="table" style="width: 100%; border-style: solid; border-width: 2px; border-collapse: collapse">

                                <tr id="header1" visible="false" runat="server" style="background-color: White">
                                      <td class="style10" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                           <strong>Tax Type</strong>
                                       </td>
                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Voucher Date</strong>
                                    </td>

                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Vendor/Supplier Name</strong>
                                    </td>

                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Challan No</strong>
                                    </td>
                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Challan Date</strong>
                                    </td>
                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Item</strong>
                                    </td>
                                   <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>SKU :</strong>
                                    </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Quantity</strong>
                                    </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Unit</strong>
                                    </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Unit Price</strong>
                                    </td>

                                     <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>VAT</strong>
                                        </td>
                                        <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>SD</strong>
                                        </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>VDS</strong>
                                        </td>
                                        <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>AIT</strong>
                                        </td>


                                    <td class="style14" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Value</strong>
                                    </td>

                                    <td class="style14" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Value(consolidated)</strong>
                                    </td>

                                    <td class="style14" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Payment Method</strong>
                                    </td>



                                </tr>



                                <tr id="header2" visible="false" runat="server" style="background-color: White">
                                      <td class="style10" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                           <strong>Tax Type</strong>
                                       </td>
                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Voucher Date</strong>
                                    </td>

                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Vendor/Supplier Name</strong>
                                    </td>

                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Challan No</strong>
                                    </td>
                                    <td class="style10" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Challan Date</strong>
                                    </td>
                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Item</strong>
                                    </td>
                                      <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>SKU :</strong>
                                    </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Quantity</strong>
                                    </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Unit</strong>
                                    </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Unit Price</strong>
                                    </td>
                                    
                                     <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>VAT</strong>
                                        </td>
                                        <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>SD</strong>
                                        </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>VDS</strong>
                                        </td>
                                        <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>AIT</strong>
                                        </td>
                                      <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>Asses Value</strong>
                                        </td>
                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>CD</strong>
                                        </td>

                                    <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>RD</strong>
                                        </td>

                                        <td class="style11" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                            <strong>AT</strong>
                                        </td>


                                    <td class="style14" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Value</strong>
                                    </td>

                                    <td class="style14" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Value(consolidated)</strong>
                                    </td>

                                    <td class="style14" align="center" style="vertical-align: middle; width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Payment Method</strong>
                                    </td>

                                </tr>

                                <tr>
                                    <asp:Label runat="server" ID="lblleisureShow"></asp:Label>
                                </tr>
                            </table>


                         

                        </asp:Panel>

                    </div>
                    <asp:Button ID="btnPrint" CssClass="btn-btn" Style="background-color:#65C2DD; float: right" runat="server" Text="Print" OnClientClick="return PrintPanel();"
                        Width="64px" />
                </div>
                 <div id="PopupContainer" runat="server">
                      
                 </div>
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </div>
    </div>


</asp:Content>
