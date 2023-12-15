const Items = document.querySelectorAll(".sidebar__item");

Items.forEach(item => {    
    const itemName = item.getAttribute("name");
    const img = document.querySelector(`.configurator__toppings img[name="${itemName}"]`);
    console.log(img)
    console.log("click")
})