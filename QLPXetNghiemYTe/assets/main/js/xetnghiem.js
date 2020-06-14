$(document).ready(function () {
    //serviceAjax.get('/', {}, true, function (res) {
    //    Common.renderData('.subtable-object-header', '.subtable-object-body', res.Data, "ObjectID");
    //});

    $('.saveXN').click(function () {
        debugger
        var xetnghiem = {};
        xetnghiem["TenXN"] = $($('.form-xetnghiem [fieldname="TenXN"]').first()).val();

        xetnghiem["LoaiXNID"] = $($('.form-xetnghiem [fieldname="LoaiXN"]').first()).val();
        xetnghiem["TriSoBTNamMin"] = $($('.form-xetnghiem [fieldname="TriSoNamMin"]').first()).val();
        xetnghiem["TriSoBTNamMax"] = $($('.form-xetnghiem [fieldname="TriSoNamMax"]').first()).val();

        xetnghiem["TriSoBTNuMin"] = $($('.form-xetnghiem [fieldname="TriSoNuMin"]').first()).val();
        xetnghiem["TriSoBTNuMax"] = $($('.form-xetnghiem [fieldname="TriSoNuMax"]').first()).val();
        xetnghiem["DonVi"] = $($('.form-xetnghiem [fieldname="DonVi"]').first()).val();
        xetnghiem["DonGia"] = $($('.form-xetnghiem [fieldname="DonGia"]').first()).val();


        serviceAjax.post('/api/XetNghiems', xetnghiem, true, function (res) {
            alert("Lưu thành công");

        });
    })



});