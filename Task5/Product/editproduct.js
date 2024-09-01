var x = localStorage.getItem("ProductID");

const API = `https://localhost:44308/api/Products/UpdateProduct/${x}`

var form = document.getElementById("form");
async function updateProduct(){
    event.preventDefault();
    var formData = new FormData(form);
   
  let response = await fetch(API, {
    method: "PUT",
    body: formData,
});

var data = response;
    alert("Product updated successfully!");
}