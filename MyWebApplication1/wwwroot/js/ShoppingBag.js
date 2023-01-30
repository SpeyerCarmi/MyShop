
function GetMyCart() {
    let myCartAsJson = sessionStorage.getItem('myCart');
    myCart = JSON.parse(myCartAsJson);
    totalAmount = 0
    i = 0
    myCart.forEach(cart => {

        totalAmount += cart.price
        showCart(cart, i);
        i++;
    })
    document.getElementById("itemCount").innerText = myCart.length
    document.getElementById("totalAmount").innerText = totalAmount
}

function showCart(cart, i) {
    let temp = document.getElementById("temp-row");
    let clone = temp.content.cloneNode(true);
    clone.querySelector(".itemName").innerText = cart.name;
    clone.querySelector(".price").innerText = cart.price;
    clone.querySelector(".DeleteButton").addEventListener('click', () => { deleteProductFromCart(cart, i) });
    let stringImage = "../img/" + cart.imageUrl;
    clone.querySelector(".image").style.backgroundImage = `url(${stringImage})`;
    document.body.appendChild(clone);

}

function deleteProductFromCart(cart, i) {
    let myCartAsJson = sessionStorage.getItem('myCart');
    myCart = JSON.parse(myCartAsJson);
    removeCart(myCart)
    myCart.splice(i, 1);
    sessionStorage.setItem('myCart', JSON.stringify(myCart))

    GetMyCart()
}


function removeCart(myCart) {


    const res = document.getElementById("temp-row");
    const products = document.getElementsByClassName("item-row");
    for (let i = products.length - 1; i >= 0; i--) {
        var prod = products[i]
        document.body.removeChild(prod);
    }
    sessionStorage.removeItem('myCart')
}

const placeOrder = async () => {
    const userDataAsJson = sessionStorage.getItem('user')
    const userData = JSON.parse(userDataAsJson)
    const userId = userData.id;
    const myCartAsJson = sessionStorage.getItem('myCart');
    const myCart = JSON.parse(myCartAsJson);
    const orderItems = myCart.map(createOrderItems);
    const totalPrice = document.getElementById("totalAmount").value;
    const order = createOrder(userId, totalPrice, orderItems);

    const response = await fetch("api/Order", {
        headers: { "Content-Type": "application/json" },
        method: 'POST',
        body: JSON.stringify(order)

    });
    if (!response.ok) {
        throw new Error(`the connect failed ${response.status}, try again`);
    }
    if (response.status == 204) {
        console.log("order doeswnt craete");
        return;
    }
    const newOrder = response.json();
    alert(`הזמנתך התקבלה בהצלחה`);
    saveCartToSessionStorage([]);
    window.location.href = "Products.html";
}

const createOrderItems = (product) => {
    const orderItem = {
        "productId": product.id,
        "Quantity": "3"
    }
    return orderItem;
}

function createOrder(userId, price, orderItems) {
    const order = {
        "date": new Date(),
        "price": price,
        "userId": userId,
        "orderItems": orderItems
    };
    return order;
}

