$(document).ready(function () {
    serviceAjax.get('/', {}, true, function (res) {
        Common.renderData('.subtable-object-header', '.subtable-object-body', res.Data, "ObjectID");
    });



});