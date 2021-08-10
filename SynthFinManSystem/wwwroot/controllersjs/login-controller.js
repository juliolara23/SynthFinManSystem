angular
    .module("appTest")
    .controller("LoginController", LoginController);

LoginController.$inject = [
    "$rootScope", "$scope", "$window", "$http", "$cookies", "AccountService"
];

function LoginController($rootScope,
    $scope,
    $window,
    $http,
    $cookies,
    AccountService) {
    "use strict";


    $scope.init = function() {
        $scope.username = "";
        $scope.password = "";
        $scope.modalWindow = new bootstrap.Modal(document.querySelector("#modalWindow"));
    };

    $scope.sendLogin = function() {
        if ($scope.username == "") {
            Swal.fire({
                toast: true,
                icon: "warning",
                title: "The username cannot be empty"
            });
        } else if ($scope.password == "") {
            Swal.fire({
                toast: true,
                icon: "warning",
                title: "The password cannot be empty"
            });
        } else {
            $scope.swal = Swal.fire({
                icon: "info",
                title: "Processing, please wait",
                didOpen: () => {
                    Swal.showLoading();
                }
            });
            var data = {
                userName: $scope.username,
                password: $scope.password
            };
            var response = AccountService.verificarInfoAccesoAsync(data);
            response.then(function (response) {
                    $scope.swal.close();
                    if (response.valid) {
                            $cookies.putObject('userApp', response, {
                                path: '/'
                            });
                            $window.location.href = '/';

                        } else {
                            Swal.fire({
                                toast: true,
                                icon: "error",
                                title: "the username or password supplied is incorrect"
                            });
                        }
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