<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="TurnoverTaxReturn_9_2, App_Web_pj2ymx2u" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%--<%@ Register assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="container-fluid">
    <div class="panel-group">
      <div class="panel panel-primary">
        <div class="panel-heading" style="text-align:center; font-size:21px; font-weight:bold; height:30px; padding-top:0px">টার্নওভার কর দাখিলপত্র (মূসক-৯.২)</div>
          <div class="panel-body" style="padding-top:0px; padding-bottom:10px">
             <div class="row" style="margin-top:1%">
               <div class="col-sm-2"></div>
                <div class="col-sm-4">
                    <fieldset class="scheduler-border-report" style="margin:0px; padding-bottom:01em">
                    <legend title="" class="scheduler-border-report">কর মেয়াদ</legend>
                    <div class="col-sm-6" style="padding:0px">
                     <asp:Label ID="Label2" runat="server" Text="Date From:" class="present-address-lbl"></asp:Label>
                     <ww:jQueryDatePicker ID="dtpDateFrom" runat="server" class="present-address-tb" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                    </div>
                    <div class="col-sm-6" style="padding:0px">
                     <asp:Label ID="Label1" runat="server" Text="Date To:" class="present-address-lbl"></asp:Label>
                     <ww:jQueryDatePicker ID="dtpDateTo" runat="server" class="present-address-tb" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                    </div>
                  </fieldset>
                </div>
                <div class="col-sm-4">
                     <asp:Button ID="btnShowReport" runat="server" style="margin-top: 20px;" onclick="btnShow_Click" Text="Show Report" CssClass="button" />
                     <asp:Button ID="btnPrint" runat="server" onclick="btnPrint_Click" Text="Print Report" CssClass="button" />
               </div> 
               <div class="col-sm-2"></div>     
           </div>
         </div>
       </div>
       <div class="panel panel-primary" style="width:80%; padding:1%">
           <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
             <div class="row" style="margin-top:1%">
                <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                <p style="text-align:center"><strong> জাতীয় রাজস্ব বোর্ড</strong></p>
                <p style="text-align:center;margin-left: 93px;"><strong>টার্নওভার কর দাখিলপত্র</strong> <b style="border:1px solid gray;margin-left: 25px;">মূসক-৯.২</b></p>
                <p style="text-align:center">[বিধি ৪৭ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
             </div>
             <div class="row" style="margin-top:1%">
                <table class="table table-bordered" style="width:98%">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align:center; background-color:#cccccc">অংশ-১: করদাতার তথ্য</th>
                </tr>
                
                    <tr>
                        <td class="td-width-30" scope="row">(১) করদাতার নাম</td>
                        <td class="td-width-2">:</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td scope="row">(২) ব্যবসায় সনাক্তকরণ সংখ্যা</td>
                        <td>:</td>
                        <td></td>
                    </tr>
                </table>
             </div>
             <div class="row" style="margin-top:1%">
                <table class="table table-bordered" style="width:98%">
                <tr>
                    <th colspan="3" style="text-align:center; background-color:#cccccc">অংশ-২: দাখিলপত্র জমার তথ্য</th>
                </tr>
                
                    <tr>
                        <td class="td-width-30">(১) কর মেয়াদ </td>
                        <td class="td-width-2">:</td>
                        <td>ত্রৈমাস                /            বৎসর </td>
                    </tr>
                    <tr>
                        <td>(২) দাখিলপত্রের প্রকার [অনুগ্রহ করে প্রযোজ্যটিতে টিক দিন এবং নির্দেশনা অনুসরণ করুন]  </td>
                        <td>:</td>
                        <td>
                           (ক) মূল দাখিলপত্র (ধারা ৬৪)                    <input type="checkbox"><br />
                            (খ) সংশোধিত দাখিলপত্র (ধারা ৬৬)              <input type="checkbox"><br />
                            (গ)পূর্ণ, অতিরিক্ত বা বিকল্প দাখিলপত্র(ধারা ৬৭)    <input type="checkbox">
                        </td>
                    </tr>
                    <tr>
                        <td class="td-width-30">(৩) বিগত করমেয়াদে কোনো কার্যক্রম সম্পন্ন হইয়াছে কি?</td>
                        <td class="td-width-2">:</td>
                        <td>
                            <input type="checkbox">হ্যাঁ   &nbsp &nbsp
                            <input type="checkbox">না<br />
                           [যদি ‘না’ হয় তাহলে অংশ-১, ২ এবং ৭ পূরণ করুন]
                        </td>
                    </tr>
                    <tr>
                        <td class="td-width-30">(৪) পেশের তারিখ
                                    [অনলাইনে দাখিলের ক্ষেত্রে তাৎক্ষণিকভাবে এবং ডাক বা সরাসরি দাখিলের ক্ষেত্রে প্রহণের তারিখ দাখিলপত্র জমার তারিখ হিসেবে বিবেচিত হইবে ।]
                        </td>
                        <td class="td-width-2">:</td>
                        <td>D	D	/	M	M	/	Y	Y	Y	Y</td>
                    </tr>
                </table>
             </div>
             <div class="row" style="margin-top:1%">
                <table class="table table-bordered" style="width:98%">
                <tr>
                    <th colspan="6" style="text-align:center; background-color:#cccccc">অংশ-৩: বিক্রয় তথ্য </th>
                </tr>
                <tr>
                    <th style="width:45%;text-align:center; background-color:#cccccc" colspan="2">আইটেম</th>
                    <th style="width:5%;text-align:center; background-color:#cccccc">নোট</th>
                    <th style="width:20%;text-align:center; background-color:#cccccc">মূল্য (ক)</th>
                    <th style="width:10%;text-align:center; background-color:#cccccc">হার</th>
                    <th style="width:20%;text-align:center; background-color:#cccccc">টার্নওভার কর (খ) </th>
                </tr>
                <tr>
                    <td rowspan="2">শূন্যহার বিশিষ্ট বিক্রয়</td>
                    <td>প্রচ্ছন্ন রপ্তানি</td>
                    <td class="td-width-5">১</td>
                    <td></td>
                    <td>০%</td>
                    <td></td>
                  </tr>
                  <tr>
                    <td>সরাসরি রপ্তানি</td>
                    <td>২</td>
                    <td></td>
                    <td>০%</td>
                    <td></td>
                  </tr>
                <tr>
                    <td colspan="2">অব্যাহতিপ্রাপ্ত বিক্রয় </td>
                    <td>৩</td>
                    <td></td>
                    <td>-</td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">আদর্শ হারের বিক্রয় </td>
                    <td>৪</td>
                    <td></td>
                    <td>৩%</td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">মোট টার্নওভার কর [৪খ]   </td>
                    <td>৫</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
             </div>
              <div class="row" style="margin-top:1%">
                <table class="table table-bordered" style="width:98%">
                <tr>
                    <th colspan="3" style="text-align:center; background-color:#cccccc">অংশ-৪: নীট প্রদেয় কর হিসাব </th>
                </tr>
                <tr>
                    <th style="width:55%;text-align:center; background-color:#cccccc">আইটেম</th>
                    <th style="width:10%;text-align:center; background-color:#cccccc">নোট</th>
                    <th style="width:35%;text-align:center; background-color:#cccccc">টার্নওভার কর (ক) </th>
                </tr>
                <tr>
                    <td>মোট টার্নওভার কর [৫] </td>
                    <td>৬</td>
                    <td></td>
                </tr>
                 <tr>
                    <td>মোট হ্রাসকারী সমন্বয় (বর্তমান করমেয়াদ) </td>
                    <td>৭</td>
                    <td></td>
                </tr>
                <tr>
                    <td>অন্যকোনো বৃদ্ধিকারী সমন্বয় </td>
                    <td>৮</td>
                    <td></td>
                </tr>
                <tr>
                    <td>অন্যকোনো হ্রাসকারী সমন্বয়</td>
                    <td>৯</td>
                    <td></td>
                </tr>
                <tr>
                    <td>অন্যকোনো হ্রাসকারী সমন্বয়</td>
                    <td>৯</td>
                    <td></td>
                </tr>
                <tr>
                    <td>বর্তমান করমেয়াদের জন্য মোট প্রদেয় টার্নওভার কর (৬-৭+৮-৯)</td>
                    <td>১০</td>
                    <td></td>
                </tr>
                <tr>
                    <td>আগাম কর</td>
                    <td>১১</td>
                    <td></td>
                </tr>
                <tr>
                    <td>আবগারি শুল্ক </td>
                    <td>১২</td>
                    <td></td>
                </tr>
                <tr>
                    <td>সারচার্জ </td>
                    <td>১৩</td>
                    <td></td>
                </tr>
                </table>
            </div>
            <div class="row" style="margin-top:1%">
                <table class="table table-bordered" style="width:98%">
                <tr>
                    <th colspan="4" style="text-align:center; background-color:#cccccc">অংশ-৫: কর পরিশোধের তফসিল</th>
                </tr>
                <tr>
                    <th style="text-align:center; background-color:#cccccc">আইটেম</th>
                    <th style="text-align:center; background-color:#cccccc">নোট</th>
                    <th style="text-align:center; background-color:#cccccc">অর্থনৈতিক কোড</th>
                    <th style="text-align:center; background-color:#cccccc">পরিমাণ</th>
                </tr>
                <tr>
                    <td>মোট কর (১০-১২)</td>
                    <td class="td-width-5">১৪</td>
                    <td>১/১১৩৩/অপারেশনাল কোড/০৩১১</td>
                    <td class="td-width-25"></td>
                </tr>
                <tr>
                    <td>আবগারি শুল্ক </td>
                    <td>১৫</td>
                    <td>১/১১৩৩/অপারেশনাল কোড/০৬০১</td>
                    <td></td>
                </tr>
                <tr>
                    <td>সারচার্জ </td>
                    <td>১৬</td>
                    <td>১/১১৩৩/অপারেশনাল কোড/২২১৪</td>
                    <td></td>
                </tr>
            </table>
            </div>
            <div class="row" style="margin-top:1%">
                <table class="table table-bordered" style="width:98%">
                <tr>
                    <th colspan="3" style="text-align:center; background-color:#cccccc">অংশ-৬: ঋণাত্মক নীট অর্থ জের টানা এবং ফেরত </th>
                </tr>
                <tr>
                    <td>ঋণাত্মক নীট অর্থ জের টানিবার জন্য বা ফেরতের জন্য টিক চিহ্ন দিন </td>
                    <td>১৭</td>
                    <td>
                        জের টানা  <input type="checkbox"> &nbsp &nbsp
                        নগদ ফেরত  <input type="checkbox"><br />
                        ফেরতদাবীর পরিমাণ  <input type="text" id="money" width="50px"> (টাকায়) 
                    </td>
                </tr>
            </table>
            </div>
            <div class="row" style="margin-top:1%">
                <table class="table table-bordered" style="width:98%">
                <tr>
                    <th colspan="3" style="text-align:center; background-color:#cccccc">অংশ-৭: ঘোষণা</th>
                </tr>
                <tr>
                   <td colspan="3">আমরা ঘোষণা করিতেছি যে, এই দাখিলপত্রে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল। </td> 
                </tr>
                <tr>
                    <td class="td-width-20">নাম</td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td class="td-width-20">পদবী </td>
                    <td class="td-width-40"></td>
                    <td rowspan="4"></td>
                </tr>
                <tr>
                    <td class="td-width-20">তারিখ </td>
                    <td class="td-width-40"></td>
                </tr>
                <tr>
                    <td class="td-width-20">মোবাইল নম্বর</td>
                    <td class="td-width-40"></td>
                </tr>
                <tr>
                    <td class="td-width-20">ইমেইল</td>
                    <td class="td-width-40"></td>
                </tr>
                <tr>
                    <td ></td>
                    <td ></td>
                    <td colspan="3" style="float:right">স্বাক্ষর </td>
                </tr>
            </table>
            </div>
          </div>
        </div>
    </div>
  </div>
</asp:Content>
