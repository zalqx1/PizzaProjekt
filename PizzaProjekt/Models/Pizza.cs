using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Models;

namespace PizzaProjekt.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public List<PizzaIngredients> PizzaIngredients { get; set; } = new List<PizzaIngredients>();
        public List<OrdersPizza> OrdersPizza { get; set; } = new List<OrdersPizza>();
    }
}
