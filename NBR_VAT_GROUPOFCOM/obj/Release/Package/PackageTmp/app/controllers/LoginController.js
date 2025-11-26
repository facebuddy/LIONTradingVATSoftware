'use strict';
var LoginController = function ($scope, $filter, $log, kgchrmService) {
   
    $scope.companyList = [];

   


  


    $scope.getCompanyList = function () {
        $scope.pg = true;

        kgchrmService.getCompanyList()
            .then(function (lst) {

                $scope.companyList = lst.data;
                var datan = JSON.stringify("Company List:" + JSON.stringify($scope.companyList));
                console.log(datan);
                $scope.pg = false;

            });
    }



        

    $scope.getCompanyList();
  



}


angular.module('myApps')
        .controller('LoginController', LoginController);