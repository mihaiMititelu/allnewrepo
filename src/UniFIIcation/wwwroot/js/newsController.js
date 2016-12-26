(function () {
    'use strict';

    angular
        .module('app-news')
        .controller('newsController', newsController);

    newsController.$inject = ['$scope'];

    function newsController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.author = "neica nimeni lol";
        vm.news = [
            {
                title: "Nu se fac ore de Crăciun",
                text: "ladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladidaladiladiladida",
                author: vm.author,
                created: new Date()
            },
            {
                title: "Nu se fac ore de Crăciun",
                text: "ladiladiladida",
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
