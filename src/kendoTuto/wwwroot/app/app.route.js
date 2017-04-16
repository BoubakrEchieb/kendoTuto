var App;
(function (App) {
    "use strict";
    function routes($routeProvider) {
        $routeProvider
            .when("/grid", {
            templateUrl: "app/grid/views/grid.html",
            controller: "GridCtrl",
            controllerAs: "vm"
        })
            .otherwise("/grid");
    }
    routes.$inject = ["$routeProvider"];
    angular.module("app")
        .config(routes);
})(App || (App = {}));
