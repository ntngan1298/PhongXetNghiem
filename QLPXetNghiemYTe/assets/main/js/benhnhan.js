$(document).ready(function () {

    $('.inthongtinBN').click(function () {
        debugger
        var benhNhan = {};
        benhNhan["HoTen"] = $($('.form-benhnhan [fieldname="HotenBN"]').first()).val();

        var ngay = $($('.form-benhnhan [fieldname="NgaysinhBN"]').first()).val();
        var thang =$( $('.form-benhnhan [fieldname="ThangSinhBN"]').first()).val();
        var nam = $($('.form-benhnhan [fieldname="NamsinhBN"]').first()).val();
        benhNhan["SN"] = new Date(`${thang}-${ngay}-${nam}`);
        benhNhan["DiaChi"] = $($('.form-benhnhan [fieldname="DiachiBN"]').first()).val();
        benhNhan["SDT"] = $($('.form-benhnhan [fieldname="SDTBN"]').first()).val();
        benhNhan["Email"] = $($('.form-benhnhan [fieldname="EmailBN"]').first()).val();
        benhNhan["CMND"] = $($('.form-benhnhan [fieldname="CMNDBN"]').first()).val();
        benhNhan["GT"] = $($('.form-benhnhan [fieldname="GTBN"]').first()).val();
     

        serviceAjax.post('/api/BenhNhans', benhNhan, true, function (res) {
            alert("Lưu thành công");

        });
    })

});
