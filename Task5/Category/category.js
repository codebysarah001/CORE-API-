async function GetAllCategories(){
    const API = 'https://localhost:44308/api/Categories/GetAllCategories'
    
    let request = await fetch(API);
    let response = await request.json();

    let cards = document.getElementById("table");
    response.forEach(row => {
        cards.innerHTML += 
        `<tr>
            <td>${row.categoryName}</td>
            <td>
                <img class="card-img-top" src="/images/${row.productImage}" alt="${row.productImage} (image not found)">

            </td>
            <td>
                <a href="/product/editcategory.html" class="btn btn-primary btn-sm">Edit</a>
                <a href="/product/Details/1" class="btn btn-info btn-sm">Details</a>
                <a href="/product/Delete/1" class="btn btn-danger btn-sm">Delete</a>
            </td>
            
        </tr>
        `  
    });

}

// function GoToDetails(categoryId) {

//     localStorage.setItem("CategoryID",categoryId);
//     window.location.href = `/product/product.html?categoryId=${categoryId}`;

// }

GetAllCategories();
