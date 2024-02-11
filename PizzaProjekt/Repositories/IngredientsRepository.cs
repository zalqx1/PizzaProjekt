using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Database;
using PizzaProjekt.Models;

namespace PizzaProjekt.Repositories
{
    public class IngredientsRepository
    {
        private readonly DatabaseContext _context;
        public IngredientsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Ingredients> GetAll()
        {
            return _context.Ingredients.ToList();
        }
        public List<Ingredients> GetIngredientsByIds(List<int> ingredientIds)
        {
            return _context.Ingredients
                .Where(i => ingredientIds.Contains(i.id))
                .ToList();
        }
    }
}
