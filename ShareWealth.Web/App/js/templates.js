angular.module('materialAdmin').run(['$templateCache', function($templateCache) {
  'use strict';

  $templateCache.put('includes/footer.html',
    "Copyright &copy; 2015 Sharewealth Systems<ul class=\"f-menu\"><li><a href=\"\">Home</a></li><li><a href=\"\">Dashboard</a></li><li><a href=\"\">Reports</a></li><li><a href=\"\">Support</a></li><li><a href=\"\">Contact</a></li></ul>"
  );


  $templateCache.put('includes/header.html',
    "<ul class=\"header-inner\"><li id=\"menu-trigger\" data-target=\"mainmenu\" data-toggle-sidebar data-model-left=\"mactrl.sidebarToggle.left\" data-ng-class=\"{ 'open': mactrl.sidebarToggle.left === true }\"><div class=\"line-wrap\"><div class=\"line top\"></div><div class=\"line center\"></div><div class=\"line bottom\"></div></div></li><!--<li class=\"logo hidden-xs\">--><li class=\"logo hidden-xs\"><a href=\"/\">Beyond Charts {{ layoutSS }}</a></li><li class=\"logo hidden-lg hidden-md hidden-sm\"><a href=\"/\">BC {{ layoutSS }}</a></li><li class=\"pull-right\"><ul class=\"top-menu\"><li id=\"toggle-width\"><div class=\"toggle-switch\"><input id=\"tw-switch\" type=\"checkbox\" hidden data-change-layout=\"mactrl.layoutType\"><label for=\"tw-switch\" class=\"ts-helper\"></label></div></li><li id=\"top-search\"><a class=\"tm-search\" href=\"\" data-ng-click=\"hctrl.openSearch()\"></a></li><li class=\"dropdown\"><a data-toggle=\"dropdown\" class=\"tm-notification\" href=\"\"><i class=\"tmn-counts\">9</i></a><div class=\"dropdown-menu dropdown-menu-lg stop-propagate pull-right\"><div class=\"listview\" id=\"notifications\"><div class=\"lv-header\">Notification<ul class=\"actions\"><li class=\"dropdown\"><a href=\"\" data-ng-click=\"hctrl.clearNotification($event)\"><i class=\"md md-done-all\"></i></a></li></ul></div><div class=\"lv-body c-overflow\"><a class=\"lv-item\" ng-href=\"\" ng-repeat=\"w in hctrl.messageResult\"><div class=\"media\"><div class=\"pull-left\"><div ng-class=\"hctrl.whatClassIsIt(w.symbol)\">{{w.symbol}}</div></div><div class=\"media-body\"><div class=\"lv-title\">{{ w.message }}</div><small class=\"lv-small\">{{ w.type }}</small></div></div></a></div><a class=\"lv-footer\" href=\"\">View Previous</a></div></div></li><!--<li class=\"dropdown hidden-xs\">\r" +
    "\n" +
    "                <a data-toggle=\"dropdown\" class=\"tm-task\" href=\"\"><i class=\"tmn-counts\">2</i></a>\r" +
    "\n" +
    "                <div class=\"dropdown-menu pull-right dropdown-menu-lg\">\r" +
    "\n" +
    "                    <div class=\"listview\">\r" +
    "\n" +
    "                        <div class=\"lv-header\">\r" +
    "\n" +
    "                            Tasks\r" +
    "\n" +
    "                        </div>\r" +
    "\n" +
    "                        <div class=\"lv-body\">\r" +
    "\n" +
    "                            <div class=\"lv-item\">\r" +
    "\n" +
    "                                <div class=\"lv-title m-b-5\">HTML5 Validation Report</div>\r" +
    "\n" +
    "\r" +
    "\n" +
    "                                <div class=\"progress\">\r" +
    "\n" +
    "                                    <div class=\"progress-bar\" role=\"progressbar\" aria-valuenow=\"95\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: 95%\">\r" +
    "\n" +
    "                                        <span class=\"sr-only\">95% Complete (success)</span>\r" +
    "\n" +
    "                                    </div>\r" +
    "\n" +
    "                                </div>\r" +
    "\n" +
    "                            </div>\r" +
    "\n" +
    "                            <div class=\"lv-item\">\r" +
    "\n" +
    "                                <div class=\"lv-title m-b-5\">Google Chrome Extension</div>\r" +
    "\n" +
    "\r" +
    "\n" +
    "                                <div class=\"progress\">\r" +
    "\n" +
    "                                    <div class=\"progress-bar progress-bar-success\" role=\"progressbar\" aria-valuenow=\"80\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: 80%\">\r" +
    "\n" +
    "                                        <span class=\"sr-only\">80% Complete (success)</span>\r" +
    "\n" +
    "                                    </div>\r" +
    "\n" +
    "                                </div>\r" +
    "\n" +
    "                            </div>\r" +
    "\n" +
    "                            <div class=\"lv-item\">\r" +
    "\n" +
    "                                <div class=\"lv-title m-b-5\">Social Intranet Projects</div>\r" +
    "\n" +
    "\r" +
    "\n" +
    "                                <div class=\"progress\">\r" +
    "\n" +
    "                                    <div class=\"progress-bar progress-bar-info\" role=\"progressbar\" aria-valuenow=\"20\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: 20%\">\r" +
    "\n" +
    "                                        <span class=\"sr-only\">20% Complete</span>\r" +
    "\n" +
    "                                    </div>\r" +
    "\n" +
    "                                </div>\r" +
    "\n" +
    "                            </div>\r" +
    "\n" +
    "                            <div class=\"lv-item\">\r" +
    "\n" +
    "                                <div class=\"lv-title m-b-5\">Bootstrap Admin Template</div>\r" +
    "\n" +
    "\r" +
    "\n" +
    "                                <div class=\"progress\">\r" +
    "\n" +
    "                                    <div class=\"progress-bar progress-bar-warning\" role=\"progressbar\" aria-valuenow=\"60\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: 60%\">\r" +
    "\n" +
    "                                        <span class=\"sr-only\">60% Complete (warning)</span>\r" +
    "\n" +
    "                                    </div>\r" +
    "\n" +
    "                                </div>\r" +
    "\n" +
    "                            </div>\r" +
    "\n" +
    "                            <div class=\"lv-item\">\r" +
    "\n" +
    "                                <div class=\"lv-title m-b-5\">Youtube Client App</div>\r" +
    "\n" +
    "\r" +
    "\n" +
    "                                <div class=\"progress\">\r" +
    "\n" +
    "                                    <div class=\"progress-bar progress-bar-danger\" role=\"progressbar\" aria-valuenow=\"80\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: 80%\">\r" +
    "\n" +
    "                                        <span class=\"sr-only\">80% Complete (danger)</span>\r" +
    "\n" +
    "                                    </div>\r" +
    "\n" +
    "                                </div>\r" +
    "\n" +
    "                            </div>\r" +
    "\n" +
    "                        </div>\r" +
    "\n" +
    "\r" +
    "\n" +
    "                        <a class=\"lv-footer\" href=\"\">View All</a>\r" +
    "\n" +
    "                    </div>\r" +
    "\n" +
    "                </div>\r" +
    "\n" +
    "            </li>--><li class=\"dropdown\"><a data-toggle=\"dropdown\" class=\"tm-settings\" href=\"\"></a><ul class=\"dropdown-menu dm-icon pull-right\"><li><a data-ng-click=\"hctrl.fullScreen()\" href=\"\"><i class=\"md md-fullscreen\"></i> Toggle Fullscreen</a></li><li><a data-ng-click=\"hctrl.clearLocalStorage()\" href=\"\"><i class=\"md md-delete\"></i> Clear Local Storage</a></li><li><a href=\"\"><i class=\"md md-person\"></i> Privacy Settings</a></li><li><a href=\"\"><i class=\"md md-settings\"></i> Other Settings</a></li></ul></li><li class=\"\" data-target=\"chat\" data-toggle-sidebar data-model-right=\"mactrl.sidebarToggle.right\" data-ng-class=\"{ 'open': mactrl.sidebarToggle.right === true }\"><a class=\"tm-chat\" href=\"\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"\" data-original-title=\"Security Explorer\"></a></li></ul></li></ul><!-- Top Search Content --><div id=\"top-search-wrap\"><input type=\"text\"> <i id=\"top-search-close\" data-ng-click=\"hctrl.closeSearch()\">&times;</i></div>"
  );


  $templateCache.put('includes/security-explorer.html',
    "<div ng-controller=\"securityExploreCtrl as vm\" class=\"h-100\"><ul class=\"tab-nav tn-justified\" role=\"tablist\"><li role=\"presentation\" class=\"active\"><a href=\"#friends\" aria-controls=\"friends\" role=\"tab\" data-toggle=\"tab\">Securities</a></li><li role=\"presentation\"><a href=\"#online\" aria-controls=\"online\" role=\"tab\" data-toggle=\"tab\">Watchlist</a></li></ul><div class=\"chat-search\"><div class=\"fg-line\"><input type=\"text\" ng-model=\"vm.keyword\" class=\"form-control remove-clear\" placeholder=\"Search Items\"></div></div><div class=\"tab-content c-overflow h-100\"><div role=\"tabpanel\" class=\"tab-pane fade in active\" id=\"friends\"><div class=\"listview h-100\"><a class=\"lv-item\" href=\"\" ng-repeat=\"sec in vm.secResult | filter: { securityCode: vm.keyword } \"><div class=\"media\"><div class=\"pull-left p-relative\"><div class=\"circle-pink\">{{::sec.symbol}}</div></div><div class=\"media-body\"><div class=\"lv-title\">{{::sec.securityCode}}</div><small class=\"lv-small\">{{sec.securityName +' | '+ sec.exchange}}</small> <span ng-hide data-security-id=\"{{::sec.id}}\"></span></div></div></a></div></div><div role=\"tabpanel\" class=\"tab-pane fade\" id=\"online\"><div class=\"listview h-100\"><a class=\"lv-item\" href=\"\" ng-repeat=\"wl in vm.watchlists | filter: { name: vm.keyword } \"><div class=\"media\"><!--<div class=\"pull-left p-relative\">\r" +
    "\n" +
    "                    <img class=\"lv-img-sm\" src=\"Content/img/profile-pics/2.jpg\" alt=\"\">\r" +
    "\n" +
    "                    <i class=\"chat-status-busy\"></i>\r" +
    "\n" +
    "                </div>--><div class=\"media-body\"><div class=\"lv-title\">{{::wl.name}}</div><small class=\"lv-small\">{{::wl.type}}</small> <span hidden data-watchlist-id=\"{{::wl.id}}\"></span></div></div></a></div></div></div></div>"
  );


  $templateCache.put('includes/sidebar-left.html',
    "<div class=\"sidebar-inner c-overflow\"><div class=\"profile-menu\"><a href=\"\" toggle-submenu><div class=\"profile-pic\"><img src=\"img/profile-pics/ic_account_circle_white_36dp_2x.png\" alt=\"\"><!--<img src=\"img/profile-pics/GaryStonePhoto.png\" alt=\"\">--></div><div class=\"profile-info\">Gary Stone <i class=\"md md-arrow-drop-down\"></i></div></a><ul class=\"main-menu\"><li><a href=\"profile-about.html\"><i class=\"md md-person\"></i> Account Settings</a></li><li><a href=\"\"><i class=\"md md-vpn-key\"></i> Account Licenses</a></li><li><a href=\"\"><i class=\"md md-settings\"></i> Application Settings</a></li><li><a href=\"\"><i class=\"md md-history\"></i> Logout</a></li></ul></div><ul class=\"main-menu\"><li data-ui-sref-active=\"active\"><a data-ui-sref=\"home\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-dashboard\"></i> Dashboard</a></li><li class=\"sub-menu\" data-ng-class=\"{ 'active toggled': mactrl.$state.includes('portfolio') }\"><a href=\"\" toggle-submenu><i class=\"md md-work\"></i> Portfolio</a><ul><li><a data-ui-sref-active=\"active\" data-ui-sref=\"portfolio.active-portfolio.profile\" data-ng-click=\"mactrl.sidebarStat($event)\">Active Portfolio</a></li><li><a data-ui-sref-active=\"active\" data-ui-sref=\"portfolio.portfolios\" data-ng-click=\"mactrl.sidebarStat($event)\">Portfolios</a></li><li><a data-ui-sref-active=\"active\" data-ui-sref=\"portfolio.transactions\" data-ng-click=\"mactrl.sidebarStat($event)\">Transactions</a></li></ul></li><li class=\"sub-menu\" data-ng-class=\"{ 'active toggled': mactrl.$state.includes('scans') }\"><a href=\"\" toggle-submenu><i class=\"md md-wifi-tethering\"></i> Scans</a><ul><li><a data-ui-sref-active=\"active\" data-ui-sref=\"scans.daily\" data-ng-click=\"mactrl.sidebarStat($event)\">Active Portfolio</a></li><li><a data-ui-sref-active=\"active\" data-ui-sref=\"scans.scans\" data-ng-click=\"mactrl.sidebarStat($event)\">Portfolios</a></li></ul></li><li data-ui-sref-active=\"active\"><a data-ui-sref=\"securities\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-account-balance\"></i> Securities</a></li><li data-ui-sref-active=\"active\"><a data-ui-sref=\"watchlist\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-visibility\"></i> Watchlist</a></li><li data-ui-sref-active=\"active\"><a data-ui-sref=\"stock-chart\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-insert-chart\"></i> StockChart</a></li></ul></div>"
  );


  $templateCache.put('includes/templates.html',
    ""
  );

}]);
