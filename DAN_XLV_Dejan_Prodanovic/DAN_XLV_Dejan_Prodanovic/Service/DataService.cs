﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
 

namespace DAN_XLV_Dejan_Prodanovic.Service
{
    class DataService : IDataService
    {
        

        public void AddProduct(tblProduct product)
        {
            
        }

        public List<tblProduct> GetProducts()
        {
            try
            {
                using (StoreDBEntities context = new StoreDBEntities())
                {
                    List<tblProduct> list = new List<tblProduct>();
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
            try
            {
                using (StoreDBEntities context = new StoreDBEntities())
                {
                    tblProduct productToDelete = (from u in context.tblProducts
                                                  where u.ID == productId select u).First();

                    context.tblProducts.Remove(productToDelete);

                    context.SaveChanges();
 
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}