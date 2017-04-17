var App;
(function (App) {
    "use strict";
    var Grid1Service = (function () {
        function Grid1Service($http) {
            this.$http = $http;
        }
        Grid1Service.prototype.read = function (adresse) {
            return this.$http.get(adresse);
        };
        Grid1Service.prototype.update = function (adresse, vm) {
            return this.$http.put(adresse, vm);
        };
        Grid1Service.prototype.remove = function (adresse) {
            return this.$http.delete(adresse);
        };
        Grid1Service.prototype.add = function (adresse, vm) {
            return this.$http.post(adresse, vm);
        };
        Grid1Service.$inject = ["$http"];
        return Grid1Service;
    }());
    angular.module("app")
        .service("Grid1Service", Grid1Service);
})(App || (App = {}));
