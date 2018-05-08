/**
 * @author a.demeshko
 * created on 12/16/15
 */
(function () {
    'use strict';

    // angular.module('BlurAdmin.pages.sourceTeam.contactMany')
    //     .directive("fileread", [function () {
    //         return {
    //             scope: {
    //                 fileread: "="
    //             },
    //             link: function (scope, element, attributes) {
    //                 element.bind("change", function (changeEvent) {
    //                     var reader = new FileReader();
    //                     reader.onload = function (loadEvent) {
    //                         scope.$apply(function () {
    //                             scope.fileread = loadEvent.target.result;
    //                         });
    //                     }
    //                     reader.readAsDataURL(changeEvent.target.files[0]);
    //                 });
    //             }
    //         }
    //     }]);

    angular.module('BlurAdmin.pages.sourceTeam.contactMany')
        .directive("fileInput", ['$parse',function ($parse) {
            return {
                restrict:'A',
                link: function(scope, element, attrs){
                    element.bind('change', function(){
                        $parse(attrs.fileInput).assign(scope, element[0].files)
                        scope.$apply()
                    })
                }
            }
        }]);

})();