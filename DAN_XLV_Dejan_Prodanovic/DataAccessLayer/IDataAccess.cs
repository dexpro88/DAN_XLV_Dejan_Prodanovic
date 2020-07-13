using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataAccess
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        void RemoveProduct(int productId);
    }
}
