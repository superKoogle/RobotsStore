
const pageLoad = async () => {
    const products = await getAllProducts();
    const categories = await getAllCategories(products);
    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    document.querySelector("#ItemsCountText").innerText = cart.length;
}

const getAllProducts = async (query) => {
    const response = await fetch(`https://localhost:44333/api/Product?${query || ""}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    const products = response.status==200 ? await response.json() : [];
    document.getElementById("PoductList").innerHTML = "";
    products.map(product => {
        const temp = document.getElementById("temp-card");
        const clon = temp.content.cloneNode(true);
        clon.querySelector("img").src = `../robots/${product.imagePath}`;
        clon.querySelector("h1").innerText = product.productName;
        clon.querySelector(".price").innerText = `${product.price} $`;
        clon.querySelector(".description").innerText = product.description;
        clon.querySelector("button").addEventListener("click", () => { addToCart(product)});
        document.getElementById("PoductList").appendChild(clon);
    })
    return products;
}

const getAllCategories = async (products) => {
    const response = await fetch("https://localhost:44333/api/Category", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    const categories = response.ok ? await response.json() : [];
    categories.map(category => {
        const temp = document.getElementById("temp-category");
        const clon = temp.content.cloneNode(true);
        clon.querySelector(".OptionName").innerText = category.categoryName;
        clon.querySelector(".Count").innerText = products.filter(p => p.category.categoryName == category.categoryName).length;
        document.getElementById("categoryList").appendChild(clon);
    })
    return categories;
}

const addToCart = (product) => {
    var cart = JSON.parse(localStorage.getItem("cart")) || [];
    const existingProd = cart.find(p => p.productId == product.productId);
    if (existingProd) existingProd.count += 1;
    else cart.push({ ...product, count:1 });
    localStorage.setItem("cart", JSON.stringify(cart));
    document.querySelector("#ItemsCountText").innerText = cart.length;
}

const filterProducts = async () => {
    const categoriesNodes = document.querySelector("#categoryList").querySelectorAll("div")
    var categories = [];
    for (var i = 0; i < categoriesNodes.length; i++) {
        if (!categoriesNodes[i].querySelector("input").checked)
            categories.push(categoriesNodes[i].querySelector(".OptionName").innerText)
    }
    const name = document.querySelector("#nameSearch").value;
    const minPrice = document.querySelector("#minPrice").value;
    const maxPrice = document.querySelector("#maxPrice").value;
    await getAllProducts(createQueryString(categories, name, minPrice, maxPrice));
}

const createQueryString=(categories, name, min, max)=>{
    var query = "";
    if (categories != [])
        for (var i = 0; i < categories.length; i++) {
            query = query.concat(`categories=${categories[i]}&`)
        }
    if (name != null) query = query.concat(`name=${name}&`);
    if (min != null) query = query.concat(`minPrice=${min}&`);
    if (max != null) query = query.concat(`maxPrice=${max}&`);
    return query;
}

document.addEventListener("load", pageLoad());

