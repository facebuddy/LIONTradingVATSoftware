var simsService = function(akFileUploaderService, $http) {

    var baseUrl = "http://127.0.0.1:8000/api/";
    var baseUrlService = "http://127.0.0.1:8000/";

    // var baseUrl = "http://sims.timezoneservice.com/api/";
    //var baseUrlService = "http://sims.timezoneservice.com/";

    var saveRole = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "create-role");

    };

    var saveRoleSecondary = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "create-role-secondary");

    };

    var saveComponentGroup = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "save-componentgroup");

    };

    var saveComponent = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "savecomponent");

    };


    var updateRole = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "update-role");

    };

    var updateRoleSecondary = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "update-role-secondary");

    };



    var updateComponent = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "updatecomponent");

    };


    var getMenu = function(Entity) {

        var dataObj = {
            role_id: Entity
        };

        return akFileUploaderService.saveModel(dataObj, baseUrl + "getmenu");
        /* return $http({
         method: 'GET',
         data: dataObj,
         url: baseUrl + 'getmenu',
         headers: {'Content-Type': 'application/json;charset=utf-8'}
         }); */

        // return $http.get(baseUrl + "getmenu");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };

    var getPoducts = function(Entity) {
        return $http.get(baseUrl + "getproducts");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };


    var getAsmList = function(Entity) {
        return $http.get(baseUrl + "getasmlist2");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };







    var getRoles = function() {
        return $http.get(baseUrl + "get-roles");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };

    var getRolesSecondary = function() {
        return $http.get(baseUrl + "get-roles-secondary");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };


    var getParticulars = function() {
        return $http.get(baseUrl + "get-particulars");

    };

    var getParticularsvat = function() {
        return $http.get(baseUrl + "get-particulars-vat1");

    };



    var getComponentGroups = function() {
        return $http.get(baseUrl + "getcomponentgroups");

    };

    var getComponents = function() {
        return $http.get(baseUrl + "getcomponents");

    };


    var getPermissions = function(roleId) {
        return $http({
            method: 'POST',
            data: { id: roleId },
            url: baseUrl + 'get-permissions',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };


    var setSessionData = function(Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'addsdata',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };

    var getProductPrice = function(Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'get-productprice',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };

    var updatePermissions = function(Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'save-permissions',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };


    var saveProduct = function(Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'saveproduct',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };
    var postArray = function(Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'testarray',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
        //return $http.post(Entity, baseUrl + "testarray");
        // return akFileUploaderService.saveModel(Entity, baseUrl + "testarray");
    };




    var savePriceType = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "savepricetype");

    };

    var updatePrice = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "updateprice");

    };

    var getPriceTypes = function() {
        return $http.get(baseUrl + "getpricetype");

    };

    var getUnitTypes = function() {
        return $http.get(baseUrl + "getunittypes");

    };


    var saveUnitType = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "saveunittype");

    };

    var updateProduct = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'updateproduct',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var updateUnitType = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "updateunittype");

    };

    var getProductById = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "getproductbyid");

    };

    var productSearch = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "productsearching");

    };

    var productSearchingByCategory = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "productsearching-bycategory");

    };


    var productSearchingByScheme = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrlService + "get-discountlist");

    };



    var getDiscountById = function(Entity) {
        return akFileUploaderService.saveModel(Entity, baseUrl + "get-productdiscountbyid");

    };

    var saveProductDiscounts = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'save-discountlist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var saveProductDiscountsSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'save-discountlist-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };




    var getDeliveryList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-delivery-list-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };




    var savePurchaseProduct = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'purchseentry',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var saveIndentProducts = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'indententry',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };








    var stockReceiveSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'stock-receive-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };




    var saveIndentProductsSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'save-indent-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };



    var saveParticulars = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'save-particulars',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var saveParticularsClaim = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'save-particulars-claim',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };





    var saveParticularsvat = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'save-particularsvat',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var processSalesOrder = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'sales-order-process',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var processInvoiceCancel = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'process-invoice-cancel',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var processSalesOrderSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'salesorder-process-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var processSalesOrderSecondaryNew = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'sales-order-process-secondary-new',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };



    var processInvoice = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'process-invoice',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var stockReceive = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'stock-receive',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var stockReceivePrimary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'stock-receive-secondary-primary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };





    var processInvoiceReturn = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'process-invoice-return',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var processInvoiceReturnSecondaryIssue = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'process-invoice-return-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getSupliers = function() {
        return $http.get(baseUrl + "getsuppliers");

    };



    var getSRList = function(Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'get-srlist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });



        //  return $http.get(baseUrl + "get-srlist");

    };






    var getBanks = function() {
        return $http.get(baseUrl + "getbanks");

    };



    var getDesignations = function() {
        return $http.get(baseUrl + "getdesignations");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };


    var getDistributors = function() {
        return $http.get(baseUrl + "getdistributors");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };



    var getDepartments = function() {
        return $http.get(baseUrl + "getdepartments");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };


    var getUserLevels = function() {
        return $http.get(baseUrl + "getuserlevels");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };

    var getCompanies = function() {
        return $http.get(baseUrl + "getcompanys");
        // return akFileUploaderService.saveModel(Entity, baseUrl+"getmenu");
    };


    var getIndentList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getallindent-list',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };



    var getIndentListSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getallindent-list-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getIndentListByUser = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getallindent-list-byuser',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };






    var getIndentListReporting = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getallindent-list-report',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };




    var getInvoiceReturnListReporting = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-invoicereturnlist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };







    var getIndentListByUser = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getallindent-list-report',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getcurrentCreditBalance = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-currentbalance',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getIndentListReport = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            // url: baseUrl + 'getIndentDetailsByInvoice',

            url: baseUrlService + 'getindentdetailsby-invoice',

            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getSalesOrderList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-salesorderlist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getCurrentStockList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'current-stock',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getCurrentStockListSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'current-stock-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getCollectionReport = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'collection-reports',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getDamageCollectionReport = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'damage-collection-reports',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };





    var getClosingStockList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'closing-stock',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };



    var getIndentById = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getindentby-id',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getIndentByIdSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-indent-secondary-by-id',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getIndentByIdSecondaryBatch = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-indent-secondary-by-batch',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };



    var getSalesOrderByInvoice = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getsalesorderby-invoice1',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };







    var getInvoiceReturned = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-return-inovoiced',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };





    var getSalesOrderById = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'getsalesorderbyid',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getInvioceList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-invoicelist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getInvioceListByLocation = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-invoicelist-bylocation',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getchalanReportSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-chalan-report',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getReturnInvioceListByLocationPrimary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-invoicelist-bylocation-primary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };
    var getReturnInvioceListByLocationSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-invoicelist-bylocation',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };








    var getInvioceById = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-invoice-byid',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getInvioceByIdNew = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-invoice-byidnew',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };





    var getPurchaseList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-purchselist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var saveBit = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'save-bit',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var updateBit = function(Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'update-bit',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };

    var getBits = function() {
        return $http.get(baseUrlService + "get-bits");

    };



    var saveOutlet = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'save-outlet',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var updateOutlet = function(Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'update-outlet',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };

    var getOutlets = function() {
        return $http.get(baseUrlService + "get-outlets");

    };


    var getDevisions = function() {
        return $http.get(baseUrl + "getdivisionlist");

    };


    var getDistricts = function(divisionId) {
        return $http.get(baseUrl + "getgeodatalist?id=" + divisionId + "&len=" + 4);

    };



    var getUpazila = function(districtId) {
        return $http.get(baseUrl + "getgeodatalist?id=" + districtId + "&len=" + 6);

    };

    var getClosingLedgerList = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'closing-ledger',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getDeliveryListSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-delivery-list',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };




    var getDeliveryListSecondaryNew = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-delivery-list-new',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getsalesListSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-indent-secondarysales-by-id',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getsalesListSecondaryNew = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-indent-secondarysales-by-id-new',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };



    var getOutletListByCompany = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-outletby-company',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getBitListByCompany = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-bitby-company',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getUsersByType = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-usersby-type',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var getDeliveryPerson = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-delivery-person',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };


    var getProductSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-product-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var processInvoiceSecondary = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'process-invoice-secondary',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };




    var processInvoiceSecondaryNew = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'process-invoice-secondary-new',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };






    var processInvoiceSecondaryCancel = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'process-invoice-secondary-cancel',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };









    var getSaleSummaryDistributorWise = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-distributorwisesalesummary-report',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };





    var getSaleSummaryDistributorWiseType = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-summary-typewise',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };






    var getSaleSummaryASMWise = function(Entity) {

        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrlService + 'get-asmwisesummary-report',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };







    return {
        saveRole: saveRole,
        getMenu: getMenu,
        getRoles: getRoles,
        postArray: postArray,
        updateRole: updateRole,
        getPermissions: getPermissions,
        updatePermissions: updatePermissions,
        saveComponentGroup: saveComponentGroup,
        getComponentGroups: getComponentGroups,
        saveComponent: saveComponent,
        getComponents: getComponents,
        updateComponent: updateComponent,
        saveProduct: saveProduct,
        savePriceType: savePriceType,
        getPriceTypes: getPriceTypes,
        updatePrice: updatePrice,
        getUnitTypes: getUnitTypes,
        saveUnitType: saveUnitType,
        updateUnitType: updateUnitType,
        getPoducts: getPoducts,
        getProductById: getProductById,
        productSearch: productSearch,
        updateProduct: updateProduct,
        productSearchingByCategory: productSearchingByCategory,
        saveProductDiscounts: saveProductDiscounts,
        getDiscountById: getDiscountById,
        getSupliers: getSupliers,
        savePurchaseProduct: savePurchaseProduct,
        getDepartments: getDepartments,
        getUserLevels: getUserLevels,
        getCompanies: getCompanies,
        getDesignations: getDesignations,
        saveIndentProducts: saveIndentProducts,
        getIndentList: getIndentList,
        getIndentById: getIndentById,
        processSalesOrder: processSalesOrder,
        getSalesOrderList: getSalesOrderList,
        getSalesOrderById: getSalesOrderById,
        getIndentListReport: getIndentListReport,
        processInvoice: processInvoice,
        getInvioceList: getInvioceList,
        setSessionData: setSessionData,
        getProductPrice: getProductPrice,
        getCurrentStockList: getCurrentStockList,
        saveParticulars: saveParticulars,
        getcurrentCreditBalance: getcurrentCreditBalance,
        getDistributors: getDistributors,
        getAsmList: getAsmList,
        getSalesOrderByInvoice: getSalesOrderByInvoice,
        processInvoiceReturn: processInvoiceReturn,

        getIndentListReporting: getIndentListReporting,
        getPurchaseList: getPurchaseList,

        saveParticularsvat: saveParticularsvat,

        getIndentListByUser: getIndentListByUser,
        getClosingStockList: getClosingStockList,
        getParticulars: getParticulars,
        getBanks: getBanks,
        saveParticularsClaim: saveParticularsClaim,
        getCollectionReport: getCollectionReport,

        getParticularsvat: getParticularsvat,
        getInvoiceReturnListReporting: getInvoiceReturnListReporting,
        getRolesSecondary: getRolesSecondary,
        saveRoleSecondary: saveRoleSecondary,
        updateRoleSecondary: updateRoleSecondary,
        getInvioceListByLocation: getInvioceListByLocation,
        getInvioceById: getInvioceById,
        saveBit: saveBit,
        getBits: getBits,
        updateBit: updateBit,
        getDistricts: getDistricts,
        getDevisions: getDevisions,
        updateOutlet: updateOutlet,
        saveOutlet: saveOutlet,
        getOutlets: getOutlets,
        getClosingLedgerList: getClosingLedgerList,
        stockReceive: stockReceive,
        getCurrentStockListSecondary: getCurrentStockListSecondary,
        getOutletListByCompany: getOutletListByCompany,
        getBitListByCompany: getBitListByCompany,
        getUsersByType: getUsersByType,
        getProductSecondary: getProductSecondary,
        saveIndentProductsSecondary: saveIndentProductsSecondary,
        getIndentListSecondary: getIndentListSecondary,
        getIndentByIdSecondary: getIndentByIdSecondary,
        processSalesOrderSecondary: processSalesOrderSecondary,
        getDeliveryListSecondary: getDeliveryListSecondary,
        getsalesListSecondary: getsalesListSecondary,
        processInvoiceSecondary: processInvoiceSecondary,
        getDamageCollectionReport: getDamageCollectionReport,
        getSaleSummaryDistributorWise: getSaleSummaryDistributorWise,
        getSaleSummaryASMWise: getSaleSummaryASMWise,
        processInvoiceCancel: processInvoiceCancel,
        getDeliveryPerson: getDeliveryPerson,
        productSearchingByScheme: productSearchingByScheme,
        saveProductDiscountsSecondary: saveProductDiscountsSecondary,
        getDeliveryList: getDeliveryList,
        getSaleSummaryDistributorWiseType: getSaleSummaryDistributorWiseType,
        getUpazila: getUpazila,
        stockReceiveSecondary: stockReceiveSecondary,
        getInvoiceReturned: getInvoiceReturned,
        processInvoiceReturnSecondaryIssue: processInvoiceReturnSecondaryIssue,
        getReturnInvioceListByLocationPrimary: getReturnInvioceListByLocationPrimary,
        getInvioceByIdNew: getInvioceByIdNew,
        stockReceivePrimary: stockReceivePrimary,
        getSRList: getSRList,
        getchalanReportSecondary: getchalanReportSecondary,
        getIndentByIdSecondaryBatch: getIndentByIdSecondaryBatch,
        processSalesOrderSecondaryNew: processSalesOrderSecondaryNew,
        getDeliveryListSecondaryNew: getDeliveryListSecondaryNew,
        getsalesListSecondaryNew: getsalesListSecondaryNew,
        processInvoiceSecondaryNew: processInvoiceSecondaryNew,
        processInvoiceSecondaryCancel: processInvoiceSecondaryCancel

    };
};


angular.module('myApps').factory('simsService', simsService);