var commonService = function (akFileUploaderService, $http) {

    var baseUrl = "http://kgcsims.com/api/";
    var baseUrlService = "http://13.251.5.159/";
  

 




    var getInvioceList = function (Entity) {

        var nrp= $http({
            method: 'POST',
            data: Entity,
            //url: baseUrlService + 'get-invoicelist',
            url: baseUrlService + '/get-invoicelist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });

        console.log(JSON.stringify(nrp));

        return $http({
            method: 'POST',
            data: Entity,
            //url: baseUrlService + 'get-invoicelist',
            url: baseUrlService + '/get-invoicelist',
            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        });


    };

    var Test = function (Entity) {


        var data = $http.get('http://apidemo.gouptechnologies.com/api/admin');

        console.log( JSON.stringify(data));
        var i = 0;
        return $http.get('http://apidemo.gouptechnologies.com/api/admin');


    };
 

    



    return {
     
        getInvioceList: getInvioceList,
        Test: Test
    };
};


angular.module('myApps').factory('commonService', commonService);