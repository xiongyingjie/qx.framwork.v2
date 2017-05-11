(function(){
    angular.module('MyApp', ['angular-bind-html-compile'])
        .run(configFuc)
        .controller('MyController', MyController)
        .directive('compileBindHtml', compileBindHtml);

    configFuc.$inject = ['$templateCache'];
    MyController.$inject = ['$sce'];
    compileBindHtml.$inject = ['$compile'];


    function configFuc($templateCache){
        var template = '<div class="container">\
            <div class="title">{{vm.info}}</div>\
            <div class="content">content</div>\
            </div>';
        $templateCache.put('template-2', template);
    }

    function MyController($sce){
        var vm = this;
        vm.info = 'Hello,World';
        vm.msg = 'Thank You!';
        vm.html = '<div class="container">\
            <div class="title">{{vm.info}}</div>\
            <div class="content">content</div>\
            </div>';


        vm.trust_my_html = trust_my_html;
        vm.get_trust_html = get_trust_html;

        function trust_my_html(str){
            return $sce.trustAsHtml(str);
        }

        function get_trust_html(str){
            return $sce.getTrustedHtml(str);
        }

    }

    function compileBindHtml($compile){
        var directive = {
            restrict: 'AE',
            link:linkFunc
        };
        return directive;

        function linkFunc(scope, elements, attrs){
            var func = function(){
                return scope.$eval(attrs.compileBindHtml);
            };
            scope.$watch(func, function(newValue){
                elements.html(newValue);
                $compile(elements.contents())(scope);
            })
        }
    }
})();