angular.module('stockApp').run(['$templateCache', function($templateCache) {
  'use strict';

  $templateCache.put('app/includes/footer.html',
    "Copyright &copy; 2015 Sharewealth Systems<ul class=\"f-menu\"><li><a href=\"https://www.facebook.com/sharewealthsystems\" target=\"_blank\"><i class=\"socicon socicon-facebook\"></i></a></li><li><a href=\"http://www.twitter.com/sharewealthsys\" target=\"_blank\"><i class=\"socicon socicon-twitter\"></i></a></li><li><a href=\"https://www.linkedin.com/company/share-wealth-systems\" target=\"_blank\"><i class=\"socicon socicon-linkedin\"></i></a></li><li><a href=\"https://www.youtube.com/user/sharewealthsys\" target=\"_blank\"><i class=\"socicon socicon-youtube\"></i></a></li><li><a href=\"http://www.sharewealthsystems.com.au/blog\" target=\"_blank\"><i class=\"socicon socicon-wordpress\"></i></a></li></ul>"
  );


  $templateCache.put('app/includes/header.html',
    "<ul class=\"header-inner\"><li id=\"menu-trigger\" data-target=\"mainmenu\" data-toggle-sidebar data-model-left=\"mactrl.sidebarToggle.left\" data-ng-class=\"{ 'open': mactrl.sidebarToggle.left === true }\"><div class=\"line-wrap\"><div class=\"line top\"></div><div class=\"line center\"></div><div class=\"line bottom\"></div></div></li><!--<li class=\"logo hidden-xs\">--><li class=\"logo hidden-xs\"><a href=\"/\">Beyond Charts {{ layoutSS }}</a></li><li class=\"logo hidden-lg hidden-md hidden-sm\"><a href=\"/\">BC {{ layoutSS }}</a></li><li class=\"pull-right\"><ul class=\"top-menu\"><!--<li id=\"toggle-width\">\r" +
    "\n" +
    "                <div class=\"toggle-switch\">\r" +
    "\n" +
    "                    <input id=\"tw-switch\" type=\"checkbox\" hidden=\"hidden\" data-change-layout=\"mactrl.layoutType\"> \r" +
    "\n" +
    "                    <label for=\"tw-switch\" class=\"ts-helper\"></label>\r" +
    "\n" +
    "                </div>\r" +
    "\n" +
    "            </li>--><!--<li id=\"top-search\">\r" +
    "\n" +
    "                <a class=\"tm-search\" href=\"\" data-ng-click=\"hctrl.openSearch()\"></a>\r" +
    "\n" +
    "            </li>--><li class=\"dropdown\"><a data-toggle=\"dropdown\" class=\"tm-notification\" href=\"\"><i class=\"tmn-counts\">5</i></a><div class=\"dropdown-menu dropdown-menu-lg stop-propagate pull-right\"><div class=\"listview\" id=\"notifications\"><div class=\"lv-header\">Notification<ul class=\"actions\"><li class=\"dropdown\"><a href=\"\" data-ng-click=\"hctrl.clearNotification($event)\"><i class=\"md md-done-all\"></i></a></li></ul></div><div class=\"lv-body c-overflow\"><a class=\"lv-item\" ng-href=\"\" ng-repeat=\"w in hctrl.messageResult\"><div class=\"media\"><div class=\"pull-left\"><div ng-class=\"hctrl.whatClassIsIt(w.symbol)\">{{w.symbol}}</div></div><div class=\"media-body\"><div class=\"lv-title\">{{ w.message }}</div><small class=\"lv-small\">{{ w.type }}</small></div></div></a></div><a class=\"lv-footer\" href=\"\">View Previous</a></div></div></li><li class=\"dropdown\"><a data-toggle=\"dropdown\" class=\"tm-share\" href=\"\"></a><ul class=\"dropdown-menu dm-icon pull-right\"><li><a data-ng-click=\"\" href=\"https://www.facebook.com/sharewealthsystems\" target=\"_blank\"><i class=\"socicon socicon-facebook\"></i> Facebook</a></li><li><a data-ng-click=\"\" href=\"\"><i class=\"socicon socicon-twitter\"></i> Twitter</a></li><li><a data-ng-click=\"\" href=\"\"><i class=\"socicon socicon-linkedin\"></i> LinkedIn</a></li><li><a data-ng-click=\"\" href=\"\"><i class=\"socicon socicon-youtube\"></i> YouTube</a></li><li><a data-ng-click=\"\" href=\"\"><i class=\"md md-chat\"></i> SWS Forum</a></li></ul></li><li class=\"dropdown\"><a data-toggle=\"dropdown\" class=\"tm-settings\" href=\"\"></a><ul class=\"dropdown-menu dm-icon pull-right\"><li><a data-ng-click=\"hctrl.fullScreen()\" href=\"\"><i class=\"md md-fullscreen\"></i> Toggle Fullscreen</a></li><li><a data-ng-click=\"hctrl.clearLocalStorage()\" href=\"\"><i class=\"md md-refresh\"></i> Refresh All Data</a></li><li><a href=\"\"><i class=\"md md-settings\"></i> Other Settings</a></li></ul></li><li class=\"\" data-target=\"chat\" data-toggle-sidebar data-model-right=\"mactrl.sidebarToggle.right\" data-ng-class=\"{ 'open': mactrl.sidebarToggle.right === true }\"><a class=\"tm-chat\" href=\"\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"\" data-original-title=\"Security Explorer\"></a></li></ul></li></ul><!-- Top Search Content --><div id=\"top-search-wrap\"><input type=\"text\"> <i id=\"top-search-close\" data-ng-click=\"hctrl.closeSearch()\">&times;</i></div>"
  );


  $templateCache.put('app/includes/security-explorer.html',
    "<div ng-controller=\"securityExploreCtrl as vm\" class=\"h-100\"><ul class=\"tab-nav tn-justified\" role=\"tablist\"><li role=\"presentation\" class=\"active\"><a href=\"#friends\" aria-controls=\"friends\" role=\"tab\" data-toggle=\"tab\">Securities</a></li><li role=\"presentation\"><a href=\"#online\" aria-controls=\"online\" role=\"tab\" data-toggle=\"tab\">Watchlist</a></li></ul><div class=\"chat-search\"><div class=\"fg-line\"><input type=\"text\" ng-model=\"vm.keyword\" class=\"form-control remove-clear\" placeholder=\"Search Items\"></div></div><div class=\"tab-content c-overflow h-100\"><div role=\"tabpanel\" class=\"tab-pane fade in active\" id=\"friends\"><div class=\"listview h-100\"><a class=\"lv-item\" href=\"\" ng-repeat=\"sec in vm.secResult | filter: { securityCode: vm.keyword } \" context-menu=\"vm.menuOptions(sec)\"><div class=\"media\"><div class=\"pull-left p-relative\"><div class=\"circle-pink\">{{::sec.symbol}}</div></div><div class=\"media-body\"><div class=\"lv-title\">{{::sec.securityCode}}</div><small class=\"lv-small\">{{sec.securityName +' | '+ sec.exchange}}</small> <span ng-hide data-security-id=\"{{::sec.id}}\"></span></div></div></a></div></div><div role=\"tabpanel\" class=\"tab-pane fade\" id=\"online\"><div class=\"listview h-100\"><a class=\"lv-item\" href=\"\" ng-repeat=\"wl in vm.watchlists | filter: { name: vm.keyword } \"><div class=\"media\"><!--<div class=\"pull-left p-relative\">\r" +
    "\n" +
    "                    <img class=\"lv-img-sm\" src=\"Content/img/profile-pics/2.jpg\" alt=\"\">\r" +
    "\n" +
    "                    <i class=\"chat-status-busy\"></i>\r" +
    "\n" +
    "                </div>--><div class=\"media-body\"><div class=\"lv-title\">{{::wl.name}}</div><small class=\"lv-small\">{{::wl.type}}</small> <span hidden data-watchlist-id=\"{{::wl.id}}\"></span></div></div></a></div></div></div></div>"
  );


  $templateCache.put('app/includes/sidebar-left.html',
    "<div class=\"sidebar-inner c-overflow\"><div class=\"profile-menu\"><a href=\"\" toggle-submenu><div class=\"profile-pic\"><!--<img src=\"app/img/profile-pics/ic_account_circle_white_36dp_2x.png\" alt=\"\" />--><img src=\"app/img/profile-pics/GaryStonePhoto.png\" alt=\"\"></div><div class=\"profile-info\">Gary Stone <i class=\"md md-arrow-drop-down\"></i></div></a><ul class=\"main-menu\"><li><a href=\"profile-about.html\"><i class=\"md md-person\"></i> Account Settings</a></li><li><a href=\"\"><i class=\"md md-vpn-key\"></i> Account Licenses</a></li><li><a href=\"\"><i class=\"md md-settings\"></i> Application Settings</a></li><li><a href=\"\"><i class=\"md md-devices\"></i> Sync Device</a></li><li><a href=\"\"><i class=\"md md-history\"></i> Logout</a></li></ul></div><ul class=\"main-menu\"><li data-ui-sref-active=\"active\"><a data-ui-sref=\"home\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-dashboard\"></i> Dashboard</a></li><li class=\"sub-menu\" data-ng-class=\"{ 'active toggled': mactrl.$state.includes('portfolio') }\"><a href=\"\" toggle-submenu><i class=\"md md-work\"></i> Portfolio</a><ul><li><a data-ui-sref-active=\"active\" data-ui-sref=\"portfolio.active-portfolio.profile\" data-ng-click=\"mactrl.sidebarStat($event)\">Active Portfolio</a></li><li><a data-ui-sref-active=\"active\" data-ui-sref=\"portfolio.portfolios\" data-ng-click=\"mactrl.sidebarStat($event)\">Portfolios</a></li><li><a data-ui-sref-active=\"active\" data-ui-sref=\"portfolio.active-portfolio-transactions\" data-ng-click=\"mactrl.sidebarStat($event)\">Transactions</a></li></ul></li><!--<li class=\"sub-menu\" data-ng-class=\"{ 'active toggled': mactrl.$state.includes('scans') }\">\r" +
    "\n" +
    "            <a href=\"\" toggle-submenu><i class=\"md md-wifi-tethering\"></i> Scans</a>\r" +
    "\n" +
    "            <ul>\r" +
    "\n" +
    "                <li><a data-ui-sref-active=\"active\" data-ui-sref=\"scan-profiles\" data-ng-click=\"mactrl.sidebarStat($event)\">Scan Profiles</a></li>\r" +
    "\n" +
    "                <li><a data-ui-sref-active=\"active\" data-ui-sref=\"scan-daily\" data-ng-click=\"mactrl.sidebarStat($event)\">Daily Scans</a></li>\r" +
    "\n" +
    "            </ul>\r" +
    "\n" +
    "        </li>--><li class=\"sub-menu\" data-ng-class=\"{ 'active toggled': mactrl.$state.includes('scans') }\"><a href=\"\" toggle-submenu><i class=\"md md-wifi-tethering\"></i> Scans</a><ul><li><a data-ui-sref-active=\"active\" data-ui-sref=\"scans.scan-profiles\" data-ng-click=\"mactrl.sidebarStat($event)\">Scan Profiles</a></li><li><a data-ui-sref-active=\"active\" data-ui-sref=\"scans.scan-daily\" data-ng-click=\"mactrl.sidebarStat($event)\">Daily Scans</a></li></ul></li><li data-ui-sref-active=\"active\"><a data-ui-sref=\"securities\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-account-balance\"></i> Securities</a></li><li data-ui-sref-active=\"active\"><a data-ui-sref=\"watchlist\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-visibility\"></i> Watchlist</a></li><li data-ui-sref-active=\"active\"><a data-ui-sref=\"stock-chart\" data-ng-click=\"mactrl.sidebarStat($event)\"><i class=\"md md-insert-chart\"></i> StockChart</a></li></ul></div>"
  );


  $templateCache.put('app/includes/templates.html',
    ""
  );

}]);
