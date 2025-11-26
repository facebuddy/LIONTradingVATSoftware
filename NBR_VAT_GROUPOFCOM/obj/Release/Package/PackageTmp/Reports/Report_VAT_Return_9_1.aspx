<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_Report_VAT_Return_9_1, App_Web_o1josinq" %>

<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Others.ascx" TagName="others" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />

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
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-primary">
        <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">মূল্য সংযোজন কর দাখিলপত্র (মূসক-৯.১)</div>
        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
            <div class="row" style="padding-left: 0%; padding-right: 2%">
                <div class="col-sm-4" style="padding: 0px; padding-left: 0%">
                    <div class="col-sm-3" style="padding: 0px">
                        <asp:RadioButton runat="server" Text="কর মেয়াদ" Style="margin-top: 22px; margin-left: 12px"
                            CssClass="present-address-lbl" ID="rd1" AutoPostBack="true" GroupName="rdoGroup"
                            OnCheckedChanged="radio_OnCheckedChanged" Checked="true" /></div>
                    <div class="col-sm-9" style="padding: 0px" runat="server" id="Div2" visible="false">
                        <fieldset class="scheduler-border-report" style="margin: 0px; padding: 0em">
                            <legend title="" class="scheduler-border-report">কর মেয়াদ</legend>
                            <div class="col-sm-6" style="padding: 0px">
                                <div class="col-sm-3" style="padding: 0px">
                                    <asp:Label ID="Label1" runat="server" Text="Month:" /></div>
                                <div class="col-sm-3" style="padding: 0px">
                                    <asp:DropDownList runat="server" ID="drpMonth" CssClass="present-address-tb" Style="width: 240%;
                                        height: 25px; text-align: left" AutoPostBack="true" OnSelectedIndexChanged="drpMonth_OnSelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="col-sm-6" style="padding: 0px">
                                <div class="col-sm-3" style="padding: 0px">
                                    <asp:Label ID="Label7" Style="margin-left: 9px" runat="server" Text="Year:" /></div>
                                <div class="col-sm-3" style="padding: 0px">
                                    <asp:DropDownList runat="server" ID="drpYear" CssClass="present-address-tb" Style="width: 245%;
                                        height: 25px" AutoPostBack="true" OnSelectedIndexChanged="drpYear_OnSelectedIndexChanged" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="col-sm-8" style="padding: 0px;">
                    <fieldset class="scheduler-border-report" style="margin: 0px; padding: 0em; margin-left: 5px;
                        margin-top: 3px">
                        <legend title="" class="scheduler-border-report">দাখিলপত্রের প্রকার</legend>
                        <div class="col-sm-3" style="padding: 0%">
                            <asp:Label ID="Label3" Style="margin-left: 3px" runat="server" Text="(ক) মূল দাখিলপত্র (ধারা ৬৪)" />&nbsp<asp:CheckBox
                                ID="rules64" runat="server" />
                        </div>
                        <div class="col-sm-4" style="padding: 0%">
                            <asp:Label ID="Label4" runat="server" Text="(খ) সংশোধিত দাখিলপত্র (ধারা ৬৬)" />&nbsp<asp:CheckBox
                                ID="rules66" runat="server" />
                        </div>
                        <div class="col-sm-5" style="padding: 0%">
                            <asp:Label ID="Label5" runat="server" Text="(গ)পূর্ণ, অতিরিক্ত বা বিকল্প দাখিলপত্র(ধারা ৬৭)" />&nbsp<asp:CheckBox
                                ID="rules67" runat="server" />
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="row" style="padding: 0%;">
                <div class="col-sm-6" style="padding: 0%;">
                    <div class="col-sm-3" style="padding: 0px; margin-top: 12px">
                        <asp:RadioButton runat="server" Style="margin-left: 12px;" Text="Advance Search"
                            ID="rd2" AutoPostBack="true" GroupName="rdoGroup" OnCheckedChanged="radio_OnCheckedChanged" /></div>
                    <div id="Div1" class="col-sm-9" style="padding: 0px" runat="server" visible="false">
                        <fieldset class="scheduler-border-report" style="margin: 0px; padding: 0em">
                            <legend title="" class="scheduler-border-report">কর মেয়াদ</legend>
                            <div class="col-sm-6" style="padding: 0px">
                                <asp:Label ID="Label2" runat="server" Text="Date From:" class="present-address-lbl"
                                    Style="margin-left: 5%; margin-top: 3px"></asp:Label>
                                <ww:jQueryDatePicker ID="dtpDateFrom" runat="server" Style="width: 60%; margin-left: 16%;
                                    height: 27px" class="present-address-tb" DateFormat="dd/MM/yyyy" placeholder="dd/MM/yyyy"
                                    onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"></ww:jQueryDatePicker>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="dtpDateFrom"
                                    ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                    ErrorMessage="Invalid date format in From Date." CssClass="litMessage" />
                            </div>
                            <div class="col-sm-6" style="padding: 0px">
                                <asp:Label ID="Label22" runat="server" Text="Date To:" class="present-address-lbl"
                                    Style="margin-left: 5%; margin-top: 3px"></asp:Label>
                                <ww:jQueryDatePicker ID="dtpDateTo" runat="server" Style="width: 60%; margin-left: 13.5%;
                                    height: 27px" class="present-address-tb" DateFormat="dd/MM/yyyy" placeholder="dd/MM/yyyy"
                                    onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"></ww:jQueryDatePicker>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="dtpDateTo"
                                    ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                    ErrorMessage="Invalid date format in To Date." CssClass="litMessage" />
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="col-sm-4" style="padding: 0%; margin-top: 15px; margin-left: 0px">
                    <asp:Label ID="Label6" runat="server" Style="margin-left: 8px" Text="বিগত করমেয়াদে কোনো কার্যক্রম সম্পন্ন হইয়াছে কি?  "> <asp:Label ID="Label8" runat="server" Style="margin-left: 5px" Text="হ্যাঁ "> <asp:CheckBox ID="ha" runat="server" /></asp:Label>
                        <asp:Label ID="Label9" Style="margin-left: 5px" runat="server" Text="না "> <asp:CheckBox ID="na" runat="server" /></asp:Label>
                    </asp:Label>
                </div>
                <div class="col-sm-2" style="padding: 0%;">
                    <asp:Button ID="showBTN" runat="server" CssClass="btn btn-warning" Style="float: right;
                        margin-right: 11%; margin-top: 5px" Text="Show Report" OnClick="showButton_click" />
                    <asp:Label runat="server" ID="lblErrorMessage" ForeColor="Red" Font-Bold="true" />
                </div>
            </div>
            <div class="row" style="padding: 0%;margin-top:3px">
              <div class="col-sm-3" style="padding: 0%;">
                <asp:RadioButton runat="server" Style="margin-left: 12px;" Text="ঋণাত্মক নীট অর্থ জের টানা এবং ফেরত"
                            ID="rbLessAmountP9" AutoPostBack="true" GroupName="" OnCheckedChanged="rbLessAmountP9_OnCheckedChanged" />
              </div>
              <div class="col-sm-6" style="padding: 0%;">
                <asp:Label runat="server" Text="ঋণাত্মক নীট অর্থ জের টানিবার জন্য বা ফেরতের জন্য টিক চিহ্ন দিন:" ID="lblTik" Visible="false"/>
                 <asp:CheckBox ID="chkAddPrevious" runat="server" Text="জের টানা" Visible="false"/>&nbsp
                 <asp:CheckBox ID="chkCashReturn" runat="server" Text="নগদ ফেরত" Visible="false"/>
              </div>
              <div class="col-sm-3" style="padding: 0%;margin-left:-7%">
                 <asp:Label runat="server" ID="lblReturnAmount" Text="ফেরতদাবীর পরিমাণ: " CssClass="present-address-lbl" style="margin-top:5px" Visible="false"/>
                 <asp:TextBox runat="server" ID="txtReturnDemandAmount" CssClass="present-address-tb" style="width:50%;height:27px;margin-left:115px;margin-bottom:3px" placeholder="টাকায়" Visible="false"/>
              </div>
        </div>
        </div>
    </div>
    <div id="reportMain" class="container-fluid" style="padding: 2%;" runat="server"
        visible="false">
        <div class="row">
            <p style="text-align: center">
                গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
            <p style="text-align: center">
                জাতীয় রাজস্ব বোর্ড</p>
            <p style="text-align: center">
                মূল্য সংযোজন কর দাখিলপত্র</p>
            <p style="text-align: center">
                [বিধি ৪৭ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
            <p style="border: 1px solid #000; float: right; margin-right: 15px">
                মূসক-৯.১</p>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #DDDDDD">
                        অংশ-১: করদাতার তথ্য
                    </th>
                </tr>
                <tr>
                    <td class="td-width-30">
                        (১) করদাতার নাম
                    </td>
                    <td class="td-width-2">
                        :
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTaxpayerName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        (২) ব্যবসায় সনাক্তকরণ সংখ্যা
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblBIN" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="3" style="text-align: center; background-color: #DDDDDD">
                        অংশ-২: দাখিলপত্র জমার তথ্য
                    </th>
                </tr>
                <tr>
                    <td class="td-width-30">
                        (১) কর মেয়াদ
                    </td>
                    <td class="td-width-2">
                        :
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTaxValidation" />
                    </td>
                </tr>
                <tr>
                    <td>
                        (২) দাখিলপত্রের প্রকার
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        (ক) মূল দাখিলপত্র (ধারা ৬৪)
                        <asp:CheckBox ID="chk64" runat="server" Checked="false" /><br />
                        (খ) সংশোধিত দাখিলপত্র (ধারা ৬৬)
                        <asp:CheckBox ID="chk66" runat="server" Checked="false" /><br />
                        (গ)পূর্ণ, অতিরিক্ত বা বিকল্প দাখিলপত্র(ধারা ৬৭)
                        <asp:CheckBox ID="chk67" runat="server" Checked="false" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30">
                        (৩) বিগত করমেয়াদে কোনো কার্যক্রম সম্পন্ন হইয়াছে কি?
                    </td>
                    <td class="td-width-2">
                        :
                    </td>
                    <td>
                        <asp:CheckBox ID="chkHa" runat="server" />
                        হ্যাঁ &nbsp &nbsp
                        <asp:CheckBox ID="chkNa" runat="server" />
                        না<br />
                        [যদি ‘না’ হয় তাহলে অংশ-১, ২ এবং ১০ পূরণ করুন]
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30">
                        (৪) পেশের তারিখ [অনলাইনে দাখিলের ক্ষেত্রে তাৎক্ষণিকভাবে এবং ডাক বা সরাসরি দাখিলের
                        ক্ষেত্রে প্রহণের তারিখ দাখিলপত্র জমার তারিখ হিসেবে বিবেচিত হবে ।]
                    </td>
                    <td class="td-width-2">
                        :
                    </td>
                    <td style="padding: 10px;">
                        <asp:Label runat="server" ID="lblSystemDate" />
                        <asp:Label runat="server" ID="lblSystemDate1" Visible = false />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="6" style="text-align: center; background-color: #DDDDDD">
                        অংশ-৩: সরবরাহ প্রদান-প্রদেয় কর
                    </th>
                </tr>
                <tr>
                    <th style="width: 65%; text-align: center; background-color: #DDDDDD" colspan="2">
                        সরবরাহের প্রকৃতি
                    </th>
                    <th style="width: 5%; text-align: center; background-color: #DDDDDD">
                        নোট
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">
                        মূল্য (ক)
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">
                        মূসক (খ)
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">
                        এসডি (গ)
                    </th>
                </tr>
                <tr>
                    <td rowspan="2">
                        শূন্যহার বিশিষ্ট সরবরাহ
                    </td>
                    <td>
                        প্রচ্ছন্ন রপ্তানি
                    </td>
                    <td class="td-width-5">
                        ১
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblDeemedExportPriceP3" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                <tr>
                    <td>
                        সরাসরি রপ্তানি
                    </td>
                    <td>
                        ২
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblDirectExportPriceP3" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        অব্যাহতিপ্রাপ্ত সরবরাহ
                    </td>
                    <td>
                        ৩
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblExemptSupplyPriceP3" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        আদর্শ হারের সরবরাহ
                    </td>
                    <td>
                        ৪
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTypicalSupplyPriceP3" />
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTypicalSupplyVatP3" />
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTypicalSupplySDP3" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ভূমি এবং ভবনের সরবরাহ
                    </td>
                    <td>
                        ৫
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblLandBuildingPriceP3" />
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblLandBuildingVatP3" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        মোট প্রদেয় কর (৪খ+৪গ+৫খ)
                    </td>
                    <td>
                        ৬
                    </td>
                    <td style="background-color: #DDDDDD">
                        <asp:Label runat="server" ID="lblTotalPriceP3" />
                    </td>
                    <td colspan="2">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatP3" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="5" style="text-align: center; background-color: #DDDDDD">
                        অংশ-৪: ক্রয় – উপকরণ কর
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD" colspan="2">
                        ক্রয়ের প্রকৃতি
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        মূল্য (ক)
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        মূসক (খ)
                    </th>
                </tr>
                <tr>
                    <td rowspan="2">
                        অব্যাহতিপ্রাপ্ত ক্রয়
                    </td>
                    <td>
                        সরবরাহ
                    </td>
                    <td class="td-width-5">
                        ৭
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblPurchaseRelievedSupplyPriceP4" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                <tr>
                    <td>
                        আমদানি
                    </td>
                    <td>
                        ৮
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblPurchaseRelievedImportPriceP4" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                 <tr>
                    <td rowspan="2">
                       শূন্যহার বিশিষ্ট ক্রয় 
                    </td>
                    <td>
                        সরবরাহ
                    </td>
                    <td class="td-width-5">
                        ৯
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblZeroRateSupplyPriceP4" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                <tr>
                    <td>
                        আমদানি
                    </td>
                    <td>
                        ১০
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblZeroRateImportPriceP4" />
                    </td>
                    <td style="background-color: #DDDDDD">
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">
                        আদর্শ হারের ক্রয়
                    </td>
                    <td>
                        সরবরাহ
                    </td>
                    <td>
                       ১১
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblStandardPurchaseSupplyPriceP4" />
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblStandardPurchaseSupplyVatP4" />
                    </td>
                </tr>
                <tr>
                    <td>
                        আমদানি
                    </td>
                    <td>
                        ১২
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblStandardPurchaseImportPriceP4" />
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblStandardPurchaseImportVatP4" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ভূমি এবং ভবনের ক্রয়
                    </td>
                    <td>
                       ১৩
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblLandBuildingPriceP4" />
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblLandBuildingVatP4" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        মোট উপকরন কর (১১খ+১২খ+১৩খ)
                    </td>
                    <td>
                        ১৪
                    </td>
                    <td style="background-color: #DDDDDD">
                        <asp:Label runat="server" ID="lblTotalPriceP4" />
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatP4" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="4" style="text-align: center; background-color: #DDDDDD">
                        অংশ-৫: বৃদ্ধিকারী সমন্বয়
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">
                        সমন্বয় ঘটনা
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD; border-right: 1px solid gray">
                        পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70">
                        সরবরাহকারীর সরবরাহ থেকে উৎসে কর্তনের জন্য
                    </td>
                    <td class="td-width-5">
                        ১৫
                    </td>
                    <td class="td-width-24">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblSuppliersCuttingQuantityP5" />
                    </td>
                </tr>
                <tr>
                    <td>
                        ব্যাংকিং চ্যানেলে মূল্য পরিশোধিত হয় নাই এমন সরবরাহের জন্য
                    </td>
                    <td>
                       ১৬
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblBankingPendingPriceQuantityP5" />
                    </td>
                </tr>
                <tr>
                    <td>
                        ক্রয়ের মূল্য বা পরিমাণ পরিবর্তন বা তাহা বাতিলের জন্য
                    </td>
                    <td>
                        ১৭
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblChangePurchasePriceQuantityP5" />
                    </td>
                </tr>
                <tr>
                    <td>
                        অন্যকোনো সমন্বয় ঘটনার জন্য
                    </td>
                    <td>
                        ১৮
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAnotherAdjusmentQuantityP5" />
                    </td>
                </tr>
                <tr>
                    <td>
                        মোট বৃদ্ধিকারী সমন্বয় (১৫+১৬+১৭+১৮)
                    </td>
                    <td>
                        ১৯
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalQuantityP5" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="4" style="text-align: center; background-color: #DDDDDD">
                        অংশ-৬: হ্রাসকারী সমন্বয়
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">
                        সমন্বয় ঘটনা
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70">
                        প্রদত্ত সরবরাহ হইতে উৎসে কর্তনের জন্য
                    </td>
                    <td class="td-width-5">
                        ২০
                    </td>
                    <td class="td-width-25">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblSourceCuttingQuantityP6" />
                    </td>
                </tr>
                <tr>
                    <td>
                        বিক্রয়ের মূল্য বা পরিমাণ পরিবর্তন বা তা বাতিলের জন্য
                    </td>
                    <td>
                        ২১
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblChangePriceQuantityP6" />
                    </td>
                </tr>
                <tr>
                    <td>
                        সম্পূরক শুল্কের জন্য
                    </td>
                    <td>
                        ২২
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblSDQuantityP6" />
                    </td>
                </tr>
                <tr>
                    <td>
                        অন্যকোনো সমন্বয় ঘটনার জন্য
                    </td>
                    <td>
                        ২৩
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAnotherAdjusmentQuantityP6" />
                    </td>
                </tr>
                <tr>
                    <td>
                        মোট হ্রাসকারী সমন্বয় (২০+২১+২২+২৩)
                    </td>
                    <td>
                        ২৪
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalQuantityP6" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="4" style="text-align: center; background-color: #DDDDDD">
                        অংশ-৭: নীট কর হিসাব
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">
                        আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70">
                        বর্তমান করমেয়াদে প্রদেয় মোট মূসক ও সম্পূরক শুল্ক (৬-১৪+১৯-২৪)
                    </td>
                    <td class="td-width-5">
                        ২৫
                    </td>
                    <td class="td-width-25">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatSDQuantityP7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        মূল্য সংযোজন কর আইন,১৯৯১ এর অধীন চলতি হিসাব (মূসক-১৮) হইতে আনীত সমাপনী জেরের অবশিষ্ট
                        অংশ (মূসক-১৮.৬ এর ভিত্তিতে)
                    </td>
                    <td>
                       ২৬
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblPendingPriceQuantityP7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        নোট ২৬ এর জন্য হ্রাসকারী সমন্বয় (নোট ২৫ এর ১০% পর্যন্ত)
                    </td>
                    <td>
                        ২৭
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblNote24AdjusmentQuantityP7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        আগাম কর
                    </td>
                    <td>
                        ২৮
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdvanceTaxQuantityP7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        পূর্ববর্তী করমেয়াদ হইতে আনীত ঋণাত্মক জের
                    </td>
                    <td>
                        ২৯
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblNegativeBalanceQuantityP7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        আবগারি শুল্ক
                    </td>
                    <td>
                        ৩০
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblExciseDutyQuantityP7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        সারচার্জ
                    </td>
                    <td>
                        ৩১
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblSurchargeQuantityP7" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="4" style="text-align: center; background-color: #DDDDDD">
                        অংশ-৮: কর পরিশোধের তফসিল
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">
                        আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        অর্থনৈতিক কোড
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">
                        পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td>
                        মোট কর (২৫-২৭-২৮-২৯)
                    </td>
                    <td class="td-width-5">
                        ৩২
                    </td>
                    <td>
                        ১/১১৩৩/<asp:Label runat="server" ID="lblVatOperationCode" />/০৩১১
                    </td>
                    <td class="td-width-25">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatP8" />
                    </td>
                </tr>
                <tr>
                    <td>
                        আবগারি শুল্ক
                    </td>
                    <td>
                        ৩৩
                    </td>
                    <td>
                        ১/১১৩৩/অপারেশনাল কোড/০৬০১
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblExciseDutyP8" />
                    </td>
                </tr>
                <tr>
                    <td>
                        সারচার্জ
                    </td>
                    <td>
                        ৩৪
                    </td>
                    <td>
                        ১/১১৩৩/অপারেশনাল কোড/২২১৪
                    </td>
                    <td>
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblSurchargeP8" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="3" style="text-align: center; background-color: #DDDDDD">
                        অংশ-৯: ঋণাত্মক নীট অর্থ জের টানা এবং ফেরত
                    </th>
                </tr>
                <tr>
                    <td>
                        ঋণাত্মক নীট অর্থ জের টানিবার জন্য বা ফেরতের জন্য টিক চিহ্ন দিন
                    </td>
                    <td>
                        ৩৫
                    </td>
                    <td>
                        জের টানা
                        <asp:CheckBox runat="server" ID="chkPreviousAmount"/>
                        &nbsp &nbsp নগদ ফেরত
                        <asp:CheckBox runat="server" ID="chkCashAmount"/><br />
                        ফেরতদাবীর পরিমাণ
                        <asp:TextBox runat="server" ID="txtRefundMoney" width="25%"/>
                        (টাকায়)
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-top: 40px">
            <table class="table table-bordered" style="width: 100%;background:none">
                <tr>
                    <th colspan="3" style="text-align: center; background-color: #DDDDDD">
                        অংশ-১০: ঘোষণা
                    </th>
                </tr>
                <tr>
                    <td colspan="3">
                        আমরা ঘোষণা করিতেছি যে, এই দাখিলপত্রে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20">
                        নাম
                    </td>
                    <td colspan="2">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblNameP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20">
                        পদবী
                    </td>
                    <td class="td-width-40">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblDesignationP10" />
                    </td>
                    <td rowspan="4">
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20">
                        তারিখ
                    </td>
                    <td class="td-width-40">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblDateP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20">
                        মোবাইল নম্বর
                    </td>
                    <td class="td-width-40">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblMobileP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20">
                        ইমেইল
                    </td>
                    <td class="td-width-40">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblMailP10" />
                    </td>
                </tr>
                <tr>
                    <td style="border: 0px">
                    </td>
                    <td style="border: 0px">
                    </td>
                    <td style="float: right">
                        স্বাক্ষর
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <asp:Button Style="float: right; margin-right: 2%;" CssClass="test-btn-primary" runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" Visible="false" />
        <asp:Button Style="float: right; margin-right: 2px;width: 85px;" CssClass="test-btn-primary" runat="server" ID="btnCSV" Text="Create CSV" OnClick="btnCSV_Click" Visible="false" />
        <asp:Button Style="float: right; margin-right: 2px;width: 85px;" CssClass="test-btn-primary" runat="server" ID="btnXML" Text="Create XML" OnClick="btnXML_Click" Visible="false" />
        <asp:Button Style="float: right; margin-right: 2px;" CssClass="test-btn-primary" runat="server" ID="btnPrint" Text="Print" OnClientClick="return PrintPanel()" Visible="false" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnImport" runat="server" CssClass="test-btn-primary" Text="Import CSV" OnClick="ImportCSV" style="float:left;width:120px;" />
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>
