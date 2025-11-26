<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Purchase_Account_Book_Form16_N, App_Web_xijeoyc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />

    <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <style>
        @page {
            size: auto;
            margin: 5mm;
        }
    </style>

    <style>
        table.allSolid {
            border: 1.5px solid black;
        }

            table.allSolid th {
                border: 1.5px solid black;
            }

            table.allSolid td {
                border: 1.5px solid black;
            }
    </style>




    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
                     var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
                     printWindow.document.write('<html><head><title></title>');
                     printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
                     printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
                     printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;}table.allSolid td { border: 1.5px solid black;}</style>');
                     printWindow.document.write('</head><body style="margin: 50px;font-size:smaller;">');
                     printWindow.document.write(panel.innerHTML);
                     printWindow.document.write('</body></html>');
                     printWindow.document.close();
                     setTimeout(function () {
                         printWindow.print();
                     }, 500);
                     return false;
                 }
    </script >
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <%--<div class="panel-heading" style="text-align: center; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">ক্রয় হিসাব পুস্তক (মূসক-১৬)</div>--%>
                        <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">ক্রয় হিসাব পুস্তক (মূসক-৬.১)</div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <%--zahid 01-08-22--%>
                                        <div class="col-md-6">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right">পণ্যের ধরন:</label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="Purchase16_drpProductType" runat="server" CssClass="form-control select2" OnSelectedIndexChanged="drpProductType_SelectedIndexChanged" AutoPostBack="true">


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
                                        <div class="col-md-6">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-5 text-right">পণ্যের নাম :</label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control select2">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

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
                            </div>
                            <div class="row">
                                <div class="col-md-12" style="text-align: right; margin-top: 10px">
                                    <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" Style="width: 80px"></asp:TextBox>
                                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="btnShow_OnClick"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                                    <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                                    <asp:LinkButton ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" OnClick="btnExportToExcel_Click"><i class="fa fa-list"></i>  Excel</asp:LinkButton>
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
                    <div class="panel panel-primary" style="font-family: Nikosh">
                        <div class="panel panel-body">
                            <div class="col-md-12">
                                <div runat="server" id="print">
                                    <%--<div class="row" style="font-size:16px">--%>
                                    <div class="row" style="font-size: 16px">
                                        <p style="text-align: center">
                                            গণপ্রজাতন্ত্রী বাংলাদেশ সরকার

                                        </p>

                                        <p style="text-align: center">
                                            জাতীয় রাজস্ব বোর্ড 
                                        </p>
                                        <p style="text-align: center">
                                            <asp:Label Style="font-weight: bold; font-size: larger;" runat="server" ID="TaxOrganizationName" />
                                        </p>
                                        <p style="text-align: center">
                                            <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationAddress" />
                                        </p>
                                        <p style="text-align: center">
                                            <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationBIN" />
                                        </p>
                                        <br />
                                        <p style="text-align: center">
                                            <strong>ক্রয় হিসাব পুস্তক </strong>
                                        </p>
                                        <p style="text-align: center">
                                            <strong>(পণ্য বা সেবা প্রক্রিয়াকরণে সম্পৃক্ত এমন নিবন্ধিত বা তালিকাভুক্ত ব্যক্তির জন্য প্রযোজ্য) </strong>
                                        </p>
                                        <%-- <p style="text-align: center">
                                            [বিধি 22(১) দ্রষ্টব্য]
                                        </p>--%>
                                        <p style="text-align: center">
                                            [বিধি ৪০ (১) এর দফা (ক) এবং ৪১ এর দফা (ক) দ্রষ্টব্য]
                                        </p>

                                        <%--<p style="border: 1px solid #000; float: right; margin-right: 15px">মূসক-১৬</p>--%>
                                        <p style="border: 1px solid #000; float: right; margin-right: 15px; font-weight: bold">&nbsp&nbsp মূসক-৬.১ &nbsp&nbsp</p>
                                    </div>

                                    <%--<div style="font-size:12px">--%>
                                    <div style="font-size: 12px">
                                        <%--<table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse">--%>
                                        <table border="1" class="allSolid" style="width: 100%; border-collapse: collapse">
                                            <thead>
                                                <tr style="border: 1px solid #000">
                                                    <td colspan="21" style="font-weight: normal">
                                                        <center>
                                                        <h4 style="font-weight: bold">
                                                            পণ্য/ সেবার উপকরণ ক্রয়</h4>
                                                    </center>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th rowspan="3" class="col_3_percent" style="font-weight: bold; text-align: center;">ক্রমিক সংখ্যা</th>
                                                    <th rowspan="3" class="col_3_percent" style="font-weight: bold; text-align: center;">তারিখ</th>
                                                    <th colspan="2" style="font-weight: bold; text-align: center;">মজুদ উপকরণের প্রারম্ভিক  জের</th>
                                                    <th colspan="14" style="text-align: center; font-weight: bold;">ক্রয়কৃত উপকরণ</th>
                                                    <%--<th colspan="2" rowspan="2" class="col_10_percent" style="font-weight: normal">পণ্য প্রস্তুতকরণ / উৎপাদনে ব্যবহার (ব্যবসায়ীদের ক্ষেত্রে পণ্য বিক্রয়)</th>--%>
                                                    <%--<th colspan="2" rowspan="2" style="font-weight: normal">উপকরণের প্রান্তিক জের</th>--%>
                                                    <th colspan="2" style="font-weight: bold; text-align: center;">উপকরণের প্রান্তিক জের</th>
                                                    <th rowspan="3" style="font-weight: bold; text-align: center;">মন্তব্য</th>

                                                </tr>
                                                <tr>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">পরিমাণ (একক)</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">মূল্য (সকল প্রকার কর ব্যতীত)</th>
                                                    <th class="col_5_percent" style="text-align: center; font-weight: bold" rowspan="2">চালানপত্র / বিল অব এন্ট্রি নম্বর</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">তারিখ</th>
                                                    <th colspan="3" class="col_15_percent" style="text-align: center; font-weight: bold">বিক্রেতা/সরবরাহকারী</th>

                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">বিবরণ</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">পরিমাণ</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">মূল্য (সকল প্রকার কর ব্যতীত)</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">সম্পূরক শুল্ক (যদি থাকে)</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">মূসক</th>
                                                    <th colspan="2" class="col_10_percent" style="text-align: center; font-weight: bold">মোট উপকরণের পরিমাণ</th>
                                                    <th colspan="2" class="col_10_percent" style="text-align: center; font-weight: bold">পণ্য প্রস্তুতকরণ / উৎপাদনে ব্যবহার</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">পরিমাণ</th>
                                                    <th class="col_3_percent" style="text-align: center; font-weight: bold" rowspan="2">মূল্য (সকল প্রকার কর ব্যতীত)</th>




                                                </tr>
                                                <tr>
                                                    <th style="text-align: center; font-weight: bold">নাম</th>
                                                    <th style="text-align: center; font-weight: bold">ঠিকানা</th>
                                                    <th style="text-align: center; font-weight: bold">নিবন্ধন /তালিকাভুক্তি/ জাতীয় পরিচয়পত্র নং</th>
                                                    <th style="text-align: center; font-weight: bold">পরিমাণ</th>
                                                    <th style="text-align: center; font-weight: bold">মূল্য</th>
                                                    <th style="text-align: center; font-weight: bold">পরিমাণ (একক)</th>
                                                    <th style="text-align: center; font-weight: bold">মূল্য (সকল প্রকার কর ব্যতীত)</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: center; font-weight: bold">(১)</td>
                                                    <td style="text-align: center; font-weight: bold">(২)</td>
                                                    <td style="text-align: center; font-weight: bold">(৩)</td>
                                                    <td style="text-align: center; font-weight: bold">(৪)</td>
                                                    <td style="text-align: center; font-weight: bold">(৫)</td>
                                                    <td style="text-align: center; font-weight: bold">(৬)</td>
                                                    <td style="text-align: center; font-weight: bold">(৭)</td>
                                                    <td style="text-align: center; font-weight: bold">(৮)</td>
                                                    <td style="text-align: center; font-weight: bold">(৯)</td>
                                                    <td style="text-align: center; font-weight: bold">(১০)</td>
                                                    <td style="text-align: center; font-weight: bold">(১১)</td>
                                                    <td style="text-align: center; font-weight: bold">(১২)</td>
                                                    <td style="text-align: center; font-weight: bold">(১৩)</td>
                                                    <td style="text-align: center; font-weight: bold">(১৪)</td>
                                                    <td style="text-align: center; font-weight: bold">(১৫)</td>
                                                    <td style="text-align: center; font-weight: bold">(১৬)</td>
                                                    <td style="text-align: center; font-weight: bold">(১৭)</td>
                                                    <td style="text-align: center; font-weight: bold">(১৮)</td>
                                                    <td style="text-align: center; font-weight: bold">(১৯)</td>
                                                    <td style="text-align: center; font-weight: bold">(২০)</td>
                                                    <td style="text-align: center; font-weight: bold">(২১)</td>
                                                </tr>
                                                <tr>
                                                    <asp:Label runat="server" ID="lblPurchaseBookRow" />
                                                </tr>
                                            </tbody>
                                        </table>
                                        <div class="row">
                                            <div class="col-md-12">

                                                <%--<div class="form-group form-group-sm">
                                                <h5>বিশেষ  দ্রস্টব্যঃ</h5>
                                                <label class="control-label">১. অর্থনৈতিক কার্যক্রম সংশ্লিষ্ট সকল প্রকার ক্রয়ের তথ এই ফরমে অন্তর্ভুক্ত করিতে হইবে।</label><br />
                                                <label class="control-label">২. যে ক্ষেত্রে  অনিবন্ধিত ব্যক্তির নিকট হইতে পণ্য ক্রয় করা হইবে সে ক্ষেত্রে উক্ত ব্যক্তির পূর্ণাঙ্গ নাম ঠিকানা ও  জাতীয়পরিচয়পত্র নম্বর
                                                    যথাযথভাবে সংশ্লিষ্ট কলাম [(৭),(৮) ও(৯)] এ আবশিক্যভাবে উল্লেখ করতে হবে|
                                                </label><br />
                                                <label class="control-label">৩. উপকরণ ক্রয়ের স্বপক্ষে প্রামানিক দলিল হিসাবে বিল অব এন্ট্রি বা চালানপত্রের  কপি সংরক্ষণ করিতে হইবে।</label>
                                            </div>--%>

                                                <div class="form-group form-group-sm">
                                                    <h6>বিশেষ  দ্রস্টব্যঃ</h6>
                                                    <h6>১. অর্থনৈতিক কার্যক্রম সংশ্লিষ্ট সকল প্রকার ক্রয়ের তথ এই ফরমে অন্তর্ভুক্ত করিতে হইবে।</h6>
                                                    <h6>২. যে ক্ষেত্রে  অনিবন্ধিত ব্যক্তির নিকট হইতে পণ্য ক্রয় করা হইবে সে ক্ষেত্রে উক্ত ব্যক্তির পূর্ণাঙ্গ নাম ঠিকানা ও  জাতীয়পরিচয়পত্র নম্বর
                                                    যথাযথভাবে সংশ্লিষ্ট কলাম [(৭),(৮) ও(৯)] এ আবশিক্যভাবে উল্লেখ করতে হবে|
                                                    </h6>
                                                    <h6>৩. উপকরণ ক্রয়ের স্বপক্ষে প্রামানিক দলিল হিসাবে বিল অব এন্ট্রি বা চালানপত্রের  কপি সংরক্ষণ করিতে হইবে।</h6>
                                                </div>

                                            </div>
                                            <div class="col-md-12" style="margin-top: 2px">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label runat="server" Text="System User: "></asp:Label>
                                                    <asp:Label runat="server" ID="lblUser"></asp:Label>
                                                    <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                                    <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                                </div>
                                            </div>
                                            <div style="text-align: right; font-size: 11px;">
                                                System Generated (KGCVAT)
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>





        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
