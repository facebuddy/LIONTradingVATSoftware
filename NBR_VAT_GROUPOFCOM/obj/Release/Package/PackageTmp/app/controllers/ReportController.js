'use strict';
var ReportController = function ($scope, $filter, $log,$window, kgchrmService) {

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
    $scope.EntityRpt = {};
    $scope.roles = [];
    $scope.rolePermissionList = [];
    $scope.roleList = [];
    $scope.departmentLis=[];
  
    $scope.educationList=[];
    $scope.jobExperienceList=[];

    $scope.Entity = {};

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




    $scope.Months = [
      { "name": "January", "id": "0" },
      { "name": "February", "id": "1" },
      { "name": "March", "id": "2" },
      { "name": "April", "id": "3" },
      { "name": "May", "id": "4" },
      { "name": "June", "id": "5" },
      { "name": "July", "id": "6" },
      { "name": "August", "id": "7" },
      { "name": "September", "id": "8" },
      { "name": "October", "id": "9" },
      { "name": "November", "id": "10" },
      { "name": "December", "id": "11" },

    ];








    $scope.Years = [
      { "name": "2021", "id": "2021" },
      { "name": "2022", "id": "2022" },
      { "name": "2023", "id": "2023" },
      { "name": "2024", "id": "2024" },
      { "name": "2025", "id": "2025" },
      { "name": "2026", "id": "2026" },
      { "name": "2027", "id": "2027" },
      { "name": "2028", "id": "2028" },
      { "name": "2029", "id": "2029" },
      { "name": "2030", "id": "2030" },
      

    ];



    var monthid = new Date().getMonth();
    var year = new Date().getFullYear();



    $scope.EntityRpt.YearId = String(year);
    $scope.EntityRpt.MonthId = String(0);

    $scope.title = null;
    $scope.message = "Asib AL aMIN";








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
    
    
    else if (mode == 'Update') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;

            $scope.Entity = $filter('filter')($scope.roleList, function (d) {
                return d.Id === id;
            })[0];
            if ($scope.Entity.Status == 1) {
                $scope.Entity.Status = true;
            } else {
                $scope.Entity.Status = false;

            }


        }
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




    




    //$scope.getLeaveTypeListObj = function () {
    //    $scope.pg = true;
    //    var Entity = getCookie('UserId');
    //    kgchrmService.getLeaveTypeListObj(Entity)
    //        .then(function (lst) {

    //            $scope.Entity = lst.data;
    //           // var datan = JSON.stringify($scope.employeeList);
    //          //  console.log(datan);
    //            $scope.pg = false;

    //        });
    //}






 






    

    $scope.getCompanyList = function () {
        $scope.pg = true;

        kgchrmService.getCompanyList()
            .then(function (lst) {

                $scope.companyList = lst.data;
                var datan = JSON.stringify("Company List:" + JSON.stringify($scope.companyList));
               // console.log(datan);
                $scope.pg = false;

            });
    }

    $scope.getCompanyList();
   // $scope.getLeaveTypeListObj();



    
    $scope.LeaveSheet = function (Entity) {
        $scope.pg = true;
      //  var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/LeaveReport.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + Entity.YearId, '_blank', 'height=800,width=1000');
    }



    $scope.MyLeaveSheet = function (Entity) {
        $scope.pg = true;
        var pin = getCookie('PIN');
        //  var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/LeaveReport.aspx?employee_code=" + pin + "&year_id=" + Entity.YearId, '_blank', 'height=800,width=1000');
    }




    $scope.LeaveApplication = function (Entity) {
        $scope.pg = true;
        //  var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/Leaveapplication.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + Entity.YearId, '_blank', 'height=800,width=1000');
    }




    $scope.MyLeaveApplication = function (Entity) {
        $scope.pg = true;
        var pin = getCookie('PIN');
        var pindata = EncryptData(pin);
        //  var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/Leaveapplication.aspx?employee_code=" + pindata + "&year_id=" + Entity.YearId, '_blank', 'height=800,width=1000');
    }


    $scope.DailyAttendenceReport = function (Entity) {
        $scope.pg = true;

        var companyId = $("#departemntId").val().split(':')[1];
        var date = $("#atdDate").val();
        return $window.open("/Reports/DailyAttendenceReport.aspx?department_id=" + companyId + "&attendence_date=" + date, '_blank', 'height=800,width=1000');
    }


    $scope.TZDailyAttendenceReport = function (Entity) {
        $scope.pg = true;

      
        var date = $("#atdDate").val();
        return $window.open("/Reports/DailyTIMEZONEAttendenceReport.aspx?attendence_date=" + date, '_blank', 'height=800,width=1000');
    }

    
    


    $scope.SearchAtd = function (Entity) {
        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/AttendenceReport.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + Entity.YearId + "&MonthId=" + month, '_blank', 'height=800,width=1000');
    }

    $scope.SearchAtdNew = function (Entity) {
        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/AttendenceReportNew.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + Entity.YearId + "&MonthId=" + month, '_blank', 'height=800,width=1000');
    }



    $scope.LeaveRegisterDetail = function (Entity) {
        $scope.pg = true;
        var year = $("#YearId").val().split(':')[1];
        return $window.open("/Reports/LeaveRegisterDetailHR.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + year, '_blank', 'height=800,width=1000');
    }




    $scope.MyLeaveRegisterDetail = function (Entity) {
        $scope.pg = true;
        var year = $("#YearId").val().split(':')[1];
        var pin = getCookie('PIN');
        var pindata = EncryptData(pin);
        return $window.open("/Reports/LeaveRegisterDetailHR.aspx?employee_code=" + pindata + "&year_id=" + year, '_blank', 'height=800,width=1000');
    }



    $scope.TAXDetail = function (Entity) {
        $scope.pg = true;
        var year = $("#YearId").val().split(':')[1];

        var startDate = $("#StartDate").val();
        var endDate = $("#EndDate").val();

        return $window.open("/Reports/TaxCertificateReportNew.aspx?employee_code=" + Entity.EmployeeCode + "&start_date=" + startDate + "&end_date=" + endDate + "&year_id=" + year, '_blank', 'height=800,width=1000');
    }

    $scope.MYTAXDetail = function (Entity) {
        $scope.pg = true;

        var pin = getCookie('PIN');
        var pindata = EncryptData(pin);
        var year = $("#YearId").val().split(':')[1];
        return $window.open("/Reports/TaxCertificateReport.aspx?employee_code=" + pindata + "&year_id=" + year, '_blank', 'height=800,width=1000');
    }


    $scope.SalaryDetail = function (Entity) {
        $scope.pg = true;
        var year = $("#YearId").val().split(':')[1];
        return $window.open("/Reports/SalaryCertifiate.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + year, '_blank', 'height=800,width=1000');
    }




    $scope.MySalaryDetail = function (Entity) {
        $scope.pg = true;

        var pin = getCookie('PIN');
        var pindata=   EncryptData(pin);
        var year = $("#YearId").val().split(':')[1];
        return $window.open("/Reports/SalaryCertifiate.aspx?employee_code=" + pindata + "&year_id=" + year, '_blank', 'height=800,width=1000');
    }





    $scope.PFLedgerSheet = function (Entity) {
        $scope.pg = true;
      
       // var month = $("#MonthId").val().split(':')[1];
       // var month = parseInt(month) + 1;
        return $window.open("/Reports/PFSheetReportPaid.aspx?employee_code=" + Entity.EmployeeCode, '_blank', 'height=800,width=1000');
    }



    $scope.MyPFLedgerSheet = function (Entity) {
        $scope.pg = true;


        var pin = getCookie('PIN');
        var pindata = EncryptData(pin);
        // var month = $("#MonthId").val().split(':')[1];
        // var month = parseInt(month) + 1;
        return $window.open("/Reports/PFSheetReportPaid.aspx?employee_code=" + pindata, '_blank', 'height=800,width=1000');
    }



    $scope.TAXCertifiate = function (Entity) {
        $scope.pg = true;
        var year = $("#YearId").val().split(':')[1];
        return $window.open("/Reports/TaxCertificateReport.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + year, '_blank', 'height=800,width=1000');
    }



    $scope.SearchAtdTZ = function (Entity) {
        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];
        return $window.open("/Reports/TZAttendenceReport.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + Entity.YearId + "&MonthId=" + month, '_blank', 'height=800,width=1000');
    }



    $scope.SearchIndividualSalarySheet= function (Entity) {
        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];
        var month = parseInt(month)+1;
        return $window.open("/Reports/IndividualSalaryReport.aspx?employee_code=" + Entity.EmployeeCode + "&year_id=" + Entity.YearId + "&month_id=" + month, '_blank', 'height=800,width=1000');
    }





    $scope.MySearchIndividualSalarySheet = function (Entity) {


        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];
        var pin = getCookie('PIN');
        var pindata = EncryptData(pin);
        var month = parseInt(month) + 1;
        return $window.open("/Reports/IndividualSalaryReport.aspx?employee_code=" + pindata + "&year_id=" + Entity.YearId + "&month_id=" + month, '_blank', 'height=800,width=1000');
    }










    $scope.GetBonusPaymentTypeInfo = function () {
        $scope.pg = true;

        kgchrmService.GetBonusPaymentTypeInfo()
            .then(function (lst) {

                $scope.BonusPaymentTypeList = lst.data;
                var datan = JSON.stringify($scope.roleList);
                console.log(datan);
                $scope.pg = false;

            });
    }


    $scope.GetBonusPaymentTypeInfo();


    $scope.SearchIndividualLoanLedger = function (Entity) {
        $scope.pg = true;
       // var month = $("#MonthId").val().split(':')[1];
       // var month = parseInt(month) + 1;
        return $window.open("/Reports/IndividualLoanReport.aspx?employee_code=" + Entity.EmployeeCode, '_blank', 'height=800,width=1000');
    }





    $scope.MySearchIndividualLoanLedger = function (Entity) {
        $scope.pg = true;
        // var month = $("#MonthId").val().split(':')[1];
        // var month = parseInt(month) + 1;

          var pin = getCookie('PIN');
        var pindata = EncryptData(pin);



        return $window.open("/Reports/IndividualLoanReport.aspx?employee_code=" + pindata, '_blank', 'height=800,width=1000');
    }



    $scope.SearchIndividualPFLoanLedger = function (Entity) {
        $scope.pg = true;
        // var month = $("#MonthId").val().split(':')[1];
        // var month = parseInt(month) + 1;
        return $window.open("/Reports/IndividualPFLoanReport.aspx?employee_code=" + Entity.EmployeeCode, '_blank', 'height=800,width=1000');
    }


    $scope.SearchSalarySheetMonthly = function (Entity) {
        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];
        var companyId = $("#CompanyId").val().split(':')[1];

        var month = parseInt(month) + 1;
        return $window.open("/Reports/SalarySheetMonthly.aspx?year_id=" + Entity.YearId + "&month_id=" + month+"&company_id="+companyId , '_blank', 'height=800,width=1000');
    }




    $scope.MobileBillSheetMonthly = function (Entity) {
        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];
        var month = parseInt(month) + 1;
        return $window.open("/Reports/MobileSheetReportPaid.aspx?year_id=" + Entity.YearId + "&month_id=" + month, '_blank', 'height=800,width=1000');
    }







    $scope.BonusSheetPop = function (Entity) {
        $scope.pg = true;
        var month = $("#MonthId").val().split(':')[1];

        var company_id = $("#CompanyId").val().split(':')[1];
        var department_id = $("#DepartmentId").val().split(':')[1];

        var designation_id = $("#DesignationId").val().split(':')[1];

        var bonusType = $("#BonusType").val().split(':')[1];

        var year = $("#YearId").val().split(':')[1];


       // var month = parseInt(month) + 1;
        return $window.open("/Reports/BonusSheetReportPaid.aspx?year_id=" + Entity.YearId + "&month_id=" + month + "&company_id=" + company_id + "&departmentId=" + department_id + "&designationId=" + designation_id + "&bonus_type=" + bonusType, '_blank', 'height=800,width=1000');
    }












    $scope.DownloadBonusSheet = function (Entity) {
        $scope.pg = true;
       // var month = $("#MonthId").val().split(':')[1];
        //  var month = parseInt(month) + 1;

        var designationId = $('#designationId :selected').val().split(":")[1];
        var departemntId = $('#departemntId :selected').val().split(":")[1];

         var companyId = $('#CompanyId :selected').val().split(":")[1];

         return $window.open("/Utility/DownloadExcelEmployeeBonus?departemntId=" + departemntId + "&designationId=" + designationId + "&CompanyId=" + companyId, '_blank', 'height=800,width=1000');
    }





    $scope.DownloadSalarySheet = function (Entity) {
        $scope.pg = true;

        var designationId =  $('#designationId :selected').val().split(":")[1];
        var departemntId = $('#departemntId :selected').val().split(":")[1];
        var companyId = $('#CompanyId :selected').val().split(":")[1];

        // var month = $("#MonthId").val().split(':')[1];
        //  var month = parseInt(month) + 1;
        return $window.open("/Utility/DownloadSalarySheet?departemntId=" + departemntId + "& designationId=" + designationId + "&CompanyId=" + companyId, '_blank', 'height=800,width=1000');
    }


    $scope.DownloadTAXSheet = function (Entity) {
        $scope.pg = true;
        // var month = $("#MonthId").val().split(':')[1];
        //  var month = parseInt(month) + 1;
          var designationId =  $('#designationId :selected').val().split(":")[1];
        var departemntId =  $('#departemntId :selected').val().split(":")[1];

        var companyId = $('#CompanyId :selected').val().split(":")[1];

        return $window.open("/Utility/DownloadTAXExport?departemntId=" + departemntId + "& designationId=" + designationId + "&CompanyId=" + companyId, '_blank', 'height=800,width=1000');
    }


    


        $scope.getEmployeeList = function () {
            $scope.pg = true;

            kgchrmService.getEmployeeList(null)
                .then(function (lst) {

                    $scope.employeeList = lst.data;
                  //  var datan = JSON.stringify($scope.employeeList);
                  //  console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getEmployeeList();


        $scope.getDesignationList = function () {
            $scope.pg = true;

            kgchrmService.getDesignationList(null)
                .then(function (lst) {

                    $scope.designationList = lst.data;
                    var datan = JSON.stringify($scope.designationList);
                   // console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getDesignationList();




        $scope.getLeaveTypeList = function () {
            $scope.pg = true;

            kgchrmService.getLeaveTypeList(null)
                .then(function (lst) {

                    $scope.leaveTypeList = lst.data;
                  //  var datan = JSON.stringify($scope.departmentList);
                //    console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getLeaveTypeList();



        $scope.getDepartmentList = function () {
            $scope.pg = true;

            kgchrmService.getDepartmentList(null)
                .then(function (lst) {

                    $scope.departmentList = lst.data;
                    var datan = JSON.stringify($scope.departmentList);
                   // console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getDepartmentList();

      


        $scope.ShiftList = function () {
            $scope.pg = true;

            kgchrmService.ShiftList()
                .then(function (lst) {

                    $scope.shiftList = lst.data;
                    var datan = JSON.stringify("Company List:" + JSON.stringify($scope.shiftList));
                   // console.log(datan);
                    $scope.pg = false;

                });
        }


       // $scope.ShiftList();
        





      //  $scope.Entity.YearId = year;
        //$scope.Entity.MonthId = monthid;




    
    $scope.init = function() {



      //  getDataShow();

      //  $(".select21").select2();

      /*  $(".tag").select2({
            tags: true
        });
        */



    }


}


angular.module('myApps')
        .controller('ReportController', ReportController);