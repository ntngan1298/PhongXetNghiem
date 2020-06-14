var serviceAjax = {
    get: function (uri, param, async, callback) {
        $.ajax({
            method: 'GET',
            url: uri,
            dataType: 'json',
            async: async === undefined ? false : async,
            data: param,
            success: function (response) {
                callback(response);
                $('.loading').css('display', 'none');
            },
            error: function (result) {
            }
        });
    },
    post: function (uri, param, async, callback) {
        $.ajax({
            url: uri,
            method: 'POST',
            async: async === undefined ? false : async,
            data: JSON.stringify(param),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                callback(response);
                $('.loading').css('display', 'none');
            },
            error: function () {
                
            }
        });
    },
    put: function (uri, param, async, callback) {
        $.ajax({
            url: uri,
            method: 'PUT',
            data: JSON.stringify(param),
            contentType: "application/json;charset=utf-8",
            dataType: "html",
            async: async === undefined ? false : async,
            success: function (response) {
                callback(response);
                $('.loading').css('display', 'none');
            },
            error: function () {

            }
        });
    },
    delete: function (uri, param, async, callback) {
        $.ajax({
            url: uri,
            method: 'DELETE',
            data: JSON.stringify(param),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: async === undefined ? false : async,
            success: function (response) {
                callback(response);
                $('.loading').css('display', 'none');
            },
            error: function () {

            }
        });
    }
};