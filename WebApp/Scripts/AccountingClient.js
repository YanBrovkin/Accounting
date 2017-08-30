var AccountingApp = angular.module('AccountingApp', []);
AccountingApp.controller('PricesController', function ($scope, PricesService) {
    var vm = this;
    vm.prices = [];

    getAllPrices();

    function getAllPrices() {
        PricesService.getAllPrices()
            .then(
            function (response) {
                vm.prices = response.data;
                console.log(vm.prices);
            },
            function (reason) {
                console.log('Failed: ' + reason);
            });
    }
});

AccountingApp.factory('PricesService', ['$http', function ($http) {
    var PricesService = {};
    PricesService.getAllPrices = function () {
        return $http.get('/api/pricesweb');
    };
    return PricesService;
}]);