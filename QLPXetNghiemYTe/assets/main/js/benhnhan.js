$(document).ready(function () {
    $.ajax({
        url: 'vidu2.php',
        type: 'POST',
        dataType: 'html',
        data: {
            a: "content abc",
            b: "content bcd"
        }
    }).done(function (ketqua) {
        $('#noidung').html(ketqua);
    });
}
