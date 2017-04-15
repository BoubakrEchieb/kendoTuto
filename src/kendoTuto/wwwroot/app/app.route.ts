module App {
    "use strict";
    function routes($routeProvider: ng.route.IRouteProvider): void {
        $routeProvider
            .when("/grid", {
                templateUrl: "app/grid/grid.html",
                controller: "GridCtrl",
                controllerAs: "vm"
            })
            .otherwise("/grid");
    }
    routes.$inject = ["$routeProvider"];
    angular.module("app")
        .config(routes);
}