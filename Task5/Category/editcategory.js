document.getElementById("form").addEventListener("submit", updateCategory);

async function updateCategory(event) {
    event.preventDefault();

    var x = localStorage.getItem("CategoryID");
    const API = `https://localhost:44308/api/Categories/${x}`;
    
    var form = document.getElementById("form");
    var formData = new FormData(form);
    
    var response = await fetch(API, {
        method: "PUT",
        body: formData
    });

    if (response.ok) {
        alert("Category updated successfully!");
    } else {
        alert("Failed to update category.");
    }
}
