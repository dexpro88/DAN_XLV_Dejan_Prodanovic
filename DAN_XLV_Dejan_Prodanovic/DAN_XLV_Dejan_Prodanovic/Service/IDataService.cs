using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLV_Dejan_Prodanovic.Service
{
    interface IDataService
    {
        List<Product> GetProducts();
    }
}
