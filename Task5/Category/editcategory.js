const API = `https://localhost:44308/api/Categories/${CategoryID}`;

var form = document.getElementById("form");
async function updateCategory(){
    event.preventDefault();
    var formData = new FormData(form);

    var response = await fetch(API, {
        method: "PUT",
        body: formData
    })
    alert("Product updated successfully!");
}