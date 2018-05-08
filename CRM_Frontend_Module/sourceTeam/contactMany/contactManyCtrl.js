/**
 * @author a.demeshko
 * created on 12/16/15
 */
(function () {
    'use strict';
  
    angular.module('BlurAdmin.pages.sourceTeam.contactMany')
      .controller('ContactManyCtrl', ContactManyCtrl);
  
    /** @ngInject */
    function ContactManyCtrl($scope, $timeout, baConfig, toastr) {
      var vm = this;
      

      vm.loadFileClick = function(){
        console.log(vm.file)
        if (vm.file[0].type != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"){
          toastr.error('File type must be .xlsx !', 'Error file', {
            "autoDismiss": false,
            "positionClass": "toast-top-right",
            "type": "error",
            "timeOut": "4000",
            "extendedTimeOut": "2000",
            "allowHtml": false,
            "closeButton": false,
            "tapToDismiss": true,
            "progressBar": false,
            "newestOnTop": true,
            "maxOpened": 0,
            "preventDuplicates": false,
            "preventOpenDuplicates": false
          })
          return;
        }
        else{
          alert("ok")
        }
      }
    }
  })();