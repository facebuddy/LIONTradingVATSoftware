'use strict';
var LoanController = function ($scope, $filter, $log, kgchrmService) {


    $scope.Entity = {};
    $scope.data = [
        {"name": "John", "location": "Boston"},
        {"name": "Dave", "location": "Lancaster"}
    ];

    $scope.title = null;
    $scope.message = "Asib AL aMIN";

    $scope.loanlist = [];

   // $scope.loanlistPF = [];

    $scope.PFOpeninglist = [];


    $scope.Installmentlist = [];

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
           // $scope.Entity.GrantedLoanAmount = 0;

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



        else if (mode == 'UpdateInstallment') {
            $scope.Add = false;
            $scope.Update = true;
            $scope.title = title;
            $scope.Display = true;

            $scope.Entity = {};

            $scope.Entity = $filter('filter')($scope.Installmentlist, function (d) {
                return d.Id === id;
            })[0];

            var loanType = $scope.Entity.LoanType;
            $("#LoanType").select2("val", loanType);





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

    $scope.ChangeInstallmentAmount=function(Entity)
    {
        Entity.InstallmentAmount = parseFloat(parseFloat(Entity.GrantedLoanAmount) / parseFloat(Entity.NumberOfInstallment));

        Entity.CurrentInstallment = Entity.InstallmentAmount + Entity.PreviousInstallment;
    }
    


      $scope.GetLoanApplicationList = function () {
            $scope.pg = true;

          kgchrmService.GetLoanApplicationList()
                .then(function (lst) {

                    $scope.loanlist = lst.data;
                 

                });
      }






      $scope.GetLoanApplicationListPF = function () {
          $scope.pg = true;

          kgchrmService.GetLoanApplicationListPF()
                .then(function (lst) {

                    $scope.loanlistPF = lst.data;


                });
      }


    //  $scope.GetLoanApplicationListPF();

    
   

      $scope.SaveLoanApprove = function (Entity) {

          Entity.EntryUserId = getCookie('UserId');
          var validation = $('#loanApproval').validate();
          // '  var result = $("#new-form").validate();

        //  var model = $('#loanApproval').valid();

        //  if (model == true) {

              kgchrmService.SaveLoanApprove(Entity)
              .then(function (msg) {

                  toastr.success(msg.data);
                  $scope.GetLoanApplicationList();
                  // $scope.getComponentGroups();

              }, function (error) {
                  toastr.error(error);

              });
      }






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
              $scope.GetLoanApplicationListPF();

          }, function (error) {
              toastr.error(error);

          });
      }









    // }






      $scope.SaveInstallment = function (Entity) {

         // Entity.EntryUserId = getCookie('UserId');
        //  var validation = $('#myform').validate();
          // '  var result = $("#new-form").validate();
          Entity.EntryUserId = getCookie('UserId');
          Entity.LoanType = $('#LoanType').val();
          var model = $('#myform').valid();

           if (model == true) {

               kgchrmService.SaveInstallment(Entity)
               .then(function (msg) {

                   toastr.success(msg.data);

                //   $scope.GetLoanApplicationListPF();
                   // $scope.getComponentGroups();

               }, function (error) {
                   toastr.error(error);

               });
           }
      }







      $scope.SaveOpeningLoan = function (Entity) {

          // Entity.EntryUserId = getCookie('UserId');
          //  var validation = $('#myform').validate();
          // '  var result = $("#new-form").validate();
          Entity.EntryUserId = getCookie('UserId');
          //Entity.LoanType = $('#LoanType').val();
          var model = $('#myform').valid();

          if (model == true) {

              kgchrmService.SaveOpeningLoan(Entity)
              .then(function (msg) {

                  toastr.success(msg.data);

                  //   $scope.GetLoanApplicationListPF();
                  // $scope.getComponentGroups();

              }, function (error) {
                  toastr.error(error);

              });
          }
      }





      $scope.UpdateOpeningLoan = function (Entity) {

          // Entity.EntryUserId = getCookie('UserId');
          //  var validation = $('#myform').validate();
          // '  var result = $("#new-form").validate();
          Entity.EntryUserId = getCookie('UserId');
          //Entity.LoanType = $('#LoanType').val();
          var model = $('#myform').valid();

          if (model == true) {

              kgchrmService.UpdateOpeningLoan(Entity)
              .then(function (msg) {

                  toastr.success(msg.data);

                  //   $scope.GetLoanApplicationListPF();
                  // $scope.getComponentGroups();

              }, function (error) {
                  toastr.error(error);

              });
          }
      }

      


    
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
              $scope.GetLoanApplicationList();

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
              $scope.GetLoanApplicationListPF();
              // $scope.getComponentGroups();

          }, function (error) {
              toastr.error(error);

          });
      }






    //  $scope.GetLoanApplicationList();

    $scope.saveLoanApplication = function (Entity) {

        Entity.EntryUserId = getCookie('UserId');
        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        if (model == true) {

            kgchrmService.saveLoanApplication(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                $scope.GetLoanApplicationList();
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }







    $scope.saveWithraw = function (Entity, event) {

      Entity.EntryUserId = getCookie('UserId');
      //  var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        if (Entity.WithdrawAmount > Entity.PreviousLoan)
        {
            toastr.error("Withdraw amount can not be greater PF Amount!");
            return;
        }


        if (typeof Entity.WithdrawAmount !== 'undefined')
        {
            
            kgchrmService.WithdrawPFAmount(Entity)
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








    $scope.UpdateInstallment = function (Entity) {

        Entity.EntryUserId = getCookie('UserId');
        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        Entity.LoanType = $('#LoanType').val();

        if (model == true) {

            kgchrmService.UpdateInstallment(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }












    $scope.UpdateInstallment = function (Entity) {

        Entity.EntryUserId = getCookie('UserId');
        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

        Entity.LoanType = $('#LoanType').val();

        if (model == true) {

            kgchrmService.UpdateInstallment(Entity)
            .then(function (msg) {

                toastr.success(msg.data);
                // $scope.getComponentGroups();

            }, function (error) {
                toastr.error(error);

            });
        }

    }




    $scope.UpdateOpeningLoan = function (Entity) {

        Entity.EntryUserId = getCookie('UserId');
        var validation = $('#myform').validate();
        // '  var result = $("#new-form").validate();

        var model = $('#myform').valid();

     //   Entity.LoanType = $('#LoanType').val();

        if (model == true) {

            kgchrmService.UpdateOpeningLoan(Entity)
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


    $scope.ChangeEmployeeCodePF = function (code) {
        var data = { EmployeeCode: code };
        kgchrmService.SearchEmployeeChangePF(data)
              .then(function (lst) {

                  $scope.Entity = lst.data;


              });
    }


    $scope.ChangeWithdrawPF = function (code) {
        var data = { EmployeeCode: code };
        kgchrmService.SearcWitdrawPF(data)
              .then(function (lst) {

                  $scope.Entity = lst.data;


              });
    }





    $scope.ChangeEmployeeCodeInstallment = function (code) {
        var data = { EmployeeCode: code };
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


    $scope.SearchEmployeePF = function (EmployeeCode) {
        $scope.pg = true;

        kgchrmService.SearchEmployeePF(EmployeeCode)
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


    $scope.LoanInstallmentSearch = function (EmployeeCode) {
        $scope.pg = true;

        kgchrmService.GetLoanInstallmentListSearch(EmployeeCode)
            .then(function (lst) {

                $scope.Installmentlist = lst.data;

                $scope.pg = false;

            });
    }




    $scope.OpeningLoanSearch = function (EmployeeCode) {
        $scope.pg = true;

        kgchrmService.OpeningLoanSearch(EmployeeCode)
            .then(function (lst) {

                $scope.Installmentlist = lst.data;

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
        .controller('LoanController', LoanController);