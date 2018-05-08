/**
 * @author a.demeshko
 * created on 12/16/15
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.sourceTeam.contactOne')
      .directive('numbersOnly', function () {
        return {
          require: 'ngModel',
          link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
              if (text) {
                var transformedInput = text.replace(/[^0-9]/g, '');
  
                if (transformedInput !== text) {
                  ngModelCtrl.$setViewValue(transformedInput);
                  ngModelCtrl.$render();
                }
                return transformedInput;
              }
              return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
          }
        };
      });

    //   angular.module('BlurAdmin.pages.sourceTeam.contactOne')
    //   .directive('datepicker', function () {
    //     return {
    //         restrict: "A",
    //         require: "ngModel",
    //         link: function (scope, elem, attrs, ngModelCtrl) {
    //           var updateModel = function (dateText) {
    //             scope.$apply(function () {
    //               ngModelCtrl.$setViewValue(dateText);
    //             });
    //           };
    //           var options = {
    //             dateFormat: "dd/mm/yy",
    //             onSelect: function (dateText) {
    //               updateModel(dateText);
    //             }
    //           };
    //           elem.datepicker(options);
    //         }
    //       }
    //   });

  

  })();