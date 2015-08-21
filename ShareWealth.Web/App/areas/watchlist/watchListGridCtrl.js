(function() {
    'use strict';
    angular.module('stockApp')
    .controller('watchListGridCtrl', function (watchlistService) {
        var vm = this;
        var readDataMain = function (options) {
            return watchlistService.getWatchlist().then(function (result) {
                options.success(result.data);
            });
        };
        var addDataMain = function (options) {
            return watchlistService.addWatchlist(options.data).then(function (result) {
                options.success(result.data);
            }, function (error) {
                
                alert("Error: " + error.errors[0].errorMessage);
            });
        };



        var readDataDetails = function (options) {
            return watchlistService.getWatchlistSecurities().then(function (result) {
                options.success(result.data);
            });
        };

        //http://ernpac.net/?p=566
        vm.mainGridOptions = {
            dataSource: {
                transport: {
                    read: readDataMain,
                    create: addDataMain,
                },
                schema: {
                    model: {
                        id: "id",
                        fields: {
                            id: { type: "string", editable: false },
                            name: { type: "string", validation : {required: true}},
                            type: { type: "string", editable: false, defaultValue: "User Defined" },
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
                numeric: true
            },
            columns: [
                //{ field: "id", title: "Id", width: 120 },
                { field: "name", title: "Name" },
                { field: "type", title: "Type", width: 160, filterable: { multi: true } },
            ],
        };

        //http://ernpac.net/?p=566 & http://demos.telerik.com/kendo-ui/grid/angular
        vm.detailGridOptions = function (dataItem) {
            return {
                dataSource: {
                    transport: {
                        read: readDataDetails,
                    },
                    schema: {
                        model: {
                            id: "id",
                            fields: {
                                id: { type: "string" },
                                securityCode: { type: "string" },
                                securityName: { type: "string" },
                                exchange: { type: "string" },
                                watchlistId: { type: "string" }
                            }
                        }
                    },
                    pageSize: 10,
                    filter: { field: "watchlistId", operator: "eq", value: dataItem.id }
                },
                height: 400,
                scrollable: true,
                filterable: false,
                selectable: true,
                navigatable: true,
                pageable: {
                    input: true,
                    numeric: true,
                },
                columns: [
                    //{ field: "id", title: "Id", width: 120 },
                    { field: "securityCode", title: "Security Code", width: 120 },
                    { field: "securityName", title: "Security Name" },
                    { field: "exchange", title: "Exchange", width: 160, filterable: { multi: true } },
                ],
                dataBound: function () {
                    $(".k-grid-content tbody").find("tr").addClass("hasMenu");

                }
            };
        };
        vm.scanSettingsOption = function(dataItem){
            vm.theDate = dataItem.startDate;
        };
    })
})();