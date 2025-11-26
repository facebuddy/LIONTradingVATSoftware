<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


Route::get('test', 'seng\core\secondaryService@index');
Route::get('slap', 'seng\core\coreService@index');
Route::post('user-login', 'seng\core\coreService@checkCredential');



Route::post('getpartyledger-detail', 'seng\core\coreService@getPartyledgerRpt');







Route::post('receive-indent5', 'seng\core\secondaryService@receiveIndent');

Route::post('receive-indent-new5', 'seng\core\secondaryService@receiveIndentNew');
Route::post('receive-indent-new1', 'seng\core\secondaryService@receiveIndentNew1');

Route::post('sales-order-process', 'seng\core\coreService@salesOrderProcess');




Route::post('get-salesorderlist', 'seng\core\coreService@getSalesOrderListAll');

Route::post('process-invoice-cancel', 'seng\core\coreService@cancelProcessInvoice');


Route::post('getsalesorderbyid', 'seng\core\coreService@getSalesOrderById');
Route::post('purchseentry', 'seng\core\coreService@savePurchaseProduct');





Route::post('UpdateTrackingNumber', 'seng\core\coreService@UpdateTrackingNumber');





Route::post('indententry', 'seng\core\coreService@saveIndentProducts');
Route::post('save-particulars', 'seng\core\coreService@saveParticulars');
Route::post('save-particulars-claim', 'seng\core\coreService@saveParticularsClaim');

Route::post('save-particularsvat', 'seng\core\coreService@saveParticularsVat');

Route::post('get-secondary-listreport', 'seng\core\secondaryService@GetSecondarySalesList');


Route::post('get-salesreport-secondary-all', 'seng\core\reportService@GetSalesReportSecondaryDetailAll');



Route::post('get-salesreport-secondary-all-new', 'seng\core\reportService@GetSalesReportSecondaryDetailAllNew');

Route::post('get-ordercollection-report', 'seng\core\reportService@getOrderCollectionReport');





Route::post('get-chalansummary-report', 'seng\core\reportService@GetChalanReceiveReportDetail');


Route::post('get-primarysales-jp', 'seng\core\reportService@GetSalesPrimaryJP');



///////////////////////////////////MUSHAK VAT UPDATE/////////////////////////////////

Route::post('get-SubForm_k', 'seng\core\reportService@SubForm_k');

Route::post('get-SubForm_k_Note_14', 'seng\core\reportService@SubForm_k_Note_14');

Route::post('get-SubForm_k_Note_14Lakh', 'seng\core\reportService@SubForm_k_Note_14Lakh');


Route::post('get-SubForm_k_Note_14SalesLakh', 'seng\core\reportService@SubForm_k_Note_14SalesLakh');

Route::post('get-MushakSalesReturn', 'seng\core\reportService@MushakSalesReturn');


Route::post('get-MushakSalesReturnMushak6', 'seng\core\reportService@MushakSalesReturnMushak6');

Route::post('get-Subform_Note_31CreditNoteReturn', 'seng\core\reportService@Subform_Note_31CreditNoteReturn');

Route::post('get-productlist', 'seng\core\reportService@gerProductList');
Route::post('get-isProductExist', 'seng\core\reportService@isProductExist');




Route::post('get-secondarysales-jp', 'seng\core\reportService@GetSalesSecondaryJP');

Route::post('get-purchase-jp', 'seng\core\reportService@GetPurchaseJP');




Route::post('getindentdetailsby-invoice', 'seng\core\coreService@getIndentDetailsByInvoice');

Route::post('getpurchasedetailsby-invoice', 'seng\core\coreService@getPurchaseDetailsByInvoice');


Route::post('getallindent-list', 'seng\core\coreService@getIndentListAll');
Route::post('getallindent-list-report', 'seng\core\coreService@getIndentListAllReport');
Route::post('getallindent-list-byuser', 'seng\core\coreService@getIndentListAllReportByUserId');




Route::post('getindentby-id', 'seng\core\coreService@getIndentById');

Route::post('getinvoicereturnby-id', 'seng\core\coreService@invoiceReturnPrintById');
Route::post('get-invoicereturnlist', 'seng\core\coreService@getInvoiceReturnListAll');

Route::post('getsalesorderby-invoice1', 'seng\core\coreService@getSalesOrderByInvoice');
Route::post('get-return-inovoiced', 'seng\core\coreService@getReturnByInvoice');


Route::post('get-purchselist', 'seng\core\coreService@getPurchseList');


Route::post('process-invoice-return', 'seng\core\coreService@processInvoiceReturn');









