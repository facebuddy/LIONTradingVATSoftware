'use strict';
var NotificationController = function ($scope, $filter, $log, kgchrmService) {

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
     var currentRoleId = 1;
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

            console.log("Menu info:" + JSON.stringify($scope.menu));


        }, function () {
            alert('Error in getting records');
        });
    }






    //var timeSince = function (date) {
    //    if (typeof date !== 'object') {
    //        date = new Date(date);
    //    }

    //    var seconds = Math.floor((new Date() - date) / 1000);
    //    var intervalType;

    //    var interval = Math.floor(seconds / 31536000);
    //    if (interval >= 1) {
    //        intervalType = 'year';
    //    } else {
    //        interval = Math.floor(seconds / 2592000);
    //        if (interval >= 1) {
    //            intervalType = 'month';
    //        } else {
    //            interval = Math.floor(seconds / 86400);
    //            if (interval >= 1) {
    //                intervalType = 'day';
    //            } else {
    //                interval = Math.floor(seconds / 3600);
    //                if (interval >= 1) {
    //                    intervalType = "hour";
    //                } else {
    //                    interval = Math.floor(seconds / 60);
    //                    if (interval >= 1) {
    //                        intervalType = "minute";
    //                    } else {
    //                        interval = seconds;
    //                        intervalType = "second";
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    if (interval > 1 || interval === 0) {
    //        intervalType += 's';
    //    }

    //    return interval + ' ' + intervalType;
    //};
    //var aDay = 24 * 60 * 60 * 1000;







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

            var exist = list.data[0];
            if (exist != null)
            {
                $scope.Count = list.data[0].Count;
            }
           // $scope.TimeAgo = timeSince(new Date(Date.now() - aDay))
            //$scope.notificationList.forEach(function (item) {

            //    item.TimeAgo = timeSince(new Date(Date.now() - aDay));


            //});
            //  $scope.menu.clear();

          
           // console.log("Menu info:" + JSON.stringify($scope.menu));


        }, function () {
            alert('Error in getting records');
        });
    }




    setInterval($scope.geNotificationList, 5*10000);

    $scope.geNotificationList();
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
       // $scope.geMenuList();





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
        .controller('NotificationController', NotificationController);