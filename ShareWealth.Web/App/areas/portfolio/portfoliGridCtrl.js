(function(){
    'use strict';
    
    angular.module('stockApp')
    .controller('portfolioGridCtrl', function(portfolioService){
         var vm = this;
          
          var readDataMain = function (options) {
              return portfolioService.getPortfolios().then(function (result) {
                  options.success(result.data);
                  vm.localData = result.data;
              });
          };
          vm.selected = {};
          vm.showValue = function () {
              alert(vm.selected.name);
          };
          

          vm.gridData = new kendo.data.DataSource({
              transport: {
                  read: readDataMain,
                  //create: addData
              },
              schema: {
                  model: {
                      id: "id",
                      fields: {
                          id: { type: "string", editable: false, nullable: true },
                          name: { type: "string" },
                          system: { type: "string" },
                          currency: { type: "string" },
                      }
                  }
              },
              pageSize: 20
          });

          vm.gridColumns = [
            //{ field: "id", title: "Id", width: 120 },
            { field: "name", title: "Name" },
            { field: "currency", title: "Currency" },
            { field: "system", title: "System", width: 160, filterable: { multi: true } },
          ];

          //http://ernpac.net/?p=566
          vm.mainGridOptions = {
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
              dataBound: function () {
                  $(".k-grid-content tbody").find("tr").addClass("hasMenu");

              }
          };
    })
})();