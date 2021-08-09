angular
    .module('appTest')
    .service('AccountService', AccountService);

AccountService.$inject = ['AjaxRequestService'];

function AccountService(AjaxRequestService) {

    var verificarInfoAccesoAsync = function (data) {
        return AjaxRequestService.ajaxRequestAuthData("VerificarInfoAcceso", data);
    }

    return {
        verificarInfoAccesoAsync: verificarInfoAccesoAsync
    }
}