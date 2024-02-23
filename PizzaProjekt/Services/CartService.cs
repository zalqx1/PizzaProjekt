using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjekt.Database;
using PizzaProjekt.Models;

namespace PizzaProjekt.Services
{
    public class CartService
    {
        private readonly DatabaseContext _dbContext;

        public CartService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateOrder(Orders order, List<Pizza> cartItems)
        {
            // Add and save Order Data to Database
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            int ordersId = order.id;

            foreach (var pizza in cartItems)
            {
                // Ensure PizzaIngredients are attached to the context
                foreach (var pizzaIngredient in pizza.PizzaIngredients)
                {
                    _dbContext.Attach(pizzaIngredient);
                }

                // Add and save Pizza Data to Database
                _dbContext.Pizza.Add(pizza);
                _dbContext.SaveChanges();

                int pizzaId = pizza.Id;

                OrdersPizza ordersPizza = new OrdersPizza
                {
                    OrdersId = ordersId,
                    PizzaId = pizzaId
                };
                
                // Add and save OrdersPizza Data to Database
                _dbContext.OrdersPizza.Add(ordersPizza);
                _dbContext.SaveChanges();
            }
        }
    }
}
