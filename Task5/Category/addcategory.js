const url = "https://localhost:44308/api/Categories/AddNewCategory";
var form = document.getElementById("form");

async function addCategory() {
  event.preventDefault();

  debugger;
  const formData = new FormData(form);
  console.log(formData.get("AddCategory function called!")); 

  let response = await fetch("https://localhost:44308/api/Categories/AddNewCategory", {
      method: "POST",
      body: formData,
  });

  var data = response;
  alert("Category Added Succesfully!");
}
