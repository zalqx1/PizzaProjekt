using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Extensions;

namespace PizzaProjekt.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            List<string> cartItems = HttpContext.Session.Get<List<string>>("Cart");

            return View(cartItems);
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
