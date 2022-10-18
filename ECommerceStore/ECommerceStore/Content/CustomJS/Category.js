function Save() {
    $('#loader').show();
    var formdata = new FormData();
    formdata = $('form').serialize();
    $.ajax({
        url: '/Category/Save',
        type: 'POST',
        data: formdata,
        success: function (data) {
            if (data.status) {
                BindCategoryList();
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

function BindCategoryList() {
   
    $.ajax({
        url: '/Category/BindCategoryList',
        type: 'POST',
        success: function (data) {
            $(data).each(function (i, item) {
                $('#tblcategorybody').append('<tr><th>' + (i + 1) + '</th><th>' + item.category_name + '</th><th>' + item.isactive + '</th><th><a  onclick="Edit(' + item.id + ')"><label class="badge badge-danger"><i class="mdi mdi-tooltip-edit"></i> Edit</label></a></th></tr>');
            })
            $('#loader').hide();
        },
        error: function () {
            alert("error");
        }
    });
}

//function BindTypeDDl() {
//    $.ajax({
//        url: '/Category/BindTypeDDl',
//        type: 'POST',
//        success: function (data) {
//            $(data).each(function (i, item) {
//                $('#ddltype').append('<option value="' + item.id + '">' + item.category_name + '</option>');
//            })
//        },
//        error: function () {
//            alert("error");
//        }
//    });
//}
function Edit(id) {
    $.ajax({
        url: '/Category/BindCategoryById',
        type: 'POST',
        data: {Id:id},
        success: function (data) {
            $('#DivForm').html(data);
            $('#ddltype').focus();
        },
        error: function () {
            alert("error");
        }
    });
}