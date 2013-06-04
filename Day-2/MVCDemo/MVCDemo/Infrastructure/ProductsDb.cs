using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;

namespace MVCDemo.Infrastructure
{
    public static class ProductsDb
    {
        private static List<Product> _list =new List<Product>();

        static ProductsDb()
        {
            _list.Add(new Product() { Id = 101, Name = "Pen", Cost = 100 });
            _list.Add(new Product() { Id = 102, Name = "Den", Cost = 200 });
            
        }
        public static Product Add(Product product)
        {
            var newId = _list.Any() ? _list.Max(p => p.Id) + 1 : 1;
            var newProduct = new Product {Id = newId, Name = product.Name, Cost = product.Cost};
            _list.Add(newProduct);
            return newProduct;
        }

        public static IEnumerable<Product> GetAllProducts()
        {
            return _list;
        } 
    }
}