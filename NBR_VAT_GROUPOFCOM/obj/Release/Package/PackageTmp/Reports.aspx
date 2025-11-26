<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.master" autoeventwireup="true" inherits="Reports, App_Web_qr4mw4bg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
     <style>
        .list-group-item:not(.active) { background-color: #ffffff; }
        .list-group-item:not(.active):hover { background-color: #f2f2f2 !important; }


        

    .jstree-default a { 
    white-space:normal !important; height: auto; 
}
.jstree-anchor {
    height: auto !important;
}
.jstree-default li > ins { 
    vertical-align:top; 
}
.jstree-leaf {
    height: auto;
}
.jstree-leaf a{
    height: auto !important;
}



    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">





        <div class="panel-heading">Reports</div>
        <div class="panel-body">
            <div class="list-group col-md-2 col-sm-4 ">
                <a class="list-group-item active">NBR Reports-I</a>

                <div class="jstree_demo_div">
                  <ul>
                    <li>মূল্য সংযোজন কর দাখিলপত্র (মূসক-৯.১)</li>
                    <li> টি. আর. ফরম-৬</li>
                     <li>চালানপত্র (মূসক-৬.৩)</li>
                            <li>দুই লাখ টাকার বেশি মূল্য মানের ক্রয় বিক্রয় চালানপত্রের তথ্য (মূসক-৬.১০)</li>
                  </ul>
                </div>

                <%--<asp:HyperLink class="list-group-item" ID="HyperLink52" NavigateUrl="~/Reports/VAT_Return_Form19_N.aspx" runat="server">মূল্য সংযোজন কর দাখিলপত্র (মূসক-১৯) - পুরাতন </asp:HyperLink>--%>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink61" NavigateUrl="~/Reports/VATReturnMushok19.aspx" runat="server">মূল্য সংযোজন কর দাখিলপত্র (মূসক-১৯) - নূতন </asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink61" NavigateUrl="~/Reports/VATReturnMushok19s.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূল্য সংযোজন কর দাখিলপত্র (মূসক-৯.১)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink6" NavigateUrl="~/Reports/treasuryChallan_form.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> টি. আর. ফরম-৬</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink10" NavigateUrl="~/Reports/Current_Account_Form18_N.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> চলতি হিসাব-১৮</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink9" NavigateUrl="~/Reports/Challan_Form11.aspx" runat="server">চালানপত্র (মূসক-১১)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink9" NavigateUrl="~/Reports/Challan_Form11.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> চালানপত্র (মূসক-৬.৩)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink66" NavigateUrl="~/Reports/AboveTwoLacRep_6.10.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> দুই লাখ টাকার বেশি মূল্য মানের ক্রয় বিক্রয় চালানপত্রের তথ্য (মূসক-৬.১০)</asp:HyperLink>



                <%-- <asp:HyperLink class="list-group-item" ID="HyperLink9" NavigateUrl="~/Reports/VatRegistration2.1.aspx"  runat="server">Vat Registration 2.1</asp:HyperLink>--%>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink10" NavigateUrl="~/Reports/VatRegistration2_2.aspx" runat="server">Branch Registration 2.2</asp:HyperLink>--%>



                <asp:HyperLink class="list-group-item"   ID="HyperLink8" NavigateUrl="~/Reports/Credit_Note_Form12.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Credit Note-12</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink7" NavigateUrl="~/Reports/Current_Account_Form18.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> চলতি হিসাব-১৮(old)</asp:HyperLink>

                <asp:HyperLink class="list-group-item"   ID="HyperLink5" NavigateUrl="~/Reports/TurnoverTaxReturn_9.2.aspx" Visible="false" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> টার্নওভার কর দাখিলপত্র (মূসক-৯.২)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink1" NavigateUrl="~/Reports/Price_Declaration_Form1.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূল্য ঘোষণাপত্র-১</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink2" NavigateUrl="~/Reports/PriceDeclaration_Form1Kha.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Price By Traders-1Kha</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink3" NavigateUrl="~/Reports/PriceDeclaration_Form1Ga.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূসক-১গ</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink48" NavigateUrl="~/Reports/Report_VAT_Return_9_1.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূল্য সংযোজন কর দাখিলপত্র (মূসক-১৯)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink57" NavigateUrl="~/Reports/rptMushok5Ka.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> চালানপত্র (মূসক-১১)</asp:HyperLink>
            </div>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">NBR Reports-II</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink54" NavigateUrl="~/Reports/Debit_Note_Form12Ka_N.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ডেবিট নোট</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink53" NavigateUrl="~/Reports/Credit_Note_Form12_N.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্রেডিট নোট</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink45" NavigateUrl="~/Reports/Mushok_1.aspx" runat="server">Cost Analysis Sheet(মূসক-১)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink45" NavigateUrl="~/Reports/Mushok_1.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Cost Analysis Sheet (মূসক- ৪.৩)</asp:HyperLink>
               
                <asp:HyperLink class="list-group-item"   ID="HyperLink52" NavigateUrl="~/Reports/Mushok4_3.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উপকরণ - উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা (৪.৩)</asp:HyperLink>
                 
                            <asp:HyperLink class="list-group-item"   ID="HyperLink67" NavigateUrl="~/Reports/ContractualProductionIssueReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Issue/চুক্তিভিত্তিক উৎপাদনের চালানপত্র (মূসক-৬.৪)</asp:HyperLink>
                            <asp:HyperLink class="list-group-item"   ID="HyperLink68" NavigateUrl="~/Reports/ContractualProductionReceiveReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receive/চুক্তিভিত্তিক উৎপাদনের চালানপত্র (মূসক-৬.৪)</asp:HyperLink>
                            <asp:HyperLink class="list-group-item"   ID="HyperLink69" NavigateUrl="~/Reports/OwnProductionIssueReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Issue/উৎপাদনের চালানপত্র</asp:HyperLink>
                            <asp:HyperLink class="list-group-item"   ID="HyperLink70" NavigateUrl="~/Reports/OwnProductionReceiveReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receive/উৎপাদনের চালানপত্র</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink78" NavigateUrl="~/Reports/AtActualComparison.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Actual Consumption</asp:HyperLink>
                  <asp:HyperLink class="list-group-item"   ID="HyperLink74" NavigateUrl="~/Reports/TransferIssueReport6.5.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Issue / কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)</asp:HyperLink>
                            <asp:HyperLink class="list-group-item"   ID="HyperLink75" NavigateUrl="~/Reports/TransferReceiveReport6.5.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>  Receive / কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)</asp:HyperLink>


                <asp:HyperLink class="list-group-item"   ID="HyperLink50" NavigateUrl="~/Reports/Mushok_1_rpt.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূসক -১</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink24" NavigateUrl="~/Reports/Mushok_1_rpt_KHA.aspx" runat="server" Visible="false">মূসক-১(খ)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink62" NavigateUrl="~/Reports/rptMushok1Gha.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূসক - ১(গ)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink63" NavigateUrl="~/Reports/rptMushok1GHAA.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> মূসক - ১(ঘ)</asp:HyperLink>


                <asp:HyperLink class="list-group-item"   ID="HyperLink11" NavigateUrl="~/Reports/Debit_Note_Form12Ka.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Debit Note-12KA</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink12" NavigateUrl="~/Reports/Purchase_Account_Book_Form16.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Purchase Account-16</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink13" NavigateUrl="~/Reports/SaleChallan17.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Account-17</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink14" NavigateUrl="~/Reports/Dispose.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Inputs Dispose-26</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink15" NavigateUrl="~/Reports/Cashmemo.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Cash Memo-11KA</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink16" NavigateUrl="~/Reports/Stock_Declaration_rpt.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Stock Declaration-15</asp:HyperLink>


            </div>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">NBR Reports-III</a>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink55" NavigateUrl="~/Reports/SourceTaxDeductedCertificate_6.6.aspx" runat="server">উৎসে মূসক কর্তনের প্রত্যয়ন পত্র (মূসক-১২খ)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink55" NavigateUrl="~/Reports/SourceTaxDeductedCertificate_6.6.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উৎসে কর কর্তন সনদ পত্র (মূসক-৬.৬)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink23" NavigateUrl="~/Reports/SourceTaxDeductedCertificate_Receive_6.6.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receive/উৎসে কর কর্তন সনদপত্র</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink43" NavigateUrl="~/Reports/Dispose_Inputs_Form26.aspx" runat="server" ><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তির আবেদনপত্র (মূসক-৪.৪)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink44" NavigateUrl="~/Reports/Destroy_Inputs_Form27.aspx" runat="server" ><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>দুর্ঘটনায় ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত পণ্য নিষ্পত্তির আবেদনপত্র (মূসক-৪.৫)</asp:HyperLink>
                      <asp:HyperLink class="list-group-item"   ID="HyperLink72" NavigateUrl="~/Reports/GoodsTransferSummeryChak_Ka.aspx" runat="server" ><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>Goods Transfer Summary (Chak- Ka)</asp:HyperLink>
                      <asp:HyperLink class="list-group-item"   ID="HyperLink73" NavigateUrl="~/Reports/SalesTransactionSummeryChak_Kha.aspx" runat="server" ><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>Sales Transaction Summary (Chak-Kha)</asp:HyperLink>

                <asp:HyperLink class="list-group-item"   ID="HyperLink17" NavigateUrl="~/Reports/AboveTwoLacRep_6.10.aspx" Visible="false" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> দুই লক্ষ টাকার বেশি মূল্য মানের ক্রয়-বিক্রয় চালানপত্রের তথ্য (মূসক-৬.১০)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink233" NavigateUrl="~/Reports/SourceTaxDeductedCertificate_6.6.aspx"
                    runat="server" Visible="false">Issue/উৎসে কর কর্তন সনদপত্র (মূসক-৬.৬)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink444" NavigateUrl="~/Reports/SourceTaxDeductedCertificate_Receive_6.6.aspx"
                    runat="server" Visible="false">Receive/উৎসে কর কর্তন সনদপত্র (মূসক-৬.৬)</asp:HyperLink>
            </div>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">Purchase/Sales Reports</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink51" NavigateUrl="~/Reports/Purchase_Account_Book_Form16_N.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্রয় হিসাব পুস্তক (মূসক-৬.১)</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink59" NavigateUrl="~/Reports/Sales_Account_Book_Form17_N.aspx" runat="server">বিক্রয় হিসাব পুস্তক (মূসক-১৭) </asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink65" NavigateUrl="~/Reports/Sales_Account_Book_Form17_N.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> বিক্রয় হিসাব পুস্তক (মূসক-৬.২) </asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink59" NavigateUrl="~/Reports/musuk_6_2_1_.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্রয় ও বিক্রয় হিসাব পুস্তক (মূসক-৬.২.১) </asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink64" NavigateUrl="~/Reports/rptMushok17KA.aspx" runat="server">ক্রয় ও বিক্রয় হিসাব পুস্তক(মূসক-১৭ক)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink64" NavigateUrl="~/Reports/rptMushok17KA.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্রয় ও বিক্রয় হিসাব পুস্তক</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink46" NavigateUrl="~/Reports/purchase_leisure_book.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Payable Ledger Book</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink47" NavigateUrl="~/Reports/sales_leisure_book.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receivable Ledger Book</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink58" NavigateUrl="~/Reports/CategoryWisePreodicReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Category Wise Purchase Periodic Report</asp:HyperLink>

                <asp:HyperLink class="list-group-item"   ID="HyperLink18" NavigateUrl="~/Reports/PurchaseAccountingBook_6.1.aspx" Visible="false"
                    runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্রয় হিসাব পুস্তক (মূসক-১৬)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink19" NavigateUrl="~/Reports/PurchaseSummaryReport.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Purchase Summary</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink20" NavigateUrl="~/Reports/PurchaseDaywiseSummaryReport.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Purchase Summary (Day-wise)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink21" NavigateUrl="~/Reports/PurchaseTypeWiseSummaryReport.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Purchase Summary (Type-wise)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink22" NavigateUrl="~/Reports/PurchaseDayItemChallanGrpRep.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Purchase Statement</asp:HyperLink>

                <asp:HyperLink class="list-group-item"   ID="HyperLink244" NavigateUrl="~/Reports/SaleAccountingBook_6.2.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> বিক্রয় হিসাব পুস্তক (মূসক-১৭)</asp:HyperLink>

                <asp:HyperLink class="list-group-item"   ID="HyperLink25" NavigateUrl="~/Reports/SaleSummaryReport.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Summary</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink26" NavigateUrl="~/Reports/SaleDayWiseSummaryReport.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Summary (Day-wise)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink27" NavigateUrl="~/Reports/SaleTypeWiseSummaryReport.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Summary (Type-wise)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink28" NavigateUrl="~/Reports/SaleDayItemChallanGrpRep.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Statement</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink33" NavigateUrl="~/Reports/VatDeductedSource.aspx"
                    runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VDS Report</asp:HyperLink>




                <asp:HyperLink class="list-group-item"   ID="HyperLink56" NavigateUrl="~/TestDropDownAjax.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Test DD </asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink36" NavigateUrl="~/TestR_D.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> R & D </asp:HyperLink>


            </div>

            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">MIS Reports</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink34" NavigateUrl="~/Reports/PurchaseReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Periodic Purchase Report</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink81" NavigateUrl="~/Reports/Periodic_Purchase_Report_BI.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>Purchase Challan (B/I) Report</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink35" NavigateUrl="~/Reports/SaleReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Periodic Sales Report</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink60" NavigateUrl="~/Reports/PeriodicStockReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Periodic Stocks Report</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink30" NavigateUrl="~/Reports/RawMaterialConsumptionReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Raw Materials Consumption</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink31" NavigateUrl="~/Reports/FinishGoodProductionReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Finished Products Production</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink79" NavigateUrl="~/Reports/ValueAdditionPctwiseReport4_3.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Value Added Percentage wise Report(4.3)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink82" NavigateUrl="~/Reports/Summary_Of_Value_Addition.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Value Addition summary (4.3)</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink71" NavigateUrl="~/Reports/QuantityWiseSaleReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Sub Report</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink76" NavigateUrl="~/Reports/DailySaleReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Monthly Sales-Purchase Summary Report (Day Basis)</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink77" NavigateUrl="~/Reports/SalesPurchaseComparativeReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sales-Purchase Comparative Report </asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink80" NavigateUrl="~/Reports/SaleSummaryMonthwise.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Summary Report </asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink4" NavigateUrl="~/Reports/PurchaseRegister.aspx" Visible="false" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Purchase Register</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink49" NavigateUrl="~/Reports/SaleRegister.aspx" Visible="false" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Sale Register</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink29" NavigateUrl="~/Reports/Treasury_Challan_Detail_Report.aspx" Visible="false" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Tresury Challan</asp:HyperLink>

                <asp:HyperLink class="list-group-item"   ID="HyperLink32" NavigateUrl="~/Reports/VATMonthlySummaryReport.aspx" Visible="false" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VAT Monthly Summary</asp:HyperLink>





            </div>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">Audit Reports</a>
              <%--  <asp:HyperLink class="list-group-item" ID="HyperLink37" NavigateUrl="~/UI/Audit/IngredientsPurchaseInformation.aspx" runat="server">উপকরণ সংক্রান্ত তথ্য (মূসক-১৬ রেজিষ্টার মোতাবেক)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink38" NavigateUrl="~/UI/Audit/ProductionNSalesStatement.aspx" runat="server">উৎপাদন ও বিক্রয় বিবরণী (মূসক-১৭ রেজিস্টার মোতাবেক)</asp:HyperLink>--%>
                  <asp:HyperLink class="list-group-item"   ID="HyperLink37" NavigateUrl="~/UI/Audit/IngredientsPurchaseInformation.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উপকরণ সংক্রান্ত তথ্য (রেজিষ্টার মোতাবেক)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink38" NavigateUrl="~/UI/Audit/ProductionNSalesStatement.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উৎপাদন ও বিক্রয় বিবরণী (রেজিস্টার মোতাবেক)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink39" NavigateUrl="~/UI/Audit/RevenueStatement.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> রাজস্ব বিবরণী (মূসক-১৮ মোতাবেক)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink41" NavigateUrl="~/UI/Audit/RebateStatement.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> রেয়াত গ্রহণের বিবরণী</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink42" NavigateUrl="~/UI/Audit/PriceDeclarationInformation.aspx" runat="server">অনুমোদিত মূল্যভিত্তি ঘোষণাপত্র (মূসক-১ মোতাবেক)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink42" NavigateUrl="~/UI/Audit/PriceDeclarationInformation.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> অনুমোদিত মূল্যভিত্তি ঘোষণাপত্র (মূসক-৪.৩ মোতাবেক)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink40" NavigateUrl="~/UI/Audit/VDSStatement.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উৎসে কর্তনযোগ্য মূসকের বিবরণী</asp:HyperLink>
                           
                 </div>
            <%--<div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12" >
                <a class="list-group-item active">All Application</a>
                <asp:HyperLink class="list-group-item" ID="HyperLink34" NavigateUrl="~/Reports/Mushok2_4.aspx" Visible ="false"
                    runat="server">নিবন্ধন/টার্নওভার কর তালিকাভুক্তি বাতিল ও কর-প্রকৃতি পরিবর্তনের আবেদনপত্র(মূসক-২.৪)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink35" NavigateUrl="~/Reports/Mushok2_6.aspx" Visible ="false"
                    runat="server">নিবন্ধন/তালিকাভুক্তি পরবর্তী তথ্যের পরিবর্তন(মূসক-২.৬)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink36" NavigateUrl="~/Reports/Mushok2_7.aspx" Visible ="false"
                    runat="server">ব্যবসায় স্থান পরিবর্তনের আবেদন(মূসক-২.৭)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink37" NavigateUrl="~/Reports/Mushok12_7.aspx" Visible ="false"
                    runat="server">জব্দকৃত যানবাহন ছাড়করণের আবেদনপত্র(মূসক-১২.৭)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink38" NavigateUrl="~/Reports/Mushok12_8.aspx" Visible ="false"
                    runat="server">জব্দকৃত যানবাহন অন্তর্বর্তীকালীন ছাড়ের জন্য ব্যক্তিগত মুচলেকা(মূসক-১২.৮)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink39" NavigateUrl="~/Reports/Mushok16_2.aspx" Visible ="false"
                    runat="server">স্বীকারোক্তিমূলক জবানবন্দি(মূসক-১৬.২)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink40" NavigateUrl="~/Reports/Mushok17_1.aspx" Visible ="false"
                    runat="server">বিকল্প বিরোধ নিষ্পত্তি পদ্ধতিতে মামলা নিষ্পত্তির আবেদন(মূসক-১৭.১)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink41" NavigateUrl="~/Reports/Mushok9_3.aspx" Visible ="false"
                    runat="server">বিলম্বে দাখিলপত্র পেশের আবেদন(মূসক-৯.৩)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink42" NavigateUrl="~/Reports/Mushok9_4.aspx" Visible ="false"
                    runat="server">সংশোধিত দাখিলপত্র পেশের আবেদন (মূসক-৯.৪)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink43" NavigateUrl="~/Reports/Mushok18_3.aspx" Visible ="false"
                    runat="server">মূসক ছাড়পত্র প্রাপ্তির আবেদনপত্র (মূসক-১৮.৩)</asp:HyperLink>
                
            </div>--%>
          <%--  <div class="col-lg-12 col-md-12 col-sm-12">
                <h3>Reports section is sub-divided into 6 different categories. They are as listed below
                </h3>
                <ul>
                    <li><b>NBR Reports I/ NBR Reports II/ NBR Reports III:</b> These three sections contain the pre-existing
                        mandatory reports required by NBR.</li>
                    <li><b>Purchase/Sale Reports:</b> This section includes all types of Purchase & Sales related additional
                        reports generated by KGCVAT.</li>
                    <li><b>MIS Reports:</b> This section includes all extra financial, production, and inventory
                        reports generated by KGCVAT. </li>
                    <li><b>Audit Reports:</b> All kind of audit Report generated by KGCVAT. </li>
                </ul>
            </div>--%>
        </div>
    </div>
</asp:Content>

