const Items = document.querySelectorAll(".sidebar__item");

Items.forEach(item => {
    

    item.addEventListener("click", function () {
        const itemName = item.getAttribute("name");
        const img = document.querySelector(`.configurator__toppings img[name="${itemName}"]`);
        const option = document.querySelector(`.sidebar__item[name="${ itemName }"]`)

        console.log(itemName)
        console.log(img)
        console.log(option)
        if (option.classList.contains("active")) {
            console.log("if")
            img.classList.add("item__visible");
        } else {
            console.log("else")
            img.classList.remove("item__visible");
        }
    })
})