Route::post('process-invoice-return-secondary', 'seng\core\secondaryService@processInvoiceReturnSecondary');







Route::post('process-invoice', 'seng\core\coreService@processInvoice');
Route::post('get-invoicelist', 'seng\core\coreService@getInvoiceListAll');
Route::post('get-invoicelist-bylocation', 'seng\core\coreService@getInvoiceListAllByLocation');


Route::post('get-chalan-report', 'seng\core\coreService@getChallanReport');

Route::post('get-closingstockreport-secondary', 'seng\core\secondaryService@ClosingStockReportSecondarys');

Route::post('get-closingstockreport-secondary', 'seng\core\secondaryService@ClosingStockReportSecondarys');



Route::post('get-invoicelist-bylocation-primary', 'seng\core\coreService@getInvoiceListAllByLocationPrimary');




Route::post('invoice-print', 'seng\core\coreService@invoicePrintById');

Route::post('invoice-print-new', 'seng\core\coreService@invoicePrintByIdNew');

Route::post('getpass-print', 'seng\core\coreService@getPassPrint');





Route::post('get-invoice-byid', 'seng\core\coreService@invoicePrintByIdInventory');

Route::post('get-stockreceive-detail', 'seng\core\coreService@stockReceiveDetail');

Route::post('get-opening-detail', 'seng\core\coreService@OpeingingstockDetail');


Route::post('get-stockreturn-detail', 'seng\core\coreService@stockReturnDetail');
Route::post('get-salesreport-secondary', 'seng\core\reportService@GetSalesReportSecondaryDetail');


Route::post('get-invoice-byidnew', 'seng\core\coreService@getInvoiceForReturnTwo');


Route::get('getsdata', 'seng\core\coreService@getSessionData');
Route::get('testreport', 'seng\core\reportService@testReport');
Route::post('current-stock', 'seng\core\reportService@InventoryList');
Route::post('current-stock-print', 'seng\core\reportService@InventoryListPrint');
Route::post('price-list', 'seng\core\reportService@product_pricelist');

Route::post('closing-stock', 'seng\core\reportService@GetClosingStockDetail');
Route::post('closing-stock-brandwise', 'seng\core\reportService@GetClosingStockSummaryBrandWise');
Route::post('closing-stockledger-brandwise', 'seng\core\reportService@GetClosingStockLedgerDetail');
Route::post('salesummary-brandwise-pivot', 'seng\core\reportService@BrandWiseSaleSummaryPivot');


Route::post('git-bitoutletinfo', 'seng\core\reportService@getBitOutletInfo');


Route::post('salesummary-brandwise-pivot-sale', 'seng\core\reportService@BrandWiseSaleSummaryPivotNetSale');


Route::post('salesummary-asmwise-pivot', 'seng\core\reportService@ASMWiseBrandWiseSaleSummaryPivot');

Route::post('partyledger-list', 'seng\core\reportService@getPartyLedgerList');
Route::post('partyledger-list-vat', 'seng\core\reportService@getPartyLedgerListVat');
Route::post('collection-reports', 'seng\core\reportService@getCollectionReport');
Route::post('get-collection-reports', 'seng\core\reportService@getCollectionReportPrint');

Route::post('get-adjustment-reports', 'seng\core\reportService@getAdjustmentReport');


Route::post('get-collection-reports-excluding-adjust', 'seng\core\reportService@getCollectionReportExcludingAdjustmentPrint');

Route::post('damage-collection-reports', 'seng\core\reportService@getDamageCollectionReport');



Route::post('get-currentbalance', 'seng\core\reportService@getCurrentBalance');
Route::post('getdetailsales-report', 'seng\core\reportService@GetSalesReportDetail');

Route::post('getnetdetailsales-report', 'seng\core\reportService@GetSalesReportDetailNetSale');


Route::post('sale-summary-new', 'seng\core\reportService@salesSummaryDetailNew');




Route::post('getdetailsales-report-brand', 'seng\core\reportService@GetSalesReportDetailBrand');

Route::post('getnetdetailsales-report-brand', 'seng\core\reportService@GetNetSalesReportDetailBrand');








Route::post('getdailydetailsales-report', 'seng\core\reportService@GetDailySalesReportDetail');
Route::post('get-brandwisesalesummary-report', 'seng\core\reportService@BrandWiseSaleSummary');

Route::post('get-distributorwisesalesummary-report', 'seng\core\reportService@DistributorWiseSummary');


Route::post('get-summary-typewise', 'seng\core\reportService@DistributorWiseSummaryTypeNew');


Route::post('get-asmwisesummary-report', 'seng\core\reportService@ASMWiseSummary');


