(function() {
    "use strict";

    angular
        .module("news")
        .controller("newsController", ["$http", newsController]);

    newsController.$inject = ["$scope"];

    function newsController($http) {
        /* jshint validthis:true */

        var vm = this;
        vm.news = [];
        vm.isBusy = true;
        vm.results = [];
        vm.callRestService = function() {
            $http({ method: "GET", url: "/api/get" })
                .success(function (data, status, headers, config) {
                    angular.copy(response.data, vm.news);
                });
        }

        $http.get("/api/get").then(function(response) {
                angular.copy(response.data, vm.news);
            },
            function() {
                console.log('failure: ' + status);
            }).finally(function() {
            vm.isBusy = false;
        });


        activate();

        function activate() {}
    }
})();