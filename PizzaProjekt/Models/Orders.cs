using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaProjekt.Models
{
    public class Orders
    {
        public int id { get; set; }

        public string street{ get; set; }
        
        public int number{ get; set; }
        
        public int postCode{ get; set; }
        
        public string city{ get; set; }
        
        public string name{ get; set; }
        
        public string nachname{ get; set; }

        public ICollection<IngredientsOrders> IngredientsOrders { get; set; }
    }
}
