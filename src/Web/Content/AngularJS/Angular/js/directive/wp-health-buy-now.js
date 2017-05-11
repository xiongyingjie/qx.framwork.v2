
var app = angular.module('myApp', ['ngMessages']);

app.directive('LunBo', function () {

    alert("enter");
    return {
        restrict: 'E',
        templateUrl: '/Directive/Lunbo.html',
        replace: true
    };
});
