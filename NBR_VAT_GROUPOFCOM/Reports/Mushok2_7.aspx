<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok2_7, App_Web_pj2ymx2u" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
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
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
    <asp:Panel ID="pnlContents" runat="server">
        <div class="container-fluid" style="padding: 2%">
            <div class="row">
                <p style="text-align: center">
                    গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                <p style="text-align: center">
                    জাতীয় রাজস্ব বোর্ড</p>
                <p style="border: 1px solid #000; float: right; margin-right: 15px">
                    মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                        font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                        font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                        text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                        background-color: rgb(255, 255, 255); display: inline !important; float: none;">২.৭</span></p>
            </div>
            <div>
                <table class="table
        table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="3" scope="colgroup" style="text-align: center; background-color: White;
                            border-width: 0px">
                            <b>ব্যবসায় স্থান পরিবর্তনের আবেদন</b>
                            <br />
                            [বিধি ১৩ এর উপ-বিধি (১) দ্রষ্টব্য]
                        </th>
                    </tr>
                    <tr>
                        <td>
                            ব্যবসায় সনাক্তকরণ সংখ্যা
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblBIN" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            আবেদনকারীর নাম
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblNameApplicant" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            স্থান পরিবর্তনের তারিখ
                        </td>
                        <td>
                        </td>
                        <td>
                            <div style="width: 88%; float: left">
                                <asp:TextBox ID="txtPlaceChangingDate" runat="server" type="text" Width="500px" onkeydown="return (event.keyCode!=13);"
                                    onkeyup="FormatIt(this);" MaxLength="10" placeholder="Enter Date"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPlaceChangingDate"
                                    ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                    ErrorMessage="Invalid date format." CssClass="litMessage" />
                            </div>
                            <div style="width: 11; float: right">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            আবেদন দাখিলের তারিখ
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtApplicationSubmitionDate" runat="server" type="text" Width="500px"
                                onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"
                                placeholder="Enter Date"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtApplicationSubmitionDate"
                                ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="Invalid date format." CssClass="litMessage" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <div>
                    <table class="table table-bordered" style="width: 100%">
                        <tr>
                            <th colspan="6" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                class="style4">
                                পরিবর্তিত ঠিকানা
                            </th>
                        </tr>
                    </table>
                    <div class="row">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">শহরের ঠিকানা</legend>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" class="control-label col-sm-5">
                                    হোল্ডিং নং</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Holding" placeholder="Enter Holding No"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" class="control-label col-sm-5">
                                    রোড নং বা নাম</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Road" placeholder="Enter Road"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" class="control-label col-sm-5">
                                   ব্লক/এলাকা</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Block_Area"
                                            placeholder="Enter Block/Area"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" class="control-label col-sm-5">
                                   জেলা</asp:Label>
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpPresentDistrict" runat="server" ReadOnly="true" class="drop-down"
                                            data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpPresentDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" class="control-label col-sm-5">
                                    উপ-জেলা</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpPresentUpazila" runat="server" ReadOnly="true" class="form-input">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" class="control-label col-sm-5">
                                    থানা</asp:Label>
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpPresentThana" runat="server" ReadOnly="true" class="form-input"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" class="control-label col-sm-5">
                                    পোস্টাল কোড</asp:Label>
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpPresentPostCode" runat="server" ReadOnly="true" class="form-input"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label8" runat="server" class="control-label col-sm-5">
                                    রোড নং বা নাম</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Road_No" placeholder="Enter Road No"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" class="control-label col-sm-5">
                                    মৌজার নাম</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_MozaName" placeholder="Enter Moza Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" class="control-label col-sm-5">
                                    ফোন</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Phone_no1" placeholder="Enter Phone No"
                                            MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label11" class="control-label col-sm-5" runat="server">
                                    ফোন:</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Phone_no2" placeholder="Enter Phone No"
                                            MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label12" class="control-label col-sm-5" runat="server">
                                    মোবাইল ফোন</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Mobile_no1"
                                            placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label13" class="control-label col-sm-5" runat="server">
                                    মোবাইল ফোন</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Mobile_no2"
                                            placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label14" class="control-label col-sm-5" runat="server">
                                    ইমেইল</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Email" placeholder="Enter Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label15" class="control-label col-sm-5" runat="server">
                                    ওয়েবসাইট</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Website" placeholder="Enter Website"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label16" class="control-label col-sm-5" runat="server">
                                    ফ্যাক্স</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPr_Fax" placeholder="Enter Fax"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="row">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">গ্রামের ঠিকানা</legend>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label17" class="control-label col-sm-5" runat="server">
                                    Para/Mohalla:</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Para" placeholder="Enter Para/Moholla"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label18" class="control-label col-sm-5" runat="server">
                                    Village:</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Village" placeholder="Enter Village"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label19" class="control-label col-sm-5" runat="server">
                                    জেলা</asp:Label>
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpPermanentDistrict" runat="server" ReadOnly="true" class="form-input"
                                            data-toggle="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpPermanentDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label20" class="control-label col-sm-5" runat="server">
                                    উপ-জেলা</asp:Label>
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpPermanentUpazila" runat="server" ReadOnly="true" class="form-input"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label21" class="control-label col-sm-5" runat="server">
                                    থানা</asp:Label>
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpPermanentThana" runat="server" ReadOnly="true" class="form-input"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label22" class="control-label col-sm-5" runat="server">
                                    পোস্টাল কোড</asp:Label>
                                    <div class=" dropdown col-sm-7">
                                        <asp:DropDownList ID="drpPermanentPost" runat="server" ReadOnly="true" class="form-input"
                                            data-toggle="dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label23" class="control-label col-sm-5" runat="server">
                                    রোড নং বা নাম</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Road_no" placeholder="Enter Road No"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label24" class="control-label col-sm-5" runat="server">
                                    মৌজার নাম</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Moza" placeholder="Enter Moza Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label25" class="control-label col-sm-5" runat="server">
                                    ফোন</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Phone_no1"
                                            placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label26" class="control-label col-sm-5" runat="server">
                                    ফোন</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Phone_no2"
                                            placeholder="Enter Phone No" MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label27" class="control-label col-sm-5" runat="server">
                                    মোবাইল ফোন</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Mobile_no1"
                                            placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label28" class="control-label col-sm-5" runat="server">
                                    মোবাইল ফোন:</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Mobile_no2"
                                            placeholder="Enter Mobile No" MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label29" class="control-label col-sm-5" runat="server">
                                    ইমেইল</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Email" placeholder="Enter Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label30" class="control-label col-sm-5" runat="server">
                                    ওয়েবসাইট</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Website" placeholder="Enter Website"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label31" class="control-label col-sm-5" runat="server">
                                    ফ্যাক্স</asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPar_Fax" placeholder="Enter Fax"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div style="height: 30px">
                    </div>
                </div>
                <div>
                    <table class="table table-bordered" style="width: 100%">
                        <tr>
                            <td class="style6" style="width: 40%" align="left">
                                <strong>(১) আপনার কোনো বকেয়া কর আছে কিনা?</strong>
                            </td>
                            <td class="style7" style="width: 15%" align="left">
                                <strong>হ্যাঁ&nbsp; </strong>
                                <asp:CheckBox ID="chkDueYes" runat="server" AutoPostBack="True" OnCheckedChanged="chkDueYes_CheckedChanged" />
                            </td>
                            <td class="style7" style="width: 15%" align="left">
                                <strong>না</strong>&nbsp;&nbsp;
                                <asp:CheckBox ID="chkDueNo" runat="server" AutoPostBack="True" OnCheckedChanged="chkDueNo_CheckedChanged" />
                            </td>
                            <td class="style7" style="width: 30%" align="left">
                                <strong></strong>&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" style="width: 49%" align="left">
                                <strong>(২) প্রশ্ন (১) এর উত্তর হ্যাঁ সূচক হইলে বকেয়ার পরিমাণ </strong>
                            </td>
                            <td class="style7" style="width: 49%" align="left" colspan="3">
                                <asp:TextBox ID="txtDueAmount" runat="server" placeholder="Amount" type="text" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" style="width: 40%" align="left">
                                <strong>(৩) কোনো অনিষ্পন্ন মামলা আছে কিনা?</strong>
                            </td>
                            <td class="style7" style="width: 15%" align="left">
                                <strong>হ্যাঁ&nbsp; </strong>
                                <asp:CheckBox ID="chkMamlaYes" runat="server" AutoPostBack="True" OnCheckedChanged="chkMamlaYes_CheckedChanged" />
                            </td>
                            <td class="style7" style="width: 15%" align="left">
                                <strong>না</strong>&nbsp;&nbsp;
                                <asp:CheckBox ID="chkMamlaNo" runat="server" AutoPostBack="True" OnCheckedChanged="chkMamlaNo_CheckedChanged" />
                            </td>
                            <td class="style7" style="width: 30%" align="left">
                                <strong></strong>&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table class="table table-bordered" style="width: 100%">
                            <tr>
                                <th colspan="5" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                    class="style4">
                                    (৪) প্রশ্ন (৩) এর উত্তর হ্যাঁ সূচক হইলে তাহার বিবরণ
                                </th>
                            </tr>
                            <tr>
                                <td class="style10" align="center" style="width: 10%">
                                    <strong>মামলা নং</strong>
                                </td>
                                <td class="style11" align="center" style="width: 15%">
                                    <strong>যে দপ্তরে/আদালতে বিচারাধিন তাহার নাম</strong>
                                </td>
                                <td class="style14" align="center" style="width: 30%">
                                    <strong>মামলার সংক্ষিপ্ত বিবরণ</strong>
                                </td>
                                <td class="style13" align="center" style="width: 15%">
                                    <strong>দাবিকৃত করের পরিমাণ</strong>
                                </td>
                                <td align="center" class="style15" style="width: 30%">
                                    <strong>মন্তব্য</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10" align="center" style="width: 10%; height: 100px">
                                    <asp:TextBox ID="txtMamlaNo" runat="server" placeholder="Write Here" type="text"
                                        Width="100%"></asp:TextBox>
                                </td>
                                <td class="style11" align="center" style="width: 10%; height: 100px">
                                    <asp:TextBox ID="txtMamlaBicharadhirName" runat="server" placeholder="Write Here"
                                        type="text" Width="100%"></asp:TextBox>
                                </td>
                                <td class="style14" align="center" style="width: 30%; height: 100px">
                                    <asp:TextBox ID="txtMamlaDescription" runat="server" placeholder="Write Here" type="text"
                                        Width="100%" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td class="style13" align="center" style="width: 15%; height: 100px">
                                    <asp:TextBox ID="txtMamlaVatAmount" runat="server" placeholder="Write Here" type="text"
                                        Width="100%"></asp:TextBox>
                                </td>
                                <td align="center" class="style15" style="width: 30%; height: 100px">
                                    <asp:TextBox ID="txtMamlaMontobbo" runat="server" placeholder="Write Here" type="text"
                                        Width="100%" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="table table-bordered" style="width: 100%">
                            <tr>
                                <td class="style6" style="width: 40%" align="left">
                                    <strong>(৫) সমন্বয় শেষ হয়নি এমন কোনো রেয়াত আছে কি? </strong>
                                </td>
                                <td class="style7" style="width: 15%" align="left">
                                    <strong>হ্যাঁ&nbsp; </strong>
                                    <asp:CheckBox ID="chkReatYes" runat="server" AutoPostBack="True" OnCheckedChanged="chkReatYes_CheckedChanged" />
                                </td>
                                <td class="style7" style="width: 15%" align="left">
                                    <strong>না</strong>&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkReatNo" runat="server" AutoPostBack="True" OnCheckedChanged="chkReatNo_CheckedChanged" />
                                </td>
                                <td class="style7" style="width: 30%" align="left">
                                    <strong></strong>&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 49%" align="left">
                                    <strong>(৬) প্রশ্ন (৫) এর উত্তর হ্যাঁ সূচক হইলে উহার পরিমাণ</strong>
                                </td>
                                <td class="style7" style="width: 49%" align="left" colspan="3">
                                    <asp:TextBox ID="txtReatAmount" runat="server" placeholder="Amount" type="text" Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 40%" align="left">
                                    <strong>(৭) কোনো ফেরতের আবেদন অনিষ্পন্ন আছে কি?</strong>
                                </td>
                                <td class="style7" style="width: 15%" align="left">
                                    <strong>হ্যাঁ&nbsp; </strong>
                                    <asp:CheckBox ID="chkReturnAppYes" runat="server" AutoPostBack="True" OnCheckedChanged="chkReturnAppYes_CheckedChanged" />
                                </td>
                                <td class="style7" style="width: 15%" align="left">
                                    <strong>না</strong>&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkReturnAppNo" runat="server" AutoPostBack="True" OnCheckedChanged="chkReturnAppNo_CheckedChanged" />
                                </td>
                                <td class="style7" style="width: 30%" align="left">
                                    <strong></strong>&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 49%" align="left">
                                    <strong>(৮)প্রশ্ন (৭) এর উত্তর হ্যাঁ সূচক হইলে উহার পরিমাণ</strong>
                                </td>
                                <td class="style7" style="width: 49%" align="left" colspan="3">
                                    <asp:TextBox ID="txtReturnAppAmount" runat="server" placeholder="Amount" type="text"
                                        Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 40%" align="left">
                                    <strong>(৯) স্থান পরিবর্তনের ফলে কমিশনারেট পরিবর্তিত হইবে কি?</strong>
                                </td>
                                <td class="style7" style="width: 15%" align="left">
                                    <strong>হ্যাঁ&nbsp; </strong>
                                    <asp:CheckBox ID="chkCommissionYes" runat="server" AutoPostBack="True" OnCheckedChanged="chkCommissionYes_CheckedChanged" />
                                </td>
                                <td class="style7" style="width: 15%" align="left">
                                    <strong>না</strong>&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkCommissionNo" runat="server" AutoPostBack="True" OnCheckedChanged="chkCommissionNo_CheckedChanged" />
                                </td>
                                <td class="style7" style="width: 30%" align="left">
                                    <strong></strong>&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" style="width: 49%" align="left">
                                    &nbsp;
                                </td>
                                <td class="style7" style="width: 49%" align="left" colspan="3">
                                    <asp:TextBox ID="txtCommission" runat="server" placeholder="Write Here" type="text"
                                        Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="height: 30px">
                    </div>
                </div>
                <div>
                    <p>
                        ঘোষণা<br />
                        <br />
                        আমি ঘোষণা করিতাছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও
                        <br />
                        নির্ভুল।
                        <br />
                        <br />
                        <div>
                            <p>
                                নাম&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
                                    ID="txtEmployeeName" runat="server" type="text" Width="500px" placeholder="Enter Name"
                                    ReadOnly="True"></asp:TextBox>
                            </p>
                        </div>
                        <p>
                            পদবি&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtDesignation" runat="server" type="text" Width="500px" placeholder="Enter Designation"
                                ReadOnly="True"></asp:TextBox>
                            <br />
                            <br />
                        </p>
                        <p>
                            &nbsp;</p>
                        <p>
                            <br />
                            স্বাক্ষর ও সীল
                        </p>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="container-fluid" style="padding: 2%">
        <div style="height: 30px">
            <asp:Button ID="printButton" runat="server" Text="Print" Width="72px" Font-Bold="True"
                Style="float: right" OnClientClick="return PrintPanel();" />
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
                Style="float: right" OnClick="btnSave_Click" />
        </div>
        <div class="col-sm-2">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
