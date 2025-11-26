<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="rptMushok17KA, App_Web_pj2ymx2u" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%= print.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<style>');
            style = "text-decoration: none;"
            printWindow.document.write('</style>');
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">ক্রয় ও বিক্রয় হিসাব পুস্তক(মূসক-১৭ক)</div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">পণ্যের নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control" Enabled="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date From :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="dtpDateFrom" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date To :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="dtpDateTo" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="btnShow_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                                    <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel panel-body">
                            <div class="col-md-12">
                                <div runat="server" id="print">
                                    <div class="row">
                                        <p style="text-align: center">
                                            গণপ্রজাতন্ত্রী বাংলাদেশ সরকার

                                        </p>

                                        <p style="text-align: center">
                                            জাতীয় রাজস্ব বোর্ড, ঢাকা 
                                        </p>


                                        <p style="text-align: center">
                                            <strong>ক্রয় ও বিক্রয় হিসাব পুস্তক</strong>
                                        </p>
                                        <p style="text-align: center">
                                            [বিধি ৪(১৬) দ্রষ্টব্য]
                                        </p>

                                        <p style="border: 1px solid #000; float: right; margin-right: 15px">মূসক-১৭ক</p>


                                    </div>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 50%; font-weight: bold">প্রতিষ্ঠানের নাম:
                                                <asp:Label runat="server" ID="lblOrgName" Style="font-weight: normal" /></td>
                                            <td style="width: 49%; font-weight: bold">মাসের নাম:
                                                <asp:Label runat="server" ID="lblReportMonth" Style="font-weight: normal" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50%; font-weight: bold">প্রতিষ্ঠানের ঠিকানা:
                                                <asp:Label runat="server" ID="lblOrgAddress" Style="font-weight: normal" /></td>
                                            <td style="width: 49%; font-weight: bold">সন:
                                                <asp:Label runat="server" ID="lblReportYear" Style="font-weight: normal" /></td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="gvPurchaseSale" runat="server" AutoGenerateColumns="false" DataKeyNames="PChallanID, SChallanID"
                                        OnRowCommand="gvPurchaseSale_RowCommand" OnSelectedIndexChanged="gvPurchaseSale_SelectedIndexChanged" Width="100%">
                                        <Columns>
                                            <asp:BoundField HeaderText="ক্রমিক সংখ্যা" DataField="RowNo" />
                                            <asp:BoundField HeaderText="ক্রয়কৃত উপকরণের মূল্য" DataField="PurchaseAmount" />
                                            <asp:TemplateField HeaderText="ক্রয়ের তারিখ ও চালানের নং">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbPChallanNo" runat="server" CommandArgument='<%# Eval("PChallanID") %>' OnClick="lbPChallanNo_Click"><%# Eval("PurchaseDateChallan") %></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="সরবরাহকৃত পণ্যের/প্রদত্ত সেবার মূল্য" DataField="SaleAmount" />
                                            <asp:TemplateField HeaderText="সরবরাহের/প্রদানের তারিখ ও চালানপত্র নং">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbSChallanNo" runat="server" CommandArgument='<%# Eval("SChallanID") %>' OnClick="lbSChallanNo_Click"><%# Eval("SaleDateChallan") %></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="BurlyWood" Font-Bold="true" />
                                    </asp:GridView>
                                    <%-- <table border="1" class="table table-bordered" style="width: 100%;border-collapse:collapse;background-color: #fff;" >
                                            <tr>
                                                <th style="text-align: center;font-weight: bold">ক্রমিক সংখ্যা</th>
                                                <th style="text-align: center;font-weight: bold">ক্রয়কৃত উপকরণের মূল্য</th>
                                                <th style="text-align: center;font-weight: bold">ক্রয়ের তারিখ ও চালানের নং</th>
                                                <th style="text-align: center;font-weight: bold">সরবরাহকৃত পণ্যের/প্রদত্ত সেবার মূল্য</th>
                                                <th style="text-align: center;font-weight: bold">সরবরাহের/প্রদানের তারিখ ও চালানপত্র নং</th>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;font-weight: bold">(১)</td>
                                                <td style="text-align: center;font-weight: bold">(২)</td>
                                                <td style="text-align: center;font-weight: bold">(৩)</td>
                                                <td style="text-align: center;font-weight: bold">(৪)</td>
                                                <td style="text-align: center;font-weight: bold">(৫)</td>
                                            </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblPurchaseBookRow" />
                                            </tr>
                                    </table>--%>
                                    <div class="row">
                                        <div class="col-md-12" style="margin-top: 5px">
                                            <div class="form-group form-group-sm">
                                                <asp:Label runat="server" Text="System User: "></asp:Label>
                                                <asp:Label runat="server" ID="lblUser"></asp:Label>
                                                <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                                <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary" runat="server" visible="false" id="detailid">
                        <div class="panel panel-heading text-center">
                            <asp:Label runat="server" ID="lblGrideading"></asp:Label>
                        </div>
                        <div class="panel panel-body">
                            <div class="col-md-12">
                                <asp:GridView runat="server" ID="gvPurchaseOrSale" CssClass="mydatagrid" AutoGenerateColumns="false" Width="100%"
                                    DataKeyNames="challan_id" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager">
                                    <Columns>
                                        <asp:BoundField HeaderText="Item" DataField="item_name" />
                                        <asp:BoundField HeaderText="Unit" DataField="unit_code" />
                                        <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                                        <asp:BoundField HeaderText="Unit Price" DataField="unit_price" />
                                        <asp:BoundField HeaderText="Total Price" DataField="total_price" />
                                        <asp:BoundField HeaderText="Vat" DataField="vat" />
                                        <asp:BoundField HeaderText="SD" DataField="sd" />
                                        <asp:BoundField HeaderText="Grand Total" DataField="grand_total" />
                                        <asp:BoundField HeaderText="Challan Date" DataField="date_challan" DataFormatString="{0:dd/MM/yyyy}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
