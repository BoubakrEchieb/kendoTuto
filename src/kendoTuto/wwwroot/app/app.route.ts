module App {
    "use strict";
    function routes($routeProvider: ng.route.IRouteProvider): void {
        $routeProvider
            .when("/grid", {
                templateUrl: "app/grid/views/grid.html",
                controller: "GridCtrl",
                controllerAs: "vm"
            })
            .when("/grid1", {
                templateUrl: "app/grid1/views/grid1.html",
                controller: "Grid1Ctrl",
                controllerAs: "vm"
            })
            .otherwise("/grid");
    }
    routes.$inject = ["$routeProvider"];
    angular.module("app")
        .config(routes);
}