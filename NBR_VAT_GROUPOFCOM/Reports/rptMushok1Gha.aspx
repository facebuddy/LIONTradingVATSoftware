<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="rptMushok1Gha, App_Web_pj2ymx2u" %>

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
                            <b>মূসক - ১(গ)</b>
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
                                    অব্যাহতিপ্রাপ্ত অথবা বাংলাদেশ হইতে রপ্তানিকৃত বা রপ্তানিকৃত বলিয়া গণ্য পণ্যের উপকরণ মূল্য ও উপকরণ-উৎপাদ সম্পর্ক বা সহগ ঘোষণাপত্র
                                </p>
                                <p style="text-align: center; margin-top: -1%">
                                    [বিধি ৩(১) দ্রষ্টব্য ]
                                </p>

                                <p style="border: 1px solid #000; float: right; margin-right: 15px">
                                    মূসক-<b><span lang="BN-BD">১গ </span></b>.
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

                                    <tr style="background-color: White">

                                        <td style="width: 25%">প্রতিষ্ঠানের নাম:</td>

                                        <td style="width: 35%">
                                            <asp:Label ID="lblOrganizationName" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">এলাকা কোড:</td>

                                        <td style="width: 20%">
                                            <asp:Label ID="lblAreaCode" runat="server"
                                                Text=""></asp:Label>
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
                                        <strong>পণ্য উৎপাদনে ব্যবহার্য উপকরণ/ কাঁচামাল এবং প্যাকিং সামগ্রীর নাম ও বিবরণ </strong></td>
                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>একক পণ্য উৎপাদনে ব্যবহার্য উপকরণ/ কাঁচামাল ও প্যাকিং সামগ্রীর পরিমাণ (অপচয়ের পরিমাণ প্রথম বন্ধনীর মধ্যে আলাদা ভাবে উল্লেখ করিতে হইবে)</strong></td>
                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>[কলাম (৬)] এ বর্ণিত উপকরণ বা প্যাকিং সামগ্রীর মূল্য (আমদানিকৃত হলে শুল্কায়নযোগ্য মূল্য + শুল্ক + সম্পূরক শুল্ক + এলসি ফি+অবকাঠামো উন্নয়ন সারচারজ /স্থানীয় উৎপাদিত হইলে সম্পূরক শুল্কসহ মোট ক্রয়মূল্য (প্রদত্ত মূসক ব্যতীত)/আবগারী পণ্য হইলে আবগারী শুল্কসহ মূট মূল্য/মূসক অব্যহতি প্রাপ্ত হইলে মোট ক্রয়মূল্য</strong>
                                    </td>
                                </tr>

                                <tr style="background-color: White">
                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">(১)</td>
                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">(২)</td>
                                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">(৩)</td>
                                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">(৪)</td>
                                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">(৫)</td>
                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">(৬)</td>
                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">(৭)</td>
                                </tr>

                                <tr style="background-color: White">
                                    <asp:Label runat="server" ID="lblInfoShow"></asp:Label>
                                </tr>
                            </table>


                            <div class="row">
                                <p style="text-align: left">
                                    ১।  কলাম (৭) এ প্রদত্ত তথ্যের সমর্থনে প্রামানিক দলিলাদি এই ঘোষণা পত্রের সহিত সংযুক্ত করা হইয়াছে ।<br>
                                    ২। আমি এইমর্মে ঘোষণা করিতেছি যে, এই ঘোষণাপত্রে উল্লেখিত সকল তথ্য সত্য ও সঠিক। 
                                </p>
                                <p style="text-align: left">
                                </p>
                                <p style="text-align: left">
                                </p>

                            </div>
                            <div class="row" style="padding-left: 15px; padding-right: 10px">
                                <table style="width:100%">
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
