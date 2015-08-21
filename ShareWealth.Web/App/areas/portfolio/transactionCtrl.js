(function () {

    'use strict';
    angular.module('stockApp')
    .controller('transactionCtrl', function (portfolioService, $state) {
        var vm = this;
        //alert($stateParams.id);
        var readData = function (options) {
            return portfolioService.getTransactions().then(function (result) {
                options.success(result.data);
            });
        };

        vm.createTransaction = function(){
            $state.go('portfolio.create-transactions');
        };

        //http://ernpac.net/?p=566
        vm.mainGridOptions = {
            dataSource: {
                transport: {
                    read: readData,
                },
                schema: {
                    model: {
                        fields: {
                            transactionDate: { type: "date" },
                            securityId: { type: "number" },
                            securityCode: {type: "string"},
                            signalName: {type: "string"},
                            transactionType: { type: "string" },
                            price: { type: "number" },
                            quantity: { type: "number" },
                            tradeValue: { type: "number" },
                        }
                    }
                },
                pageSize: 20
            },
            height: 600,
            scrollable: true,
            sortable: true,
            groupable: true,
            filterable: true,
            selectable: true,
            navigatable: true,
            pageable: {
                input: true,
                numeric: true,
                refresh: true,
            },
            columns: [
                { field: "transactionDate", title: "Date", filterable: true, format: "{0:dd/MM/yyyy}" },
                { field: "securityCode", title: "Security"},
                { field: "signalName", title: "Signal" },
                { field: "transactionType", title: "Type", filterable: { multi: true } },
                { field: "price", title: "Price", filterable: true, format: "{0:n}", attributes: { style: "text-align:right;" } },
                { field: "quantity", title: "Qty", filterable: true, format: "{0:n0}", attributes: { style: "text-align:right;" } },
                { field: "tradeValue", title: "Trade Value", filterable: true, format: "{0:n}", attributes: { style: "text-align:right;" } },
            ],
            dataBound: function () {
                $(".k-grid-content tbody").find("tr").addClass("hasMenu");

            }
        };


    });

})();