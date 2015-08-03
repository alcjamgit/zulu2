(function(){

    angular.module('shareWealth')

    .run(function($templateCache,$http){
          $http.get('includes/templates.html', {cache:$templateCache});
    })

    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/home");


        $stateProvider
        
            //------------------------------
            // HOME
            //------------------------------
        
            .state ('home', {
                url: '/home',
                templateUrl: 'views/home-min.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    'vendors/bower_components/fullcalendar/dist/fullcalendar.min.css'
                                ]
                            },
                            {
                                name: 'vendors',
                                insertBefore: '#app-level-js',
                                files: [
                                    'vendors/sparklines/jquery.sparkline.min.js',
                                    'vendors/bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js',
                                    'vendors/bower_components/simpleWeather/jquery.simpleWeather.min.js'
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
                templateUrl: 'views/securities-grid.html',
                controller: 'securitiesGridCtrl as vm'
            })
            
            //------------------------------
            // SECURITIES GRID
            //------------------------------

            .state('watchlist', {
                url: '/watchlist',
                templateUrl: 'views/watchlist-grid.html',
                controller: 'watchListGridCtrl as vm'
            })

            //------------------------------
            // STOCK CHART
            //------------------------------

            .state('stock-chart', {
                url: '/stock-chart',
                templateUrl: 'views/stock-chart.html',
                controller: 'stockChartCtrl as vm'
            })

            //------------------------------
            // PORTFOLIO
            //------------------------------
            .state ('portfolio', {
                url: '/portfolio',
                templateUrl: 'views/portfolio-common.html',
            })

                .state ('portfolio.active-portfolio', {
                    url: '/active-portfolio',
                    templateUrl: 'views/active-portfolio-common.html',
                    controller: 'activePortfolioCtrl as vm'
                })

                    .state('portfolio.active-portfolio.profile', {
                            url: '/profile',
                            templateUrl: 'views/active-portfolio-profile.html',
                    })
                    .state('portfolio.active-portfolio.status', {
                            url: '/status',
                            templateUrl: 'views/active-portfolio-status.html',
                    })
                    .state('portfolio.active-portfolio.adjustments', {
                        url: '/adjustments/{id}',
                        templateUrl: 'views/active-portfolio-adjustments.html',
                        controller: 'activePortfolioAdjustmentCtrl as vm',
                    })

            //------------------------------
            // SCANS
            //------------------------------
            .state('scan-profiles', {
                url: '/scan-profiles',
                templateUrl: 'views/scan-profiles.html',
                controller: 'scanProfilesCtrl as vm',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    'vendors/bower_components/bootstrap-select/dist/css/bootstrap-select.css',
                                    'vendors/chosen_v1.4.2/chosen.min.css',
                                    'vendors/bower_components/nouislider/distribute/jquery.nouislider.min.css',
                                    'vendors/farbtastic/farbtastic.css',
                                    'vendors/bower_components/summernote/dist/summernote.css',
                                    'vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css'
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    'vendors/input-mask/input-mask.min.js',
                                    'vendors/bower_components/bootstrap-select/dist/js/bootstrap-select.js',
                                    'vendors/chosen_v1.4.2/chosen.jquery.min.js',
                                    'vendors/bower_components/nouislider/distribute/jquery.nouislider.all.min.js',
                                    'vendors/bower_components/moment/min/moment.min.js',
                                    'vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js',
                                    'vendors/farbtastic/farbtastic.min.js',
                                    'vendors/bower_components/summernote/dist/summernote.min.js',
                                    'vendors/fileinput/fileinput.min.js'
                                ]
                            }
                        ])
                    }
                }
            })
            .state('scan-daily', {
                url: '/scan-daily',
                templateUrl: 'views/scan-daily.html',
            })

            
        
            //------------------------------
            // FORMS
            //------------------------------
            .state ('form', {
                url: '/form',
                templateUrl: 'views/common.html'
            })

            .state ('form.basic-form-elements', {
                url: '/basic-form-elements',
                templateUrl: 'views/form-elements.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'vendors',
                                files: [
                                    'vendors/bower_components/autosize/dist/autosize.min.js'
                                ]
                            }
                        ])
                    }
                }
            })

            .state ('form.form-components', {
                url: '/form-components',
                templateUrl: 'views/form-components.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    'vendors/bower_components/bootstrap-select/dist/css/bootstrap-select.css',
                                    'vendors/chosen_v1.4.2/chosen.min.css',
                                    'vendors/bower_components/nouislider/distribute/jquery.nouislider.min.css',
                                    'vendors/farbtastic/farbtastic.css',
                                    'vendors/bower_components/summernote/dist/summernote.css',
                                    'vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css'
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    'vendors/input-mask/input-mask.min.js',
                                    'vendors/bower_components/bootstrap-select/dist/js/bootstrap-select.js',
                                    'vendors/chosen_v1.4.2/chosen.jquery.min.js',
                                    'vendors/bower_components/nouislider/distribute/jquery.nouislider.all.min.js',
                                    'vendors/bower_components/moment/min/moment.min.js',
                                    'vendors/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js',
                                    'vendors/farbtastic/farbtastic.min.js',
                                    'vendors/bower_components/summernote/dist/summernote.min.js',
                                    'vendors/fileinput/fileinput.min.js'
                                ]
                            }
                        ])
                    }
                }
            })
        
            .state ('form.form-examples', {
                url: '/form-examples',
                templateUrl: 'views/form-examples.html'
            })
        
            .state ('form.form-validations', {
                url: '/form-validations',
                templateUrl: 'views/form-validations.html'
            })
        
            
                    
         
            
            
            //------------------------------
            // BREADCRUMB DEMO
            //------------------------------
            .state ('breadcrumb-demo', {
                url: '/breadcrumb-demo',
                templateUrl: 'views/breadcrumb-demo.html'
            })

    });

})();

