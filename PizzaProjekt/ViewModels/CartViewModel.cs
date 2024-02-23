using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Models;

namespace PizzaProjekt.ViewModels
{
    public class CartViewModel
    {
        public List<Pizza> CartItems { get; set; }
        public int CartItemCount { get; set; }

    }
}
