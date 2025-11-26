<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="SaleChallan_11_Report, App_Web_ebyme1bz" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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

        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;}
        table.allSolid td { border: 1.5px solid black;}

    </style>

    <script type="text/javascript" src='<%= this.ResolveClientUrl("~/Scripts/jquery-3.1.1.min.js") %>'></script>
    <script type="text/javascript" src='<%= this.ResolveClientUrl("~/Scripts/sweetalert2/sweetalert2.all.min.js") %>'></script>

    <script type="text/javascript">
        function PrintPanel() {

            var panel = document.getElementById("<%=pnlContents.ClientID %>");
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
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<style> td, tr, table{border-collapse:collapse;} table{width:100%}</style>');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;font-size:10px;line-height:300px;} table.allSolid th { border: 1.5px solid black;}table.allSolid td { border: 1.5px solid black;}</style>');
            printWindow.document.write('</head>');
            //printWindow.document.write('<body style="margin: 20px; font-family: "Times New Roman", Times, serif; font-size:14px">');
            //printWindow.document.write('<body style="margin-left: 20px; margin-right: 20px; font-family: Times New Roman, Times, serif; font-size:14px">');
            
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upContent" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlContents" runat="server">
                <div class="panel panel-primary panel-primary-custom" >
                    <div class="panel-body" runat="server" id="print_content" style="font-family:Nikosh">
                        <div runat="server" id="divhead" visible="false">
                        <div style="font-size:16px;margin-top:30px">                       
                       
                                <div class="row">
                                  
                                    <div style="font-size: 16px">
                                        <%--<img src="../../Images/bdlogo.png" style="height: 50px; margin-left: 80px;"></img>--%>
                                       <%-- <div style="display:grid; grid-template-columns: auto auto auto;">
                                           <p>as</p>
                                        <p style="text-align: center; font-size: 12px;  background-color: green">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার </p>
                                             <p style="text-align: right; padding: 5px; background-color: aquamarine">
                                                <b style="border: 1px solid gray; margin-right: 17px; margin-top: 20px; background-color: green">মূসক-৬.৮</b>
                                            </p>
                                        </div>--%>
                                       <p style="text-align: right; padding: 5px;">
                                                <b style="border: 1px solid gray; margin-right: 17px; margin-top: 20px;">মূসক-৬.৩</b>
                                        </p>
                                        <p style="text-align: center; font-size: 12px;margin: 2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার </p>
                                        <p style="text-align: center; font-size: 12px;margin: 2px; ">জাতীয় রাজস্ব বোর্ড</p>
                                        <p style="text-align: center; font-size: 12px; margin: 2px;"><strong>কর চালানপত্র</strong></p>
                                        <p style="text-align: center; font-size: 12px; margin: 2px;">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ছ) দ্রষ্টব্য]</p>
                                    </div>

                                </div>
                            <div style="font-size:12px">
                                <div class="row" style=" font-size: 16px"> <%--zahid 16-08-22--%>
                                <table style="border: none; width: 100%">
                                    <tr>
                                        <th colspan="2" scope="colgroup" style="text-align: center; font-size: 14px; border: none"></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../../Images/bdlogo.png" style="height: 50px; margin-left: 80px; margin-top: -120px"></img>

                                        </td>

                                        <td></td>

                                </table>

                            </div>
                              
                          </div>  
                           
                       
                         <div style="padding-left:100px;font-size:11px;">
                            <div class="col-md-12">
                                <div class="form-group form-group-sm">
                                    <div class="col-sm-12" >
                                        <%--<center style="width: 100%; font-size:12px;">--%>
                                            <%--<label class="control-label">--%> 
                                            <label class="removePaddingMargin">নিবন্ধিত ব্যক্তির নাম : <asp:Label runat="server" ID="OrgName"/></label>
                                    <%--</center>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group form-group-sm">
                                    <div class="col-sm-12">
                                        <%--<center>--%>
                                        <%--<label class="control-label">--%>
                                            <label class="removePaddingMargin"> নিবন্ধিত ব্যক্তির বিআইএন : <asp:Label runat="server" ID="OrgTin"/></label>
                                    <%--</center>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group form-group-sm">
                                    <div class="col-sm-12" >
                                        <%--<center>--%>
                                        <%--<label class="control-label">--%>
                                        <label class="removePaddingMargin">চালানপত্র ইস্যুর ঠিকানা : <asp:Label runat="server" ID="OrgAddress" /></label>
                                    <%--</center>--%>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <br />
                       <%--</center>--%>
                        
                              <div class="col-sm-4" style="float: right;">
                                    <p style="margin: 0;">
                                        চালানপত্র নম্বরঃ 
                                <asp:Label runat="server" ID="Challan_No" style="font-size:smaller;" />
                                    </p>
                                    <p style="margin: 0;">
                                        ইস্যুর তারিখঃ 
                                <asp:Label runat="server" ID="Challan_Date" style="font-size:smaller;" />
                                    </p>
                                    <p style="margin:0;">
                                        ইস্যুর সময়ঃ 
                                <asp:Label runat="server" ID="Challan_Time" style="font-size:smaller;" />
                                    </p>
                                </div>
                              <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label  style="margin: 0;">ক্রেতার নাম  :
                                               <asp:Label ID="Customer_name" runat="server" Text="" style="font-size:smaller;margin: 0;"></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>                                       
                              <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" >
                                                <label  style="margin: 0;">ক্রেতার বিআইএন/NID   :
                                                 <asp:Label ID="Customer_TIN" runat="server" style="font-size:smaller;margin: 0;" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>                                         
                              <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" >
                                                <label  style="margin: 0;">ক্রেতার ঠিকানা :
                                                 <asp:Label ID="Customer_Address" runat="server" style="font-size:smaller;margin: 0;" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>  
                              <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12">
                                                <label  style="margin: 0;">সরবরাহের গন্তব্যস্থল :
                                                 <asp:Label ID="Goods_Services_Ship" runat="server" Text="" style="font-size:smaller;margin: 0;"></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                              <div class="col-md-12">
                                        <div class="form-group form-group-sm">

                                            <%--<div class="col-sm-12" aria-orientation="horizontal">--%>

                                            <div class="col-sm-12">
                                                <label  style="margin: 0;">যানবাহনের প্রকৃতি ও নম্বর :
                                                 <asp:Label ID="txtTransport" runat="server" Text="" style="font-size:smaller;margin: 0;"></asp:Label></label>
                                            </div>
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

                        </div>
                        <div class="clearfix"></div>
                        <br />
                        <div class="col-md-12" runat="server" id="divbody" visible="false"> 
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                    <%--<table class="table" style="width: 100%; font-size:12px;" border="1">--%>
                                    <%--<table  class="table" border="1" style="font-size:12px;">--%>
                                    <%--<table  class="allSolid" border="1" style="line-height:450px;width:100%;">--%>
                                    <table  class="allSolid" border="1" style="line-height:330px;width:100%;">
                                        <%--<thead style="font-weight:bolder;">--%>
                                            <thead>
                                            <tr style="text-align:center;line-height:20px;">
                                                <%--<th>ক্রমিক</th>
                                                <th>পণ্য বা সেবার বর্ণনা (প্রযোজ্য ক্ষেত্রে ব্র্যান্ড নামসহ)</th>
                                                <th>সরবরাহের একক</th>
                                                <th>পরিমাণ</th>
                                                <th>একক মূল্য (টাকায়)</th>
                                                <th>মোট মূল্য (টাকায়)</th>
                                                <th>সম্পূরক শুল্কের পরিমাণ (টাকায়)</th>
                                                <th>মূল্য সংযোজন করের হার/ সুনির্দিষ্ট কর</th>
                                                <th>মূল্য সংযোজন কর/ সুনির্দিষ্ট কর এর পরিমাণ (টাকায়)</th>
                                                <th>সকল প্রকার শুল্ক ও করসহ মূল্য</th>--%>

                                                <%-- <th>পণ্য/সেবার নাম</th>--%>
                                                <%-- <th>সম্পূরক শুল্ক আরোপযোগ্য মূল্য</th>--%>
                                                <%-- <th>সম্পূরক শুল্কের পরিমাণ (টাকায়)</th>--%>
                                                <%-- <th>মূল্য সংযোজন করের পরিমাণ</th>--%>


                                                <%--<td style="font-weight: bold;">ক্রমিক</td>
                                                <td style="font-weight: bold;">পণ্য বা সেবার বর্ণনা (প্রযোজ্য ক্ষেত্রে ব্র্যান্ড নামসহ)</td>
                                                <td style="font-weight: bold;">সরবরাহের একক</td>
                                                <td style="font-weight: bold;">পরিমাণ</td>
                                                <td style="font-weight: bold;">একক মূল্য<sup>১</sup> (টাকায়)</td>
                                                <td style="font-weight: bold;">মোট মূল্য (টাকায়)</td>
                                                 <td style="font-weight: bold;">সম্পূরক শুল্কের হার</td>
                                                <td style="font-weight: bold;">সম্পূরক শুল্কের পরিমাণ (টাকায়)</td>
                                                <td style="font-weight: bold;">মূল্য সংযোজন করের হার/ সুনির্দিষ্ট কর</td>
                                                <td style="font-weight: bold;">মূল্য সংযোজন কর/ সুনির্দিষ্ট কর এর পরিমাণ (টাকায়)</td>
                                                <td style="font-weight: bold;">সকল প্রকার শুল্ক ও করসহ মূল্য</td>--%>


                                                <td style="width:30px;">ক্রমিক</td>
                                                <td style="width:400px;">পণ্য বা সেবার বর্ণনা (প্রযোজ্য ক্ষেত্রে ব্র্যান্ড নামসহ)</td>
                                                <td style="width:35px;">সরবরাহের একক</td>
                                                <td>পরিমাণ</td>
                                                <td style="width:100px;">একক মূল্য (টাকায়)<sup>১</sup></td>
                                                <td style="width:130px;">মোট মূল্য (টাকায়)</td>
                                                <td style="width:30px;">সম্পূরক শুল্কের হার</td>
                                                <td style="width:130px;">সম্পূরক শুল্কের পরিমাণ (টাকায়)</td>
                                                <td style="width:30px;">মূল্য সংযোজন করের হার/ সুনির্দিষ্ট কর</td>
                                                <td style="width:100px;">মূল্য সংযোজন কর/ সুনির্দিষ্ট কর এর পরিমাণ (টাকায়)</td>
                                                <td style="width:150px;">সকল প্রকার শুল্ক ও করসহ মূল্য</td>


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

                                              <%--<tr>--%>
                                            <tr style="line-height:15px;">
                                                <td style="text-align:center;">(১)</td>
                                                <td style="text-align:center;">(২)</td>
                                                <td style="text-align:center;">(৩)</td>
                                                <td style="text-align:center;">(৪)</td>
                                                <td style="text-align:center;">(৫)</td>
                                                <td style="text-align:center;">(৬)</td>
                                                <td style="text-align:center;">(৭)</td>
                                                <td style="text-align:center;">(৮)</td>
                                                <td style="text-align:center;">(৯)</td>
                                                <td style="text-align:center;">(১০)</td>
                                                <td style="text-align:center;">(১১)</td>
                                            </tr>
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
                        <div runat="server" id="divfooter" visible="false">
                        <div class="col-md-12">
                        <div class="form-group form-group-sm">
                            <%--<label class="control-label">--%>
                            <label style="font-size:11px;">প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যক্তির নাম :</label>
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
                        <div style="text-align:right;margin-right:100px;">
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <label style="font-size:11px;">সিল&nbsp;&nbsp;&nbsp;&nbsp; :</label>
                            </div>
                        </div>
                        <div class="col-md-12" style="height: 15px;">
                            <div class="form-group form-group-sm">
                            </div>
                        </div>                    
                        <div class="col-md-12" style="height: 20px;">
                            <div class="form-group form-group-sm">
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <label style="font-size:9px;">১.সকল প্রকার কর ব্যতীত মূল্য";</label>
                            </div>
                        </div>
                             <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
                        </div>
                        </div>
                    </div>
                </div>

             
            </asp:Panel>
            <%-- <div class="row">
      <p style="text-align:center;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
      <p style="text-align:center; padding:0px">জাতীয় রাজস্ব বোর্ড</p>
      <p style="text-align:center;margin-left: 80px;">কর চালানপত্র  <b style="border:1px solid #000; margin-left:1%; float:right">মূসক-৬.৩</b></p>
      <p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (গ) ও দফা (চ) দ্রষ্টব্য]</p>
    </div>
    <div class="row">
        <p style="margin-left:25%">নিবন্ধিত ব্যক্তির নামঃ&nbsp <asp:Label runat="server" ID="lblOrgName" style="font-weight:bold;font-size:14px" /></p>
        <p style="margin-left:25%">নিবন্ধিত ব্যক্তির বিআইএনঃ&nbsp <asp:Label runat="server" ID="lblOrgBIN" style="font-weight:bold;font-size:14px"/></p>
        <p style="margin-left:25%">চালানপত্র ইস্যুর ঠিকানাঃ&nbsp <asp:Label runat="server" ID="lblOrgAddress" style="font-weight:bold;font-size:14px"/></p>
    </div>
    <div class="row">
     <div class="col-sm-6" style="padding:0px">
        <p>ক্রেতার নামঃ&nbsp <asp:Label runat="server" ID="lblPartyName" style="font-weight:bold;font-size:14px"/></p>
        <p>ক্রেতার বিআইএনঃ&nbsp <asp:Label runat="server" ID="lblPartyBIN" style="font-weight:bold;font-size:14px"/></p>
        <p>সরবরাহের গন্তব্যস্থলঃ&nbsp <asp:Label runat="server" ID="lblUltimateDestination" style="font-weight:bold;font-size:14px"/></p>
       
     </div>
     <div class="col-sm-6" >
         <p >চালানপত্র নম্বরঃ&nbsp <asp:Label runat="server" ID="lblChallanNo" style="font-weight:bold;font-size:14px"/></p>
         <p >ইস্যুর তারিখঃ&nbsp <asp:Label runat="server" ID="lblChallanDate" style="font-weight:bold;font-size:14px"/></p>
         <p >ইস্যুর সময়ঃ&nbsp <asp:Label runat="server" ID="lblChallanTime" style="font-weight:bold;font-size:14px"/></p>
     </div>
    </div>
    <div class="row" style="padding:1px">
      <p>সরবরাহের বিবরণঃ</p>
      <table class="table table-bordered" style="width:auto;text-align:center">
        <tr style="text-align:center">
          <th scope="row" style="width:5%;text-align:center">ক্রমিক</th>
          <th style="width:45%;text-align:center">সরবরাহের বিবরণ</th>
          <th style="width:5%;text-align:center">সরবরাহের একক</th>
          <th style="width:10%;text-align:center">পরিমাণ</th>
          <th style="width:15%;text-align:center">একক মূল্য<sup>১</sup> (টাকায়)</th>
          <th style="width:5%;text-align:center">সম্পূরক শুল্কের পরিমাণ </th>
          <th style="width:15%;text-align:center">মোট মূল্য (টাকায়) </th>
        </tr>
        <tr>
            <asp:Label runat="server" ID="lblSaleChallanReport"></asp:Label>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:0">সর্বমোট</td>
         <td style="width:25px"><asp:Label runat="server" ID="lblTotalSD" /></td>
         <td style="width:25px"><asp:Label runat="server" ID="lblTotalPrice" /></td>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:0">সর্বমোট মূসক<sup>২</sup></td>
         <td style="width:25px" colspan="2"><asp:Label runat="server" ID="lblTotalVat" /></td>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right; border:0">সর্বমোট কর<sup>৩</sup></td>
         <td style="width:25px" colspan="2"><asp:Label runat="server" ID="lblTotalTax" /></td>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:0">উৎসে কর্তনযোগ্য করের সর্বোচ্চ পরিমাণ<sup>৪</sup></td>
         <td style="width:25px" colspan="2"><asp:Label runat="server" ID="lblVDS" /></td>
        </tr>
      </table>
      <p>দায়িত্ব প্রাপ্ত ব্যক্তির নাম ও স্বাক্ষর</p>
    </div>
    <div class="row">
      <hr/>
    </div>
    
    <div class="row">
      
      <p><sup>১</sup> প্রতি একক সরবরাহের মূসক ও সম্পূরক শুল্ক (যদি থাকে) সহ মূল্য।</p>
      <p><sup>২</sup> সর্বমোট মূল্য গুণন কর-ভগ্নাংশ।</p>
      <p><sup>৩</sup> সর্বমোট সম্পূরক শুল্ক যোগ সর্বমোট মূসক।</p>
      <p><sup>৪</sup> সর্বমোট মূসক-এর এক-তৃতীয়াংশ পরিমাণ। শুধু উৎসে কর্তনযোগ্য সরবরাহের ক্ষেত্রে ফরমটি সমনবিত কর চালানপত্র ও </p>
      <p>উৎসে কর কর্তন সনদপত্র হিসেবে বিবেচিত হইবে। এটি উৎসে কর কর্তনযোগ্য সরবরাহের ক্ষেত্রে প্রযোজ্য হইবে। </p>
    </div>--%>
            <div class="row">
                <%--<center><a href="#" onclick="window.print(); return false;"   data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint"><i class="fa fa-print"></i> Print</a></center>--%>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="clearfix"></div>
    <div class="text-right">
        <%--<asp:Button ID="btnPrint" runat="server" class="btn btn-primary noPrint btn-sm" Text="Print Report"  OnClick="btnPrint_Click" />--%>
        <%--<asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info noPrint" OnClick="btnPrint_Click">--%> 
        <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info noPrint" OnClientClick="return PrintPanel();">
            <i class="fa fa-print"></i> Print
        </asp:LinkButton>
        <%--<asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>Javascript  Print</asp:LinkButton>--%>
    </div>
    <br />

 
</asp:Content>

