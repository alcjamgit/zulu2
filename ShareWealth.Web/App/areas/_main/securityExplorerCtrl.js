(function(){
    'use strict';

    angular.module('stockApp')
    .controller('securityExploreCtrl', function (securityService) {
        var vm = this;
        
        vm.keyword = "";

        securityService.getSecurities().then(function (result) {
            vm.secResult = result.data;
        });
        securityService.getWatchlist().then(function (result) {
            vm.watchlists = result.data;
        });

        
        vm.menuOptions = function (sec) {
            return [
                ['Open Chart', function ($itemScope) {
                    alert('ahoy');
                }],
                null, // Dividier
                ['Remove', function ($itemScope) {
                    alert('');
                }]
            ];

        };

    })
})();