﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const items = document.querySelectorAll(".sidebar__item");

items.forEach(item => {
    console.log(item);
    item.addEventListener('click', function () {
        
        if (this.classList.contains("active")) {
            this.classList.remove("active");
        } else {
            this.classList.add("active");
        }
    })
})

const PriceButton = document.querySelector(".configurator__price-button");

PriceButton.addEventListener("click", function () {
    alert("Ihre Bestellung wurde zum Warenkorb hinzugefügt.")
})

const Items = document.querySelectorAll(".sidebar__item");
Items.forEach(item => {


    item.addEventListener("click", function () {
        const itemName = item.getAttribute("name");
        const img = document.querySelector(`.configurator__toppings img[name="${itemName}"]`);
        const option = document.querySelector(`.sidebar__item[name="${itemName}"]`)

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