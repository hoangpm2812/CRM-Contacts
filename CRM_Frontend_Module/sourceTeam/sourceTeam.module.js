/**
 * @author v.lugovsky
 * created on 16.12.2015
 */
(function() {
    'use strict';
  
    angular.module('BlurAdmin.pages.sourceTeam', [
        'BlurAdmin.pages.sourceTeam.contactOne',
        'BlurAdmin.pages.sourceTeam.contactMany'
      ])
      .config(routeConfig);
  
    /** @ngInject */
    function routeConfig($stateProvider) {
      $stateProvider
        .state('main.sourceTeam', {
          url: '/sourceTeam',
          abstract: true,
          template: '<div ui-view  autoscroll="true" autoscroll-body-top></div>',
          title: 'Đội nguồn',
          sidebarMeta: {
            icon: 'ion-stats-bars',
            order: 150,
          },
          authenticate: true
        });
    }
  
  })();