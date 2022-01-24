// Hover effects
let li = document.getElementsByClassName("nav_item");

for (let i = 0; i < li.length; i++) {
    li[i].addEventListener("mouseover", function () {
        li[i].classList.add("nav_item_active")
    });
    li[i].addEventListener("mouseout", function () {
        li[i].classList.remove("nav_item_active")
    })
}


// -----------
