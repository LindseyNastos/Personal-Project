(function () {

    var app = angular.module('QuinterestApp');

    //PINS

    app.controller('PinIndexController', ['$resource', '$location', '$modal', function ($resource, $location, $modal) {
        var self = this;
        
        var Pin = $resource('/api/pins/:id');
        self.pins = Pin.query();

        var Board = $resource('/api/boards/:id');
        self.boards = Board.query();

        self.pinItModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/modals/pinItModal.html',
                controller: 'PinItController',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    },
                    boards: function () {
                        return boards;
                    }
                }
            });
        };

    }]);


    app.controller('PinDetailsController', ['$resource', '$location', '$modal', function ($resource, $location, $modal) {
        var self = this;

        self.pinItModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/modals/pinItModal.html',
                controller: 'PinItController',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });
        };

    }]);


    app.controller('PinItController', ['id', '$resource', '$modalInstance', function (id, $resource, $modalInstance) {
        var self = this;
        
        var Board = $resource('/api/boards/:id');
        self.boards = Board.query();

        var Pin = $resource('/api/pins/:id');
        self.pin = Pin.get({ id: id });

        self.exit = function () {
            $modalInstance.close();
        };
    }]);


    app.controller('PinCreateController', function () {
        var self = this;
        //change this!!! --> only temporary
        self.createPin = function () {
            console.dir(self.pin);
        };
    });





    //BOARDS

    app.controller('BoardIndexController', function () {
        var self = this;
        self.boards = boards;
    });


    app.controller('BoardDetailsController', ['$routeParams', function ($routeParams) {
        var self = this;
        self.pins = pins.filter(function (item) {
            return item.boardId == $routeParams.id;
        })

        self.board = boards.filter(function (item) {
            return item.id == $routeParams.id;
        })[0];
    }]);

    app.controller('BoardCreateController', function () {
        var self = this;
        //change this!!! --> only temporary
        self.createBoard = function () {
            console.dir(self.board);
        };
    });




    //LOGIN

    app.controller('AccountController', function ($http) {
        var self = this;

        self.login = function () {
            self.loginMessage = '';
            var data = "grant_type=password&username=" + self.login.email + "&password=" + self.login.password;

            $http.post('/Token', data,
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (result) {
                self.login = null;
                $http.defaults.headers.common['Authorization'] = 'bearer ' + result.access_token;
                $http.get('/api/admin/isAdmin').success(function (isAdmin) {
                    sessionStorage.setItem('accessToken', result.access_token);
                    sessionStorage.setItem('isAdmin', isAdmin);
                })
            }).error(function () {
                self.loginMessage = 'Invalid user name/password';
            });
        };

        self.logout = function () {
            sessionStorage.removeItem('accessToken');
            sessionStorage.removeItem('isAdmin');
        };

        self.isAdmin = function () {
            return sessionStorage.getItem('isAdmin') === 'true';
        };

        self.isLoggedIn = function () {
            return sessionStorage.getItem('accessToken') != undefined;
        };


    });




})();