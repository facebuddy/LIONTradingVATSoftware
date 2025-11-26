'use strict';
var MenuController = function ($scope, $filter, $log, kgchrmService) {
    $scope.title = "Working Menu";
    $scope.menuData = [];
    $scope.menu = [];









    $scope.menuexpand = function (element) {

        element.show = true;

    };












    $scope.geMenuList = function () {


       // var currentRoleId = parseInt(getCookie('role_id'));


        //   $('#currentRoleId').val();
        var currentRoleId = 1;

        var response = kgchrmService.getMenu(currentRoleId);
        response.then(function (list) {

            $scope.menuData = list.data;




            angular.forEach($scope.menuData, function (value, key) {
                if (value.parent_id == 0) {
                    $scope.menu.push(value);
                }
            });

            angular.forEach($scope.menuData, function (value, key) {
                if (value.id != 0) {
                    angular.forEach($scope.menu, function (value2, key2) {
                        if (value.parent_id == value2.id) {
                            if (value2.children == undefined) {
                                value2.children = [];
                                value2.showChildren = false;
                            }
                            value2.children.push(value);
                        }
                    });
                }
            });



             includeJs("../assets/js/app.js");




           // console.log("Menu info:" + JSON.stringify($scope.menu));


        }, function () {
            alert('Error in getting records');
        });
    }
  




    $scope.init = function () {

        var data = {
            user_id: $('#userId').val(),
            role_id: $('#roleId').val()
        };

        $('#currentUserId').val($('#userId').val());
        $('#currentRoleId').val($('#roleId').val());
        var roleId = $('#roleId').val();
        var userId = $('#userId').val();
        var companyId = $('#company_id').val();
        if (roleId != undefined) {

            setCookie('role_id', roleId, 100);
            setCookie('user_id', userId, 100);
            setCookie('company_id', companyId, 100);

            //  sessionStorage.setItem("role_id", $('#roleId').val());
        }


         $scope.geMenuList();





        var response = simsService.setSessionData(data);
        response.then(function (list) {

            $scope.geMenuList();


        }, function (error) {
            toastr.error(error.data);
        });


    }






}


angular.module('myApps')
        .controller('MenuController', MenuController);