(function () {

    'use strict';
    angular.module('stockApp')
        .controller('createTransactionCtrl', function ($stateParams,  $window, $filter, scanService, portfolioService) {
                var vm = this;
                vm.scanData = {};
                vm.trans = {};
                vm.trans.transactionDate = $filter('date')(new Date(), 'dd/MM/yyyy');
        
                if ($stateParams.scanId !== '') {
                    initFromScan();
                };
                function initFromScan() {
                    scanService.getScanItem($stateParams.scanId).then(function (response) {
                        vm.scanData = angular.copy(response.data);


                        vm.trans.signalName = vm.scanData.signalName;
                        vm.trans.securityId = vm.scanData.securityId;
                        vm.trans.securityCode = vm.scanData.securityCode;
                        vm.trans.transactionType = vm.scanData.signalType;
                        vm.trans.brokerage = 30;
                        vm.trans.price = vm.scanData.signalPrice;
                        vm.trans.quantity = 0;

                        updateTotal();
                    });
                };

                vm.tradeValue=0;
        
                function updateTotal() {
                    var total = (vm.trans.quantity * vm.trans.price) + vm.trans.brokerage;
                    vm.tradeValue = $filter('number')(total,2) ;
                };

                vm.updateTotal = updateTotal;
                vm.cancel = function () {
                    $window.history.back();
                };

                vm.save = function () {
                    portfolioService.addStockTransaction(vm.trans).then(function (response) {
                        alert('Transaction Saved');
                    }, function (responseException) {
                        alert("Failed");
                    });
                };
        

        

            });

})();