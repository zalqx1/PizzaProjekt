using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Models;

namespace PizzaProjekt.ViewModels
{
    public class ConfiguratorFormViewModel
    {
        public ConfiguratorFormViewModel()
        {
            AvailableIngredients = new List<Ingredients>();
            GroupedIngredients = new Dictionary<string, List<Ingredients>>();
            SelectedIngredientIds = new List<int>();
        }

        public List<Ingredients> AvailableIngredients { get; set; }
        public Dictionary<string, List<Ingredients>> GroupedIngredients { get; set; }
        public List<int> SelectedIngredientIds { get; set; }
    }
}
