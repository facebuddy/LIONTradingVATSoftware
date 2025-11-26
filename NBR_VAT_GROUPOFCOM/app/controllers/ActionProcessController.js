'use strict';
var ActionProcessController = function ($scope, $filter, $log, kgchrmService) {

    $scope.Entity = {};
    $scope.data = [
        {"name": "John", "location": "Boston"},
        {"name": "Dave", "location": "Lancaster"}
    ];




    $scope.yearsFinancial = [
     { "id": "2019-2020", "name": "2019-2020" },
     { "id": "2020-2021", "name": "2020-2021" },
     { "id": "2021-2022", "name": "2021-2022" },
     { "id": "2022-2023", "name": "2022-2023" },
       { "id": "2023-2024", "name": "2023-2024" },
    ];










    $scope.title = null;
    $scope.message = "Asib AL aMIN";

    $scope.loanlist = [];

    $scope.loanlistPF = [];

    $scope.PFOpeninglist = [];

    $scope.pogress = false;

    $scope.EmployeeListLock = [];
    $scope.BonusPaymentTypeList = [];


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
    
    
        else if (mode == 'Approve') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;

            $scope.Entity = {};

            $scope.Entity = $filter('filter')($scope.loanlist, function (d) {
                return d.Id === id;
            })[0];
            $scope.Entity.GrantedLoanAmount = 0;

        }


        else if (mode == 'ApprovePF') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;

            $scope.Entity = {};

            $scope.Entity = $filter('filter')($scope.loanlistPF, function (d) {
                return d.Id === id;
            })[0];
            $scope.Entity.GrantedLoanAmount = 0;

        }




        else if (mode == 'UpdateOpening') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;

            $scope.Entity = {};

            $scope.Entity = $filter('filter')($scope.PFOpeninglist, function (d) {
                return d.Id === id;
            })[0];
           // $scope.Entity.GrantedLoanAmount = 0;

        }


        else if (mode == 'Payment') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;
            $scope.Entity = {};
            $scope.Entity = $filter('filter')($scope.loanlist, function (d) {
                return d.Id === id;
            })[0];

          


        }


        else if (mode == 'PaymentPF') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;
            $scope.Entity = {};
            $scope.Entity = $filter('filter')($scope.loanlistPF, function (d) {
                return d.Id === id;
            })[0];




        }


        
        







    }




    function isEmpty(val) {
        return (val === undefined || val == null || val.length <= 0) ? true : false;
    }













    $scope.ChangeInstallmentAmount=function(Entity)
    {
        Entity.InstallmentAmount = parseFloat(parseFloat(Entity.GrantedLoanAmount) / parseFloat(Entity.NumberOfInstallment));
    }
    


      $scope.GetLoanApplicationList = function () {
            $scope.pg = true;

          kgchrmService.GetLoanApplicationList()
                .then(function (lst) {

                    $scope.loanlist = lst.data;
                 

                });
      }

      $scope.SearchEmployeeLock = function (EmployeeCode) {
          $scope.pg = true;
          var data = {
              employeePin:EmployeeCode
          }
          kgchrmService.SearchEmployeeLock(data)
                .then(function (lst) {

                    $scope.EmployeeListLock = lst.data;


                });
      }


      




      $scope.GetLoanApplicationListPF = function () {
          $scope.pg = true;

          kgchrmService.GetLoanApplicationListPF()
                .then(function (lst) {

                    $scope.loanlistPF = lst.data;


                });
      }


      $scope.GetLoanApplicationListPF();

    
   

      $scope.SaveLoanApprove = function (Entity) {

          Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          // '  var result = $("#new-form").validate();

        //  var model = $('#loanApproval').valid();

        //  if (model == true) {

              kgchrmService.SaveLoanApprove(Entity)
              .then(function (msg) {

                  toastr.success(msg.data);
                  // $scope.getComponentGroups();

              }, function (error) {
                  toastr.error(error);

              });
      }






      $scope.SaveSalaryProcess = function (Entity) {

          $scope.pogress = true;
       
        
        //  Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.processSalary(Entity)
          .then(function (msg) {

              $scope.pogress = false;

              toastr.success(msg.data);
            

          }, function (error) {
              toastr.error(error);
              $scope.pogress = false;

          });
      }












      $scope.ProcessLeaveEncashment = function (Entity) {

          $scope.pogress = true;

          var data = {
              year: Entity.YearId
          }
       
       
          kgchrmService.processLeaveEncashment(data)
          .then(function (msg) {

              $scope.pogress = false;

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);
              $scope.pogress = false;

          });
      }











      $scope.SaveLoanProcess = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.processLoanSys(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }




      $scope.SavePFLoanProcess = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.ImportPFOpeningLoan(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }





      $scope.ImportLeaveOpeningLoan = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.ImportLeaveOpeningLoan(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }






      







      $scope.ImportTasHistory = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.ImportTasHistory(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }




      $scope.ImportTAXCHALANNO = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.ImportTAXCHALANNO(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }



      $scope.SaveSalaryCertificate = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
         // var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
        //  Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.processSalaryCertificate(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }









      $scope.SalaryCertificate = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
         // var validation = $('#loanApproval').validate();
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.processSalary(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }











      $scope.processTAX = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');
       
          Entity.file = document.getElementById('file').files[0];
          Entity.SallaryDate = $('#SallaryDate').val();
          kgchrmService.processTAX(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }


      $scope.saveProcessLockEmployee = function (Entity) {

          //  Entity.EntryUserId = getCookie('UserId');

        
          kgchrmService.saveProcessLockEmployee(Entity)
          .then(function (msg) {

              toastr.success(msg.data);


          }, function (error) {
              toastr.error(error);

          });
      }


      

      

      $scope.BonusSalaryProcess = function (Entity) {

          Entity.EntryUserId = getCookie('UserId');


          var bonusTypeLr = $('#BonusType').val().split(":")[1];

          var bonusType = isEmpty(bonusTypeLr);


        if (bonusType == false)
        {
            //  var validation = $('#loanApproval').validate();
            Entity.file = document.getElementById('file').files[0];
            Entity.SallaryDate = $('#SallaryDate').val();
            Entity.BonusType = parseInt(bonusTypeLr);
            kgchrmService.processBonus(Entity)
            .then(function (msg) {

                toastr.success(msg.data);


            }, function (error) {
                toastr.error(error);

            });
        }
        else {
            toastr.error("Please Select Bonus Type");
        }



      
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


      $scope.SaveLoanApprovePF = function (Entity) {

          Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          // '  var result = $("#new-form").validate();

          //  var model = $('#loanApproval').valid();

          //  if (model == true) {

          kgchrmService.SaveLoanApprovePF(Entity)
          .then(function (msg) {

              toastr.success(msg.data);
              // $scope.getComponentGroups();

          }, function (error) {
              toastr.error(error);

          });
      }









     // }
    
      $scope.SaveOpeningBalancePF = function (Entity) {

         // Entity.EntryUserId = getCookie('UserId');
          var validation = $('#myform').validate();
          // '  var result = $("#new-form").validate();
          Entity.EntryUserId = getCookie('UserId');
          Entity.OpeningType = $('#OpeningType').val();
          var model = $('#myform').valid();

           if (model == true) {

               kgchrmService.SaveOpeningBalancePF(Entity)
               .then(function (msg) {

                   toastr.success(msg.data);

                   $scope.GetLoanApplicationListPF();
                   // $scope.getComponentGroups();

               }, function (error) {
                   toastr.error(error);

               });
           }
      }

      



      $scope.saveLoanPayment = function (Entity) {

          Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          // '  var result = $("#new-form").validate();

          //  var model = $('#loanApproval').valid();

          //  if (model == true) {

          kgchrmService.saveLoanPayment(Entity)
          .then(function (msg) {
            
              toastr.success(msg.data);
              // $scope.getComponentGroups();

          }, function (error) {
              toastr.error(error);

          });
    }

      


      $scope.saveLoanPaymentPF = function (Entity) {

          Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          // '  var result = $("#new-form").validate();

          //  var model = $('#loanApproval').valid();

          //  if (model == true) {

          kgchrmService.saveLoanPaymentPF(Entity)
          .then(function (msg) {

              toastr.success(msg.data);
              $scope.GetLoanApplicationListSearchPF(Entity.EmployeeCode);
              // $scope.getComponentGroups();

          }, function (error) {
              toastr.error(error);

          });
      }






      $scope.GetLoanApplicationList();

    $scope.saveLoanApplication = function (Entity) {

        Entity.EntryUserId = getCookie('UserId');
        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        if (model == true) {

            kgchrmService.saveLoanApplication(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }









     $scope.saveLoanApplicationPF = function (Entity) {

        Entity.EntryUserId = getCookie('UserId');
        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        if (model == true) {

            kgchrmService.saveLoanApplicationPF(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }











    $scope.UpdateOpeningBalancePF = function (Entity) {

        Entity.EntryUserId = getCookie('UserId');
        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        Entity.OpeningType = $('#OpeningType').val();

        if (model == true) {

            kgchrmService.UpdateOpeningBalancePF(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }







    











    $scope.ChangeEmployeeCode=function(code)
    {
        var data={EmployeeCode:code};
        kgchrmService.SearchEmployee(data)
              .then(function (lst) {

                  $scope.Entity = lst.data;
                 

              });
    }



    $scope.GetLoanApplicationListSearch = function (EmployeeCode) {
        $scope.pg = true;

        kgchrmService.GetLoanApplicationListSearch(EmployeeCode)
            .then(function (lst) {

                $scope.loanlist = lst.data;
             
                $scope.pg = false;

            });
    }




    $scope.GetLoanApplicationListSearchPF = function (EmployeeCode) {
        $scope.pg = true;

        kgchrmService.GetLoanApplicationListSearchPF(EmployeeCode)
            .then(function (lst) {

                $scope.loanlistPF = lst.data;

                $scope.pg = false;

            });
    }



    $scope.PFOpeningSearch = function (EmployeeCode) {
        $scope.pg = true;

        kgchrmService.GetPFOpeningListSearch(EmployeeCode)
            .then(function (lst) {

                $scope.PFOpeninglist = lst.data;

                $scope.pg = false;

            });
    }





 


    $scope.SearchEmployee = function (Id) {



        $scope.Add = false;
        $scope.Update = true;

      



    }
  

    
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
        .controller('ActionProcessController', ActionProcessController);