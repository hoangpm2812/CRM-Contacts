/**
 * @author a.demeshko
 * created on 12/17/15
 */
(function() {
    'use strict';
  
    angular.module('BlurAdmin.pages.sourceTeam.contactMany', [])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider) {
      $stateProvider
        .state('main.sourceTeam.contactMany', {
          url: '/contactMany',
          templateUrl: 'app/pages/sourceTeam/contactMany/contactMany.html',
          title: 'Nhập contact 1-n',
          sidebarMeta: {
            order: 150,
          },
          authenticate: true
        });
    }
  
  })();