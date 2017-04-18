var App;
(function (App) {
    "use strict";
    var Grid1Controller = (function () {
        function Grid1Controller($service) {
            this.title = "Grid'CRUD";
            this.$service = $service;
            this.initGridDataSource();
            this.initGridOptions();
        }
        // refrech grid
        Grid1Controller.prototype.refrechGrid = function () {
            $("#grid").data("kendoGrid").dataSource.read();
        };
        // initialize gridDataSource
        Grid1Controller.prototype.initGridDataSource = function () {
            var _this = this;
            var dataArray;
            var gridData;
            _this.gridDataSource = new kendo.data.DataSource({
                transport: {
                    read: function (e) {
                        _this.$service.read("api/Employee/GetAll")
                            .then(function (result) {
                            dataArray = result.data;
                            gridData = new kendo.data.ObservableArray([]);
                            gridData.push.apply(gridData, dataArray);
                            e.success(gridData);
                        }, function (error) {
                            alert("Error");
                            e.error();
                        });
                    },
                    create: function (e) {
                        var newItem = e.data;
                        console.log(e.data);
                        var Em = new App.Employee();
                        Em.FirstName = newItem.firstName;
                        Em.LastName = newItem.lastName;
                        Em.City = newItem.city;
                        Em.Country = newItem.country;
                        Em.Title = newItem.title;
                        _this.$service.add("api/Employee/Create", Em)
                            .then(function (result) {
                            if (JSON.parse(angular.toJson(result.data))["success"] === true) {
                                newItem = JSON.parse(angular.toJson(result.data))["employee"];
                                e.data = newItem;
                                e.success(e.data);
                            }
                        }, function (error) {
                            console.log("error");
                            _this.refrechGrid();
                            e.error(e.data);
                        });
                    },
                    destroy: function (e) {
                        var itemToDelete = e.data;
                        var url = "api/Employee/Remove/" + e.data.employeeId;
                        _this.$service.remove(url)
                            .then(function (result) {
                            if (JSON.parse(angular.toJson(result.data))["success"] === true) {
                                e.success(e.data);
                            }
                        }, function (error) {
                            console.log("error");
                            _this.refrechGrid();
                            e.error(e.data);
                        });
                    },
                    update: function (e) {
                        console.log("update");
                        var url = "api/Employee/Update";
                        var Item = e.data;
                        console.log(e.data);
                        var Em = new App.Employee();
                        Em.FirstName = Item.firstName;
                        Em.LastName = Item.lastName;
                        Em.City = Item.city;
                        Em.Country = Item.country;
                        Em.Title = Item.title;
                        _this.$service.update(url, Item)
                            .then(function (result) {
                            if (JSON.parse(angular.toJson(result.data))["success"] === true) {
                                e.success(e.data);
                            }
                        }, function (error) {
                            console.log("error");
                            _this.refrechGrid();
                            e.error(e.data);
                        });
                    },
                    parameterMap: function (data, operation) {
                        if (operation != "read") {
                            console.log("here");
                            console.log(data);
                            return JSON.stringify({ value: data.models });
                        }
                        else {
                            return JSON.stringify(data);
                        }
                    },
                },
                schema: {
                    model: {
                        id: "employeeId",
                        fields: {
                            employeeId: { editable: false, nullable: true, type: "number" },
                            firstName: { editable: true, nullable: true, type: "string" },
                            lastName: { editable: true, nullable: true, type: "string" },
                            country: { editable: true, nullable: true, type: "string" },
                            city: { editable: true, nullable: true, type: "string" },
                            title: { editable: true, nullable: true, type: "string" },
                        }
                    }
                },
                pageSize: 5,
                serverFiltering: true,
                serverSorting: true,
            });
        };
        // initialize gridOptions
        Grid1Controller.prototype.initGridOptions = function () {
            var _this = this;
            _this.gridOptions = {
                toolbar: ["create", "pdf"],
                pdf: {
                    allPages: true,
                    avoidLinks: true,
                    paperSize: "A4",
                    margin: { top: "2cm", left: "1cm", right: "1cm", bottom: "1cm" },
                    landscape: true,
                    repeatHeaders: true,
                    template: $("#page-template").html(),
                    scale: 0.8,
                    date: new Date()
                },
                dataSource: _this.gridDataSource,
                editable: "popup",
                sortable: true,
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5
                },
                resizable: true,
                columns: [
                    { field: "employeeId", title: "ID#", width: "80px" },
                    { field: "firstName", title: "First Name", width: "100px" },
                    { field: "lastName", title: "Last Name", width: "100px" },
                    { field: "country", title: "Country", width: "100px" },
                    { field: "city", title: "City", width: "100px" },
                    { field: "title", title: "Title", width: "100px" },
                    { command: ["edit", "destroy"], title: "&nbsp;", width: "200px" }
                ],
            };
        };
        Grid1Controller.$inject = ["Grid1Service"];
        return Grid1Controller;
    }());
    App.Grid1Controller = Grid1Controller;
    angular.module("app")
        .controller("Grid1Ctrl", Grid1Controller);
})(App || (App = {}));
