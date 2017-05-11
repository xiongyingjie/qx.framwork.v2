function MyController($scope, $timeout) {
    var updateClock = function () {
        $scope.clock = new Date();
        $timeout(function () {
            updateClock();
        }, 1000);
    };
    updateClock();
};

function MyController1($scope) {
    $scope.clock =
        {
            now: new Date()
        };
    var updateClock = function () {
        $scope.clock.now = new Date()
    };
    setInterval(function () {
        $scope.$apply(updateClock);
    }, 1000);
    updateClock();
};

///------------------angular 模块概念
angular.module('myApp', [])
    .run(function ($rootScope, $http) {
        $rootScope.name = "Charles";
        //$rootScope.say = "is say be influenced?";
    });

angular.module('myPartialApp', [])
    .run(function ($rootScope) {
        $rootScope.name = "Maggie";
    });

//模块的控制尽量不要写在全局的模块里面，避免污染，应当独立定义
var app = angular.module('myApp', ['ngMessages']);
app.controller('MyController1', function ($scope, $http) {
    $scope.message = "Maggie";//隔离的$scope对象
    $scope.today = new Date();//隔离的$scope对象
    $scope.counter = 0;//控制器内有效
    $scope.add = function (amount) { $scope.counter += amount }
    $scope.subtract = function (amount) { $scope.counter -= amount }

    $scope.person = { name: 'Ari Lerner' };

    $http.get("api/json-gettemplete/floatdiv").success(function (data) {
        $scope.myText = data.Content;
    });

});

app.filter(
    'to_trusted', ['$sce', function ($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        }
    }]);


app.directive('myDirective', function ($http,$sce) {
    var model = angular.copy($http.get("api/gettemplete/floatdiv").success(function (data) {
        //console.log(data);
        //alert($sce.trustAsHtml(data));
        return $sce.trustAsHtml(data);
    }));

    alert(model);
        
    

    return {
        restrict: 'E',//E（自定义）A(属性)C(类)M(注释)，A的兼容性最好
        replace: true,
        template: model
    };
});




