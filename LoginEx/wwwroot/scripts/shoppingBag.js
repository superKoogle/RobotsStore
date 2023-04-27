
window.onload = () => {
    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    countProducts = 0;
    sumPrice = 0;
    cart.map((p,i) => {
        const temp = document.querySelector("#temp-row");
        const clone = temp.content.cloneNode(true);
        //clone.id = "id" + p.productId;
        clone.querySelector("tr").id = "id" + p.productId;
        clone.querySelector(".imageColumn img").src = `../robots/${p.imagePath}`;
        clone.querySelector(".descriptionColumn h3").innerText = p.productName;
        clone.querySelector(".descriptionColumn p").innerText = p.count;
        clone.querySelector(".price").innerText = p.price;
        clone.querySelector(".expandoHeight a").onclick = () => { removeItem(p.productId) };
        document.querySelector("tbody").appendChild(clone);
        countProducts += p.count;
        sumPrice += p.price * p.count;
    })
    document.querySelector("#itemCount").innerText = countProducts;
    document.querySelector("#totalAmount").innerText = sumPrice;
}

const removeItem = (id) => {
    var cart = JSON.parse(localStorage.getItem("cart")) || [];
    const updatedCart = cart.filter(p => p.productId != id);
    localStorage.setItem("cart", JSON.stringify(updatedCart));
    const element = document.querySelector("tbody").querySelector(`#id${id}`);
    document.querySelector("#itemCount").innerText = cart.reduce((accumulator, prod) => {
        return accumulator + prod.count;
    }, 0)
    document.querySelector("#totalAmount").innerText = cart.reduce((accumulator, prod) => {
        return accumulator + prod.price * prod.count;
    }, 0)
    document.querySelector("tbody").removeChild(element);
}

const placeOrder = async () => {

    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    const orderDate = (new Date()).toISOString();
    if (cart.length == 0) return;

    const orderSum = cart.reduce((accumulator, prod) => {
        return accumulator + prod.price * prod.count;
    }, 0)
    if (localStorage.getItem("user") == null) return;
    const userId = JSON.parse(localStorage.getItem("user")).userId;
    const orderItems = cart.map(p => { return { productId: p.productId, quantity: p.count } });
    const response = await fetch("https://localhost:44333/api/Order", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ orderDate, orderSum, userId, orderItems })
    })
    console.log(response.status);
    if (response.ok) localStorage.setItem("cart", null);
}
