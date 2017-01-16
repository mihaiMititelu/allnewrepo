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
        vm.tooLong = false;

        $http.get("/api/getnews").then(function(response) {
                angular.copy(response.data, vm.news);
                console.log(response.data);
            },
            function() {
                console.log("failure: " + status);
            }).finally(function() {
            vm.isBusy = false;
        });

        activate();

        function activate() {}
    }
})();