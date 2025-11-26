'use strict';
var ProductController = function ($scope, $filter, $window, $log, simsService) {

    const PRODUCT_GROUP_ID = 1;
    $scope.title = "Product Component";
    var baseUrl = "http://cr.time-zone.biz/"
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


    $scope.groups = [];
    $scope.categories = [];
    $scope.brands = [];
    $scope.subgroups = [];
    $scope.sizes = [];
    $scope.subbrands = [];
    $scope.variants = [];


    $scope.componentListTemp = [];
    $scope.productObj = null;
    $scope.showMsgsCompoent = false;
    $scope.Entity = {};
    // $scope.Entity.priceListTemp=[];
    //$scope.Entity.componentListTemp=[];
    $scope.priceListTemp = [];
    $scope.productList = [];
    $scope.productListDis = [];
    $scope.showMsgs = false;
    $scope.productObjListDis = [];


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


    $scope.addProductComponent = function (cid, gid) {

        if (cid != undefined)
        {
            var id = $scope.Entity.component_group_id;
            $scope.EntityObj = $filter('filter')($scope.componetList, function (d) {
                return d.component_id == cid;
            })[0];

            const getComponent = $scope.componentListTemp.find(component => component.component_group_id == gid);

            if (getComponent === undefined)
            {
                $scope.componentListTemp.push($scope.EntityObj);
                $scope.Entity.componentListTemp = $scope.componentListTemp;
            } else
            {
                toastr.error('Already exist this component');
            }
        } else {
            toastr.error('blank item!');
        }


    }





    $scope.priceList = function () {

        return $window.open(baseUrl + "PriceList.aspx", '_blank', 'height=700,width=1000');
    };





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

    $scope.removeComponentUpd = function (id) {

        $scope.Entity.componentListTemp = $filter('filter')($scope.Entity.componentListTemp, function (item) {
            return !(item.component_id == id);
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


        if ($scope.groupForm.$valid)
        {

            simsService.saveComponentGroup(Entity)
                    .then(function (msg) {
                        $scope.Entity = {};
                        toastr.success(msg.data);
                        $scope.getComponentGroups();
                        $scope.getComponents();
                        // Entity = {};

                    }, function (error) {
                        toastr.error(error);

                    });

        } else {
            $scope.showMsgs = true;
            return;
        }


    }

    $scope.groupChange = function (Entity) {
        $scope.componetListDD = null;
        $scope.componetListDD = $filter('filter')($scope.componetList, {component_group_id: Entity});
    }



    $scope.saveComponent = function (Entity) {

        $scope.pg = true;
        if ($scope.componentForm.$valid)
        {


            simsService.saveComponent(Entity)
                    .then(function (msg) {
                        $scope.Entity = {};
                        $scope.getComponents();

                        toastr.success("Component List" + msg.data);
                        $scope.showMsgsCompoent = false;
                        $scope.pg = false;
                        // $scope.getComponentGroups();

                    }, function (error) {
                        toastr.error(error);

                    });

        } else {
            $scope.showMsgsCompoent = true;
            $scope.pg = false;
            return;
        }






    }

    $scope.saveProduct = function (Entity) {
        console.log("Product Post data" + Entity);


        if ($scope.myform.$valid)
        {

            simsService.saveProduct(Entity)
                    .then(function (msg) {
                        console.log("data" + JSON.stringify(msg.data));
                        //  alert(JSON.stringify(msg.data));

                        toastr.success(msg.data);
                        $scope.Entity = {};
                        $scope.componentListTemp = [];
                        $scope.priceListTemp = [];
                        // $scope.getComponentGroups();

                    }, function (error) {
                        toastr.error(error);

                    });

        } else {

            $scope.showMsgs = true;
        }
        return;

    }


    $scope.updateProduct = function (Entity) {

        console.log("Product Post data" + JSON.stringify(Entity));

        simsService.updateProduct(Entity)
                .then(function (msg) {
                    console.log("data" + JSON.stringify(msg.data));
                    // alert(JSON.stringify(msg.data));

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
    }


    $scope.updateComponent = function (Entity) {
        $scope.pg = true;

        simsService.updateComponent(Entity)
                .then(function (msg) {




                    toastr.success(msg.data);
                    // $scope.getComponentGroups();
                    $scope.getComponents();
                    $scope.pg = false;
                    // alert(JSON.stringify(msg.data));

                }, function (error) {
                    toastr.error(error);
                    $scope.pg = false;

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


            if ($scope.Entity.is_indent_off == 1) {
                $scope.Entity.is_indent_off = true;
            } else {
                $scope.Entity.is_indent_off = false;

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




    $scope.productSearchingByScheme = function (Entity) {



        var response = simsService.productSearchingByScheme(Entity);
        response.then(function (list) {

            $scope.productListDis = list.data;
            console.log($scope.productListDis);


            // console.log("Product Object" + JSON.stringify($scope.productObj));
        }, function (error) {
            toastr.error(error.data);
        });
    }





    $scope.saveDiscount = function (Entity) {

        var data = {
            name: "Discount",
            discountList: Entity
        };
        var response = simsService.saveProductDiscounts(data);
        response.then(function (list) {


            toastr.success(list.data);

            console.log("Product Object" + JSON.stringify($scope.productObj));
        }, function (error) {
            toastr.error(error.data);
        });


        // alert("ok");
        console.log("DiscountArray" + Entity);
        console.log("DiscountArray" + JSON.stringify(Entity));


    };




    $scope.saveProductDiscountsSecondary = function (Entity) {

        var data = {
            name: "Discount",
            discountList: Entity
        };
        var response = simsService.saveProductDiscountsSecondary(data);
        response.then(function (list) {


            toastr.success(list.data);

            console.log("Product Object" + JSON.stringify($scope.productObj));
        }, function (error) {
            toastr.error(error.data);
        });


        // alert("ok");
        console.log("DiscountArray" + Entity);
        console.log("DiscountArray" + JSON.stringify(Entity));


    };












    $scope.changeAmount = function (Entity) {


        var unitCost = parseFloat(Entity.discount_tp_amount);
        var unitQuty = parseFloat(Entity.discount_amount);

        Entity.sum_amount = unitCost + unitQuty;



    };

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

    $scope.changeDiscountAmountInd = function (Entity) {
        Entity.discount_amount = Entity.discount_amount;

        Entity.discount_percent = ((Entity.discount_amount / Entity.product_price) * 100).toFixed(2);
        // $scope.IsAllChecked = true;



    };


    $scope.changeDiscountPrctInd = function (Entity) {
        Entity.discount_percent = Entity.discount_percent;

        Entity.discount_amount = ((Entity.discount_percent / 100) * Entity.product_price).toFixed(2);
        // $scope.IsAllChecked = true;



    };











    $scope.AllDiscountChangeSecondary = function (Entity) {
        // $scope.IsAllChecked = true;

        for (var i = 0; i < $scope.productListDis.length; i++) {

            $scope.productListDis[i].discount_amount = parseFloat(Entity);

            if ($scope.productListDis[i].product_price != "0.00")
            {
                $scope.productListDis[i].discount_percent = (($scope.productListDis[i].discount_amount / $scope.productListDis[i].product_price) * 100).toFixed(2);
            } else
            {
                $scope.productListDis[i].discount_percent = 0;
            }


        }





    };



    $scope.AllDiscountChangeSecondaryPrct = function (Entity) {
        // $scope.IsAllChecked = true;

        for (var i = 0; i < $scope.productListDis.length; i++) {

            $scope.productListDis[i].discount_percent = parseFloat(Entity);

            if ($scope.productListDis[i].product_price != "0.00")
            {
                $scope.productListDis[i].discount_amount = (($scope.productListDis[i].discount_percent / 100) * $scope.productListDis[i].product_price).toFixed(2);
            } else
            {
                $scope.productListDis[i].discount_amount = 0;
            }


        }





    };













    $scope.init = function () {


        // var baseUrl = 'http://127.0.0.1:8000/api/findProductQuery';
        var baseUrl = 'http://sims.timezoneservice.com/api/findProductQuery';
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
        var data = {
            product_id: item.product_id
        };

        var response = simsService.getDiscountById(data);
        response.then(function (list) {

            $scope.productObjListDis = list.data;

            // console.log("Product Object" + JSON.stringify($scope.productObj));
        }, function (error) {
            toastr.error(error.data);
        });


        $("#currentProductId").val(item.product_id);
        $("#productCurrentUnitPcs").val(item.pics_qty);
        $("#productName").val(item.name);
        $("#currentBarcode").val(item.barcode);






    })







    $scope.getUnitTypes();
    $scope.getComponentGroups();
    $scope.getComponents();
    $scope.getPrices();
    $scope.getPoducts();
    //$scope.getGroupList();

}


angular.module('myApps')
        .controller('ProductController', ProductController);