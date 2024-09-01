async function details(){
    let categoryIdFromStorage = localStorage.getItem('productID');
    const API =`https://localhost:7260/api/Products/Product/${categoryIdFromStorage}`
    debugger;
    let request = await fetch(API);
    let response = await request.json();
    
    let cards = document.getElementById("container");
    cards.innerHTML =
        `<div class="card" style="width: 18rem;">
                <img class="card-img-top" src="/images/${response.productImage}" alt="${response.productName}">
                <div class="card-body">
                    <h3 class="card-title">${response.productName}</h3>
                    <p  class="card-text">${response.description}</p>
                    <h5 class="card-price">$${response.price}</h5>
                        <form id="addToCart">
                        <div>
                            <label>Enter Quantity:</label>
                            <input type="number" name="quantity" id="quantity"/>
                        </div>
                        <br>
                        <div>
                            <button type="submit" onclick="addToCart(${response.cartId})">Add To Cart</button>
                        </div>
                    </form>
                </div>
            </div>`;
    }
    details();


    async function addToCart() {
        // debugger;

    const url = "https://localhost:7260/api/CartItem/AddToCart";
    event.preventDefault();

    const cartId = 1;
    const productId = localStorage.getItem("productID");
    quantity = document.getElementById("quantity").value;
        
      let request={
        cartId: cartId,
        productId: productId,
        quantity: quantity,
  
  
      };
    
      let response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(request),
        headers: {
          "Content-Type": "application/json",
        },
      });
      alert("Product Added Succesfully!")

      let data = await response.json();
      window.location.href= '../Cart/cart.html';
    }
    
addToCart()