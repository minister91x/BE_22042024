AddItemToCart = function (e) {

    // Bước 1: // lấy giỏ ra để bắt đầu đi nhặt hàng
    var store = GetCookie('MyShoppingCart');


    // đi nhặt hàng
    var product_item = {
        ProductID: $(e).data('productid'),
        ProductName: $(e).data('productname'),
        Quantity: 1,
        Price: $(e).data('price'),
        Image: $(e).data('image')
    };



    AddAndUpdateShoppingCart(store, product_item);
    alert("Thêm vào giỏ thành công!")
}

AddAndUpdateShoppingCart = function (store, item) {


    // tìm trong giỏ xem có sản phẩm nào giống item truyền vào 
    var index = store.findIndex(function (d) {
        return d.ProductID == item.ProductID;
    });

    // không có 
    if (store.length == 0 || index == -1) {
        // dưa vào giỏ
        store.push(item);
        // set lại cookie 
        SetCookie('MyShoppingCart', store);
        return store;
    }

    // có tồn tại sản phẩm rồi thì tăng số lương lên 1 

    store[index].Quantity = parseInt(store[index].Quantity) + 1;
    SetCookie('MyShoppingCart', store);
    return store;
}

RemoveItemFromCart = function (e) {
    var rs = confirm("Bạn có chắc chắn muốn xóa sản phẩm này trong giỏ ??");
    if (rs) {
        // lấy giỏ ra để bắt đầu đi nhặt hàng
        var store = GetCookie('MyShoppingCart');

        var item = {
            ProductID: $(e).data('productid'),
            ProductName: $(e).data('productname'),
            Quantity: 1,
            Price: $(e).data('price'),
            Image: $(e).data('image')
        };

        // thực hiện xóa
        RemoveItemFromShoppingCart(store, item);
        window.location.href = "/ShoppingCart";
    }
}

RemoveItemFromShoppingCart = function (store, item) {

    if (store.length > 0) {
        var index = store.findIndex(function (d) {
            return d.ProductID == item.ProductID;
        });

        store.splice(index, 1);
        SetCookie('MyShoppingCart', store);
        return store;
    }
}


UpdateCart = function (e) {

    var quantity = $("#txtCartQuantity").val();

    // lấy giỏ ra để bắt đầu đi nhặt hàng
    var store = GetCookie('MyShoppingCart');

    var item = {
        ProductID: $(e).data('productid'),
        ProductName: $(e).data('productname'),
        Quantity: 1,
        Price: $(e).data('price'),
        Image: $(e).data('image')
    };

    // thực hiện cập nhật
    // kiểm tra xem trong giỏ có sản phẩm đó ko 
    var index = store.findIndex(function (d) {
        return d.ProductID == item.ProductID;
    });

    // nếu không có thì dừng luôn
    if (store.length == 0 || index == -1) {
        return;
    }

    store[index].Quantity = quantity;// set cái số lương = số lượng truyền vào
    SetCookie('MyShoppingCart', store);

    window.location.href = "/ShoppingCart";

}