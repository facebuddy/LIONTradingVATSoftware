<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="rptMushok1GHAA, App_Web_xijeoyc2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
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
    <div class="container-fluid">
        <asp:UpdatePanel runat="server" ID="mqmm">
            <ContentTemplate>
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel panel-heading text-center">
                            <b>মূসক - ১(ঘ)</b>
                        </div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পণ্যের নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlProductName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">মূল্য ঘোষণাপত্র নম্বর : </label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlPriceDeclarationNo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPriceDeclarationNo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnShowReport" CssClass="btn btn-info btn-sm" runat="server" Text="Show Report" OnClick="btnShowReport_Click" />
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="pnlContents" runat="server">


                            <div class="row">
                                <p style="text-align: center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                                <p style="text-align: center; margin-top: -1%">জাতীয় রাজস্ব বোর্ড </p>
                                <p style="text-align: center; margin-top: -1%">ঢাকা।</p>
                                <p style="text-align: center; margin-top: -1%">
                                    পণ্যের গায়ে/ধারকে/পাত্রে/মোড়কে মুদ্রিত খুচরা মূল্যের ক্ষেত্রে মূল্য ঘোষণা 
                                </p>
                                <p style="text-align: center; margin-top: -1%">
                                    [বিধি ৩(১) দ্রষ্টব্য ]
                                </p>

                                <p style="border: 1px solid #000; float: right; margin-right: 15px">
                                    মূসক-<b><span lang="BN-BD">১ঘ </span></b>.
                                </p>
                            </div>
                            <div class="row">

                                <table style="width: 90%; margin: 14px; border: 0px">

                                    <tr style="background-color: White">

                                        <td style="width: 25%">নিবন্ধিত ব্যক্তির নাম:</td>

                                        <td style="width: 35%; text-align: left">
                                            <asp:Label ID="lblOrganizationOwnerName" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">মূল্য ঘোষণা নম্বর:</td>

                                        <td style="width: 20%">
                                            <asp:Label ID="lblPriceDeclarationNo" runat="server" Text=""></asp:Label>
                                            /
                                        <asp:Label ID="lblYear" runat="server" Text=""></asp:Label></td>

                                    </tr>

                                    <tr style="background-color: White" runat="server" visible="false">

                                        <td style="width: 25%">প্রতিষ্ঠানের নাম:</td>

                                        <td style="width: 35%">
                                            <asp:Label ID="lblOrganizationName" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">এলাকা কোড:</td>

                                        <td style="width: 20%">
                                            <asp:Label ID="lblAreaCode" runat="server" Text=""></asp:Label>
                                        </td>

                                    </tr>

                                    <tr style="background-color: White">

                                        <td style="width: 25%">পূর্ণ ব্যবসায়িক ঠিকানা:</td>

                                        <td style="width: 35%">
                                            <asp:Label ID="lblOrganizationAddress" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">টেলিফোন নম্বর: </td>

                                        <td style="width: 20%">
                                            <asp:Label ID="lblTelephoneNo" runat="server" Text=""></asp:Label>
                                        </td>

                                    </tr>

                                    <tr style="background-color: White">

                                        <td style="width: 25%">নিবদ্ধন নম্বর:</td>

                                        <td style="width: 35%">
                                            <asp:Label ID="lblOrganizationBIN" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">ফ্যাক্স নম্বর:</td>

                                        <td style="width: 20%">
                                            <asp:Label ID="lblFaxNo" runat="server" Text=""></asp:Label></td>

                                    </tr>


                                </table>



                            </div>




                            <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse">

                                <tr style="background-color: White">
                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>ক্র: নং</strong>
                                    </td>
                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>পণ্যের সামঞ্জস্যপূর্ণ নামকরণ কোড(H.S. Code)</strong></td>
                                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>পণ্যের নাম ও বিবরণ</strong></td>
                                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>সরবরাহ / বিক্রয়ের একক</strong></td>
                                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>উৎপাদনে ব্যবহৃত কাঁচামালের নাম</strong></td>
                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>প্রতি একক পণ্য উৎপাদনে ব্যবহৃত কাঁচামালের [পরিমান ও মূল্য] (অপচয়ের পরিমাণ প্রথম বন্ধনীর মধ্যে আলাদা ভাবে উল্লেখ করিতে হইবে)</strong></td>
                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>গায়ে/ধারকে/মোড়কে মুদ্রিত মূল্য </strong>
                                    </td>
                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>উৎপাদনকারী কর্তৃক নির্ধারিত মূসক আরোপযোগ্য মূল্য</strong>
                                    </td>
                                </tr>

                                <tr style="background-color: White">
                                    <td style="width: 10%; text-align: center">(১)</td>
                                    <td style="width: 10%; text-align: center">(২)</td>
                                    <td style="width: 10%; text-align: center">(৩)</td>
                                    <td style="width: 10%; text-align: center">(৪)</td>
                                    <td style="width: 10%; text-align: center">(৫)</td>
                                    <td style="width: 10%; text-align: center">(৬)</td>
                                    <td style="width: 10%; text-align: center">(৭)</td>
                                    <td style="width: 10%; text-align: center">(৮)</td>
                                </tr>

                                <tr style="background-color: White">
                                    <asp:Label runat="server" ID="lblInfoShow"></asp:Label>
                                </tr>
                            </table>


                            <div class="row">
                                <p style="text-align: left">
                                    আমি এই মর্মে ঘোষণা করিতেছি যে,<br>
                                    ১।  উপরে বর্ণিত সকল তথ্য সত্য ও নির্ভুল এবং ইহা নির্ধারণের অনুকূলে সকল দলিলাদি আমার হেফাজতে আছে ;<br>
                                    ২। উৎপাদন পর্যায়ে মূসক আরোপযোগ্য মূল্য উপরে বর্ণিত পণ্যের গায়ে/ ধারাকে/ মোড়কে মুদ্রিত মূল্যের দুই-তৃতীয়াংশের কম নয়;<br>
                                    ৩।  উল্লিখিত বিধিমালার বিধি (৩)-এ বর্ণিত পরিস্থিতির আলোকে মূল্য সংযোজন কর কর্তৃপক্ষ কর্তৃক পরিচালিত কোনো তদন্তে বা 
                                জরিপে উপরিউক্ত ঘোষিত মূল্য অসঙ্গতিপূর্ণ বা কম প্রতীয়মান হওয়ার ক্ষেত্রে উক্ত কর্তৃপক্ষ কর্তৃক নির্ধারিত মূলভিত্তি অনুযায়ী ঘোষণা 
                                প্রদানের তারিখ হইতে কর প্রদানে আমি বাধ্য থাকিব। 
                                </p>
                                <p style="text-align: left">
                                </p>
                                <p style="text-align: left">
                                </p>

                            </div>
                            <div class="row" style="padding-left: 15px; padding-right: 10px">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 70%; text-align: left">তারিখ:
                                            <asp:Label runat="server" ID="lblDate" /></td>
                                        <td style="width: 30%; text-align: center">নিবন্ধিত ব্যক্তি, সত্ত্বাধীকারী বা ক্ষমতাপ্রাপ্ত প্রতিনিধির স্বাক্ষর</td>
                                    </tr>
                                </table>
                            </div>
                            <div class="row">
                                <div class="col-md-12" style="margin-top: 5px">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="System User: "></asp:Label>
                                        <asp:Label runat="server" ID="lblUser"></asp:Label>
                                        <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                        <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
