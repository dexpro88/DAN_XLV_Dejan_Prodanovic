using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        List<Product> products = new List<Product>() { new Product("12345",10, 1000, false) ,
        new Product("43215",20, 3400, false) ,new Product("76543",40, 1500, true),
            new Product("45367",10, 2000, true)  };

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void RemoveProduct(int productId)
        {
            Product productToDelete = null;
            foreach (var product in products)
            {
                if (product.ID==productId)
                {
                    productToDelete = product;
                }
            }
            if (productToDelete!=null)
            {
                products.Remove(productToDelete);
            }
        }
    }
}
