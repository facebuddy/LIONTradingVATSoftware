<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Challan_Form11sCheck.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.Challan_Form11sCheck" %>



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

            td, th {
                border-collapse: collapse;
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


        label.removePaddingMargin {
           padding: 0; 
           margin: 0;
        }

    </style>

    <script type="text/javascript" src='<%= this.ResolveClientUrl("~/Scripts/jquery-3.1.1.min.js") %>'></script>
    <script type="text/javascript" src='<%= this.ResolveClientUrl("~/Scripts/sweetalert2/sweetalert2.all.min.js") %>'></script>

    <script type="text/javascript">
        function PrintPanel() {

            var panel = document.getElementById("<%=mushok11Panel.ClientID %>");
            //var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            var printWindow = window.open('', '', 'left=1,top=0,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<style> td, tr, table{border-collapse:collapse;} table{width:100%}</style>');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;font-size:10px;line-height:300px;} table.allSolid th { border: 1.5px solid black; } table.allSolid td { border: 1.5px solid black; } label.removePaddingMargin {padding: 0; margin: 0;} </style>');
            printWindow.document.write('</head>');
            //printWindow.document.write('<body style="margin: 20px; font-family: "Times New Roman", Times, serif; font-size:14px;line-height:300px;">');
            //printWindow.document.write('<body style="margin-left: 20px; margin-right: 20px; font-family: "Times New Roman", Times, serif; font-size:4px">');

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
            <div class="panel panel-primary panel-primary-custom">
                <%--<div class="panel-heading text-center">চালানপত্র (মূসক-১১)</div>--%>
                <div class="panel-heading text-center" style=" font-family:Tahoma; font-size:18px;"><b>চালানপত্র (মূসক-৬.৩)</b></div>
                
                <div class="panel-body">
                    <div class="row">

                      
                     <%--   <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateFrom" style="font-size:11pt"  AutoPostBack="True" OnTextChanged="dateChangedGetChallan" />
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
                        </div>--%>
                       <%-- <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Customer Name :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlCustomer" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Sale Challan No :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="ddlChallanId" placeholder="Enter Sale Challan No"  AutoPostBack="True" OnSelectedIndexChanged="ddlChallanId_SelectedIndexChanged" />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Invoice No:"></asp:Label>  <asp:Label ID="lblinvoice" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                      <%--  <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">SKU :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlSKU" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>--%>
                         <div class="col-md-4">
                            
                           <asp:LinkButton ID="btnClear"  runat="server" CssClass="btn btn-success btn-sm " style="float:right" OnClick="btnShow_Click" ><i class="	fa fa-archive"></i> Report</asp:LinkButton>&nbsp&nbsp
                          <asp:LinkButton ID="btnPrint" runat="server" style="float:right" CssClass="btn btn-info btn-sm" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>Print</asp:LinkButton>
                          <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px;float:right"></asp:TextBox>
                              </div>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator> 
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
               
                    <div class="panel-body" runat="server" id="print_content" style="font-family:Nikosh">
                       <div style="font-size:16px;">
                          <%--<p style="text-align:right; padding:5px;">
                          <b style="border:1px solid gray;margin-right: 17px;">মূসক-৬.৩</b></p>                       
                         <p style="text-align:center; font-size:12px; margin:2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                         <p style="text-align:center; font-size:12px; margin:2px;">জাতীয় রাজস্ব বোর্ড</p>      
                         <p style="text-align:center;font-size:12px; margin:2px;"><strong>কর চালানপত্র</strong></p>
                         <p style="text-align:center;font-size:12px; margin:2px;">বিধি ৪০ এর উপবিধি (১) এর দফা (গ) ও (চ) দ্রষ্টব্য]</p>--%>
                           <div style="font-size: 16px">
                            <p style="text-align: right; padding: 5px;">
                                <b style="border: 1px solid gray; margin-right: 17px;">মূসক-৬.৩</b>
                            </p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;">জাতীয় রাজস্ব বোর্ড,ঢাকা</p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;"><strong>কর চালানপত্র</strong></p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (চ) দ্রষ্টব্য]</p>
                        </div>

                          <%-- <table style="border:none;width: 100%;">
                               <tr>
                                   <td style="visibility:collapse;">yesaugrsursrf</td>
                                     
                                   <td>
                                         <p style="text-align:center; font-size:12px; margin:2px;margin-top:-50px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                                         <p style="text-align:center; font-size:12px; margin:2px;">জাতীয় রাজস্ব বোর্ড</p>      
                                         <p style="text-align:center;font-size:12px; margin:2px;"><strong>কর চালানপত্র</strong></p>
                                         <p style="text-align:center;font-size:12px; margin:2px;">বিধি ৪০ এর উপবিধি (১) এর দফা (গ) ও (চ) দ্রষ্টব্য]</p>
                                   </td>

                                   <td>
                                        <p style="text-align:right;">
                                        <b style="border:1px solid gray;margin-right: 17px;">মূসক-৬.৩</b></p> 
                                   </td>
                               </tr>
                           </table>   --%> 
                           
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
                <br />

                        <%--<center style="width: 100%; font-size:12px;">--%>
                         <%-- <center style="width: 100%; font-size:12px;">--%>

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
                       <%--</center>--%>
                        <br />
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
                                                <label  style="margin: 0;">ক্রেতার বিআইএন /NID  :
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


                        <div class="clearfix"></div>
                        <br />
                        <div class="col-md-12">

                              <asp:UpdatePanel Visible="false" ID="dulicate" runat="server">
                                                    <ContentTemplate>
                                                                          <div style="position: fixed;

                                                        bottom: 500px;

                                                        left: 200px;

                                                        z-index: 10000;

                                                        font-size:100px;

                                                        color: red;

                                                        transform:rotate(-30deg);

                                                        opacity: 0.6;">

                                              Duplicate

                                            </div>
                                                        </ContentTemplate>
                                  </asp:UpdatePanel>


                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                    <%--<table class="table" style="width: 100%; font-size:12px;" border="1">--%>
                                    <%--<table  class="table" border="1" style="font-size:12px;line-height:330px;">--%>
                                    <table  class="allSolid" border="1" style="width:100%;line-height:280px;">
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
                                            <tr">
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
                        <div class="col-md-12" >
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <labelstyle="font-size:11px;" style="font-size:11px;">স্বাক্ষর :</labelstyle="font-size:11px;">
                            </div>
                        </div>
                        <div  style="text-align:right;margin-right:100px;">
                            <div class="form-group form-group-sm">
                                <%--<label class="control-label">--%>
                                <label style="font-size:11px;">সিল :</label>
                            </div>
                        </div>
                        <div class="col-md-12" style="height: 15px;">
                            <div class="form-group form-group-sm">
                            </div>
                        </div>
                       <%-- <div class="col-md-12">
                            <div class="form-group form-group-sm">
                                
                                <label style="font-size:9px;">* উৎসে কর্তনযোগ্য সরবরাহের ক্ষেত্রে ফরমটি সমন্বিত করে চালানপত্র ও উৎসে এর কর্তন সনদপত্র হিসেবে বিবেচিত হইবে এবং উহা উৎসে কর কর্তনযোগ্য।</label>
                            </div>
                        </div>--%>
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
                               <div class="col-md-12" style="margin-top: 5px">
                                            <div class="form-group form-group-sm">
                                                <asp:Label runat="server" Text="System User: "></asp:Label>
                                                <asp:Label runat="server" ID="lblUser"></asp:Label>
                                                <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                                <asp:Label runat="server" ID="Label2" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                            </div>
                  </div>
                     <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
                    </div>
            

                </div>
                </div>
            </asp:Panel>
                </div>
           
         
            <div class="row">
                <%--<center><a href="#" onclick="window.print(); return false;"   data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint"><i class="fa fa-print"></i> Print</a></center>--%>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="clearfix"></div>
       <div class="text-right">
       
        <%--<asp:Button ID="btnPrint" runat="server" class="btn btn-primary noPrint btn-sm" Text="Print Report"  OnClick="btnPrint_Click" />--%>
        <%--<asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info noPrint" OnClick="btnPrint_Click">
            <i class="fa fa-print"></i> Print
        </asp:LinkButton>--%>
      
    </div>
    <br />
</asp:Content>
