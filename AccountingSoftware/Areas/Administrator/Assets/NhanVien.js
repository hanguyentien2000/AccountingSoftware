//load dữ liệu
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/NhanVien/Index',
        success: function (response) {
            var a = "";
            a = response.NgayVaoLam;
            a = a.match(/\d+/g).join("");
            var date = new Date(parseInt(a));
            var b = "";

            b = response.NgaySinh;
            b = b.match(/\d+/g).join("");
            var date = new Date(parseInt(a));
            var date2 = new Date(parseInt(b));
            const hours = date.getHours().toString().padStart(2, '0'); // get hours and pad with leading zero if necessary
            const minutes = date.getMinutes().toString().padStart(2, '0'); /
            const day = date.getDate().toString().padStart(2, '0'); // get day and pad with 0 if necessary
            const month = (date.getMonth() + 1).toString().padStart(2, '0'); // get month and pad with 0 if necessary
            const year = date.getFullYear().toString(); // get year
            const dateString = `${day}/${month}/${year}`; // concatenate day, month, and year with '/' separator
            console.log(dateString); // o

            const day2 = date2.getDate().toString().padStart(2, '0'); // get day and pad with 0 if necessary
            const month2 = (date2.getMonth() + 1).toString().padStart(2, '0'); // get month and pad with 0 if necessary
            const year2 = date2.getFullYear().toString(); // get year
            const dateString2 = `${day2}/${month2}/${year2}`; // concatenate day, month, and year with '/' separator
            console.log(dateString2); // o

            $("#manv1").val(response.MaNhanVien);
            $("#macv1").val(response.MaChucVu);
            $("#mapb1").val(response.MaPhongBan);
            $("#tennv1").val(response.HoTen);
            $("#diaChi1").val(response.DiaChi);
            $("#queQuan1").val(response.QueQuan);
            $("#trinhDo1").val(response.TrinhDo);
            $("#hsl1").val(response.HeSoLuong);
            $("#mst1").val(response.MaSoThue);
            $("#snpt1").val(response.SoNguoiPhuThuoc);
            response.GioiTinh ? $("#gioiTinhb").prop("checked", true) : $("#gioiTinhg").prop("checked", true);
            $("#ngaySinh1").val(dateString2);
            //$("#ngayVaoLam1").val(new Date(response.NgayVaoLam));
            $('#ngayVaoLam1').val(dateString);
            console.log($('#ngayVaoLam1'));
        },
        error: function (response) {
            //debugger;  
            console.log(response.responseText);
            console.log(id);
            alert("Error has occurred..");
        }
    });
}

//Thêm mới nhân viên
function themNhanVien() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/NhanVien/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/NhanVien/Index");
                }, 1000)
            } else {
                $("#add-message").addClass("text-danger");
            }
            $("#add-message").html(response.message);
        },
        error: function (response) {
            console.log(response);
        }
    });
    return false;
}


//Cập nhật nhân viên
function capNhatNhanVien() {
    let data = {};
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/NhanVien/Update',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);
            if (response.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/NhanVien/Index");
                }, 1000)
            } else {
                $("#update-message").addClass("text-danger");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
    return false;
}

//load data lên form xóa
function deleteItem(id) {
    $("#delete-id").val(id);
}

function xoaNhanVien() {
    let id = $("#delete-id").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/NhanVien/Delete',
        success: function (response) {
            if (response.status == true) {
                $("#row-" + id).remove();
                $("#delete-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/NhanVien/Index");
                }, 1000)
            }
        },
        error: function (response) {
            alert("Error has occurred..");
            console.log(response);
        }
    });
}