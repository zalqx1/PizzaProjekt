using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Extensions;
using PizzaProjekt.Services;

namespace PizzaProjekt.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            List<string> cartItems = HttpContext.Session.Get<List<string>>("Cart");

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult addToCart()
        {
            var formData = HttpContext.Request.Form;
            var selectedItems = _cartService.ProcessCart(formData);
            var existingCart = HttpContext.Session.Get<List<string>>("Cart");
            
            if (existingCart == null)
            {
                // If the cart session does not exist, set it with the selected items
                HttpContext.Session.Set("Cart", selectedItems);
            }
            else
            {
                // If the cart session exists, add the selected items to it
                existingCart.AddRange(selectedItems);
                HttpContext.Session.Set("Cart", existingCart);
            }


            return RedirectToAction("Index", "Home");
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
