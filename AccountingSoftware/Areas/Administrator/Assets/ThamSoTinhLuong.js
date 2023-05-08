//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/ThamSoTinhLuong/Index',
        success: function (response) {
            $("#id1").val(response.MaThamSo);
            $("#thangnam1").val(response.ThangNam);
            $("#congluong1").val(response.CongLuong);
            $("#giocongngay1").val(response.GioCongNgay);
            $("#hsnt1").val(response.HsNgayThuong);
            $("#hsnl1").val(response.HsNgayLe);
            $("#tlbhxh1").val(response.TLBHXH);
            $("#tlbhyt1").val(response.TLBHYT);
            $("#tlbhtn1").val(response.TLBHTN);
            $("#tlkpcd1").val(response.TLKPCD);
            $("#gtbt1").val(response.GiamTruBanThan);
            $("#gtnpt1").val(response.GiamTruNPT);
        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

//gửi ajax thêm mới
function themThamSoTinhLuong() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/ThamSoTinhLuong/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/ThamSoTinhLuong/Index");
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

//gửi ajax sửa danh mục
function capNhatThamSoTinhLuong() {
    let data = {};
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/ThamSoTinhLuong/Update',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);
            if (response.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/ThamSoTinhLuong/Index");
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

function xoaThamSoTinhLuong() {
    let id = $("#delete-id").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/ThamSoTinhLuong/Delete',
        success: function (response) {
            if (response.status == true) {
                $("#row-" + id).remove();
                $("#delete-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/ThamSoTinhLuong/Index");
                }, 1000)
            }
        },
        error: function (response) {
            alert("Error has occurred..");
            console.log(response);
        }
    });
}