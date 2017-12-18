var myApp = angular.module("myApp", []);

myApp.config(function ($httpProvider) {
    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
});

myApp.factory("test", ["$http", function ($http) {
    var det = {};

    // debugger;
    det.detail = function () {

        return $http.get("http://localhost:50580/api/Details/Get/");
    }

    det.keyupevt = function () {
        //     debugger;
        alert(event.keyCode);
    }

    det.delval = function (value) {
//        debugger;
         return $http.delete("http://localhost:50580/api/Detail/DeleteDetail/",value);
     
    }


    det.srch = function (value) {
        
        if ((value !== undefined) && (value !== null) && (value !== "")) {
        
            return $http.get("http://localhost:50580/api/Details/GetName/" + value);
        }
        else {
            return $http.get("http://localhost:50580/api/Details/Get/");
        }
    }

    det.AddDetVal = function (abcs) {
        debugger;
        var aDetail = {
            "Name": abcs.Name,
            "Phone": abcs.Phone,
            "Address": abcs.Address,
	    "Spec":abcs.Spec
        }

           return $http(
        {  
              method: 'post',
              data: {aDetail:aDetail},
              url: 'api/Details/Post/'
        });

    }

    return det;
}])

myApp.controller("myCtrl", function ($scope, test) {
    //  debugger;

    $scope.InsertDet = function (abcs) {
        debugger;
        test.AddDetVal(abcs).then(function (d)
        { $scope.user = d.data; })
    }

    test.detail().then(function (d) {
        $scope.user = d.data;
    });


    $scope.somthng = function (value) {
        test.delval(value).then(function (d) {
            $scope.user = d.data;
        })
    }

    $scope.srchVal = function (value) {
        test.srch(value).then(function (d) {
            $scope.user = d.data;
        })
    }

});



//myApp.controller("myCtrl", function ($scope, $http) {
//    debugger;


//    $scope.user = '';
//    var val1 = '';
//    $http.get('@Url.Action("GetAllDetail", "vms")').then(function (success) {
//        $scope.user = success.data;
//        //  console.log(success.data);
//    });


//$scope.AddVMS = function (abcs) {
//    $http({
//        traditional: true,
//        url: '@Url.Action("Create", "vms")',
//        method: "POST",
//        data: JSON.stringify(abcs),
//        dataType: "json"
//    }).then(function (result) {
//        debugger;
//        $scope.val = result;
//        console.log(val1);
//           $scope.user.push(abcs);



//        alert('Data Save successfully')

//            $http.get('@Url.Action("GetAllDetail", "vms")').then(function (success) {
//                $scope.user = success.data;
//                console.log(success.data);
//            });



//        });


//        /*.success(function (data, status, header, config) {
//        successcb(data);
//    }). error(function (data, status, header, config) {
//        $log.warn(data, status, header, config);*/
//        //});

//    };

//});