angular
    .module('appTest')
    .service('SearchService', SearchService);

SearchService.$inject = ['AjaxRequestService'];

function SearchService(AjaxRequestService) {

    var findTransactionByUserIsFraud = function () {
        return AjaxRequestService.ajaxRequestAuth("../Search/FindTransactionByUserIsFraud");
    }

    var findTransactionByUserNameDest = function (data) {
        return AjaxRequestService.ajaxRequestAuthData("../Search/FindTransactionByUserNameDest", data);
    }

    var findTransactionByTransactionDate = function (data) {
        return AjaxRequestService.ajaxRequestAuthData("../Search/FindTransactionByTransactionDate", data);
    }

    var updateTransaction = function (data) {
        return AjaxRequestService.ajaxRequestAuthData("../Search/UpdateTransaction", data);
    }

    return {
        findTransactionByUserIsFraud: findTransactionByUserIsFraud,
        findTransactionByUserNameDest: findTransactionByUserNameDest,
        findTransactionByTransactionDate: findTransactionByTransactionDate,
        updateTransaction: updateTransaction

    }
}