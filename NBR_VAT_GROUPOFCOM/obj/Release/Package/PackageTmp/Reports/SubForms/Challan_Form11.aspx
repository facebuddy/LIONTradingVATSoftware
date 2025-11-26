<%@ page title="বিক্রয় চালানপত্র (মূসক-১১)" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_Challan_Form11, App_Web_lb3hvxkt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
       <style>
        .btn {
            padding: 5px;
            text-decoration: none;
        }

        .btn-default {
            background: #ddd;
            color: #000;
        }

        .btn-danger {
            background: #F26363;
            color: #fff;
        }

        /*td {
            padding-right: 15px;
        }*/


    </style>
    <style media="print">
        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            td, th{
                border-collapse:collapse;
            }

            /*tr, td {
                padding: 2px;
            }*/

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

    <script type="text/javascript" src='<%= this.ResolveClientUrl("~/Scripts/jquery-3.1.1.min.js") %>'></script>
    <script type="text/javascript" src='<%= this.ResolveClientUrl("~/Scripts/sweetalert2/sweetalert2.all.min.js") %>'></script>

    <script type="text/javascript">
        function PrintPanel() {

            var panel = document.getElementById("<%=mushok11Panel.ClientID %>");
            <%--var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            document.getElementById('<%=btnPrint.ClientID%>').click();

            setTimeout(function () {
                printWindow.print(); return false;
            }, 500);
            return false;--%>

            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<style> td, tr, table{border-collapse:collapse;} table{width:100%}</style>');
            printWindow.document.write('</head>');
            //printWindow.document.write('<body style="margin: 20px; font-family: "Times New Roman", Times, serif; font-size:14px">');
            printWindow.document.write('<body style="margin-left: 20px; margin-right: 20px; font-family: "Times New Roman", Times, serif; font-size:14px">');
            
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

     <%-- <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upContent" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary panel-primary-custom">
                <%--<div class="panel-heading text-center">চালানপত্র (মূসক-১১)</div>--%>
                <div class="panel-heading text-center">চালানপত্র (মূসক-৬.৩)</div>
                
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateFrom" style="font-size:11pt" />
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateTo" style="font-size:11pt" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Customer Name :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlCustomer" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Sale Challan No :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlChallanId" placeholder="Enter Sale Challan No" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">SKU :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlSKU" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                           <asp:LinkButton ID="btnClear"  runat="server" CssClass="btn btn-success btn-sm " style="float:right" OnClick="btnShow_Click" ><i class="	fa fa-archive"></i> Report</asp:LinkButton>&nbsp&nbsp
                          <asp:LinkButton ID="btnPrint" runat="server" style="float:right" CssClass="btn btn-info btn-sm" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>Print</asp:LinkButton>
                         </div>
                    </div>
                      
                   <%-- <div class="col-md-5 col-sm-5">
                       <div class="col-sm-6">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label">From Date :</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateFrom" />
                            </div>
                           </div>
                        </div>
                        <div class="col-sm-6">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label">To Date :</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateTo" />
                            </div>
                           </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-5 control-label">ক্রেতার নাম :</label>
                            <div class="col-sm-7">
                                <asp:DropDownList runat="server" ID="drpOrgName" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3">
                        <div class="form-group form-group-sm">
                            <label class="col-sm-8 control-label">চালানপত্রের ক্রমিক সংখ্যা :</label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtChallanId" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1 col-sm-1">
                        <div class="form-group form-group-sm">
                             <asp:LinkButton ID="btnClear"  runat="server" CssClass="btn btn-success" OnClick="btnShow_Click" ><i class="	fa fa-archive"></i> Report</asp:LinkButton>
                           
                        </div>
                    </div>--%>
                </div>
            </div>
     
             
           
         
          <asp:Panel ID="mushok11Panel" runat="server">
                    <div class="panel panel-primary panel-primary-custom">
                    <div class="panel-body" runat="server" id="print_content">
                        <%--<div class="row">
                         <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                         <p style="text-align:center">জাতীয় রাজস্ব বোর্ড</p>                      
                         <p style="text-align:right; font-size:12px"><b style="border:1px solid gray;margin-right: 17px;">মূসক-৬.৩</b></p>
                         <p style="text-align:center;font-size:14px"><strong>কর চালানপত্র</strong></p>
                         <p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (গ) ও দফা (চ) দ্রষ্টব্য ]</p>
                       </div>--%>
                          <p style="text-align:right; padding:5px;font-size:12px">
                              <b style="border:1px solid gray;margin-right: 17px;">মূসক-৬.৩</b></p>    
                       <%--  <p style="text-align:right; font-size:12px;  margin:2px;">মূসক-৬.৩</p>--%>
                         <p style="text-align:center; font-size:12px; margin:2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                         <p style="text-align:center; font-size:12px; margin:2px;">জাতীয় রাজস্ব বোর্ড</p>      
                         <p style="text-align:center;font-size:12px; margin:2px;"><strong>কর চালানপত্র</strong></p>
                         <p style="text-align:center;font-size:12px; margin:2px;">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (গ) ও দফা (চ) দ্রষ্টব্য ]</p>
                          
                       
                        <%--<center style="width: 100%; font-size:12px;">--%>
                        <center style="width: 100%; font-size:12px;">
                            <div class="col-md-12">
                                <div class="form-group form-group-sm">
                                    <div class="col-sm-12" aria-orientation="horizontal">
                                        <%--<center style="width: 100%; font-size:12px;">--%>
                                            <%--<label class="control-label">--%> 
                                            <label>নিবন্ধিত ব্যাক্তির নাম : <asp:Label runat="server" ID="OrgName"/></label>
                                    <%--</center>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group form-group-sm">
                                    <div class="col-sm-12" aria-orientation="horizontal">
                                        <%--<center>--%>
                                        <%--<label class="control-label">--%>
                                            <label> নিবন্ধিত ব্যাক্তির বিআইএন : <asp:Label runat="server" ID="OrgTin"/></label>
                                    <%--</center>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group form-group-sm">
                                    <div class="col-sm-12">
                                        <%--<center>--%>
                                        <%--<label class="control-label">--%>
                                        <label>চালানপত্র ইস্যুর ঠিকানা : <asp:Label runat="server" ID="OrgAddress" /></label>
                                    <%--</center>--%>
                                    </div>
                                </div>
                            </div>
                       </center>
                        
                        <br />

                        <div class="clearfix"></div>


                        <div style="font-size:12px;">
                        <div class="col-sm-6" style="width: 50%; float: left;">
                            <p style="  margin:2px;">
                                ক্রেতার নামঃ 
                                <asp:Label runat="server" ID="Customer_name" />
                            </p>
                            <p style="  margin:2px; ">
                                ক্রেতার বিআইএনঃ 
                                <asp:Label runat="server" ID="Customer_TIN" />
                            </p>
                            <p style="  margin:2px; ">
                              সরবরাহের গন্তব্যস্থলঃ 
                                <asp:Label runat="server" ID="Goods_Services_Ship" />
                            </p>

                            <p style="  margin:2px; ">Print Date & Time &nbsp;&nbsp;&nbsp;:<asp:Label runat="server" ID="printDate"></asp:Label>
                            </p>

                        </div>
                        <div class="col-sm-6" style="width: 49%; float: left">
                            <p style="  margin:2px; ">
                                চালানপত্র নম্বরঃ 
                                <asp:Label runat="server" ID="Challan_No" />
                            </p>
                            <p style="  margin:2px; ">
                                ইস্যুর তারিখঃ 
                                <asp:Label runat="server" ID="Challan_Date" />
                            </p>
                            <p style="  margin:2px; ">
                                ইস্যুর সময়ঃ 
                                <asp:Label runat="server" ID="Challan_Time" />
                            </p>
                        </div>
                    </div>


                    <div hidden>
                          <label class="control-label" style="text-align: left;">
                              পণ্য অপসারণের/অর্পণের বা সেবা
                               <br />
                               প্রদানের প্রকৃত তারিখ ও সময় :
                                <asp:Label runat="server" ID="Goods_Upload_Date_Time" />
                            </label>
                     </div>


                        <div class="clearfix"></div>
                        <br />
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                    <%--<table class="table" style="width: 100%; font-size:12px;" border="1">--%>
                                    <table class="table" border="1" style="font-size:12px;">
                                        <thead>
                                            <tr style="text-align:center;">
                                                <%--<th>ক্রমিক</th>
                                                <th>পণ্য বা সেবার বর্ণনা (প্রযোজ্য ক্ষেত্রে ব্র্যান্ড নামসহ)</th>
                                                <th>সরবরাহের একক</th>
                                                <th>পরিমাণ</th>
                                                <th>একক মূল্য (টাকায়)</th>
                                                <th>মোট মূল্য (টাকায়)</th>
                                                <th>সম্পূরক শুল্কের পরিমাণ (টাকায়)</th>
                                                <th>মূল্য সংযোজন করের হার/ সুনিদৃষ্ট কর</th>
                                                <th>মূল্য সংযোজন কর/ সুনিদৃষ্ট কর এর পরিমান (টাকায়)</th>
                                                <th>সকল প্রকার শুল্ক ও করসহ মূল্য</th>--%>

                                                <%-- <th>পণ্য/সেবার নাম</th>--%>
                                                <%-- <th>সম্পূরক শুল্ক আরোপযোগ্য মূল্য</th>--%>
                                                <%-- <th>সম্পূরক শুল্কের পরিমাণ (টাকায়)</th>--%>
                                                <%-- <th>মূল্য সংযোজন করের পরিমাণ</th>--%>


                                                <td>ক্রমিক</td>
                                                <td>পণ্য বা সেবার বর্ণনা (প্রযোজ্য ক্ষেত্রে ব্র্যান্ড নামসহ)</td>
                                                <td>সরবরাহের একক</td>
                                                <td>পরিমাণ</td>
                                                <td>একক মূল্য (টাকায়)</td>
                                                <td>মোট মূল্য (টাকায়)</td>
                                                <td>সম্পূরক শুল্কের পরিমাণ (টাকায়)</td>
                                                <td>মূল্য সংযোজন করের হার/ সুনিদৃষ্ট কর</td>
                                                <td>মূল্য সংযোজন কর/ সুনিদৃষ্ট কর এর পরিমান (টাকায়)</td>
                                                <td>সকল প্রকার শুল্ক ও করসহ মূল্য</td>


                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%-- <tr>
                                                <td>(১)</td>
                                                <td>(২)</td>
                                                <td>(৩)</td>
                                                <td>(৪)</td>
                                                <td>(৫)</td>
                                                <td>(৬)</td>
                                                <td>(৭)</td>
                                                <td>(৮)</td>
                                                <td>(৮)</td>
                                            </tr>--%>
                                            <tr>
                                                <asp:Label runat="server" ID="lblReportHtml" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <%-- <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <label class="control-label">১। শুধুমাত্র নিবন্ধিত ক্রেতাকে পণ্য সরবরাহ বা সেবা প্রদান করা হইলেই ক্রেতার নাম, ঠিকানা ও করদাতা সনাক্তকরণ সংখ্যা [অবশ্যই] উল্লেখ করিতে হইবে।</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <label class="control-label">২। পণ্য/সেবার চূড়ান্ত গন্তব্যস্থল ক্রেতার ঠিকানা হইতে পৃথক হইলে শুধুমাত্র প্রযোজ্য হইবে।</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <label class="control-label">৩। চালানপত্র প্রদানের সময়, পণ্য অপসারণের/অর্পণের বা সেবা প্রদানের প্রকৃত তারিখ ও সময় অঙ্কে ও কথায় লিখিতে হইবে।</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <label class="control-label">৪। সরাসরি অথবা প্রচ্ছন্ন রপ্তানি হইলে ঋণপত্র অথবা অভ্যন্তরীণ ব্যাক-টু-ব্যাক ঋণপত্র অথবা স্থানীয় বা আন্তর্জাতিক দরপত্রের ক্ষেত্রে কার্যাদেশের নম্বর ও তারিখ (ব্যাংকের নামসহ) ইত্যাদি তথ্য কলাম (২) এর তথ্য এর সহিত উল্লেখ করিতে হইবে।</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <label class="control-label">৫। এই কলামে পণ্য/সেবার পরিমাণ অঙ্কে ও তার নিচে কথায় লিখিতে হইবে।</label>
                            </div>
                        </div>--%>
                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <%--<label class="control-label">--%>
                            <label style="font-size:11px;">প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যাক্তির নাম :</label>
                            <asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerName"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <%--<label class="control-label">--%>
                            <label style="font-size:11px;">পদবী&nbsp;&nbsp; :</label>
                            <asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerDesignationName"></asp:Label>
                        </div>
                    </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <labelstyle="font-size:11px;" style="font-size:11px;">স্বাক্ষর :</labelstyle="font-size:11px;">
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <label style="font-size:11px;">সিল&nbsp;&nbsp;&nbsp;&nbsp; :</label>
                            </div>
                        </div>
                        <div class="col-md-12" style="height: 15px;">
                            <div class="form-group form-group-sm">
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <label style="font-size:9px;">* উৎসে কর্তনযোগ্য সরবরাহের ক্ষেত্রে ফরমটি সমন্বিত করে চালানপত্র ও উৎসে এর কর্তন সনদপত্র হিসেবে বিবেচিত হইবে এবং উহা উৎসে কর কর্তনযোগ্য।</label>
                            </div>
                        </div>
                        <div class="col-md-12" style="height: 20px;">
                            <div class="form-group form-group-sm">
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <label style="font-size:9px;">*সকল প্রকার কর ব্যাতীত মূল্য";</label>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>

        </ContentTemplate>
           
    </asp:UpdatePanel>
    
  

</asp:Content>
             
