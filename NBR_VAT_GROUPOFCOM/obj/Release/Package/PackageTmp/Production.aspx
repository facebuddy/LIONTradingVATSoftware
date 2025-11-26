<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Production, App_Web_qr4mw4bg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <style>
        .list-group-item:not(.active) { background-color: #ffffff; }
        .list-group-item:not(.active):hover { background-color: #f2f2f2 !important; }
    </style>
    <div class="panel panel-default">
        <div class="panel-heading">Purchase/Production/Sales</div>
        <div class="panel-body">
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">Purchase</a>

                <%--<asp:HyperLink class="list-group-item" ID="HyperLink1" NavigateUrl="~/UI/Challan.aspx" runat="server" Visible = "false">Purchase Challan (VAT Form-11)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"  ID="HyperLink4" NavigateUrl="~/UI/Purchase/LocalPurchases.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্রয় চালানপত্র</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink17" NavigateUrl="~/UI/Purchase/BillOfEntry_6.3.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> আমদানি চালানপত্র</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink22" NavigateUrl="~/UI/Purchase/Adjustment_Voucher_Purchase.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Payable Adjustment Voucher</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink2" NavigateUrl="~/UI/Purchase/PurchaseReturn.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Purchase Return</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink25" NavigateUrl="~/UI/Purchase/Purchase_Edit.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Edit Purchase Data</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID ="HyperLink27" NavigateUrl="~/UI/Purchase/BillofEntry_Edit.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Edit Bill of Entry Data</asp:HyperLink>


                <asp:HyperLink class="list-group-item" ID="HyperLink51" NavigateUrl="~/TestPage.aspx" runat="server" Visible="false">Test Excel Page</asp:HyperLink>

            </div>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">Production</a>

                <%--<asp:HyperLink class="list-group-item" ID="HyperLink5" NavigateUrl="~/UI/Admin/ProductsTransfer_6.5.aspx" runat="server">Issue/পণ্য স্থানান্তর চালানপত্র (মূসক-৬.৫)</asp:HyperLink>--%>


                <%--<asp:HyperLink class="list-group-item" ID="HyperLink24" NavigateUrl="~/UI/Admin/ProductsTransfer_receive_6.5.aspx" runat="server">Receive/পণ্য স্থানান্তর চালানপত্র (মূসক-৬.৫)</asp:HyperLink>--%>

                <asp:HyperLink class="list-group-item"  ID="HyperLink7" NavigateUrl="~/UI/Production/RawMaterialIssueForProduction.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Raw Material Requisition (কাঁচামালের চাহিদা পত্র)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink6" NavigateUrl="~/UI/Admin/ContractualProduction_6.4.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Issue/ চুক্তিভিত্তিক উৎপাদনের চালানপত্র (মূসক-৬.৪)</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink1" NavigateUrl="~/UI/Admin/ContractualProduction_6.4.aspx" runat="server">সত্ত্বাধিকারীর সরবরাহস্থল হইতে উৎপাদনের জন্য প্রেরিত উপকরণ এর চালানপত্র (মূসক-১১গ)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"  ID="HyperLink1" NavigateUrl="~/UI/Admin/ContractualProduction_6.4.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> সত্ত্বাধিকারীর সরবরাহস্থল হইতে উৎপাদনের জন্য প্রেরিত উপকরণ এর চালানপত্র (মুসক-৬.৫)</asp:HyperLink>
                
               
                
                

                <asp:HyperLink class="list-group-item"  ID="HyperLink3" NavigateUrl="~/UI/Admin/ContractualProduction_Receive_6.4.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receive/ চুক্তিভিত্তিক উৎপাদনের চালানপত্র (মূসক-৬.৪)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink39" NavigateUrl="~/UI/Admin/Own_Production_6.4.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Issue/ উৎপাদনের চালানপত্র</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink40" NavigateUrl="~/UI/Admin/Own_Production_Receive6.4.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receive/ উৎপাদনের চালানপত্র</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"  ID="HyperLink43" NavigateUrl="~/UI/Admin/wastemanagement.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Waste Management</asp:HyperLink>

                 <asp:HyperLink class="list-group-item"  ID="HyperLink44" NavigateUrl="~/UI/Admin/Band_roll_requisition_form.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Bandroll Requisition</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"  ID="HyperLink45" NavigateUrl="~/UI/Admin/Bandrollrequisition_receive.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Bandroll Requisition Receive</asp:HyperLink>
              
                  <%--<asp:HyperLink class="list-group-item" ID="HyperLink38" NavigateUrl="~/UI/Admin/ContractualProduction_Receive_6.4.aspx" runat="server">সত্ত্বাধিকারীর সরবরাহ স্থল থেকে উৎপাদিত পণ্য গ্রহণ (মূসক-১১গ)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"  ID="HyperLink38" NavigateUrl="~/UI/Admin/ContractualProduction_Receive_6.4.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> সত্ত্বাধিকারীর সরবরাহ স্থল থেকে উৎপাদিত পণ্য গ্রহণ</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink50" NavigateUrl="~/Reports/Mushok6_5.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right fa-2x" style="color:green;" aria-hidden="true"></i> কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র(মুসক-৬.৫)</asp:HyperLink>



                <asp:HyperLink class="list-group-item"  ID="HyperLink28" NavigateUrl="~/UI/Production/RawMaterialRequisition.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Raw Material Requisition (Foods)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink29" NavigateUrl="~/UI/Production/RawMaterialIssuedForProduction.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উৎপাদনের জন্য প্রেরিত উপকরণ এর চালানপত্র (Foods)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink23" NavigateUrl="~/UI/Production/FinishProductReceiveFromSelfProduction.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>Finished Product Received</asp:HyperLink>

                <asp:HyperLink class="list-group-item"  ID="HyperLink8" NavigateUrl="~/UI/Production/FinishedGoodsProduction.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Finished Goods Production</asp:HyperLink>

                <asp:HyperLink class="list-group-item"  ID="HyperLink9" NavigateUrl="~/UI/Production/Bandroll.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>bandroll</asp:HyperLink>


                <asp:HyperLink class="list-group-item"  ID="HyperLink10" NavigateUrl="~/UI/Production/BandrollReceive.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>Bandroll Receive</asp:HyperLink>

                <asp:HyperLink class="list-group-item"  ID="HyperLink11" NavigateUrl="~/UI/Production/BandrollUse.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>bandroll usage</asp:HyperLink>
                 <asp:HyperLink class="list-group-item"   ID="HyperLink46" NavigateUrl="~/Reports/BandrollRegister.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Bandroll Register</asp:HyperLink>
            </div>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">Sale</a>

                <%--<asp:HyperLink class="list-group-item" ID="HyperLink12" NavigateUrl="~/UI/Sale/SaleChallan11.aspx" runat="server">Sale Challan (VAT Form-11)</asp:HyperLink>--%>
               <%-- <asp:HyperLink class="list-group-item" ID="HyperLink16" NavigateUrl="~/UI/Sale/SaleChallan_11.aspx" runat="server">বিক্রয় চালানপত্র (মূসক-১১)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"  ID="HyperLink16" NavigateUrl="~/UI/Sale/SaleChallan_11.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> বিক্রয় চালানপত্র (মূসক- ৬.৩)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink49" NavigateUrl="~/UI/Sale/ConsumableItemSale.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Consumable Item Uses</asp:HyperLink>
                
                <asp:HyperLink class="list-group-item"  ID="HyperLink48" NavigateUrl="~/UI/Sale/InstallmentPaymentSchedule.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Installment Payment Scheduler</asp:HyperLink>

                <asp:HyperLink class="list-group-item"  ID="HyperLink12" NavigateUrl="~/UI/Sale/Adjustment_Voucher.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receivable Adjustment Voucher</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink13" NavigateUrl="~/#" runat="server" Visible="false"><i class="fa fa-arrow-circle-right fa-2x" style="color:green;" aria-hidden="true"></i> Sale Return</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink14" NavigateUrl="~/UI/Admin/CreditNote_6.7.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্রেডিট নোট (মূসক-৬.৭)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink41" NavigateUrl="~/UI/Admin/CreditNote_Extension.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> হ্রাসকারী সমন্বয়</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink15" NavigateUrl="~/UI/Admin/DebitNote_6.8.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ডেবিট নোট (মূসক-৬.৮)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink42" NavigateUrl="~/UI/Admin/DebitNote_Extension.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> বৃদ্ধিকারী সমন্বয়</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink26" NavigateUrl="~/UI/Sale/Sale_Edit.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Edit Sale Data</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink18" NavigateUrl="~/UI/Admin/TurnoverVatChallan_6.9.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> টার্নওভার কর চালানপত্র (মূসক-৬.৯)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink19" NavigateUrl="~/UI/Sale/CashMemo.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Cash Memo</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink20" NavigateUrl="~/UI/Sale/InvoiceCancel.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Invoice</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink31" NavigateUrl="~/UI/Sale/CustomCashMemo.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Custom Cash Memo</asp:HyperLink>


            </div>
            <%-- <div class="list-group col-md-3">
                <a class="list-group-item active">Turn Over Tax</a>
                <asp:HyperLink class="list-group-item" ID="HyperLink21" NavigateUrl="~/UI/TurnOver/TurnOverTax.aspx" runat="server">Sale Turn Over Tax</asp:HyperLink>


            </div>--%>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">Others</a>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink5" NavigateUrl="~/UI/Admin/ProductsTransfer_6.5.aspx" runat="server">Issue / পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"  ID="HyperLink5" NavigateUrl="~/UI/Admin/ProductsTransfer_6.5.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Issue / কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)</asp:HyperLink>
                
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink24" NavigateUrl="~/UI/Admin/ProductsTransfer_receive_6.5.aspx" runat="server">Receive / পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"  ID="HyperLink24" NavigateUrl="~/UI/Admin/ProductsTransfer_receive_6.5.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Receive / কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র (মুসক-৬.৫)</asp:HyperLink>
                <asp:HyperLink class="list-group-item"  ID="HyperLink21" NavigateUrl="~/UI/Others/DADO.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> DADO</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink30" NavigateUrl="~/UI/Others/Dispose.aspx" runat="server">অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি(মূসক-২৬)</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink36" NavigateUrl="~/UI/Others/Damaged.aspx" runat="server">ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তি(মূসক-২৭)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"  ID="HyperLink30" NavigateUrl="~/UI/Others/Dispose.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি</asp:HyperLink>
                <asp:HyperLink class="list-group-item"    ID="HyperLink36" NavigateUrl="~/UI/Others/Damaged.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তি</asp:HyperLink>
            </div>
            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">NBR Audit</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink32" NavigateUrl="~/UI/Audit/AllChallanAudit.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> All Challan Audit</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink33" NavigateUrl="~/UI/Audit/AccountingBookAudit.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Accounting Book Audit</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink65" NavigateUrl="~/Reports/ReconciliationReport.aspx" runat="server">Reconciliation Report for Mushok-01</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink65" NavigateUrl="~/Reports/ReconciliationReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Reconciliation Report for Mushok-4.3</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink34" NavigateUrl="~/UI/Audit/OnlineChalanVerification.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Online TR Challan Verification</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink35" NavigateUrl="~/UI/Audit/AuditTrailLog.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Audit Trail Log Report</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink37" NavigateUrl="~/UI/Audit/AuditTrailLogReport.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> NBR Audit Completion Report</asp:HyperLink>
             <asp:HyperLink class="list-group-item"   ID="HyperLink67" NavigateUrl="~/Reports/BandrollManagement.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Bandroll Management</asp:HyperLink>
                
            </div>

            <div class="list-group col-lg-2 col-md-2 col-sm-4 col-xs-12">
                <a class="list-group-item active">Pre-Approve Stage</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink47" NavigateUrl="~/UI/Sale/ApproveSaleChallan.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Pre-Sale Approval</asp:HyperLink>

                
            </div>

            <div class="clearfix"></div>
           <%-- <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <h4>Purchase/Production/Sales section is divided into 3 sub-categories.They are:</h4>
                <ul>
                    <li><b>Purchase:</b> Here System Users will enter all purchase related information via
                    VAT-Form 6.3 and Bill-of-Entry. They will also have the option of returning purchased
                    products without any hassle.</li>
                    <li><b>Production:</b> Production aids a business in managing its inventory for effective
                    and efficient functioning.</li>
                    <li><b>Sale:</b> Here System Users will enter all sale details via the VAT-Form 6.3 (local
                    or export). They will also be able to issue Cash memo, sales return, and credit/debit
                    note to its clients with ease. </li>
                </ul>
            </div>--%>
        </div>
    </div>
</asp:Content>
