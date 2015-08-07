materialAdmin
    // =========================================================================
    // Securities used by security Explorer
    // =========================================================================

    .factory('securityService', ['$http', function ($http) {
        function securities(){
            return $http.get('api/Security');
        }
        function securitiesExtended() {
            return $http.get('api/SecurityExtended');
        }
        function watchlists(){
            return $http.get('api/Watchlist');
        }
        function priceData(){
            return $http.get('api/PriceData');
        }
        return {
            getSecurities: securities,
            getExtendedSecurities: securitiesExtended,
            getWatchlist: watchlists,
            getPriceData: priceData,
        }

    }])

    // =========================================================================
    // Watchlist servce
    // =========================================================================

    .service('watchlistService', ['$http', function ($http) {
        function addWatchlist(data) {
            return $http.post('api/watchlists/add', JSON.stringify(data), {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).success(function (data) {
                alert('ahoo');
            });
        };
        return {
            getWatchlist: function () {
                return $http.get('api/watchlist');
            },
            getWatchlistSecurities: function () {
                return $http.get('api/watchlistSecurities');
            },
            addWatchlist: function(data) {
                //return $http.get('api/watchlist');
                return $http.post('api/watchlist/add', JSON.stringify(data), {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                ).success(function (data) {
                    return data;
                });
            }
        }
    }])

    // =========================================================================
    // Portfolio servce
    // =========================================================================
        .factory('portfolioService', ['$http','$stateParams', function ($http, $stateParams) {
            function adjustments() {
                return $http.get('api/PortfolioAdjustment', 
                    { params: { id: $stateParams.id } }
                );
            }
            function transactions(){
                return $http.get('api/stockTransactions');
            };
            function portfolios(){
                return $http.get('api/portfolios');
            };
            return {
                getAdjustments: adjustments,
                getTransactions: transactions,
                getPortfolios: portfolios
            }
        }])
    
    // =========================================================================
    // Watchlist servce
    // =========================================================================

    .factory('scanService', ['$http', function ($http) {
        function addScanProfile(data)
        {
            return   $http.post('api/watchlists/add', JSON.stringify(data), {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).success(function (data) {
                alert('ahoo');
            });
        };
        return {
            getScanProfiles: function () {
                return $http.get('api/scanProfiles')
            },
            getDailyScans: function () {
                return $http.get('api/scanResults')
            },
            addScanProfile: addScanProfile
        }
    }])
    // =========================================================================
    // Header Messages and Notifications list Data
    // =========================================================================

    .service('messageService', ['$http', function ($http) {

        return {
            get: function () {
                return $http.get('api/Notification');
            }
        }
    }])


    // =========================================================================
    // Best Selling Widget Data (Home Page)
    // =========================================================================

    .service('bestsellingService', ['$resource', function ($resource) {
        this.getBestselling = function (img, name, range) {
            var gbList = $resource("data/best-selling.json");
            alert(gbList);
            return gbList.get({
                img: img,
                name: name,
                range: range,
            });
        }
    }])


    // =========================================================================
    // Todo List Widget Data
    // =========================================================================

    .service('todoService', ['$resource', function ($resource) {
        this.getTodo = function (todo) {
            var todoList = $resource("data/todo.json");

            return todoList.get({
                todo: todo
            });
        }
    }])


    // =========================================================================
    // Recent Items Widget Data
    // =========================================================================

    .service('recentitemService', ['$resource', function ($resource) {
        this.getRecentitem = function (id, name, price) {
            var recentitemList = $resource("data/recent-items.json");

            return recentitemList.get({
                id: id,
                name: name,
                price: price
            })
        }
    }])


    // =========================================================================
    // Recent Posts Widget Data
    // =========================================================================

    .service('recentpostService', ['$resource', function ($resource) {
        this.getRecentpost = function (img, user, text) {
            var recentpostList = $resource("data/messages-notifications.json");

            return recentpostList.get({
                img: img,
                user: user,
                text: text
            })
        }
    }])


    // =========================================================================
    // Nice Scroll - Custom Scroll bars
    // =========================================================================
    .service('nicescrollService', function () {
        var ns = {};
        ns.niceScroll = function (selector, color, cursorWidth) {
            $(selector).niceScroll({
                cursorcolor: color,
                cursorborder: 0,
                cursorborderradius: 0,
                cursorwidth: cursorWidth,
                bouncescroll: true,
                mousescrollstep: 100,
                autohidemode: false
            });
        }

        return ns;
    })


    //==============================================
    // BOOTSTRAP GROWL
    //==============================================

    .service('growlService', function () {
        var gs = {};
        gs.growl = function (message, type) {
            $.growl({
                message: message
            }, {
                type: type,
                allow_dismiss: false,
                label: 'Cancel',
                className: 'btn-xs btn-inverse',
                placement: {
                    from: 'top',
                    align: 'right'
                },
                delay: 2500,
                animate: {
                    enter: 'animated bounceIn',
                    exit: 'animated bounceOut'
                },
                offset: {
                    x: 20,
                    y: 85
                }
            });
        }

        return gs;
    })
