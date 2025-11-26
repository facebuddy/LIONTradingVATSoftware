<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_GoodsTransferSummery_Chak__Ka_, App_Web_pj2ymx2u" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <script type="text/javascript">
function PrintPanel() {
            var panel = document.getElementById("<%=reportMain.ClientID %>");
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
    <style>
        .m
        {
            text-align:right;
            padding-right:5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="float:right">
        
    </div>
    <div class="panel panel-group">
        <div class="panel panel-primary panel-primary-custom">
                       
                    <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">Goods Transfer Summary (Chak- Ka)</div>
                    <div class="panel-body">
                         <div class="row">
                               
                               
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">From Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="dtpFromDate" DateFormat="dd/MM/yyyy" />
                                            <cc11:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpFromDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">To Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="dtpToDate" DateFormat="dd/MM/yyyy" />
                                            <cc11:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpToDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
            <div class="form-group form-group-sm">
                <label class="col-sm-5 control-label text-right" ><span class="required" style="color:red">* </span>প্রেরণকারী ইউনিট :</label>
                <div class="col-sm-7">
                    <asp:DropDownList ID="drpIssueBranch" runat="server" CssClass="form-control select2">
                       
                    </asp:DropDownList>
                </div>
            </div>
        </div>
                               

                            </div>

                        <div class="row">
                              <div class="col-md-4">
                            <div class="form-group form-group-sm">
                <label class="col-sm-5 control-label text-right" ><span class="required" style="color:red">* </span>গ্রহীতা ইউনিট :</label>
                <div class="col-sm-7">
                    <asp:DropDownList ID="drpRcvBranch" runat="server" CssClass="form-control select2">
                       
                    </asp:DropDownList>
                </div>
            </div>
                </div>              <div class="col-md-4" style="text-align:right">
                     <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                                <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="showReport_OnClick"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                             <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
    

 <div class="form-group form-group-sm" runat="server" id="reportMain">
     <div class="table-responsive">
         <p style="text-align: center; font-weight: bold">ছক -ক</p>
         <p style="text-align: center; font-weight: bold">কেন্দ্রীয় ইউনিট হইতে বিক্রয় ইউনিটে স্থানান্তরিত পণ্য/ সেবা বিবরণী</p>
         <p style="text-align: center; font-weight: bold">
             [বিধি ৭ দ্রষ্টব্য]
         </p>
         <table border="1" class="allSolid" style="width: 100%; border-collapse: collapse">
             <thead>
                 <tr>
                     <th>কেন্দ্রীয় নিবন্ধিত ব্যক্তির নাম ও বিআইন</th>
                     <th>পণ্য/সেবা প্রেরণকারী ইউনিট এর নাম ও ঠিকানা</th>
                     <th>পণ্য/সেবা গ্রহীতা ইউনিট এর নাম ও ঠিকানা</th>
                     <th>কেন্দ্রীয় ইউনিট হইতে ইস্যুকৃত পণ্য/সেবার স্থানান্তর চালানপত্র বইয়ের নাম্বার ও ইস্যুর তারিখ</th>
                     <th>পণ্য/সেবার স্থানান্তর চালানপত্র ফরম মুসক-৬.৫ নম্বর ও তারিখ</th>
                     <th>স্থানান্তরিত পণ্য বা সেবার বিবরণ (প্রযোজ্যক্ষেত্রে সুনিদিষ্ট ব্র্যান্ডসহ নাম</th>
                    
                     <th>স্থানান্তরিত পণ্য বা সেবার পরিমাণ</th>
                     <th>স্থানান্তরিত পণ্য বা সেবার কর ব্যতীত মূল্য</th>
                     <th>স্থানান্তরিত পণ্য বা সেবার ক্ষেত্রে প্রযোজ্য করের পরিমাণ</th>
                 </tr>
             </thead>
             <tbody>
                 <tr>
                     <td style="text-align: center">(১)
                     </td>
                     <td style="text-align: center">(২)
                     </td>
                     <td style="text-align: center">(৩)
                     </td>
                     <td style="text-align: center">(৪)
                     </td>
                     <td style="text-align: center">(৫)
                     </td>
                     <td style="text-align: center">(৬)
                     </td>
                     <td style="text-align: center">(৭)
                     </td>
                     <td style="text-align: center">(৮)
                     </td>
                     <td style="text-align: center">(৯)
                     </td>
                    
                 </tr>

                 <tr>

                     <asp:Label runat="server" ID="lblReportHtml" />
                 </tr>
             </tbody>
         </table>
           
     </div>
      <br />
      <div class="col-md-12" style="margin-top: 1px">
                                            <div class="form-group form-group-sm">
                                                <asp:Label runat="server" Text="System User: "></asp:Label>
                                                <asp:Label runat="server" ID="lblUser"></asp:Label>
                                                <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                                <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                            </div>
                                        </div>

     <br />
     <div style="text-align:right;font-size:11px;">
         System Generated (KGCVAT)
     </div>
 </div>
    </asp:Content>