var mymodal = angular.module('mymodal', []);



mymodal.directive('modal', function () {
    return {




        template:
       ' <div class="uk-modal">'+
        '  <div class="uk-modal-dialog">' +
        '<h4 class="modal-title">{{ title }}</h4>' +
              '  <button class="uk-modal-close uk-close" type="button"></button>'+
                '<div ng-transclude></div>' +
                  '  </div>'+
           ' </div>',





      
        restrict: 'E',
        transclude: true,
        replace: true,
        scope: true,
        link: function postLink(scope, element, attrs) {
            scope.title = attrs.title;

            scope.$watch(attrs.visible, function (value) {
                if (value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });

            $(element).on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = true;
                });
            });

            $(element).on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = false;
                });
            });
        }
    };
});