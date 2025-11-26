'use strict';
var LeaveManagementController = function ($scope, $filter, $window, $log, kgchrmService) {

    $scope.menuDatas = [];
    $scope.employeeList = [];
    $scope.leaveTypeList = [];
    $scope.shiftList = [];
    $scope.departmentList = [];
    $scope.designationList = [];
    $scope.gradeList = [];
    $scope.jobExperienceLists = [];
    $scope.menus = [];
    $scope.companyObj = {};
    $scope.NomineeList = [];
    $scope.companyList = [];
    $scope.ChildrenList = [];
    $scope.Count=0;
    $scope.LeaveListHR = [];
    $scope.roles = [];
    $scope.rolePermissionList = [];
    $scope.roleList = [];


    $scope.supervisorList = [];


    $scope.educationList=[];
    $scope.jobExperienceList=[];

    $scope.Entity = {};

    $scope.EntityObj = {};
    $scope.Entity.LeaveDays = 0;

    $scope.Entity.Status = true;
    $scope.permissons = [];
    $scope.componetList = [];
    $scope.rolesSecondary = [];
    $scope.designations = [];
    $scope.departments = [];
    $scope.userLevels = [];
    $scope.companies = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;
    $scope.data = [
        {"name": "John", "location": "Boston"},
        {"name": "Dave", "location": "Lancaster"}
    ];



    $scope.leaveTypeCompentionate = [
    { Id: 2, Name: "Compensatory Leave" },
    ];

    $scope.title = null;
    $scope.message = "Asib AL aMIN";


    function days_between(date1, date2) {

        // The number of milliseconds in one day
        const ONE_DAY = 1000 * 60 * 60 * 24;

        // Calculate the difference in milliseconds
        const differenceMs = Math.abs(date1 - date2);

        // Convert back to days and return
        return Math.round(differenceMs / ONE_DAY);

    }



    
    $scope.ChangeDate = function (Entity) {

        Entity.LeaveDays = 0;
        var date = days_between(Entity.LeaveFrom, Entity.LeaveTo);
        if (!isNaN(date))
        {
           Entity.LeaveDays = date+1;
        }
      
        
    }




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
            $scope.pullRoleInformation(1);
      

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
    
    
        else if (mode == 'Approve') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;
         //   var data=
           // $scope.SearchLeaveRequestList();
            $scope.Entity = $filter('filter')($scope.LeaveListHR, function (d) {
                return d.Id === id;
            })[0];
            //if ($scope.Entity.Status == 1) {
            //    $scope.Entity.Status = true;
            //} else {
            //    $scope.Entity.Status = false;

            //}


        }
    }



    $scope.ChangeEmployeeCode = function (code) {
        var data = { EmployeeCode: code };
        kgchrmService.SearchEmployee(data)
              .then(function (lst) {

                  $scope.Entity = lst.data;


              });
    }


    $scope.SaveLeaveInfo = function (Entity) {

        Entity.LeaveType = $('#LeaveType :selected').val().split(":")[1];
        Entity.EmployeeId = $('#EmployeeId :selected').val().split(":")[1];
      
        Entity.UserId = getCookie('UserId');
      



        if (typeof Entity.LeaveFrom == 'undefined') {
            toastr.error("Leave From Date can not be empty!");
            return;
        }

        if (Entity.LeaveFrom ==null) {
            toastr.error("Leave From Date can not be empty!");
            return;
        }

        if (typeof Entity.LeaveTo == 'undefined') {
            toastr.error("Leave To Date can not be empty!");
            return;
        }

        if (Entity.LeaveTo == null) {
            toastr.error("Leave To Date can not be empty!");
            return;
        }

        if (typeof Entity.LeaveType === 'undefined') {
            toastr.error("Leave Type can not be empty!");
            return;
        }

        if (typeof Entity.EmployeeId === 'undefined') {
            toastr.error("Supervisor can not be empty!");
            return;
        }


        if (Entity.UserId == "")
        {
            toastr.error("User can not be empty!");
            return;
        }

        kgchrmService.SaveLeaveInfo(Entity)
         .then(function (lst) {

             $scope.Entity = lst.data;
            // console.log(lst.data);
             toastr.success("Successfully Applied!");

             $scope.pg = false;

         });

     







    }




    $scope.SaveLeaveInfoHRTest = function (Entity) {

        Entity.LeaveType = $('#LeaveType :selected').val().split(":")[1];
        Entity.SupervisorId = $('#SupervisorId :selected').val().split(":")[1];

        Entity.UserId = getCookie('UserId');




        if (typeof Entity.LeaveFrom == 'undefined') {
            toastr.error("Leave From Date can not be empty!");
            return;
        }

        if (Entity.LeaveFrom == null) {
            toastr.error("Leave From Date can not be empty!");
            return;
        }

        if (typeof Entity.LeaveTo == 'undefined') {
            toastr.error("Leave To Date can not be empty!");
            return;
        }

        if (Entity.LeaveTo == null) {
            toastr.error("Leave To Date can not be empty!");
            return;
        }

        if (typeof Entity.LeaveType === 'undefined') {
            toastr.error("Leave Type can not be empty!");
            return;
        }

        if (typeof Entity.EmployeeId === 'undefined') {
            toastr.error("Supervisor can not be empty!");
            return;
        }


        if (Entity.UserId == "") {
            toastr.error("User can not be empty!");
            return;
        }

        if (Entity.Reason == "") {
            toastr.error("Reason can not be empty!");
            return;
        }


        var dataObj = {
            EmployeeId: Entity.EmployeeIdObj,
            SupervisorId:Entity.SupervisorId,
            LeaveUpto: Entity.LeaveTo,
            SupervisorId: Entity.EmployeeId,
            LeaveApplicationFrom: Entity.LeaveFrom,
            Reason: Entity.Reason,
            UserId: Entity.UserId,
            LeaveType: Entity.LeaveType,
            LeaveFrom: Entity.LeaveFrom,
            LeaveTo: Entity.LeaveTo,
            Status: Entity.Status

        };

      //  return;

        kgchrmService.SaveLeaveInfoHR(dataObj)
         .then(function (lst) {

             $scope.Entity = lst.data;
             // console.log(lst.data);
             toastr.success("Successfully Applied!");

             $scope.pg = false;

         });









    }











    $scope.SaveLeaveCompentionate = function (Entity) {

        Entity.LeaveType = $('#LeaveType :selected').val().split(":")[1];
        Entity.SupervisorId = $('#SupervisorId :selected').val().split(":")[1];

        Entity.UserId = getCookie('UserId');




        if (typeof Entity.WorkingHour == 'undefined') {
            toastr.error("Working hour can not be empty!");
            return;
        }

        if (Entity.WorkingDate == null) {
            toastr.error("Working Date can not be empty!");
            return;
        }

        if (typeof Entity.LeaveDate == 'undefined') {
            toastr.error("Leave Date can not be empty!");
            return;
        }

     


        var dataObj = {
            EmployeeId: Entity.EmployeeIdObj,
            SupervisorId: Entity.SupervisorId,
            WorkingHour: Entity.WorkingHour,
            WorkingDate: Entity.WorkingDate,
            LeaveDate: Entity.LeaveDate,
            Reason: Entity.Reason,
            UserId: Entity.UserId,

        };

        //  return;

        kgchrmService.SaveCompentionate(dataObj)
         .then(function (lst) {

             $scope.Entity = lst.data;
             // console.log(lst.data);
             toastr.success(lst.data);

             $scope.pg = false;

         });









    }





    $scope.EditAttendance = function (Entity) {

       

        Entity.UserId = getCookie('UserId');

        var loginTime = $('#in-time').val();
        var logoutTime = $('#out-time').val();
        var pin = $('#EmployeeCode').val();

     
        

        var dataObj = {
            EntryUserId: Entity.UserId,
            InTimeLog: loginTime,
            OutTime: logoutTime,
            PIN: pin,
            Reason:Entity.Reason
           
        };

  

        kgchrmService.SaveEditAttendence(dataObj)
         .then(function (lst) {

            // $scope.Entity = lst.data;
             // console.log(lst.data);
             toastr.success(lst.data);

             $scope.pg = false;

         });









    }














    $scope.getLeaveTypeListObj = function () {
        $scope.pg = true;
        var Entity = getCookie('UserId');
        kgchrmService.getLeaveTypeListObj(Entity)
            .then(function (lst) {

                $scope.Entity = lst.data;
               // var datan = JSON.stringify($scope.employeeList);
              //  console.log(datan);
                $scope.pg = false;

            });
    }

    $scope.LeaveRequestChange = function (Entity) {
        $scope.pg = true;
        Entity.UserId = getCookie('UserId');
      
        kgchrmService.getLeaveEmployeeObj(Entity)
            .then(function (lst) {

                $scope.EntityObj = lst.data;
            //    Entity.Status = true;
                // var datan = JSON.stringify($scope.employeeList);
                //  console.log(datan);
                $scope.pg = false;

            });
    }




     $scope.LeaveRequestChangeCompentionate = function (Entity) {
        $scope.pg = true;
        Entity.UserId = getCookie('UserId');
      
        kgchrmService.getLeaveEmployeeObj(Entity)
            .then(function (lst) {

                $scope.EntityObj = lst.data;
                $scope.EntityObj.LeaveType = 2;
            //    Entity.Status = true;
                // var datan = JSON.stringify($scope.employeeList);
                //  console.log(datan);
                $scope.pg = false;

            });
    }












    $scope.LeaveApprove = function (Entity) {
        $scope.pg = true;
      //  Entity.UserId = getCookie('UserId');

        var data = {
            Id: Entity.Id,
            SupervisorId: getCookie('UserId')
        }


        kgchrmService.LeaveApprove(data)
            .then(function (lst) {

                toastr.success(lst.data);

            });
    }



    $scope.CancelStatusUpdate = function (Entity) {
        $scope.pg = true;
        //  Entity.UserId = getCookie('UserId');

        var data = {
            Id: Entity.Id,
            SupervisorId: getCookie('UserId')
        }


        kgchrmService.CancelStatusUpdate(data)
            .then(function (lst) {

                toastr.success(lst.data);

            });
    }
    
    


    $scope.SearchLeaveRequestList = function (Entity) {
        $scope.pg = true;
        // var Entity = getCookie('UserId');

      //  return Entity;

        kgchrmService.getLeaveRequestListHR(Entity)
            .then(function (lst) {

                $scope.LeaveListHR = lst.data;
                // var datan = JSON.stringify($scope.employeeList);
                //  console.log(datan);
                $scope.pg = false;

            });
    }

 

    $scope.SearchLeaveRequestListCompentionate = function (Entity) {
        $scope.pg = true;
        // var Entity = getCookie('UserId');

        //  return Entity;

        kgchrmService.getLeaveRequestListHRCompentionate(Entity)
            .then(function (lst) {

                $scope.LeaveListHR = lst.data;
                // var datan = JSON.stringify($scope.employeeList);
                //  console.log(datan);
                $scope.pg = false;

            });
    }




    $scope.LeaveApplication = function (Entity) {
        $scope.pg = true;
        //  var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/LeaveapplicationHR.aspx?employee_code=" + Entity.PIN + "&reason=" + Entity.Reason + "&from=" + Entity.LeaveForm + "&to=" + Entity.LeaveTo + "&days=" + Entity.Days + "&leave_id=" + Entity.Id, '_blank', 'height=800,width=1000');
    }




    




    $scope.getLeaveTypeListObj();






        $scope.getEmployeeList = function () {
            $scope.pg = true;

            kgchrmService.getEmployeeList(null)
                .then(function (lst) {

                    $scope.employeeList = lst.data;
                    var datan = JSON.stringify($scope.employeeList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }


     //   $scope.getEmployeeList();


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


        


        $scope.getLeaveTypeList = function () {
            $scope.pg = true;

            kgchrmService.getLeaveTypeList(null)
                .then(function (lst) {

                    $scope.leaveTypeList = lst.data;
                    var datan = JSON.stringify($scope.departmentList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getLeaveTypeList();




      


        $scope.ShiftList = function () {
            $scope.pg = true;

            kgchrmService.ShiftList()
                .then(function (lst) {

                    $scope.shiftList = lst.data;
                    var datan = JSON.stringify("Company List:" + JSON.stringify($scope.shiftList));
                    console.log(datan);
                    $scope.pg = false;

                });
        }


       // $scope.ShiftList();
        









    
    $scope.init = function() {



      //  getDataShow();

      //  $(".select21").select2();

      /*  $(".tag").select2({
            tags: true
        });
        */



    }



    $scope.CompnetionateLeave=function() {
        $scope.EntityObj.LeaveType = 2;
    }


}


angular.module('myApps')
        .controller('LeaveManagementController', LeaveManagementController);