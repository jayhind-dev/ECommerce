function Save() {
    $('#loader').show();
    var formdata = new FormData();
    formdata = $('form').serialize();
    $.ajax({
        url: '/Product/Save',
        type: 'POST',
        data: formdata,
        success: function (data) {
            if (data.status) {
                BindProductList();
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

function BindProductList() {
   
    $.ajax({
        url: '/Product/BindProductList',
        type: 'POST',
        success: function (data) {
            $(data).each(function (i, item) {
                var tr = '';
                tr+='<tr>'
                tr += '<td>' + (i + 1) + '</td>';
                tr += '<td>Product type</td>';
                tr += '<td>Product Category</td>';
                tr += '<td>Product Sub Category</td>';
                tr += '<td>' + item.name + '</td>';
                tr += '<td>' + item.id+'</td>';
                tr += '<td>' + item.tax_id + '</td>';
                tr += '<td>' + item.price+'</td>';
                tr += '<td>' + item.description + '</td>';
                tr += '<td>' + item.sku + '</td>';
                tr += '<td>' + item.stock+'</td>';
                tr += '</tr>';
                $('#tblproductbody').append(tr);
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
        url: '/Product/BindProductById',
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