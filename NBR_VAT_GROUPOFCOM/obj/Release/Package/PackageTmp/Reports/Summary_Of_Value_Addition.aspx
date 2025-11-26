<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Periodic_Purchase_Report_BI, App_Web_pj2ymx2u" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
       
    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/panel.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <style media="print">
        {
        }

        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            tr, td {
            }

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
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
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
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                   Value Addition summary (4.3)
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top: 1%">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="dtpFromDate" CssClass="form-control"  OnTextChanged="dtpFromDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpFromDate" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="dtpToDate" CssClass="form-control"  OnTextChanged="dtpToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpToDate" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Item Name :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" ID="ddlItem" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="text-align: right">
                        <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" Style="width: 80px"></asp:TextBox>
                        <%--<asp:LinkButton ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" OnClick="btnExportToExcel_Click"><i class="fa fa-list"></i>  Excel</asp:LinkButton>--%>
                        <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-success" OnClick="showBTN_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                        <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="precisionTxtBox" runat="server"
                        ErrorMessage="Precision has to be a number between 0 to 12"
                        ForeColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>

                    <div class="row" style="margin-top: 1%; overflow:auto;font-family:Nikosh;font-size:12px" >

                       

                    </div>
                   
                </div>
               
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </div>


    <asp:Panel ID="pnlContents" runat="server">

        <div id="divResult" runat="server">

            <table style="border: none; width: 100%;">
                <tr>
                    <td style="visibility: collapse;">yesaugrsursrf</td>
                    <td>
                        <p style="text-align: center; font-size: 12px; margin: 2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                        <p style="text-align: center; font-size: 12px; margin: 2px;">জাতীয় রাজস্ব বোর্ড</p>
                        <p style="text-align: center; font-size: 12px; margin: 2px; font-weight: bold;">উপকরণ-উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা </p>
                        <p style="text-align: center; font-size: 12px; margin: 2px;">বিধি (২১) দ্রষ্টব্য</p>
                    </td>

                    <td>
                        <p style="text-align: right;">
                            <b style="border: 1px solid gray;">মূসক-৪.৩</b>
                        </p>

                    </td>
                </tr>
            </table>


            <div>
                <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse; background-color: white">
                    <thead>
                        <tr style="border: 1px solid #000">
                            <td colspan="12" style="font-weight: normal">



                                <center>
                                                      
                                                           

                                                <div  style="text-align:left;font-size:12px;">
                                                <label>প্রতিষ্ঠানের নাম :</label> <asp:Label ID="lblNibondhitoBektirName" runat="server" Text=""></asp:Label>
                                                 <br/>
                                                  <label>ঠিকানা :</label><asp:Label ID="lblThikana" runat="server" Text=""></asp:Label>                   
                                                <br/>
                                                <label>বিন (BIN): </label> <asp:Label ID="lblNibondhonShonkha" runat="server" Text=""></asp:Label>
                                                <br/>   
                                               <label>দাখিলের তারিখ:</label><asp:Label ID="lblDakhilerTarikh" runat="server" Text=""></asp:Label>
                                                     <br/>   
                                               <label>ঘোষিত সহগ অনুযায়ী পণ্যের প্রথম সরবরাহের তারিখ:</label><asp:Label ID="lbleffectivDate" runat="server" Text=""></asp:Label>
                                                 </div>
                                                       
                                                    </center>
                            </td>
                        </tr>



                        <tr style="background-color: white; text-align: center; font-size: 12px;">
                            <th class="col_3_percent" style="font-weight: normal; background-color: white; text-align: center">ক্রমিক সংখ্যা</th>
                            <th class="col_3_percent" style="font-weight: normal; background-color: white; text-align: center">পণ্যের এইচ এস কোড/ সেবা কোড</th>
                            <th class="col_3_percent" style="font-weight: normal; background-color: white; text-align: center">সরবরাহতব্য পণ্য/সেবার নাম </th>
                            <th class="col_3_percent" style="font-weight: normal; background-color: white; text-align: center">সরবরাহের একক</th>
                            <th class="col_3_percent" style="font-weight: normal; background-color: white; text-align: center">ক্রয়মূল্য</th>
                            <th class="col_3_percent" style="font-weight: normal; background-color: white; text-align: center">মূল্য সংযোজন</th>
                            <th class="col_3_percent" style="font-weight: normal; background-color: white; text-align: center">শতকরা মূল্য সংযোজন </th>
                        </tr>



                    </thead>
                    <tbody style="font-size: 11px;">

                        <tr style="background-color: white; text-align: center;">
                            <td>(১)</td>
                            <td>(২)</td>
                            <td>(৩)</td>
                            <td>(৪)</td>
                            <td>(৫)</td>
                            <td>(৬)</td>
                            <td>(৭)</td>


                        </tr>
                        <tr>
                            <asp:Label runat="server" ID="lblInfoShow" />
                        </tr>
                    </tbody>
                </table>

                <div runat="server" id="signatureDiv" visible="false" style="padding-left: 80px;">
                    <table style="border: hidden;">
                        <tr>
                            <td style="float: right;">
                                <asp:Label Style="float: right" runat="server" Text="প্রতিষ্ঠানের দায়িত্বপ্রাপ্ত ব্যক্তির নাম: "></asp:Label></td>
                            <td>&nbsp&nbsp&nbsp</td>
                            <td>
                                <asp:Label Style="font-size: 12px;" ID="lblDutyOfficerName" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="float: right;">
                                <asp:Label Style="float: right" runat="server" Text="পদবী: "></asp:Label></td>
                            <td>&nbsp&nbsp&nbsp</td>
                            <td>
                                <asp:Label Style="font-size: 12px;" ID="lblDutyOfficerDesignation" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="float: right;">
                                <asp:Label Style="float: right" runat="server" Text="সাক্ষর: "></asp:Label></td>
                            <td>&nbsp&nbsp&nbsp</td>
                            <td>
                                <asp:Label ID="clientsign" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="float: right;">
                                <asp:Label Style="float: right" runat="server" Text="সীল: "></asp:Label></td>
                            <td>&nbsp&nbsp&nbsp</td>
                            <td>
                                <asp:Label ID="clientStamp" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group form-group-sm" style="font-size: 9px;">
                            <label class="control-label">বিশেষ দ্রষ্টব্য :</label>
                            <br />

                            <label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;১| যেকোনো পণ্য বা সেবা প্রথম সরবরাহের পূর্ববর্তী পনেরো কার্যদিবসের মধ্যে অনলাইনে মূসক কম্পিউটার সিস্টেমে বা সংশ্লিষ্ট বিভাগীয় কর্মকর্তার দপ্তরে উপকরণ-উৎপাদ সহগ সহজ ঘোষণা দাখিল করতে হইবে।
                             <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;২| পণ্য মূল্য বা মোট উপকরণ /কাঁচামালের মূল্য ৭.৫% এর বেশি পরিবর্তন হইলে নতুন ঘোষণা দাখিল করিতে হইবে।
                             <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;৩| উপকরণ ক্রয়ের স্বপক্ষে প্রামাণিক দলিল হিসাবে বিল অব এট্রি বা চালানপত্রের কপি সংযুক্ত করিতে হইবে।
                            </label>

                        </div>
                    </div>
                    <div style="text-align: right; font-size: 11px;">
                        System Generated (KGCVAT)
                    </div>
                </div>
            </div>



        </div>


        <div class="col-md-10">
            <asp:Label Visible="false" runat="server" ID="purchaseTypelbl" Font-Bold="true"></asp:Label>

            <asp:Label Visible="false" runat="server" ID="vendorlbl" Font-Bold="true"></asp:Label>

            <asp:Label Visible="false" runat="server" ID="fromdatelbl" Font-Bold="true"></asp:Label>

            <asp:Label Visible="false" runat="server" ID="todatelbl" Font-Bold="true"></asp:Label>
        </div>


        </div>











    </asp:Panel>
 


</asp:Content>
