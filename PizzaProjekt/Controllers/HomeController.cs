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
using PizzaProjekt.ViewModels;

namespace PizzaProjekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IngredientsRepository _ingredientsRepository;


        public HomeController(ILogger<HomeController> logger, IngredientsRepository ingredientsRepository)
        {
            _logger = logger;
            _ingredientsRepository = ingredientsRepository;
        }

        public IActionResult Index()
        {
            List<Ingredients> availableIngredients = _ingredientsRepository.GetAll();
            var viewModel = new ConfiguratorFormViewModel
            {
                AvailableIngredients = availableIngredients,
                GroupedIngredients = availableIngredients
                    .GroupBy(ingredient => ingredient.gruppe)
                    .ToDictionary(group => group.Key, group => group.ToList())
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
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
