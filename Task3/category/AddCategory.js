async function addCategory() {
  event.preventDefault();
  var form = document.getElementById("categoryForm");
  const formData = new FormData(form);
  console.log(formData.get("CategoryName"));

  fetch("https://localhost:44308/api/Categories/AddNewCategory", {
    method: "POST",
    body: formData,
  });
}


// const formRef = document.getElementById("categoryForm");

// formRef.addEventListener("submit", (event) => {
//   event.preventDefault();

//   const formData = new FormData(formRef);

// //   console.log(formData.get("CategoryName"));

//   fetch("https://localhost:44308/api/Categories/AddNewCategory", {
//     method: "POST",
//     body: formData,
//   });
// });



