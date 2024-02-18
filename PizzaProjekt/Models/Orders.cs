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
        
        public int houseNumber{ get; set; }
        
        public int postCode{ get; set; }
        
        public string city{ get; set; }
        
        public string name{ get; set; }
        
        public string surname{ get; set; }

        public string phoneNumber { get; set; }

        public List<OrdersPizza> OrdersPizza { get; set; } = new List<OrdersPizza>();
    }
}
