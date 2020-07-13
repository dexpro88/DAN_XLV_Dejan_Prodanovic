using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer
{
    interface IEFDataAccess
    {
        void AddProduct(tblProduct product);
        List<tblProduct> GetProducts();
        void RemoveProduct(int productId);
    }
}
