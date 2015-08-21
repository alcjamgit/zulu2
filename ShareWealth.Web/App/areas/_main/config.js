/// <reference path="config.js" />
/// <reference path="../security/securities-grid.html" />
angular.module('stockApp')

    .run(function($templateCache,$http){
          $http.get('app/includes/templates.html', {cache:$templateCache});
    })

    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/home");


        $stateProvider
        
            //------------------------------
            // HOME
            //------------------------------
        
            .state ('home', {
                url: '/home',
                templateUrl: '/app/areas/dashboard/dashboard.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/fullcalendar/dist/fullcalendar.min.css'
                                ]
                            },
                            {
                                name: 'vendors',
                                insertBefore: '#app-level-js',
                                files: [
                                    '/app/vendors/sparklines/jquery.sparkline.min.js',
                                    '/app/vendors/bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js',
                                    '/app/vendors/bower_components/simpleWeather/jquery.simpleWeather.min.js',
                                ]
                            }
                        ])
                    }
                }
            })
        

            //------------------------------
            // SECURITIES GRID
            //------------------------------

            .state('securities', {
                url: '/securities',
                templateUrl: '/app/areas/security/securities-grid.html',
                controller: 'securitiesGridCtrl as vm'
            })
            
            //------------------------------
            // WATCHLIST
            //------------------------------

            .state('watchlist', {
                url: '/watchlist',
                templateUrl: '/app/areas/watchlist/watchlist-grid.html',
                controller: 'watchListGridCtrl as vm'
            })

            //------------------------------
            // STOCK CHART
            //------------------------------

            .state('stock-chart', {
                url: '/stock-chart',
                templateUrl: '/app/areas/stockChart/stock-chart.html',
                controller: 'stockChartCtrl as vm'
            })

            //------------------------------
            // PORTFOLIO
            //------------------------------
            .state ('portfolio', {
                url: '/portfolio',
                templateUrl: '/app/areas/portfolio/portfolio-common.html',
            })

                .state ('portfolio.active-portfolio', {
                    url: '/active-portfolio',
                    templateUrl: '/app/areas/portfolio/active-portfolio-common.html',
                    controller: 'activePortfolioCtrl as vm'
                })

                    .state('portfolio.active-portfolio.profile', {
                            url: '/profile',
                            templateUrl: '/app/areas/portfolio/active-portfolio-profile.html',
                    })
                    .state('portfolio.active-portfolio.status', {
                            url: '/status',
                            templateUrl: '/app/areas/portfolio/active-portfolio-status.html',
                    })
                    .state('portfolio.active-portfolio.adjustments', {
                        url: '/adjustments/{id}',
                        templateUrl: '/app/areas/portfolio/active-portfolio-adjustments.html',
                        controller: 'activePortfolioAdjustmentCtrl as vm',
                    })
            .state('portfolio.portfolios', {
                url: '/portfolios',
                templateUrl: '/app/areas/portfolio/portfolioGrid.html',
                controller: 'portfolioGridCtrl as vm',
            })
            .state('portfolio.active-portfolio-transactions', {
                url: '/transactions',
                templateUrl: '/app/areas/portfolio/active-portfolio-transactions.html',
                controller: 'transactionCtrl as vm',
            })
                    .state('portfolio.create-transactions', {
                        url: '/create/{scanId}',
                        templateUrl: '/app/areas/portfolio/active-portfolio-form-transaction.html',
                        controller: 'createTransactionCtrl as vm',
                        resolve: {
                            loadPlugin: function ($ocLazyLoad) {
                                return $ocLazyLoad.load([
                                    {
                                        name: 'css',
                                        insertBefore: '#app-level',
                                        files: [
                                            '/app/vendors/bower_components/bootstrap-select/dist/css/bootstrap-select.css',
                                            '/app/vendors/chosen_v1.4.2/chosen.min.css',
                                            '/app/vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css'
                                        ]
                                    },
                                    {
                                        name: 'vendors',
                                        files: [
                                            '/app/vendors/input-mask/input-mask.min.js',
                                            '/app/vendors/bower_components/bootstrap-select/dist/js/bootstrap-select.js',
                                            '/app/vendors/chosen_v1.4.2/chosen.jquery.min.js',
                                            '/app/vendors/bower_components/nouislider/distribute/jquery.nouislider.all.min.js',
                                            '/app/vendors/bower_components/moment/min/moment.min.js',
                                            '/app/vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js',
                                            '/app/vendors/fileinput/fileinput.min.js'
                                        ]
                                    }
                                ])
                            }
                        }
                    })
            //------------------------------
            // SCANS
            //------------------------------
             .state('scans', {
                url: '/scans',
                templateUrl: '/app/areas/scans/scan-common.html',
                
            })
            .state('scans.scan-profiles', {
                url: '/scan-profiles',
                templateUrl: '/app/areas/scans/scan-profiles.html',
                controller: 'scanProfilesCtrl as vm',
                    resolve: {
                        loadPlugin: function($ocLazyLoad) {
                            return $ocLazyLoad.load ([
                                {
                                    name: 'css',
                                    insertBefore: '#app-level',
                                    files: [
                                        '/app/vendors/bower_components/bootstrap-select/dist/css/bootstrap-select.css',
                                        '/app/vendors/chosen_v1.4.2/chosen.min.css',
                                        '/app/vendors/bower_components/nouislider/distribute/jquery.nouislider.min.css',
                                        '/app/vendors/farbtastic/farbtastic.css',
                                        '/app/vendors/bower_components/summernote/dist/summernote.css',
                                        '/app/vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css'
                                    ]
                                },
                                {
                                    name: 'vendors',
                                    files: [
                                        '/app/vendors/input-mask/input-mask.min.js',
                                        '/app/vendors/bower_components/bootstrap-select/dist/js/bootstrap-select.js',
                                        '/app/vendors/chosen_v1.4.2/chosen.jquery.min.js',
                                        '/app/vendors/bower_components/nouislider/distribute/jquery.nouislider.all.min.js',
                                        '/app/vendors/bower_components/moment/min/moment.min.js',
                                        '/app/vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js',
                                        '/app/vendors/farbtastic/farbtastic.min.js',
                                        '/app/vendors/bower_components/summernote/dist/summernote.min.js',
                                        '/app/vendors/fileinput/fileinput.min.js'
                                    ]
                                }
                            ])
                        }
                    }
            })
            .state('scans.scan-daily', {
                url: '/scan-daily',
                templateUrl: '/app/areas/scans/scans-daily.html',
                controller: 'scanDailyCtrl as vm'
            })


        
            
           

    });
