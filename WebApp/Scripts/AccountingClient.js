var AccountingApp = angular.module('AccountingApp', [])
AccountingApp.controller('PricesController', function ($scope, PricesService) {
    var vm = this;
    vm.prices = [];

    getAllPrices();

    function getAllPrices() {
        PricesService.getAllPrices()
            .then(function (response) {
                vm.prices = response.data;
                console.log($scope.prices);
            });
        //.error(function (error) {
        //    $scope.status = 'Unable to load customer data: ' + error.message;
        //    console.log($scope.status);
        //});
    }
});

AccountingApp.factory('PricesService', ['$http', function ($http) {
    var PricesService = {};
    PricesService.getAllPrices = function () {
        return $http.get('/api/pricesweb');
    };
    return PricesService;
}]);