Route::post('get-mushoksixone-report', 'seng\core\reportService@getmushoksixone');


Route::post('save-distributor', 'seng\core\coreService@saveDistributor');
Route::post('getdistributordatas', 'seng\core\coreService@getDistributorData');
Route::post('update-distributor1', 'seng\core\coreService@updateDistributor');

Route::get('get-particulars-vat/{QUERY}', 'seng\core\reportService@getVatParticularTypeAhend');
Route::get('get-particulars/{QUERY}', 'seng\core\reportService@getParticularTypeAhend');
Route::get('getdistributorall', 'seng\core\coreService@getDistributor');


Route::post('get-targetachivement', 'seng\core\reportService@getTargetAchivementSales');

Route::post('get-targetachivementasm', 'seng\core\reportService@getTargetAchivementSalesASM');
Route::post('get-targetachivementasmsummary', 'seng\core\reportService@getTargetAchivementSalesASMSummary');

Route::post('save-bit', 'seng\core\secondaryService@saveBit');

Route::post('load-sheet', 'seng\core\secondaryService@loadSheetNew');


Route::post('return-collection-report', 'seng\core\secondaryService@ReturnCollectionReport');

Route::post('load-sheet-sale', 'seng\core\secondaryService@loadSheetSale');

Route::get('get-bits', 'seng\core\secondaryService@getBits');
Route::post('get-bits-client', 'seng\core\secondaryService@getBitByCompanyClient');
Route::post('get-discountlist', 'seng\core\secondaryService@productSearchingByScheme');
Route::post('save-discountlist-secondary', 'seng\core\secondaryService@saveProductDiscountListSecondary');





Route::post('update-bit', 'seng\core\secondaryService@updateBit');

Route::post('save-outlet', 'seng\core\secondaryService@saveOutlet');
Route::get('get-outlets', 'seng\core\secondaryService@getOutlets');
Route::post('update-outlet', 'seng\core\secondaryService@updateOutlet');
Route::post('closing-ledger', 'seng\core\secondaryService@getClosingLedger');
Route::post('stock-receive', 'seng\core\secondaryService@stockReceive');
Route::post('current-stock-secondary', 'seng\core\secondaryService@InventoryList');

Route::post('get-bitby-company', 'seng\core\secondaryService@getBitByCompany');
Route::post('get-outletby-company', 'seng\core\secondaryService@getOutletByCompany');

Route::post('get-usersby-type', 'seng\core\secondaryService@getUsersByType');
Route::post('get-delivery-person', 'seng\core\secondaryService@getDeliveryPerson');



Route::post('save-indent-secondary', 'seng\core\secondaryService@saveIndentProducts');

Route::post('get-product-secondary', 'seng\core\secondaryService@getProduct');

Route::post('stock-receive-secondary', 'seng\core\secondaryService@StockReceiveSecondary');














Route::post('getallindent-list-secondary', 'seng\core\secondaryService@getIndentListAllSecondary');
Route::post('stock-receive-secondary-primary', 'seng\core\secondaryService@stockReceivePrimary');

Route::post('get-indent-secondary-by-id', 'seng\core\secondaryService@getIndentSecondary');

Route::post('get-indent-secondary-by-batch', 'seng\core\secondaryService@getIndentSecondaryBatchUpdate');


Route::post('get-indent-secondarysales-by-id', 'seng\core\secondaryService@getIndentSecondarySales');
Route::post('get-indent-secondarysales-by-id-new', 'seng\core\secondaryService@getIndentSecondarySalesNew');



Route::post('salesorder-process-secondary', 'seng\core\secondaryService@salesOrderProcess');
Route::post('sales-order-process-secondary-new', 'seng\core\secondaryService@salesOrderProcessNewFinal');

Route::post('get-delivery-list', 'seng\core\secondaryService@getDeliveryListAllSecondary');

Route::post('get-delivery-list-new', 'seng\core\secondaryService@getDeliveryListAllSecondaryNew');

Route::post('process-invoice-secondary', 'seng\core\secondaryService@processInvoice');


Route::post('process-invoice-secondary-new', 'seng\core\secondaryService@processInvoiceNew');

Route::post('process-invoice-secondary-cancel', 'seng\core\secondaryService@processInvoiceCancel');


Route::post('get-secondary-invoice-fnl', 'seng\core\secondaryService@getInvoiceSecondary');

Route::post('get-delivery-list-secondary', 'seng\core\secondaryService@getDeliveryListAll');



//Route::post('save-distributor', 'seng\core\coreService@saveDistributor');
//Route::post('getdistributordata', 'seng\core\coreService@getDistributorData');

