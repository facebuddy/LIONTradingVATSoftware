<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_BandrollRegister, App_Web_o1josinq" %>
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
            <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px"></div>
            
                    <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 25px; padding-top: 0px">Bandroll Register</div>
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
                <label class="col-sm-5 control-label text-right" ><span class="required" style="color:red">* </span>Category :</label>
                <div class="col-sm-7">
                    <asp:DropDownList ID="drpRegType" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpRegType_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">বিড়ি</asp:ListItem>
                        <asp:ListItem Value="2">সিগারেট</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
                               

                            </div>

                        <div class="row">

                             <div class="col-md-4">
                                     <div class="form-group form-group-sm">
                                               <label ID="designLabel" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>Design :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpdesignType"  runat="server" CssClass="form-control select2"  >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                </div>
                             

                                <div class="col-md-4">
                                     <div class="form-group form-group-sm">
                                               <label ID="brsdLabel" class="control-label col-sm-5"><span class="required"  style="color:red"> * </span>Band-roll & Stamp :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpbrsdType" CssClass="form-control select2" runat="server" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                </div>
                            <div class="col-md-4" style="text-align:right">
                                <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="showReport_OnClick"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                             <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
    

 <div class="form-group form-group-sm" runat="server" id="reportMain">
     <div class="table-responsive">
         <p style="text-align: center; font-weight: bold">ফরম</p>
         <p style="text-align: center; font-weight: bold">ব্যান্ডরোল রেজিস্টার</p>
         <p style="text-align: center; font-weight: bold">
             [বিধি ৭(৩) দ্রষ্টব্য]
         </p>
         <table border="1" class="table" style="width: 100%; border-collapse: collapse">
             <thead>
                 <tr>
                     <th>ক্রমিক নং</th>
                     <th>তারিখ</th>
                     <th>প্রারম্ভিক ব্যান্ডরোলের পরিমাণ</th>
                     <th>সংগ্রহীত/ক্রয়কৃত ব্যান্ডরোলের পরিমাণ</th>
                     <th>সংগ্রহীত/ক্রয়কৃত ব্যান্ডরোলের মূল্য</th>
                     <th>মোট ব্যান্ডরোলের পরিমাণ<br />
                         (৬=৩+৪)</th>
                     <th>পোস্ট অফিস কর্মকর্তা বা বোর্ড কর্তৃক ক্ষমতাপ্রাপ্ত কর্মকর্তার স্বাক্ষর</th>
                     <th>ব্যবহিত ব্যান্ডরোলের পরিমাণ</th>
                     <th>ব্যান্ডরোলের জের</th>
                     <th>মন্তব্য</th>
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
                     <td style="text-align: center">(১০)
                     </td>
                 </tr>

                 <tr>

                     <asp:Label runat="server" ID="lblReportHtml" />
                 </tr>
             </tbody>
         </table>
     </div>
 </div>
    </asp:Content>