var DemoClosure = function () {
    angular.module('demoApp', [])
          .controller('DemoCtrl', [function () {
              console.log("DemoCtrl has been created");
          }]);
}();