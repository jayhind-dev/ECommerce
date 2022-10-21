$(document).ready(function () {
    BindProductList();
})
function Save() {
    var imgstring = '';
    
    $('#loader').show();
    upmainimage();
    upmultimage();
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
                    'Someting Wrong Category Not Added',
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
                tr += '<td>' + item.name + '</td>';
                tr += '<td>' + item.id+'</td>';
                tr += '<td>' + item.tax_id + '</td>';
                tr += '<td>' + item.price+'</td>';
                tr += '<td>' + item.description + '</td>';
                tr += '<td>' + item.sku + '</td>';
                tr += '<td>' + item.stock+'</td>';
                tr += '<th><a onclick="Edit(' + item.id + ')"><label class="badge badge-danger"><i class="mdi mdi-tooltip-edit"></i> Edit</label></a></th>';
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
            $('#Pro_Category').focus();
        },
        error: function () {
            alert("error");
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
    $('#loader').hide();
}
