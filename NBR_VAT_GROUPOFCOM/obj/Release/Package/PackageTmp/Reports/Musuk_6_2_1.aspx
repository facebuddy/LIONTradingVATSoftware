
<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Musuk_6_2_1.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.Musuk_6_2_1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
        <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <style>
        .m {
            text-align: right;
            padding-right: 5px;
        }

        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;}
        table.allSolid td { border: 1.5px solid black;}

    </style>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
            var printWindow = window.open('', '', 'left=0,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            //printWindow.document.write('</head><body style="margin: 5px;">');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;} table.allSolid th { border: 1.5px solid black;}table.allSolid td { border: 1.5px solid black;}</style>');
            printWindow.document.write('</head><body style="margin:unset;font-size:smaller;">');
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

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px">ক্রয়-বিক্রয় হিসাব (মূসক-৬.২.১)</div>
                <div class="panel panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="control-label col-sm-5 text-right">পণ্যের নাম :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control select2">
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
                        </div>
                        <div class="col-md-12" style="text-align:right">
                            <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px;"></asp:TextBox>
                            <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="btnShow_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                            <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                        </div>
                    
                </div>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="precisionTxtBox" runat="server"
                                ErrorMessage="Precision has to be a number between 0 to 12"
                                ForeColor="Red"
                                ValidationExpression="\d+">
                            </asp:RegularExpressionValidator> 
            </div>
            <div id="print" class="container-fluid" style="padding:unset;font-family:Nikosh" runat="server" visible="true">
                <%--<div class="row">
                    <p style="text-align: center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                    <p style="text-align: center; margin-top: -1%;">জাতীয় রাজস্ব বোর্ড</p>     //commeneted to erase it from out of the form
                </div>--%>
                <div>
                    <%--<table class="table table-bordered" style="overflow-x: scroll; overflow-y: hidden; font-size:12px; text-align:center">--%>
                    <table class="allSolid" style="overflow-x: scroll; overflow-y: hidden; font-size:12px; text-align:center; border-collapse: collapse;">
                        <tr> 
                                                     

                            <th colspan="26" style="text-align: center; background-color: ##FFFFFF;font-size:16px">
                            
                                <p style="text-align: center"><sup>১</sup>[গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>   

                                <p style="text-align: center; ">জাতীয় রাজস্ব বোর্ড</p>

                                <%--<div style="width:120px;height:20px;float: right;">
                                    <p style="border: 1px solid #000; font-weight: bold">মূসক-৬.২.১</p>
                                </div>--%>

                                <p style="border: 1px solid #000; float: right; margin-right: 5px;font-weight: bold">&nbsp মূসক-৬.২.১ &nbsp</p>
                                
                                <%--<p style="border: 1px solid #000; float: right; margin-right: 15px;font-weight: bold">&nbsp&nbsp মূসক-৬.১ &nbsp&nbsp</p>--%>

                                <p style="text-align: center;padding-left:150px;">
                                    <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationName" />
                                </p>
                                <p style="text-align: center;padding-left:150px;">
                                    <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationAddress" />
                                </p>
                                <p style="text-align: center">
                                    <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationBIN" />
                                </p>
                                <p style="text-align: center">
                                    ক্রয়-বিক্রয় হিসাব
                                    <br />
                                  
                                  (পণ্য বা সেবা প্রক্রিয়াকরণে সম্পৃক্ত  এমন নিবন্ধিত বা তালিকাভুক্ত ব্যক্তির জন্য প্রযোজ্য)
<br />
                                    [বিধি ৪০ এর উপ-বিধি (১) এর দফা (খখ) এবং ৪১ এর দফা (ক) দ্রষ্টব্য]

                                </p>
                            </th>
                        </tr>
                        <tr>
                            <th rowspan="2" style="text-align: center; background-color: ##FFFFFF">ক্রমিক সংখ্যা
                            </th>
                            <th rowspan="2" style="text-align: center; background-color: ##FFFFFF">তারিখ
                            </th>
                                    <th colspan="2" style="text-align: center; background-color: ##FFFFFF">বিক্রয়যোগ্য পণ্যের প্রারম্ভিক জের
                            </th>
                            <th colspan="2" style="text-align: center; background-color: ##FFFFFF">ক্রয়
                            </th>
                            <th colspan="1" style="text-align: center; background-color: ##FFFFFF">মোট পণ্য
                            </th>
                            <th colspan="3" style="width: 30%; text-align: center; background-color: ##FFFFFF">বিক্রেতার তথ্য
                            </th>
                            <th colspan="2" style="text-align: center; background-color: ##FFFFFF">ক্রয় চালানপত্রের<br />
                                /বিল অব এন্ট্রির বিবরণ
                            </th>
                            <th colspan="5" style="text-align: center; background-color: ##FFFFFF">বিক্রিত/সরবরাহকৃত পণ্যের বিবরণ
                            </th>
                            <th colspan="3" style="text-align: center; background-color: ##FFFFFF">ক্রেতার তথ্য
                            </th>
                            <th colspan="2" style="text-align: center; background-color: ##FFFFFF">বিক্রয় চালানপত্রের বিবরণ
                            </th>
                            <th colspan="1" style="text-align: center; background-color: ##FFFFFF">পণ্যের প্রান্তিক জের
                            </th>
                            <th style="text-align: center; background-color: ##FFFFFF">মন্তব্য
                            </th>
                        </tr>
                        <tr style="font-size:12px">
                            <th rowspan="1" style="text-align: center; background-color: ##FFFFFF">বিবরণ</th>
                            <th rowspan="1" style="text-align: center; background-color: ##FFFFFF">পরিমাণ<br />
                                (একক)</th>
                            <%--<th rowspan="1" style="text-align: center; background-color: ##FFFFFF">মূল্য<br />
                                (সকল প্রকার কর ব্যতীত)</th>--%>
                            <th rowspan="1" style="text-align: center; background-color: ##FFFFFF">পরিমাণ<br />
                                (একক)</th>
                            <th rowspan="1" style="text-align: center; background-color: ##FFFFFF">মূল্য<br />
                                (সকল প্রকার কর ব্যতীত)</th>
                            <th rowspan="1" style="text-align: center; background-color: ##FFFFFF">পরিমাণ<br />
                                (একক)</th>
                          <%--  <th rowspan="1" style="text-align: center; background-color: ##FFFFFF">মূল্য<br />
                                (সকল প্রকার কর ব্যতীত)</th>--%>
                            <%--<th colspan="3" style="text-align: center; background-color: ##FFFFFF">&nbsp</th>--%>
                            <th style="text-align: center; background-color: ##FFFFFF">নাম</th>
                            <th style="width: 20%;text-align: center; background-color: ##FFFFFF">ঠিকানা</th>
                            <th style="text-align: center; background-color: ##FFFFFF">নিবন্ধন/তালিকাভুক্তি/জাতীয় পরিচয়পত্র নম্বর</th>
                            <th style="text-align: center; background-color: ##FFFFFF">নম্বর</th>
                            <th style="text-align: center; background-color: ##FFFFFF">তারিখ</th>
                            <th style="text-align: center; background-color: ##FFFFFF">বিবরণ</th>
                            <th style="text-align: center; background-color: ##FFFFFF">পরিমাণ (একক)</th>
                            <th style="text-align: center; background-color: ##FFFFFF">মূল্য
                                <br />
                                (সকল প্রকার কর ব্যতীত)</th>
                            <th style="text-align: center; background-color: ##FFFFFF">সম্পূরক শুল্ক<br />
                                (যদি থাকে)</th>
                            <th style="text-align: center; background-color: ##FFFFFF">মূসক</th>
                            <%--<th colspan="3" style="text-align: center; background-color: ##FFFFFF">&nbsp</th>--%>
                            <th style="text-align: center; background-color: ##FFFFFF">নাম</th>
                            <th style="width: 20%;text-align: center; background-color: ##FFFFFF">ঠিকানা</th>
                            <th style="text-align: center; background-color: ##FFFFFF">নিবন্ধন/তালিকাভুক্তি/জাতীয় পরিচয়পত্র নং</th>
                            <%--<th colspan="2" style="text-align: center; background-color: ##FFFFFF">&nbsp</th>--%>
                            <th style="text-align: center; background-color: ##FFFFFF">নম্বর</th>
                            <th style="text-align: center; background-color: ##FFFFFF">তারিখ</th>
                            <th style="text-align: center; background-color: ##FFFFFF">পরিমাণ(একক)</th>
                           <%-- <th style="text-align: center; background-color: ##FFFFFF">মূল্য<br />
                                (সকল প্রকার কর ব্যতীত)</th>--%>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                        </tr>
                        <%--<tr>
                            <th style="text-align: center; background-color: ##FFFFFF">নাম</th>
                            <th style="text-align: center; background-color: ##FFFFFF">ঠিকানা</th>
                            <th style="text-align: center; background-color: ##FFFFFF">নিবন্ধন/তালিকাভুক্তি/জাতীয় পরিচয়পত্র নং</th>
                            <th style="text-align: center; background-color: ##FFFFFF"></th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">নাম</th>
                            <th style="text-align: center; background-color: ##FFFFFF">ঠিকানা</th>
                            <th style="text-align: center; background-color: ##FFFFFF">নিবন্ধন/তালিকাভুক্তি/জাতীয় পরিচয়পত্র নং</th>
                            <th style="text-align: center; background-color: ##FFFFFF">নম্বর</th>
                            <th style="text-align: center; background-color: ##FFFFFF">তারিখ</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                            <th style="text-align: center; background-color: ##FFFFFF">&nbsp</th>
                        </tr>--%>
                        <tr>
                            <td style="text-align: center; background-color: ##FFFFFF">(১)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(২)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(৩)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(৪)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(৫)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(৬)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(৭)=(৪+৫)</td>
                           <%-- <td style="text-align: center; background-color: ##FFFFFF">(৮)=(৪+৬)</td>--%>
                            <td style="text-align: center; background-color: ##FFFFFF">(৮)
                            <td style="text-align: center; background-color: ##FFFFFF">(৯)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১০)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১১)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১২)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১৩)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১৪)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১৫)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১৬)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১৭)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১৮)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(১৯)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(২০)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(২১)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(২২)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(২৩)=(৭-১৪)</td>
                             <td style="text-align: center; background-color: ##FFFFFF">(২৪)
