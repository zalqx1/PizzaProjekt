using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaProjekt.Models
{
    public class IngredientsOrders
    {
        public int id { get; set; }

        public int IngredientsId { get; set; }
        public Ingredients Ingredients { get; set; }

        public int OrdersId { get; set; }
        public Orders Orders { get; set; }
    }
}
