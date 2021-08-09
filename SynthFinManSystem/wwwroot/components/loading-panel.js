/**=========================================================
 * Module: commun.service.loading-panel.js
 * Services for loading box
 =========================================================*/

(function () {
    'use strict';

    angular
        .module('appTest')
        .service('LoadingPanel', LoadingPanel);

    LoadingPanel.$inject = ['SweetAlert'];

    function LoadingPanel(SweetAlert) {

        function show(message) {
            SweetAlert.swal({
                title: "",
                text: "" +
                    "<div>&nbsp;</div>" +
                    "<label>" + message + "</label>" +
                    "<div>&nbsp;</div>" +
                    "<div class='whirl traditional'>" +
                    "</div>" +
                    "<div>&nbsp;</div>" +
                    "<div>&nbsp;</div>",
                showConfirmButton: false,
                html: true
            });
        }

        function hide() {
            swal.close();
        }

        return {
            show: show,
            hide: hide
        }
    }
})();