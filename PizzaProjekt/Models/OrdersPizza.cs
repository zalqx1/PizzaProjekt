using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaProjekt.Models
{
    public class OrdersPizza
    {
        public int id { get; set; }

        public int OrdersId { get; set; }
        public Orders Orders { get; set; }
        
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
