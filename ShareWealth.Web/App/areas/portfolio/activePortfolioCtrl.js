//=================================================
// PORTFOLIO MANAGER
//=================================================

(function(){
    'use strict';
    angular.module('stockApp')

    .controller('activePortfolioCtrl', function (growlService) {
        //PROFILE
        var vm = this;
        vm.id = 1;
        vm.profile = {
            //General
            name: "Default",
            createDate: new Date(2013, 6, 1),
            system: "SPA3",
            currency: "AUD",
            exchange: "XASX",
            watclistName: "Portfolio Watchlist",
            //Money Mgmt
            riskOptions: "Default XASX SIROC 21:08",
            maxOpenPositions: 30,
            allocationRisk: 0.03,
            //Costs
            minBrokerage: 30,
            brokeragePercentage: 0.02,
            brokerageThreshold: 100,
        };

        vm.showRiskOptions = function () {
            if (vm.profile.system === 'SPA3'){
                return true;
            }
            return false;
        };

        //PROFILE IMAGE
        vm.getImgUrl = function () {
            if (vm.profile.system === 'SPA3') {
                return 'app/img/spa3_600x600.png';
            }
            if (vm.profile.system === 'SPA3 ETF') {
                return 'app/img/etf_600x600.png';
            }
            return "";
        };

        //Edit
        vm.editGeneral = 0;
        vm.editMoneyManagement = 0;
        vm.submit = function (item, message) {
            if (item === 'generalInfo') {
                this.editGeneral = 0;
            }

            if (item === 'moneyManagement') {
                this.editMoneyManagement = 0;
            }


            growlService.growl(message + ' has updated Successfully!', 'inverse');
        }

        //CURRENT STATUS
        vm.status = {
            //General
            openTrades: 21,
            marketValue: 75000,
            profit: 15000,
            allocated: 60000,
            available: 0,
            initialCapital: 57000,
            addedCapital: 5000,
            withdrawnCapital: 2500,
            fees: 500,
            totalBalance: 75000,
        };

    })

})();