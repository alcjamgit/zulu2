materialAdmin
    // =========================================================================
    // Base controller for common functions
    // =========================================================================

    .controller('materialadminCtrl', function ($timeout, $state, growlService) {
        //Welcome Message
        growlService.growl('Welcome back John Doe!', 'inverse')


        // Detact Mobile Browser
        if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            angular.element('html').addClass('ismobile');
        }

        // By default Sidbars are hidden in boxed layout and in wide layout only the right sidebar is hidden.
        this.sidebarToggle = {
            left: false,
            right: false
        }

        // By default template has a boxed layout
        this.layoutType = localStorage.getItem('ma-layout-status');

        // For Mainmenu Active Class
        this.$state = $state;

        //Close sidebar on click
        this.sidebarStat = function (event) {
            if (!angular.element(event.target).parent().hasClass('active')) {
                this.sidebarToggle.left = false;
            }
        }
    })


    // =========================================================================
    // Header
    // =========================================================================
    .controller('headerCtrl', function ($timeout, messageService) {

        var vm = this;
        // Top Search
        vm.openSearch = function () {
            angular.element('#header').addClass('search-toggled');
            //growlService.growl('Welcome back Mallinda Hollaway', 'inverse');
        }

        vm.closeSearch = function () {
            angular.element('#header').removeClass('search-toggled');
        }

        // Get messages and notification for header
        //this.img = messageService.img;
        //this.user = messageService.user;
        //this.user = messageService.text;

        //this.messageResult = messageService.getMessage(this.img, this.user, this.text);

        messageService.get().then(function (result) {
            vm.messageResult = result.data;
        });

        //Clear Notification
        vm.clearNotification = function ($event) {
            $event.preventDefault();

            var x = angular.element($event.target).closest('.listview');
            var y = x.find('.lv-item');
            var z = y.size();

            angular.element($event.target).parent().fadeOut();

            x.find('.list-group').prepend('<i class="grid-loading hide-it"></i>');
            x.find('.grid-loading').fadeIn(1500);
            var w = 0;

            y.each(function () {
                var z = $(this);
                $timeout(function () {
                    z.addClass('animated fadeOutRightBig').delay(1000).queue(function () {
                        z.remove();
                    });
                }, w += 150);
            })

            $timeout(function () {
                angular.element('#notifications').addClass('empty');
            }, (z * 150) + 200);
        }

        // Clear Local Storage
        vm.clearLocalStorage = function () {

            //Get confirmation, if confirmed clear the localStorage
            swal({
                title: "Are you sure?",
                text: "All your saved localStorage values will be removed",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#F44336",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                localStorage.clear();
                swal("Done!", "localStorage is cleared", "success");
            });

        }

        //Fullscreen View
        vm.fullScreen = function () {
            //Launch
            function launchIntoFullscreen(element) {
                if (element.requestFullscreen) {
                    element.requestFullscreen();
                } else if (element.mozRequestFullScreen) {
                    element.mozRequestFullScreen();
                } else if (element.webkitRequestFullscreen) {
                    element.webkitRequestFullscreen();
                } else if (element.msRequestFullscreen) {
                    element.msRequestFullscreen();
                }
            }

            //Exit
            function exitFullscreen() {
                if (document.exitFullscreen) {
                    document.exitFullscreen();
                } else if (document.mozCancelFullScreen) {
                    document.mozCancelFullScreen();
                } else if (document.webkitExitFullscreen) {
                    document.webkitExitFullscreen();
                }
            }

            if (exitFullscreen()) {
                launchIntoFullscreen(document.documentElement);
            }
            else {
                launchIntoFullscreen(document.documentElement);
            }
        }

        //Conditional Class
        vm.whatClassIsIt = function (scanType) {
            if(scanType=="S")
                return "circle-red"
            else if(scanType=="B")
                return "circle-green";
            else
                return "circle-blue";
        }
    })



    // =========================================================================
    // Best Selling Widget
    // =========================================================================

    .controller('bestsellingCtrl', function (bestsellingService) {
        // Get Best Selling widget Data
        this.img = bestsellingService.img;
        this.name = bestsellingService.name;
        this.range = bestsellingService.range;

        this.bsResult = bestsellingService.getBestselling(this.img, this.name, this.range);
    })


    // =========================================================================
    // Todo List Widget
    // =========================================================================

    .controller('todoCtrl', function (todoService) {

        //Get Todo List Widget Data
        this.todo = todoService.todo;

        this.tdResult = todoService.getTodo(this.todo);

        //Add new Item (closed by default)
        this.addTodoStat = 0;

        //Dismiss
        this.clearTodo = function (event) {
            this.addTodoStat = 0;
            this.todo = '';
        }
    })


    // =========================================================================
    // Recent Items Widget
    // =========================================================================

    .controller('recentitemCtrl', function (recentitemService) {

        //Get Recent Items Widget Data
        this.id = recentitemService.id;
        this.name = recentitemService.name;
        this.parseInt = recentitemService.price;

        this.riResult = recentitemService.getRecentitem(this.id, this.name, this.price);
    })


    // =========================================================================
    // Recent Posts Widget
    // =========================================================================

    .controller('recentpostCtrl', function (recentpostService) {

        //Get Recent Posts Widget Items
        this.img = recentpostService.img;
        this.user = recentpostService.user;
        this.text = recentpostService.text;

        this.rpResult = recentpostService.getRecentpost(this.img, this.user, this.text);
    })


    //=================================================
    // Profile
    //=================================================

    .controller('profileCtrl', function (growlService) {

        //Get Profile Information from profileService Service

        //User
        this.profileSummary = "Sed eu est vulputate, fringilla ligula ac, maximus arcu. Donec sed felis vel magna mattis ornare ut non turpis. Sed id arcu elit. Sed nec sagittis tortor. Mauris ante urna, ornare sit amet mollis eu, aliquet ac ligula. Nullam dolor metus, suscipit ac imperdiet nec, consectetur sed ex. Sed cursus porttitor leo.";

        this.fullName = "John Doe";
        this.gender = "male";
        this.birthDay = "23/06/1978";
        this.martialStatus = "Married";
        this.mobileNumber = "00971123456789";
        this.emailAddress = "JohnDoeh@gmail.com";
        this.twitter = "@johnDoe";
        this.twitterUrl = "twitter.com/john";
        this.skype = "john.doe";
        this.addressSuite = "10098 ABC Towers";
        this.addressCity = "Sydney";
        this.addressCountry = "Australia";


        //Edit
        this.editSummary = 0;
        this.editInfo = 0;
        this.editContact = 0;


        this.submit = function (item, message) {
            if (item === 'profileSummary') {
                this.editSummary = 0;
            }

            if (item === 'profileInfo') {
                this.editInfo = 0;
            }

            if (item === 'profileContact') {
                this.editContact = 0;
            }

            growlService.growl(message + ' has updated Successfully!', 'inverse');
        }

    })



    //=================================================
    // LOGIN
    //=================================================

    .controller('loginCtrl', function () {

        //Status

        this.login = 1;
        this.register = 0;
        this.forgot = 0;
    })


    //=================================================
    // CALENDAR
    //=================================================

    .controller('calendarCtrl', function () {

        //Create and add Action button with dropdown in Calendar header. 
        this.month = 'month';

        this.actionMenu = '<ul class="actions actions-alt" id="fc-actions">' +
                            '<li class="dropdown">' +
                                '<a href="" data-toggle="dropdown"><i class="md md-more-vert"></i></a>' +
                                '<ul class="dropdown-menu dropdown-menu-right">' +
                                    '<li class="active">' +
                                        '<a data-calendar-view="month" href="">Month View</a>' +
                                    '</li>' +
                                    '<li>' +
                                        '<a data-calendar-view="basicWeek" href="">Week View</a>' +
                                    '</li>' +
                                    '<li>' +
                                        '<a data-calendar-view="agendaWeek" href="">Agenda Week View</a>' +
                                    '</li>' +
                                    '<li>' +
                                        '<a data-calendar-view="basicDay" href="">Day View</a>' +
                                    '</li>' +
                                    '<li>' +
                                        '<a data-calendar-view="agendaDay" href="">Agenda Day View</a>' +
                                    '</li>' +
                                '</ul>' +
                            '</div>' +
                        '</li>';



        //Calendar Event Data
        this.calendarData = {
            eventName: ''
        };

        //Tags
        this.tags = [
            'bgm-teal',
            'bgm-red',
            'bgm-pink',
            'bgm-blue',
            'bgm-lime',
            'bgm-green',
            'bgm-cyan',
            'bgm-orange',
            'bgm-purple',
            'bgm-gray',
            'bgm-black',
        ]

        this.onTagClick = function (tag, $index) {
            this.activeState = $index;
            this.activeTagColor = tag;
        }

        //Open new event modal on selecting a day
        this.onSelect = function (argStart, argEnd) {
            $('#addNew-event').modal('show');
            this.calendarData.getStart = argStart;
            this.calendarData.getEnd = argEnd;
        }

        //Add new event
        this.addEvent = function () {
            var tagColor = $('.event-tag > span.selected').data('tag');

            if (this.calendarData.eventName.length > 0) {

                //Render Event
                $('#calendar').fullCalendar('renderEvent', {
                    title: this.calendarData.eventName,
                    start: this.calendarData.getStart,
                    end: this.calendarData.getEnd,
                    allDay: true,
                    className: this.activeTagColor

                }, true); //Stick the event

                this.activeState = -1;
                this.calendarData.eventName = '';
                $('#addNew-event').modal('hide');
            }
        }


    })

    //=================================================
    // SECURITY EXPLORER
    //=================================================
    .controller('securityExploreCtrl', function (securitiesExploreService) {
        var vm = this;
        vm.keyword = "";

        securitiesExploreService.get().then(function (result) {
            vm.secResult = result.data;
        });

        //vm.id = securitiesExploreService.id;
        //vm.securityCode = securitiesExploreService.securityCode;
        //vm.securityName = securitiesExploreService.securityName;
        //vm.exchange = securitiesExploreService.exchange;
        //vm.secResult = securitiesExploreService.getSecurities(vm.id, vm.securityCode, vm.securityName, vm.exchange);


        vm.watchlists = [
            { name: "All Ordinaries", type: "Industry Watchlist" },
            { name: "Energy Industry", type: "Industry Watchlist" },
            { name: "Technology", type: "Industry Watchlistt" },
            { name: "Automotive", type: "Industry Watchlist" },
            { name: "Entertainment", type: "Your Watchlist" },
            { name: "Portfolio A", type: "Your Watchlist" },
            { name: "Portfolio B", type: "Your Watchlist" },
        ];
    })

     //=================================================
    // SECURITY EXPLORER
    //=================================================
    .controller('securitiesGridCtrl', function (securitiesList) {
        var vm = this;
        vm.secResult = securitiesList.getSecurities;

        vm.mainGridOptions = {
            dataSource: {
                data: vm.secResult,
                schema: {
                    model: {
                        fields: {
                            code: { type: "string" },
                            securityName: { type: "string" },
                            exchange: { type: "string" },
                            type: { type: "string" },
                            icbIndustry: { type: "string" },
                        }
                    }
                },
                pageSize: 20
            },
            height: 600,
            scrollable: true,
            sortable: true,
            filterable: true,
            selectable: true,
            navigatable: true,
            groupable:true,
            pageable: {
                input: true,
                numeric: false
            },
            columns: [
                { field: "code", title: "Code", width: "80px"},
                { field: "securityName", title: "Security Name" },
                { field: "type", title: "Type", width: "160px", filterable: { multi: true } },
                { field: "exchange", title: "Exchange", width: "160px", filterable: { multi: true } },
                { field: "close" , title: "Closing Price", width: "160px", format: "{0:c}"},
            ],
            dataBound: function () {
                $(".k-grid-content tbody").find("tr").addClass("hasMenu");
            }
        };

        //Context menu
        vm.menuOpen = 0;
        vm.onSelect = function (e) {
            console.log("Test");
            vm.selected = $(e.item).children(".k-link").text();
        };

    })