




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


angular.module('myApp', [])
    .run(function ($rootScope, $http) {
        $rootScope.name = "Charles";
        //$rootScope.say = "is say be influenced?";
    });

angular.module('myPartialApp', [])
    .run(function ($rootScope) {
        $rootScope.name = "Maggie";
    });


var app = angular.module('myApp', ['ngMessages']);
app.controller('MyController1', function ($scope, $http) {
    $scope.message = "Maggie";
    $scope.today = new Date();
    $scope.counter = 0;
    $scope.add = function (amount) { $scope.counter += amount }
    $scope.subtract = function (amount) { $scope.counter -= amount }

    $scope.person = { name: 'Ari Lerner' };

    $http.get("/api/json-gettemplete/floatdiv").success(function (data) {
        $scope.floatAD = data.Content;
    });

    $http.get("/api/json-getidTransformView2/idTransformView2").success(function (data) {
        $scope.TransformView2 = data.Content;
    });

});

app.filter(
    'to_trusted', ['$sce', function ($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        }
    }]);


app.directive('myDirective', function ($http, $sce) {
    var model = angular.copy($http.get("api/gettemplete/floatdiv").success(function (data) {
        //console.log(data);
        //alert($sce.trustAsHtml(data));
        return $sce.trustAsHtml(data);
    }));

    alert(model);



    return {
        restrict: 'E',
        replace: true,
        template: model
    };
});




