async function GetAllCategories(){
    const API = 'https://localhost:44308/api/Categories/GetAllCategories'
    
    let request = await fetch(API);
    let response = await request.json();

    let cards = document.getElementById("container");
    response.forEach(category => {
        cards.innerHTML += 
        `<div class="card" style="width: 18rem;">
            <h5 class="card-title">${category.categoryName}</h5>
            <img class="card-img-top" src="/images/${category.categoryImage}" alt="${category.categoryImage} (image not found)">
            <div class="card-body">
                <button onclick="GoToDetails(${category.categoryId})">Go To Details</button>
            </div>
        </div>
        `  
    });

}

function GoToDetails(categoryId) {

    localStorage.setItem("CategoryID",categoryId);
    window.location.href = `/product/product.html?categoryId=${categoryId}`;

}

GetAllCategories();
