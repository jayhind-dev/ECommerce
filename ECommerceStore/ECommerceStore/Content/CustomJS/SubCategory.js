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
                //$("#saveit").show();
                //$("#delit").hide();
                //$("#updtit").hide();
                $("#cfs").val('');
                $("#DDlCategory").val('');
                BindSubCategoryList();
                Swal.fire(
                    'Success',
                    ' Sub Cataegory Added !',
                    'success'
                   
                )
                location.reload();
                

            }

            else {
                $('#loader').hide();
                Swal.fire(
                    'Server Problem',
                    'Someting Wrong wi',
                    'error'
                   
                )
                $('#recodId').empty();
                $('#cf').empty();
               
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
                  
                    $('#tblsubcategorybody').append('<tr><th>' + (i + 1) + '</th><th>' + item.category_name + '</th><th>' + item.type_category + '</th><th>' + item.isactive + '</th><th><a  onclick="Edit(' + item.id + ')"><label class="badge badge-danger"><i class="mdi mdi-tooltip-edit"></i> Edit</label></a></th></tr>');
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
    $('#recodId').empty();
    $('#cf').empty();
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
function Delete() {
    var id = $("#recodId").val();
    Swal.fire({
        title: 'Do you want to Delete the Sub Category?',
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
                url: "/SubCategory/DelSubCategoryById",
                data: { Id: id },
                success: function (customer) {
                    $('#loader').hide();
                    if (customer != null) {
                        $('#DivForm').html(customer);
                        $("#cfs").val('');
                        $("#DDlCategory").val('');
                        BindSubCategoryList();
                        $('#loader').hide();
                        Swal.fire(
                            'Success',
                            'Cataegory Deleted !',
                            'success'
                        )
                    }
                    else {
                        $('#loader').hide();
                        $("#cfs").val('');
                        $("#DDlCategory").val('');
                        BindSubCategoryList();
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
                'Sub Category Not Deleted',
                'User Reject Delete request ',
                'error'
            )
        }

    })

}