$(document).ready(function () {
    $('.inthongtinBN').click(function () {
        debugger
        var benhNhan = {};
        benhNhan["HoTen"] = $('.form-benhnhan [fielname="HotenBN"]').val();

        var ngay = $('.form-benhnhan [fielname="NgaysinhBN"]').val();
        var thang = $('.form-benhnhan [fielname="ThangSinhBN"]').val();
        var nam = $('.form-benhnhan [fielname="NamsinhBN"]').val();
        benhNhan["SN"] = new Date(`${ngay}-${thang}-${nam}`)
        benhNhan["DiaChi"] = $('.form-benhnhan [fielname="DiachiBN"]').val();
        benhNhan["SDT"] = $('.form-benhnhan [fielname="SDTBN"]').val();
        benhNhan["Email"] = $('.form-benhnhan [fielname="EmailBN"]').val();
        benhNhan["CMND"] = $('.form-benhnhan [fielname="CMNDBN"]').val();
        benhNhan["GT"] = $('.form-benhnhan [fielname="GTBN"]').val();


        serviceAjax.post('/api/BenhNhans', benhNhan, true, function (res) {
            alert("Lưu thành công");

        });
    })

});
