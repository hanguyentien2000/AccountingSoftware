//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/ThueTNCN/Index',
        success: function (response) {
            $("#id1").val(response.MaThueTNCN);
            $("#manv1").val(response.MaNV);
            $("#bt1").val(response.BacThue);
            $("#t1").val(response.Tu);
            $("#d1").val(response.Den);
        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

//gửi ajax thêm mới
function themThueTNCN() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/ThueTNCN/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/ThueTNCN/Index");
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
function capNhatThueTNCN() {
    let data = {};
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/ThueTNCN/Update',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);
            if (response.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/ThueTNCN/Index");
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

function xoaThueTNCN() {
    let id = $("#delete-id").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/ThueTNCN/Delete',
        success: function (response) {
            if (response.status == true) {
                $("#row-" + id).remove();
                $("#delete-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/ThueTNCN/Index");
                }, 1000)
            }
        },
        error: function (response) {
            alert("Error has occurred..");
            console.log(response);
        }
    });
}