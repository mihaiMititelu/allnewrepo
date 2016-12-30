(function () {
    "use strict";

    angular
        .module("news")
        .controller("newsController", ["$http", newsController]);

    newsController.$inject = ["$scope"];

    function newsController($http) {
        /* jshint validthis:true */

        var vm = this;
        vm.news = [];

        $http.get("/api/get").then(function(response) {
                angular.copy(response.data, vm.news);
            },
            function() {

            });


        activate();

        function activate() { }
    }
})();
