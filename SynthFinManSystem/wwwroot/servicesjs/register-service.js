angular
    .module('appTest')
    .service('RegisterService', RegisterService);

RegisterService.$inject = ['AjaxRequestService'];

function RegisterService(AjaxRequestService) {

    var saveTransaction = function (data) {
        return AjaxRequestService.ajaxRequestAuthData("../Register/SaveTransaction", data);
    }

    return {
        saveTransaction: saveTransaction
    }
}