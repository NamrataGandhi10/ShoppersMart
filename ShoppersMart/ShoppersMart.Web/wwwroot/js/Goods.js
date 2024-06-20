$(document).ready(function () {
    var isAdmin = $("#isAdmin").val();
    var cart = JSON.parse(localStorage.getItem('cart')) || [];
    $("#cartItemCount").text(cart.length);
    var table = $('#productTable').DataTable({
        "bPaginate": true,
        "bLengthChange": false,
        "bInfo": isAdmin.toString() == "1" ? true : false,
        columns: [
            { data: 'name', className: 'text-center' },
            { data: 'description' },
            {
                data: 'price', className: 'td-number', render: function (data) {
                    return '$' + parseFloat(data).toFixed(2);
                }
            },
            { data: 'stock', className: 'td-number', visible: isAdmin.toString() == "1" ? true : false },
            {
                data: null, className: 'td-actions td-right', sorting: false, render: function (data, type, row) {
                    var button = isAdmin.toString() == "1" ? '<a href="/Goods/AddProduct/' + data.id + '" class="btn btn-success"><img style="height:20px;" src="/assets/img/edit-white.png" /></a> &nbsp; <button type="button" rel="tooltip" class="btn btn-danger delete-product"><img style="height:20px;" src="/assets/img/delete-white.png" /></button>' : '<button class="btn btn-info btn-sm add-to-cart"> <img style="height:20px;" src="/assets/img/shopping-cart-white.png" />	</button>';
                    return button;


                }
            }
        ]
    });

    // Fetch data from API and populate the table
    function fetchData() {
        $.ajax({
            url: 'Goods/GetProducts', // Replace with your API URL
            method: 'GET',
            success: function (data) {
                table.clear().rows.add(data.data).draw();
                updateAddToCartButtons();
            },
            error: function (xhr, res, status) {
                if (xhr.status == 401) {
                    window.location.href = xhr.responseJSON.redirectUrl;
                    return;
                }
            }
        });
    }
    function updateAddToCartButtons() {
        $('.add-to-cart').off('click').on('click', function () {
            var row = $(this).closest('tr');
            var data = table.row(row).data();
            var product = {
                name: data.name,
                description: data.description,
                price: data.price,
                quantity: 1,
                stock: data.stock,
                id: data.id
            };
            if (data.stock > 0) {
                addToCart(product);
            } else {
                toastr.error("Product is out of stock.", "Error");
            }

        });
        $('.edit-product').off('click').on('click', function () {
            var row = $(this).closest('tr');
            var data = table.row(row).data();
            $('#editId').val(data.id);
            $('#editName').val(data.name);
            $('#editDescription').val(data.description);
            $('#editPrice').val(data.price);
            $('#editStock').val(data.stock);
            $('#editProductModal').modal('show');
        });

        $('.delete-product').off('click').on('click', function () {
            var row = $(this).closest('tr');
            var data = table.row(row).data();

            var product = {
                Id: data.id
            }

            $.ajax({
                url: '/Goods/DeleteProduct', // Replace with your API URL
                method: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(product),
                success: function (data) {
                    if (data.isSuccess) {
                        toastr.success(data.message, "Success");
                        fetchData();
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

        });
    }

    function addToCart(product) {
        var cart = JSON.parse(localStorage.getItem('cart')) || [];
        var found = false;

        for (var i = 0; i < cart.length; i++) {
            if (cart[i].id === product.id) {
                cart[i].quantity += 1;
                if (cart[i].quantity > product.stock) {
                    toastr.error("Maximum quantity of " + product.name + " has been added to your cart!", "Error");
                    return "";
                    break;
                }
                found = true;
                break;
            }
        }

        if (!found) {
            cart.push(product);
        }

        localStorage.setItem('cart', JSON.stringify(cart));
        $("#cartItemCount").text(cart.length);
        toastr.success(product.name + " has been added to your cart!", "Success");
    }
    fetchData();
});
