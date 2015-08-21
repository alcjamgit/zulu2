(function(){
    'use strict';

    angular.module('stockApp')
    .controller('scanDailyCtrl', function(scanService, $state){
        var vm = this;
        var readDataMain = function (options) {
            return scanService.getDailyScans().then(function (result) {
                options.success(result.data);
            });
        };
        vm.selected = {};
        vm.createTransaction = function () {
            $state.go('portfolio.create-transactions', { scanId: vm.selected.id});
        };

        //http://ernpac.net/?p=566
        vm.mainGridOptions = {
            dataSource: {
                transport: {
                    read: readDataMain,
                },
                schema: {
                    model: {
                        id: "id",
                        fields: {
                            id: {type:"string", editable: false},
                            securityCode: {type: "string"},
                            signalDate: { type: "date" },
                            actionDate: { type: "date" },
                            signalName: { type: "string" },
                            signalType: { type: "string" },
                            signalPrice: { type: "number" },

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
                { field: "securityCode", title: "Security", width: 120 },
                { field: "signalName", title: "Signal" },
                { field: "signalType", title: "Type", width: 80, filterable: { multi: true } },
                { field: "signalDate", title: "Signal Date", filterable: true, format: "{0:dd/MM/yyyy}" },
                { field: "actionDate", title: "Action Date", filterable: true, format: "{0:dd/MM/yyyy}" },
                { field: "signalPrice", title: "Signal Price", filterable: true, format: "{0:n}" },
            ],
             dataBound: function () {
                $(".k-grid-content tbody").find("tr").addClass("hasMenu");

            }
        };

    });

})();