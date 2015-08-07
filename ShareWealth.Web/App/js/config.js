materialAdmin

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
                templateUrl: '/app/views/home-min.html',
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
                templateUrl: '/app/views/securities-grid.html',
                controller: 'securitiesGridCtrl as vm'
            })
            
            //------------------------------
            // SECURITIES GRID
            //------------------------------

            .state('watchlist', {
                url: '/watchlist',
                templateUrl: '/app/views/watchlist-grid.html',
                controller: 'watchListGridCtrl as vm'
            })

            //------------------------------
            // STOCK CHART
            //------------------------------

            .state('stock-chart', {
                url: '/stock-chart',
                templateUrl: '/app/views/stock-chart.html',
                controller: 'stockChartCtrl as vm'
            })

            //------------------------------
            // PORTFOLIO
            //------------------------------
            .state ('portfolio', {
                url: '/portfolio',
                templateUrl: '/app/views/portfolio-common.html',
            })

                .state ('portfolio.active-portfolio', {
                    url: '/active-portfolio',
                    templateUrl: '/app/views/active-portfolio-common.html',
                    controller: 'activePortfolioCtrl as vm'
                })

                    .state('portfolio.active-portfolio.profile', {
                            url: '/profile',
                            templateUrl: '/app/views/active-portfolio-profile.html',
                    })
                    .state('portfolio.active-portfolio.status', {
                            url: '/status',
                            templateUrl: '/app/views/active-portfolio-status.html',
                    })
                    .state('portfolio.active-portfolio.adjustments', {
                        url: '/adjustments/{id}',
                        templateUrl: '/app/views/active-portfolio-adjustments.html',
                        controller: 'activePortfolioAdjustmentCtrl as vm',
                    })
            .state('portfolio.portfolios', {
                url: '/portfolios',
                templateUrl: '/app/views/portfolioGrid.html',
                controller: 'portfolioGridCtrl as vm',
            })
            .state('portfolio.active-portfolio-transactions', {
                url: '/transactions',
                templateUrl: '/app/views/active-portfolio-transactions.html',
                controller: 'transactionCtrl as vm',
            })

            //------------------------------
            // SCANS
            //------------------------------
             .state('scans', {
                url: '/scans',
                templateUrl: '/app/views/scan-common.html',
                
            })
            .state('scans.scan-profiles', {
                url: '/scan-profiles',
                templateUrl: '/app/views/scan-profiles.html',
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
                templateUrl: '/app/views/scans-daily.html',
                controller: 'scanDailyCtrl as vm'
            })

            //------------------------------
            // WIDGETS
            //------------------------------
        
            .state ('widgets', {
                url: '/widgets',
                templateUrl: '/app/views/common.html'
            })

            .state ('widgets.widgets', {
                url: '/widgets',
                templateUrl: '/app/views/widgets.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/mediaelement/build/mediaelementplayer.css',
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/bower_components/mediaelement/build/mediaelement-and-player.js'
                                ]
                            }
                        ])
                    }
                }
            })

            .state ('widgets.widget-templates', {
                url: '/widget-templates',
                templateUrl: '/app/views/widget-templates.html'
            })


            //------------------------------
            // TABLES
            //------------------------------
        
            .state ('tables', {
                url: '/tables',
                templateUrl: '/app/views/common.html'
            })

            .state ('tables.tables', {
                url: '/tables',
                templateUrl: '/app/views/tables.html'
            })

            .state ('tables.data-tables', {
                url: '/data-tables',
                templateUrl: '/app/views/data-tables.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/jquery.bootgrid/dist/jquery.bootgrid.min.css',
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/bower_components/jquery.bootgrid/dist/jquery.bootgrid-override.min.js'
                                ]
                            }
                        ])
                    }
                }
            })

        
            //------------------------------
            // FORMS
            //------------------------------
            .state ('form', {
                url: '/form',
                templateUrl: '/app/views/common.html'
            })

            .state ('form.basic-form-elements', {
                url: '/basic-form-elements',
                templateUrl: '/app/views/form-elements.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/bower_components/autosize/dist/autosize.min.js'
                                ]
                            }
                        ])
                    }
                }
            })

            .state ('form.form-components', {
                url: '/form-components',
                templateUrl: '/app/views/form-components.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/bootstrap-select/dist/css/bootstrap-select.css',
                                    'vendors/chosen_v1.4.2/chosen.min.css',
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
        
            .state ('form.form-examples', {
                url: '/form-examples',
                templateUrl: '/app/views/form-examples.html'
            })
        
            .state ('form.form-validations', {
                url: '/form-validations',
                templateUrl: '/app/views/form-validations.html'
            })
        
            
            //------------------------------
            // USER INTERFACE
            //------------------------------
        
            .state ('user-interface', {
                url: '/user-interface',
                templateUrl: '/app/views/common.html'
            })

            .state ('user-interface.colors', {
                url: '/colors',
                templateUrl: '/app/views/colors.html'
            })

            .state ('user-interface.animations', {
                url: '/animations',
                templateUrl: '/app/views/animations.html'
            })
        
            .state ('user-interface.box-shadow', {
                url: '/box-shadow',
                templateUrl: '/app/views/box-shadow.html'
            })
        
            .state ('user-interface.buttons', {
                url: '/buttons',
                templateUrl: '/app/views/buttons.html'
            })
        
            .state ('user-interface.icons', {
                url: '/icons',
                templateUrl: '/app/views/icons.html'
            })
        
            .state ('user-interface.alerts', {
                url: '/alerts',
                templateUrl: '/app/views/alerts.html'
            })
        
            .state ('user-interface.notifications-dialogs', {
                url: '/notifications-dialogs',
                templateUrl: '/app/views/notification-dialog.html'
            })
        
            .state ('user-interface.media', {
                url: '/media',
                templateUrl: '/app/views/media.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/mediaelement/build/mediaelementplayer.css',
                                    '/app/vendors/bower_components/lightgallery/light-gallery/css/lightGallery.css'
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/bower_components/mediaelement/build/mediaelement-and-player.js',
                                    '/app/vendors/bower_components/lightgallery/light-gallery/js/lightGallery.min.js'
                                ]
                            }
                        ])
                    }
                }
            })
        
            .state ('user-interface.components', {
                url: '/components',
                templateUrl: '/app/views/components.html'
            })
        
            .state ('user-interface.other-components', {
                url: '/other-components',
                templateUrl: '/app/views/other-components.html'
            })
            
        
            //------------------------------
            // CHARTS
            //------------------------------
            
            .state ('charts', {
                url: '/charts',
                templateUrl: '/app/views/common.html'
            })

            .state ('charts.flot-charts', {
                url: '/flot-charts',
                templateUrl: '/app/views/flot-charts.html',
            })

            .state ('charts.other-charts', {
                url: '/other-charts',
                templateUrl: '/app/views/other-charts.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/sparklines/jquery.sparkline.min.js',
                                    '/app/vendors/bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js',
                                ]
                            }
                        ])
                    }
                }
            })
        
        
            //------------------------------
            // CALENDAR
            //------------------------------
            
            .state ('calendar', {
                url: '/calendar',
                templateUrl: '/app/views/calendar.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/fullcalendar/dist/fullcalendar.min.css',
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/bower_components/moment/min/moment.min.js',
                                    '/app/vendors/bower_components/fullcalendar/dist/fullcalendar.min.js'
                                ]
                            }
                        ])
                    }
                }
            })
        
        
            //------------------------------
            // GENERIC CLASSES
            //------------------------------
            
            .state ('generic-classes', {
                url: '/generic-classes',
                templateUrl: '/app/views/generic-classes.html'
            })
        
            
            //------------------------------
            // PAGES
            //------------------------------
            
            .state ('pages', {
                url: '/pages',
                templateUrl: '/app/views/common.html'
            })
            
        
            //Profile
        
            .state ('pages.profile', {
                url: '/profile',
                templateUrl: '/app/views/profile.html'
            })
        
            .state ('pages.profile.profile-about', {
                url: '/profile-about',
                templateUrl: '/app/views/profile-about.html'
            })
        
            .state ('pages.profile.profile-timeline', {
                url: '/profile-timeline',
                templateUrl: '/app/views/profile-timeline.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/lightgallery/light-gallery/css/lightGallery.css'
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/bower_components/lightgallery/light-gallery/js/lightGallery.min.js'
                                ]
                            }
                        ])
                    }
                }
            })

            .state ('pages.profile.profile-photos', {
                url: '/profile-photos',
                templateUrl: '/app/views/profile-photos.html',
                resolve: {
                    loadPlugin: function($ocLazyLoad) {
                        return $ocLazyLoad.load ([
                            {
                                name: 'css',
                                insertBefore: '#app-level',
                                files: [
                                    '/app/vendors/bower_components/lightgallery/light-gallery/css/lightGallery.css'
                                ]
                            },
                            {
                                name: 'vendors',
                                files: [
                                    '/app/vendors/bower_components/lightgallery/light-gallery/js/lightGallery.min.js'
                                ]
                            }
                        ])
                    }
                }
            })
        
            .state ('pages.profile.profile-connections', {
                url: '/profile-connections',
                templateUrl: '/app/views/profile-connections.html'
            })
        
        
            //-------------------------------
        
            .state ('pages.listview', {
                url: '/listview',
                templateUrl: '/app/views/list-view.html'
            })
        
            .state ('pages.messages', {
                url: '/messages',
                templateUrl: '/app/views/messages.html'
            })
        
            
            
            //------------------------------
            // BREADCRUMB DEMO
            //------------------------------
            .state ('breadcrumb-demo', {
                url: '/breadcrumb-demo',
                templateUrl: '/app/views/breadcrumb-demo.html'
            })

    });
