/**
 * @author a.demeshko
 * created on 12/17/15
 */
(function () {
  'use strict';

  angular.module('BlurAdmin.pages.sourceTeam.contactOne', [])
    .config(routeConfig);

  /** @ngInject */
  function routeConfig($stateProvider) {
    $stateProvider
      .state('main.sourceTeam.contactOne', {
        url: '/contactOne',
        templateUrl: 'app/pages/sourceTeam/contactOne/contactOne.html',
        // controller: 'ContactOneCtrl',
        title: 'Nhập contact 1-1',
        
        sidebarMeta: {
          order: 100,
        },
        authenticate: true
      });
  }

})();