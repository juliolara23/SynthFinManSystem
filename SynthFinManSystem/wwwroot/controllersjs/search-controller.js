angular
    .module("appTest")
    .controller("SearchController", SearchController);

SearchController.$inject = [
    "$rootScope", "$scope", "$window", "$http", "$cookies", "SearchService"
];

function SearchController($rootScope,
    $scope,
    $window,
    $http,
    $cookies,
    SearchService) {
    "use strict";

    $scope.init = function() {
        $scope.searchBy = "f";
        $scope.nameDest = "";
        $scope.listTransactions = [];
        $scope.transactionDate = undefined;
    }

    $scope.isNameDest = function() {
        if ($scope.searchBy == "r") {
            return true;
        } else {
            return false;
        }
    };

    $scope.isTransactDate = function () {
        if ($scope.searchBy == "d") {
            return true;
        } else {
            return false;
        }
    };

    $scope.gridTransactions = {
        enableSorting: true,
        enableFiltering: true,
        paginationPageSizes: [15, 20, 25],
        paginationPageSize: 15,
        enableRowSelection: false,
        selectionRowHeaderWidth: 35,
        columnDefs: [
            {
                name: 'type',
                field: 'type',
                displayName: 'Type',
                enableHiding: false,
                headerCellClass: 'text-center'
            },
            {
                name: 'amount',
                field: 'amount',
                displayName: 'Amount',
                type: 'number',
                enableHiding: false,
                cellClass: 'text-right',
                headerCellClass: 'text-center'
            },
            {
                name: 'nameOrig',
                field: 'nameOrig',
                displayName: 'Customer Name',
                enableHiding: false,
                cellClass: 'text-left',
                headerCellClass: 'text-center'
            },
            {
                name: 'nameDest',
                field: 'nameDest',
                displayName: 'Recipient Name',
                enableHiding: false,
                cellClass: 'text-left',
                headerCellClass: 'text-center'
            },
            {
                name: 'transactionDate',
                field: 'transactionDate',
                displayName: 'Transaction Date',
                type: 'date',
                cellFilter: 'date:\'yyyy-MM-dd\'',
                enableHiding: false,
                headerCellClass: 'text-center'
            },
            {
                name: 'isFraud',
                field: 'isFraud',
                displayName: 'Is fraud',
                enableHiding: false,
                headerCellClass: 'text-center'
            },
            {
                name: 'tool',
                field: '',
                displayName: '',
                width: 45,
                enableHiding: false,
                enableFiltering: false,
                enableSorting: false,
                cellTemplate:
                    "<span><a href='' ng-click='grid.appScope.markFraud(row.entity)' ng-show='grid.appScope.showMark(row.entity)'  uib-tooltip='Mark Fraud' tooltip-trigger='mouseenter' tooltip-placement='top'>" +
                        "<i class='fas fa-check-square'></i></a></span>" +
                        "</div>",
                cellClass: 'text-center'
            }
        ]
    };

    $scope.gridTransactions.onRegisterApi = function (gridApi) {
        $scope.gridApiTransactions = gridApi;
    };

    $scope.showMark = function (entity) {
        var user = $cookies.getObject('userApp');
        if (user.idRole == "M" || user.idRole == "D") {
            if (entity.isFraud) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }

    $scope.gridTransactions.data = 'listTransactions';
    $scope.gridTransactions.fastWatch = true;

    $scope.search = function () {
        var data = {};
        var response = undefined;
        $scope.swal = Swal.fire({
            icon: "info",
            title: "Processing, please wait",
            didOpen: () => {
                Swal.showLoading();
            }
        });
        switch ($scope.searchBy) {
            case "f":
                response = SearchService.findTransactionByUserIsFraud();
                response.then(function (response) {
                        $scope.swal.close();
                        $scope.listTransactions = response;
                    },
                    function (response) {
                        $scope.swal.close();
                        Swal.fire({
                            toast: true,
                            icon: "error",
                            title: "An error occurred while executing the operation"
                        });
                    });
                break;
            case "r":
                data = {
                        nameDest: $scope.nameDest
                    };
                    response = SearchService.findTransactionByUserNameDest(data);
                    response.then(function (response) {
                            $scope.swal.close();
                            $scope.listTransactions = response;
                        },
                        function (response) {
                            $scope.swal.close();
                            Swal.fire({
                                toast: true,
                                icon: "error",
                                title: "An error occurred while executing the operation"
                            });
                        });
                break;
            case "d":
                if ($scope.transactionDate == undefined) {
                    Swal.fire({
                        toast: true,
                        icon: "warning",
                        title: "The transaction date cannot be empty"
                    });
                } else {
                    data = {
                        transactionDate: $scope.transactionDate
                    };
                    response = SearchService.findTransactionByTransactionDate(data);
                    response.then(function (response) {
                            $scope.swal.close();
                            $scope.listTransactions = response;
                        },
                        function (response) {
                            $scope.swal.close();
                            Swal.fire({
                                toast: true,
                                icon: "error",
                                title: "An error occurred while executing the operation"
                            });
                        });
                }
                break;
        }
    }

    $scope.markFraud = function(entity)
    {
        entity.isFraud = true;
        Swal.fire({
            title: 'Are you sure, you are going to mark this transaction as fraud?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes'
        }).then((result) => {
            if (result.isConfirmed) {
                $scope.swal = Swal.fire({
                    icon: "info",
                    title: "Processing, please wait",
                    didOpen: () => {
                        Swal.showLoading();
                    }
                });
                var data = {
                    transaction: entity
                };
                var response = SearchService.updateTransaction(data);
                response.then(function (response) {
                        $scope.swal.close();
                        $scope.search();
                    },
                    function (response) {
                        $scope.swal.close();
                        Swal.fire({
                            toast: true,
                            icon: "error",
                            title: "An error occurred while executing the operation"
                        });
                    });
            }
        });
    }

}