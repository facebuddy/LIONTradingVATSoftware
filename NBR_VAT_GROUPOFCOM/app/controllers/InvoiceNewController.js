'use strict';
var InvoiceNewController = function ($scope, $filter, $window, $log, simsService) {
    $scope.title = "Product Component";
    $scope.indentList = [];
    $scope.EntityObj = {};
    $scope.purchaseList = [];
    $scope.Entity = {};
    $scope.IndentObj = {};
    $scope.salesorderList = [];
    $scope.ctn_quantity_salesorder = 0;
    $scope.quantity_salesorder = 0;
    $scope.totalamount_salesorder = 0;
    $scope.discount_amount_salesorder = 0;
    $scope.discount_percent_salesorder = 0;
    $scope.netamount_salesorder = 0;
    $scope.totalSale = 0;
    $scope.totalOutstanding = 0;
    $scope.totalDiscount = 0;
    $scope.totalCollection = 0;
    $scope.invoiceList = [];
    $scope.InvoiceObj = {};
    $scope.ReturnInvoice = true;
    var baseReportUrl = "http://cr.time-zone.biz/";
    // var baseReportUrl = "http://localhost:51592/"
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
            $scope.invoiceList = [];



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




    $scope.salesOrderSearching = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        var response = simsService.getSalesOrderList(Entity);
        response.then(function (list) {

            $scope.salesorderList = list.data;
            $scope.pg = false;
            console.log("Sales Order List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.getSaleSummaryDistributorWise = function (Entity) {
        $scope.pg = true;

        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();

        var response = simsService.getSaleSummaryDistributorWise(Entity);
        response.then(function (list) {

            $scope.saleDistributorWise = list.data[0].salesView;
            // console.log("Sale List" + JSON.stringify($scope.saleDistributorWise));
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalTp = 0;
            $scope.totalDp = 0;
            $scope.pg = false;
            $scope.calculateTotalSale();

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }



    $scope.getSaleSummaryASMWise = function (Entity) {
        $scope.pg = true;

        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();

        var response = simsService.getSaleSummaryASMWise(Entity);
        response.then(function (list) {
            $scope.saleDistributorWise = [];

            $scope.saleDistributorWise = list.data[0].salesView;
            // console.log("Sale List" + JSON.stringify($scope.saleDistributorWise));
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalTp = 0;
            $scope.totalDp = 0;
            $scope.pg = false;
            $scope.calculateTotalSale();

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }







    $scope.getSaleSummaryDistributorWiseRealTime = function (Entity) {
        $scope.pg = true;

        // Entity.start_date = $("#start_date").val();
        //Entity.end_date = $("#end_date").val();

        var response = simsService.getSaleSummaryDistributorWise(Entity);
        response.then(function (list) {

            $scope.saleDistributorWise = list.data[0].salesView;
            //  console.log("Sale List" + JSON.stringify($scope.saleDistributorWise));
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalTp = 0;
            $scope.totalDp = 0;
            $scope.pg = false;
            $scope.calculateTotalSale();

        }, function (error) {
            $scope.pg = false;
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






    $scope.CheckUncheckHeaderReturn = function () {
        // $scope.IsAllChecked = true;

        if ($scope.IsAllChecked)
        {
            for (var i = 0; i < $scope.InvoiceObj.invoiceDetailsList.length; i++) {

                $scope.InvoiceObj.invoiceDetailsList[i].isSelected = true;

            }

        } else {
            for (var i = 0; i < $scope.InvoiceObj.invoiceDetailsList.length; i++) {

                $scope.InvoiceObj.invoiceDetailsList[i].isSelected = false;

            }


        }

        //  $scope.calculateTotal();

    };





    $scope.changeCheckBox = function (Entity) {
        // $scope.IsAllChecked = true;



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

            $scope.ctn_quantity_salesorder += parseFloat(item['ctn_quantity_salesorder']);
            $scope.quantity_salesorder += parseInt(item['quantity_salesorder']);
            $scope.totalamount_salesorder += parseFloat(item['totalamount_salesorder']);
            $scope.discount_amount_salesorder += parseFloat(item['discount_amount_salesorder']);
            $scope.discount_percent_salesorder += parseFloat(item['discount_percent_salesorder']);
            $scope.netamount_salesorder += parseFloat(item['netamount_salesorder']);


        });


    };



    $scope.calculateTotalSale = function ()
    {
        $scope.totalSale = 0;
        $scope.totalOutstanding = 0;
        $scope.totalCollection = 0;



        $scope.saleDistributorWise.forEach(function (item) {

            $scope.totalSale += parseFloat(item['netamount']);
            $scope.totalOutstanding += parseInt(item['outstanding']);
            $scope.totalCollection += parseFloat(item['collection']);



        });


    };










    $scope.getSalesOrderByInvoice = function (Entity) {


        var response = simsService.getSalesOrderByInvoice(Entity);
        response.then(function (list) {

            //  $scope.IndentObj.chalanmaster_id=Entity;
            //  $scope.IsAllChecked = true;
            $scope.InvoiceObj = list.data;
            $scope.processBtn = true;

            for (var i = 0; i < $scope.InvoiceObj.invoiceDetailsList.length; i++) {

                $scope.InvoiceObj.invoiceDetailsList[i].return_qty = parseInt($scope.InvoiceObj.invoiceDetailsList[i].quantity);



            }



            console.log("Invoice List" + JSON.stringify($scope.InvoiceObj));
        }, function (error) {
            toastr.error(error.data);
        });
    }







    $scope.getIndentById = function (Entity) {

        var data = {
            id: Entity
        };

        var response = simsService.getSalesOrderById(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.IndentObj = list.data[0];
            $scope.IsAllChecked = true;
            for (var i = 0; i < $scope.IndentObj.indentDetailsList.length; i++) {

                $scope.IndentObj.indentDetailsList[i].isSelected = true;
                $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder = $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder;
                $scope.IndentObj.indentDetailsList[i].quantity_salesorder = $scope.IndentObj.indentDetailsList[i].quantity_salesorder;
                $scope.IndentObj.indentDetailsList[i].totalamount_salesorder = $scope.IndentObj.indentDetailsList[i].totalamount_salesorder;
                $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder = $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder;
                $scope.IndentObj.indentDetailsList[i].discount_percent_salesorder = ($scope.IndentObj.indentDetailsList[i].discount_amount_salesorder / $scope.IndentObj.indentDetailsList[i].totalamount_salesorder) * 100;
                $scope.IndentObj.indentDetailsList[i].netamount_salesorder = $scope.IndentObj.indentDetailsList[i].netamount_salesorder;

                if ($scope.IndentObj.indentDetailsList[i].due_status == 1)
                {
                    $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder = $scope.IndentObj.indentDetailsList[i].due_ctn_quantity;
                    $scope.IndentObj.indentDetailsList[i].quantity_salesorder = $scope.IndentObj.indentDetailsList[i].due_pcs_quantity;
                    $scope.IndentObj.indentDetailsList[i].ctn_quantity_invoice = $scope.IndentObj.indentDetailsList[i].due_ctn_quantity;
                    $scope.IndentObj.indentDetailsList[i].quantity_invoice = $scope.IndentObj.indentDetailsList[i].due_pcs_quantity;
                    $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder = ($scope.IndentObj.indentDetailsList[i].unit_price_indent * $scope.IndentObj.indentDetailsList[i].due_pcs_quantity) * ($scope.IndentObj.indentDetailsList[i].unit_discountpercent_salesorder / 100);
                    $scope.IndentObj.indentDetailsList[i].netamount_salesorder = ($scope.IndentObj.indentDetailsList[i].unit_price_indent * $scope.IndentObj.indentDetailsList[i].due_pcs_quantity);

                } else
                {
                    $scope.IndentObj.indentDetailsList[i].ctn_quantity_invoice = $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder;
                    $scope.IndentObj.indentDetailsList[i].quantity_invoice = $scope.IndentObj.indentDetailsList[i].quantity_salesorder;

                }

                $scope.IndentObj.indentDetailsList[i].due_pcs_quantity = 0;
                $scope.IndentObj.indentDetailsList[i].due_ctn_quantity = 0;

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
        var unitQty = parseInt(Entity.quantity_invoice);

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

        Entity.totalamount_salesorder = unitCost * unitQty;
        Entity.ctn_quantity_invoice = (unitQty / unitQtyUnit).toFixed(2);
        Entity.discount_amount_salesorder = Entity.totalamount_salesorder * (Entity.unit_discountpercent_salesorder / 100);
        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;
        //  Entity.discount_percent_salesorder = ((Entity.unit_discountamount_salesorder / Entity.totalamount_salesorder) * 100).toFixed(2);
        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);
        Entity.due_pcs_quantity = Entity.quantity_salesorder - Entity.quantity_invoice;
        Entity.due_ctn_quantity = (Entity.ctn_quantity_salesorder - Entity.ctn_quantity_invoice).toFixed(2);
        $scope.calculateTotal();

    };



    $scope.discountAmountChange = function (Entity)
    {



        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;

        Entity.discount_percent_salesorder = ((Entity.discount_amount_salesorder / Entity.totalamount_salesorder) * 100).toFixed(2);

        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);

        $scope.calculateTotal();

    };


    $scope.discountPercentChange = function (Entity)
    {

        var discount = Entity.discount_percent_salesorder / 100;
        Entity.discount_amount_salesorder = (Entity.totalamount_salesorder * discount).toFixed(2);

        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;

        // Entity.discount_percent_salesorder = ((Entity.discount_amount_salesorder / Entity.totalamount_salesorder) * 100).toFixed(2);

        // var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);

        $scope.calculateTotal();

    };


    $scope.processInvoice = function (Entity)
    {
        // console.log("Before Update List " + Entity);
        // console.log("Before Update List " + JSON.stringify(Entity));
        $scope.pg = true;
        $scope.salesOrderTemp = $filter('filter')(Entity, function (item) {
            return (item.isSelected == true);
        });

        var data = {
            company_id: getCookie('company_id'),
            user_id: getCookie('user_id'),
            distributor_name: Entity.distributor_name,
            driver_name: Entity.driver_name,
            delivery_details: Entity.delivery_details,
            transport_name: Entity.transport_name,
            vehicle_number: Entity.vehicle_number,
            delivery_place: Entity.delivery_place,
            chalanmaster_id: $scope.IndentObj.indentMaster[0].id,
            total_amount_salesorder: $scope.totalamount_salesorder,
            total_discount_amount_salesorder: $scope.discount_amount_salesorder,
            price_type: $scope.IndentObj.indentMaster[0].price_type,
            sales_location_id: $scope.IndentObj.indentMaster[0].destination_location_id,
            total_netamount_salesorder: $scope.netamount_salesorder,
            salesOrderList: $scope.salesOrderTemp,
        };

        if ($scope.salesOrderTemp.length > 18)
        {
            toastr.error("You can not Add greater than 18 Products!");
            $scope.pg = false;
            return;
        }




        var response = simsService.processInvoice(data);
        response.then(function (list) {
            //toastr.success(list.data);


            $scope.IndentObj = list.data[0];
            $scope.IsAllChecked = true;


            var invoiceObj = {
                invoice_no: $scope.IndentObj.invoice_no
            };
            $scope.invoiceList.push(invoiceObj);
            for (var i = 0; i < $scope.IndentObj.indentDetailsList.length; i++) {

                $scope.IndentObj.indentDetailsList[i].isSelected = true;
                $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder = $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder;
                $scope.IndentObj.indentDetailsList[i].quantity_salesorder = $scope.IndentObj.indentDetailsList[i].quantity_salesorder;
                $scope.IndentObj.indentDetailsList[i].totalamount_salesorder = $scope.IndentObj.indentDetailsList[i].totalamount_salesorder;
                $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder = $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder;
                $scope.IndentObj.indentDetailsList[i].discount_percent_salesorder = ($scope.IndentObj.indentDetailsList[i].discount_amount_salesorder / $scope.IndentObj.indentDetailsList[i].totalamount_salesorder) * 100;
                $scope.IndentObj.indentDetailsList[i].netamount_salesorder = $scope.IndentObj.indentDetailsList[i].netamount_salesorder;

                if ($scope.IndentObj.indentDetailsList[i].due_status == 1)
                {
                    $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder = $scope.IndentObj.indentDetailsList[i].due_ctn_quantity;
                    $scope.IndentObj.indentDetailsList[i].quantity_salesorder = $scope.IndentObj.indentDetailsList[i].due_pcs_quantity;
                    $scope.IndentObj.indentDetailsList[i].ctn_quantity_invoice = $scope.IndentObj.indentDetailsList[i].due_ctn_quantity;
                    $scope.IndentObj.indentDetailsList[i].quantity_invoice = $scope.IndentObj.indentDetailsList[i].due_pcs_quantity;

                    $scope.IndentObj.indentDetailsList[i].netamount_salesorder = ($scope.IndentObj.indentDetailsList[i].quantity_invoice * $scope.IndentObj.indentDetailsList[i].unit_price_indent).toFixed(2);
                    $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder = $scope.IndentObj.indentDetailsList[i].netamount_salesorder * ($scope.IndentObj.indentDetailsList[i].discount_percent_salesorder / 100)

                } else
                {
                    $scope.IndentObj.indentDetailsList[i].ctn_quantity_invoice = $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder;
                    $scope.IndentObj.indentDetailsList[i].quantity_invoice = $scope.IndentObj.indentDetailsList[i].quantity_salesorder;

                }

                $scope.IndentObj.indentDetailsList[i].due_pcs_quantity = 0;
                $scope.IndentObj.indentDetailsList[i].due_ctn_quantity = 0;

            }

            $scope.calculateTotal();


            $scope.pg = false;
            swal({
                html: true,
                title: "Successfully Invoice generated",
                text: "",
                type: "success",
                timer: 2000,
                confirmButtonText: "Close",
                // html: "<h1>Hello Everyone</h1>"
                showConfirmButton: true
            });
            // data={};
            //  Entity = {};
            //  $scope.IndentObj={};

        }, function (error) {
            toastr.error(error.data);
        });

        $scope.salesOrderSearching({});
        console.log("After Update List " + JSON.stringify(data));

    };




    $scope.processInvoiceReturn = function (Entity)
    {
        // console.log("Before Update List " + Entity);
        // console.log("Before Update List " + JSON.stringify(Entity));
        $scope.pg = true;
        $scope.salesOrderTemp = $filter('filter')(Entity, function (item) {
            return (item.isSelected == true);
        });
        var date = Entity[0].salesmaster_id;

        var ctn_quantity = 0;
        var return_qty = 0;
        var netamount = 0;
        var discount_amount = 0;
        var total_amount = 0;

        $scope.salesOrderTemp.forEach(function (item) {

            ctn_quantity += parseInt(item['ctn_quantity']);
            return_qty += parseFloat(item['return_qty']);
            netamount += parseInt(item['netamount']);
            total_amount += parseInt(item['totalamount']);
            discount_amount += parseFloat(item['discount_amount']);


        });


        // var test = data.salesmaster_id;
        var data = {
            company_id: getCookie('company_id'),
            user_id: getCookie('user_id'),
            salesmaster_id: Entity[0].salesmaster_id,
            invoice_number: $scope.Entity.invoice_number,
            total_netamount: netamount,
            total_amount: total_amount,
            total_quantity: return_qty,
            total_ctn_quantity: ctn_quantity,
            total_discount_amount: discount_amount,
            distribution_node_id: $scope.salesOrderTemp[0].distributor_id,

            salesOrderList: $scope.salesOrderTemp,
        };





        var response = simsService.processInvoiceReturn(data);
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
            // data={};
            //  Entity = {};
            //  $scope.IndentObj={};
            $scope.ReturnInvoice = false;
            $scope.processBtn = false;
        }, function (error) {
            toastr.error(error.data);
        });

        console.log("After Update List " + JSON.stringify(data));

    };





    $scope.getSaleSummaryDistributorWiseType = function (Entity) {
        $scope.pg = true;

        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();

        var response = simsService.getSaleSummaryDistributorWiseType(Entity);
        response.then(function (list) {

            $scope.saleDistributorWise = list.data[0].salesView;
            console.log("Sale List" + JSON.stringify($scope.saleDistributorWise));
            $scope.totalPcs = 0;
            $scope.totalCtn = 0;
            $scope.totalTp = 0;
            $scope.totalDp = 0;
            $scope.pg = false;
            $scope.calculateTotalSale();
        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
    }






    $scope.getInvoiceList = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        var response = simsService.getInvioceList(Entity);
        response.then(function (list) {

            $scope.invoiceList = list.data;
            $scope.pg = false;
            // console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }

    $scope.getInvoiceListRealTime = function (Entity) {

        $scope.pg = true;

        var response = simsService.getInvioceList(Entity);
        response.then(function (list) {

            $scope.invoiceList = list.data;
            $scope.pg = false;
            //console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.popitup = function (url) {
        return $window.open(baseReportUrl + "InvoicePrint.aspx?invoice_no=" + url, '_blank', 'height=800,width=1000');
    };

    $scope.popitupMushak = function (url) {
        return $window.open(baseReportUrl + "MushakPrint?invoice_no=" + url, '_blank', 'height=800,width=1000');
    };

    $scope.init = function () {


        $('.date').datetimepicker({
            format: 'YYYY-MM-DD',

        });



        var today = new Date();
        var dd = today.getDate();
        // var dd1 = today.getDate() - 1;
        // var mm = today.getMonth() + 1;

        var yyyy = today.getFullYear();
        $scope.Entity.start_date = yyyy + '-' + mm + '-' + dd;
        $scope.Entity.end_date = yyyy + '-' + mm + '-' + dd;


        // $scope.getSaleSummaryDistributorWiseRealTime($scope.Entity);

        $scope.getSaleSummaryDistributorWiseType($scope.Entity);
        $scope.getInvoiceListRealTime($scope.Entity);


        $("#start_date").text($scope.Entity.start_date);

        $("#end_date").text($scope.Entity.end_date);
        $("#start_date").val($scope.Entity.start_date);

        $("#end_date").val($scope.Entity.end_date);




    };
    var today = new Date();
    var dd = today.getDate();
    var dd1 = today.getDate() - 1;
    var mm = today.getMonth() + 1;
    var mm1 = today.getMonth() - 1;
    var yyyy = today.getFullYear();
    $scope.Entity.start_date = yyyy + '-' + mm + '-' + dd;
    $scope.Entity.end_date = yyyy + '-' + mm + '-' + dd;

    $("#start_date").text($scope.Entity.start_date);

    $("#end_date").text($scope.Entity.end_date);
    $("#start_date").val($scope.Entity.start_date);

    $("#end_date").val($scope.Entity.end_date);

    var userId = getCookie('user_id');

    var refreshId = setInterval(function () {

         $scope.getSaleSummaryDistributorWiseType($scope.Entity);
        $scope.getInvoiceListRealTime($scope.Entity);
    }, 1000 * 15 * 60);




}


angular.module('myApps')
        .controller('InvoiceNewController', InvoiceNewController);