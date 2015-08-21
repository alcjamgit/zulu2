(function(){
    'use strict';
    angular.module('stockApp')
    .controller('scanProfilesCtrl', function (scanService, watchlistService) {
        var vm = this;
        var readDataMain = function (options) {
            return scanService.getScanProfiles().then(function (result) {
                options.success(result.data);
            });
        };

        var readDataSecurities = function (options) {
            return watchlistService.getWatchlistSecurities().then(function (result) {
                options.success(result.data);
            });
        };

        

        //http://ernpac.net/?p=566
        vm.mainGridOptions = {
            dataSource: {
                transport: {
                    read: readDataMain,
                },
                schema: {
                    model: {
                        id:'id',
                        fields: {
                            id: { type: "number" },
                            name: { type: "string" },
                            system: { type: "string" },
                            locked: { type: "boolean" },
                            scanType: { type: "string" },
                            parameters: { type: "string" },
                            chartOptions: { type: "string" },
                            entry: { type: "boolean" },
                            exit: { type: "boolean" },
                            pyramid: { type: "boolean" },
                            lighten: { type: "boolean" },
                            timeFrameType: { type: "string" },
                            period: { type: "number" },
                            periodType: { type: "string" },
                            startDate: { type: "date" },
                            endDate: { type: "date" },

                        }
                    }
                },
                pageSize: 20
            },
            toolbar: ["create"],
            editable: "popup",
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
                { field: "id", title: "Id", width: 120 },
                { field: "name", title: "Name" },
                { field: "system", title: "Type", width: 80, filterable: { multi: true } },
                { field: "locked", title: "Locked", width: 80, filterable: { multi: true } },
            ],
        };

        //http://ernpac.net/?p=566 & http://demos.telerik.com/kendo-ui/grid/angular
        vm.detailGridOptions = function (dataItem) {
            return {
                dataSource: {
                    transport: {
                        read: readDataSecurities,
                    },
                    schema: {
                        model: {
                            fields: {
                                id: { type: "number" },
                                securityCode: { type: "string" },
                                securityName: { type: "string" },
                                exchange: { type: "string" },
                                watchlistId: { type: "number" }
                            }
                        }
                    },
                    pageSize: 10,
                    filter: { field: "watchlistId", operator: "eq", value: dataItem.id }
                },
                height: 300,
                scrollable: true,
                filterable: false,
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
                ]
            };
        };


    });
})();