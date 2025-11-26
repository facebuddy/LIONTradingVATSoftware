<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="ProductionNSalesStatements.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Audit.ProductionNSalesStatements" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
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
    <div class="container-fluid">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">উৎপাদন ও বিক্রয় বিবরণী (মূসক-৬.২ রেজিস্টার মোতাবেক)</div>
                <div class="panel-body" style="padding-bottom: 0px">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="fromDate" CssClass="form-control" DateFormat="dd/MM/yyyy" MaxLength="10" placeholder="DD/MM/YYYY" />
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="fromDate" />
                                    <asp:Label ID="lblfromDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="toDate" CssClass="form-control" DateFormat="dd/MM/yyyy" MaxLength="10" placeholder="DD/MM/YYYY" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="toDate" />
                                    <asp:Label ID="lblToDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <%-- <div class="col-md-3">
                      <div class="form-group form-group-sm">
                          <label class="col-sm-5 control-label">Finish Product :</label>
                          <div class="col-sm-7">
                              <asp:DropDownList runat="server" ID="drpIngredient" CssClass="form-control" />
                          </div>
                      </div>

                  </div>--%>
                        <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                  <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                                <asp:Button runat="server" ID="btnSearch"  CssClass="btn-btn" Style="background-color: #3B7CB5;float: right" Text="Search" OnClick="btnSearch_OnClick" />
                            </div>

                        </div>
                        <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning btn-sm" OnClientClick="return PrintPanel();" Visible="false" />
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
        </div>
        <div runat="server" id="print" style="font-family:Nikosh">
            <div class="col-md-12">
                <div class="form-group form-group-sm">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <center>
                         <asp:Label runat="server" class="control-label" style="font-size:16px; font-weight:bold">উৎপাদন ও বিক্রয় বিবরণী (মূসক-৬.২ রেজিস্টার মোতাবেক)</asp:Label>
                     </center>

                    </div>
                    <div class="col-sm-4"></div>
                </div>
            </div>
            <div style="font-size:12px">
            <div class="col-md-12">
                <div class="form-group form-group-sm">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <center>
                      <asp:Label runat="server" ID="lfDate" class="control-label" style="font-size:16px"/>&nbsp&nbsp<asp:Label runat="server" class="control-label" Text="হতে  "/><asp:Label runat="server" ID="ltDate" class="control-label" style="font-size:16px"/>&nbsp&nbsp<asp:Label runat="server" class="control-label" Text="  পর্যন্ত "/>  
                      </center>
                    </div>
                    <div class="col-sm-4"></div>
                </div>

            </div>
            <div class="col-md-12">
                <div class="form-group form-group-sm">
                    <div class="table-responsive">
                        <table class="table" border="1" style="background: none; border-collapse: collapse;width:100%">
                            <thead>
                                <tr>
                                    <th rowspan="2" style="text-align: center">পণ্যের নাম</th>
                                    <th colspan="2" style="text-align: center">প্রারম্ভিক জের</th>
                                    <th colspan="2" style="text-align: center">উৎপাদন</th>
                                    <th colspan="2" style="text-align: center">মোট পরিমাণ</th>
                                    <th colspan="2" style="text-align: center">সরবরাহ</th>
                                    <th colspan="2" style="text-align: center">সমাপনী জের</th>
                                </tr>
                                <tr>
                                    <th style="text-align: center">পরিমাণ</th>
                                    <th style="text-align: center">মূল্য</th>
                                    <th style="text-align: center">পরিমাণ</th>
                                    <th style="text-align: center">মূল্য</th>
                                    <th style="text-align: center">পরিমাণ</th>
                                    <th style="text-align: center">মূল্য</th>
                                    <th style="text-align: center">পরিমাণ</th>
                                    <th style="text-align: center">মূল্য</th>
                                    <th style="text-align: center">পরিমাণ</th>
                                    <th style="text-align: center">মূল্য</th>
                                </tr>

                            </thead>
                            <tbody>
                                <tr>
                                    <td style="text-align: center">(১)</td>
                                    <td style="text-align: center">(২)</td>
                                    <td style="text-align: center">(৩)</td>
                                    <td style="text-align: center">(৪)</td>
                                    <td style="text-align: center">(৫)</td>
                                    <td style="text-align: center">(৬)</td>
                                    <td style="text-align: center">(৭)</td>
                                    <td style="text-align: center">(৮)</td>
                                    <td style="text-align: center">(৯)</td>
                                    <td style="text-align: center">(১০)</td>
                                    <td style="text-align: center">(১১)</td>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="lblReportHtml" />
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <table style="border: none; width: 100%">
                    <tr>
                        <td style="float: left">উপর্যুক্ত তথ্য ও উপাত্ত সঠিক ও নির্ভুল</td>
                        <td style="float: right">ক্ষমতাপ্রাপ্ত কর্মকর্তার স্বাক্ষর, নাম ও পদবীসহ সিল</td>
                    </tr>
                </table>
            </div>
            <div class="col-md-12" style="margin-top: 25px">
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
    <%-- <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="test-btn-primary" style="float:right" onclientclick="return PrintPanel();" Visible="false" />--%>
  <%--  <uc2:MsgBox ID="msgBox" runat="server" />--%>
    <uc1:MsgBoxs runat="server" ID="msgBox" />
</asp:Content>




