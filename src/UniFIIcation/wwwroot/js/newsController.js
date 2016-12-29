(function () {
    "use strict";

    angular
        .module("app-news")
        .controller("newsController", newsController);

    newsController.$inject = ["$scope"];

    function newsController() {
        /* jshint validthis:true */
        var vm = this;
        vm.author = "nimeni";
        vm.news = [
            {
                title: "Nu se fac ore de Crăciun",
                text: "ladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladida",
                author: vm.author,
                created: new Date()
            },
            {
                title: "Nu se fac ore de Crăciun",
                text: "ladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladida",
                author: vm.author,
                created: new Date()
            },
            {
                title: "Nu se fac ore de Crăciun",
                text: "ladiladiladida",
                author: vm.author,
                created: new Date()
            }
        ];
        
        activate();

        function activate() { }
    }
})();
