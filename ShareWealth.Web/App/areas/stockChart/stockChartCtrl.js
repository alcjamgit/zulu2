(function(){
    'use strict';
    angular.module('stockApp')
    .controller('stockChartCtrl', function (securityService) {
        var vm = this;
        var readPriceData = function (options) {
            return securityService.getPriceData().then(function (result) {
                options.success(result.data);
            });
        };

        //http://docs.telerik.com/kendo-ui/api/javascript/dataviz/ui/stock-chart#configuration-categoryAxis.baseUnit
        vm.chartOptions = {
            dataSource: {
                transport: {
                    read: readPriceData,
                },
                schema: {
                    model: {
                        fields: {
                            date: { type: "date" }
                        }
                    }
                }
            },
            //title: {
            //    text: "BHP - XASX"
            //},
            dateField: "date",
            series: [{
                type: "candlestick",
                openField: "open",
                highField: "high",
                lowField: "low",
                closeField: "close"
            }],
            navigator: {
                series: {
                    type: "area",
                    field: "close"
                },
                select: {
                    from: "2010/04/01",
                    to: "2015/07/20"
                }
            },
            chartArea: { height: 500 },
            categoryAxis: {
                baseUnit: "fit",
                maxDateGroups: 60,
                notes: {
                    //data: [{
                    //    value: "2010/01/01",
                    //    label: {
                    //        text: "01"
                    //    }
                    //}, {
                    //    value: "2011/01/01",
                    //    label: {
                    //        text: "02"
                    //    }
                    //}, {
                    //    value: "2012/01/01",
                    //    label: {
                    //        text: "03"
                    //    }
                    //}, {
                    //    value: "2013/01/01",
                    //    label: {
                    //        text: "04"
                    //    }
                    //}, {
                    //    value: "2014/01/01",
                    //    label: {
                    //        text: "05"
                    //    }
                    //}, {
                    //    value: "2015/01/01",
                    //    label: {
                    //        text: "06"
                    //    }
                    //}]
                }
            }
        };
    })
})();