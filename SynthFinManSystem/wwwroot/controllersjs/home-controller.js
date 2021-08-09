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
        console.log($cookies.getAll());
        var user = $cookies.getObject('userApp');
        console.log(user);
        if (user.role == "A" || user.role == "D") {
            return true;
        } else {
            return false;
        }
    };


}