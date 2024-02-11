using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PizzaProjekt.Services
{
    public class CartService
    {
        public void ProcessCart(IFormCollection formData)
        {
            var selectedItems = new List<string>();

            foreach (var key in formData.Keys)
            {
                var values = formData[key];

                if (values.Contains("true", StringComparer.OrdinalIgnoreCase))
                {
                    selectedItems.Add(key);
                }
            }
        }
    }
}
