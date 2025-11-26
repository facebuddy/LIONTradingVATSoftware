var kgchrmService = function (akFileUploaderService, $http) {

 var baseUrl = "http://localhost:63777/";
  var baseUrlService = "http://127.0.0.1:8000/";
   // var baseUrl = "";
  //  var baseUrlService = "";

 // var baseUrl = "http://hrm.time-zone.biz/";
  // var baseUrlService = "http://hrm.time-zone.biz/";



  var deleteSalary = function (Entity) {
      return akFileUploaderService.saveModel(Entity, "/Action/DeleteSallary");

   };


   var processSalary = function (Entity) {
       return akFileUploaderService.saveModel(Entity, "/Action/ImportSallary");

   };




  var processLoanSys = function (Entity) {
      return akFileUploaderService.saveModel(Entity, "/Action/ImportOpeningLoan");

  };



  var ImportPFOpeningLoan = function (Entity) {
      return akFileUploaderService.saveModel(Entity, "/Action/ImportPFOpeningLoan");

  };


  var ImportLeaveOpeningLoan = function (Entity) {
      return akFileUploaderService.saveModel(Entity, "/Action/ImportOpeningLeave");

  };
  


  var ImportTaxHistoryChalanNo = function (Entity) {
      return akFileUploaderService.saveModel(Entity, "/Action/ImportSalaryTaxCettifcateNew");

  };


  var ImportTasHistory = function (Entity) {
      return akFileUploaderService.saveModel(Entity, "/Action/ImportTaxCettifcateHistory");

  };



  var ImportTAXCHALANNO = function (Entity) {
      return akFileUploaderService.saveModel(Entity, "/Action/ImportSalaryTaxCettifcateNew");

  };



   var processSalaryCertificate = function (Entity) {
       return akFileUploaderService.saveModel(Entity, "/Action/ImportSalaryTaxCettifcate");

   };






   var processLeaveEncashment = function (Entity) {
       return akFileUploaderService.saveModel(Entity, "/Action/ProcessLeaveEncashment");

   };









   var processTAX = function (Entity) {
       return akFileUploaderService.saveModel(Entity, "/Action/ImportTax");

   };


   var processBonus = function (Entity) {
       return akFileUploaderService.saveModel(Entity, "/Action/ImportBonus");

   };





   var getLeaveEmployeeObj = function (Entity) {
       return $http({
           method: 'POST',
           data: Entity,
           url: baseUrl + 'LeaveManagement/getLeaveApplicationObj',
           headers: { 'Content-Type': 'application/json;charset=utf-8' }
       });
   };


   var saveSalaryStructureInformation = function (Entity) {
       return $http({
           method: 'POST',
           data: Entity,
           url: baseUrl + 'Sallary/SaveSallaryStructure',
           headers: { 'Content-Type': 'application/json;charset=utf-8' }
       });
   };

   var GetEmployeeListSearch = function (Entity) {
       return $http({
           method: 'POST',
           data: Entity,
           url: baseUrl + 'Promotion/GetEmployeeListSearch',
           headers: { 'Content-Type': 'application/json;charset=utf-8' }
       });
   };



 
   var saveProcessLockEmployee = function (Entity) {
       return $http({
           method: 'POST',
           data: Entity,
           url: baseUrl + 'Utility/ProcessEmpoyeeLock',
           headers: { 'Content-Type': 'application/json;charset=utf-8' }
       });
   };

   


    var saveRoleInformation = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Utility/SaveRole',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };


      var getMyAttendence = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Report/AttendenceRport',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };



    var saveCompanyInformation = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Admin/AddNewCompany',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };





    var saveMobileInfo = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Common/SaveMobileInfo',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };



    var UpdateMobileInfo = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Common/UpdateMobileInfo',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };








    var updateCompanyInformation = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Admin/UpdateCompany',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };

    var updateRoleInformation = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Utility/UpdateRole',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };




    var UpdateSalaryStructureDetailList = function (Entity) {
        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + 'Sallary/UpdateSalaryStructureDetailList',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });
    };






    var saveRole = function (Entity) {




        return $http({
            url: "/Home/Test",
            dataType: 'json',
            method: 'POST',
            data: Entity,
            headers: {
                "Content-Type": "application/json"
            }
        })




       // return akFileUploaderService.saveModel(Entity, baseUrl + "Test");

    };


 var saveLoanApplication = function (Entity) {

        return $http({
            url: "/Loan/SaveLoanApplication",
            dataType: 'json',
            method: 'POST',
            data: Entity,
            headers: {
                "Content-Type": "application/json"
            }
        })


 };



 var saveLoanApplicationPF = function (Entity) {

     return $http({
         url: "/Loan/SaveLoanApplicationPF",
         dataType: 'json',
         method: 'POST',
         data: Entity,
         headers: {
             "Content-Type": "application/json"
         }
     })


 };


 var WithdrawPFAmount = function (Entity) {

     return $http({
         url: "/Loan/WithdrawPFAmount",
         dataType: 'json',
         method: 'POST',
         data: Entity,
         headers: {
             "Content-Type": "application/json"
         }
     })


 };









  var SaveOpeningBalancePF = function (Entity) {

        return $http({
            url: "/ProvidentFund/SaveOpeningBalancePF",
            dataType: 'json',
            method: 'POST',
            data: Entity,
            headers: {
                "Content-Type": "application/json"
            }
        })


  };





  var SaveInstallment = function (Entity) {

      return $http({
          url: "/ProvidentFund/SaveInstallment",
          dataType: 'json',
          method: 'POST',
          data: Entity,
          headers: {
              "Content-Type": "application/json"
          }
      })


  };






  var SaveOpeningLoan = function (Entity) {

      return $http({
          url: "/ProvidentFund/SaveOpeningLoanBalance",
          dataType: 'json',
          method: 'POST',
          data: Entity,
          headers: {
              "Content-Type": "application/json"
          }
      })


  };
 



  var UpdateOpeningBalancePF = function (Entity) {

      return $http({
          url: "/ProvidentFund/UpdateOpeningBalancePF",
          dataType: 'json',
          method: 'POST',
          data: Entity,
          headers: {
              "Content-Type": "application/json"
          }
      })


  };


 

  var UpdateInstallment = function (Entity) {

      return $http({
          url: "/ProvidentFund/UpdateInstallment",
          dataType: 'json',
          method: 'POST',
          data: Entity,
          headers: {
              "Content-Type": "application/json"
          }
      })


  };



  var UpdateOpeningLoan = function (Entity) {

      return $http({
          url: "/ProvidentFund/UpdateOpeningLoan",
          dataType: 'json',
          method: 'POST',
          data: Entity,
          headers: {
              "Content-Type": "application/json"
          }
      })


  };







 var saveLoanPayment = function (Entity) {




     return $http({
         url: "/Loan/SaveLoanPayment",
         dataType: 'json',
         method: 'POST',
         data: Entity,
         headers: {
             "Content-Type": "application/json"
         }
     });


 };




 var saveLoanPaymentPF = function (Entity) {




     return $http({
         url: "/Loan/SaveLoanPaymentPF",
         dataType: 'json',
         method: 'POST',
         data: Entity,
         headers: {
             "Content-Type": "application/json"
         }
     });


 };







 var getLeaveRequestListHR = function (Entity) {




     return $http({
         url: "/LeaveManagement/LeaveListAllDataHR",
         dataType: 'json',
         method: 'POST',
         data: Entity,
         headers: {
             "Content-Type": "application/json"
         }
     });


 };



 var getLeaveRequestListHRCompentionate = function (Entity) {




     return $http({
         url: "/LeaveManagement/LeaveListAllDataHRDataCopentionate",
         dataType: 'json',
         method: 'POST',
         data: Entity,
         headers: {
             "Content-Type": "application/json"
         }
     });


 };


 var getVisitRequestListHR = function (Entity) {




     return $http({
         url: "/VisitManagement/VisitListAllDataHR",
         dataType: 'json',
         method: 'POST',
         data: Entity,
         headers: {
             "Content-Type": "application/json"
         }
     });


 };



    var getRoleList = function (Entity) {



        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Utility/getAllRoleInfo",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };




    var GetBonusPaymentTypeInfo = function (Entity) {



        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Admin/GetBonusPaymentTypeInfo",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };







    var getCompanyList = function (Entity) {


        return $http({
            method: 'GET',
            data: Entity,
            url: baseUrl + "/Admin/CompanyList",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };




    var getHeadQuaterList = function (Entity) {


        return $http({
            method: 'GET',
            data: Entity,
            url: baseUrl + "/Admin/GetHeadQuaterLocation",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };


    var ShiftList = function (Entity) {


        return $http({
            method: 'GET',
            data: Entity,
            url: baseUrl + "/Admin/ShiftList",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };






    





  var getDepartmentList = function (Entity) {


        return $http({
            method: 'GET',
            data: Entity,
            url: baseUrl + "/Admin/DepartmentList",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

  };

  var getLeaveTypeList = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Admin/LeaveTypeList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };



  var getDesignationList = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Admin/DesignationList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };


  var AttendenceLocationList = function () {


      return $http({
          method: 'GET',
       
          url: baseUrl + "Admin/AttendenceLocationList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };


  var getGradeList = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Admin/EmployeeGradeList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };

  var GetSalaryStructureList = function () {


      return $http({
          method: 'POST',
        
          url: baseUrl + "/Sallary/getSalaryStructureList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };


  






  var getEmployeeList = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Admin/GetEmloyeeList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };



  var GetSuperVisorList = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Admin/GetSuperVisorList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };



  








  var GetLoanApplicationList = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Loan/GetLoanApplicationList",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };




  var getMobileListDataList = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Common/getMobileBillInfo",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };


  









  var GetLoanApplicationListPF = function (Entity) {


      return $http({
          method: 'GET',
          data: Entity,
          url: baseUrl + "/Loan/GetLoanApplicationListPF",
          headers: { 'Content-Type': 'application/json;charset=utf-8' }
      });

  };


  


  var SaveEmployee = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/Admin/SaveEmployee",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype':"multipart/form-data"
              }
      });

  };

  


  var SaveEmployee = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/Admin/SaveEmployee",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };



  var SaveLeaveInfo = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/LeaveManagement/SaveLeaveInfo",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };


  var SaveVisitInfo = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/VisitManagement/SaveVisitInfo",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };




  var SaveLeaveInfoHR = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/LeaveManagement/SaveLeaveInfoHR",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };




   var SaveCompentionate = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/LeaveManagement/SaveCompentionateLeaveInfo",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };





   var SaveEditAttendence = function (Entity) {


       return $http({
           method: 'POST',
           data: Entity,
           url: baseUrl + "/LeaveManagement/SaveEditAttendence",
           headers:
               {
                   'Content-Type': 'application/json;charset=utf-8',
                   'enctype': "multipart/form-data"
               }
       });

   };



  var SaveVisitInfoHR = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/VisitManagement/SaveVisitInfoHR",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };








  var ApprovalStatusUpdate = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/LeaveManagement/ApprovalStatusUpdate",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };



  var ApprovalVisitStatusUpdate = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/VisitManagement/ApprovalStatusUpdate",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };








  var CancelStatusUpdate = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/LeaveManagement/CancelStatusUpdate",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };



  var UpdateEmployee = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/Admin/UpdateEmployee",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };



  var UpdateSallaryStructure = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/Sallary/UpdateSallaryStructure",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };





  var LeaveApprove = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/LeaveManagement/ApprovalStatusUpdate",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };






  var VisitApprove = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/VisitManagement/ApprovalStatusUpdate",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };





  var CancelStatusUpdate = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/LeaveManagement/CancelStatusUpdate",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };

  
  
  var CancelStatusUpdateHR = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/VisitManagement/CancelStatusUpdate",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };




  var SaveSallaryStructureDetail = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/Sallary/SaveSallaryStructureDetail",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };



  var GetSalaryStructureByEmployee = function (Entity) {


      return $http({
          method: 'POST',
          data: Entity,
          url: baseUrl + "/Sallary/GetSalaryStructureByEmployee",
          headers:
              {
                  'Content-Type': 'application/json;charset=utf-8',
                  'enctype': "multipart/form-data"
              }
      });

  };







  
  

  



    var SaveUpdatePermission = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Utility/SavePermission",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };


    
    var SaveLoanApprove = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Loan/SaveLoanApprove",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };



    var SaveLoanApprovePF = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Loan/SaveLoanApprovePF",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };






    var ProcessIncrement = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Promotion/ProcessIncrement",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };


       var ProcessIncrements = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Promotion/ProcessIncrements",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };




    var ProcessPromotion = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Promotion/ProcessPromotion",
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

    };





    var getRolePermissionList = function (Entity) {


        return $http({
            method: 'POST',
            params: { roleId: Entity },
            url: baseUrl + "/Utility/getPermissionList",
           
        });

    };





    
    var getEmployeeListObj = function (Entity) {


        return $http({
            method: 'POST',
            params: { roleId: Entity },
            url: baseUrl + "/Utility/getPermissionList",
           
        });

    };












    var GetLoanApplicationListSearch = function (Entity) {


        return $http({
            method: 'POST',
            params: { employeeCode: Entity },
            url: baseUrl + "/Loan/GetLoanApplicationListSearch",

        });

    };



    var GetLoanApplicationListSearchPF = function (Entity) {


        return $http({
            method: 'POST',
            params: { employeeCode: Entity },
            url: baseUrl + "/Loan/GetLoanApplicationListSearchPF",

        });

    };


    var GetPFOpeningListSearch = function (Entity) {


        return $http({
            method: 'POST',
            params: { employeeCode: Entity },
            url: baseUrl + "/Loan/GetPFOpeningListSearch",

        });

    };






    var GetLoanInstallmentListSearch = function (Entity) {


        return $http({
            method: 'POST',
            params: { employeeCode: Entity },
            url: baseUrl + "/ProvidentFund/GetLoanInstallmentList",

        });

    };




    var OpeningLoanSearch = function (Entity) {


        return $http({
            method: 'POST',
            params: { employeeCode: Entity },
            url: baseUrl + "/ProvidentFund/GetOpeningLoanPF",

        });

    };






    


    var SearchEmployee = function (Entity) {


        return $http({
            method: 'POST',
            data:Entity ,
            url: baseUrl + "/Loan/GetEmployeeBasicInfoSearch",

        });

    };



    var SearchEmployeeLock = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Utility/GetEmployeeLockInfo",

        });

    };


    var SearchEmployeeChangePF = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Loan/GetEmployeeBasicInfoSearchPF",

        });

    };



    var SearcWitdrawPF = function (Entity) {


        return $http({
            method: 'POST',
            data: Entity,
            url: baseUrl + "/Loan/GetWitdrawPF",

        });

    };



    var SearchEmployeePF = function (Entity) {


        return $http({
            method: 'POST',
            params: { employeeCode: Entity },
            url: baseUrl + "/Loan/GetLoanApplicationListSearchPF",

        });

    };




    var getCompamyListObj = function (Entity) {


        return $http({
            method: 'POST',
            params: { Id: Entity },
            url: baseUrl + "/Admin/GetCompanyListObj",

        });

    };





    var getLeaveTypeListObj = function (Entity) {


        return $http({
            method: 'POST',
            params: { Id: Entity },
            url: baseUrl + "/LeaveManagement/LeaveInfoObj",

        });

    };






        var getEmployeeListObj = function (Entity) {


        return $http({
            method: 'POST',
            params: { Id: Entity },
            url: baseUrl + "/Admin/GetEmployeeListObj",

        });

    };





    var getMenuSidbar = function (Entity) {



        return $http({
            url: "/Utility/getMenu",
            dataType: 'json',
            method: 'POST',
            params: { id: Entity },
           
        })


    };



    var GetSalaryStructureDetailList = function (Entity) {



        return $http({
            url: "/Sallary/GetSalaryStructureDetailList",
            dataType: 'json',
            method: 'POST',
            params: { Id: Entity },

        })


    };




   





    var getNotificationList = function (Entity) {



        return $http({
            // url: "http://notify.time-zone.biz/LeaveManagement/NotificationList",

            url: "/LeaveManagement/NotificationList",
            dataType: 'json',
            method: 'POST',
            params: { Id: Entity },

        })


    };


    









    return {
     
     
        saveRole: saveRole,
        saveRoleInformation:saveRoleInformation,
        getMenuSidbar: getMenuSidbar,
        updateRoleInformation: updateRoleInformation,
        getRoleList: getRoleList,
        getRolePermissionList: getRolePermissionList,
        SaveUpdatePermission: SaveUpdatePermission,
        getCompanyList: getCompanyList,
        saveCompanyInformation:saveCompanyInformation,
        getCompamyListObj: getCompamyListObj,
        updateCompanyInformation: updateCompanyInformation,
        getDepartmentList: getDepartmentList,
        getDesignationList: getDesignationList,
        getGradeList: getGradeList,
        getEmployeeList:getEmployeeList,
        ShiftList: ShiftList,
        SaveEmployee: SaveEmployee,
        getEmployeeListObj:getEmployeeListObj,
        UpdateEmployee: UpdateEmployee,
        getLeaveTypeList:getLeaveTypeList,
        getLeaveTypeListObj: getLeaveTypeListObj,
        SaveLeaveInfo: SaveLeaveInfo,
        getNotificationList: getNotificationList,
        ApprovalStatusUpdate: ApprovalStatusUpdate,
        CancelStatusUpdate: CancelStatusUpdate,
        getMyAttendence: getMyAttendence,
        saveSalaryStructureInformation: saveSalaryStructureInformation,
        GetSalaryStructureList: GetSalaryStructureList,
        UpdateSallaryStructure: UpdateSallaryStructure,
        SaveSallaryStructureDetail: SaveSallaryStructureDetail,
        GetSalaryStructureDetailList: GetSalaryStructureDetailList,
     
        UpdateSalaryStructureDetailList: UpdateSalaryStructureDetailList,
        GetSalaryStructureByEmployee: GetSalaryStructureByEmployee,
        SearchEmployee: SearchEmployee,
        saveLoanApplication: saveLoanApplication,
        GetLoanApplicationList: GetLoanApplicationList,
        SaveLoanApprove: SaveLoanApprove,
        GetLoanApplicationListSearch: GetLoanApplicationListSearch,
        saveLoanPayment: saveLoanPayment,
        SaveOpeningBalancePF: SaveOpeningBalancePF,
        GetPFOpeningListSearch: GetPFOpeningListSearch,
        UpdateOpeningBalancePF:UpdateOpeningBalancePF,
        GetLoanApplicationListPF: GetLoanApplicationListPF,
        GetLoanApplicationListSearchPF: GetLoanApplicationListSearchPF,
        saveLoanApplicationPF: saveLoanApplicationPF,
        SaveLoanApprovePF: SaveLoanApprovePF,
        saveLoanPaymentPF: saveLoanPaymentPF,
        processSalary: processSalary,
        GetEmployeeListSearch: GetEmployeeListSearch,
        ProcessIncrement: ProcessIncrement,
        GetBonusPaymentTypeInfo: GetBonusPaymentTypeInfo,
        ProcessPromotion:ProcessPromotion,
        AttendenceLocationList: AttendenceLocationList,
        processBonus: processBonus,
        processTAX:processTAX,
        getLeaveRequestListHR: getLeaveRequestListHR,
        getLeaveEmployeeObj: getLeaveEmployeeObj,
        SaveLeaveInfoHR:SaveLeaveInfoHR,
        LeaveApprove: LeaveApprove,
        CancelStatusUpdate: CancelStatusUpdate,
        SaveVisitInfo: SaveVisitInfo,
        SaveVisitInfoHR:SaveVisitInfoHR,
        getVisitRequestListHR: getVisitRequestListHR,
        ApprovalVisitStatusUpdate: ApprovalVisitStatusUpdate,
        VisitApprove: VisitApprove,
        CancelStatusUpdateHR: CancelStatusUpdateHR,
        ProcessIncrements: ProcessIncrements,
        GetLoanInstallmentListSearch: GetLoanInstallmentListSearch,
        SaveInstallment: SaveInstallment,
        UpdateInstallment: UpdateInstallment,
        GetSuperVisorList: GetSuperVisorList,
        SaveOpeningLoan: SaveOpeningLoan,
        OpeningLoanSearch: OpeningLoanSearch,
        UpdateOpeningLoan: UpdateOpeningLoan,
        SearchEmployeePF: SearchEmployeePF,
        SearchEmployeeChangePF: SearchEmployeeChangePF,
        SearchEmployeeLock: SearchEmployeeLock,
        saveProcessLockEmployee: saveProcessLockEmployee,
        getHeadQuaterList: getHeadQuaterList,
        processSalaryCertificate: processSalaryCertificate,
        SearcWitdrawPF:SearcWitdrawPF,
        WithdrawPFAmount: WithdrawPFAmount,
        SaveCompentionate:SaveCompentionate,
        getLeaveRequestListHRCompentionate: getLeaveRequestListHRCompentionate,
        saveMobileInfo: saveMobileInfo,
        getMobileListDataList: getMobileListDataList,
        UpdateMobileInfo: UpdateMobileInfo,
        processLoanSys: processLoanSys,
        ImportTasHistory:ImportTasHistory,
        ImportPFOpeningLoan: ImportPFOpeningLoan,
        ImportLeaveOpeningLoan: ImportLeaveOpeningLoan,
        processLeaveEncashment: processLeaveEncashment,
        ImportTAXCHALANNO: ImportTAXCHALANNO,
        SaveEditAttendence: SaveEditAttendence
     
    
       



    };
};


angular.module('myApps').factory('kgchrmService', kgchrmService);