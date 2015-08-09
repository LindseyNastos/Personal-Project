(function () {
    angular.module('QuinterestApp', ['ngRoute', 'ngResource', 'ui.bootstrap']).config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/ngViews/pins/index.html',
                controller: 'PinIndexController',
                controllerAs: 'main'
            })
            .when('/pinDetails/:id', {
                templateUrl: '/ngViews/pins/pinDetails.html',
                controller: 'PinDetailsController',
                controllerAs: 'main'
            })
            .when('/pinCreate', {
                templateUrl: '/ngViews/pins/pinCreate.html',
                controller: 'PinCreateController',
                controllerAs: 'main'
            })
            .when('/profile', {
                templateUrl: '/ngViews/boards/boardIndex.html',
                controller: 'BoardIndexController',
                controllerAs: 'main'
            })
            .when('/boardDetails/:id', {
                templateUrl: '/ngViews/boards/boardDetails.html',
                controller: 'BoardDetailsController',
                controllerAs: 'main'
            })
            .when('/boardCreate', {
                templateUrl: '/ngViews/boards/boardCreate.html',
                controller: 'BoardCreateController',
                controllerAs: 'main'
            })
            .otherwise({
                templateUrl: '/ngViews/notFound.html'
            });

        $locationProvider.html5Mode(true);

    });

})();