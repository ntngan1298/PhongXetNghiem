$(document).ready(function () {
    serviceAjax.get('/GetXetNghiemByType/2', null, true, function (res) {
        res.forEach(function (item) {
            var html = `<input type="checkbox" data="${item.ID}"><label class="type - of - test">${item.TenXn}</label>
                <br />`

            $('#ck-Hoasinh').append(html);
        });
     

    });
    serviceAjax.get('/GetXetNghiemByType/1', null, true, function (res) {
        res.forEach(function (item) {
            var html = `<input type="checkbox" data="${item.ID}"><label class="type-of-test">${item.TenXn}</label>
                <br />`

            $('#ck-huyethoc').append(html);
        });


    });

    serviceAjax.get('/GetXetNghiemByType/3', null, true, function (res) {
        res.forEach(function (item) {
            var html = `<input type="checkbox" data="${item.ID}"><label class="type-of-test">${item.TenXn}</label>
                <br />`

            $('#ck-visinh').append(html);
        });


    });

    $('.ck-allHS').change(function () {
        if ($('.ck-allHS').is(':checked')) {
            $('#ck-Hoasinh input').prop("checked", true);
        }
        else {
            $('#ck-Hoasinh input').prop("checked", false);
        }
    });
    $('.ck-allHH').change(function () {
        if ($('.ck-allHH').is(':checked')) {
            $('#ck-huyethoc input').prop("checked", true);
        }
        else {
            $('#ck-huyethoc input').prop("checked", false);
        }
    });

    $('.ck-allVS').change(function () {
        if ($('.ck-allHH').is(':checked')) {
            $('#ck-visinh input').prop("checked", true);
        }
        else {
            $('#ck-visinh input').prop("checked", false);
        }
    });
    $('.btn-Xn').click(function () {
        var obj = {};
        var lstXN = [];

        $('input[data]').each(function (index, item) {
            if ($(item).is(":checked")) {
                lstXN.push($(item).attr('data'));
            }
        });
        const urlParams = new URLSearchParams(window.location.search);
        const myParam = urlParams.get('id');
        obj['HoSoBNID'] = myParam;
        obj['lstXN'] = lstXN;
        serviceAjax.post('api/XetNghiems', obj, true, function (res) {
            window.location.href = location.origin + 'View/BenhNhan/HoaDon.html' + `?id=${res.ID}`

        });
      
    })
});