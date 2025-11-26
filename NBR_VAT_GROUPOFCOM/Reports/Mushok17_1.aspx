<%@ page language="C#" autoeventwireup="true" inherits="Reports_Mushok17_1, App_Web_y1tsx4fu" masterpagefile="~/DashboardVTR.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <style type="text/css">
        .style4
        {
            height: 22px;
        }
        .style16
        {
            width: 358px;
        }
        .style17
        {
            width: 171px;
        }
        
        .test
        {
            width: 183px;
        }
        .style18
        {
            width: 39px;
        }
    </style>
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
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
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
                    দাপ্তরিক নাম, লগো ঠিকানা</p>
                <p style="border: 1px solid #000; float: right; margin-right: 15px">
                    মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                        font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                        font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                        text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                        background-color: rgb(255, 255, 255); display: inline !important; float: none;">১৭</span>.১</p>
            </div>
            <div>
            </div>
            <div>
            </div>
            <p style="text-align: center">
                <b><u>বিকল্প বিরোধ নিষ্পত্তি পদ্ধতিতে মামলা নিষ্পত্তির আবেদন</u></b>
                <br />
                [বিধি ৯৯ এর উপ-বিধি (১) দ্রষ্টব্য]
            </p>
            <br />
            <div>
                <table class="table table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc"
                            class="style4">
                        </th>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                            ১।
                        </td>
                        <td class="style17">
                            (ক) আবেদনকারী ব্যক্তি/প্রতিষ্ঠানের নাম ও ঠিকানাঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox runat="server" Height="60px" type="text" class="form-input" ID="txtApplicant_Name_Address"
                                placeholder="Enter Information" TextMode="MultiLine" MaxLength="499" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                        </td>
                        <td class="style17">
                            (খ) আবেদনকারীর বিআইএন ও ফোন নম্বরঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtApplicantBin_Phone"
                                Height="60px" placeholder="Enter Information" MaxLength="499" TextMode="MultiLine"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                            ২।
                        </td>
                        <td class="style17">
                            (ক) আবেদনে বর্ণিত বিরোধের প্রকৃতি ও বর্তমান অবস্থাঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtdisputed_description"
                                Height="60px" placeholder="Enter Information" MaxLength="499" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                        </td>
                        <td class="style17">
                            (খ) বিরোধীয় (disputed) বিষয় সংশ্লিষ্ট কমিশনারেটের নামঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtdisputed_commissionarate_name"
                                Height="60px" placeholder="Enter Information" MaxLength="499" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                            ৩।
                        </td>
                        <td class="style17">
                            বিরোধীয় (disputed) মূল্য জরিমানার বা রিফান্ডের পরিমাণঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtdisputed_amount"
                               onkeypress="return isNumberKey(event)" placeholder="Enter Information" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                            ৪।
                        </td>
                        <td class="style17">
                            বিরোধীয় (disputed) বিষয়ের সংক্ষিপ্ত বিবরণঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtdisputed_details"
                                Height="60px" placeholder="Enter Information" MaxLength="499" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                            ৫।
                        </td>
                        <td class="style17">
                            বিরোধীয় বিষয় নিষ্পত্তির সমর্থনে প্রাসঙ্গিক দলিলাদির নাম ও বিবরণ এবং সংযুক্তিঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtDoucument_Details"
                                Height="60px" placeholder="Enter Information" MaxLength="499" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height = 60px">
                        <td class="style18">
                            ৬।
                        </td>
                        <td class="style17">
                            সহায়তাকারীর নাম ও ঠিকানাঃ
                        </td>
                        <td class="style16">
                            <asp:TextBox ID="txtFacilitatorName_Add" runat="server" class="form-input" placeholder="Enter Information"
                                Height="60px" type="text" MaxLength="499" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <div style="text-align: left">
                    <br />
                    <br />
                    <p style="text-align: right; padding-right: 82px">
                        আবেদনকারীর স্বাক্ষরঃ
                    </p>
                    <p style="text-align: right">
                        নাম&nbsp;
                        <asp:TextBox ID="txtEmployeeName" runat="server" placeholder="Enter Name" ReadOnly="True"
                            type="text" Width="250px"></asp:TextBox>
                        <br />
                        <p style="text-align: right">
                            পদবি
                            <asp:TextBox ID="txtDesignation" runat="server" placeholder="Enter Designation" ReadOnly="True"
                                type="text" Width="250px"></asp:TextBox>
                        </p>
                        <p style="text-align: right">
                            তারিখঃ
                            <asp:TextBox ID="txtDate" runat="server" placeholder="Enter Date" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" type="text" Width="250px" MaxLength="10"></asp:TextBox>
                        </p>
                        <p style="text-align: right">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDate"
                                ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="Invalid date format." CssClass="litMessage" />
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                    </p>
                </div>
                <div>
                </div>
            </div>
            </div>
    </asp:Panel>
    <div class="container-fluid" style="padding: 2%">
        <div style="height: 30px">
            <asp:Button ID="printButton" runat="server" Text="Print" Width="72px" Font-Bold="True"
                Style="float: right" OnClientClick="return PrintPanel();" />
            <asp:Button ID="btnSave" runat="server" Font-Bold="True" Style="float: right" Text="Save"
                Width="72px" OnClick="btnSave_Click" />
        </div>
        <div class="col-sm-2">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