<%--                            <td style="text-align: center; background-color: ##FFFFFF">(২৪)=(৭-১৫)</td>--%>
                            <%--<td style="text-align: center; background-color: ##FFFFFF">(২৫)=(৮-১৬)</td>
                            <td style="text-align: center; background-color: ##FFFFFF">(২৬)</td>--%>
                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="lblReportView" />
                        </tr>
                        
                    </table>
                </div>
                 <div class="col-md-12" style="margin-top: 5px">
                     বিশেষ দ্রষ্টব্যঃ <br />
                     *যে ক্ষেত্রে অনিবন্ধিত ব্যক্তির নিকট পণ্য ক্রয় বা অনিবন্ধিত ব্যক্তির নিকট পণ্য বিক্রয় করা হইবে সেই ক্ষেত্রে উক্ত ব্যক্তির পূর্ণাঙ্গ নাম,ঠিকানা ও জাতীয় পরিচয়পত্র নম্বর যথাযথভাবে সংশ্লিষ্ট কলামে [(৮),(৯),(১০),(১৮),(১৯) ও (২০)] আবসশ্যিকভাবে উল্লেখ করিতে হইবে।
                     </div>
                <br />
                <br />
                <br />
                <br />
                <div class="col-md-3" style="margin-top: 5px;border-top:solid"></div>
                 <div class="col-md-12" style="margin-top: 5px;">
                     <sup>১</sup> এসআরও নং-১৭৯-আইন/২০২০/১৯৯-মূসক, তারিখঃ৩০ জুন,২০২০ দ্বারা প্রতিস্থাপিত।

                     </div>
                  <div class="col-md-12" style="margin-top: 5px">
                                            <div class="form-group form-group-sm">
                                                <asp:Label runat="server" Text="System User: "></asp:Label>
                                                <asp:Label runat="server" ID="lblUser"></asp:Label>
                                                <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                                <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                            </div>
                  </div>
                 <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
            </div>
              <asp:HiddenField ID="hiddenPrantikJerQty" runat="server" />
            <asp:HiddenField ID="hiddenPrantikJerValue" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
