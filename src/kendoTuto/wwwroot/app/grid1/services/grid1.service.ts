module App {
    "use strict";
    export interface IGrid1Service {
        read(adresse: string): ng.IHttpPromise<{}>;
        update(adresse: string, vm: any): ng.IHttpPromise<{}>;
        remove(adresse: string): ng.IHttpPromise<{}>;
        add(adresse: string, vm: any): ng.IHttpPromise<{}>;
    }
    class Grid1Service implements IGrid1Service {
        $http: ng.IHttpService;
        static $inject = ["$http"];

        constructor($http: ng.IHttpService) {
            this.$http = $http;
        }
        read(adresse: string): ng.IHttpPromise<{}> {
            return this.$http.get(adresse);
        }
        update(adresse: string, vm: any): ng.IHttpPromise<{}> {
            return this.$http.put(adresse, vm);
        }
        remove(adresse: string): ng.IHttpPromise<{}> {
            return this.$http.delete(adresse);
        }
        add(adresse: string, vm: any): ng.IHttpPromise<{}> {
            return this.$http.post(adresse, vm);
        }
    }
    angular.module("app")
        .service("Grid1Service", Grid1Service);
}