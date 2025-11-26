'use strict';
var KGCHRMController = function ($scope, $filter, $log,$window, kgchrmService) {


    $scope.structureMasterId = 0;
    $scope.menuDatas = [];
    $scope.employeeList = [];
    $scope.leaveTypeList = [];
    $scope.shiftList = [];
    $scope.departmentList = [];
    $scope.designationList = [];
    $scope.gradeList = [];
    $scope.jobExperienceLists = [];
    $scope.employeePromotionList = [];
    $scope.menus = [];
    $scope.companyObj = {};
    $scope.NomineeList = [];
    $scope.companyList = [];
    $scope.EmployeeSalaryDetails = [];
    $scope.ChildrenList = [];
    $scope.attendenceList = [];
    $scope.salarySturctureList=[];
    $scope.roles = [];
    $scope.rolePermissionList = [];
    $scope.roleList = [];
    $scope.attendenceLocationList=[];
    $scope.HeadQuaterList = [];
    $scope.BonusPaymentTypeList = [];

    $scope.educationList=[];
    $scope.jobExperienceList=[];

    $scope.Entity = {};
    $scope.SalaryStructureDetailList = [];
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

    $scope.title = null;
    $scope.message = "Asib AL aMIN";



 

    $scope.UpdateEmployee = function (Entity) {

        Entity.CompanyId = $('#CompanyId :selected').val().split(":")[1];
        Entity.DepartmentId = $('#DepartmentId :selected').val().split(":")[1];
        Entity.ShiftType = $('#ShiftType :selected').val().split(":")[1];
        Entity.DesignationId = $('#DesignationId :selected').val().split(":")[1];
        Entity.GradeId = $('#GradeId :selected').val().split(":")[1];


        Entity.JobNatureStatus = $('#JobNatureStatus :selected').val().split(":")[1];
        Entity.ExistStatus = $('#ExistStatus :selected').val().split(":")[1];

        Entity.SupervisorId = $('#SupervisorId :selected').val().split(":")[1];
        Entity.SecondarySupervisoryId = $('#SecondarySupervisoryId :selected').val().split(":")[1];
        Entity.Religion = $('#Religion :selected').val().split(":")[1];

        Entity.JobType = $('#JobType :selected').val().split(":")[1];

        Entity.Nationality = $('#Nationality :selected').val().split(":")[1];

        Entity.Education = $scope.educationList;



        Entity.Education = $scope.educationList;

        Entity.JobExperience = $scope.jobExperienceList;

        Entity.Nominee = $scope.NomineeList;

        Entity.Children = $scope.ChildrenList;


        Entity.EmployeeSalaryStructureVw = $scope.salarySturctureList;
        // Entity.ProfileImage=
        var file = $('#myProfile')[0].files[0];

        var fd = new FormData();

        fd.append('file', file);



        Entity.file = JSON.stringify(file);


        $.ajax({
            url: "/Admin/SaveFile",
            type: 'POST',
            data: fd,
            async: false,
            cache: false,
            contentType: false,
            enctype: 'multipart/form-data',
            processData: false,
            success: function (response) {


                Entity.ProfileImage = response;

         kgchrmService.UpdateEmployee(Entity)
         .then(function (lst) {

             $scope.Entity = lst.data;
             console.log(lst.data);
             toastr.success(lst.data);

             $scope.pg = false;

         });




            }
        });








        console.log(Entity);
        console.log(JSON.stringify(Entity));



    }







    $scope.EmployeeShortListPreview = function () {

        var Entity = {};
       
      
            var CompanyIdSearch = $('#CompanyIdSearch :selected').val();

     

       
            var DeprtmentIdSearch = $('#DeprtmentIdSearch :selected').val();

        
      


       
            var DesignationIdSearch = $('#DesignationIdSearch :selected').val();

        
       

        return $window.open("/Reports/EmployeeShortList.aspx?company_id=" + CompanyIdSearch + "&department_id=" + DeprtmentIdSearch + "&designation_id=" + DesignationIdSearch, '_blank', 'height=800,width=1000');
    }



    $scope.SaveEmployee = function (Entity) {

       var CompanyId = $('#CompanyId :selected').text();
        if (CompanyId != "")
        {
            Entity.CompanyId = $('#CompanyId :selected').val().split(":")[1];
            
        }
        else {
            Entity.CompanyId = null;

        }

        var DepartmentId = $('#DepartmentId :selected').text();
        if (DepartmentId != "") {
            Entity.DepartmentId = $('#DepartmentId :selected').val().split(":")[1];

        }
        else {
            Entity.DepartmentId = null;

        }


        var DesignationId = $('#DesignationId :selected').text();
        if (DesignationId != "") {
            Entity.DesignationId = $('#DesignationId :selected').val().split(":")[1];

        }
        else {
            Entity.DesignationId = null;

        }


       

        var ShiftType = $('#ShiftType :selected').text();
        if (ShiftType != "") {
            Entity.ShiftType = $('#ShiftType :selected').val().split(":")[1];

        }
        else {
            Entity.ShiftType = null;

        }



        var ShiftType = $('#ShiftType :selected').text();
        if (ShiftType != "") {
            Entity.ShiftType = $('#ShiftType :selected').val().split(":")[1];

        }
        else {
            Entity.ShiftType = null;

        }

        var GradeId = $('#GradeId :selected').text();
        if (GradeId != "") {
            Entity.GradeId = $('#GradeId :selected').val().split(":")[1];

        }
        else {
            Entity.GradeId = null;

        }

        var AttendenceLocationId = $('#AttendenceLocationId :selected').text();
        if (AttendenceLocationId != "") {
            Entity.AttendenceLocationId = $('#AttendenceLocationId :selected').val().split(":")[1];

        }
        else {
            Entity.AttendenceLocationId = null;

        }

        var SupervisorId = $('#SupervisorId :selected').text();
        if (SupervisorId != "") {
            Entity.SupervisorId = $('#SupervisorId :selected').val().split(":")[1];

        }
        else {
            Entity.SupervisorId = null;

        }

        var SecondarySupervisoryId = $('#SecondarySupervisoryId :selected').text();
        if (SecondarySupervisoryId != "") {
            Entity.SecondarySupervisoryId = $('#SecondarySupervisoryId :selected').val().split(":")[1];

        }
        else {
            Entity.SecondarySupervisoryId = null;

        }



        var JobNatureStatus = $('#JobNatureStatus :selected').text();
        if (JobNatureStatus != "") {
            Entity.JobNatureStatus = $('#JobNatureStatus :selected').val();

        }
        else {
            Entity.JobNatureStatus = null;

        }



        var ExistStatus = $('#ExistStatus :selected').text();
        if (ExistStatus != "") {
            Entity.ExistStatus = $('#ExistStatus :selected').val();

        }
        else {
            Entity.ExistStatus = null;

        }

        var ProbationPeriod = $('#ProbationPeriod :selected').text();
        if (ProbationPeriod != "") {
            Entity.ProbationPeriod = $('#ProbationPeriod :selected').val();

        }
        else {
            Entity.ProbationPeriod = null;

        }

        var Religion = $('#Religion :selected').text();
        if (Religion != "") {
            Entity.Religion = $('#Religion :selected').val();

        }
        else {
            Entity.Religion = null;

        }

        var JobType = $('#JobType :selected').text();
        if (JobType != "") {
            Entity.JobType = $('#JobType :selected').val();

        }
        else {
            Entity.JobType = null;

        }


        var Nationality = $('#Nationality :selected').text();
        if (Nationality != "") {
            Entity.Nationality = $('#Nationality :selected').val();

        }
        else {
            Entity.Nationality = null;

        }


        var ProbationPeriod = $('#ProbationPeriod :selected').text();
        if (ProbationPeriod != "") {
            Entity.ProbationPeriod = $('#ProbationPeriod :selected').val();

        }
        else {
            Entity.ProbationPeriod = null;

        }


        var Gender = $('#Gender :selected').text();
        if (Gender != "") {
            Entity.Gender = $('#Gender :selected').val();

        }
        else {
            Entity.Gender = null;

        }

        var MaritialStatus = $('#MaritialStatus :selected').text();
        if (MaritialStatus != "") {
            Entity.MaritialStatus = $('#MaritialStatus :selected').val();

        }
        else {
            Entity.MaritialStatus = null;

        }




        




        if (Entity.EmployeeOldCode == null) {
            toastr.error("Employee OldCode can not be empty!");
            return;
        }


        if (Entity.CompanyId == "" || typeof Entity.CompanyId === 'undefined') {
            toastr.error("Company can not be empty!");
            return;
        }

        if (Entity.DepartmentId == "" || typeof Entity.DepartmentId === 'undefined') {
            toastr.error("Department can not be empty!");
            return;
        }

        if (Entity.DesignationId == "" || typeof Entity.DesignationId === 'undefined') {
            toastr.error("Designation can not be empty!");
            return;
        }



        Entity.Education = $scope.educationList;



        Entity.Education = $scope.educationList;

        Entity.JobExperience = $scope.jobExperienceList;

        Entity.Nominee = $scope.NomineeList;

        Entity.Children = $scope.ChildrenList;


        Entity.EmployeeSalaryStructureVw = $scope.SalaryStructureDetailList;
       // Entity.ProfileImage=
        var file = $('#myProfile')[0].files[0];

        var fd = new FormData();
    
        fd.append('file', file);
     

        
        Entity.file =JSON.stringify(file);

       // Entity.EmployeeDOB = $('#EmployeeDOB').text();
       // Entity.EmployeeDOB = $('#EmployeeDOB').val();

        $.ajax({
            url: "/Admin/SaveFile",
            type: 'POST',
            data: fd,
            async: false,
            cache: false,
            contentType: false,
            enctype: 'multipart/form-data',
            processData: false,
            success: function (response) {

            
                Entity.ProfileImage = response;

                var mode = $('#mode').val();

                if (mode == "Add")
                {


                        kgchrmService.SaveEmployee(Entity)
                         .then(function (lst) {

                           //  $scope.Entity = lst.data;
                             console.log(lst.data);
                             toastr.success(lst.data);

                             $scope.pg = false;

                        });

                }
                else {



                    kgchrmService.UpdateEmployee(Entity)
                     .then(function (lst) {

                        // $scope.Entity = lst.data;
                       //  console.log(lst.data);

                         toastr.success(lst.data);


                         $('#exampleExtraLargeModal').modal('hide');


                       //  return;

                       //  $scope.pg = false;

                     });



                }





            }
        });



    



        
        console.log(Entity);
        console.log(JSON.stringify(Entity));



    }


    $scope.ClearData = function () {
        $scope.Entity = {};
       // $scope.SalaryStructureDetailList = {};
        var data = $scope.SalaryStructureDetailList;
        $scope.SalaryStructureDetailList = [];
        var data2 = $scope.SalaryStructureDetailList;
       
    }
    $scope.getEmployeeData = function (Id) {



        $scope.Add = false;
        $scope.Update = true;

        kgchrmService.getEmployeeListObj(Id)
              .then(function (lst) {

                  $scope.Entity = lst.data;
                  console.log(lst.data);

                  $scope.educationList = lst.data.Education;
                  $scope.jobExperienceList = lst.data.JobExperience;
                  $scope.NomineeList = lst.data.Nominee;
                  $scope.ChildrenList = lst.data.Children;
                  $scope.EmployeeSalaryDetails = lst.data.EmployeeSalaryStructureVw;

                  if (lst.data.EmployeeSalaryStructureVw.length!=0)
                  {
                      var salaryStructureId = lst.data.EmployeeSalaryStructureVw[0].SalaryStructureMasterId;
                      $scope.Entity.SalaryMasterId = salaryStructureId;
                      $scope.SalaryStructureDetailList = lst.data.EmployeeSalaryStructureVw;
                      $scope.Entity.BasicSalary = lst.data.EmployeeSalaryStructureVw[0].BasicSalary;
                      $scope.Entity.GrossSalary = lst.data.EmployeeSalaryStructureVw[0].GrossSalary;
                      $scope.Entity.TaxAmount = lst.data.EmployeeSalaryStructureVw[0].TaxAmount;
                      
                     // $("#salarySlabId").
                     // document.getElementById('#salarySlabId').disabled = true;

                     // $("#salarySlabMaster").hide();
                  }

                 
               

                

                //  $("#myProfileView").attr("src", "./UploadedFiles/" + $scope.Entity.ProfileImage);

                  $("#myProfileView").attr("src", "/UploadedFiles/" + $scope.Entity.ProfileImage);

                  $scope.Entity.JobType = String(lst.data.JobType);
                  $scope.Entity.ProbationPeriod = String(lst.data.ProbationPeriod);


                  
                //  var datan = JSON.stringify("Company List:" + JSON.stringify($scope.companyList));
                  if ($scope.Entity.Status == 1) {
                      $scope.Entity.Status = true;
                  } else {
                      $scope.Entity.Status = false;

                  }

                  if (lst.data.PermanentDate != null)
                  {
                      $scope.Entity.PermanentDate = new Date(parseInt(lst.data.PermanentDate.substr(6)));
                  }

                  if (lst.data.EmployeeDOB != null) {
                      $scope.Entity.EmployeeDOB = new Date(parseInt(lst.data.EmployeeDOB.substr(6)));
                  }


                  if (lst.data.JoiningDate != null) {
                      $scope.Entity.JoiningDate = new Date(parseInt(lst.data.JoiningDate.substr(6)));
                  }
                  
                
                //  console.log(datan);
                  $scope.pg = false;

              });









    }




    $scope.getCompanyData=function(Id)
    {

        

        $scope.Add = false;
        $scope.Update = true;

        kgchrmService.getCompamyListObj(Id)
              .then(function (lst) {

                  $scope.Entity = lst.data;
                  console.log(lst.data);
                  $scope.Entity.DateOfEstablish = new Date(parseInt(lst.data.DateOfEstablish.substr(6)));
                  var datan = JSON.stringify("Company List:" + JSON.stringify($scope.companyList));
                  if ($scope.Entity.Status == 1) {
                      $scope.Entity.Status = true;
                  } else {
                      $scope.Entity.Status = false;

                  }
                  console.log(datan);
                  $scope.pg = false;

              });






     
       

    }



    




    $scope.changeSalarySlap=function(Id)
    {
        $scope.GetSalaryStructureDetailList(Id);
    }

    
    $scope.SlabChange = function (Id) {
        alert(Id);

    }

    $(document.body).on("change", "#salarySlabId", function () {
        var data = this.value;
        var id = data.split(":")[1];

        var data = {
            Id: id,
            EmployeeId:0
        }
        $scope.GetSalaryStructureByEmployee(data);
    });


    $scope.changeGrossSallary=function(Entity)
    {
        var basicSalPercent = 0;
        $scope.SalaryStructureDetailList.forEach(function (item) {

           // var structureId = item[''];
            //var structureAmont = item[''];
            var structurePercent = item['PercentAmount'];

            item.Amount =Math.round( parseFloat(Entity.GrossSalary) * (structurePercent / 100)+ Number.EPSILON);

            basicSalPercent = item['BasicPercent'];
        });

        Entity.BasicSalary = Math.round(parseFloat(Entity.GrossSalary) * (basicSalPercent / 100));



    }

    $scope.GetSalaryStructureByEmployee = function (data) {





        kgchrmService.GetSalaryStructureByEmployee(data)
              .then(function (lst) {

                  $scope.SalaryStructureDetailList = lst.data;


              });



    }








    $scope.GetSalaryStructureDetailList = function (Id) {

        kgchrmService.GetSalaryStructureDetailList(Id)
              .then(function (lst) {

                  $scope.SalaryStructureDetailList = lst.data;
                

              });

    }


    $scope.getHeadQuaterList = function () {

        kgchrmService.getHeadQuaterList()
              .then(function (lst) {

                  $scope.HeadQuaterList = lst.data;


              });

    }

    
    $scope.getHeadQuaterList();


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

            $scope.Entity = $filter('filter')($scope.roleList, function (d) {
                return d.Id === id;
            })[0];
            if ($scope.Entity.Status == 1) {
                $scope.Entity.Status = true;
            } else {
                $scope.Entity.Status = false;

            }

    }


    else if (mode == 'UpdateStructure') {

        $scope.structureMasterId=id;
        $scope.GetSalaryStructureDetailList(id);
      

    }

        


    else if (mode == 'UpdateSalary') {
        $scope.Add = false;
        $scope.Update = true;
        $scope.title = title;
        $scope.Display = true;

        $scope.Entity = $filter('filter')($scope.salarySturctureList, function (d) {
            return d.Id === id;
        })[0];
        if ($scope.Entity.Status == 1) {
            $scope.Entity.Status = true;
        } else {
            $scope.Entity.Status = false;

        }


    }












    }




    $scope.geMenuList = function (Entity) {


        // var currentRoleId = parseInt(getCookie('role_id'));


        //   $('#currentRoleId').val();
        var currentRoleId = 1;
        /*    var data = {
            id:1
        }
        */
        var response = kgchrmService.getRolePermissionList(Entity);
        response.then(function (list) {

            $scope.menuDatas = [];
            $scope.menus = [];
            $scope.menuDatas = list.data;




            angular.forEach($scope.menuDatas, function (value, key) {
                if (value.ParentId == 0) {
                    $scope.menus.push(value);
                }
            });

            angular.forEach($scope.menuDatas, function (value, key) {
                if (value.Id != 0) {
                    angular.forEach($scope.menus, function (value2, key2) {
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

            console.log("Menu Peermission info:" + JSON.stringify($scope.menus));


        }, function () {
            alert('Error in getting records');
        });
    }








    $scope.pullRoleInformation = function (id) {

        $scope.geMenuList(id);


    }










    $scope.saveSalaryStructure = function (Entity) {


        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        if (model == true) {
            Entity.EntryUserId = getCookie('UserId');
            Entity.CompanyId = getCookie('CompanyId');

            kgchrmService.saveSalaryStructureInformation(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                $scope.GetSalaryStructureList();
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }

    

    $scope.SaveSallaryStructureDetail = function (Entity) {


        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        if (model == true) {
            Entity.EntryUserId = getCookie('UserId');
            Entity.CompanyId = getCookie('CompanyId');

            Entity.SallaryMasterId = $scope.structureMasterId;

            kgchrmService.SaveSallaryStructureDetail(Entity)
            .then(function (msg) {

                toastr.success(msg.data.message);

                $scope.GetSalaryStructureDetailList($scope.structureMasterId);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }



    $scope.UpdateSalaryStructure = function (Entity) {


        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        if (model == true) {
            Entity.EntryUserId = getCookie('UserId');
            Entity.CompanyId = getCookie('CompanyId');

            Entity.SallaryMasterId = $scope.structureMasterId;

            kgchrmService.UpdateSalaryStructure(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }
    




    $scope.ChangeIncrementAmount = function (Entity) {


        var incrementAmount = parseFloat(Entity.IncrementAmount);

        var incrementPercent = parseFloat((Entity.IncrementAmount / Entity.GrossSalary) * 100).toFixed(2);
        Entity.IncrementPercent = incrementPercent;


    }

 

    $scope.ChangeIncrementPercent = function (Entity) {


        var incrementPercent = parseFloat(Entity.IncrementPercent);

        var incrementAmount = parseFloat(Entity.GrossSalary * (Entity.IncrementPercent /100)).toFixed(2);
        Entity.IncrementAmount = incrementAmount;


    }






    
    $scope.UpdateSalaryStructureDetailList = function (Entity) {



            kgchrmService.UpdateSalaryStructureDetailList(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    


        $scope.saveRole= function (Entity) {

          
            var validation = $('#myform').validate();
         // '  var result = $("#new-form").validate();

            var model = $('#myform').valid();

            if (model == true)
            {

                kgchrmService.saveRoleInformation(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
            }

        }


        $scope.ProcessIncrement = function (Entity) {


         
            kgchrmService.ProcessIncrement(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
            

        }


        $scope.ProcessIncrements = function (Entity, obj) {

            var effectiveDate = $("#EffectiveDate").val();
            var activationDate = $("#ActivationDate").val();


            if (effectiveDate == "" || typeof effectiveDate === 'undefined') {
                toastr.error("Effective Date can not be empty!");
                return;
            }

            if (activationDate == "" || typeof activationDate === 'undefined') {
                toastr.error("Activation Date can not be empty!");
                return;
            }


            var dataObj={
                UserId: getCookie('UserId'),
                EffectiveDate: effectiveDate,
                ActivationDate: activationDate,
                listmodel:Entity,
            }

            kgchrmService.ProcessIncrements(dataObj)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);
                    
                });


        }




        $scope.ProcessPromotion = function (Entity) {

            Entity.DesignationPromotionTo = $('#DesignationPromotionTo :selected').val().split(":")[1];
            Entity.TransferCompanyId = $('#TransferCompanyId :selected').val().split(":")[1];

            kgchrmService.ProcessPromotion(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });


        }


     



        


        


       //$scope.saveSalaryStructure= function (Entity) {


       //     var validation = $('#myform').validate();
       //  // '  var result = $("#new-form").validate();

       //     var model = $('#myform').valid();

       //     if (model == true)
       //     {

       //         kgchrmService.saveRoleInformation(Entity)
       //         .then(function (msg) {

       //             toastr.success(msg.data);
       //             // $scope.getComponentGroups();

       //         }, function (error) {
       //             toastr.error(error);

       //         });
       //     }

       // }




    






    $scope.updateCompanyInformation = function (Entity) {

        Entity.ParentCompanyId = $('#ParentCompanyId').val().split(":")[1];
        //$('#ParentCompanyId :selected').val();

        var validation = $('#myform').validate();


        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        if (model == true) {

            kgchrmService.updateCompanyInformation(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);

                    getDataShow();
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
        }

    }

        $scope.saveCompanyInformation = function (Entity) {

            Entity.ParentCompanyId = $('#ParentCompanyId').val().split(":")[1];
                //$('#ParentCompanyId :selected').val();
          
            var validation = $('#myform').validate();

      
            // '  var result = $("#new-form").validate();

            var model = $('#myform').valid();

            if (model == true) {

                kgchrmService.saveCompanyInformation(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);

                      getDataShow();
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
            }

        }





        $scope.updateRole = function (Entity) {


            var validation = $('#myform').validate();
            // '  var result = $("#new-form").validate();
            var model = $('#myform').valid();

            if (model == true) {

                kgchrmService.updateRoleInformation(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
            }

        }




        $scope.UpdateSallaryStructure = function (Entity) {


            var validation = $('#myform').validate();
            // '  var result = $("#new-form").validate();
            var model = $('#myform').valid();

            if (model == true) {

                kgchrmService.UpdateSallaryStructure(Entity)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
            }

        }


        





        $scope.SaveUpdatePermission = function (Entity) {


            //var validation = $('#myform').validate();
            // '  var result = $("#new-form").validate();
            // var model = $('#myform').valid();




            $scope.permissions = [];

            var id = 0;
            $.each(Entity, function (key, value) {


                var data = {
                    Id: value.MenuId,
                    MenuId: value.MenuId,
                    MenuName: value.MenuName,
                    RoleId: value.RoleId,
                   
                    Status: value.Status
                }
                $scope.permissions.push(data);
                data = {};


                $.each(value.children, function (k, v) { // The contents inside stars


                    var datan = {
                        Id: v.MenuId,
                        MenuId: v.MenuId,
                        MenuName: v.MenuName,
                        RoleId: v.RoleId,

                        Status: v.Status
                    }
                    $scope.permissions.push(datan);
                    datan = {};
                
                });
                id++;

            });





          

            kgchrmService.SaveUpdatePermission($scope.permissions)
                .then(function (msg) {

                    toastr.success(msg.data);
                    // $scope.getComponentGroups();

                }, function (error) {
                    toastr.error(error);

                });
            

        }




        




     






        $scope.AllIncrementChange = function (Entity) {
            // $scope.IsAllChecked = true;

            for (var i = 0; i < $scope.employeePromotionList.length; i++) {

                $scope.employeePromotionList[i].IncrementPercent = parseFloat(Entity);

                $scope.employeePromotionList[i].IncrementAmount = $scope.employeePromotionList[i].GrossSalary * parseFloat($scope.employeePromotionList[i].IncrementPercent / 100);

            }

        };


        $scope.CheckUncheckHeader = function () {
            // $scope.IsAllChecked = true;

            if ($scope.IsAllChecked) {
                for (var i = 0; i < $scope.employeePromotionList.length; i++) {

                    $scope.employeePromotionList[i].isSelected = true;

                }

            } else {
                for (var i = 0; i < $scope.employeePromotionList.length; i++) {

                    $scope.employeePromotionList[i].isSelected = false;

                }


            }

        };



        $scope.GetEmployeeListSearch = function (Entity) {
            $scope.pg = true;

            Entity.CompanyId = $('#CompanyId :selected').val().split(":")[1];
            Entity.DepartmentId = $('#DepartmentId :selected').val().split(":")[1];
            Entity.DesignationId = $('#DesignationId :selected').val().split(":")[1];

            var data = {
                EmployeeCode: Entity.Code,
                CompanyId: Entity.CompanyId,
                DepartmentId: Entity.DepartmentId,
                DesignationId: Entity.DesignationId,

            };
            kgchrmService.GetEmployeeListSearch(data)
                .then(function (lst) {

                    $scope.employeePromotionList = lst.data;
                    var datan = JSON.stringify($scope.employeePromotionList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }



        $scope.GetEmployeeListSearchObj = function (Entity) {
            $scope.pg = true;

          

            var data = {
                EmployeeCode: Entity.EmployeeCode,
             

            };
            kgchrmService.GetEmployeeListSearch(data)
                .then(function (lst) {

                    $scope.Entity = lst.data[0];
                   // var datan = JSON.stringify($scope.employeePromotionList);
                  //  console.log(datan);
                    $scope.pg = false;

                });
        }





        $scope.AttendenceLocationList = function () {
            $scope.pg = true;

            kgchrmService.AttendenceLocationList(null)
                .then(function (lst) {

                    $scope.attendenceLocationList = lst.data;
                    var datan = JSON.stringify($scope.attendenceLocationList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.AttendenceLocationList();



        $scope.getDesignationList = function () {
            $scope.pg = true;

            kgchrmService.getDesignationList(null)
                .then(function (lst) {

                    $scope.designationList = lst.data;
                    var datan = JSON.stringify($scope.designationList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getDesignationList();



    
        $scope.getMyAttendence = function () {
            $scope.pg = true;

            var data = {
                EmployeeCode:getCookie('UserId')
            }

            kgchrmService.getMyAttendence(data)
                .then(function (lst) {

                    $scope.attendenceList = lst.data;
                    var datan = JSON.stringify($scope.attendenceList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getMyAttendence();





        $scope.getGradeList = function () {
            $scope.pg = true;

            kgchrmService.getGradeList(null)
                .then(function (lst) {

                    $scope.gradeList = lst.data;
                    var datan = JSON.stringify($scope.gradeList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.getGradeList();


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


        $scope.getEmployeeList();





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



        $scope.getDepartmentList = function () {
            $scope.pg = true;

            kgchrmService.getDepartmentList(null)
                .then(function (lst) {

                    $scope.departmentList = lst.data;
                    var datan = JSON.stringify($scope.departmentList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }

        
        $scope.getDepartmentList();

        $scope.GetRoleList = function () {
            $scope.pg = true;

            kgchrmService.getRoleList()
                .then(function (lst) {

                    $scope.roleList = lst.data;
                    var datan = JSON.stringify($scope.roleList);
                    console.log(datan);
                    $scope.pg = false;

                });
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


        $scope.GetSalaryStructureList = function () {
            $scope.pg = true;

            kgchrmService.GetSalaryStructureList()
                .then(function (lst) {

                    $scope.salarySturctureList = lst.data;
                    var datan = JSON.stringify($scope.roleList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }


        $scope.GetSalaryStructureList();
         

        $scope.getCompanyList = function () {
            $scope.pg = true;

            kgchrmService.getCompanyList()
                .then(function (lst) {

                    $scope.companyList = lst.data;
                    var datan = JSON.stringify("Company List:"+ JSON.stringify($scope.companyList));
                    console.log(datan);
                    $scope.pg = false;

                });
        }



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


        $scope.ShiftList();
        








       $scope.addEducation = function(Entity) {

      
        var $elOrganization = $("#organization_id");



        var item = {
            Institue: Entity.Institue,
            AcademicYear: Entity.AcademicYear,
            Degree: Entity.Degree,
            PassingYear: Entity.PassingYear,
            Division: Entity.Division,

        }



        $scope.educationList.push(item);

    
        console.log($scope.educationList);

    }



    $scope.removeEducation = function(degree) {

        $scope.educationList = $filter('filter')($scope.educationList, function(item) {
            return !(item == degree);
        });


    }









    
       $scope.addJobExperience = function(Entity) {

      
       // var $elOrganization = $("#organization_id");



        var item = {
            Organization: Entity.Organization,
            JobDuration: Entity.JobDuration,
            Designation: Entity.Designation,
            Salary: Entity.Salary,
            Reason: Entity.Reason,

        }



        $scope.jobExperienceList.push(item);

    
        console.log($scope.jobExperienceList);

    }



    $scope.removeJobExperience = function(Entity) {

        $scope.jobExperienceList = $filter('filter')($scope.jobExperienceList, function (item) {
            return !(item == Entity);
        });


    }







    $scope.addNominee = function (Entity) {


        // var $elOrganization = $("#organization_id");



        var item = {
            NomineeName: Entity.NomineeName,
            NomineeAddress: Entity.NomineeAddress,
            Relation: Entity.Relation,
           

        }



        $scope.NomineeList.push(item);


        console.log($scope.NomineeList);

    }



    $scope.removeNominee = function (Entity) {

        $scope.NomineeList = $filter('filter')($scope.NomineeList, function (item) {
            return !(item == Entity);
        });


    }








    $scope.addChildren = function (Entity) {


        // var $elOrganization = $("#organization_id");



        var item = {
            ChildrenName: Entity.ChildrenName,
            ChildrenBirthDate: Entity.ChildrenBirthDate,
        


        }



        $scope.ChildrenList.push(item);


        console.log($scope.ChildrenList);

    }



    $scope.removeChildren= function (Entity) {

        $scope.ChildrenList = $filter('filter')($scope.ChildrenList, function (item) {
            return !(item == Entity);
        });


    }






















    function getDataShow() {


        var baseURL_API = "http://localhost:63777/";
        //  $('#data-table-info').DataTable();
        $('#data-table-info').DataTable().destroy();

        var data = null;
        var i = 1;
        $.ajax({
            url: "/Admin/CompanyList",
            type: 'GET',
            success: function (data) {
                console.log(data);

                $('#data-table-info').DataTable({
                    "aaData": data,
                    "aoColumns": [{
                        "mRender": function (data, type, full, meta) {
                            return i++;
                        }
                    },

                     {
                        "mDataProp": "Code",
                        "width": "5%"
                    },

                    {
                        "mDataProp": "Name",
                        "width": "30%"
                    },

                    {
                        "mDataProp": "CompanyType",
                        "width": "20%"
                    },
                    {
                        "mDataProp": "Address",
                        "width": "20%"
                    },
                    {
                        "mDataProp": "Status",
                        "width": "5%",
                        "mRender": function (data, type, row) {
                            if (row.Status == 1) {
                                return '<div class="badge rounded-pill bg-light-success text-success w-100">Active</div>';
                            } else {
                                return '<div class="badge rounded-pill bg-light-danger text-danger w-100 ">Closed</div>';
                            }
                        }
                    },


                    {
                        "mData": "action",
                        "mRender": function (data, type, row) {

                            var res = '<a onclick="getEditData(' + row.Id + ', \'' + row.name + '\');" href="javascrip:;" class="btn btn-sm btn-primary" title="Edit"><i class="bx bx-edit"></i></a>\n\
                                        <a onclick="getResumeData(' + row.id + ', \'' + row.patient_code + '\');" href="javascrip:;" class="btn btn-sm btn-icon btn-rounded btn-outline-danger" title="Resume"><i class="bx bx-comment-check"></i></a>';
                            return res;
                        }
                    },]

                });

            }
        });
    }

    function getResumeData(id, name) {
        //  $('#mode').val("Update");
        //  $('#exampleExtraLargeModal').modal('show');



        window.open("/Reports/EmployeeCv.aspx?employee_code=" + id, '_blank', 'height=800,width=1000');




        // angular.element(document.getElementById('divID')).scope().getEmployeeData(id);


    }





 



        $scope.getRolePermissionList = function (Entity) {
            $scope.pg = true;

            kgchrmService.getRolePermissionList(Entity)
                .then(function (lst) {

                    $scope.rolePermissionList = lst.data;
                    var datan = JSON.stringify($scope.rolePermissionList);
                    console.log(datan);
                    $scope.pg = false;

                });
        }

        




        $scope.GetRoleList();

        $scope.getCompanyList();


    $scope.savePermissions = function () {


        var data = {
            CompanyId: 1,
            UserId: 2,
            Permissions: [
                { "RoleId": 1, "Status": 0 },
                { "RoleId": 1, "Status": 1}
            ]
        }

        kgchrmService.saveRole(data)
            .then(function (msg) {

                toastr.success("Component List" + msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
    }




    
    $scope.init = function() {



        getDataShow();

      //  $(".select21").select2();

      /*  $(".tag").select2({
            tags: true
        });
        */



    }


}


angular.module('myApps')
        .controller('KGCHRMController', KGCHRMController);