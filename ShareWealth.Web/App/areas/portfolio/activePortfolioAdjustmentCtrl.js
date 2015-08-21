(function(){
    'use strict';
    angular.module('stockApp')

    .controller('activePortfolioAdjustmentCtrl', function (portfolioService, $stateParams) {
        var vm = this;
        //alert($stateParams.id);
        var readData = function (options) {
            return portfolioService.getAdjustments().then(function (result) {
                options.success(result.data);
            });
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
                            id: { type: "number" },
                            date: { type: "date" },
                            type: { type: "string" },
                            portfolioId: { type: "number" },
                            amount: { type: "string" },
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
                numeric: true
            },
            toolbar: ["create"],
            columns: [
                { field: "id", title: "Id", width: 64 },
                { field: "date", title: "Date", format: "{0:dd/MM/yyyy}" },
                { field: "type", title: "Type", filterable: { multi: true } },
                { field: "amount", title: "Amount", width: 120, format: "{0:n}", attributes: { style: "text-align:right;" } },
            ],
            dataBound: function () {
                $(".k-grid-content tbody").find("tr").addClass("hasMenu");

            }
        };


    })
})();