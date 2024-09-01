const url = "https://localhost:44308/api/Categories/AddNewCategory";

var form = document.getElementById("form");
console.log(form);

async function addCategory() {
  event.preventDefault();

  debugger;
  const formData = new FormData(form);
  console.log(formData.get("CategoryName")); 

  let response = await fetch(url, {
      method: "POST",
      body: formData,
  });

  var data = response;
  alert("Category Added Succesfully!");
}

