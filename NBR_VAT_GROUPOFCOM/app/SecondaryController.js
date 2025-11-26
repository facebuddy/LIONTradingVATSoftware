'use strict';
var SecondaryController = function ($scope, $filter, $log, $window, simsService) {


    var baseReportUrl = "http://cr.time-zone.biz/";
    // var baseReportUrl = "http://localhost:51592/"

    $scope.pg = false;
    $scope.btn = true;
    $scope.currentPage = 1;
    //$scope.EntityObj.stcok=0; 
    $scope.invoiceList = [];
    $scope.distributorList = [];
    $scope.employeeListASR = [];
    $scope.deliveryPersonList = [];
    $scope.closingLedgerList = [];
    $scope.outletLists = [];
    $scope.bitList = [];
    $scope.bitLists = [];
    $scope.divisionList = [];
    $scope.quantity_salesorder = 0;
    $scope.outletList = [];
    $scope.districtList = [];
    $scope.indentList = [];
    $scope.deliveryListTemp = [];
    $scope.asmList = [];
    $scope.InvoiceObj = {};
    $scope.IndentObj = {};
    $scope.Entity = {};
    $scope.productObj = {};
    $scope.purchaseList = [];
    $scope.btnRecieve = true;
    $scope.total_netamount = 0;
    $scope.Entity.status = true;
    $scope.deliveryList = [];
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
            var Entity = {};
            $scope.getIndentById(id);
            $scope.btnRecieve = true;
            //  $scope.calculateTotal();


            //$scope.Entity = $filter('filter')($scope.roles, function(d) { return d.Id === id; })[0];
        } else if (mode == 'Update') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;
            $scope.Entity = $filter('filter')($scope.bitList, function (d) {
                return d.id === id;
            })[0];
            if ($scope.Entity.status == 1) {
                $scope.Entity.status = true;
            } else {
                $scope.Entity.status = false;
            }


        } else if (mode == 'SalesOrder') {
            $scope.Add = false;
            $scope.Update = false;
            $scope.title = title;
            $scope.Display = true;
            var Entity = {};
            $scope.getIndentByCompanyWise(id);
            $scope.btn = true;
            //  $scope.calculateTotal();


            //$scope.Entity = $filter('filter')($scope.roles, function(d) { return d.Id === id; })[0];
        } else if (mode == 'Sales') {
            $scope.Add = false;
            $scope.Update = false;
            $scope.title = title;
            $scope.Display = true;
            var Entity = {};
            $scope.getIndentByCompanyWiseSales(id);
            $scope.btn = true;
            //  $scope.calculateTotal();


            //$scope.Entity = $filter('filter')($scope.roles, function(d) { return d.Id === id; })[0];
        }








    }




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

        var data = {
            company_id: getCookie('company_id'),
            chalanmaster_id: $scope.IndentObj.chalan_master_id,
            total_amount_salesorder: $scope.totalamount_salesorder,
            delivery_person_id: $scope.IndentObj.delivery_person_id,

            total_discount_amount_salesorder: $scope.discount_amount_salesorder,
            total_discount_amount_salesorder: $scope.discount_amount_salesorder,
            total_netamount_salesorder: $scope.netamount_salesorder,
            salesOrderList: $scope.salesOrderTemp,
        };
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
        var response = simsService.processSalesOrderSecondary(data);
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
            $scope.indentSearchingSecondary({});
            $scope.btn = false;
            // data={};
            //  Entity = {};
            //  $scope.IndentObj={};

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
        console.log("After Update List " + JSON.stringify(data));
    };
    $scope.processDelivery = function (Entity, IndentObj)
    {

        $scope.pg = true;
        // console.log("Before Update List " + Entity);
        // console.log("Before Update List " + JSON.stringify(Entity));

        $scope.salesOrderTemp = $filter('filter')(Entity, function (item) {
            return (item.isSelected == true);
        });
        // alert( $scope.salesOrderTemp);
        // return;


        var data = {
            company_id: getCookie('company_id'),
            chalanmaster_id: Entity[0].chalan_master_id,
            parent_company_id: 1,

            delivery_person_id: Entity[0].delivery_person_id,
            asr_id: Entity[0].asr_id,
            bit_id: Entity[0].bit_id,
            outlet_id: Entity[0].outlet_id,

            total_amount_salesorder: $scope.totalamount_salesorder,
            total_discount_amount_salesorder: $scope.discount_amount_salesorder,
            total_discount_amount_salesorder: $scope.discount_amount_salesorder,
            total_netamount_salesorder: $scope.netamount_salesorder,
            salesOrderList: $scope.salesOrderTemp,
        };



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
        var response = simsService.processInvoiceSecondary(data);
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
            $scope.getDeliveryListSecondary({});
            $scope.btn = false;
            // data={};
            //  Entity = {};
            //  $scope.IndentObj={};

        }, function (error) {
            $scope.pg = false;
            toastr.error(error.data);
        });
        console.log("After Update List " + JSON.stringify(data));
    };
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
            $scope.Entity = $filter('filter')($scope.outletList, function (d) {
                return d.id === id;
            })[0];
            if ($scope.Entity.division) {
                $scope.getDistricts($scope.Entity.division);
                $scope.Entity.division = parseInt($scope.Entity.division);
                $scope.Entity.district = parseInt($scope.Entity.district);
                //do something
            }

            if ($scope.Entity.status == 1) {
                $scope.Entity.status = true;
            } else {
                $scope.Entity.status = false;
            }


        }
    }

    $scope.pageChanged = function () {
        var begin = (($scope.currentPage - 1) * $scope.itemsPerPage),
                end = begin + $scope.itemsPerPage;
        // $scope.componetListflt = $scope.componetList.slice(begin, end);
    };
    $scope.saveIndentProducts = function (Entity) {

        if (Entity.bit_id == null)
        {
            toastr.error("Please add Bit");
            return;
        }
        if (Entity.outlet_id == null)
        {
            toastr.error("Please add Outlet");
            return;
        }




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
        var response = simsService.saveIndentProductsSecondary(Entity);
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





    $scope.getBitListByCompany = function (Entity) {

        var data = {
            company_id: Entity
        };
        var response = simsService.getBitListByCompany(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.bitLists = list.data;
            console.log("Bit List" + JSON.stringify($scope.bitLists));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.getASRList = function (Entity) {

        var data = {
            user_type: Entity
        };
        var response = simsService.getUsersByType(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.employeeListASR = list.data;
            console.log("Bit List" + JSON.stringify($scope.bitList));
        }, function (error) {
            toastr.error(error.data);
        });
    }

    $scope.getDeliveryPersonList = function (Entity) {

        var data = {
            user_type: Entity
        };
        var response = simsService.getDeliveryPerson(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.deliveryPersonList = list.data;
            console.log("Bit List" + JSON.stringify($scope.bitList));
        }, function (error) {
            toastr.error(error.data);
        });
    }




    $scope.getOutletListByCompany = function (Entity) {

        var data = {
            company_id: getCookie('company_id'),
            bit_id: Entity
        };
        var response = simsService.getOutletListByCompany(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.outletLists = list.data;
            //  $scope.calculateTotal();

            console.log("Bit List" + JSON.stringify($scope.bitList));
        }, function (error) {
            toastr.error(error.data);
        });
    }






    $scope.getClosingLedgerList = function (Entity) {

        $scope.pg = true;
        // start_date
        Entity.end_date = $("#end_date").val();
        var response = simsService.getClosingLedgerList(Entity);
        response.then(function (list) {

            $scope.closingLedgerList = list.data[0].closingLedger;
            $scope.pg = false;
            $scope.calculateLedger();
            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.getComponentsList = function () {

        var response = simsService.getComponents();
        response.then(function (list) {



        }, function (error) {
            toastr.error(error.data);
        });
    }

    $scope.getDistributors = function (Entity) {

        $scope.pg = true;
        // start_date

        var response = simsService.getDistributors();
        response.then(function (list) {

            $scope.distributorList = list.data;
            $scope.pg = false;
            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.saveBit = function (Entity) {

        $scope.pg = true;
        // start_date
        Entity.parent_company_id = 1;
        var response = simsService.saveBit(Entity);
        response.then(function (list) {

            // $scope.distributorList = list.data;
            $scope.pg = false;
            toastr.success("Successfully Save data!");
            $scope.getBits();
            //console.log("Save List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.saveOutlet = function (Entity) {

        $scope.pg = true;
        // start_date
        Entity.parent_company_id = 1;
        var response = simsService.saveOutlet(Entity);
        response.then(function (list) {

            // $scope.distributorList = list.data;
            $scope.pg = false;
            toastr.success("Successfully Save data!");
            $scope.getOutlets();
            //console.log("Save List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }

    $scope.updateBit = function (Entity) {

        $scope.pg = true;
        // start_date
        Entity.parent_company_id = 1;
        var response = simsService.updateBit(Entity);
        response.then(function (list) {

            // $scope.distributorList = list.data;
            $scope.pg = false;
            toastr.success(list.data);
            //console.log("Save List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.updateOutlet = function (Entity) {

        $scope.pg = true;
        // start_date
        Entity.parent_company_id = 1;
        var response = simsService.updateOutlet(Entity);
        response.then(function (list) {

            // $scope.distributorList = list.data;
            $scope.pg = false;
            toastr.success(list.data);
            //console.log("Save List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.getBits = function (Entity) {


        var response = simsService.getBits(Entity);
        response.then(function (list) {

            $scope.bitList = list.data;
            $scope.pg = false;
            console.log("Bit list" + JSON.stringify(list.data));
            // toastr.success(list.data);

        }, function (error) {
            toastr.error(error.data);
        });
    }




    $scope.indentSearchingSecondary = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        Entity.company_id = getCookie('company_id');
        var response = simsService.getIndentListSecondary(Entity);
        response.then(function (list) {

            $scope.indentList = list.data;
            $scope.pg = false;
            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }

    $scope.getDeliveryListSecondary = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        Entity.company_id = getCookie('company_id');
        var response = simsService.getDeliveryListSecondary(Entity);
        response.then(function (list) {

            $scope.deliveryList = list.data;
            $scope.pg = false;
            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }


    $scope.getDeliveryList = function (Entity) {

        $scope.pg = true;
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        Entity.company_id = getCookie('company_id');
        var response = simsService.getDeliveryList(Entity);
        response.then(function (list) {

            $scope.deliveryList = list.data;
            $scope.pg = false;
            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }




    $scope.CheckUncheckHeaderPrint = function () {
        // $scope.IsAllChecked = true;

        if ($scope.IsAllChecked)
        {
            for (var i = 0; i < $scope.deliveryList.length; i++) {

                $scope.deliveryList[i].isSelected = true;

            }

        } else {
            for (var i = 0; i < $scope.deliveryList.length; i++) {

                $scope.deliveryList[i].isSelected = false;

            }


        }

        // $scope.calculateTotal();

    };





    $scope.printInv = function () {
        // $scope.IsAllChecked = true;

        var invoice_no = "";

        $scope.deliveryListTemp = $filter('filter')($scope.deliveryList, function (item) {
            return (item.isSelected == true);
        });

        for (var i = 0; i < $scope.deliveryListTemp.length; i++) {

            if (i == 0)
            {
                invoice_no = $scope.deliveryListTemp[i].tracking_no;
            } else
            {
                invoice_no = invoice_no + "," + $scope.deliveryListTemp[i].tracking_no;
            }



        }
        console.log(invoice_no);


        return $window.open(baseReportUrl + "/SecondaryUI/InvoicePrint.aspx?invoice_no=" + invoice_no, '_blank', 'height=800,width=1000');



        // $scope.calculateTotal();

    };










    $scope.stockReceive = function (stockList, Entity)
    {
        // console.log("Before Update List " + Entity);
        // console.log("Before Update List " + JSON.stringify(Entity));
        $scope.pg = true;
        var data = {
            company_id: getCookie('company_id'),
            user_id: getCookie('user_id'),
            salesmaster_id: Entity[0].salesmaster_id,
            stockList: stockList,
        };
        var response = simsService.stockReceive(data);
        response.then(function (list) {
            //toastr.success(list.data);




            $scope.pg = false;
            swal({
                html: true,
                title: "Successfully Received!",
                text: "",
                type: "success",
                timer: 2000,
                confirmButtonText: "Close",
                // html: "<h1>Hello Everyone</h1>"
                showConfirmButton: true
            });
            $scope.btnRecieve = false;
            // data={};
            //  Entity = {};
            //  $scope.IndentObj={};
            var data = {};
            $scope.getInvoiceList(data);
        }, function (error) {
            toastr.error(error.data);
            $scope.pg = false;
        });
        console.log("After Update List " + JSON.stringify(data));
    };
    $scope.getOutlets = function (Entity) {


        var response = simsService.getOutlets(Entity);
        response.then(function (list) {

            $scope.outletList = list.data;
            $scope.pg = false;
            console.log("Outlet list" + JSON.stringify(list.data));
            // toastr.success(list.data);

        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.getDivision = function () {


        var response = simsService.getDevisions();
        response.then(function (list) {

            $scope.divisionList = list.data;
            $scope.pg = false;
            console.log("Devision list" + JSON.stringify($scope.divisionList));
            // toastr.success(list.data);

        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.getDistricts = function (Entity) {


        var response = simsService.getDistricts(Entity);
        response.then(function (list) {

            $scope.districtList = list.data;
            $scope.pg = false;
            console.log("Bit list" + JSON.stringify($scope.districtList));
            // toastr.success(list.data);

        }, function (error) {
            toastr.error(error.data);
        });
    }



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
        // var discountAmount = Entity.discount_amount * unitCost;
        // var totaldiscountAmount = discountPercent * unitCost;
        var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs).toFixed(2);
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
        Entity.discount_amounts = discount;
        Entity.unit_discountamount_indent = Entity.discount_amount;
        // Entity.unit_discountamount = Entity.discount_amount;
        Entity.unit_discountpercent_indent = Entity.discount_percent;
    };
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






    $scope.getInvoiceList = function (Entity) {

        $scope.pg = true;
        // start_date
        Entity.start_date = $("#start_date").val();
        Entity.end_date = $("#end_date").val();
        Entity.location_id = getCookie('company_id');
        var response = simsService.getInvioceListByLocation(Entity);
        response.then(function (list) {

            $scope.invoiceList = list.data;
            $scope.pg = false;
            console.log("Indent List" + JSON.stringify(list.data));
        }, function (error) {
            toastr.error(error.data);
        });
    }




    /*   $scope.getIndentById = function (Entity) {
     
     var data = {
     invoice_no: Entity
     };
     
     var response = simsService.getInvioceById(data);
     response.then(function (list) {
     //  $scope.IndentObj.chalanmaster_id=Entity;
     
     $scope.IndentObj = list.data;
     
     $scope.IsAllChecked = true;
     
     
     console.log("Indent List" + JSON.stringify($scope.IndentObj));
     }, function (error) {
     toastr.error(error.data);
     });
     }
     */





    $scope.calculateTotal = function ()
    {

        $scope.total_netamount = 0;
        $scope.IndentObj[0].invoiceDetailsList.forEach(function (item) {

            $scope.total_netamount += parseFloat(item['netamount'])


        });
    };










    $scope.calculateLedger = function ()
    {

        $scope.total_netamount = 0;
        $scope.closingLedgerList.forEach(function (item) {

            $scope.total_netamount += parseFloat(item['balance'])


        });
    };



    $scope.getIndentById = function (Entity) {

        var data = {
            invoice_no: Entity
        };
        var response = simsService.getInvioceById(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.IndentObj = list.data;
            $scope.IsAllChecked = true;
            $scope.calculateTotal();
            //  $scope.calculateTotal();

            console.log("Indent List" + JSON.stringify($scope.IndentObj));
        }, function (error) {
            toastr.error(error.data);
        });
    }



    $scope.quantityChangeSalesOrder = function (Entity)
    {

        if (Entity.stock < Entity.quantity_salesorder)
        {
            Entity.stockAvail = false;
        } else
        {
            Entity.stockAvail = true;
        }
        var unitCost = parseFloat(Entity.product_unit_price);
        // var netUnitPrice = parseFloat(Entity.netunit_price);
        var unitQty = parseInt(Entity.quantity_salesorder);
        if (isNaN(unitQty) || unitQty == 0)
        {

            toastr.error("Quantity Can not be empty!");
            // Entity.quantity_salesorder=1;

        }
        var unitQtyUnit = parseInt(Entity.pics_qty);
        Entity.totalamount_salesorder = unitCost * unitQty;
        Entity.ctn_quantity_salesorder = (unitQty / unitQtyUnit).toFixed(2);
        Entity.discount_amount_salesorder = parseFloat(Entity.totalamount_salesorder * (Entity.discount_percent_salesorder / 100).toFixed(2));
        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;
        $scope.calculateTotalSalesOrder();
    };
    $scope.quantityChangeSalesOrderDlr = function (Entity)
    {



        if (Entity.return_quantity_salesorder > Entity.quantity_salesorder)
        {
            Entity.stockAvail = false;
        } else
        {
            Entity.stockAvail = true;
        }

        Entity.sale_quantity = Entity.quantity_salesorder - Entity.return_quantity_salesorder;
        var unitCost = parseFloat(Entity.product_unit_price);
        // var netUnitPrice = parseFloat(Entity.netunit_price);
        var unitQty = parseInt(Entity.sale_quantity);
        if (isNaN(unitQty) || unitQty == 0)
        {

            // toastr.error("Quantity Can not be empty!");
            // Entity.quantity_salesorder=1;

        }
        var unitQtyUnit = parseInt(Entity.pics_qty);
        Entity.totalamount_salesorder = unitCost * unitQty;
        Entity.ctn_quantity_salesorder = (unitQty / unitQtyUnit).toFixed(2);
        Entity.discount_amount_salesorder = parseFloat(Entity.totalamount_salesorder * (Entity.discount_percent_salesorder / 100).toFixed(2));
        Entity.netamount_salesorder = Entity.totalamount_salesorder - Entity.discount_amount_salesorder;
        $scope.calculateTotalSalesOrderDLR();
    };
    $scope.calculateTotalSalesOrder = function ()
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
    $scope.calculateTotalSalesOrderDLR = function ()
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
            $scope.quantity_salesorder += parseInt(item['sale_quantity']);
            $scope.netamount_salesorder += parseFloat(item['netamount_salesorder']);
            $scope.discount_amount_salesorder += parseFloat(item['discount_amount_salesorder']);
            $scope.discount_percent_salesorder += parseFloat(item['discount_percent_salesorder']);
            $scope.totalamount_salesorder += parseFloat(item['totalamount_salesorder']);
        });
        $scope.ctn_quantity_salesorder = $scope.ctn_quantity_salesorder.toFixed(2);
    };
    $scope.getIndentByCompanyWiseSales = function (Entity) {

        var data = {
            id: Entity,
            company_id: getCookie('company_id')
        };
        var response = simsService.getsalesListSecondary(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.IndentObj = list.data;
            $scope.IsAllChecked = true;
            for (var i = 0; i < $scope.IndentObj.indentDetailsList.length; i++) {
                if ($scope.IndentObj.indentDetailsList[i].quantity_indent > $scope.IndentObj.indentDetailsList[i].stock)
                {
                    $scope.IndentObj.indentDetailsList[i].stockAvail = false;
                } else
                {
                    $scope.IndentObj.indentDetailsList[i].stockAvail = true;
                }


                $scope.IndentObj.indentDetailsList[i].isSelected = true;
                $scope.IndentObj.indentDetailsList[i].isNewItem = false;
                $scope.IndentObj.indentDetailsList[i].ctn_quantity_salesorder = $scope.IndentObj.indentDetailsList[i].ctn_quantity_indent;
                $scope.IndentObj.indentDetailsList[i].quantity_salesorder = parseInt($scope.IndentObj.indentDetailsList[i].quantity_salesorder);
                $scope.IndentObj.indentDetailsList[i].return_quantity_salesorder = 0;
                $scope.IndentObj.indentDetailsList[i].totalamount_salesorder = $scope.IndentObj.indentDetailsList[i].totalamount_indent;
                $scope.IndentObj.indentDetailsList[i].discount_amount_salesorder = parseFloat($scope.IndentObj.indentDetailsList[i].discount_amount_salesorder);
                // $scope.IndentObj.indentDetailsList[i].discount_percent_salesorder = parseFloat(($scope.IndentObj.indentDetailsList[i].discount_amount_indent / $scope.IndentObj.indentDetailsList[i].totalamount_indent) * 100);
                $scope.IndentObj.indentDetailsList[i].discount_percent_salesorder = parseFloat($scope.IndentObj.indentDetailsList[i].unit_discountpercent_indent);
                $scope.IndentObj.indentDetailsList[i].netamount_salesorder = $scope.IndentObj.indentDetailsList[i].netamount_indent;
                $scope.IndentObj.indentDetailsList[i].sale_quantity = $scope.IndentObj.indentDetailsList[i].quantity_salesorder;
            }

            $scope.calculateTotalSalesOrderDLR();
            // $scope.calculateTotal();

            //  $scope.calculateTotal();

            console.log("Indent List" + JSON.stringify($scope.IndentObj));
        }, function (error) {
            toastr.error(error.data);
        });
    }





    $scope.getIndentByCompanyWise = function (Entity) {

        var data = {
            id: Entity,
            company_id: getCookie('company_id')
        };
        var response = simsService.getIndentByIdSecondary(data);
        response.then(function (list) {
            //  $scope.IndentObj.chalanmaster_id=Entity;

            $scope.IndentObj = list.data;
            $scope.IsAllChecked = true;
            for (var i = 0; i < $scope.IndentObj.indentDetailsList.length; i++) {
                if ($scope.IndentObj.indentDetailsList[i].quantity_indent > $scope.IndentObj.indentDetailsList[i].stock)
                {
                    $scope.IndentObj.indentDetailsList[i].stockAvail = false;
                } else
                {
                    $scope.IndentObj.indentDetailsList[i].stockAvail = true;
                }


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

            $scope.calculateTotalSalesOrder();
            // $scope.calculateTotal();

            //  $scope.calculateTotal();

            console.log("Indent List" + JSON.stringify($scope.IndentObj));
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

    $scope.getAsmList = function () {

        var response = simsService.getAsmList();
        response.then(function (list) {

            $scope.asmList = list.data;
            console.log("ASM list:" + JSON.stringify($scope.asmList));

        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.init = function () {

        $('.date').datetimepicker({
            format: 'YYYY-MM-DD',
        });
        $('#datetimepicker11').datetimepicker({
            defaultDate: new Date()
        });
        $('#challanDate').datetimepicker({
            defaultDate: new Date()
        });
        $scope.getAsmList();
        $scope.getOutlets();
        $scope.getDistributors();
        $scope.getBits();
        $scope.getDivision();
        $scope.getBitListByCompany();
        $scope.getDeliveryPersonList(12);
        var company_id = getCookie('company_id');
        $scope.getBitListByCompany(company_id);
        //var baseUrl = 'http://127.0.0.1:8000/api/findProductQuery';
        //var baseUrlFindSupplier = 'http://127.0.0.1:8000/api/getdistributorpoint-typeahend';
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
                name: 'name',
                display: 'name',
                source: findDistributorQuery
            });
        });
    };
////////////////////////////////////// End init //////////////////////////////////

    $('#productQry .typeahead').on('typeahead:selected', function (evt, item) {



        $scope.EntityObj = {};
        var company_id = getCookie('company_id');
        var data = {
            product_id: item.product_id,
            company_id: company_id
        };
        var response = simsService.getProductSecondary(data);
        response.then(function (item) {



            if (item.data[0] == null)
            {

                swal({
                    html: true,
                    title: "Product or Price Not Found",
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
            // $scope.EntityObj.unit_discountamount = item.data[0].discount_amount_primary;
            $scope.EntityObj.discount_amount = item.data[0].discount_amount;
            $scope.EntityObj.discount_percent = item.data[0].discount_percent;
            $("#unit_cost").val(item.data[0].product_price);
            $("#currentDiscount").val(item.data[0].discount_amount ? item.data[0].discount_amount : 0);
            $("#netUnitPrice").val($scope.EntityObj.netunit_price);
            $("#stock").val(item.data[0].stock);
        }, function (error) {
            toastr.error(error.data);
        });
    })







}


angular.module('myApps')
        .controller('SecondaryController', SecondaryController);