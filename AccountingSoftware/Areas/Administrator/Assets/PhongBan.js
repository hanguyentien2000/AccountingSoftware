//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/PhongBan/Index',
        success: function (response) {
            $("#id1").val(response.MaPhongBan);
            $("#name1").val(response.TenPhongBan);
            $("#phone1").val(response.SDT);
        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

//gửi ajax thêm mới
function themPhongBan() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/PhongBan/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/PhongBan/Index");
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
function capNhatPhongBan() {
    let data = {};
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/PhongBan/Update',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);
            if (response.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/PhongBan/Index");
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

function xoaPhongBan() {
    let id = $("#delete-id").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/PhongBan/Delete',
        success: function (response) {
            if (response.status == true) {
                $("#row-" + id).remove();
                $("#delete-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/PhongBan/Index");
                }, 1000)
            }
        },
        error: function (response) {
            alert("Error has occurred..");
            console.log(response);
        }
    });
}