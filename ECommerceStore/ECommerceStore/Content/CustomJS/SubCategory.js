function Save() {
    $('#loader').show();
    var formdata = new FormData();
    formdata = $('form').serialize();
    $.ajax({
        url: '/SubCategory/Save',
        type: 'POST',
        data: formdata,
        success: function (data) {
            if (data.status) {
                BindSubCategoryList();
                Swal.fire(
                    'Success',
                    'Cataegory Added !',
                    'success'
                )

            }
            else {
                Swal.fire(
                    'Server Error',
                    'Someting Wrong wi',
                    'error'
                )
            }
        },
        error: function () {
            Swal.fire(
                'Server Error',
                'Someting Wrong wi',
                'error'
            )
        }
    });
}

function BindSubCategoryList() {
    $.ajax({
        url: '/SubCategory/BindSubCategoryList',
        type: 'POST',
        success: function (data) {
            $('#tblsubcategorybody').html('');
            if (data.length > 0) {
                $(data).each(function (i, item) {
                    $('#tblsubcategorybody').append('<tr><th>' + (i + 1) + '</th><th>' + item.subcategory_name + '</th><th>' + item.isactive + '</th><th><a  onclick="Edit(' + item.id + ')"><label class="badge badge-danger"><i class="mdi mdi-tooltip-edit"></i> Edit</label></a></th></tr>');
                })
            }
            else {
                alert('no data found!');
            }
            $('#loader').hide();
        },
        error: function () {
            alert("error");
        }
    });
}

function Edit(id) {
    $.ajax({
        url: '/SubCategory/BindSubCategoryById',
        type: 'POST',
        data: { Id: id },
        success: function (data) {
            $('#DivForm').html(data);
            $('#DDlCategory').focus();
        },
        error: function () {
            alert("error");
        }
    });
}