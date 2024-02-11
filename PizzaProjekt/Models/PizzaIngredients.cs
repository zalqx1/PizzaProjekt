using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Models;

namespace PizzaProjekt.Models
{
    public class PizzaIngredients
    {
        public int id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int IngredientsId { get; set; }
        public Ingredients Ingredients { get; set; }
    }
}
