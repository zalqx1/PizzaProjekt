using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaProjekt.Models;
using PizzaProjekt.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Repositories;

namespace PizzaProjekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IngredientsRepository _ingredientsRepository;
        private readonly CartService _cartService;


        public HomeController(ILogger<HomeController> logger, IngredientsRepository ingredientsRepository, CartService cartService)
        {
            _logger = logger;
            _ingredientsRepository = ingredientsRepository;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var ingredients = _ingredientsRepository.GetAllIngredients();
            return View(ingredients);
        }

        [HttpPost]
        public IActionResult addToCart()
        {
            var formData = HttpContext.Request.Form;

            _cartService.ProcessCart(formData);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        } 
        
        public IActionResult Checkout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
