var app = angular.module('myApp', ['ngMessages']);

//app.config(['$routeProvider', function ($routeProvider) {
//    $routeProvider
//    .when('/list', {
//        templateUrl: 'views/route/list.html',
//        controller: 'RouteListCtl'
//    })
//    .when('/list/:id', {
//        templateUrl: 'views/route/detail.html',
//        controller: 'RouteDetailCtl'
//    })
//    .otherwise({
//        redirectTo: '/list'
//    });
//}]);


app.controller('SController', function ($scope, $http) {
    //单行数据栏目
    $scope.SURL = "/api/json-getSigleColumn/";

    $scope.setID_S = function (id) {

        $http.get($scope.SURL + id)
            .success(function (data) {
                $scope.Smodel = data.Content;
            })
            .error(function () {
                alert("error_请求单行数据栏目(id:" + id + ")失败");
            });
    };
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
                alert("error_请求多行数据栏目(id:"+id+")失败");
            });
    };

});

//app.directive('lunbo', function () {

//    alert("enter");
//    return {
//        restrict: 'E',
//        templateUrl: 'angular-directives/BuyNowV2.html',
//        replace: true
//    };
//});

app.directive('lunbo', function () {

    alert("enter");
    return {
        restrict: 'AE',
        template :'<a>aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</a>',
        templateUrl: '#angular-directives/BuyNowV2.html',
        replace: true
    };
});

app.filter('to_trusted', ['$sce', function ($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        }
    }]);