module App {
    "use strict";
    export class GridCtrl {
        // properties
        mainGridOptions: kendo.ui.GridOptions;
        mainGridDataSource: kendo.data.DataSource;
        mainDataTable: any[];
        mainObservableData: kendo.data.ObservableArray;

        detailGridOptions: kendo.ui.GridOptions;
        detailGridDataSource: kendo.data.DataSource;
        detailDataTable: any[];
        detailObservableData: kendo.data.ObservableArray;

        $service: IGridService;
        static $inject = ["GridService"];
        constructor($service: IGridService) {
            this.$service = $service;
            this.detailObservableData = new kendo.data.ObservableArray([]);
            this.mainObservableData = new kendo.data.ObservableArray([]);
            this.initMainGridDataSource();
            this.initMainGridOptions();
        }
        // initialize mainGridOptions
        private initMainGridOptions() {
            let _this = this;
            _this.mainGridOptions = {
                dataSource: _this.mainGridDataSource,
                sortable: true,
                pageable: true,
                dataBound: function () {
                    this.expandRow(this.tbody.find("tr.k-master-row").first());
                },
                columns: [
                    {
                        field: "employeeId",
                        title: "#ID",
                        width: "120px"
                    },
                    {
                        field: "firstName",
                        title: "First Name",
                        width: "120px"
                    },
                    {
                        field: "lastName",
                        title: "Last Name",
                        width: "120px"
                    },
                    {
                        field: "country",
                        width: "120px"
                    },
                    {
                        field: "city",
                        width: "120px"
                    },
                    {
                        field: "title"
                    }
                ]
            }
        }
        // initialize mainGridDataSource
        private initMainGridDataSource() {
            let _this = this;
            _this.mainGridDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "api/Employee/GetAll",
                        type: "GET",
                        dataType:"json"
                    },
                    create: {},
                    update: {},
                    destroy: {}
                },
                pageSize: 5,
                serverPaging: true,
                serverSorting: true
            });
        }
        public initDetailGridOptions(dataItem: Employee) {
            let _this = this;
            let employeeId = dataItem.employeeId + "";
            console.log(employeeId);
            _this.detailGridDataSource = new kendo.data.DataSource({
                transport: {
                    read: function (e) {
                        let url = "api/Order/GetAll/" + employeeId;
                        console.log(url);
                        _this.$service.read(url)
                            .then((result: any) => {
                                _this.detailDataTable = result.data;
                                _this.detailObservableData.push.apply(_this.detailObservableData, _this.detailDataTable);
                                e.success(_this.detailObservableData);
                            }, (error: any): any => {
                                alert("Error");
                            });
                    }
                },
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true,
                pageSize: 5,
                filter: { field: "employee.employeeId", operator: "eq", value: dataItem.employeeId }
            });
            _this.detailGridOptions = {
                dataSource: _this.detailGridDataSource,
                scrollable: false,
                sortable: true,
                pageable: true,
                columns: [
                    { field: "orderId", title: "ID", width: "56px" },
                    { field: "shipCountry", title: "Ship Country", width: "110px" },
                    { field: "shipAddress", title: "Ship Address" },
                    { field: "shipName", title: "Ship Name", width: "190px" },
                    { field: "employee.employeeId", title: "EmployeeID", width: "190px" }
                ]
            };
            return _this.detailGridOptions;
        }
    }
    angular.module("app")
        .controller("GridCtrl", GridCtrl);
}