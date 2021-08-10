angular
    .module("appTest")
    .controller("RegisterController", RegisterController);

RegisterController.$inject = [
    "$rootScope", "$scope", "$window", "$http", "$cookies","RegisterService"
];

function RegisterController($rootScope,
    $scope,
    $window,
    $http,
    $cookies,
    RegisterService) {
    "use strict";

    $scope.init = function() {
        $scope.resetTransaction();
    };

    $scope.resetTransaction = function() {
        $scope.transaction = {
            id: 0,
            type: "",
            amount: 0,
            nameOrig: "",
            nameDest: "",
            transactionDate: undefined,
            IsFraud: false
        }
    };

    $scope.formIsValid = function() {
        if ($scope.transaction.type == "" ) {
            Swal.fire({
                toast: true,
                icon: "warning",
                title: "The type cannot be empty"
            });
            return false;
        } else if ($scope.transaction.amount < 1) {
            Swal.fire({
                toast: true,
                icon: "warning",
                title: "The amount must be greater than 0"
            });
            return false;
        } else if ($scope.transaction.nameOrig == "") {
            Swal.fire({
                toast: true,
                icon: "warning",
                title: "The customer name cannot be empty"
            });
            return false;
        } else if ($scope.transaction.nameDest == "") {
            Swal.fire({
                toast: true,
                icon: "warning",
                title: "The recipient name cannot be empty"
            });
            return false;
        } else if ($scope.transaction.transactionDate == undefined) {
            Swal.fire({
                toast: true,
                icon: "warning",
                title: "The transaction date cannot be empty"
            });
            return false;
        }
        return true;
    };

    $scope.submit = function() {
        if ($scope.formIsValid()) {
            $scope.swal = Swal.fire({
                icon: "info",
                title: "Processing, please wait",
                didOpen: () => {
                    Swal.showLoading();
                }
            });
            var data = {
                transaction: $scope.transaction
            };
            var response = RegisterService.saveTransaction(data);
            response.then(function(response) {
                    $scope.swal.close();
                    Swal.fire({
                        toast: true,
                        icon: "success",
                        title: "the transaction has been registered correctly"
                    });
                    $scope.resetTransaction();
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
    };

}