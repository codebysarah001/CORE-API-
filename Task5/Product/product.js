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
            <td>
                <a href="/product/editproduct.html" class="btn btn-primary btn-sm">Edit</a>
                <a href="/product/Details/1" class="btn btn-info btn-sm">Details</a>
                <a href="/product/Delete/1" class="btn btn-danger btn-sm">Delete</a>
            </td>
            
        </tr>
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