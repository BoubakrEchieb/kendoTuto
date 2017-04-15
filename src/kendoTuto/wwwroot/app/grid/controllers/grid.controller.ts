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
                        field: "FirstName",
                        title: "First Name",
                        width: "120px"
                    },
                    {
                        field: "LastName",
                        title: "Last Name",
                        width: "120px"
                    },
                    {
                        field: "Country",
                        width: "120px"
                    },
                    {
                        field: "City",
                        width: "120px"
                    },
                    {
                        field: "Title"
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
                        type:"json"
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
            _this.detailGridDataSource = new kendo.data.DataSource({
                transport: {
                    read: {

                    }
                },
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true,
                pageSize: 5,
                filter: { field: "EmployeeId", operator: "eq", value: dataItem.EmployeeId }
            });
            _this.detailGridOptions = {
                dataSource: _this.detailGridDataSource,
                scrollable: false,
                sortable: true,
                pageable: true,
                columns: [
                    { field: "OrderId", title: "ID", width: "56px" },
                    { field: "ShipCountry", title: "Ship Country", width: "110px" },
                    { field: "ShipAddress", title: "Ship Address" },
                    { field: "ShipName", title: "Ship Name", width: "190px" }
                ]
            };
        }
    }
}