async function GetAllProducts(){
    const API = 'https://localhost:44308/api/Products'
    let categoryIdFromStorage = localStorage.getItem('CategoryID');

    let request = await fetch(API);
    let response = await request.json();

    if (categoryIdFromStorage){
        response = response.filter(product => product.categoryId === parseInt(categoryIdFromStorage));
    }
    let cards = document.getElementById("table");
    response.forEach(row => {
        cards.innerHTML += 
        `<tr>
            <td>${row.productName}</td>
            <td>${row.price}</td>
            <td>
                <img class="card-img-top" src="/images/${row.productImage}" alt="${row.productImage} (image not found)">

            </td>
            <td>${row.description}</td>
            <td>${row.categoryId}</td>
            <td>
                <a href="/Product/editproduct.html" onclick="Edit(${row.productId})" class="btn btn-primary btn-sm">Edit</a>
            </td>
            
        </tr>
        `  
    });
}
function Edit(productId) {
    localStorage.setItem("ProductID", productId);
    window.location.href = `/Product/editproduct.html`; 
}

GetAllProducts();

