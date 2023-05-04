//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/BangChamCong/Index',
        success: function (response) {
            $("#id1").val(response.MaCC);
            $("#idnv1").val(response.MaNV);
            $("#ngaythuong1").val(response.SoNgayLVNgayThuong);
            $("#ngayle1").val(response.SoNgayLVNgayLe);
            $("#nghiphep1").val(response.SoNgayLVNgayNghiPhep);
            $("#khongluong1").val(response.SoNgayNghiKhongLuong);
            $("#thucte1").val(response.SoNgayCongThucTe);
            $("#dghq1").val(response.DGHQCN);
        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

//gửi ajax thêm mới
function themBangChamCong() {
    let data = {};
    let formData = $('#add-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/BangChamCong/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            if (response.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/BangChamCong/Index");
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
function capNhatBangChamCong() {
    let data = {};
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/BangChamCong/Update',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);
            if (response.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Administrator/BangChamCong/Index");
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
