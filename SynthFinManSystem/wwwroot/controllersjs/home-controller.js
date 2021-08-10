angular
    .module("appTest")
    .controller("HomeController", HomeController);

HomeController.$inject = [
    "$rootScope", "$scope", "$window", "$http", "$cookies"
];

function HomeController($rootScope,
    $scope,
    $window,
    $http,
    $cookies) {
    "use strict";

    $scope.validateReg = function () {
        var user = $cookies.getObject('userApp');
        if (user.idRole == "A" || user.idRole == "D") {
            return true;
        } else {
            return false;
        }
    };

    $scope.validateSearch = function () {
        var user = $cookies.getObject('userApp');
        if (user.idRole == "A" || user.idRole == "D") {
            return true;
        } else {
            return false;
        }
    };

    $scope.validateMark = function () {
        var user = $cookies.getObject('userApp');
        if (user.idRole == "M" || user.idRole == "D") {
            return true;
        } else {
            return false;
        }
    };


}