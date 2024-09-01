const url = "https://localhost:44308/api/Products/AddProduct";
var form = document.getElementById("form");
console.log(form);

async function addProduct() {
  event.preventDefault();

  const formData = new FormData(form);
  console.log(formData.get("ProductName")); 
  debugger

  const response = await fetch(url, {
    method: "POST",
    body: formData,
  });

  var data = response;
  alert("Product Added Succesfully!")
}

async function selectCat(){
  const catURL ="https://localhost:44308/api/Categories/GetAllCategories";

  let request = await fetch(catURL);
  let categories = await request.json();

  var select = document.getElementById("selectCat");
  categories.forEach(option => {
    select.innerHTML += 
    `<option value="${option.categoryId}">${option.categoryName}</option>`;  
  });
}

selectCat();