'use strict';
var PriceController = function($scope, $filter, $log, simsService) {

    $scope.roles = [];
    $scope.priceTypes = [];
    $scope.permissons = [];
    $scope.componetList = [];

    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;
    $scope.data = [
        { "name": "John", "location": "Boston" },
        { "name": "Dave", "location": "Lancaster" }
    ];

    $scope.title = "Price Type";
    $scope.DisplayModal = function(mode, title, id) {
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

            $scope.Entity = $filter('filter')($scope.priceTypes, function(d) { return d.id === id; })[0];
            if ($scope.Entity.status == 1) {
                $scope.Entity.status = true;
            } else {
                $scope.Entity.status = false;

            }


        }
    }








    $scope.savePrice = function(Entity) {

        simsService.savePriceType(Entity)
            .then(function(msg) {
                //alert(JSON.stringify(msg.data));
                toastr.success(msg.data);

                $scope.getPrices();



            }, function(error) {
                toastr.error(error);
                // $scope.pg = false;
            });
    }

    $scope.updatePrice = function(Entity) {

        simsService.updatePrice(Entity)
            .then(function(msg) {

                toastr.success(msg.data);

                $scope.getPrices();



            }, function(error) {
                toastr.error(error);
                // $scope.pg = false;
            });
    }

    $scope.getPrices = function() {

        var response = simsService.getPriceTypes();
        response.then(function(list) {

            $scope.priceTypes = list.data;


            console.log("Price Type:" + JSON.stringify($scope.priceTypes));


        }, function(error) {
            toastr.error(error.data);
        });
    }


    $scope.getPrices();


}


angular.module('myApps')
    .controller('PriceController', PriceController);