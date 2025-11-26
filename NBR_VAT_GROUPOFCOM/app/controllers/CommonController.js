'use strict';
var CommonController = function ($scope, $filter, $log,$window, kgchrmService) {


    $scope.structureMasterId = 0;
    $scope.menuDatas = [];
    $scope.employeeList = [];
  
    $scope.MobileListData=[];

    $scope.supervisorList = [];

    $scope.DisplayModal = function (mode, title, id) {
        if (mode == 'Add') {
            $scope.Add = true;
            $scope.Update = false;
            $scope.title = title;
            $scope.Entity = {};
            $scope.Entity.Status = true;
            $scope.Display = false;

        }

        

        else if (mode == 'Permission') {
            $scope.Add = false;
            $scope.Update = false;
            $scope.title = title;
            $scope.Display = true;
            $scope.pullRoleInformation(id);
      

        //$scope.Entity = $filter('filter')($scope.roles, function(d) { return d.Id === id; })[0];
        }

        else if (mode == 'Display') {
            $scope.Add = false;
            $scope.Update = false;
            $scope.title = title;
            $scope.Display = true;
       
            $scope.getPermissions(id);

            //$scope.Entity = $filter('filter')($scope.roles, function(d) { return d.Id === id; })[0];
        }
    
    
    else if (mode == 'Update') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;

            $scope.Entity = $filter('filter')($scope.MobileListData, function (d) {
                return d.EmployeeId === id;
            })[0];
            if ($scope.Entity.Status == 1) {
                $scope.Entity.Status = true;
            } else {
                $scope.Entity.Status = false;

            }

          //  $("#EmployeeId").select2("val", $scope.Entity.EmployeeId);

        }


        



    }




    $scope.GetSuperVisorList = function () {
        $scope.pg = true;

        kgchrmService.GetSuperVisorList(null)
            .then(function (lst) {

                $scope.supervisorList = lst.data;
                //   var datan = JSON.stringify($scope.employeeList);
                //  console.log(datan);
                $scope.pg = false;

            });
    }


    $scope.GetSuperVisorList();


    $scope.getEmployeeData = function (Id) {



        $scope.Add = false;
        $scope.Update = true;

        kgchrmService.getEmployeeListObj(Id)
              .then(function (lst) {

                  $scope.Entity = lst.data;


                  //  console.log(datan);
                  $scope.pg = false;

              });

    }

   



    $scope.getMobileListData = function () {



        $scope.Add = false;
        $scope.Update = true;

        kgchrmService.getMobileListDataList()
              .then(function (lst) {

                  $scope.MobileListData = lst.data;


                  //  console.log(datan);
                  $scope.pg = false;

              });

    }

    $scope.getMobileListData();








      $scope.saveMobileInfo = function (Entity) {

          Entity.EmployeeId = $('#EmployeeId').val().split(":")[1];
                //$('#ParentCompanyId :selected').val();
          
          //  var validation = $('#myform').validate();

      
            // '  var result = $("#new-form").validate();

            var model = $('#myform').valid();

            if (model == true) {

                kgchrmService.saveMobileInfo(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);

                    //  getDataShow();
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
            }

        }









      $scope.UpdateMobileInfo = function (Entity) {

          Entity.EmployeeId = $('#EmployeeId').val().split(":")[1];
          //$('#ParentCompanyId :selected').val();

          //  var validation = $('#myform').validate();


          // '  var result = $("#new-form").validate();

          var model = $('#myform').valid();

          if (model == true) {

              kgchrmService.UpdateMobileInfo(Entity)
              .then(function (msg) {

                  toastr.success(msg.data);

                  $('#addNewRole').modal('hide');

                  //  getDataShow();
                  // $scope.getComponentGroups();

              }, function (error) {
                  toastr.error(error);

              });
          }

      }
















    
    $scope.init = function() {

    }


}


angular.module('myApps')
        .controller('CommonController', CommonController);