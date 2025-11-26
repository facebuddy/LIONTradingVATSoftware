'use strict';
var IndentSecondaryController = function ($scope, $filter, $log, simsService) {
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
    $scope.supplierList = []
    $scope.netAmount = 0;
    $scope.discountAmount = 0;
    $scope.priceList = [];
    $scope.productListTemp = [];
    $scope.EntityObj = {};
    $scope.purchaseList = [];
    $scope.Entity = {};
    // $scope.Entity.credit_limit = 5000000;
    // $scope.Entity.credit_balance = 300000;
    $scope.EntityObj.unit_cost = 0;
    $scope.EntityObj.stcok = 0;
    $scope.pg = false;
    //$scope.EntityObj.stcok=0; 
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

        } 
        else
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
        $scope.discountAmount = 0;
        $scope.netAmount = 0;
        $scope.purchaseList.forEach(function (item) {

            $scope.totalPcs += parseInt(item['unit_pcs']);
            $scope.totalCtn += parseFloat(item['unit_ctn']);
            $scope.totalCost += parseFloat(item['total_amount']);
            $scope.discountAmount += parseFloat(item['discount_amount']);
            $scope.netAmount += parseFloat(item['net_amount']);


        });

        if ($scope.purchaseList.length == 0)
        {
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalCost = 0;
            $scope.netAmount = 0;
            $scope.discountAmount = 0;


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

        if (Object.keys(Entity).length === 0 || Entity.unit_cost == "" || typeof Entity.unit_cost === 'undefined' || Entity.unit_pcs == "" || typeof Entity.unit_pcs === 'undefined')
        {


            toastr.error("Empty product!");
            $('#productQry .typeahead').typeahead('val', '');
            $("#unit_cost").val("");
            $("#currentDiscount").val("");
            $("#netUnitPrice").val("");

            $("#stock").val("");
            return;
        }

        const getProduct = $scope.purchaseList.find(product => product.product_id === Entity.product_id);
        if (getProduct === undefined)
        {

            $scope.EntityObj = Entity;
            console.log("Product Post data" + JSON.stringify(Entity));
            $scope.purchaseList.push($scope.EntityObj);
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalCost = 0;
            $scope.netAmount = 0;
            $scope.discountAmount = 0;
            $scope.purchaseList.forEach(function (item) {


                $scope.discountAmount += parseFloat(item['discount_amount']);
                $scope.totalPcs += parseInt(item['unit_pcs']);
                $scope.totalCtn += parseFloat(item['unit_ctn']);
                $scope.totalCost += parseFloat(item['total_amount']);
                $scope.netAmount += parseFloat(item['net_amount']);


            });
            $scope.EntityObj = {};
            Entity = {};
            $('#productQry .typeahead').typeahead('val', '');
            $("#unit_cost").val("");
            $("#currentDiscount").val("");
            $("#netUnitPrice").val("");

            $("#stock").val("");



        } else {



            swal({
                html: true,
                title: "Product Already Exist",
                text: "",
                type: "error",
                timer: 5000,
                confirmButtonText: "Close",
                // html: "<h1>Hello Everyone</h1>"
                showConfirmButton: true
            });



            return;


        }



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


    $scope.saveIndentProducts = function (Entity) {



        if (Entity.distributor_id == 0 || Object.keys(Entity).length === 0 || (typeof $scope.purchaseList == "undefined" || $scope.purchaseList.length <= 0))
        {

            if ((typeof $scope.purchaseList == "undefined" || $scope.purchaseList.length <= 0))
            {

                swal({
                    html: true,
                    title: "Empty List!",
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









        // Entity.challan_date
        $scope.pg = true;
        var date1 = $("#challanDate").val();
        Entity.purchaseList = $scope.purchaseList;

        Entity.challan_date = date1;

        Entity.total_pcs_quantity = $scope.totalPcs;
        Entity.total_qtn_quantity = $scope.totalCtn;

        Entity.total_netamount = $scope.netAmount;
        Entity.total_discount_amount = $scope.discountAmount;
        Entity.total_amount = $scope.totalCost;
        Entity.company_id = getCookie('company_id');
        Entity.user_id = getCookie('user_id');
        Entity.price_id = $scope.Entity.pricetype_id;
        var response = simsService.saveIndentProducts(Entity);
        response.then(function (list) {
            //toastr.success(list.data);

            $scope.pg = false;

            swal({
                html: true,
                title: list.data,
                text: "",
                type: "success",
                timer: 2000,
                confirmButtonText: "Close",
                // html: "<h1>Hello Everyone</h1>"
                showConfirmButton: true
            });

            $scope.purchaseList = [];
            Entity = {};
            $scope.Entity = {};
            $('#distributorQry .typeahead').typeahead('val', '');
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalCost = 0;
            $scope.netAmount = 0;
            $scope.discountAmount = 0;
            $('#credit_limit').val("");
            $('#credit_balance').val("");
            $('#address').val("");
            console.log("Result Data" + JSON.stringify(list.data));
        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
        console.log("Indent Data" + JSON.stringify(Entity));


    }











    $scope.stockReceiveSecondary = function (Entity) {



        if (Entity.distributor_id == 0 || Object.keys(Entity).length === 0 || (typeof $scope.purchaseList == "undefined" || $scope.purchaseList.length <= 0))
        {

            if ((typeof $scope.purchaseList == "undefined" || $scope.purchaseList.length <= 0))
            {

                swal({
                    html: true,
                    title: "Empty List!",
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









        // Entity.challan_date
        $scope.pg = true;
        var date1 = $("#challanDate").val();
        Entity.purchaseList = $scope.purchaseList;

        Entity.challan_date = date1;

        Entity.total_pcs_quantity = $scope.totalPcs;
        Entity.total_qtn_quantity = $scope.totalCtn;

        Entity.total_netamount = $scope.netAmount;
        Entity.total_discount_amount = $scope.discountAmount;
        Entity.total_amount = $scope.totalCost;
        Entity.company_id = getCookie('company_id');
        Entity.user_id = getCookie('user_id');
        Entity.price_id = $scope.Entity.pricetype_id;
        Entity.location_id = Entity.distributor_id;




        // return;
        // $scope.pg = false;
        var response = simsService.stockReceiveSecondary(Entity);
        response.then(function (list) {
            //toastr.success(list.data);

            $scope.pg = false;

            swal({
                html: true,
                title: list.data,
                text: "",
                type: "success",
                timer: 2000,
                confirmButtonText: "Close",
                // html: "<h1>Hello Everyone</h1>"
                showConfirmButton: true
            });

            $scope.purchaseList = [];
            Entity = {};
            $scope.Entity = {};
            $('#distributorQry .typeahead').typeahead('val', '');
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalCost = 0;
            $scope.netAmount = 0;
            $scope.discountAmount = 0;
            //  $('#credit_limit').val("");
            //  $('#credit_balance').val("");
            $('#address').val("");
            console.log("Result Data" + JSON.stringify(list.data));
        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
        console.log("Indent Data" + JSON.stringify(Entity));


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
        var unitCost = parseFloat(Entity.netunit_price);
        var unitQuty = parseInt(Entity.unit_pcs);
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
        Entity.unit_ctn = parseFloat(Entity.unit_pcs / unitPcs).toFixed(2);
        Entity.total_amount = parseFloat(unitCost * unitQuty).toFixed(2);


    };


    $scope.quantityChange = function (Entity)
    {
        var stock = $("#stock").val()
        if (Entity.unit_pcs > stock)
        {
            toastr.error("Stock not available");
            Entity.unit_pcs = 0;
            return;
        }
        var unitCost = parseFloat(Entity.unit_cost);
        var netUnitPrice = parseFloat(Entity.unit_cost).toFixed(2);
        var unitQuty = parseInt(Entity.unit_pcs);
        var discountPercent = Entity.unit_discountamount / 100;
        var discountAmount = discountPercent * unitCost;
        var totaldiscountAmount = discountPercent * unitCost;
        var discount = parseFloat(discountAmount * Entity.unit_pcs).toFixed(2);


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
        Entity.unit_ctn = parseFloat(Entity.unit_pcs / unitPcs).toFixed(2);
        Entity.total_amount = parseFloat(unitCost * unitQuty).toFixed(2);
        Entity.net_amount = parseFloat(netUnitPrice * unitQuty).toFixed(2) - discount;
        Entity.discount_amount = discount;
        Entity.unit_discountamount_indent = discount;
        Entity.unit_discountpercent_indent = Entity.unit_discountamount;
    };









    $scope.quantityChangeOpeining = function (Entity)
    {
       
        var unitCost = parseFloat(Entity.unit_cost);
        var netUnitPrice = parseFloat(Entity.unit_cost).toFixed(2);
        var unitQuty = parseInt(Entity.unit_pcs);
        var discountPercent = Entity.unit_discountamount / 100;
        var discountAmount = discountPercent * unitCost;
        var totaldiscountAmount = discountPercent * unitCost;
        var discount = parseFloat(discountAmount * Entity.unit_pcs).toFixed(2);


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
        Entity.unit_ctn = parseFloat(Entity.unit_pcs / unitPcs).toFixed(2);
        Entity.total_amount = parseFloat(unitCost * unitQuty).toFixed(2);
        Entity.net_amount = parseFloat(netUnitPrice * unitQuty).toFixed(2) - discount;
        Entity.discount_amount = discount;
        Entity.unit_discountamount_indent = discount;
        Entity.unit_discountpercent_indent = Entity.unit_discountamount;
    };






    $scope.init = function () {



        $('#datetimepicker11').datetimepicker({
            defaultDate: new Date()
        });

        // var baseUrl = 'http://127.0.0.1:8000/api/findProductQuery';
        // var baseUrlFindSupplier = 'http://127.0.0.1:8000/api/getdistributorpoint-typeahend';
       // var baseUrl = 'http://sims.timezoneservice.com/api/findProductQuery';
       // var baseUrlFindSupplier = 'http://sims.timezoneservice.com/api/getdistributorpoint-typeahend';
        
        var baseUrl = 'http://sims.timezoneservice.com/api/findProductQuery';
        var baseUrlFindSupplier = 'http://sims.timezoneservice.com/api/getdistributorpoint-typeahend';

        $(document).ready(function () {
            var findProductQuery = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,

                remote: {
                    url: baseUrl + '/%QUERY ',
                    wildcard: '%QUERY'
                }
            });
            $('#productQry .typeahead').typeahead(null, {
                limit: 50,
                name: 'name',
                display: 'name',
                source: findProductQuery
            });


            var findDistributorQuery = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,

                remote: {
                    url: baseUrlFindSupplier + '/%QUERY',
                    wildcard: '%QUERY'
                }
            });
            $('#distributorQry .typeahead').typeahead(null, {
                limit: 50,
                name: 'name',
                display: 'name',
                source: findDistributorQuery
            });






        });

    };
    $('#distributorQry .typeahead').on('typeahead:selected', function (evt, item) {

        $scope.Entity.distributor_id = item.id;
        $scope.Entity.pricetype_id = item.price_id;
        $('#credit_limit').val(item.credit_limit);

        $('#address').val(item.address);
        var data = {
            company_id: item.id
        };
        var response = simsService.getcurrentCreditBalance(data);
        response.then(function (list) {

            $('#credit_balance').val(list.data);


        }, function (error) {
            toastr.error(error.data);
        });





    });

    $('#productQry .typeahead').on('typeahead:selected', function (evt, item) {



        $scope.EntityObj = {};


        var data = {price_id: $scope.Entity.pricetype_id,
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

            

            $scope.EntityObj.product_id = item.data[0].product_id;
            $scope.EntityObj.pics_qty = parseInt(item.data[0].pics_qty);
            $scope.EntityObj.product_name = item.data[0].name;
            $scope.EntityObj.barcode = item.data[0].barcode;
            $scope.EntityObj.unit_cost = parseFloat(item.data[0].product_price);
            $scope.EntityObj.discount_amount = parseFloat(item.data[0].discount_amount_primary ? item.data[0].discount_amount_primary : 0);
            $scope.EntityObj.netunit_price = $scope.EntityObj.unit_cost - $scope.EntityObj.discount_amount;
            $scope.EntityObj.pricetype_id = item.data[0].pricetype_id;
            $scope.EntityObj.unit_discountamount = item.data[0].discount_amount_primary;
            $("#unit_cost").val(item.data[0].product_price);

            $("#currentDiscount").val(item.data[0].discount_amount_primary ? item.data[0].discount_amount_primary : 0);
            $("#netUnitPrice").val($scope.EntityObj.netunit_price);

            $("#stock").val(item.data[0].stock);



        }, function (error) {
            toastr.error(error.data);
        });












    })


    /*  $('#distributorQry .typeahead').on('typeahead:selected', function (evt, item) {
     
     $scope.Entity.distributor_id = item.id;
     $("#distributor_id").val(item.id);
     
     
     }) */


}


angular.module('myApps')
        .controller('IndentSecondaryController', IndentSecondaryController);