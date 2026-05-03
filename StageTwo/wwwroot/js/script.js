let pic = document.getElementById("avatar");
pic.addEventListener("click", () => {
    pic.style.cursor = "pointer";
    alert("Xin chào");
    pic.style.filter = "grayscale(100%)";
})