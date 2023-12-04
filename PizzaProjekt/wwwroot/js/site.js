// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
    PriceButton.querySelector("svg").classList.add("berg");
    
    const addCart = async () => {
        await setTimeout(7000);
        console.log("Waited 7s");

        const Cart = document.querySelector("header .header__cart");
        Cart.classList.add("cartAdded");
    };
    addCart();
})