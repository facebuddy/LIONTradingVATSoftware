<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok_1_rpt, App_Web_o1josinq" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <%-- <link href="../../Styles/Main.css" rel="stylesheet" />--%>
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style10 {
            width: 116px;
        }

        .style11 {
            width: 195px;
        }

        .style13 {
            width: 221px;
        }

        .style14 {
            width: 318px;
        }

        .style15 {
        }

        .test {
            width: 183px;
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
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="container-fluid" style="padding: 2%">
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">&nbsp;
                    </th>
                </tr>
                <tr style="background-color: White">
                    <td class="td-width-30">পণ্যের নাম
                    </td>
                    <td class="td-width-2"></td>
                    <td>
                        <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                            <asp:DropDownList ID="drpDeclaretionNo" runat="server" Width="100%"
                                Height="25px">
                            </asp:DropDownList>
                        </div>
                        <div style="width: 29%; border: 1px; border-style: solid; float: right; font-weight: bold">
                            <asp:Button ID="btnReport" runat="server" Text="Report" Width="64px" OnClick="btnReport_Click" />
                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();"
                                Width="64px" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>


        <asp:Panel ID="pnlContents" runat="server">


            <div class="row">
                <p style="text-align: center">
                    গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
                    <br />
                      জাতীয় রাজস্ব বোর্ড, ঢাকা।
                </p>
                <p style="text-align: center">
                    উপকরণ/উৎপাদন সম্পর্ক বা সহগ ও মূল্যভিত্তি ঘোষণাপত্র
                </p>
                <p style="text-align: center">
                    [অনুচ্ছেদ ৫ এর উপ-অনুচ্ছেদ (৩) দ্রষ্টব্য ]
                </p>

              <%--  <p style="border: 1px solid #000; float: right; margin-right: 15px">
                    মূসক-<b><span lang="BN-BD">১</span></b>.
                </p>--%>
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
                            <asp:Label ID="lblTelephoneNumber" runat="server"
                                Text=""></asp:Label>
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




            <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse">

                <%--<tr style="background-color: White">
                
                        <th colspan="9"></th>
                
                        <th colspan="2">সম্পূরক শুল্ক আরোপ- যোগ্য মূল্য (যদি বিবেচ্য পণ্যের উৎপাদন পর্যায়ে সম্পূরক শুল্ক প্রযোজ্য থাকে) [কলাম (৭) ও (৯)] এর যোগফল) </th>
            
                
                        <th colspan="1"></th>
                        <th colspan="2">মূসক আরোপযোগ্য মূল্য [কলাম(১১)+কলাম(১২)][বিঃ দ্রঃ যেক্ষেত্রে স্থানীয় পর্যায়ে সম্পূরক শুল্ক প্রযোজ্য নয় সেক্ষেত্রে [কলাম(৭)+(৯)]]</th>
                        <th colspan="2">শুল্ক ও করসহ বিক্রয়মূল্য</th>


                
               
                
                         </tr>--%>

                <tr style="background-color: White">
                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>ক্রমিক সংখ্যা</strong>
                    </td>
                   <%-- <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>পণ্যের সামঞ্জস্যপূর্ণ নামকরণ কোড(H.S. Code)</strong></td>--%>
                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>পণ্যের নাম ও বিবরণ</strong></td>
                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>সরবরাহ / বিক্রয়ের একক</strong></td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>সিগারেট উৎপাদনে ব্যবহার্য উপকরণ/ কাঁচামাল এবং প্যাকিং সামগ্রীর নাম ও বিবরণ </strong></td>
                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong> উৎপাদনে ব্যবহার্য অপচয়সহ উপকরণ/ কাঁচামাল ও প্যাকিং সামগ্রীর পরিমাণ (অপচয়ের পরিমাণ প্রথম বন্ধনীর মধ্যে আলাদা ভাবে উল্লেখ করিতে হইবে)</strong></td>
                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>[কলাম (৫)] এ বর্ণিত উপকরণ বা প্যাকিং সামগ্রীর মূল্য (আমদানিকৃত হলে শুল্কায়নযোগ্য মূল্য + শুল্ক + সম্পূরক শুল্ক + এলসি ফি+অবকাঠামো উন্নয়ন সারচারজ /স্থানীয় উৎপাদিত হইলে সম্পূরক শুল্কসহ মোট ক্রয়মূল্য (প্রদত্ত মূসক ব্যতীত)/আবগারী পণ্য হইলে আবগারী শুল্কসহ মূট মূল্য/মূসক অব্যহতি প্রাপ্ত হইলে মোট ক্রয়মূল্য</strong>
                    </td>
                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>মূল্য সংযোজনের খাত/আইটেমের নাম </strong>
                    </td>
                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>প্রতি একক পণ্য মূল্যে [কলাম (৭)] এ উল্লেখিত প্রতিটি আইটেম বা খাতের অবদান/মূল্য সংযোজনের পরিমাণ </strong>
                    </td>
                    <td align="center" class="style15"
                        style="border-style: solid; border-width: 1px" colspan="2">
                        <strong>সম্পূরক শুল্ক আরোপ- যোগ্য মূল্য  [কলাম (৬) ও (৮)] এর যোগফল)</strong>





                    </td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>[কলাম(১০)] এ প্রস্তাবিত মুল্যের উপর সম্পূরক শুল্কের পরিমাণ</strong>
                    </td>
                    <td align="center" class="style15"
                        style="border-style: solid; border-width: 1px" colspan="2">

                        <strong>মূসক আরোপযোগ্য মূল্য [কলাম(১০)+কলাম(১১)]</strong>
                    </td>
                    <td align="center" class="style15"
                        style="border-style: solid; border-width: 1px" colspan="2">
                        <strong>শুল্ক ও করসহ বিক্রয়মূল্য</strong>
                    </td>

                </tr>

                <tr style="background-color: White">
                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px"></td>
                  
                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">বর্তমান</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">প্রস্তাবিত</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px"></td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">বর্তমান</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">প্রস্তাবিত</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">পাইকারী </td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">মুদ্রিত খুচরা মূল্য</td>

                </tr>


                <tr style="background-color: White">
                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">১</td>
                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                        <strong>২</strong>
                    </td>
                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">৩</td>
                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">৪</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">৫</td>
                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">৬</td>
                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">৭</td>
                    <td class="style14" align="center" style="width: 10%; border-style: solid; border-width: 1px">৮</td>
                    <td class="style13" align="center" style="width: 10%; border-style: solid; border-width: 1px">৯</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">১০</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">১১</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">১২</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">১৩</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">১৪</td>
                    <td align="center" class="style15" style="width: 10%; border-style: solid; border-width: 1px">১৫</td>
                   

                </tr>




                <tr style="background-color: White">
                    <asp:Label runat="server" ID="lblInfoShow"></asp:Label>
                </tr>
            </table>


            <div class="row">
                <p style="text-align: left">
                    ১। কলাম (৬),(৭) ও (৮) এ প্রদত্ত তথ্যের সমর্থনে অনুচ্ছেদ ১১ মোতাবেক বা প্রযোজ্য অন্যান্য প্রামানিক দলিলাদি এই ঘোষণা পত্রের সহিত সংযুক্ত করা হইয়াছে ।
                   <br />
                     ২। আমি এইমর্মে অঙ্গীকার করিতেছি যে, কর ধার্যের জন্য উপর্যুক্ত মূল্যভিত্তি সম্পর্কিত সকল তথ্য সত্য ও যথাযথ এবং ইহা নির্ধারণের সমর্থনে সকল দলিলাদি আমার এখতিয়ারে আছে।
                    <br />
                     ৩। উল্লিখিত বিধিমালার অনুচ্ছেদ ৪ এর উগাএতপ-অনুচ্ছেদ (৩) এ বর্ণিত পরিস্থিতির আলোকে মূল্য সংযোজন কর কর্তৃপক্ষ কর্তৃক পরিচালিত কোনো তদন্তে বা জরিপে উপরি-উক্ত ঘোষিত মূল্যভিত্তি অসংগতি পূর্ণ বা কম প্রতীয়মান হওয়ার
                    ক্ষেত্রে উক্ত কর্তৃপক্ষ কর্তৃক নির্ধারিত মূল্যভিত্তি অনুযায়ী ঘোষণা প্রদানের তারিখ হইতে প্রদেয় কর প্রদানে আমি বাধ্য থাকিব।

                     </p>
                <p style="text-align: right"> নিবন্ধিত সিগারেট উৎপাদনকারী প্রতিষ্ঠানের <br /> ব্যক্তি/ ব্যবস্থাপনা কর্তৃপক্ষের স্বাক্ষর/সিল
                </p>
                <p style="text-align: left">
                    তারিখ
                </p>

            </div>





            <div class="row">
                <p style="text-align: left">
                </p>
                <p style="text-align: left">
                    <%--  তারিখঃ&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtApplicationDate" runat="server" placeholder="Enter Here" onkeydown="return (event.keyCode!=13);"
                                onkeyup="FormatIt(this);" MaxLength="10" Width="90px"></asp:TextBox>--%>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtApplicationDate"
                                ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                ErrorMessage="Invalid date format." CssClass="litMessage" />--%>
                </p>
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
    <uc2:MsgBox ID="msgBox" runat="server" />
    <div class="col-sm-2">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </div>
    <%--<uc2:MsgBox ID="msgBox" runat="server"/>--%>
</asp:Content>
