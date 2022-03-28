using dotnetcoresoapcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoresoapcore.Services
{
    public class ProductService : IProductService
    {
        public bool Create(Product product)
        {
            if (Startup.Products.ContainsKey(product.Id)) throw new InvalidOperationException("Product already exists.");
            Startup.Products.Add(product.Id, product);
            return true;
        }

        public bool Update(Product product)
        {
            if (!Startup.Products.ContainsKey(product.Id)) throw new InvalidOperationException("Product not found.");
            Startup.Products[product.Id] = product;
            return true;
        }

        public bool Delete(Guid id)
        {
            if (!Startup.Products.ContainsKey(id)) throw new InvalidOperationException("Product not found.");
            Startup.Products.Remove(id);
            return true;
        }

        public Product[] Get()
        {
            return Startup.Products.Values.ToArray();
        }
    }
}
