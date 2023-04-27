
window.onload =  () => {
    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    var countProducts = 0;
    var sumPrice = 0;
    //console.log(cart);
    cart.map((p, i) => {
        const temp = document.getElementById("temp-row");
        const clone = temp.content.cloneNode(true);
        clone.querySelector("tr").id = "prod" + p.productId;
        clone.querySelector(".imageColumn img").src = `../robots/${p.imagePath}`;
        clone.querySelector(".descriptionColumn h3").innerText = p.productName;
        clone.querySelector(".descriptionColumn p").innerText = p.count;
        clone.querySelector(".price").innerText = p.price;
        clone.querySelector(".expandoHeight a").onclick = () => { removeItem(p.productId) }
        document.querySelector("tbody").appendChild(clone);
        countProducts += p.count;
        sumPrice += p.price * p.count;
    })
    document.querySelector("#itemCount").innerText = countProducts;
    document.querySelector("#totalAmount").innerText = sumPrice;
}

const removeItem = (id) => {
    const cart = JSON.parse(localStorage.getItem("cart"));
    const updatedCart = cart.filter(p => p.productId != id);
    localStorage.setItem("cart", JSON.stringify(updatedCart));
    document.querySelector("tbody").removeChild(document.querySelector("tbody").querySelector(`#prod${id}`));
    //השורות הבאות עובדות באיחור
    document.querySelector("#itemCount").innerText = cart.reduce((accumulator, prod) => {
        return accumulator + prod.count;
    }, 0);
    document.querySelector("#totalAmount").innerText = cart.reduce((accumulator, prod) => {
        return accumulator + prod.price * prod.count;
    }, 0);
}

const placeOrder = async () => {
    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    if (cart.length == 0) return;
    const orderDate = (new Date()).toISOString();
    const orderSum = cart.reduce((accumulator, prod) => {
        return accumulator + prod.price * prod.count;
    }, 0);
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user) { alert("please sign in!"); return; }
    const orderItems = cart.map(p => { return { productId: p.productId/*, quantity: p.count*/ } })
    const response = await fetch("https://localhost:44333/api/Order", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ orderDate, orderSum, userId: user.userId, orderItems })
    })
    console.log(response.status);
    if (response.ok) localStorage.setItem("cart", null);
}