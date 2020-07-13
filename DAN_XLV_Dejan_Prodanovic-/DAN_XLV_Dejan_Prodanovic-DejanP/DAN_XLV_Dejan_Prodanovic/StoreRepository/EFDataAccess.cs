using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository
{
    public class EFDataAccess : IEFDataAccess
    {
        public void AddProduct(tblProduct product)
        {
            try
            {
                using (StoreDBEntities context = new StoreDBEntities())
                {

                    tblProduct newOrder = new tblProduct();
                    newOrder.ProductName = "Nesto";
                    newOrder.Price = 10;
                    newOrder.Amount = 1;

                    context.tblProducts.Add(newOrder);
                    context.SaveChanges();
                    


                   

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                
            }
        }

        public List<tblProduct> GetProducts()
        {
            try
            {
                using (StoreDBEntities context = new StoreDBEntities())
                {
                    List<tblProduct> list = new List<tblProduct>();
                    //list.Add(new tblProduct { ProductName ="nesto",Price=10});
                    list = (from x in context.tblProducts select x).ToList();

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
