$(document).ready(function () {
    var isAdmin = $("#isAdmin").val();
    // Add product form submit handler
    $('#productForm').submit(function (event) {
        event.preventDefault();

        var name = $('#name').val();
        var description = $('#description').val();
        var price = parseFloat($('#price').val());
        var stock = parseInt($('#stock').val());
        if (name.length == 0 || name == undefined) {
            toastr.error("Please Enter Product Name", "Error");
            return;
        }
        if (description.length == 0 || description == undefined) {
            toastr.error("Please Enter Product Description", "Error");
            return;
        }
        if (price == 0 || price == undefined || isNaN(price)) {
            toastr.error("Please Enter Price", "Error");
            return;
        }
        if (stock == 0 || stock == undefined || isNaN(stock)) {
            toastr.error("Please Enter Stock", "Error");
            return;
        }


        if ($('#hdnProdId').val() > 0) {

            // Validate form fields
            if (!this.checkValidity()) {
                event.stopPropagation();
                return;
            }
            var product = {
                Id: $('#hdnProdId').val(),
                Name: name,
                Description: description,
                Price: price,
                Stock: stock
            }

            $.ajax({
                url: '/Goods/EditProduct', // Replace with your API URL
                method: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(product),
                success: function (data) {
                    if (data.isSuccess) {
                        $('#editId').val('');
                        $('#editName').val('');
                        $('#editDescription').val('');
                        $('#editPrice').val('');
                        $('#editStock').val('');
                        $('#editProductModal').modal('hide');
                        toastr.success(data.message, "Success");
                        //fetchData();
                        window.location.href = '/Goods';
                    }
                    else {
                        toastr.error(data.message, "Error");
                    }
                },
                error: function (xhr, res, status) {
                    if (xhr.status == 401) {
                        window.location.href = xhr.responseJSON.redirectUrl;
                        return;
                    }
                }
            });
        } else {
            var product = {
                Name: name,
                Description: description,
                Price: price,
                Stock: stock
            }

            $.ajax({
                url: '/Goods/CreateProduct', // Replace with your API URL
                method: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(product),
                success: function (data) {
                    if (data.isSuccess) {
                        $('#name').val('');
                        $('#description').val('');
                        $('#price').val('');
                        $('#stock').val('');
                        $('#productModal').modal('hide');
                        toastr.success(data.message, "Success");
                        window.location.href = '/Goods';

                    } else {
                        toastr.error(data.message, "Error");
                    }
                },
                error: function (xhr, res, status) {
                    if (xhr.status == 401) {
                        window.location.href = xhr.responseJSON.redirectUrl;
                        return;
                    }
                }
            });
        }

    });

    //// Add product form submit handler
    //$('#productEditForm').submit(function (event) {
    //    event.preventDefault();

    //    // Validate form fields
    //    if (!this.checkValidity()) {
    //        event.stopPropagation();
    //        return;
    //    }

    //    var id = $("#editId").val();
    //    var name = $('#editName').val();
    //    var description = $('#editDescription').val();
    //    var price = parseFloat($('#editPrice').val());
    //    var stock = parseInt($('#editStock').val());

    //    if (name.length == 0 || name == undefined) {
    //        toastr.error("Please Enter Product Name", "Error");
    //        return;
    //    }
    //    if (description.length == 0 || description == undefined) {
    //        toastr.error("Please Enter Product Description", "Error");
    //        return;
    //    }
    //    if (price == 0 || price == undefined || isNaN(price)) {
    //        toastr.error("Please Enter Price", "Error");
    //        return;
    //    }
    //    if (stock == 0 || stock == undefined || isNaN(stock)) {
    //        toastr.error("Please Enter Stock", "Error");
    //        return;
    //    }
    //    var product = {
    //        Id: id,
    //        Name: name,
    //        Description: description,
    //        Price: price,
    //        Stock: stock
    //    }

    //    $.ajax({
    //        url: '/Product/EditProduct', // Replace with your API URL
    //        method: 'POST',
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        data: JSON.stringify(product),
    //        success: function (data) {
    //            if (data.isSuccess) {
    //                $('#editId').val('');
    //                $('#editName').val('');
    //                $('#editDescription').val('');
    //                $('#editPrice').val('');
    //                $('#editStock').val('');
    //                $('#editProductModal').modal('hide');
    //                toastr.success(data.message, "Success");
    //                //fetchData();
    //                window.location.href = '/Product';
    //            }
    //            else {
    //                toastr.error(data.message, "Error");
    //            }
    //        },
    //        error: function (xhr, res, status) {
    //            if (xhr.status == 401) {
    //                window.location.href = xhr.responseJSON.redirectUrl;
    //                return;
    //            }
    //        }
    //    });

    //});


});
