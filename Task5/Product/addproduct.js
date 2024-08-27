/** @format */

async function addProduct() {
  event.preventDefault();
  var form = document.getElementById("form");
  const formData = new FormData(form);

  const response = await fetch("https://localhost:44308/api/Products", {
    method: "POST",
    body: formData,
  });

  if (response.ok) {
    alert("Successfully added!");
  } else {
    alert("Failed to add product. Please try again.");
  }
}