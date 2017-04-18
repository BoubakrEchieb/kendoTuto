module App {
    "use strict";
    export class Grid1Controller {
        title: string;
        gridDataSource: kendo.data.DataSource;
        gridOptions: kendo.ui.GridOptions;
        $service: IGrid1Service;

        static $inject = ["Grid1Service"];
        constructor($service: IGrid1Service) {
            this.title = "Grid'CRUD";
            this.$service = $service;
            this.initGridDataSource();
            this.initGridOptions();
        }
        // refrech grid
        refrechGrid() {
            $("#grid").data("kendoGrid").dataSource.read();
        }
        // initialize gridDataSource
        initGridDataSource () {
            let _this = this;
            let dataArray: any[];
            let gridData: kendo.data.ObservableArray;
            _this.gridDataSource = new kendo.data.DataSource({
                transport: {
                    read: function (e) {
                        _this.$service.read("api/Employee/GetAll")
                            .then((result: any) => {
                                dataArray = result.data;
                                gridData = new kendo.data.ObservableArray([]);
                                gridData.push.apply(gridData, dataArray);
                                e.success(gridData);
                            }, (error: any): any => {
                                alert("Error");
                                e.error();
                            });
                    },
                    create: function (e) {
                        let newItem = e.data;
                        console.log(e.data);
                        let Em = new Employee();
                        Em.FirstName = newItem.firstName;
                        Em.LastName = newItem.lastName;
                        Em.City = newItem.city;
                        Em.Country = newItem.country;
                        Em.Title = newItem.title;
                        _this.$service.add("api/Employee/Create", Em)
                            .then((result: any) => {
                                if (JSON.parse(angular.toJson(result.data))["success"] === true) {
                                    newItem = JSON.parse(angular.toJson(result.data))["employee"];
                                    e.data = newItem;
                                    e.success(e.data);
                                }
                            }, (error: any) => {
                                console.log("error");
                                _this.refrechGrid();
                                e.error(e.data);
                            });
                    },
                    destroy: function (e) {
                        let itemToDelete = e.data;
                        let url = "api/Employee/Remove/" + e.data.employeeId;
                        _this.$service.remove(url)
                            .then((result: any) => {
                                if (JSON.parse(angular.toJson(result.data))["success"] === true) {
                                    e.success(e.data);
                                }
                            }, (error: any) => {
                                console.log("error");
                                _this.refrechGrid();
                                e.error(e.data);
                            });
                    },
                    update: function (e) {
                        console.log("update");
                        let url = "api/Employee/Update"
                        let Item = e.data;
                        console.log(e.data);
                        let Em = new Employee();
                        Em.FirstName = Item.firstName;
                        Em.LastName = Item.lastName;
                        Em.City = Item.city;
                        Em.Country = Item.country;
                        Em.Title = Item.title;
                        _this.$service.update(url, Item)
                            .then((result: any) => {
                                if (JSON.parse(angular.toJson(result.data))["success"] === true) {
                                    e.success(e.data);
                                }
                            }, (error: any) => {
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
        }
        // initialize gridOptions
        initGridOptions() {
            let _this = this;
            _this.gridOptions = {
                toolbar: ["create","pdf"],
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
        }
    }
    angular.module("app")
        .controller("Grid1Ctrl", Grid1Controller);
}