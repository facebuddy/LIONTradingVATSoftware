'use strict';
var PurchaseController = function ($scope, $filter, $log, simsService) {
    $scope.title = "Product Component";
    $scope.menuData = [];
    $scope.menu = [];
    $scope.componetnGroupList = [];
    $scope.componetList = [];
    $scope.componetListDD = [];
    $scope.componetListflt = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 5;
    $scope.totalItems = 0;
    $scope.priceTypes = [];
    $scope.unitTypes = [];
    $scope.componentListTemp = [];
    $scope.productObj = {};
    $scope.totalPcs = 0;
    $scope.totalCtn = 0;
    $scope.totalCost = 0;
    $scope.totalRebate = 0;
    $scope.supplierList = []
    $scope.showMsgs = false;
    $scope.priceList = [];
    $scope.productListTemp = [];
    $scope.EntityObj = {};
    $scope.purchaseList = [];
    $scope.Entity = {};
    $scope.netCost = 0;
    $scope.pg = false;
    $scope.EntityObj.rebate = 15;

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

            $scope.Entity = $filter('filter')($scope.componetListflt, function (d) {
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


    $scope.addProductComponent = function () {
        var id = $scope.Entity.component_id;
        $scope.EntityObj = $filter('filter')($scope.componetList, function (d) {
            return d.component_id == id;
        })[0];

        const getComponent = $scope.componentListTemp.find(component => component.component_id === id);

        if (getComponent === undefined)
        {
            $scope.componentListTemp.push($scope.EntityObj);
            $scope.Entity.componentListTemp = $scope.componentListTemp;
        } else
        {
            toastr.error('Already exist this component');
        }

    }

    $scope.addProductComponentUpd = function () {
        var id = $scope.Entity.component_id;
        $scope.EntityObj = $filter('filter')($scope.componetList, function (d) {
            return d.component_id == id;
        })[0];


        const getComponent = $scope.Entity.componentListTemp.find(component => component.component_id === id);

        if (getComponent === undefined)
        {
            $scope.Entity.componentListTemp.push($scope.EntityObj);

        } else
        {
            toastr.error('Already exist this component');
        }

        // $scope.Entity.componentListTemp = $scope.componentListTemp;
    }




    $scope.addProductPrice = function (priceId, price, Entity) {
        // var id = $scope.Entity.component_id;
        $scope.EntityPriceObj = $filter('filter')($scope.priceTypes, function (d) {
            return d.id == priceId;
        })[0];
        $scope.EntityPriceObj.price = price;


        const getPrice = $scope.priceListTemp.find(price => price.id === priceId);

        if (getPrice === undefined)
        {
            $scope.priceListTemp.push($scope.EntityPriceObj);
            Entity.priceListTemp = $scope.priceListTemp;
            console.log("Price List" + JSON.stringify(Entity.priceListTemp));

        } else
        {
            toastr.error('Already exist this price');
        }



    }

    $scope.addProductPriceUpd = function (priceId, price, Entity) {
        // var id = $scope.Entity.component_id;
        $scope.EntityPriceObj = $filter('filter')($scope.priceTypes, function (d) {
            return d.id == priceId;
        })[0];


        const getPrice = Entity.priceListTemp.find(price => price.id === priceId);

        if (getPrice === undefined)
        {
            $scope.EntityPriceObj.price = price;
            Entity.priceListTemp.push($scope.EntityPriceObj);


        } else
        {
            toastr.error('Already exist this price');
        }


        // Entity.priceListTemp = $scope.priceListTemp;
        // console.log("Price List" + JSON.stringify(Entity.priceListTemp));
    }


    $scope.removeComponent = function (id) {

        $scope.componentListTemp = $filter('filter')($scope.componentListTemp, function (item) {
            return !(item.component_id == id);
        });
        $scope.Entity.componentListTemp = $scope.componentListTemp;

    }

    $scope.removeComponent = function (id) {

        $scope.componentListTemp = $filter('filter')($scope.componentListTemp, function (item) {
            return !(item.component_id == id);
        });
        $scope.Entity.componentListTemp = $scope.componentListTemp;

    }

    $scope.removeProductPurchseList = function (id) {

        $scope.purchaseList = $filter('filter')($scope.purchaseList, function (item) {
            return !(item.product_id == id);
        });
        $scope.totalPcs = 0;
        $scope.totalCtn = 0;
        $scope.totalCost = 0;
        $scope.totalRebate = 0;
        $scope.netCost = 0;
        $scope.purchaseList.forEach(function (item) {

            $scope.totalPcs += parseInt(item['unit_pcs']);
            $scope.totalCtn += parseFloat(item['unit_ctn']);
            $scope.totalCost += parseInt(item['total_amount']);
            $scope.netCost += parseInt(item['net_amount']);
            $scope.totalRebate += parseFloat(item['rebate_amount']);


        });

        if ($scope.purchaseList.length == 0)
        {
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalCost = 0;
            $scope.netCost = 0;
            $scope.totalRebate = 0;


        }
        $scope.EntityObj = {};


    }


    $scope.removePriceType = function (id) {

        $scope.priceListTemp = $filter('filter')($scope.priceListTemp, function (item) {
            return !(item.id == id);
        });
        $scope.Entity.priceListTemp = $scope.priceListTemp;

    }

    $scope.removePriceTypeUpd = function (id) {

        $scope.Entity.priceListTemp = $filter('filter')($scope.Entity.priceListTemp, function (item) {
            return !(item.id == id);
        });


    }

    $scope.saveComponentGroup = function (Entity) {

        simsService.saveComponentGroup(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);
                    $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
    }

    $scope.groupChange = function (Entity) {
        $scope.componetListDD = null;
        $scope.componetListDD = $filter('filter')($scope.componetList, {component_group_id: Entity});
    }

    $scope.saveComponent = function (Entity) {

        simsService.saveComponent(Entity)
                .then(function (msg) {

                    toastr.success("Component List" + msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
    }

    $scope.saveProduct = function (Entity) {
        console.log("Product Post data" + Entity);

        simsService.saveProduct(Entity)
                .then(function (msg) {
                    console.log("data" + JSON.stringify(msg.data));
                    //  alert(JSON.stringify(msg.data));

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
    }

    $scope.productAddtoCart = function (Entity) {

        if (Object.keys(Entity).length === 0 || Entity.unit_cost == "" || typeof Entity.unit_cost === 'undefined')
        {


            toastr.error("Empty product!");
            $('#productQry .typeahead').typeahead('val', '');
            return;
        }
        if (typeof Entity.rebate == "undefined")
        {
            toastr.error("Must Enter Rebate");

            return;
        }


        $scope.EntityObj = Entity;
        console.log("Product Post data" + JSON.stringify(Entity));
        $scope.purchaseList.push($scope.EntityObj);
        $scope.totalPcs = 0;
        $scope.totalCtn = 0;
        $scope.totalCost = 0;
        $scope.totalRebate = 0;
        $scope.netCost = 0;
        $scope.purchaseList.forEach(function (item) {


            $scope.totalPcs += parseInt(item['unit_pcs']);
            $scope.totalCtn += parseFloat(item['unit_ctn']);
            $scope.totalCost += parseInt(item['total_amount']);
            $scope.totalRebate += parseFloat(item['rebate_amount']);
            $scope.netCost += parseInt(item['net_amount']);


        });
        $scope.EntityObj = {};
        Entity = {};
        $('#productQry .typeahead').typeahead('val', '');
        // $("#product_text").val("");
        //$("#product_text").text("");
    }


    $scope.updateProduct = function (Entity) {

        console.log("Product Post data" + JSON.stringify(Entity));

        simsService.updateProduct(Entity)
                .then(function (msg) {
                    console.log("data" + JSON.stringify(msg.data));
                    toastr.success(msg.data);

                }, function (error) {
                    toastr.error(error);

                });
    }


    $scope.updateComponent = function (Entity) {

        simsService.updateComponent(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();
                    $scope.getComponents();
                    // alert(JSON.stringify(msg.data));

                }, function (error) {
                    toastr.error(error);

                });
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


    $scope.getComponents = function () {

        var response = simsService.getComponents();
        response.then(function (list) {

            $scope.componetList = list.data;
            $scope.currentPage = 1;
            //var begin = (($scope.currentPage - 1) * $scope.itemsPerPage),
            //    end = begin + $scope.itemsPerPage;
            // $scope.componetList = null;
            $scope.totalItems = $scope.componetList.length;
            $scope.componetListflt = $scope.componetList;
            //$scope.componetListflt = $scope.componetList.slice(begin, end);
            // console.log("Component List:" + JSON.stringify($scope.componetList));


        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.savePurchaseProduct = function (Entity) {
        // Entity.challan_date

        $scope.pg = true;

        if (typeof Entity.supplier_id == "undefined")
        {
            swal({
                html: true,
                title: "Must be select distributor!",
                text: "",
                type: "warning",
                timer: 2000,
                confirmButtonText: "Close",
                // html: "<h1>Hello Everyone</h1>"
                showConfirmButton: true
            });
            $scope.pg = false;
            return;

        }


        if ($scope.myForm.$valid)
        {
            if ($scope.purchaseList.length > 0)
            {

                var date1 = $("#challanDate").val();
                Entity.purchaseList = $scope.purchaseList;
                Entity.user_id = getCookie('user_id');
                Entity.challan_date = date1;
                Entity.company_id = getCookie('company_id');
                Entity.total_pcs_quantity_purchase = $scope.totalPcs;
                Entity.netamount_purchase = $scope.netCost;
                Entity.totalamount_purchase = $scope.totalCost;
                Entity.rebate_amount_total = $scope.totalRebate;

                Entity.total_qtn_quantity_purchase = $scope.totalCtn;
                var response = simsService.savePurchaseProduct(Entity);
                response.then(function (list) {
                    toastr.success(list.data);
                    $scope.pg = false;
                    console.log("Result Data" + JSON.stringify(list.data));
                }, function (error) {
                    toastr.error(error.data);
                    $scope.pg = false;
                });

                console.log("Purchase Data" + JSON.stringify(Entity));
                $scope.purchaseList = [];
                $scope.Entity = {};
                $('#productQry .typeahead').typeahead('val', '');

            } else {
                swal({
                    html: true,
                    title: "Purchase List Empty",
                    text: "",
                    type: "error",
                    timer: 5000,
                    confirmButtonText: "Close",
                    // html: "<h1>Hello Everyone</h1>"
                    showConfirmButton: true
                });
                $scope.pg = false;
                return;
            }



        } else {
            // alert('in valid');
            $scope.showMsgs = true;
        }
        return;








    }



    $scope.productChange = function (Entity, $event) {


        // alert("ok");
        console.log("sweety" + Entity);


    }

    $('#productitem').find('option').click(function () {
        var optionSelected = $(this);
        var valueSelected = optionSelected.val();
        var textSelected = optionSelected.text();
    });

    // $scope.testing = "data changed";
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



    $scope.getPoducts = function () {

        var response = simsService.getPoducts();
        response.then(function (list) {

            $scope.productList = list.data;
            $scope.totalItems = list.data.length;

            console.log("Product List" + JSON.stringify($scope.productList));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.searchPoducts = function (Entity) {

        var data = {
            name: Entity
        };

        var response = simsService.productSearch(data);
        response.then(function (list) {

            $scope.productList = list.data;
            $scope.totalItems = list.data.length;

            console.log("Product List" + JSON.stringify($scope.productList));
        }, function (error) {
            toastr.error(error.data);
        });
    }




    $scope.getPoductsById = function (Entity) {

        var response = simsService.getProductById(Entity);
        response.then(function (list) {

            $scope.productObj = list.data[0];

            $scope.Entity = list.data[0].product;
            if ($scope.Entity.status == 1) {
                $scope.Entity.status = true;
            } else {
                $scope.Entity.status = false;

            }

            $scope.Entity.componentListTemp = list.data[0].productComponentList;
            $scope.Entity.priceListTemp = list.data[0].productPrices;
            console.log("Product Object" + JSON.stringify($scope.productObj));
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
    $scope.unitCostChange = function (Entity)
    {
        var unitCost = parseFloat(Entity.unit_cost);
        var unitQuty = parseInt(Entity.unit_pcs);
        var rebate = parseInt(Entity.rebate);
        // var unitPcs = $("#productCurrentUnitPcs").val();
        //Entity.product_name = $("#productName").val();
        //Entity.barcode = $("#currentBarcode").val();
        //Entity.product_id = $("#currentProductId").val();
        var unitPcs = parseInt(Entity.pics_qty);
        //unitPcs = parseInt(unitPcs);
        if (isNaN(unitQuty))
        {
            unitQuty = 1;
            Entity.unit_pcs = 1;

        }
        Entity.unit_ctn = (Entity.unit_pcs / unitPcs).toFixed(2);
        Entity.net_amount = (unitCost * unitQuty);
        Entity.rebate_amount = (Entity.net_amount * (rebate / 100));
        //  Entity.total_amount = Entity.total_amount - Entity.rebate_amount;

        Entity.total_amount = Entity.net_amount + Entity.rebate_amount;


    };


    $scope.rebateChange = function (Entity)
    {
        var unitCost = parseFloat(Entity.unit_cost);
        var unitQuty = parseInt(Entity.unit_pcs);

        var rebate = parseInt(Entity.rebate);
        // var unitPcs = $("#productCurrentUnitPcs").val();
        //Entity.product_name = $("#productName").val();
        //Entity.barcode = $("#currentBarcode").val();
        //Entity.product_id = $("#currentProductId").val();
        var unitPcs = parseInt(Entity.pics_qty);
        //unitPcs = parseInt(unitPcs);
        if (isNaN(unitQuty))
        {
            unitQuty = 1;
            Entity.unit_pcs = 1;

        }

        Entity.unit_ctn = (Entity.unit_pcs / unitPcs);
        Entity.net_amount = (unitCost * unitQuty);
        Entity.rebate_amount = (Entity.net_amount * (rebate / 100));
        Entity.total_amount = Entity.net_amount + Entity.rebate_amount;



    };









    $scope.quantityChange = function (Entity)
    {
        var unitCost = parseFloat(Entity.unit_cost);
        var unitQuty = parseInt(Entity.unit_pcs);
        var rebate = parseInt(Entity.rebate);
        //var unitPcs = $("#productCurrentUnitPcs").val();
        //Entity.product_name = $("#productName").val();
        // Entity.barcode = $("#currentBarcode").val();
        // Entity.product_id = $("#currentProductId").val();
        var unitPcs = parseInt(Entity.pics_qty);
        /* if (isNaN(unitQuty))
         {
         unitQuty = 1;
         Entity.unit_pcs = 1;
         
         }*/
        Entity.unit_ctn = (Entity.unit_pcs / unitPcs).toFixed(2);
        Entity.net_amount = unitCost * unitQuty;
        Entity.rebate_amount = (Entity.net_amount * (rebate / 100));
        //  Entity.total_amount = Entity.total_amount - Entity.rebate_amount;
        Entity.total_amount = Entity.net_amount + Entity.rebate_amount;
        // $("#unit_cost").val(item.data[0].product_price);
        // Entity.unit_ctn = (Entity.unit_pcs / unitPcs).toFixed(2);


    };


    $scope.init = function () {



        $('#datetimepicker11').datetimepicker({
            defaultDate: new Date()
        });

        // var baseUrl = 'http://127.0.0.1:8000/api/findProductQuery';
        // var baseUrlFindSupplier = 'http://127.0.0.1:8000/api/getsupplier-typeahend';

        var baseUrl = 'http://sims.timezoneservice.com/api/findProductQuery';
        var baseUrlFindSupplier = 'http://sims.timezoneservice.com/api/getsupplier-typeahend';

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
                limit: 29,
                name: 'name',
                display: 'name',
                source: findProductQuery
            });


            var findSupplierQuery = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,

                remote: {
                    url: baseUrlFindSupplier + '/%QUERY',
                    wildcard: '%QUERY'
                }
            });
            $('#supplierQry .typeahead').typeahead(null, {
                name: 'name',
                display: 'name',
                source: findSupplierQuery
            });






        });

    };


    $('#productQry .typeahead').on('typeahead:selected', function (evt, item) {


        /*  $("#product_text").val();
         $("#productCurrentUnitPcs").val(item.pics_qty);
         $("#productName").val(item.name);
         $("#currentBarcode").val(item.barcode);*/




        var data = {price_id: 22,
            product_id: item.product_id,
        };

        var response = simsService.getProductPrice(data);
        response.then(function (item) {



            if (item.data[0] == null)
            {

                swal({
                    html: true,
                    title: "Product Price Not Found",
                    text: "",
                    type: "error",
                    timer: 5000,
                    confirmButtonText: "Close",
                    // html: "<h1>Hello Everyone</h1>"
                    showConfirmButton: true
                });
                return;
            }


            $("#unit_cost").val("");
            $scope.EntityObj = {};
            $scope.EntityObj.rebate = 15;
            $scope.EntityObj.product_id = item.data[0].product_id;
            $scope.EntityObj.pics_qty = item.data[0].pics_qty;
            $scope.EntityObj.product_name = item.data[0].name;
            $scope.EntityObj.barcode = item.data[0].barcode;
            $scope.EntityObj.unit_cost = item.data[0].product_price;

            $("#unit_cost").val(item.data[0].product_price);
            //$scope.EntityObj.Entity = item.data[0].product_price;



        }, function (error) {
            toastr.error(error.data);
        });





        //$scope.Entity.supplier_id=item.su





    })


    $('#supplierQry .typeahead').on('typeahead:selected', function (evt, item) {

        $scope.Entity.supplier_id = item.id;
        $('#address').val(item.address);

    })
    // $scope.getUnitTypes();
    // $scope.getComponentGroups();
    // $scope.getComponents();
    // $scope.getPrices();
    //  $scope.getPoducts();

}


angular.module('myApps')
        .controller('PurchaseController', PurchaseController);