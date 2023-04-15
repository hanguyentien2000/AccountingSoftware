﻿//load dữ liệu lên form sửa
function loadItem(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/NguoiDung/Index',
        success: function (response) {
            $("#username1").val(response.USERNAME);
            $("#password1").val(response.PASSWORD);
            response.Quantri ? $("#gioitinhb").prop("checked", true) : $("#gioitinhg").prop("checked", true);
            $("#manv1").val(response.MaNhanVien);
        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

//gửi ajax thêm danh mục
function themNguoiDung() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/NguoiDung/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/NguoiDung/Index");
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
function capNhatNguoiDung() {
    let data = {};
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/NguoiDung/Update',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);
            if (response.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/NguoiDung/Index");
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
    $("#delete-username").val(id);
}

function xoaNguoiDung() {
    let id = $("#delete-username").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/NguoiDung/Delete',
        success: function (response) {
            if (response.status == true) {
                $("#row-" + id).remove();
            }
        },
        error: function (response) {
            alert("Error has occurred..");
            console.log(response);
        }
    });
}