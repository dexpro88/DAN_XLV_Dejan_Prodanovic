using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer
{
    class EFDataAccess : IEFDataAccess
    {
        public void AddProduct(tblProduct product)
        {
            throw new NotImplementedException();
        }

        public List<tblProduct> GetProducts()
        {
            try
            {
                using (StoreDBEntities context = new PizzeriaDBEntities())
                {
                    List<tblProduct> list = new List<tblProduct>();
                    list = (from x in context.tblOrders select x).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
