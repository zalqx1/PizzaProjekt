using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Extensions;
using PizzaProjekt.Services;
using PizzaProjekt.ViewModels;
using PizzaProjekt.Models;
using PizzaProjekt.Repositories;

namespace PizzaProjekt.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly IngredientsRepository _ingredientsRepository;

        public CartController(CartService cartService, IngredientsRepository ingredientsRepository)
        {
            _cartService = cartService;
            _ingredientsRepository = ingredientsRepository;
        }
        public IActionResult Index()
        {
            List<Pizza> cartItems = HttpContext.Session.Get<List<Pizza>>("Cart") ?? new List<Pizza>();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult addToCart(ConfiguratorFormViewModel viewModel)
        {
            var selectedIngredientIds = viewModel.SelectedIngredientIds;

            // Retrieve the corresponding Ingredients based on selectedIngredientIds
            var selectedIngredients = _ingredientsRepository.GetIngredientsByIds(selectedIngredientIds);

            var existingCart = HttpContext.Session.Get<List<Pizza>>("Cart") ?? new List<Pizza>();

            Pizza existingPizza = existingCart.FirstOrDefault();

            var newPizza = new Pizza
            {
                PizzaIngredients = selectedIngredients.Select(ingredient => new PizzaIngredients
                {
                    IngredientsId = ingredient.id,
                    Ingredients = ingredient,
                }).ToList()
            };

            existingCart.Add(newPizza);


            HttpContext.Session.Set("Cart", existingCart);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult DeleteCartItem(int index)
        {
            // Retrieve the cart from the session
            var existingCart = HttpContext.Session.Get<List<Pizza>>("Cart");

            if (existingCart != null && index >= 0 && index < existingCart.Count)
            {
                // Remove the item at the specified index
                existingCart.RemoveAt(index);

                // Update the session with the modified cart
                HttpContext.Session.Set("Cart", existingCart);
            }

            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
