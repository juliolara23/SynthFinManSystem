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
            document.querySelector("#messageWarning").innerHTML = "The username cannot be empty";
            new bootstrap.Toast(document.querySelector("#toastWarning")).show();
        } else if ($scope.password == "") {
            document.querySelector("#messageWarning").innerHTML = "The password cannot be empty";
            new bootstrap.Toast(document.querySelector("#toastWarning")).show();
        } else {
            $scope.modalWindow.toggle();
            var data = {
                userName: $scope.username,
                password: $scope.password
            };
            var response = AccountService.verificarInfoAccesoAsync(data);
            response.then(function (response) {
                    $scope.modalWindow.toggle();
                    if (response.code == 500) {
                        document.querySelector("#messageError").innerHTML =
                            "An error occurred while executing the operation";
                        new bootstrap.Toast(document.querySelector("#toastError")).show();
                    } else {
                        if (response.valid) {
                            $cookies.putObject('userApp', response, {
                                path: '/'
                            });
                            $window.location.href = '/';

                        } else {
                            document.querySelector("#messageError").innerHTML =
                                "the username or password supplied is incorrect";
                            new bootstrap.Toast(document.querySelector("#toastError")).show();
                        }
                    }
                    

                },
                function (response) {
                    $scope.modalWindow.toggle();
                    document.querySelector("#messageError").innerHTML =
                        "An error occurred while executing the operation";
                    new bootstrap.Toast(document.querySelector("#toastError")).show();
                });
        }
    };

}