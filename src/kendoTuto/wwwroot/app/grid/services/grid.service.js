var App;
(function (App) {
    "use strict";
    var GridService = (function () {
        function GridService($http) {
            this.$http = $http;
        }
        GridService.prototype.read = function (adresse) {
            return this.$http.get(adresse);
        };
        GridService.prototype.update = function (adresse, vm) {
            return this.$http.put(adresse, vm);
        };
        GridService.prototype.remove = function (adresse) {
            return this.$http.delete(adresse);
        };
        GridService.prototype.add = function (adresse, vm) {
            return this.$http.post(adresse, vm);
        };
        GridService.$inject = ["$http"];
        return GridService;
    }());
    angular.module("app")
        .service("GridService", GridService);
})(App || (App = {}));
