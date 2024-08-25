async function ShowDetails(){
    let productIDFromStorage = localStorage.getItem('ProductID');
    const API = `https://localhost:7214/api/Products/Product/${productIDFromStorage}`;

    let request = await fetch(API);
    let response = await request.json();

    console.log(response);
    
    let cards = document.getElementById("container");
        cards.innerHTML = 
        `<div class="card" style="width: 18rem;">
            <h5 class="card-title">${response.productName}</h5>
            <img class="card-img-top" src="/images/${response.productImage}" alt="${response.productImage} (image not found)">
            <div class="card-body">
                <button onclick="GoToDetails(${response.productId})">Go To Details</button>
            </div>
        </div>
        `  
}

// function ClearStorage(){
//     localStorage.clear();
// }
ShowDetails();
