<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="PeriodicStockReports.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.PeriodicStockReports" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
  
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
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                            Periodic Stock Report
                        </div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                            <div class="row" style="margin-top: 0.75%">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">From Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtFDate" CssClass="form-control" Style="font-size: 11pt" />
                                            <cc1:CalendarExtender ID="txtTransferOrderDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFDate"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">To Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control" Style="font-size: 11pt" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Item Type:</label>
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
                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Item :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="drpItem" CssClass="form-control select2" Style="font-size: 11pt" />

                                        </div>
                                    </div>
                                </div>
                               
                            </div>
                             <div class="row" style="margin-top:10px">
                                  <div class="col-md-1">
                                     
                                      </div>
                                 <div class="col-md-7">
                                      <label>Report Field:</label>
                                      <asp:CheckBox runat="server" ID="chk1" Text="Opening Balance" />&nbsp
                                      <asp:CheckBox runat="server" ID="chk2" Text="Purchase"/>&nbsp
                                     <asp:CheckBox runat="server" ID="chk3" Text="Production"/>&nbsp
                                     <asp:CheckBox runat="server" ID="chk4" Text="Sale/Transfer"/>&nbsp
                                     <asp:CheckBox runat="server" ID="chk5" Text="Closing Balance"/>
                                      <asp:CheckBox runat="server" ID="chk6" Text="Weight wise Balance"/>
                                 </div>
                                    </div>
                              <div class="row" style="margin-top:10px;text-align:right">
                            <div class="col-sm-12">
                     
                            <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>  
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" OnClick="btnSearch_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>                                   
                            <asp:LinkButton ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" OnClick="btnExportToExcel_Click"><i class="fa fa-list"></i>  Excel</asp:LinkButton>
                           <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                       
                               
                      <asp:TextBox class="col-sm-5 control-label text-right hiddencol" runat="server" id="production"></asp:TextBox>    
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
                    <div class="panel panel-primary" style="font-family:Nikosh">
                        <div class="panel panel-body">
                            <div runat="server" id="printPNL">
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <label class="control-label text-center" style="font-size:16px">Periodic Stock Report</label><br />
                                          <asp:Label runat="server" class="control-label text-center" ID="orgId" style="margin-top:15px;"></asp:Label><br />
                                    </div>
                                    <div class="col-md-6 text-right" style="margin-top:15px;">
                                        <asp:Label runat="server" class="control-label text-center" Text="From Date :"></asp:Label>
                                        <asp:Label runat="server" class="control-label text-center" ID="lblFromDate"></asp:Label>
                                    </div>
                                    <div class="col-md-6" style="margin-top:15px;">
                                        <asp:Label runat="server" class="control-label text-center" Text="To Date :"></asp:Label>
                                        <asp:Label runat="server" class="control-label text-center" ID="lblToDate"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <table border="1" style="width: 100%; border-collapse: collapse; border: 1px solid #000000">
                                            <thead style="text-align: center; font-weight: bold">
                                                 <tr>
                                                    <td rowspan="2">ক্র:নং</td>
                                                    <td rowspan="2">উপকরণের নাম</td>
                                                    <td rowspan="2">একক</td>
                                                    <td colspan="2" style="height: 35px;" id="col1" runat="server">মজুদ উপকরণের প্রারম্ভিক জের</td>
                                                    <td colspan="4" id="col2" runat="server">ক্রয় হিসাব </td>                                                   
                                                    <td colspan="4" id="col3" runat="server">উৎপাদন হিসাব</td>
                                                     <td colspan="4" id="col4" runat="server">বিক্রয় হিসাব/স্থানান্তর </td>
                                                    <td colspan="2" id="col5" runat="server">প্রান্তিক জের</td>
                                                    <td  id="col6" runat="server">প্রান্তিক জের</td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px;" id="col11" runat="server">পরিমাণ</td>
                                                    <td id="col12" runat="server">মূল্য</td>
                                                    <td id="col21" runat="server">পরিমাণ</td>
                                                    <td id="col22" runat="server">মূল্য</td>
                                                    <td id="col23" runat="server">সম্পূরক শুল্ক</td>
                                                    <td id="col24" runat="server">মূসক</td>
                                                    <td id="col31" runat="server">পরিমাণ</td>
                                                    <td id="col32" runat="server">মূল্য</td>
                                                    <%--<td>কর যোগ্য মূল্য</td>--%>
                                                    <td id="col33" runat="server">সম্পূরক শুল্ক</td>
                                                    <td id="col34" runat="server">মূসক</td>
                                                    <td id="col41" runat="server">পরিমাণ</td>
                                                    <td id="col42" runat="server">মূল্য</td>
                                                    <%--<td>কর যোগ্য মূল্য</td>--%>
                                                    <td id="col43" runat="server">সম্পূরক শুল্ক</td>
                                                    <td id="col44" runat="server">মূসক</td>
                                                    <td id="col51" runat="server">পরিমাণ</td>
                                                    <td id="col52" runat="server">মূল্য</td>
                                                      <td id="col53" runat="server">পরিমাণ</td>
                                                   
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
               
                

                <div id="PopupContainer" runat="server"></div>
                 <div id="PopupContainer1" runat="server"></div>
                <asp:Button ID="btnHiddenForImport" runat="server" Style="display: none" />
                <%--<ajaxToolkit:ModalPopupExtender ID="modalPopupForImportDetail" runat="server" PopupControlID="pnImportDetail"
                    TargetControlID="btnHiddenForImport" BackgroundCssClass="mpBack">
                </ajaxToolkit:ModalPopupExtender>--%>
             <%--   <uc2:MsgBox runat="server" ID="msgBox" />--%>
                <uc1:MsgBoxs runat="server" id="msgBox" />
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>


