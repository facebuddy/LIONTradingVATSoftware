<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="ValueAdditionPctwiseReport4_3s.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.ValueAdditionPctwiseReport4_3s" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />

        <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=print.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            //printWindow.document.write('</head><body style="margin: 20px;">');
            printWindow.document.write('</head><body style="margin: 20px;font-size:smaller;">');
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">

                    <div class="panel panel-body">
                        <div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="precisionTxtBox" runat="server"
                                ErrorMessage="Precision has to be a number between 0 to 12"
                                ForeColor="Red"
                                ValidationExpression="\d+">
                            </asp:RegularExpressionValidator>
                            <table class="table table-bordered" style="width: 100%">
                                <tr>
                                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc;">&nbsp;
                                    </th>
                                </tr>
                                <tr style="background-color: White">
                                    <td class="td-width-30">পণ্যের নাম
                                    </td>
                                    <td class="td-width-2"></td>
                                    <td>
                                        <div style="width: 60%; border: 1px; border-style: solid; float: left;">
                                            <asp:DropDownList ID="drpDeclaretionNo" runat="server" Width="100%" CssClass="select2"
                                                Height="25px">
                                            </asp:DropDownList>
                                        </div>
                                        <span>
                                            <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" min="0" max="8" style="width:80px"></asp:TextBox>
                                        </span>
                                        <div style="width: 20%; border: 1px; border-style: solid; float: right; font-weight: bold">
                                            <asp:Button ID="btnReport" runat="server" Text="Report"  CssClass="btn-btn" Style="background-color:#59BA68;"  OnClick="btnReport_Click" />
                                            <asp:Button ID="btnPrint" runat="server" Text="Print"  CssClass="btn-btn" Style="background-color:#65C2DD;" OnClientClick="return PrintPanel();" Width="64px" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                       <div runat="server" id="print">
                       <div runat="server" id="divTobacco">
                            <asp:Panel ID="Panel1" runat="server">


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
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
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
            <table  border="1" class="table-bordered" style="width: 100%;">

               
                <tr  style="background-color: White">
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
                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">২</td>
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
                    <asp:Label runat="server" ID="lblInfoShowtobacco"></asp:Label>
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
                        <asp:Label runat="server" ID="Label5" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                    </div>
                </div>
            </div>
        </asp:Panel>
                        </div>                         
                       <div runat="server" id="divOther">        
               
        <asp:Panel ID="pnlContents" runat="server" style="font-family:Nikosh">
                            <div class="col-md-12">
                               
                                    <%--<div class="row" style="font-size:16px">
                                        <p style="text-align: center">
                                            গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
                                        </p>

                                        <p style="text-align: center">
                                            জাতীয় রাজস্ব বোর্ড 
                                        </p>
                                      

                                    </div>--%>

                           <table style="border:none;width: 100%;">
                               <tr>
                                   <td style="visibility:collapse;">yesaugrsursrf</td>
                                   <td>
                                         <p style="text-align:center; font-size:12px; margin:2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                                         <p style="text-align:center; font-size:12px; margin:2px;">জাতীয় রাজস্ব বোর্ড</p>
                                         <p style="text-align:center; font-size:12px; margin:2px;font-weight:bold;"> উপকরণ-উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা </p>                                                            
                                         <p style="text-align:center; font-size:12px; margin:2px;">বিধি (২১) দ্রষ্টব্য</p>
                                   </td>

                                   <td>
                                        <p style="text-align:right;">
                                        <b style="border:1px solid gray;">মূসক-৪.৩</b></p> 

                                   </td>
                               </tr>
                           </table>  


                                  <%--  <div style="font-size:12px">--%>
                                <div>
                                    <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse;background-color:white">
                                        <thead>
                                            <tr style="border: 1px solid #000">
                                                <td colspan="12" style="font-weight: normal">

                                                    <%--<p style="text-align: right;font-size:11px;font-weight:bold;">মূসক-৪.৩</p>--%>

                                                    <center>
                                                        <%--<h4 style="font-weight: normal">
                                                           <p style="font-size:16px;font-weight:bold;"> উপকরণ-উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা </p>                                                            
                                                            <p>বিধি (২১) দ্রষ্টব্য</p>
                                                           </h4>--%>

                                                        
                                                           <%--<p style="font-weight:bold;margin-bottom:unset;"> উপকরণ-উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা </p>                                                            
                                                            <p>বিধি (২১) দ্রষ্টব্য</p>--%>
                                                           

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

                                            <%--<tr style="background-color:white;text-align:center">
                                                <th rowspan="2" style="font-weight: normal;background-color:white;text-align:center">ক্রমিক সংখ্যা</th>
                                                <th rowspan="2" style="font-weight: normal;background-color:white;text-align:center">পণ্যের এইচ এস কোড/ সেবা কোড</th>
                                                <th rowspan="2" style="font-weight: normal;background-color:white;text-align:center">সরবরাহতব্য পণ্য/সেবার নাম ও বর্ণনা (প্রযোজ্যক্ষেত্রে ব্র্যান্ড নামসহ)</th>
                                                <th rowspan="2" style="font-weight: normal;background-color:white;text-align:center">সরবরাহের একক</th>
                                                <th colspan="5" style="font-weight: normal;background-color:white;text-align:center">একক পণ্য/সেবা সরবরাহে ব্যবহার্য যাবতীয় উপকরণ/ কাঁচামালের ও প্যাকিং সামগ্রীর বিবরণ ,পরিমান,ও ক্রয় মূল্য (উপকরণভিত্তিক অপচয়ের শতকরা হারসহ)</th>
                                                <th colspan="2" style="font-weight: normal;background-color:white;text-align:center">মূল্য সংযোজনের বিবরণ</th>
                                                <th rowspan="2" style="font-weight: normal;background-color:white;text-align:center">মন্তব্য</th>
                                            </tr>--%>

                                            <tr style="background-color:white;text-align:center;font-size:12px;">
                                                <th rowspan="2" class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">ক্রমিক সংখ্যা</th>
                                                <th rowspan="2" class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">পণ্যের এইচ এস কোড/ সেবা কোড</th>
                                                <th rowspan="2" class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">সরবরাহতব্য পণ্য/সেবার নাম ও বর্ণনা (প্রযোজ্যক্ষেত্রে ব্র্যান্ড নামসহ)</th>
                                                <th rowspan="2" class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">সরবরাহের একক</th>
                                                <th colspan="5" class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">একক পণ্য/সেবা সরবরাহে ব্যবহার্য যাবতীয় উপকরণ/ কাঁচামালের ও প্যাকিং সামগ্রীর বিবরণ ,পরিমান,ও ক্রয় মূল্য (উপকরণভিত্তিক অপচয়ের শতকরা হারসহ)</th>
                                                <th colspan="2" class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মূল্য সংযোজনের বিবরণ</th>
                                                <th rowspan="2" class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মন্তব্য</th>
                                            </tr>

                                            <tr style="background-color:white;text-align:center;font-size:12px;">
                                                <%--<th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>--%>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">বিবরণ</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">অপচয়সহ পরিমান</th>
                                                <th class="col_5_percent" style="font-weight: normal;background-color:white;text-align:center">ক্রয়মূল্য</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">অপচয়ের পরিমান</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">শতকরা হার</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মূল্য সংযোজনের খাত</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মূল্য</th>
                                                <%--<th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>--%>
                                            </tr>

                                        </thead>
                                        <tbody style="font-size:11px;">
                                            <%--<tr style="background-color:white;text-align:center">
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">বিবরণ</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">অপচয়সহ পরিমান</th>
                                                <th class="col_5_percent" style="font-weight: normal;background-color:white;text-align:center">ক্রয়মূল্য</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">অপচয়ের পরিমান</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">শতকরা হার</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মূল্য সংযোজনের খাত</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center">মূল্য</th>
                                                <th class="col_3_percent" style="font-weight: normal;background-color:white;text-align:center"></th>
                                            </tr>--%>
                                            <tr style="background-color:white;text-align:center;">
                                                <td>(১)</td>
                                                <td>(২)</td>
                                                <td>(৩)</td>
                                                <td>(৪)</td>
                                                <td>(৫)</td>
                                                <td>(৬)</td>
                                                <td>(৭)</td>
                                                <td>(৮)</td>
                                                <td>(৯)</td>
                                                <td>(১০)</td>
                                                <td>(১১)</td>
                                                <td>(১২)</td>

                                            </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblInfoShow" />
                                            </tr>
                                        </tbody>
                                    </table>
                             <%--       <div runat="server" id="signatureDiv" visible="false">
                                        <div class="row" style="margin-top: 5px;">
                                            <div class="col-sm-4">
                                                <asp:Label Style="float: right" runat="server" Text="প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যক্তির নাম: "></asp:Label>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label id="lblDutyOfficerName" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 5px;">
                                            <div class="col-sm-4">
                                                <asp:Label Style="float: right" runat="server" Text="পদবী: "></asp:Label>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label id="lblDutyOfficerDesignation" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 5px;">
                                            <div class="col-sm-4">
                                                <asp:Label Style="float: right" runat="server" Text="সাক্ষর: "></asp:Label>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label id="clientsign" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 5px;">
                                            <div class="col-sm-4">
                                                <asp:Label Style="float: right" runat="server" Text="সীল: "></asp:Label>
                                            </div>
                                            <div class="col-sm-8">
                                                <asp:Label id="clientStamp" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>--%>





                                    <div runat="server" id="signatureDiv" visible="false" style="padding-left:80px;">
                                        <table style="border:hidden;">
                                            <tr>
                                                <td style="float:right;"><asp:Label Style="float: right" runat="server" Text="প্রতিষ্ঠানের দায়িত্বপ্রাপ্ত ব্যক্তির নাম: "></asp:Label></td>
                                                <td>&nbsp&nbsp&nbsp</td>
                                                <td><asp:Label style="font-size:12px;" id="lblDutyOfficerName" runat="server"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td style="float:right;"><asp:Label Style="float: right" runat="server" Text="পদবী: "></asp:Label></td>
                                                <td>&nbsp&nbsp&nbsp</td>
                                                <td><asp:Label style="font-size:12px;" id="lblDutyOfficerDesignation" runat="server"></asp:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td style="float:right;"><asp:Label Style="float: right" runat="server" Text="সাক্ষর: "></asp:Label></td>
                                                <td>&nbsp&nbsp&nbsp</td>
                                                <td><asp:Label id="clientsign" runat="server"></asp:Label></td>
                                            </tr>
                                                                                      
                                            <tr>
                                                <td style="float:right;"><asp:Label Style="float: right" runat="server" Text="সীল: "></asp:Label></td>
                                                <td>&nbsp&nbsp&nbsp</td>
                                                <td><asp:Label id="clientStamp" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>



                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group form-group-sm" style="font-size:9px;">
                                                <label class="control-label">বিশেষ দ্রষ্টব্য :</label> <br />

                                                <label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;১| যেকোনো পণ্য বা সেবা প্রথম সরবরাহের পূর্ববর্তী পনেরো কার্যদিবসের মধ্যে অনলাইনে মূসক কম্পিউটার সিস্টেমে বা সংশ্লিষ্ট বিভাগীয় কর্মকর্তার দপ্তরে উপকরণ-উৎপাদ সহগ সহজ ঘোষণা দাখিল করতে হইবে।
                             <br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;২| পণ্য মূল্য বা মোট উপকরণ /কাঁচামালের মূল্য ৭.৫% এর বেশি পরিবর্তন হইলে নতুন ঘোষণা দাখিল করিতে হইবে।
                             <br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;৩| উপকরণ ক্রয়ের স্বপক্ষে প্রামাণিক দলিল হিসাবে বিল অব এট্রি বা চালানপত্রের কপি সংযুক্ত করিতে হইবে।
                                                </label>

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
                       </div>
                     <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>
                        <uc1:MsgBoxs runat="server" ID="msgBox" />
                    </div>
                </div>
            </div>






        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

