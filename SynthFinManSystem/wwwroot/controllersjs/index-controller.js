angular
    .module("appTest")
    .controller("IndexController", IndexController);

IndexController.$inject = [
    "$rootScope", "$scope", "$window", "$http", "$cookies"
];

function IndexController($rootScope,
    $scope,
    $window,
    $http,
    $cookies) {
    "use strict";

    $scope.init = function() {
        $scope.userApp = $cookies.getObject('userApp');
    };

}