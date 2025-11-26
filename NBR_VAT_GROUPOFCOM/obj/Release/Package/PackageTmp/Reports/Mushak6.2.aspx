<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Mushak6.2.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.Mushak6__2" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=printReport.ClientID %>");
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
    </script>


    <style>
    
        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;}
        table.allSolid td { border: 1.5px solid black;}

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <%--<div class="panel-heading" style="text-align: center; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">বিক্রয় হিসাব পুস্তক (মূসক-১৭)</div>--%>
                        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px">বিক্রয় হিসাব পুস্তক (মূসক-৬.২)</div>

                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right">পণ্যের ধরন:</label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="Purchase17_drpProductType" runat="server" CssClass="form-control select2" OnSelectedIndexChanged="drpProductType_SelectedIndexChanged" AutoPostBack="true">


                                                        <asp:ListItem Value="F">Goods</asp:ListItem>
                                                        <asp:ListItem Value="P">Finished Product</asp:ListItem>
                                                        <asp:ListItem Value="R">Raw Material</asp:ListItem>
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
                                <div class="col-md-12" style="text-align:right;margin-top:10px">
                                     <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox> 
                                     <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="showReport_OnClick"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
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
                                        <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" OnClick="showReport_OnClick"><i class="fa fa-search-plus"></i> Item</asp:LinkButton>--%>
                                   
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary" style="font-family:Nikosh">
                        <div class="panel panel-body">
                            <div class="col-md-12">
                                <div runat="server" id="printReport">
                                    <div class="row" style="font-size:15px">
                                        <p style="text-align: center">
                                            গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
                                        </p>
                                        <p style="text-align: center">
                                            জাতীয় রাজস্ব বোর্ড
                                        </p>
                                        <p style="text-align: center">
                                           <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationName" />
                                        </p>
                                        <p style="text-align:center">
                                            <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationAddress" />
                                        </p>
                                        <p style="text-align:center">
                                            <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationBIN" />
                                        </p>
                                        <br />
                                        <p style="text-align: center">
                                            <strong>বিক্রয় হিসাব পুস্তক </strong>
                                        </p>
                                        <p style="text-align: center">
                                            (পণ্য বা সেবা প্রক্রিয়াকরণে সম্পৃক্ত এমন নিবন্ধিত বা তালিকাভুক্ত ব্যক্তির জন্য প্রযোজ্য)
                                        </p>
                                        <p style="text-align: center">
                                            <%-- [বিধি 22(১) দ্রষ্টব্য]--%>
                                             [বিধি ৪০ এর উপ-বিধ (১) এর দফা (খ) এবং বিধি ৪১ এর দফা (ক) দ্রষ্টব্য]
                                        </p>
                                        <p style="border: 1px solid #000; float: right; margin-right: 15px;font-weight: bold">
                                            মূসক-৬.২
                                        </p>
                                    </div>
                                    <div style="font-size:12px">
                                   <%-- <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse">--%>
                                        <table border="1" class="allSolid" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr style="border: 1px solid #000">
                                                <td colspan="21" style="font-weight: normal">
                                                    <center>
                                                        <h4 style="text-align: center; font-weight: bold">
                                                            পণ্য/সেবার বিক্রয়</h4>
                                                    </center>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th rowspan="1" class="col_3_percent" style="text-align: center; font-weight: bold">ক্রমিক সংখ্যা
                                                </th>
                                                <th rowspan="1" class="col_3_percent" style="text-align: center; font-weight: bold">তারিখ
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight: bold">উৎপাদিত পণ্যের প্রারম্ভিক জের
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight:bold">উৎপাদন
                                                </th>
                                                 <th colspan="2" style="text-align: center; font-weight: bold">মোট উৎপাদিত পণ্য/সেবা
                                                </th>
                                                <th colspan="3" style="text-align: center; font-weight: bold">ক্রেতা/ সরবরাহগ্রহীতা
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight: bold">চালানপত্রের বিবরণ
                                                </th>
                                                <th colspan="5" style="text-align: center; font-weight: bold">বিক্রিত/সরবরাহকৃত পণ্যের বিবরণ
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight: bold">পণ্যের প্রান্তিক জের
                                                </th>
                                                <th colspan="1" style="text-align: center; font-weight: bold">মন্তব্য
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr style="font-weight:bold;">
                                                <th style="text-align: center"></th>
                                                <th style="text-align: center"></th>
                                                <th style="text-align: center">পরিমাণ (একক) 
                                                </th>
                                                <th style="text-align: center">মূল্য (সকল প্রকার কর ব্যতিত) 
                                                </th>
                                                <th style="text-align: center">পরিমাণ (একক)  
                                                </th>
                                                <th style="text-align: center">মূল্য (সকল প্রকার কর ব্যতিত)
                                                </th>

                                                <th style="text-align: center">পরিমাণ (একক) 
                                                </th>
                                                <th style="text-align: center">মূল্য (সকল প্রকার কর ব্যতিত) 
                                                </th>

                                                <th style="text-align: center">নাম 
                                                </th>
                                                 <th style="text-align: center">ঠিকানা 
                                                </th>
                                                <th style="text-align: center">নিবন্ধন/তালিকাভুক্তি/জাতীয় পরিচয়পত্র নং
                                                </th>
                                               
                                                <th style="text-align: center">নম্বর 
                                                </th>
                                                <th style="text-align: center">তারিখ 
                                                </th>
                                                <th style="text-align: center">বিবরণ 
                                                </th>
                                                <th style="text-align: center">পরিমাণ 
                                                </th>
                                                <th style="text-align: center">করযোগ্য মূল্য
                                                </th>
                                                <th style="text-align: center">সম্পূরক শুল্ক(যদি থাকে) 
                                                </th>
                                                <th style="text-align: center">মুসক 
                                                </th>
                                                <th style="text-align: center">পরিমাণ (একক) 
                                                </th>
                                                <th style="text-align: center">মূল্য (সকল প্রকার কর ব্যতিত) 
                                                </th>
                                                <td style="text-align: center"></td>
                                            </tr>



                                            <tr style="font-weight:bold;">
                                                <th style="text-align: center">(১)
                                                </th>
                                                <th style="text-align: center">(২)
                                                </th>
                                                <th style="text-align: center">(৩)
                                                </th>
                                                <th style="text-align: center">(৪)
                                                </th>
                                                <th style="text-align: center">(৫)
                                                </th>
                                                <th style="text-align: center">(৬)
                                                </th>
                                                <th style="text-align: center">(৭)=(৩+৫)
                                                </th>
                                                <th style="text-align: center">(৮)=(৪+৬)
                                                </th>
                                                <th style="text-align: center">(৯)
                                                </th>
                                                <th style="text-align: center">(১০)
                                                </th>
                                                <th style="text-align: center">(১১)
                                                </th>
                                                <th style="text-align: center">(১২)
                                                </th>
                                                <th style="text-align: center">(১৩)
                                                </th>
                                                <th style="text-align: center">(১৪)
                                                </th>
                                                <th style="text-align: center">(১৫)
                                                </th>
                                                <th style="text-align: center">(১৬)
                                                </th>
                                                <th style="text-align: center">(১৭)
                                                </th>
                                                <th style="text-align: center">(১৮)
                                                </th>
                                                <th style="text-align: center">(১৯)=(৭-১৫)
                                                </th>

                                                 <th style="text-align: center">(২০)=(৮-১৬)
                                                </th>
                                                <th style="text-align: center">(২১)
                                                </th>
                                            </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblReportView" />
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label">বিশেষ দ্রষ্টব্য :</label>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label">*যেই ক্ষেত্রে অনিবন্ধিত ব্যক্তির নিকট পণ্য বিক্রয় করা হইবে সেক্ষেত্রে উক্ত ব্যক্তির পূর্ণাঙ্গ নাম,ঠিকানা ও জাতীয় পরিচয়পত্র নম্বর যথাযথভাবে সংশ্লিষ্ট কলামে [(৯),(১০) ও (১২)] আবশ্যিকভাবে উল্লেখ করিতে হইবে।</label>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 1px">
                                            <div class="form-group form-group-sm">
                                                <asp:Label runat="server" Text="System User: "></asp:Label>
                                                <asp:Label runat="server" ID="lblUser"></asp:Label>
                                                <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                                <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                            </div>
                                        </div>
                                         <div style="text-align:right;font-size:11px;margin-right:20Px">
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

            <asp:HiddenField ID="hiddenPrantikJerQty" runat="server" />
            <asp:HiddenField ID="hiddenPrantikJerValue" runat="server" />


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

