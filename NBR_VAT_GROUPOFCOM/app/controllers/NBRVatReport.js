
var NBRVatReport = function ($scope,$window,$http) {

    $scope.Entity = {};

  //  var baseUrlService = "http://13.251.5.159/";
    $scope.InvoceList =  [];

    $scope.getInvoiceList = function (Entity) {

       var rm={
           start_date: "2022-11-25",
            end_date : "2022-11-30"
       }

       $.get("https://api.github.com/users/shawnquinn")
  .done(function (data) {
      console.log(data);
      $scope.InvoceList=data
      //$(".nameTest").text(data.login);
  })
  .fail(function () {
      alert("ERROR");
  });


    }


  

}


angular.module('myApps')
        .controller('NBRVatReport', NBRVatReport);
