/**=========================================================
 * Module: commun.service.ajaxrequest.js
 * Services for redirection to login page
 =========================================================*/

(function () {
    'use strict';

    angular
        .module('appTest')
        .service('AjaxRequestService', AjaxRequestService);

    AjaxRequestService.$inject = ['$http', '$q'];

    function AjaxRequestService($http, $q) {

        function ajaxRequestAuthData(url, data) {
            var deferred = $q.defer();
            $http.post(url, data)
                .then(function (response) { deferred.resolve(response.data); },
                    function (response) {
                        if (response.status == 401) {
                            location.href = "/Account/Login/Index";
                        } else {
                            deferred.reject(response.data);
                        }
                    });
            return deferred.promise;
        }

        function ajaxRequestAuth(url) {
            var deferred = $q.defer();
            $http.post(url)
                .then(function (response) { deferred.resolve(response.data); },
                    function (response) {
                        if (response.status == 401) {
                            location.href = "/Account/Login/Index";
                        } else {
                            deferred.reject(response.data);
                        }
                    });
            return deferred.promise;
        }

        return {
            ajaxRequestAuth: ajaxRequestAuth,
            ajaxRequestAuthData: ajaxRequestAuthData
        }
    }
})();