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
                <img class="card-img-top" src="/images/${row.categoryImage}" alt="${row.categoryImage} (image not found)">

            </td>
            <td>
                <a href="/Category/editcategory.html" onclick="Edit(${row.categoryId})" class="btn btn-primary btn-sm">Edit</a>
            </td>
            
        </tr>
        `  
    });

}
function Edit(categoryId) {
    localStorage.setItem("CategoryID", categoryId);
    window.location.href = `/Category/editcategory.html`; 
}
GetAllCategories();
