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
                $("#ddltype").val('');
                $("#cf").val('');
              /*  $('#DivForm').html('');*/
                BindCategoryList();
                $('#loader').hide();
                Swal.fire(
                    'Success',
                    'Cataegory Added !',
                    'success'
                )
                location.reload();

            }
            else {
                $('#loader').hide();
                Swal.fire(
                    'Server Error',
                    'Someting Wrong wi',
                    'error'
                )
            }
        },
        error: function () {
            $('#loader').hide();
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
            $('#tblcategorybody').html('');
            $(data).each(function (i, item) {
                $('#tblcategorybody').append('<tr><th>' + (i + 1) + '</th><th>' + item.category_name + '</th><th>' + item._Type + '</th><th>' + item.isactive + '</th><th><a  onclick="Edit(' + item.id + ')"><label class="badge badge-danger"><i class="mdi mdi-tooltip-edit"></i> Edit</label></a></th></tr>');
            })
            $('#loader').hide();
        },
        error: function () {
            alert("error");
        }
    });
}

function Edit(id) {
    $.ajax({
        url: '/Category/BindCategoryById',
        type: 'POST',
        data: { Id: id },
        success: function (data) {
            $('#DivForm').html(data);
         /*   $('#ddltype').focus();*/
        },
        error: function () {
            alert("error");
        }
    });
}

function Delete() {
    var id = $("#recodId").val();
    Swal.fire({
        title: 'Do you want to Delete the Category?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Yes',
        denyButtonText: `No`,
    }).then((result) => {
        $('#loader').show();
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Category/DelCategoryById",
                data: { Id: id },
                success: function (customer) {
                    if (customer != null) {
                        $('#DivForm').html(customer);
                        BindCategoryList();
                        $('#loader').hide();
                        Swal.fire(
                            'Success',
                            'Cataegory Deleted !',
                            'success'
                        )
                    } else {
                        $('#loader').hide();
                        Swal.fire(
                            'Category Not Deleted',
                            'Someting Wrong ',
                            'error'
                        )
                    }
                }
            });
        } else if (result.isDenied) {
            $('#loader').hide();
            Swal.fire(
                'Category Not Deleted',
                'User Reject Delete request ',
                'error'
            )
        }

    })

}