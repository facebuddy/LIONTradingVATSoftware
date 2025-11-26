'use strict';
var SalesOrderController = function ($scope, $filter, $window, $log, simsService) {

    var baseUrl = "http://cr.time-zone.biz/";
    // var baseUrl = "http://localhost:51592/"
    $scope.title = "Product Component";
    $scope.indentList = [];
    $scope.EntityObj = {};
    $scope.purchaseList = [];
    $scope.returnList = [];
    $scope.Entity = {};
    $scope.IndentObj = {};
    $scope.itemsPerPage = 10;
    $scope.ctn_quantity_salesorder = 0;
    $scope.quantity_salesorder = 0;
    $scope.totalamount_salesorder = 0;
    $scope.discount_amount_salesorder = 0;
    $scope.discount_percent_salesorder = 0;
    $scope.netamount_salesorder = 0;
    $scope.processBtn = true;
    $scope.IndentObj = {};
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
            $scope.getIndentById(id);
            $scope.processBtn = true;



        }
    }





    $scope.saveIndentProducts = function (Entity) {
        // Entity.challan_date

        var date1 = $("#challanDate").val();
        Entity.purchaseList = $scope.purchaseList;

        Entity.challan_date = date1;

        Entity.total_pcs_quantity = $scope.totalPcs;
        Entity.total_qtn_quantity = $scope.totalCtn;

        Entity.total_netamount = $scope.netAmount;
        Entity.total_discount_amount = $scope.discountAmount;
        Entity.total_amount = $scope.totalCost;

        var response = simsService.saveIndentProducts(Entity);
        response.then(function (list) {
            //toastr.success(list.data);



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
            $('#distributorQry .typeahead').typeahead('val', '');
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalCost = 0;
            $scope.netAmount = 0;
            $scope.discountAmount = 0;
            console.log("Result Data" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
        console.log("Indent Data" + JSON.stringify(Entity));


    }


    $scope.popitup = function (url) {
        return $window.open(baseUrl + "default.aspx?invoice_no=" + url, '_blank');
    };


    $scope.popitupIndent = function (url) {
        return $window.open(baseUrl + "IndentDetails.aspx?invoice_no=" + url, '_blank', 'height=800,width=1000');
    };

    $scope.popitupReturn = function (url) {
        return $window.open(baseUrl + "InvoiceReturnDetails.aspx?invoice_no=" + url, '_blank', 'height=800,width=1000');
    };


    $scope.indentSearching = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        var response = simsService.getIndentList(Entity);
        response.then(function (list) {

            $scope.indentList = list.data;

            $scope.pg = false;

            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.indentSearchingReport = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        var response = simsService.getIndentListReporting(Entity);
        response.then(function (list) {

            $scope.indentList = list.data;
            $scope.calculateTotalNew();
            $scope.pg = false;

            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }

    $scope.returntSearchingReport = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        var response = simsService.getInvoiceReturnListReporting(Entity);
        response.then(function (list) {

            $scope.returnList = list.data;

            $scope.pg = false;
            $scope.calculateTotalReturn();

            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }









    $scope.myIndentSearchingReport = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        Entity.user_id = getCookie('user_id');
        var response = simsService.getIndentListReporting(Entity);
        response.then(function (list) {

            $scope.indentList = list.data;

            $scope.pg = false;

            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }









    $scope.getPurchaseList = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        var response = simsService.getPurchaseList(Entity);
        response.then(function (list) {

            $scope.indentList = list.data;

            $scope.pg = false;

            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }











    $scope.CheckUncheckHeader = function () {
        // $scope.IsAllChecked = true;

        if ($scope.IsAllChecked)
        {
            for (var i = 0; i < $scope.IndentObj.indentDetailsList.length; i++) {

                $scope.IndentObj.indentDetailsList[i].isSelected = true;

            }

        } else {
            for (var i = 0; i < $scope.IndentObj.indentDetailsList.length; i++) {

                $scope.IndentObj.indentDetailsList[i].isSelected = false;

            }


        }

        $scope.calculateTotal();

    };

    $scope.changeCheckBox = function (Entity, event) {

        $scope.calculateTotal();

    };


    $scope.calculateTotal = function ()
    {
        $scope.ctn_quantity_salesorder = 0;
        $scope.quantity_salesorder = 0;
        $scope.totalamount_salesorder = 0;
        $scope.discount_amount_salesorder = 0;
        $scope.discount_percent_salesorder = 0;
        $scope.netamount_salesorder = 0;

        $scope.IndentObj.indentDetailsListTemp = $filter('filter')($scope.IndentObj.indentDetailsList, function (item) {
            return (item.isSelected == true);
        });

        $scope.IndentObj.indentDetailsListTemp.forEach(function (item) {

            $scope.ctn_quantity_salesorder += parseFloat(item['ctn_quantity_salesorder'])
            $scope.quantity_salesorder += parseInt(item['quantity_salesorder']);
            $scope.totalamount_salesorder += parseFloat(item['totalamount_salesorder']);
            $scope.discount_amount_salesorder += parseFloat(item['discount_amount_salesorder']);
            $scope.discount_percent_salesorder += parseFloat(item['discount_percent_salesorder']);
            $scope.netamount_salesorder += parseFloat(item['netamount_salesorder']);


        });

        $scope.ctn_quantity_salesorder = $scope.ctn_quantity_salesorder.toFixed(2);


    };



    $scope.calculateTotalNew = function ()
    {

        $scope.quantity_salesorder = 0;
        $scope.ctn_quantity_indent = 0;


        $scope.quantity_indent = 0;
        $scope.ctn_quantity_salesorder = 0;
        $scope.netamount_salesorder = 0;

        $scope.netamount_indent = 0;

        $scope.indentList.forEach(function (item) {

            $scope.quantity_salesorder += parseFloat(item['quantity_salesorder_new'])
            $scope.ctn_quantity_indent += parseInt(item['ctn_indent_new']);
            $scope.quantity_indent += parseFloat(item['quantity_indent_new']);
            $scope.ctn_quantity_salesorder += parseFloat(item['ctn_salesorder_new']);
            $scope.netamount_salesorder += parseFloat(item['netamount_salesorder_new']);
            $scope.netamount_indent += parseFloat(item['netamount_indent_new']);


        });




    };

    $scope.totalqtyReturn = 0;
    $scope.totalAmountReturn = 0;
    $scope.calculateTotalReturn = function ()
    {

     

        $scope.returnList.forEach(function (item) {

            $scope.totalqtyReturn +=  parseInt(item['return_qty'])
            $scope.totalAmountReturn += parseFloat(item['total_netamount']);
           

        });




    };

    $scope.getIndentById = function (Entity) {

        var data = {
            id: Entity
        };

        var response = simsService.getIndentById(data);
        response.then(function (list) {

            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.IndentObj = list.data[0];
            $scope.IsAllChecked = true;
            for (var i = 0; i < $scope.IndentObj.indentDetailsList.length; i++) {

                $scope.IndentObj.indentDetailsList[i].isSelected = true;
                $scope.IndentObj.indentDetailsList[i].isNewItem = false;
                $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder = $scope.IndentObj.indentDetailsList[i].ctn_quantity_indent;
                $scope.IndentObj.indentDetailsList[i].quantity_salesorder = parseInt($scope.IndentObj.indentDetailsList[i].quantity_indent);
                $scope.IndentObj.indentDetailsList[i].totalamount_salesorder = $scope.IndentObj.indentDetailsList[i].totalamount_indent;
                $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder = parseFloat($scope.IndentObj.indentDetailsList[i].discount_amount_indent);
                // $scope.IndentObj.indentDetailsList[i].discount_percent_salesorder = parseFloat(($scope.IndentObj.indentDetailsList[i].discount_amount_indent / $scope.IndentObj.indentDetailsList[i].totalamount_indent) * 100);
                $scope.IndentObj.indentDetailsList[i].discount_percent_salesorder = parseFloat($scope.IndentObj.indentDetailsList[i].unit_discountpercent_indent);
                $scope.IndentObj.indentDetailsList[i].netamount_salesorder = $scope.IndentObj.indentDetailsList[i].netamount_indent;

            }

            $scope.calculateTotal();

            console.log("Indent List" + JSON.stringify($scope.IndentObj));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.quantityChange = function (Entity)
    {
        var unitCost = parseFloat(Entity.unit_price_indent);
        // var netUnitPrice = parseFloat(Entity.netunit_price);
        var unitQty = parseInt(Entity.quantity_salesorder);

        if (isNaN(unitQty) || unitQty == 0)
        {
            /*  swal({
             html: true,
             title: "Quanity Can not be Empty",
             text: "",
             type: "error",
             timer: 5000,
             confirmButtonText: "Close",
             // html: "<h1>Hello Everyone</h1>"
             showConfirmButton: true
             }); */
            toastr.error("Quantity Can not be empty!");
            // Entity.quantity_salesorder=1;

        }
        var unitQtyUnit = parseInt(Entity.pics_qty);
        //   var discountPercent = Entity.unit_discountamount_indent/100;
        //  var discountAmount=discountPercent*unitCost;
        // var discount = parseFloat(discountAmount * Entity.unit_pcs).toFixed(2);

        Entity.totalamount_salesorder = unitCost * unitQty;
        Entity.ctn_quantity_salesorder = (unitQty / unitQtyUnit).toFixed(2);
        Entity.discount_amount_salesorder = parseFloat(Entity.totalamount_salesorder * (Entity.discount_percent_salesorder / 100).toFixed(2));
        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;
        //  Entity.discount_percent_salesorder = ((Entity.discount_amount_salesorder / Entity.totalamount_salesorder) * 100).toFixed(2);
        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);
        //  Entity.discount_percent_salesorder =parseFloat(Entity.unit_discountpercent_indent);
        $scope.calculateTotal();

    };




    $scope.productAddtoCart = function (Entity) {


        if (isNaN(Entity.pics_qty) || Entity.pics_qty == 0)
        {
            /*  swal({
             html: true,
             title: "Quanity Can not be Empty",
             text: "",
             type: "error",
             timer: 5000,
             confirmButtonText: "Close",
             // html: "<h1>Hello Everyone</h1>"
             showConfirmButton: true
             }); */
            toastr.error("Quantity Can not be empty!");
            // Entity.quantity_salesorder=1;

        }

        if (Object.keys(Entity).length === 0 || Entity.unit_cost == "" || typeof Entity.unit_cost === 'undefined')
        {


            toastr.error("Empty product!");
            $('#productQry .typeahead').typeahead('val', '');
            $("#unit_cost").val("");
            $("#currentDiscount").val("");
            $("#netUnitPrice").val("");

            $("#stock").val("");
            return;
        }

        const getProduct = $scope.IndentObj.indentDetailsListTemp.find(product => product.product_id === Entity.product_id);
        if (getProduct === undefined)
        {

            $scope.EntityObj = Entity;
            console.log("Product Post data" + JSON.stringify(Entity));
            // var salesObj =[];
            var salesObj = {
                product_id: Entity.product_id,
                name: Entity.product_name,
                pics_qty: Entity.pics_qty,
                id: null,
                chalanmaster_id: null,
                unit_type: null,
                quantity_indent: 0,
                price_type: $scope.EntityObj.pricetype_id,
                ctn_quantity_indent: 0,
                quantity_salesorder: Entity.unit_pcs,
                ctn_quantity_salesorder: Entity.unit_ctn,
                unit_price_indent: Entity.unit_cost,
                totalamount_indent: 0,
                unit_discountamount_indent: 0,
                unit_discountpercent_indent: 0,
                discount_amount_indent: 0,
                netamount_indent: 0,

                totalamount_salesorder: Entity.total_amount,
                unit_discountamount_salesorder: Entity.discount_amount / Entity.unit_pcs,
                discount_percent_salesorder: Entity.discount_percent_salesorder,
                discount_amount_salesorder: Entity.discount_amount,
                netamount_salesorder: Entity.net_amount,
                isNewItem: true,
                isSelected: true,
                stock: Entity.stock,
                available_stock: Entity.available_stock,
            };

            $scope.IndentObj.indentDetailsList.push(salesObj);

            $scope.EntityObj = {};
            Entity = {};
            $('#productQry .typeahead').typeahead('val', '');
            $("#unit_cost").val("");
            $("#currentDiscount").val("");
            $("#netUnitPrice").val("");

            $("#stock").val("");

            $scope.calculateTotal();

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



    }







    $scope.discountAmountChange = function (Entity)
    {



        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;

        Entity.discount_percent_salesorder = parseFloat(((Entity.discount_amount_salesorder / Entity.totalamount_salesorder) * 100).toFixed(2));

        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);

        $scope.calculateTotal();

    };


    $scope.discountAmountChangeNewObj = function (Entity)
    {



        // Entity.netamount_salesorder = Entity.totalamount_salesorder - (Entity.discount_amount_primary*Entity.unit_pcs);

        Entity.discount_percent_salesorder = parseFloat((Entity.discount_amount_primary / Entity.unit_cost) * 100).toFixed(2);

        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);

        // $scope.calculateTotal();

    };



    $scope.discountPercentChangeNewObj = function (Entity)
    {

        var discount = Entity.discount_percent_salesorder / 100;
        Entity.discount_amount_salesorder = parseFloat((Entity.totalamount_salesorder * discount).toFixed(2));

        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;

        //  Entity.discount_amount_salesorder = ((Entity.discount_amount_salesorder / Entity.totalamount_salesorder) * 100).toFixed(2);

        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);

        $scope.calculateTotal();

    };


    $scope.discountPercentChange = function (Entity)
    {

        var discount = Entity.discount_percent_salesorder / 100;
        Entity.discount_amount_salesorder = parseFloat((Entity.totalamount_salesorder * discount).toFixed(2));

        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;

        // Entity.discount_percent_salesorder = ((Entity.discount_amount_salesorder / Entity.totalamount_salesorder) * 100).toFixed(2);

        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);

        $scope.calculateTotal();

    };


    $scope.processSalesOrder = function (Entity, IndentObj)
    {

        $scope.pg = true;
        // console.log("Before Update List " + Entity);
        // console.log("Before Update List " + JSON.stringify(Entity));

        $scope.salesOrderTemp = $filter('filter')(Entity, function (item) {
            return (item.isSelected == true);
        });
        // alert( $scope.salesOrderTemp);
        // return;

        var availableFlag = true;
        $scope.salesOrderTemp.forEach(function (item) {

            var availableStock = parseInt(item['available_stock']);
            var sale = parseInt(item['quantity_salesorder']);
            if (sale > availableStock)
            {
                toastr.error(item['name'] + " Stock Not Available!");
                availableFlag = false;
                return  false;

            }


        });
        if (availableFlag == false)
        {
            $scope.pg = false;
            return;
        }

        var data = {
            chalanmaster_id: $scope.IndentObj.indentMaster[0].id,
            total_amount_salesorder: $scope.totalamount_salesorder,
            total_discount_amount_salesorder: $scope.discount_amount_salesorder,
            total_discount_amount_salesorder: $scope.discount_amount_salesorder,
            total_netamount_salesorder: $scope.netamount_salesorder,
            salesOrderList: $scope.salesOrderTemp,
        };

        IndentObj.credit_balance += $scope.netamount_salesorder;
        // IndentObj.credit_limit=500;

        if (IndentObj.credit_balance > IndentObj.credit_limit)
        {
            swal({
                html: true,
                title: "Credit Limit exceed!",
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
        // return;


        if ((typeof $scope.salesOrderTemp == "undefined" || $scope.salesOrderTemp.length <= 0))
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




        console.log("Process sales order data " + JSON.stringify(data));
        var response = simsService.processSalesOrder(data);
        response.then(function (list) {
            //toastr.success(list.data);

            $scope.processBtn = false;

            // $("#processBtn").attr("disabled", true);
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


            $scope.indentSearching({});
            // data={};
            //  Entity = {};
            //  $scope.IndentObj={};

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });

        console.log("After Update List " + JSON.stringify(data));

    };



    $scope.quantityChangeNew = function (Entity)
    {
        var unitCost = parseFloat(Entity.unit_cost);
        var netUnitPrice = parseFloat(Entity.netunit_price);
        var unitQuty = parseInt(Entity.unit_pcs);
        //  var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);
        var discountPrcnt = Entity.discount_percent_primary;
        var discount = parseFloat(discountPrcnt / 100);
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
        Entity.total_amount = unitCost * unitQuty;
        Entity.discount_percent_salesorder = discountPrcnt;
        Entity.discount_amount = Entity.total_amount * discount;
        Entity.net_amount = parseFloat(Entity.total_amount - Entity.discount_amount).toFixed(2);





    };




    $scope.init = function () {


        $('.date').datetimepicker({
            format: 'YYYY-MM-DD',

        });
        // var baseUrl = 'http://127.0.0.1:8000/api/findProductQuery';
        // var baseUrlFindSupplier = 'http://127.0.0.1:8000/api/getdistributorpoint-typeahend';

        var baseUrl = 'http://sims.timezoneservice.com/api/findProductQuery';
        var baseUrlFindSupplier = 'http://sims.timezoneservice.com/api/getdistributorpoint-typeahend';


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



    $('#productQry .typeahead').on('typeahead:selected', function (evt, item) {



        $scope.EntityObj = {};





        var data = {price_id: $scope.Entity.pricetype_id,
            product_id: item.product_id,
            tracking_id: $scope.IndentObj.indentMaster[0].tracking_no
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

            if (item.data[0].stock == 0)
            {

                swal({
                    html: true,
                    title: "Product Stock Not Available",
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
            $scope.EntityObj.available_stock = item.data[0].available_stock;
            $scope.EntityObj.stock = item.data[0].stock;
            $scope.EntityObj.discount_percent_primary = (($scope.EntityObj.discount_amount / $scope.EntityObj.netunit_price) * 100).toFixed(2);



            $("#unit_cost").val($scope.EntityObj.unit_cost);

            $("#currentDiscount").val($scope.EntityObj.discount_amount);
            $("#netUnitPrice").val($scope.EntityObj.netunit_price);

            $("#stock").val(item.data[0].stock);
            $("#available_stock").val(item.data[0].available_stock);
            $("#unit_pcs").val('');
            $("#unit_ctn").val('');
            $("#net_amount").val('');







            /*   $scope.EntityObj.product_id = item.product_id;
             $scope.EntityObj.pics_qty = parseInt(item.pics_qty);
             $scope.EntityObj.product_name = item.name;
             $scope.EntityObj.barcode = item.barcode;
             $scope.EntityObj.unit_cost = parseFloat(item.product_price);
             $scope.EntityObj.discount_amount_primary = parseFloat(item.discount_amount_primary ? item.discount_amount_primary : 0);
             $scope.EntityObj.discount_amount = parseFloat(item.discount_amount_primary ? item.discount_amount_primary : 0);
             $scope.EntityObj.netunit_price = $scope.EntityObj.unit_cost - $scope.EntityObj.discount_amount;
             $scope.EntityObj.pricetype_id = item.pricetype_id;
             $scope.EntityObj.unit_discountamount = item.discount_amount_primary;
             
             */





        }, function (error) {
            toastr.error(error.data);
        });










        if (item.product_price == 0 || item.product_price == null)
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

        if (item.stock == 0)
        {

            swal({
                html: true,
                title: "Product Stock Not Available",
                text: "",
                type: "error",
                timer: 5000,
                confirmButtonText: "Close",
                // html: "<h1>Hello Everyone</h1>"
                showConfirmButton: true
            });
            return;
        }


        // $("#discount_percent_primary").val($scope.EntityObj.discount_percent_primary);



    })





}


angular.module('myApps')
        .controller('SalesOrderController', SalesOrderController);