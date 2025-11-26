'use strict';
var UnitTypeController = function($scope, $filter, $log, simsService) {


    $scope.unitTypes = [];

    $scope.permissons = [];
    $scope.componetList = [];

    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;


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

            $scope.Entity = $filter('filter')($scope.unitTypes, function(d) { return d.id === id; })[0];
            if ($scope.Entity.status == 1) {
                $scope.Entity.status = true;
            } else {
                $scope.Entity.status = false;

            }


        }
    }








    $scope.saveUnitType = function(Entity) {

        simsService.saveUnitType(Entity)
            .then(function(msg) {

                toastr.success(msg.data);

                $scope.getUnitTypes();



            }, function(error) {
                toastr.error(error);
                // $scope.pg = false;
            });
    }

    $scope.updateUnitType = function(Entity) {

        simsService.updateUnitType(Entity)
            .then(function(msg) {

                toastr.success(msg.data);

                $scope.getUnitTypes();



            }, function(error) {
                toastr.error(error);
                // $scope.pg = false;
            });
    }



    $scope.getUnitTypes = function() {

        var response = simsService.getUnitTypes();
        response.then(function(list) {

            $scope.unitTypes = list.data;

            console.log("Unit types" + JSON.stringify($scope.unitTypes));
        }, function(error) {
            toastr.error(error.data);
        });
    }



    $scope.getUnitTypes();


}


angular.module('myApps')
    .controller('UnitTypeController', UnitTypeController);