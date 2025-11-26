<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="ReconciliationReport, App_Web_xijeoyc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
     <link href="../../Styles/panel.css" rel="stylesheet" />
      <script src="../../Scripts/jquery-1.4.4.min.js"></script>
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
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px">Reconciliation Report</div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                       <%-- <label class="control-label col-sm-5 text-right">উৎপাদিত পণ্যের নাম :</label>--%>
                                         <label class="col-sm-5 control-label text-right"><span class="required"> * </span>উৎপাদিত পণ্যের নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlProductItem" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date From :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateFrom" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date To :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateTo" />
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
                                    <%--<div class="row">
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
                                    </div>--%>
                                     <table style="width: 100%">
                                        <tr>
                                            <td style="width: 50%; font-weight: normal">প্রতিষ্ঠানের নাম:
                                                <asp:Label runat="server" ID="lblOrgName" Style="font-weight: normal" /></td>
                                            <td style="width: 49%; font-weight: normal">মাসের নাম:
                                                <asp:Label runat="server" ID="lblReportMonth" Style="font-weight: normal" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50%; font-weight: normal">প্রতিষ্ঠানের ঠিকানা:
                                                <asp:Label runat="server" ID="lblOrgAddress" Style="font-weight: normal" /></td>
                                            <td style="width: 49%; font-weight: normal">সন:
                                                <asp:Label runat="server" ID="lblReportYear" Style="font-weight: normal" /></td>
                                        </tr>
                                        <tr>
                                            <%--<td style="width: 50%; font-weight: normal">উৎপাদিত পণ্যের নাম:
                                                <asp:Label runat="server" ID="lblFProduct" Style="font-weight: normal" /></td>
                                            <td style="width: 49%; font-weight: normal">উৎপাদনের পরিমান :
                                                <asp:Label runat="server" ID="lblFProductQuantity" Style="font-weight: normal" />&nbsp&nbsp&nbsp&nbsp
                                                <asp:Label runat="server" ID="Label1" Style="font-weight: normal" Text="বিক্রয়ের পরিমান: " />
                                                 <asp:Label runat="server" ID="lblSaleQunt" Style="font-weight: normal"/>
                                            </td>--%>
                                            <caption>
                                                &nbsp;
                                            </caption>
                                        </tr>
                                    </table>
                                     <table border="1" class="table table-bordered" style="width: 100%;border-collapse:collapse;background-color: #fff;margin-top:15px" >
                                         <tr>
                                            <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                                class="style4">
                                                <asp:Label ID="lblItem" runat="server" />
                                                - উৎপাদনে ব্যবহৃত উপকরণসমূহ
                                            </th>
                                        </tr>
                                          <tr>
                                             <th style="text-align: center;font-weight: bold">ক্রমিক সংখ্যা</th>
                                             <th style="text-align: center;font-weight: bold">উৎপাদনে ব্যবহৃত উপকরণসমূহ</th>
                                             <th style="text-align: center;font-weight: bold">একক</th>
                                             <th style="text-align: center;font-weight: bold">প্রারম্ভিক জের</th>
                                             <th style="text-align: center;font-weight: bold">একক</th>
                                             <th style="text-align: center;font-weight: bold">একক পণ্য উৎপাদনে ব্যবহৃত উপকরণের পরিমান</th>
                                             <th style="text-align: center;font-weight: bold">(<asp:Label runat="server" ID="lblVatValid"/>) করমেয়াদে উৎপাদনে  ব্যবহৃত উপকরণের পরিমান</th>
                                            <%-- <th style="text-align: center;font-weight: bold">বিক্রয় পণ্যে ব্যবহৃত উপকরণের পরিমান</th>--%>
                                           <%--  <th style="text-align: center;font-weight: bold">সরাসরি বিক্রয়</th>--%><%-- 07-Sep-2019--%>
                                             <th style="text-align: center;font-weight: bold">প্রান্তিক জের</th>
                                             <th style="text-align: center;font-weight: bold">অপচয়ের পরিমান</th>
                                             <%--<th style="text-align: center;font-weight: bold">স্থিতি</th>--%><%-- 07-Sep-2019--%>
                                         </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblPurchaseBookRow" />
                                                <caption>
                                                    <hr />
                                                </caption>
                                            </tr>
                                    </table>
                                   <div style="text-align:center;font-weight:bold;">Finished Product Information</div>
                                     <table border="1" class="table table-bordered" style="width: 100%;border-collapse:collapse;background-color: #fff;margin-top:15px" >
                                         <tr>
                                             <th style="text-align: center;font-weight: bold">ক্রমিক সংখ্যা</th>
                                             <th style="text-align: center;font-weight: bold">তারিখ</th>
                                             <th style="text-align: center;font-weight: bold">উৎপাদিত পণ্যের প্রারম্ভিক জের</th>
                                             <th style="text-align: center;font-weight: bold">একক</th>
                                             <th style="text-align: center;font-weight: bold">করমেয়াদে উৎপাদিত পণ্যের পরিমান</th>
                                             <th style="text-align: center;font-weight: bold">মোট উৎপাদন</th>
                                             <th style="text-align: center;font-weight: bold">বিক্রয়ের পরিমাণ</th>
                                             <th style="text-align: center;font-weight: bold">প্রান্তিক জের</th>
                                         </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblFinishedProductInfo" />
                                            </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenClosing" runat="server" />
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
