using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Product
    {
        //- ID, 
        // - Naziv proizvoda, 
        // - Šifra proizvoda,
        // - Količina(komad), 
        //  - Cena(izražena u dinarima) 
        //      - Skladišteno(da/ne)
        public int ID { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public bool Store { get; set; }
        static int productId = 0;

        public Product()
        {

        }

        public Product(string code, int amount, decimal price, bool store)
        {
            ID = ++productId;
            Code = code;
            Amount = amount;
            Price = price;
            Store = store;
        }
    }
}
