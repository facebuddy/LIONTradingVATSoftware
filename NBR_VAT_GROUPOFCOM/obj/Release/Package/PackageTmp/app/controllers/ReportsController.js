'use strict';
var ReportsController = function ($scope, $filter, $log, $window, simsService) {

    // var baseUrl = "http://cr.time-zone.biz/"
    // var baseUrl = "http://localhost:51592/"
    var baseUrl = "http://cr.time-zone.biz/"

    const PRODUCT_GROUP_ID = 1;
    $scope.title = "Product Component";
    $scope.menuData = [];
    $scope.menu = [];
    $scope.componetnGroupList = [];
    $scope.componetList = [];
    $scope.componetListDD = [];
    $scope.componetListDis = [];
    $scope.componetListflt = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 5;
    $scope.totalItems = 0;
    $scope.priceTypes = [];
    $scope.unitTypes = [];
    $scope.employeeListASR = [];
    $scope.saleDistributorWise = [];
    $scope.componentListTemp = [];
    $scope.productObj = null;
    $scope.showMsgsCompoent = false;
    $scope.Entity = {};
    $scope.purchaseList = [];
    $scope.collectionList = [];
    $scope.damageCollectionList = [];
    // $scope.Entity.priceListTemp=[];
    //$scope.Entity.componentListTemp=[];
    $scope.priceListTemp = [];
    $scope.productList = [];
    $scope.productListDis = [];
    $scope.showMsgs = false;
    $scope.productObjListDis = [];
    $scope.asmList = [];
    $scope.groups = [];
    $scope.categories = [];
    $scope.brands = [];
    $scope.subgroups = [];
    $scope.sizes = [];
    $scope.subbrands = [];
    $scope.variants = [];

    $scope.distributors = [];
    $scope.totalOpening = 0;
    $scope.totalReceive = 0;
    $scope.totalSales = 0;
    $scope.totalSaleReturn = 0;
    $scope.totalClosing = 0;
    //$scope.Entity.asm_id="0";
    $scope.DisplayModal = function (mode, title, id) {
        if (mode == 'Add') {
            $scope.Add = true;
            $scope.Update = false;
            $scope.title = title;
            $scope.Entity = {};
            $scope.Display = false;

        } else if (mode == 'Display') {
            $scope.Add = false;
            $scope.Update = false;
            $scope.title = title;
            $scope.Display = true;

            $scope.getPermissions(id);

            //$scope.Entity = $filter('filter')($scope.roles, function(d) { return d.Id === id; })[0];
        } else if (mode == 'Update') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;

            $scope.Entity = $filter('filter')($scope.productList, function (d) {
                return d.component_id === id;
            })[0];
            if ($scope.Entity.status == 1) {
                $scope.Entity.status = true;
            } else {
                $scope.Entity.status = false;

            }


        }
    }


    $scope.UpdateModal = function (mode, title, id) {
        if (mode == 'Add') {
            $scope.Add = true;
            $scope.Update = false;
            $scope.title = title;
            $scope.Entity = {};
            $scope.Display = false;

        } else if (mode == 'Display') {
            $scope.Add = false;
            $scope.Update = false;
            $scope.title = title;
            $scope.Display = true;

            $scope.getPermissions(id);

            //$scope.Entity = $filter('filter')($scope.roles, function(d) { return d.Id === id; })[0];
        } else if (mode == 'Update') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;
            var data = {
                product_id: id
            };

            $scope.getPoductsById(data);


        }
    }










    $scope.pageChanged = function () {
        var begin = (($scope.currentPage - 1) * $scope.itemsPerPage),
                end = begin + $scope.itemsPerPage;
        // $scope.componetListflt = $scope.componetList.slice(begin, end);
    };

    $scope.filterChanged = function () {
        $scope.currentPage = 1;
        // $scope.componetListflt = $scope.componetList.slice(begin, end);
    };

    $scope.getComponentGroups = function () {

        var response = simsService.getComponentGroups();
        response.then(function (list) {

            $scope.componetnGroupList = list.data;
            console.log("Componet Group:" + JSON.stringify($scope.componetnGroupList));

        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getDistributors = function () {

        var response = simsService.getDistributors();
        response.then(function (list) {

            $scope.distributors = list.data;
            console.log("Distributor list:" + JSON.stringify($scope.distributors));

        }, function () {
            alert('Error in getting records');
        });
    }


    $scope.getAsmList = function () {

        var response = simsService.getAsmList();
        response.then(function (list) {

            $scope.asmList = list.data;
            console.log("ASM list:" + JSON.stringify($scope.asmList));

        }, function () {
            alert('Error in getting records');
        });
    }



    $scope.popitupPartyLedger = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "PartyLedger?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id, '_blank', 'height=800,width=1000');
    };



    $scope.popitupVatSixOne = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "VatSixOne?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&product_id=" + Entity.product_id, '_blank', 'height=800,width=1000');
    };


    $scope.popitupVatLedger = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "VatLedger?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date, '_blank', 'height=800,width=1000');
    };


    $scope.popitupIndent = function (url) {
        return $window.open(baseUrl + "IndentDetails.aspx?invoice_no=" + url, '_blank', 'height=800,width=1000');
    };

    $scope.popitupPurchase = function (url) {
        return $window.open(baseUrl + "PurchaseDetails.aspx?invoice_no=" + url, '_blank', 'height=800,width=1000');
    };


    $scope.popitupSalesSKU = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SalesdetailReport.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&asm_id=" + Entity.asm_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };


    $scope.popitupSalesSKUNetSale = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "NetSalesdetailReport.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&asm_id=" + Entity.asm_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };


    $scope.popitupSalesSKUNetSaleBrandWise = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "netSalesdetailReportBrand.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&asm_id=" + Entity.asm_id + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };



    $scope.popitupSalesSKUNetChallanSummaryBrandWise = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "ChallanSummaryReport?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&subbrand_id=" + Entity.subbrand_id, '_blank', 'height=800,width=1000');
    };

    $scope.popitupSalesSKUSecondary = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        Entity.company_id = getCookie('company_id');
        return $window.open(baseUrl + "SalesdetailReportSecondary?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.company_id + "&asm_id=" + Entity.asm_id + "&sr_id=" + Entity.sr_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };


    $scope.collectionPrintWithoutAdjustment = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "CollectionReportExAdjustment.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date, '_blank', 'height=800,width=1000');
    };

    $scope.collectionAdjustmentReport = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "AdjustmentCollectionReport.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date, '_blank', 'height=800,width=1000');
    };
    $scope.popitupSalesSKUSecondaryMis = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        //Entity.company_id = getCookie('company_id');

        if (Entity.distributor_id > 0)
        {
            return $window.open(baseUrl + "SalesDetailSecondaryMis?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&asm_id=" + Entity.asm_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
        } else {
            return $window.open(baseUrl + "SalesDetailSecondaryMisAll?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&asm_id=" + Entity.asm_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
        }

    };


    $scope.popitupSalesSKUSecondaryMisReport = function (Entity) {


       Entity.sales_start_date = $("#sales_start_date").val();
        Entity.sales_end_date = $("#sales_end_date").val();
        Entity.chalan_start_date = $("#chalan_start_date").val();
        Entity.chalan_end_date = $("#chalan_end_date").val();
        //Entity.company_id = getCookie('company_id');

       
            return $window.open(baseUrl + "SecondarySaleSummaryBrandWisePivot?sales_start_date=" + Entity.sales_start_date + "&sales_end_date=" + Entity.sales_end_date + "&chalan_start_date=" + Entity.sales_start_date + "&chalan_end_date=" + Entity.sales_end_date + "&company_id=" + Entity.distributor_id + "&asm_id=" + Entity.asm_id, '_blank', 'height=800,width=1000');
        


    };

    $scope.popitupSaleSummaryNew = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SalesSummaryReport.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&asm_id=" + Entity.asm_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };





    $scope.TargetAchivementSearchingReport = function (Entity) {


        Entity.month = $("#month").val();
        Entity.year = $("#year").val();
        return $window.open(baseUrl + "TargetAchivement.aspx?year=" + Entity.year + "&month=" + Entity.month, '_blank', 'height=800,width=1000');
    };


    $scope.TargetAchivementSearchingReportASM = function (Entity) {


        Entity.month = $("#month").val();
        Entity.year = $("#year").val();
        return $window.open(baseUrl + "TargetAchivementAsm.aspx?year=" + Entity.year + "&month=" + Entity.month, '_blank', 'height=800,width=1000');
    };


    $scope.TargetAchivementSearchingReportASMSummary = function (Entity) {


        Entity.month = $("#month").val();
        Entity.year = $("#year").val();
        return $window.open(baseUrl + "TargetAchivementAsmSummary.aspx?year=" + Entity.year + "&month=" + Entity.month, '_blank', 'height=800,width=1000');
    };

    $scope.TargetAchivementSearchingReportPivot = function (Entity) {


        Entity.month = $("#month").val();
        Entity.year = $("#year").val();
        return $window.open(baseUrl + "TargetAchivementPivot.aspx?year=" + Entity.year + "&month=" + Entity.month, '_blank', 'height=1000,width=1500');
    };

    $scope.TargetAchivementSearchingReportASMPivot = function (Entity) {


        Entity.month = $("#month").val();
        Entity.year = $("#year").val();
        return $window.open(baseUrl + "TargetAchivementASMPivot.aspx?year=" + Entity.year + "&month=" + Entity.month, '_blank', 'height=1000,width=1500');
    };

    $scope.popitupSalesSKUBrand = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SalesdetailReportBrand.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&asm_id=" + Entity.asm_id + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };


    $scope.popitupSalesDaily = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SalesdetailReportDaily.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&asm_id=" + Entity.asm_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };




    $scope.collectionPrint = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "CollectionReport.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date, '_blank', 'height=800,width=1000');
    };







    $scope.popitupStockSKUwise = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "StockSummaryLedgerBrandWise.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };



    $scope.popitupClosingStockSecondary = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        Entity.distributor_id = getCookie('company_id');
        return $window.open(baseUrl + "StockSummaryLedgerBrandWiseSecondary.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };


    $scope.currentStockPrint = function (Entity) {

        return $window.open(baseUrl + "CurrentStockSummaryLedger.aspx?company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=700,width=1000');
    };

    $scope.popitupStockBrandwise = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "StockSummaryBrandWise.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };


    $scope.BrandwiseSaleSummary = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SaleSummaryBrandWise.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&asm_id=" + Entity.asm_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };

    $scope.DistributorWiseSaleSummary = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SaleSummaryDistributorWise.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&asm_id=" + Entity.asm_id, '_blank', 'height=800,width=1000');
    };


    $scope.BrandwisePivot = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SaleSummaryBrandWisePivot.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&asm_id=" + Entity.asm_id + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };


    $scope.ASMBrandwisePivot = function (Entity) {


        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        return $window.open(baseUrl + "SaleSummaryASMBrandWisePivot.aspx?start_date=" + Entity.start_date + "&end_date=" + Entity.end_date + "&asm_id=" + Entity.asm_id + "&company_id=" + Entity.distributor_id + "&category_id=" + Entity.category_id + "&brand_id=" + Entity.brand_id + "&group_id=" + Entity.group_id + "&subbrand_id=" + Entity.subbrand_id + "&variant_id=" + Entity.variant_id + "&size_id=" + Entity.size_id + "&package_id=" + Entity.package_id + "&product_name=" + Entity.product_name, '_blank', 'height=800,width=1000');
    };



    $scope.getComponents = function () {

        var response = simsService.getComponents();
        response.then(function (list) {

            $scope.componetList = list.data;
            $scope.currentPage = 1;

            $scope.totalItems = $scope.componetList.length;
            $scope.componetListflt = $scope.componetList;
            $scope.componetListDis = $filter('filter')($scope.componetList, {component_group_id: PRODUCT_GROUP_ID});


            $scope.groups = $filter('filter')($scope.componetList, {component_group_id: 1});

            $scope.categories = $filter('filter')($scope.componetList, {component_group_id: 4});
            $scope.brands = $filter('filter')($scope.componetList, {component_group_id: 2});
            $scope.subgroups = $filter('filter')($scope.componetList, {component_group_id: 3});
            $scope.packages = $filter('filter')($scope.componetList, {component_group_id: 5});
            $scope.sizes = $filter('filter')($scope.componetList, {component_group_id: 6});
            $scope.subbrands = $filter('filter')($scope.componetList, {component_group_id: 7});
            $scope.variants = $filter('filter')($scope.componetList, {component_group_id: 8});


        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.savePurchaseProduct = function (Entity) {
        console.log(JSON.stringify(Entity));


    }


    $('.typeahead').on('typeahead:selected', function (evt, item) {
        //var data=  $('#new').val(item);
        // alert(item);
        // do what you want with the item here
    })
    $scope.productChange = function (Entity, $event) {


        // alert("ok");
        console.log("sweety" + Entity);


    }





    $scope.totalqtyPCS = 0;
    $scope.totalCtn = 0;
    $scope.totalPurchase = 0;
    $scope.totalRebate = 0;
    $scope.calculateTotalPurchase = function ()
    {



        $scope.purchaseList.forEach(function (item) {

            $scope.totalqtyPCS += parseInt(item['total_pcs_quantity_purchase'])
            $scope.totalCtn += parseFloat(item['total_qtn_quantity_purchase']);
            $scope.totalPurchase += parseFloat(item['netamount_purchase']);
            $scope.totalRebate += parseFloat(item['purchase_rebate_amount_total']);

        });




    };






    $('#productitem').find('option').click(function () {
        var optionSelected = $(this);
        var valueSelected = optionSelected.val();
        var textSelected = optionSelected.text();
    });

    $scope.testing = "data changed";
    $scope.getPrices = function () {

        var response = simsService.getPriceTypes();
        response.then(function (list) {

            $scope.priceTypes = list.data;


            console.log("Price Type:" + JSON.stringify($scope.priceTypes));


        }, function (error) {
            toastr.error(error.data);
        });
    }
    $scope.getUnitTypes = function () {

        var response = simsService.getUnitTypes();
        response.then(function (list) {

            $scope.unitTypes = list.data;

            console.log("Unit types" + JSON.stringify($scope.unitTypes));
        }, function (error) {
            toastr.error(error.data);
        });
    }

    $scope.getASRList = function (Entity) {

        var data = {
            company_id: getCookie('company_id'),
            user_type: Entity
        };
        var response = simsService.getSRList(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.employeeListASR = list.data;
            console.log("Bit List" + JSON.stringify($scope.bitList));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.getCurrentStock = function (Entity) {
        $scope.pg = true;

        var response = simsService.getCurrentStockList(Entity);
        response.then(function (list) {

            $scope.productList = list.data;
            console.log("Product List" + JSON.stringify($scope.productList));
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalTp = 0;
            $scope.totalDp = 0;
            /* $scope.productList.forEach(function (item) {
             
             $scope.totalPcs += parseInt(item['stock']);
             $scope.totalCtn += parseFloat(item['stock_qtn']);
             $scope.totalDp += parseInt(item['product_price'] * item['stock']);
             $scope.totalTp += parseFloat(item['tp_price'] * item['stock']);
             
             
             
             });*/


            $scope.pg = false;

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }















    $scope.priceList = function () {

        return $window.open(baseUrl + "PriceList.aspx", '_blank', 'height=700,width=1000');
    };

    $scope.getCurrentStockListSecondary = function (Entity) {
        $scope.pg = true;
        Entity.company_id = getCookie('company_id');
        var response = simsService.getCurrentStockListSecondary(Entity);
        response.then(function (list) {

            $scope.productList = list.data;
            console.log("Product List" + JSON.stringify($scope.productList));
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalTp = 0;
            $scope.totalDp = 0;
            $scope.productList.forEach(function (item) {

                $scope.totalPcs += parseInt(item['stock']);
                $scope.totalCtn += parseFloat(item['stock_qtn']);
                $scope.totalDp += parseInt(item['product_price'] * item['stock']);
                $scope.totalTp += parseFloat(item['tp_price'] * item['stock']);



            });


            $scope.pg = false;

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }





    $scope.getClosingStockList = function (Entity) {
        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();

        var response = simsService.getClosingStockList(Entity);
        response.then(function (list) {

            $scope.productList = list.data;

            console.log("Closing Stock List " + JSON.stringify($scope.productList));
            $scope.totalOpening = 0;
            $scope.totalReceive = 0;
            $scope.totalSales = 0;
            $scope.totalSaleReturn = 0;
            $scope.totalClosing = 0;

            $scope.productList.forEach(function (item) {

                $scope.totalOpening += parseInt(item['OpeningQty']);
                $scope.totalReceive += parseInt(item['receive_qty']);
                $scope.totalSales += parseInt(item['sale_qty']);
                $scope.totalSaleReturn += parseInt(item['sale_return_qty']);
                $scope.totalClosing += parseInt(item['ClosingQty']);



            });


            $scope.pg = false;

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }


    $scope.getCollectionReport = function (Entity) {
        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();

        var response = simsService.getCollectionReport(Entity);
        response.then(function (list) {

            $scope.collectionList = list.data;

            console.log("Closing Stock List " + JSON.stringify($scope.collectionList));
            $scope.totalAmount = 0.00;
            // $scope.totalReceive = 0;
            //$scope.totalSales = 0;
            // $scope.totalSaleReturn = 0;
            // $scope.totalClosing = 0;

            $scope.collectionList.forEach(function (item) {

                $scope.totalAmount += parseFloat(item['amount']);
                // $scope.totalReceive += parseInt(item['receive_qty']);
                // $scope.totalSales += parseInt(item['sale_qty']);
                //$scope.totalSaleReturn += parseInt(item['sale_return_qty']);
                //$scope.totalClosing += parseInt(item['ClosingQty']);



            });


            $scope.pg = false;

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }



    $scope.getDamageCollectionReport = function (Entity) {
        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();

        var response = simsService.getDamageCollectionReport(Entity);
        response.then(function (list) {

            $scope.damageCollectionList = list.data;

            console.log("Closing Stock List " + JSON.stringify($scope.collectionList));
            $scope.totalAmount = 0.00;
            // $scope.totalReceive = 0;
            //$scope.totalSales = 0;
            // $scope.totalSaleReturn = 0;
            // $scope.totalClosing = 0;

            $scope.collectionList.forEach(function (item) {

                $scope.totalAmount += parseFloat(item['amount']);
                // $scope.totalReceive += parseInt(item['receive_qty']);
                // $scope.totalSales += parseInt(item['sale_qty']);
                //$scope.totalSaleReturn += parseInt(item['sale_return_qty']);
                //$scope.totalClosing += parseInt(item['ClosingQty']);



            });


            $scope.pg = false;

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }








    $scope.purchaseSearchingReport = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        var response = simsService.getPurchaseList(Entity);
        response.then(function (list) {

            $scope.purchaseList = list.data;

            $scope.pg = false;
            $scope.calculateTotalPurchase();
            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.productSearching = function (Entity) {

        var response = simsService.productSearch(Entity);
        response.then(function (list) {

            $scope.productList = list.data;

            console.log("Product Object" + JSON.stringify($scope.productObj));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.productSearchingByCategory = function (Entity) {

        var data = {
            group_id: Entity
        };

        var response = simsService.productSearchingByCategory(data);
        response.then(function (list) {

            $scope.productListDis = list.data;


            // console.log("Product Object" + JSON.stringify($scope.productObj));
        }, function (error) {
            toastr.error(error.data);
        });
    }







    $scope.CheckUncheckHeader = function () {
        // $scope.IsAllChecked = true;

        if ($scope.IsAllChecked)
        {
            for (var i = 0; i < $scope.productListDis.length; i++) {

                $scope.productListDis[i].isSelected = true;

            }

        } else {
            for (var i = 0; i < $scope.productListDis.length; i++) {

                $scope.productListDis[i].isSelected = false;

            }


        }

    };


    $scope.AllDiscountChange = function (Entity) {
        // $scope.IsAllChecked = true;

        for (var i = 0; i < $scope.productListDis.length; i++) {

            $scope.productListDis[i].discount_amount_primary = parseFloat(Entity);

        }





    };












    $scope.init = function () {


        $('.date').datetimepicker({
            format: 'YYYY-MM-DD',

        });


        var baseUrl = 'http://sims.timezoneservice.com/api/findProductQuery';
        // var baseUrl = 'http://127.0.0.1:8000/api/findProductQuery';
        $(document).ready(function () {
            var findProductQuery = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,

                remote: {
                    url: baseUrl + '/%QUERY',
                    wildcard: '%QUERY'
                }
            });
            $('#productQry .typeahead').typeahead(null, {
                limit: 50,
                name: 'name',
                display: 'name',
                source: findProductQuery
            });
        });





    };


    $('#productQry .typeahead').on('typeahead:selected', function (evt, item) {


        //$scope.productObjListDis[0].name=item.name;
        //$scope.productObjListDis[0].product_id=item.product_id;
        //$scope.productObjListDis[0].discount_amount_primary=0;
        /* var data = {
         product_id: item.product_id
         };
         
         var response = simsService.getDiscountById(data);
         response.then(function (list) {
         
         $scope.productObjListDis = list.data;
         
         // console.log("Product Object" + JSON.stringify($scope.productObj));
         }, function (error) {
         toastr.error(error.data);
         }); */
        $("#product_id").val(item.product_id);
        $scope.Entity.product_id = item.product_id;
        // $("#currentProductId").val(item.product_id);
        // $("#productCurrentUnitPcs").val(item.pics_qty);
        //$("#productName").val(item.name);
        // $("#currentBarcode").val(item.barcode);






    })







    // $scope.getUnitTypes();
    // $scope.getComponentGroups();
    $scope.getComponents();
    // $scope.getPrices();
    // $scope.getPoducts();
    $scope.getASRList(11);
    $scope.getDistributors();
    $scope.getAsmList();

    //$scope.getGroupList();

}


angular.module('myApps')
        .controller('ReportsController', ReportsController);
