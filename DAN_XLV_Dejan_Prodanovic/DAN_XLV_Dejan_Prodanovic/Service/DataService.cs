using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Model;

namespace DAN_XLV_Dejan_Prodanovic.Service
{
    class DataService : IDataService
    {
        IDataAccess dataAccess = new DataAccess();
        public List<Product> GetProducts()
        {
            List<Product>list = dataAccess.GetProducts();
            return list;
        }
    }
}
