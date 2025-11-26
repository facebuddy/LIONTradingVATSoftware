<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Musok9_2, App_Web_pj2ymx2u" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
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
    <style>
        .m
        {
            text-align:right;
            padding-right:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-primary">
        <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">টার্নওভার কর দাখিলপত্র (মূসক-৯.২)</div>
        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
            <div class="row" style="margin-top: 0.5%">
                <div class="col-md-12">
                    <div class="form-group form-group-sm">
                        <div class="col-md-4">
                            <label class="col-sm-4 comntrol-label">Date From :</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateFrom" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />
                            </div>

                        </div>
                        <div class="col-md-4">
                            <label class="col-sm-3 comntrol-label">Date To :</label>
                            <div class="col-sm-9">
                                <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateTo" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                            </div>

                        </div>
                        <div class="col-md-4">
                            <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success btn-sm"><i class="fa fa-search-plus"></i>  Report</asp:LinkButton>
                            <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                            <asp:LinkButton ID="btnXMLFormat" runat="server" CssClass="btn btn-info btn-sm"><i class="fa fa-search-plus"></i>  XML Data</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div id="reportMain" class="container-fluid" style="padding: 2%;" runat="server" visible="true">
        <div class="row">
            <p style="text-align: center">
                গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
            </p>
            <p style="text-align: center; margin-top: -1%;">জাতীয় রাজস্ব বোর্ড</p>
            <br/>
            <p style="text-align: center; margin-top: -1%;"><strong>টার্নওভার কর দাখিলপত্র</strong></p>
            
            <p style="text-align: center">[বিধি ৪৭ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
            <p style="border: 1px solid #000; float: right; margin-right: 15px; padding: 2px"><strong>মূসক-৯.২</strong></p>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" scope="colgroup" style="text-align: center; background-color: #ffbb99">অংশ-১: করদাতার তথ্য
                    </th>
                </tr>
                <tr>
                    <td style="padding-left:7px;">(১) ব্যবসায় সনাক্তকরণ সংখ্যা (ই-বিআইএন)</td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px;">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationBIN" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">(২) করদাতার নাম
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px;padding-top:2px;padding-bottom:2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationName" />
                    </td>
                </tr>               
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">
                        (৩) করদাতার ঠিকানা
                    </td>
                     <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px;padding-top:2px;padding-bottom:2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxOrganizationAddress" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">
                        (৪) ব্যবসার প্রকৃতি
                    </td>
                     <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px;padding-top:2px;padding-bottom:2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="OrganizationBusinessNature" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">
                        (৫) অর্থনৈতিক কাযক্রম এর প্রকৃতি
                    </td>
                     <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px;padding-top:2px;padding-bottom:2px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="NatureOfBusiness" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" style="text-align: center; background-color: #ffbb99;padding-top:4px;padding-bottom:2px">অংশ-২: দাখিলপত্র জমার তথ্য
                    </th>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">(১) কর মেয়াদ</td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px;">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTaxPeriod" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">(২) দাখিলপত্রের প্রকার<br />[অনুগ্রহ করিয়া প্রযোজটিতে টিক দিন]
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td  style="padding-left:7px">
                        (ক) মূল দাখিলপত্র(ধারা ৬৪) &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp<asp:CheckBox ID="ChkMainDakhil" runat="server" /><br />
                        (খ) সংশোধিত দাখিলপত্র(ধারা ৬৬) &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp<asp:CheckBox ID="ChkRevisedDakhil" runat="server" /><br />
                        (গ) পূর্ণ,অতিরিক্ত বা বিকল্প দাখিলপত্র(ধারা ৬৭)&nbsp <asp:CheckBox ID="ChkExtraDakhil" runat="server" /><br />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">(২) বিগত করমেয়াদে কোনো কার্যক্রম সম্পন্ন হইয়াছে কি?
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding-left:7px">
                        <asp:CheckBox ID="chkHa" runat="server" />
                        হ্যাঁ &nbsp &nbsp
                        <asp:CheckBox ID="chkNa" runat="server" />
                        না<br />
                        [যদি ‘না’ হয় তাহলে অংশ-১, ২ এবং ১০ পূরণ করুন]
                    </td>
                </tr>
                <tr>
                    <td class="td-width-30" style="padding-left:7px;">(৩) পেশের তারিখ
                    </td>
                    <td class="td-width-2" style="font-weight: bold; text-align: center">:
                    </td>
                    <td style="padding: 10px;">
                        <asp:Label runat="server" ID="lblReturnSubmitDate" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="6" style="text-align: center; background-color: #ffbb99">অংশ-৩: বিক্রয় তথ্য
                    </th>
                </tr>
                <tr>
                    <th style="width: 65%; text-align: center; background-color: #DDDDDD" colspan="2">সরবরাহের প্রকৃতি
                    </th>
                    <th style="width: 5%; text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">মূল্য (ক)
                    </th>
                    <th style="width: 10%; text-align: center; background-color: #DDDDDD">টার্নওভার (খ)
                    </th>
             
                </tr>               
                <tr>
                    <td rowspan="2" style="padding-left:7px">শূন্যহার বিশিষ্ট সরবরাহ</td>
                    <td style="padding-left:7px">সরাসরি রপ্তানি</td>
                    <td style="font-weight: bold; text-align: center">১
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateDirectExportAmountN2P3" />
                    </td>
                    <td ></td>                   
                    <td>
                        <asp:LinkButton ID="SubForm_3Row1K" runat="server" EnableTheming="True">সাবফর্ম-ক</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    
                    <td style="padding-left:7px">প্রচ্ছন্ন রপ্তানি</td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">২</td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="zerorateDeemedExportAmountN1P3" />
                    </td>
                    <td></td>                    
                    <td>
                    <asp:LinkButton ID="SubForm_3Row2K" runat="server" EnableTheming="True">সাবফর্ম-ক</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left:7px">অব্যাহতিপ্রাপ্ত পণ্য/সেবা</td>
                    <td style="font-weight: bold; text-align: center">৩
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="exemptedSupplyAmountN3P3" />
                    </td>
                    <td></td>                   
                    <td>
                        <asp:LinkButton ID="SubForm_3Row3K" runat="server" EnableTheming="True">সাবফর্ম-ক</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left:7px">আদর্শ হারের পণ্য
                    </td>
                    <td style="font-weight: bold; text-align: center">৪
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="typicalSupplyAmountN4P3" />
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="typicalSupplyVATN4P3" />
                    </td>                    
                     <td><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                         <asp:LinkButton ID="SubForm_3Row4K" runat="server" EnableTheming="True">সাবফর্ম-ক</asp:LinkButton>
                     </td>
                </tr>             
                <tr>
                    <td colspan="2" style="padding-left:7px">মোট বিক্রয়মূল্য ও মোট প্রদেয় কর
                    </td>
                    <td style="font-weight: bold; text-align: center">৫
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalPriceP3" />
                    </td>                   
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatN7P3" />
                    </td>                    
                </tr>
                
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="5" style="text-align: center; background-color: #ffbb99">অংশ-৪: ক্রয় – উপকরণ/কাঁচামাল                      
                    </th>
               
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD" colspan="2">ক্রয়ের প্রকৃতি
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">মূল্য (ক)
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">কর (খ)
                    </th>
                </tr>
                
                <tr>
                    <td style="padding-left:7px">অব্যাহতিপ্রাপ্ত পণ্য/সেবা
                    </td>
                    
                    <td class="td-width-5" style="font-weight: bold; text-align: center">৬
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="exemptedLocalPurchaseAmountN8P4" />
                    </td>
                    <td></td>
                    <%--<td style="background-color: #DDDDDD"><a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a></td>--%>
                    <td ><a href="SubForms/SubForm_k_Note12.aspx" style="text-decoration:none;">সাবফর্ম-ক</a></td>
                </tr>               
                <tr>
                    <td style="padding-left:7px">আদর্শ হারের পণ্য/সেবা
                    </td>                  
                    <td style="font-weight: bold; text-align: center">৭
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="standardLocalPurchaseAmountN12P4" />
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="standardLocalPurchaseVatN12P4" />
                    </td>
                    <td><%--<a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a>--%>
                        <asp:LinkButton ID="SubForm_4Row14k" runat="server" EnableTheming="True">সাবফর্ম-ক</asp:LinkButton>
                    </td>
                </tr>
                
                <tr>
                    <td style="padding-left:7px">প্রমিত হার ব্যতীত অন্যান্য হারে পণ্য/সেবা
                    </td>
                   
                    <td style="font-weight: bold; text-align: center">৮
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMulloLcl" />
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblAdorshoHarBatitoMushokLcl" />
                    </td>
                    <td>
                        <asp:LinkButton Id="SubForm_4Row16k" runat="server" EnableTheming="true">সাবফর্ম-ক</asp:LinkButton>
                    </td>
                </tr>                
                <tr>
                    <td style="padding-left:7px">বিশেষ স্কীমভিত্তিক পণ্য বা সেবা
                    </td>
                    <td style="font-weight: bold; text-align: center">৯
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="partialRebatePurchaseAmountN14P4" />
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="partialRebatePurchaseVatN14P4" />
                    </td>
                   <%-- <td>
                      <asp:LinkButton ID="SubForm_Gha_Note_18" runat="server" EnableTheming="true" OnClick="SubForm_Gha_Note_18_Click">সাবফর্ম-গ</asp:LinkButton>
                        </td>--%>
                     <td><a href="SubForms/SubForm_Gha_Note_18.aspx" style="text-decoration:none;">সাবফর্ম-গ</a></td>
                </tr>
                <tr>
                     <td style="padding-left:7px">নিধারিত মূল্য সংযোজন করভিত্তিক পণ্য/সেবা
                    </td>                   
                    <td style="font-weight: bold; text-align: center">১০
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonRebatePurchaseAmountN15P4" />
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonRebatePurchaseVatN15P4" />
                    </td>
                    <td><a href="SubForms/SubForm_k.aspx" style="text-decoration:none;">সাবফর্ম-ক</a></td>
                </tr>               
                <tr>
                    <td>মোট উপকরন কর 
                    </td>
                    <td style="font-weight: bold; text-align: center" >১১
                    </td>
                 <%--   <td style="background-color: #DDDDDD">--%>
                       <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalPriceP4" />
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatN16P4" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" style="text-align: center; background-color: #ffbb99">অংশ-৫:নীট কর হিসাব 
                    </th>
                </tr>
                <tr>
                    <th style="width:40% ;text-align: center; background-color: #DDDDDD">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD; border-right: 1px solid gray">পরিমাণ
                    </th>
                </tr>
                <tr>
                    <td class="td-width-70" style="padding-left:7px">বর্তমান করমেয়াদে প্রদেয় মোট কর (সমাপনী জের ব্যতীত)(৫খ)
                    </td>
                    <td class="td-width-5" style="font-weight: bold;text-align: center">১২
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="receiveVDSAmountN17P5" />
                    </td>
                    
                </tr>
                <tr>
                    <td style="padding-left:7px">সমাপনী জের এর সহিত সমন্বয়ের পর বর্তমান করমেয়াদে প্রদেয় মোট কর (১২-২১)
                    </td>
                    <td style="font-weight: bold; text-align: center">১৩
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="nonBankingPaymentVatN18P5" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px">অপরিশোধিত করে জন্য সুদ
                    </td>
                    <td style="font-weight: bold; text-align: center">১৪
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="changePurchaseAllVatN19P5" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px">অর্থদণ্ড ও জরিমানা
                    </td>
                    <td style="font-weight: bold; text-align: center">১৫
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="otherAdjusmentVatN20P5" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px">আবগারি শুল্ক
                    </td>
                    <td style="font-weight: bold; text-align: center">১৬
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="lblTotalVatN21P5" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px">উন্নয়ন সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">১৭
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label2" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px">তথ্য প্রযুক্তি উন্নয়ন সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">১৮
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label3" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px">স্বাস্থ্য সুরক্ষা সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">১৯
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label4" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:7px">পরিবেশ সুরক্ষা সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">২০
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label5" />
                    </td>
                </tr>              
                <tr>
                    <td style="padding-left:7px">শেষ কর মেয়াদে সমাপনী জের (টার্নওভার কর)
                    </td>
                    <td style="font-weight: bold; text-align: center">২১
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="Label6" />
                    </td>
                </tr>
            </table>
        </div>
        
        
       <div>
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="4" style="text-align: center; background-color: #ffbb99">অংশ-৬: কর পরিশোধের তফসিল(ট্রেজারি জমা)
                    </th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: #DDDDDD">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">অর্থনৈতিক কোড
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">পরিমাণ (টাকা)
                    </th>
                </tr>
                <tr>
                    <td style="padding-left:7px">বর্তমান কারমেয়াদে পরিশোধিত মোট কর
                    </td>
                    <td class="td-width-5" style="font-weight: bold; text-align: center">২২
                    </td>
                   <%-- <td style="padding-left:7px">১/১১৩৩/অপারেশনাল কোড/০৩১১--%>
                     <td style="padding-left:7px">
                      <asp:Label runat="server" ID="oc1"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TotalVatN32P8" />
                    </td>
                    <td><a href="SubForms/SubForm_CHA.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                
                <tr>
                    <td style="padding-left:7px">অপরিশোধিত করের জন্য সুদ্
                    </td>
                    <td style="font-weight: bold; text-align: center">২৩
                    </td>
                    <td style="padding-left:7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                          <asp:Label runat="server" ID="oc3"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="DueVatN34P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note54.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                
                <tr>
                    <td style="padding-left:7px">অর্থদণ্ড ও জরিমানা
                    </td>
                    <td style="font-weight: bold; text-align: center">২৪
                    </td>
                    <td style="padding-left:7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                           <asp:Label runat="server" ID="oc5"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="FinepenaltyN34P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note56.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                <tr>
                    <td style="padding-left:7px">আবগারি শুল্ক
                    </td>
                    <td  style="font-weight:bold;text-align:center">২৫
                    </td>
                    <td style="padding-left:7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                         <asp:Label runat="server" ID="oc6"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="ExciseDutyN33P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note57.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                <tr>
                    <td style="padding-left:7px">উন্নয়ন সারচার্জ
                    </td>
                    <td  style="font-weight:bold;text-align:center">২৬
                    </td>
                    <td style="padding-left:7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                        <asp:Label runat="server" ID="oc7"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="DevelopmentN33P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note58.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                <tr>
                    <td style="padding-left:7px">তথ্য প্রযুক্তি উন্নয়ন সারচার্জ
                    </td>
                    <td  style="font-weight:bold;text-align:center">২৭
                    </td>
                    <td style="padding-left:7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                         <asp:Label runat="server" ID="oc8"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="ICTN33P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note59.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                <tr>
                    <td style="padding-left:7px">স্বাস্থ্য সুরুখ সারচার্জ
                    </td>
                    <td style="font-weight:bold;text-align:center">২৮
                    </td>
                    <td style="padding-left:7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                         <asp:Label runat="server" ID="oc9"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="HealthN33P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note60.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                <tr>
                    <td style="padding-left:7px">পরিবেশ সুরক্ষা সারচার্জ
                    </td>
                    <td style="font-weight: bold; text-align: center">২৯
                    </td>
                    <td style="padding-left:7px"><%--১/১১৩৩/অপারেশনাল কোড/২২১৪--%>
                         <asp:Label runat="server" ID="oc10"></asp:Label>  
                    </td>
                    <td class="m">
                        <asp:Label Style="font-weight: bold" runat="server" ID="EnvironmentN33P8" />
                    </td>
                    <td><a href="SubForms/Sub_Form_CHA_Note61.aspx" style="text-decoration:none;">সাবফর্ম-খ</a></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center; background-color: #DDDDDD;for" ><b>অংশ-১০: ফেরত</b></td>
                </tr>
                <tr>
                     <th style="text-align: center; background-color: #DDDDDD">আইটেম
                    </th>
                    <th style="text-align: center; background-color: #DDDDDD">নোট
                    </th>                    
                    <th colspan="2" style="text-align: center; background-color: #DDDDDD">পরিমাণ (টাকা)
                    </th>
                </tr>
                <tr>   
                    <td style="width: 27.5%;padding-left:7px">সমাপনী মূল্য সংযোজন কর
                    </td>
                    <td style="font-weight: bold; text-align: center; width: 5%">৩০
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="TextBox2" Width="50%" />
                    </td>
                </tr>
            </table>
        </div>
    
        <div style="margin-top: 40px">
            <table class="table table-bordered" style="width: 100%">
                <tr>
                    <th colspan="3" style="text-align: center; background-color: #DDDDDD">অংশ-১১: ঘোষণা
                    </th>
                </tr>
                <tr>
                    <td colspan="3" style="padding-left:7px">আমরা ঘোষণা করিতেছি যে, এই দাখিলপত্রে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20" style="padding-left:7px">নাম
                    </td>
                    <td colspan="2" style="padding-left:7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerNameP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20" style="padding-left:7px">পদবী
                    </td>
                    <td class="td-width-40" style="padding-left:7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerDesignationP10" />
                    </td>
                    <td rowspan="4"></td>
                </tr>
                <tr>
                    <td class="td-width-20" style="padding-left:7px">তারিখ
                    </td>
                    <td class="td-width-40" style="padding-left:7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxPaymentDateP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20" style="padding-left:7px">মোবাইল নম্বর
                    </td>
                    <td class="td-width-40" style="padding-left:7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerMobileNoP10" />
                    </td>
                </tr>
                <tr>
                    <td class="td-width-20" style="padding-left:7px">ইমেইল
                    </td>
                    <td class="td-width-40" style="padding-left:7px">
                        <asp:Label Style="font-weight: bold" runat="server" ID="TaxpayerEmailP10" />
                    </td>
                </tr>
                <tr>
                    <td style="border: 0px"></td>
                    <td style="border: 0px"></td>
                    <td style="float: right" >স্বাক্ষর
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: 0px"><asp:Label runat="server" Text="System User: "></asp:Label>
                            <asp:Label runat="server" ID="lblUser"></asp:Label></td>
                    <td style="float: right; border:none" ><asp:Label runat="server" ID="lblPrintDateTime" style="float:right"></asp:Label>
                            <asp:Label runat="server" ID="Label1" style="float:right" Text="Print DateTime: "></asp:Label></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
