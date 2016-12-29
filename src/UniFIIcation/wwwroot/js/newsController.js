(function () {
    "use strict";

    angular
        .module("news")
        .controller("newsController", newsController);

    newsController.$inject = ["$scope"];

    function newsController($http) {
        /* jshint validthis:true */

        var vm = this;
        vm.author = "nimeni";
        vm.news = [
        {
            title: "nush",
            author: vm.author,
            created: new Date(),
            text: "ldaldasdldlasdldlsdlasdas"
        },
        {
            title: "nush",
            author: vm.author,
            created: new Date(),
            text: "ldaldasdldlasdldlsdlasdas"
        },
        {
            title: "nush",
            author: vm.author,
            created: new Date(),
            text: "ldaldasdldlasdldlsdlasdas"
        },
        {
            title: "nush",
            author: vm.author,
            created: new Date(),
            text: "ldaldasdldlasdldlsdlasdas"
        },
        {
            title: "nush",
            author: vm.author,
            created: new Date(),
            text: "ldaldasdldlasdldlsdlasdas"
        }];

        activate();

        function activate() { }
    }
})();
