async function getAllCategories(){
    const API = `https://localhost:7260/api/Categories/GetAllCategories`
    const request = await fetch(API);
    const response = await request.json();

    let cards = document.getElementById("container");
    response.forEach(category => {
        cards.innerHTML+=`<div class="card" style="width: 18rem;">
                <img class="card-img-top" src="/images/${category.categoryImage}" alt="${category.categoryName}">
                <div class="card-body">
                    <h3 class="card-title">${category.categoryName}</h3>
                    <div class="card-body">
                        <button onclick="GoToDetails(${category.categoryId})">Go To Details</button>
                    </div>
                </div>
            </div>`;
    })
};

function GoToDetails(categoryId){
    localStorage.setItem("categoryID", categoryId);
    window.location.href = `/Product/product.html?categoryId=${categoryId};`;
}

getAllCategories();