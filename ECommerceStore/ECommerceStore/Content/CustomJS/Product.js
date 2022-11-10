$(document).ready(function () {
  $('#Pro_Category').empty();
    $('#Pro_SubCategory').empty();
    BindProductList();
})
function Save() {
    var imgstring = '';
    $('#loader').show();

    var formdata = new FormData();
   
    //formdata = $('form').serialize();
    //var fileInput1 = document.getElementById('mailimg');
    formdata.append("id", $("#id").val())
    formdata.append("Pro_Type", $("#Pro_Type").val())
    formdata.append("Pro_Category", $("#Pro_Category").val())
    formdata.append("Pro_SubCategory", $("#Pro_SubCategory").val())
    formdata.append("name", $("#name").val())
    formdata.append("description", $("#description").val())
    formdata.append("tax_id", $("#tax_id").val())
    formdata.append("price", $("#price").val())
    formdata.append("sku", $("#sku").val())
    formdata.append("stock", $("#stock").val())
    var fileUpload1 = $("#mailimg").get(0);
    var files1 = fileUpload1.files[0];
    console.log(files1)
    formdata.append("Singleimg", files1);

    
    //var fileInput = document.getElementById('multiimg');
    var fileUpload = $("#multiimg").get(0);
    var files = fileUpload.files;
    //Iterating through each files selected in fileInput
    for (i = 0; i < files.length; i++) {
        //Appending each file to FormData object
        formdata.append("Multiimg", files[i]);
    }
    $.ajax({
        url: '/Product/Save',
        type: 'POST',
        data: formdata,
        contentType: false,
        processData: false,
        success: function (data) {
            if (data.status) {
                BindProductList();
                Swal.fire(
                    'Success',
                    'Product Details Added !',
                    'success'
                )
                InitialView()

                
            }
            else {
                Swal.fire(
                    'Server Error',
                    'Product Details Not Added',
                    'error'
                )
            }
        },
        error: function () {
            Swal.fire(
                'Server Error',
                'Someting Wrong',
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
            $('#tblproductbody').html('');
            $(data).each(function (i, item) {
                var tr = '';
                tr+='<tr>'
                tr += '<th>' + (i + 1) + '</th>';
                tr += '<th>' + item.name + '</th>';
                tr += '<th>' + item.isactive+'</th>';
                tr += '<th>' + item.tax_id + '</th>';
                tr += '<th>' + item.price+'</th>';
                tr += '<th>' + item.description + '</th>';
                tr += '<th>' + item.sku + '</th>';
                tr += '<th>' + item.stock+'</th>';
                tr += '<th><a onclick="Edit(' + item.id + ')"><label class="badge badge-danger"><i class="mdi mdi-tooltip-edit"></i> Edit </label></a></th>';
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


function Edit(id) {
    $.ajax({
        url: '/Product/BindProductById',
        type: 'POST',
        data: {Id:id},
        success: function (data) {
            $('#DivForm').html(data);
            $('#Pro_Type').focus();
        },
        error: function () {
            alert("Error on Edit");
        }
    });
}


function upmainimage() {
    var formdata = new FormData(); //FormData object
    var fileInput = document.getElementById('mailimg');
    //Iterating through each files selected in fileInput
    for (i = 0; i < fileInput.files.length; i++) {
        //Appending each file to FormData object
        formdata.append(fileInput.files[i].name, fileInput.files[i]);
    }
    //Creating an XMLHttpRequest and sending
    var xhr = new XMLHttpRequest();
    xhr.open('POST','/Product/Upload');
    xhr.send(formdata);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            $('#imgsulr').val(xhr.responseText);
        }
    }
    return false;
}
function upmultimage() {
    var formdata = new FormData(); //FormData object
    var fileInput = document.getElementById('multiimg');
    //Iterating through each files selected in fileInput
    for (i = 0; i < fileInput.files.length; i++) {
        //Appending each file to FormData object
        formdata.append(fileInput.files[i].name, fileInput.files[i]);
    }
    //Creating an XMLHttpRequest and sending
    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Product/Upload');
    xhr.send(formdata);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var old=$('#imgsulr').val();
            $('#imgsulr').val(old+xhr.responseText);
        }
    }
    return false;
}

function typechange() {
    $('#loader').show();
    var cnge = $('#Pro_Type').val();
    $.ajax({
        url: '/Product/BindCategriesbytypeid',
        type: 'POST',
        data: { Id: cnge },
        success: function (data) {
            $('#Pro_Category').empty();
            $('#Pro_SubCategory').empty();
            $('#Pro_Category').append('<option value="">select category</option>');
            $(data).each(function (i, item) {
                $('#Pro_Category').append('<option value="' + item.id + '">' + item.category_name + '</option>');
            })

        },
        error: function () {
            alert("error");
        }
    });
    $('#loader').hide();

}
function categoerychange() {
    $('#loader').show();
    var cnge = $('#Pro_Category').val();
    $.ajax({
        url: '/Product/BindSubCategriesbytypeid',
        type: 'POST',
        data: { Id: cnge },
        success: function (data) {
            $('#Pro_SubCategory').empty();
            $('#Pro_SubCategory').append('<option value="">select sub category</option>');
            $(data).each(function (i, item) {
                $('#Pro_SubCategory').append('<option value="' + item.id + '">' + item.category_name + '</option>');
            })

        },
        error: function () {
            alert("error");
        }
    });
    $('#loder').hide();
}

function Delete() {
 var id = $("#id").val();
    Swal.fire({
        title: 'Do you wCategoryhe Produvt Details?',
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
                url: "/Product/DelProductById",
                data: { Id: id },
                success: function (customer) {
                    if (customer != null) {
                        $('#DivForm').html(customer);
                         BindProductList()
                        $('#loader').hide();
                        Swal.fire(
                            'Success',
                            'Product Details Deleted !',
                            'success'
                        )
                    } else {
                        $('#loader').hide();
                        Swal.fire(
                            'Product Not Deleted',
                            'Someting Wrong ',
                            'error'
                        )
                    }
                }
            });
        } else if (result.isDenied) {
            $('#loader').hide();
            Swal.fire(
                'Product Not Deleted',
                'User Rej ect Delete request',
                'error'
            )
        }

    })

}

function InitialView() {
    $.ajax({
        url: '/Product/Initialreturn',
        type: 'POST',
        success: function (data) {
            $('#DivForm').html(data);
        },
        error: function () {
            alert("error fff");
        }
    });
}
