<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok_1_rpt_KHA, App_Web_y1tsx4fu" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <%-- <link href="../../Styles/Main.css" rel="stylesheet" />--%>
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />

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
    <asp:UpdatePanel runat="server" ID="mqmm">
        <ContentTemplate>
            <div class="panel panel-group">
                <div class="panel panel-primary">
                    <div class="panel panel-heading text-center">
                        <b>মূসক - ১(খ)</b>
                    </div>
                    <div class="panel panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">পণ্যের নাম :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlProductName" runat="server" CssClass="form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">মূল্য ঘোষণাপত্র নম্বর : </label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlPriceDeclarationNo" runat="server" CssClass="form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlPriceDeclarationNo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:LinkButton ID="btnShowReport" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnShowReport_Click"><i class="fa fa-search-plus"></i> Show Report</asp:LinkButton>
                                <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info btn-sm" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i> Print</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:Panel ID="pnlContents" runat="server">


                            <div class="row">
                                <p style="text-align: center">
                                    গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
                                </p>
                                <p style="text-align: center">জাতীয় রাজস্ব বোর্ড  </p>
                                <p style="text-align: center">ঢাকা।</p>
                                <p style="text-align: center">
                                    ব্যবসা বা বাণিজ্যিক আমদানিকারক কর্তৃক মূল্যভিত্তি ঘোষণাপত্র
                                </p>
                                <p style="text-align: center">
                                    [বিধি ৩(১) দ্রষ্টব্য ]
                                </p>

                                <p style="border: 1px solid #000; float: right; margin-right: 15px">
                                    মূসক-<b><span lang="BN-BD">১খ</span></b>.
                                </p>
                            </div>
                            <div class="row">

                                <table style="width: 90%; margin: 14px; border: 0px">

                                    <tr style="background-color: White">

                                        <td style="width: 20%">১. নিবন্ধিত ব্যক্তির নাম :</td>

                                        <td style="width: 30%">
                                            <asp:Label ID="lblNibondhitoBektirName" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">৫. মূল্য ঘোষণা নম্বর :</td>

                                        <td style="width: 29%">
                                            <asp:Label ID="lblMulloGhoshonaNumber" runat="server" Text=""></asp:Label>
                                            /
                                            <asp:Label ID="lblYear" runat="server" Text=""></asp:Label></td>

                                    </tr>

                                    <tr style="background-color: White">

                                        <td style="width: 20%">২. ঠিকানা :</td>

                                        <td style="width: 30%">
                                            <asp:Label ID="lblThikana" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">৬. টেলিফোন নম্বর :</td>

                                        <td style="width: 29%">
                                            <asp:Label ID="lblTelephoneNumber" runat="server" Text=""></asp:Label>
                                        </td>

                                    </tr>

                                    <tr style="background-color: White">

                                        <td style="width: 20%">৩. নিবন্ধন সংখ্যা :</td>

                                        <td style="width: 30%">
                                            <asp:Label ID="lblNibondhonShonkha" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">৭. ফ্যাক্স নম্বর :</td>

                                        <td style="width: 29%">
                                            <asp:Label ID="lblFaxNumber" runat="server" Text=""></asp:Label>
                                        </td>

                                    </tr>

                                    <tr style="background-color: White">

                                        <td style="width: 20%">৪. সার্কেল কোড :</td>

                                        <td style="width: 30%">
                                            <asp:Label ID="lblElakaCode" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td style="width: 20%">&nbsp;</td>

                                        <td style="width: 29%">&nbsp;</td>

                                    </tr>
                                </table>
                            </div>
                            <table border="1" class="table table-bordered" style="width: 100%; border-style: solid; border-collapse: collapse">
                                <tr style="background-color: White">
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">ক্রমিক সংখ্যা</td>
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">পণ্যের সামঞ্জস্যপূর্ণ নামকরণ কোড(H.S. Code)</td>
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">পণ্যের নাম ও বিবরণ (আমদানী দলিল বা ক্রয় চালানপত্র মোতাবেক) </td>
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">পণ্যের ক্রয় মূল্য (মূল্য সংযোজন কর বা আগাম আয়কর ব্যতীত)</td>
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">মূল্য সংযোজনের পরিমাণ </td>
                                    <td colspan="2" style="width: 10%; border-style: solid; border-width: 1px">সম্পূরক শুল্ক আরোপযোগ্য মূল্য</td>
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">আরোপনীয় সম্পূরক শুল্ক (যদি থাকে)</td>
                                    <td colspan="2" style="width: 10%; border-style: solid; border-width: 1px">মূল্য সংযোজন কর আরোপযোগ্য মূল্য </td>
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">পাইকারী মূল্য  </td>
                                    <td rowspan="2" style="width: 10%; border-style: solid; border-width: 1px">খুচরা মূল্য/ মুদ্রিত মূল্য</td>
                                </tr>



                                <tr style="background-color: White">
                                    <td style="width: 10%; border-style: solid; border-width: 1px; text-align: center;">বর্তমান</td>
                                    <td style="width: 10%; border-style: solid; border-width: 1px; text-align: center">প্রস্তাবিত </td>
                                    <td style="width: 10%; border-style: solid; border-width: 1px; text-align: center">বর্তমান  </td>
                                    <td style="width: 10%; border-style: solid; border-width: 1px; text-align: center">প্রস্তাবিত </td>
                                </tr>

                                <tr style="background-color: White">

                                    <td style="width: 10%; text-align: center;">(১)</td>
                                    <td style="width: 10%; text-align: center;">(২)</td>
                                    <td style="width: 10%; text-align: center;">(৩)</td>
                                    <td style="width: 10%; text-align: center;">(৪)</td>
                                    <td style="width: 10%; text-align: center;">(৫)</td>
                                    <td style="width: 10%; text-align: center;">(৬)</td>
                                    <td style="width: 10%; text-align: center;">(৭)</td>
                                    <td style="width: 10%; text-align: center;">(৮)</td>
                                    <td style="width: 10%; text-align: center;">(৯)</td>
                                    <td style="width: 10%; text-align: center;">(১০)</td>
                                    <td style="width: 10%; text-align: center;">(১১)</td>
                                    <td style="width: 10%; text-align: center;">(১২)</td>
                                </tr>
                                <tr style="background-color: White">
                                    <asp:Label runat="server" ID="lblInfoShow"></asp:Label>
                                </tr>
                            </table>


                            <div class="row">
                                <p style="text-align: left">
                                    আমি এই মর্মে ঘোষণা করিতেছি যে, উপরে বর্ণিত সকল তথ্য সত্য ও নির্ভুল ।
                                </p>
                                <p style="text-align: left">
                                    তারিখঃ 
                                </p>
                                <p style="text-align: right">
                                    স্বত্বাধিকারী, নিবন্ধিত ব্যক্তি বা ক্ষমতাপ্রাপ্ত প্রতিনিধির স্বাক্ষর
                                </p>

                            </div>

                            <div class="row">
                                <p style="text-align: left; font-weight: bold">
                                    নিবন্ধিত ব্যক্তির জন্য নির্দেশাবলীঃ 
                                </p>
                                <p style="text-align: left">
                                    ১)     আমদানি দলিল ক্রয় চালানপত্রে পণ্যের বিবরণ স্পষ্ট না হইলে উক্ত বিবরণের নিচে পণ্যটি যে নামে (সাইজ/গ্রেড/মডেল উল্লেখসহ) একজন ব্যবহারকারীর নিকত পরিচিত তা          
                                            (৩) নং কলামে উল্লেখ করিতে হইবে এবং প্রতিটি ঘোষণার সংশ্লিষ্ট আমদানি দলিল বা ক্রয় চালানপত্রেভ নম্বর ও তারিখ উল্লেখ করিতে হইবে ।
                                </p>
                                <p style="text-align: left">
                                    ২)    সংশ্লিষ্ট পণ্যের আমদানি দলিল বা ক্রয় চালানপত্রের মূল্য সংযোজন কর ও আগাম আয়কর ব্যতীত যে মূল্য (যাবতীয় শুল্ক করসহ) উল্লেখ থাকিবে তার সাথে অন্য কোনো
                                            রেয়াতযোগ্য উপকরণ ব্যবহৃত হইলে তা পরবর্তী সারি (Row)  তে (৩) নং কলামে বিবরণসহ মূল্য প্রদর্শন সাপেক্ষে (৪) নং কলামে যোগ করিতে হইবে ।
                                </p>

                                <p style="text-align: left">
                                    ৩)    ক্রয় মূল্যের সমর্থনে মূল্য ঘোশণার সাথে আমদানি দলিল বা ক্রয় চালানপত্রের ফটোকপি সংযুক্ত করিতে হইবে ।

                                </p>

                                <p style="text-align: left">
                                    ৪)    (৫) নং কলামে প্রদর্শিত সংযোজনের ভিত্তিতে ১৫% হারে নীট মূল্য সংযোজন কর প্রদেয় হইবে ।
                                </p>


                                <p style="text-align: left">
                                    ৫)    (৮) নং কলামে প্রস্তাবিত মূল্য বা বিভাগীয় কর্মকর্তা কর্তৃক অনুমোদিত মূল্যের (যেটি প্রযোজ্য) ভিত্তিতে ১৫% হারে মূসক নিরূপণ পূর্বক কর পরিশোধিত মূল্যের চেয়ে মূল্য 
                                             ঘোষণা দাখিলকারীর বিক্রয় মূল্য কোনো অবস্থাতেই বেশি হইবে না ।
                                </p>
                            </div>
                            <div class="col-md-12" style="margin-top: 5px">
                                <div class="form-group form-group-sm">
                                    <asp:Label runat="server" Text="System User: "></asp:Label>
                                    <asp:Label runat="server" ID="lblUser"></asp:Label>
                                    <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                    <asp:Label runat="server" ID="Label1" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                </div>
                            </div>


                        </asp:Panel>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>




    <div class="container-fluid" style="padding: 2%">
        <div>
            <%--<table class="table table-bordered" style="width: 100%">
                    <tr>
                        <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                            &nbsp;
                        </th>
                    </tr>
                    <tr style="background-color: White">
                        <td class="td-width-30">
                            পণ্যের নাম
                        </td>
                        <td class="td-width-2">
                        </td>
                        <td>
                            <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                                <asp:DropDownList ID="drpDeclaretionNo" runat="server" Width="100%" 
                                    Height="25px">
                                </asp:DropDownList>
                            </div>
                            <div style="width: 29%; border: 1px; border-style: solid; float: right; font-weight: bold">
                                <asp:Button ID="btnReport" runat="server" Text="Report" Width="64px" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();"
                                    Width="64px" />
                            </div>
                        </td>
                    </tr>
                </table>--%>
        </div>



    </div>
    </div>
        
    <div class="col-sm-2">
    </div>
    <%--<uc2:MsgBox ID="msgBox" runat="server"/>--%>
</asp:Content>
