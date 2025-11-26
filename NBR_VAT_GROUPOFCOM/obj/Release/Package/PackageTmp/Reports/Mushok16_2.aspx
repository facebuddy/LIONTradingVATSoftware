<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok16_2, App_Web_y1tsx4fu" %>

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


        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }



        function isAlfa(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)) {
                return false;
            }
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
        <div>
            <div class="container-fluid" style="padding: 2%">
                <div class="row">
                    <p style="text-align: center">
                        দাপ্তরিক নাম, লগো ঠিকানা</p>
                </div>
                <div class="row">
                    <p style="border: 1px solid #000; float: right; margin-right: 15px">
                        মূসক-<span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px;
                            font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                            font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px;
                            text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                            background-color: rgb(255, 255, 255); display: inline !important; float: none;">১৬.২</span></p>
                </div>
                <div style="height: 10px">
                </div>
                <div class="row">
                    <p style="text-align: center">
                        <b><u>স্বীকারোক্তিমূলক জবানবন্দি </u></b>
                    </p>
                    <p style="text-align: center">
                        [বিধি ৯৬ এর উপ-বিধি (৪) দ্রষ্টব্য]</p>
                </div>
                <div class="row">
                    <p style="text-align: left">
                        স্মারক নং-&nbsp;
                        <asp:TextBox ID="txtSharokNo" runat="server" type="text" Width="150px" 
                            placeholder="Enter Here" MaxLength="25"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;তারিখঃ&nbsp;
                        <asp:TextBox ID="txtDate" runat="server" type="text" onkeydown="return (event.keyCode!=13);"
                            onkeyup="FormatIt(this);" MaxLength="10" Width="150px" placeholder="Enter Here"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDate"
                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                            ErrorMessage="Invalid date format." CssClass="litMessage" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </p>
                    <br />
                    <p style="text-align: left">
                        সূত্রঃ
                    </p>
                    <p style="text-align: left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; সূত্রে বর্ণিত “স্বীকারোক্তিমূলক জবানবন্দি
                        প্রদানের জন্য নোটিশ (মূসক-১৬.১)” এর প্রেক্ষিতে আমি নিম্নবর্ণিত কার্যাবলীর মধ্যে
                        টিক চিহ্নিত কার্যক্রমটি গ্রহণ করিতে ইচ্ছুক, যথাঃ
                        <p style="padding-left: 150px">
                            (ক) আমি অভিযোগ সম্পূর্ণ স্বীকার করি এবং এ বিষয়ে অনুচ্ছেদ ০২ এ বর্ণিত ছকে আমার স্বীকারোক্তিমূলক
                            জবানবন্দি প্রদান করিলাম;
                        </p>
                        <p style="padding-left: 150px">
                            (খ) অভিযোগ সম্পূর্ণ অস্বীকার করি এবং কোনো স্বীকারোক্তিমূলক জবানবন্দি প্রদান করিলাম
                            না; এবং
                        </p>
                        <p style="padding-left: 150px">
                            (গ) অভিযোগটি আংশিক স্বীকার ও আংশিক অস্বীকার করি বিধায় অনুচ্ছেদ ০২ এ বর্ণিত ছকে আংশিক
                            স্বীকারের জন্য স্বীকারোক্তিমূলক জবানবন্দি প্রদান করিলাম এবং অবশিষ্ট অভিযোগের বিষয়ে
                            স্বীকারোক্তিমূলক জবানবন্দি প্রদান করিলাম না।
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                    </p>
                </div>
                <div style="height: 10px">
                </div>
                <div>
                </div>
                <table class="table table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="5" scope="colgroup" style="text-align: center; background-color: #cccccc"
                            class="style4">
                            ০২। স্বীকারোক্তিমূলক জবানবন্দি (অনুচ্ছেদ ০১ এর উপ-অনুচ্ছেদ (ক) বা (গ) এর ক্ষেত্রে
                            প্রযোজ্য। উপ-অনুচ্ছেদ (খ) এর ক্ষেত্রে “প্রযোজ্য নয়” লিখুন।)
                        </th>
                    </tr>
                    <tr>
                        <td class="style10" align="center" style="width: 5%">
                            <strong>ক্রমিক নং</strong>
                        </td>
                        <td class="style11" align="center" style="width: 30%">
                            <strong>আনীত অভিযোগ</strong>
                        </td>
                        <td class="style13" align="center" style="width: 33%">
                            <strong>স্বীকারোক্তিমূলক জবানবন্দি (প্রযোজ্য ক্ষেত্রে প্রয়োজনীয় ব্যাখ্যাসহ)</strong>
                        </td>
                        <td align="center" class="style15" style="width: 32%">
                            <strong>সুপারিশ (যদি থাকে)</strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" align="center" style="width: 5%; height: 100px">
                            <asp:TextBox ID="txtCount" runat="server" placeholder="Write Here" type="text" Width="100%"
                                ReadOnly="True">1</asp:TextBox>
                        </td>
                        <td class="style11" align="center" style="width: 30%; height: 100px">
                            <asp:TextBox ID="txtcharges" runat="server" placeholder="Write Here" type="text"
                                Width="100%" TextMode="MultiLine" MaxLength="499"></asp:TextBox>
                        </td>
                        <td class="style13" align="center" style="width: 33%; height: 100px">
                            <asp:TextBox ID="txtconfessions" runat="server" placeholder="Write Here" type="text"
                                Width="100%" TextMode="MultiLine" MaxLength="499"></asp:TextBox>
                        </td>
                        <td align="center" class="style15" style="width: 32%; height: 100px">
                            <asp:TextBox ID="txtrecommendation" runat="server" placeholder="Write Here" type="text"
                                Width="100%" TextMode="MultiLine" MaxLength="499"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="row">
                </div>
                <div>
                    <div style="text-align: left">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <p style="text-align: right; padding-right: 82px">
                            আপনার বিশ্বস্ত,
                            <br />
                            <p style="text-align: right; padding-right: 100px">
                                স্বাক্ষর
                            </p>
                            <p>
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
                        </p>
                    </div>
                    <div style="height: 15px">
                        প্রাপকঃ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtPrapok" style= "margin-left:7px" onkeypress="return isAlfa(event)" runat="server" placeholder="Enter Here" type="text" Width="250px"></asp:TextBox>
                        <br />
                        জনাব (তদন্ত কর্মকর্তা),<asp:TextBox ID="txtInvestigation_officer" runat="server"
                          onkeypress="return isAlfa(event)"  placeholder="Enter Here" type="text" Width="250px"></asp:TextBox>
                    </div>
                    <div style="height: 50px">
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="container-fluid" style="padding: 2%">
        <div style="height: 30px">
            <asp:Button ID="printButton" runat="server" Text="Print" Width="72px" Font-Bold="True"
                Style="float: right" OnClientClick="return PrintPanel();" />
            <%--  <asp:Button ID="btnSave" runat="server" Text="Save" Width="72px" Font-Bold="True"
                            Style="float: right"  />--%>
            <asp:Button ID="btnSave" runat="server" Font-Bold="True" Style="float: right" Text="Save"
                Width="72px" OnClick="btnSave_Click" />
        </div>
        <div class="col-sm-2">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
