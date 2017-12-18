var myApp = angular.module("myApp", []);

myApp.factory("test", ["$http", function ($http) {
    var det = {};

    debugger;
    det.detail = function () {

   //     return $http.get("/api/Details");
    }


    det.AddVMSVal = function (abcs) {
        debugger;
        var response = $http({
            traditional: true,
            url: '/vms/Create',

            //@Url.Action("Create", "vms")
            method: "post",
            data: JSON.stringify(abcs),
            dataType: "json"
        });
        return response;
    }

    det.logVMSVal = function (abcs) {
        debugger;
        var response = $http({
            traditional: true,
            url: '/vms/vmslog',
            method: "post",
            //  data: JSON.stringify(abcs),
            data: { empid: abcs.Name, pass: abcs.Psw1 },
            dataType: "json"
        });
        return response;
    }

    return det;
}])

myApp.controller("myCtrl", function ($scope, test) {
    debugger;


    test.detail().then(function (d) {
        $scope.user = d.data;
    });



    $scope.AddVMS = function (abcs) {
        test.AddVMSVal(abcs).then(function (response) {
            /* test.detail().then(function (response) {
                 $scope.user = response.data;*/
            debugger;
            var dt = response.data;
            if (dt == 1) {
                alert('Enter successfully');
            }

            else {
                alert('Please try after some time');
            }

            //});


        });

    };


    $scope.logVMS = function (abcs) {
        test.logVMSVal(abcs).then(function (response) {
            debugger;
            var de = response.data;
            if(de==0)
            {
                alert('User Name and Password is not correct');
                $scope.vas = 0;
            }
            else if (de==-1){
                alert('Please contact with Admisitrator for issue');
            }
        });
    };

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