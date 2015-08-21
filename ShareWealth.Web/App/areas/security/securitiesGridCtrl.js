(function(){
    'use strict';
    angular.module('stockApp')
    .controller('securitiesGridCtrl', function (securityService, $state) {
        var vm = this;
        var readData = function (options) {
            return securityService.getExtendedSecurities().then(function (result) {
                options.success(result.data);
            });
        }
        vm.showChart = function (selected) {
            alert(selected.securityCode);
            $state.go('stock-chart');
            //alert(sel.securityCode);
        };
        vm.addToWatchlist = function (selected) {
            alert(selected.securityCode);
            //alert(sel.securityCode);
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
                            securityCode: { type: "string" },
                            securityName: { type: "string" },
                            exchange: { type: "string" },
                            symbol: { type: "string" },
                            type: { type: "string" },
                            gicsSector: { type: "string" },
                            icbIndustry: { type: "string" },
                            open: { type: "number" },
                            high: { type: "number" },
                            low: { type: "number" },
                            close: { type: "number" },
                            volume: { type: "number" },
                            lastDate: { type: "date" },
                            marketCap: { type: "number" }
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
            columns: [
                { field: "securityCode", title: "Security Code", width: 120 },
                { field: "securityName", title: "Security Name" },
                { field: "exchange", title: "Exchange", width: 160, filterable: { multi: true } },
                { field: "type", title: "Type", width: 160, filterable: { multi: true } },
                { field: "icbIndustry", title: "ICB Industry", width: 160, filterable: { multi: true } },
                { field: "close", title: "Closed Price", width: 120, format: "{0:c}", attributes: { style: "text-align:right;" } },
                { field: "volume", title: "Volume", width: 120, format: "{0:n}", attributes: { style: "text-align:right;" } },
                { field: "lastDate", title: "Last Date", width: 120, format: "{0:dd/MM/yyyy}", attributes: { style: "text-align:right;" } },
            ],
            dataBound: function () {
                $(".k-grid-content tbody").find("tr").addClass("hasMenu");

            }
        };

        //Context menu
        vm.menuOpen = 0;
        vm.onSelect = function (e) {

            vm.selected = $(e.item).children(".k-link").text();
        };

    })

})();

