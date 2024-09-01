async function GetAllProducts(){
    const API = 'https://localhost:44308/api/Products'
    let categoryIdFromStorage = localStorage.getItem('CategoryID');

    let request = await fetch(API);
    let response = await request.json();

    if (categoryIdFromStorage){
        response = response.filter(product => product.categoryId === parseInt(categoryIdFromStorage));
    }
    let cards = document.getElementById("container");
    response.forEach(product => {
        cards.innerHTML += 
        `<div class="card" style="width: 18rem;">
            <h5 class="card-title">${product.productName}</h5>
            <img class="card-img-top" src="/images/${product.productImage}" alt="${product.productImage} (image not found)">
            <p>${product.description}</p>
            <div class="card-body">
                <button onclick="GoToDetails(${product.productId})">Go To Details</button>
            </div>
        </div>
        `  
    });
}
function GoToDetails(productId){
    localStorage.setItem("ProductID",productId);
    window.location.href = `/product/productDetails.html?productId=${productId}`;
}
function ClearStorage(){
    localStorage.clear();
}
GetAllProducts();