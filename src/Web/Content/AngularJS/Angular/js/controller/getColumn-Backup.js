var app = angular.module('myApp', ['ngMessages']);

app.controller('SController', function ($scope, $http) {
    //单行数据栏目
    $scope.SURL = "/api/json-getSigleColumn/";

    $scope.setID_S = function (id) {

        $http.get($scope.SURL + id)
            .success(function (data) {
                $scope.Smodel = data.Content;
            })
            .error(function () {
                alert("error_请求单行栏目数据失败");
            });
    };


    //$http.get("/api/json-getSigleColumn/floatdiv")
    //    .success(function (data) {
    //        $scope.floatAD = data.Content;
    //    })
    //    .error(function (data) {
    //        alert("error :" + data);
    //    });


});

app.controller('MController', function ($scope, $http) {

    //多行数据栏目
    $scope.MURL = "/api/json-getMutiPleColumn/";

    $scope.setID_M = function (id) {

        $http.get($scope.MURL + id)
            .success(function (data) {
                $scope.Mmodel = data.Content;
            })
            .error(function () {
                alert("error_请求多行数据栏目失败");
            });
    };

    //alert(angular.element('#Home2_lunbo').attr('id'))
    //此处添加--多行数据栏目
    // $http.get("/api/json-getMutiPleColumn/idTransformView2")
    //     .success(function (data) {
    //         $scope.TransformView2 = data.Content;
    //     })
    //    .error(function (data) {
    //        alert("error :" + data);
    //    });

});

//app.directive('dynamiccss', function ($http) {
//    $http.get("/api/json-getDynamicQuote/all")
//        .success(function (data) {
//            alert(data.Name);
//            var t = "'" + data.Name + "'";
//            alert(t);
//            return {
//                restrict: 'E',
//                template: t,
//                replace: true
//            };
//        })
//        .error(function (data) {
//            alert("error :" + data);
//        });
//});



app.filter('to_trusted', ['$sce', function ($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        }
    }]);