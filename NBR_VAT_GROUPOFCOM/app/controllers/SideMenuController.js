'use strict';
var SideMenuController = function ($scope, $filter, $log, kgchrmService) {

    $scope.roles = [];
    $scope.permissons = [];
    $scope.componetList = [];
    $scope.rolesSecondary = [];
    $scope.designations = [];
    $scope.departments = [];
    $scope.userLevels = [];
    $scope.companies = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;
    $scope.notificationList=[];
    $scope.data = [
        {"name": "John", "location": "Boston"},
        {"name": "Dave", "location": "Lancaster"}
    ];

    $scope.title = null;

    $scope.listMap = [{
        name: 'Home',
        value: [{
            name: 'File'
        }, {
            name: 'Items'
        }]
    }, {
        name: 'Second Menu',
        value: [{
            name: 'Nothings'
        }, {
            name: 'Ooo LA LA'
        }]
    }, ];
    $scope.menuData = [];
    $scope.menu = [];



    $scope.geMenuList = function () {


        // var currentRoleId = parseInt(getCookie('role_id'));


        //   $('#currentRoleId').val();
        var currentRoleId = getCookie('RoleId');
        /*    var data = {
            id:1
        }
        */
        var response = kgchrmService.getMenuSidbar(currentRoleId);
        response.then(function (list) {

            $scope.menuData = [];
           

            $scope.menuData = list.data;


          //  $scope.menu.clear();

            angular.forEach($scope.menuData, function (value, key) {
                if (value.ParentId == 0) {
                    $scope.menu.push(value);
                }
            });

            angular.forEach($scope.menuData, function (value, key) {
                if (value.Id != 0) {
                    angular.forEach($scope.menu, function (value2, key2) {
                        if (value.ParentId == value2.Id) {
                            if (value2.children == undefined) {
                                value2.children = [];
                                value2.showChildren = false;
                            }
                            value2.children.push(value);
                        }
                    });
                }
            });
            console.log("Menu Loaded!");
           // console.log("Menu info:" + JSON.stringify($scope.menu));
            includeJs("../assets/js/app.js");

        }, function () {
            alert('Error in getting records');
        });
    }




    $scope.geNotificationList = function () {


       


        //   $('#currentRoleId').val();
        var currentRoleId = getCookie('UserId');
        /*    var data = {
            id:1
        }
        */
        var response = kgchrmService.getNotificationList(currentRoleId);
        response.then(function (list) {

            $scope.notificationList = [];


            $scope.notificationList = list.data;


            //  $scope.menu.clear();

          
           // console.log("Menu info:" + JSON.stringify($scope.menu));


        }, function () {
            alert('Error in getting records');
        });
    }




   // setInterval($scope.geNotificationList, 1000);


    $scope.init = function () {

      /*  var data = {
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

        */
        $scope.geMenuList();





      /*  var response = simsService.setSessionData(data);
        response.then(function (list) {

            $scope.geMenuList();


        }, function (error) {
            toastr.error(error.data);
        });*/


    }





    $scope.init();



}


angular.module('myApps')
        .controller('SideMenuController', SideMenuController);