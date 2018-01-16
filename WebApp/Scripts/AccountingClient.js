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
        //return $http.get('/api/pricesweb');
        return $http({
            url: 'http://jsonstub.com/api/pricesweb',
            method: 'GET',
            dataType: 'json',
            data: '',
            headers: {
                'Content-Type': 'application/json',
                'JsonStub-User-Key': '53acf92f-5709-4c54-891c-e006cc27f918',
                'JsonStub-Project-Key': '984848d8-fb18-4bc0-9daa-17a7601e3e06'
            }
        });
    };
    return PricesService;
}]);