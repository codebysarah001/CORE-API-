async function getAllProducts(){
    const API =`https://localhost:7260/api/Products`
    let categoryIdFromStorage = localStorage.getItem('categoryID');

    let request = await fetch(API);
    let response = await request.json();

    if (categoryIdFromStorage){
        response = response.filter(product => product.categoryId === parseInt(categoryIdFromStorage));
    }

    let cards = document.getElementById("container");
    response.forEach(product =>{
        cards.innerHTML+=
        `<div class="card" style="width: 18rem;">
                <img class="card-img-top" src="/images/${product.productImage}" alt="${product.productName}">
                <div class="card-body">
                    <h3 class="card-title">${product.productName}</h3>
                    <p  class="card-text">${product.description}</p>
                    <div class="card-body">
                        <button onclick="GoToDetails(${product.productId})">Go To Details</button>
                    </div>
                </div>
            </div>`;
    })
}

function GoToDetails(productId){
    localStorage.setItem("productID",productId);
    window.location.href = `/Product/details.html?productId=${productId};`;
}

function ClearStorage(){
    localStorage.clear();
}

getAllProducts();