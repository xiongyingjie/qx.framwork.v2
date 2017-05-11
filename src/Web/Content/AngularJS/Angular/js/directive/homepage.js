
var app = angular.module('myApp', ['ngMessages']);

app.directive('LunBo', function () {

    alert("enter");
    return {
        restrict: 'E',
        templateUrl: '#angular-directives/directive/LunBo',
        replace: true
    };
});
