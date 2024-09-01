async function cart(){
    const API = `https://localhost:7260/api/CartItem`
    let request = await fetch(API);
    let response = await request.json();

    let cards = document.getElementById("table");
    response.forEach(row => {
        cards.innerHTML += 
        `<tr>
            <td>${row.cartItemId}</td>
            <td>
                <form>
                    <div>
                        <input type="number" name="quantity" value="${row.quantity}" id="quantity"/>
                    </div>
                </form>
            </td>
            <td>${row.product.productName}</td>
            <td>
                <a href="#" onclick="Edit(${row.cartItemId})" class="btn btn-primary btn-sm">Edit</a>
                <a href="#" onclick="DeleteItem(${row.cartItemId})" class="btn btn-danger btn-sm">Delete</a>
            </td>
            
        </tr>
        `  
    });
}
cart();

async function DeleteItem(cartItemId){
    debugger;
    const API = `https://localhost:7260/api/CartItem/DeleteFromCart/${cartItemId}`
    event.preventDefault();

    
    let response = await fetch(API, {
    method: "DELETE",
    headers: {
        'Content-Type': 'application/json'
    }
})
    
    alert("Product Deleted successfully!");
}


async function Edit(cartItemId){
    debugger;
    const API = `https://localhost:7260/api/CartItem/UpdateQuantity/${cartItemId}`
    event.preventDefault();
    let q = {
        quantity : document.getElementById("quantity").value
    }
    


    let response = await fetch(API, {
    method: "PUT",
    body: JSON.stringify(q),
    headers: {
        'Content-Type': 'application/json'
    }
})
    const updatedProduct = await response.json();
  

    var data = response;
    alert("Product updated successfully!");
}