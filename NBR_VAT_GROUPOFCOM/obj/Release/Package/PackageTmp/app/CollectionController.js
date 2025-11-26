'use strict';
var CollectionController = function ($scope, $filter, $log, simsService) {
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
    $scope.particularList1 = [];
    $scope.productObj = {};
    $scope.totalPcs = 0;
    $scope.totalCtn = 0;
    $scope.totalCost = 0;
    $scope.supplierList = [];
    $scope.bankList = [];
    $scope.netAmount = 0;
    $scope.discountAmount = 0;
    $scope.priceList = [];
    $scope.productListTemp = [];
    $scope.EntityObj = {};
    $scope.purchaseList = [];
    $scope.particularList = [];
    $scope.particularListVat = [];
    $scope.particularListvat1 = [];
    $scope.Entity = {};
    $scope.totalDebit = 0;
    $scope.totalAmount = 0;
    $scope.totalCredit = 0;
    $scope.subbrands = [];
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




    $scope.getComponentsList = function () {

        var response = simsService.getComponents();
        response.then(function (list) {

            $scope.componetList = list.data;
            $scope.currentPage = 1;

            $scope.totalItems = $scope.componetList.length;
            $scope.componetListflt = $scope.componetList;
            //   $scope.componetListDis = $filter('filter')($scope.componetList, {component_group_id: PRODUCT_GROUP_ID});


            //   $scope.groups = $filter('filter')($scope.componetList, {component_group_id: 1});

            //  $scope.categories = $filter('filter')($scope.componetList, {component_group_id: 4});
            //   $scope.brands = $filter('filter')($scope.componetList, {component_group_id: 2});
            //  $scope.subgroups = $filter('filter')($scope.componetList, {component_group_id: 3});
            //  $scope.packages = $filter('filter')($scope.componetList, {component_group_id: 5});
            //   $scope.sizes = $filter('filter')($scope.componetList, {component_group_id: 6});
            $scope.subbrands = $filter('filter')($scope.componetList, {component_group_id: 7});
            //   $scope.variants = $filter('filter')($scope.componetList, {component_group_id: 8});


        }, function (error) {
            toastr.error(error.data);
        });
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

        $scope.particularList = $filter('filter')($scope.particularList, function (item) {
            return !(item.id == id);
        });
        $scope.totalDebit = 0;
        $scope.totalCredit = 0;
        $scope.particularList.forEach(function (item) {


            $scope.totalDebit += parseFloat(item['debit']);
            $scope.totalCredit += parseInt(item['credit']);



        });


        /*  $scope.totalPcs = 0;
         $scope.totalCtn = 0;
         $scope.totalCost = 0;
         $scope.discountAmount = 0;
         $scope.netAmount = 0;
         $scope.purchaseList.forEach(function (item) {
         
         $scope.totalPcs += parseInt(item['unit_pcs']);
         $scope.totalCtn += parseFloat(item['unit_ctn']);
         $scope.totalCost += parseInt(item['total_amount']);
         $scope.discountAmount += parseFloat(item['discount_amount']);
         $scope.netAmount += parseInt(item['net_amount']);
         
         
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
         */


    }





    $scope.removeVatParticualr = function (id) {

        $scope.particularListVat = $filter('filter')($scope.particularListVat, function (item) {
            return !(item.id == id);
        });
        $scope.totalAmount = 0;

        $scope.particularListVat.forEach(function (item) {


            $scope.totalAmount += parseFloat(item['amount']);




        });






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


    $scope.getParticulars = function (Entity) {

        simsService.getParticulars(Entity)
                .then(function (list) {

                    $scope.particularList1 = list.data;

                }, function (error) {
                    toastr.error(error);

                });
    }

    $scope.getParticularsvat = function (Entity) {

        simsService.getParticularsvat(Entity)
                .then(function (list) {

                    $scope.particularListvat1 = list.data;
                    console.log("vat collection" + $scope.particularListvat1);

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

    $scope.productAddtoCartVat = function (Entity) {




        Entity.particular_name = $("#particular_name option:selected").text().trim();



        if (Object.keys(Entity).length === 0 || Entity.amount == "" || typeof Entity.amount === 'undefined')
        {


            toastr.error("Empty product!");
            $('#particularQry .typeahead').typeahead('val', '');
            //$('#reference').val("");
            $('#remarks').val("");
            $('#amount').val("");

            return;
        }

        var dataObj = {};

        var userdate = $("#users_entry_date").val();



        if (Entity.particular_name == "Opening")
        {
            dataObj.id = Entity.particular_id;
            dataObj.particular_id = Entity.particular_id;
            dataObj.reference = Entity.reference;
            dataObj.users_entry_date = userdate;

            dataObj.particulars = Entity.particular_name;
            dataObj.particular_name = Entity.particular_name;
            dataObj.remarks = Entity.remarks;
            // dataObj.particular_id = Entity.id;
            dataObj.company_id = getCookie('company_id');
            dataObj.opening = Entity.amount;
            dataObj.entryuser_id = getCookie('user_id');

            dataObj.treasury = 0;
            dataObj.reyat = 0;
            dataObj.adjustment = 0;
            dataObj.payable = 0;
            dataObj.amount = Entity.amount;
        }

        if (Entity.particular_name == "Treasury")
        {
            dataObj.id = Entity.particular_id;
            dataObj.particular_id = Entity.particular_id;
            dataObj.particular_name = Entity.particular_name;
            dataObj.particulars = Entity.particular_name;
            dataObj.remarks = Entity.remarks;
            dataObj.reference = Entity.reference;
            //dataObj.particular_id = Entity.id;
            dataObj.users_entry_date = userdate;
            dataObj.opening = 0;
            dataObj.company_id = getCookie('company_id');
            dataObj.entryuser_id = getCookie('user_id');

            dataObj.treasury = Entity.amount;
            dataObj.reyat = 0;
            dataObj.adjustment = 0;
            dataObj.payable = 0;
            dataObj.amount = Entity.amount;
        }


        if (Entity.particular_name == "Rebate(Local)")
        {
            dataObj.id = Entity.particular_id;
            dataObj.particular_id = Entity.particular_id;
            dataObj.particular_name = Entity.particular_name;
            dataObj.particulars = Entity.particular_name;
            dataObj.remarks = Entity.remarks;
            // dataObj.particular_id = Entity.id;
            dataObj.users_entry_date = userdate;
            dataObj.reference = Entity.reference;
            dataObj.opening = 0;
            dataObj.entryuser_id = getCookie('user_id');
            dataObj.company_id = getCookie('company_id');

            dataObj.treasury = 0;
            dataObj.reyat = Entity.amount;
            dataObj.adjustment = 0;
            dataObj.payable = 0;
            dataObj.amount = Entity.amount;
        }


        if (Entity.particular_name == "Rebate(Import)")
        {
            dataObj.id = Entity.particular_id;
            dataObj.particular_id = Entity.particular_id;
            dataObj.particular_name = Entity.particular_name;
            dataObj.particulars = Entity.particular_name;
            dataObj.remarks = Entity.remarks;
            // dataObj.particular_id = Entity.id;
            dataObj.users_entry_date = userdate;
            dataObj.reference = Entity.reference;
            dataObj.opening = 0;
            dataObj.company_id = getCookie('company_id');
            dataObj.entryuser_id = getCookie('user_id');

            dataObj.treasury = 0;
            dataObj.reyat = Entity.amount;
            dataObj.adjustment = 0;
            dataObj.payable = 0;
            dataObj.amount = Entity.amount;
        }

        if (Entity.particular_name == "Adjustment(Rebate)")
        {
            dataObj.id = Entity.particular_id;
            dataObj.particular_id = Entity.particular_id;
            dataObj.particular_name = Entity.particular_name;
            dataObj.particulars = Entity.particular_name;
            dataObj.remarks = Entity.remarks;
            // dataObj.particular_id = Entity.id;
            dataObj.users_entry_date = userdate;
            dataObj.opening = 0;
            dataObj.entryuser_id = getCookie('user_id');
            dataObj.company_id = getCookie('company_id');
            dataObj.reference = Entity.reference;

            dataObj.treasury = 0;
            dataObj.reyat = 0;
            dataObj.adjustment = Entity.amount;
            dataObj.payable = 0;
            dataObj.amount = Entity.amount;
        }

        if (Entity.particular_name == "Adjustment Payable")
        {
            dataObj.id = Entity.particular_id;
            dataObj.particular_id = Entity.particular_id;
            dataObj.particular_name = Entity.particular_name;
            dataObj.particulars = Entity.particular_name;
            dataObj.remarks = Entity.remarks;
            // dataObj.particular_id = Entity.id;
            dataObj.users_entry_date = userdate;
            dataObj.opening = 0;
            dataObj.entryuser_id = getCookie('user_id');
            dataObj.company_id = getCookie('company_id');
            dataObj.reference = "";
            dataObj.treasury = 0;
            dataObj.reyat = 0;
            dataObj.adjustment = Entity.amount;
            dataObj.reference = Entity.reference;
            dataObj.payable = 0;
            dataObj.amount = Entity.amount;
        }



        $scope.particularListVat.push(dataObj);
        console.log("Vat list" + JSON.stringify($scope.particularListVat));

        $scope.EntityObj = {};
        $('#particularVatQry .typeahead').typeahead('val', '');
        // $('#reference').val("");
        $('#remarks').val("");
        $('#amount').val("");
        $("#users_entry_date").val("");

        $scope.totalAmount = 0;

        $scope.particularListVat.forEach(function (item) {


            $scope.totalAmount += parseFloat(item['amount']);




        });
    }






    $scope.productAddtoCartClaim = function (Entity) {

        if (Object.keys(Entity).length === 0 || Entity.amount == "" || typeof Entity.amount === 'undefined')
        {


            toastr.error("Empty product!");
            //   $('#particularQry .typeahead').typeahead('val', '');
            $('#reference').val("");
            $('#remarks').val("");
            $('#amount').val("");

            return;
        }


        if (typeof Entity.subbrand_id == "undefined")
        {
            swal({
                html: true,
                title: "Please Select Brand!",
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

        if (typeof Entity.particular_id == "undefined")
        {
            swal({
                html: true,
                title: "Please Select Particulars!",
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


        Entity.particular_name = $("#particular_name option:selected").text();
        Entity.brand_name = $("#subbrand_id option:selected").text();

        if (Entity.type == "debit")
        {
            Entity.debit = Entity.amount;
            Entity.credit = 0;
        } else
        {
            if (Entity.isDebit == true)
            {
                Entity.debit = Entity.amount;
                Entity.credit = 0;

            } else
            {
                Entity.debit = 0;
                Entity.credit = Entity.amount;
            }
        }



        $scope.particularList.push(Entity);
        console.log("particualr varify: " + JSON.stringify($scope.particularList));
        $scope.EntityObj = {};
        $('#distributorQry .typeahead').typeahead('val', '');
        $('#reference').val("");
        $('#remarks').val("");
        $('#amount').val("");
        $('#address').text("");
        $scope.totalDebit = 0;
        $scope.totalCredit = 0;
        $scope.particularList.forEach(function (item) {


            $scope.totalDebit += parseFloat(item['debit']);
            $scope.totalCredit += parseInt(item['credit']);



        });








        /*  if (Object.keys(Entity).length === 0 || Entity.unit_cost == "" || typeof Entity.unit_cost === 'undefined' || Entity.unit_pcs == "" || typeof Entity.unit_pcs === 'undefined' )
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
         $scope.totalCost += parseInt(item['total_amount']);
         $scope.netAmount += parseInt(item['net_amount']);
         
         
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
         
         */



        // $("#product_text").val("");
        //$("#product_text").text("");
    }


    $scope.productAddtoCart = function (Entity) {

        if (Object.keys(Entity).length === 0 || Entity.amount == "" || typeof Entity.amount === 'undefined')
        {


            toastr.error("Empty product!");
            //   $('#particularQry .typeahead').typeahead('val', '');
            $('#reference').val("");
            $('#remarks').val("");
            $('#amount').val("");

            return;
        }
        Entity.cheque_date = $("#chequeDate").val();
        //  Entity.bankname = $("#bank_id option:selected").text();

        Entity.particular_name = $("#particular_name option:selected").text();
        Entity.customer_bank_name = $("#customer_bank_id option:selected").text();
        if (Entity.type == "debit")
        {
            if (typeof (Entity.remarks) != "undefined")
            {
                Entity.remarks = Entity.remarks;
            }
            if (typeof (Entity.remarks) == "undefined")
            {
                Entity.remarks = '';
            }

            if (typeof (Entity.bank_name) != "undefined")
            {
                Entity.remarks = Entity.remarks;
            }
            if (chequeDate != "")
            {
                Entity.remarks += ', ' + chequeDate;
            }

            // Entity.remarks = Entity.remarks + ', ' + Entity.bank_name + ', ' + chequeDate;
            Entity.debit = Entity.amount;
            Entity.credit = 0;
        } else
        {
            if (Entity.isDebit == true)
            {
                if (typeof (Entity.remarks) != "undefined")
                {
                    Entity.remarks = Entity.remarks;
                }
                if (typeof (Entity.remarks) == "undefined")
                {
                    Entity.remarks = '';
                }

                if (typeof (Entity.bank_name) != "undefined")
                {
                    Entity.remarks = Entity.remarks;
                }
                /* if (chequeDate != "")
                 {
                 Entity.remarks += ', ' + chequeDate;
                 }*/

                // Entity.remarks = Entity.remarks + ', ' + Entity.bank_name + ', ' + chequeDate;
                Entity.debit = Entity.amount;
                Entity.credit = 0;

            } else
            {
                if (typeof (Entity.remarks) != "undefined")
                {
                    Entity.remarks = Entity.remarks;
                }
                if (typeof (Entity.remarks) == "undefined")
                {
                    Entity.remarks = '';
                }

                if (typeof (Entity.bank_name) != "undefined")
                {
                    Entity.remarks = Entity.remarks;
                }
                /*  if (chequeDate != "")
                 {
                 Entity.remarks += ', ' + chequeDate;
                 }*/

                // Entity.remarks = Entity.remarks + ', ' + Entity.bank_name + ', ' + chequeDate;
                Entity.debit = 0;
                Entity.credit = Entity.amount;
            }
        }



        $scope.particularList.push(Entity);
        $("#chequeDate").val("");
        console.log("particualr varify: " + JSON.stringify($scope.particularList));
        $scope.EntityObj = {};
        //  $('#distributorQry .typeahead').typeahead('val', '');
        $('#reference').val("");
        $('#remarks').val("");
        $('#amount').val("");
        $('#address').text("");
        $scope.totalDebit = 0;
        $scope.totalCredit = 0;
        $scope.particularList.forEach(function (item) {


            $scope.totalDebit += parseFloat(item['debit']);
            $scope.totalCredit += parseInt(item['credit']);



        });








        /*  if (Object.keys(Entity).length === 0 || Entity.unit_cost == "" || typeof Entity.unit_cost === 'undefined' || Entity.unit_pcs == "" || typeof Entity.unit_pcs === 'undefined' )
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
         $scope.totalCost += parseInt(item['total_amount']);
         $scope.netAmount += parseInt(item['net_amount']);
         
         
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
         
         */



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


    $scope.getBanks = function () {

        var response = simsService.getBanks();
        response.then(function (list) {

            $scope.bankList = list.data;
            console.log("Componet Group:" + JSON.stringify($scope.bankList));

        }, function () {
            alert('Error in getting records');
        });
    }


    $scope.getBanks();

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


    $scope.saveParticulars = function (Entity) {
        // Entity.challan_date
        $scope.pg = true;


        if (typeof Entity.bank_id == "undefined")
        {
            swal({
                html: true,
                title: "Please Select Bank!",
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


        if (Entity.distributor_id == 0 || Object.keys(Entity).length === 0 || (typeof $scope.particularList == "undefined" || $scope.particularList.length <= 0))
        {



            if ((typeof $scope.particularList == "undefined" || $scope.particularList.length <= 0))
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

        } else {




            var date1 = $("#challanDate").val();
            Entity.particularList = $scope.particularList;

            Entity.challan_date = date1;
            Entity.distributor_id = $scope.Entity.distributor_id;
            Entity.company_id = getCookie('company_id');
            Entity.user_id = getCookie('user_id');
            console.log("Particualrs gg0" + Entity);


            var response = simsService.saveParticulars(Entity);
            response.then(function (list) {
                //toastr.success(list.data);

                $scope.pg = false;
                $scope.Entity.tracking_no = list.data;
                swal({
                    html: true,
                    title: "Successfully Saved!",
                    text: "",
                    type: "success",
                    timer: 2000,
                    confirmButtonText: "Close",
                    // html: "<h1>Hello Everyone</h1>"
                    showConfirmButton: true
                });

                $scope.particularList = [];
                Entity = {};
                $('#distributorQry .typeahead').typeahead('val', '');
                $scope.totalPcs = 0;
                $scope.totalCtn = 0;
                $scope.totalCost = 0;
                $scope.netAmount = 0;
                $scope.discountAmount = 0;
                $scope.Entity.distributor_id = 0;
                $("#credit_limit").val("");
                console.log("Result Data" + JSON.stringify(list.data));
            }, function (error) {
                $scope.pg = false;
                toastr.error(error.data);
            });
            console.log("Indent Data" + JSON.stringify(Entity));





            $scope.pg = false;

        }




    }


    $scope.saveParticularsClaim = function (Entity) {
        // Entity.challan_date
        $scope.pg = true;


        /* if (typeof Entity.brand_id == "undefined")
         {
         swal({
         html: true,
         title: "Please Select Brand!",
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
         */

        if (Object.keys(Entity).length === 0 || (typeof $scope.particularList == "undefined" || $scope.particularList.length <= 0))
        {



            if ((typeof $scope.particularList == "undefined" || $scope.particularList.length <= 0))
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



            $scope.pg = false;
            return;

        } else {




            var date1 = $("#challanDate").val();
            Entity.particularList = $scope.particularList;

            Entity.challan_date = date1;
            Entity.distributor_id = $scope.Entity.distributor_id;
            Entity.company_id = getCookie('company_id');
            Entity.user_id = getCookie('user_id');
            console.log("Particualrs gg0" + Entity);


            var response = simsService.saveParticularsClaim(Entity);
            response.then(function (list) {
                //toastr.success(list.data);

                $scope.pg = false;
                $scope.Entity.tracking_no = list.data;
                swal({
                    html: true,
                    title: "Successfully Saved!",
                    text: "",
                    type: "success",
                    timer: 2000,
                    confirmButtonText: "Close",
                    // html: "<h1>Hello Everyone</h1>"
                    showConfirmButton: true
                });

                $scope.particularList = [];
                Entity = {};
                $('#distributorQry .typeahead').typeahead('val', '');
                $scope.totalPcs = 0;
                $scope.totalCtn = 0;
                $scope.totalCost = 0;
                $scope.netAmount = 0;
                $scope.discountAmount = 0;
                $scope.Entity.distributor_id = 0;
                $("#credit_limit").val("");
                console.log("Result Data" + JSON.stringify(list.data));
            }, function (error) {
                $scope.pg = false;
                toastr.error(error.data);
            });
            console.log("Indent Data" + JSON.stringify(Entity));





            $scope.pg = false;

        }




    }





    $scope.saveParticularsVat = function (Entity) {
        // Entity.challan_date
        $scope.pg = true;

        if ((typeof $scope.particularListVat == "undefined" || $scope.particularListVat.length <= 0))
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

        } else {




            var date1 = $("#challanDate").val();
            Entity.particularListVat = $scope.particularListVat;

            Entity.challan_date = date1;

            // Entity.company_id = getCookie('company_id');
            Entity.user_id = getCookie('user_id');

            var response = simsService.saveParticularsvat(Entity);
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

                $scope.particularListVat = [];
                Entity = {};
                //  $('#distributorQry .typeahead').typeahead('val', '');
                $scope.totalPcs = 0;
                $scope.totalCtn = 0;
                $scope.totalCost = 0;
                $scope.netAmount = 0;
                $scope.discountAmount = 0;
                $scope.Entity.distributor_id = 0;
                console.log("Result Data Teasurry" + JSON.stringify(list.data));
            }, function (error) {
                $scope.pg = false;
                toastr.error(error.data);
            });
            console.log("Indent Data" + JSON.stringify(Entity));





            $scope.pg = false;

        }




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
        Entity.unit_ctn = (Entity.unit_pcs / unitPcs).toFixed(2);
        Entity.total_amount = (unitCost * unitQuty).toFixed(2);


    };


    $scope.quantityChange = function (Entity)
    {
        var unitCost = parseFloat(Entity.unit_cost);
        var netUnitPrice = parseFloat(Entity.netunit_price);
        var unitQuty = parseInt(Entity.unit_pcs);
        var discount = parseFloat(Entity.discount_amount * Entity.unit_pcs);


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
        Entity.total_amount = unitCost * unitQuty;
        Entity.net_amount = netUnitPrice * unitQuty;
        Entity.discount_amount = discount;


    };

    $scope.getParticulars();
    $scope.getComponentsList();
    $scope.getParticularsvat();
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



        var baseUrl = 'http://sims.timezoneservice.com/get-particulars';
        var baseUrlFindSupplier = 'http://sims.timezoneservice.com/api/getdistributorpoint-typeahend';
        var baseUrlVat = 'http://sims.timezoneservice.com/get-particulars-vat';
        // var baseUrl = 'http://127.0.0.1:8000/get-particulars';
        // var baseUrlFindSupplier = 'http://127.0.0.1:8000/api/getdistributorpoint-typeahend';
        // var baseUrlVat = 'http://127.0.0.1:8000/get-particulars-vat';
        // var baseUrlFindSupplier = 'http://127.0.0.1:8000/api/getdistributorpoint-typeahend';
        //  var baseUrl = 'http://sims.timezoneservice.com/get-particulars';
        // var baseUrlVat = 'http://sims.timezoneservice.com/get-particulars-vat';

        // var baseUrlFindSupplier = 'http://127.0.0.1:8000/api/getdistributorpoint-typeahend';

        //  var baseUrlFindSupplier = 'http://sims.timezoneservice.com/api/getdistributorpoint-typeahend';

        $(document).ready(function () {
            var findProductQuery = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,

                remote: {
                    url: baseUrl + '/%QUERY ',
                    wildcard: '%QUERY'
                }
            });

            var findProductQueryVat = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,

                remote: {
                    url: baseUrlVat + '/%QUERY ',
                    wildcard: '%QUERY'
                }
            });

            $('#particularQry .typeahead').typeahead(null, {
                name: 'particular_name',
                display: 'particular_name',
                source: findProductQuery
            });


            $('#particularVatQry .typeahead').typeahead(null, {
                name: 'particular_name',
                display: 'particular_name',
                source: findProductQueryVat
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

    }
    $('#distributorQry .typeahead').on('typeahead:selected', function (evt, item) {

        // $scope.Entity.distributor_id = item.id;
        $scope.EntityObj.distributor_id = item.id;
        $scope.Entity.distributor_id = item.id;
        $scope.EntityObj.distributor_name = item.name;
        $scope.Entity.pricetype_id = item.price_id;
        $('#credit_limit').val(item.credit_limit);
        $scope.Entity.address = item.address;
        $('#addressn').val(item.address);
        // $('#credit_balance').val(item.credit_balance);
        $('#addressn').text(item.address);



    });

    $('#particularQry .typeahead').on('typeahead:selected', function (evt, item) {

        $scope.EntityObj = {};
        $scope.EntityObj.type = item.type;
        $scope.EntityObj.id = item.id;
        $scope.EntityObj.particular_name = item.particular_name;
        $('#reference').val("");
        $('#remarks').val("");
        $('#amount').val("");


    });


    $('#particularVatQry .typeahead').on('typeahead:selected', function (evt, item) {

        $scope.EntityObj = {};
        $scope.EntityObj.type = item.type;
        $scope.EntityObj.id = item.id;
        $scope.EntityObj.particular_name = item.particular_name;
        // $('#reference').val("");
        $('#remarks').val("");
        $('#amount').val("");


    });


    /*  $('#distributorQry .typeahead').on('typeahead:selected', function (evt, item) {
     
     $scope.Entity.distributor_id = item.id;
     $("#distributor_id").val(item.id);
     
     
     }) */



}


angular.module('myApps')
        .controller('CollectionController', CollectionController);