using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        public double GetPrice(Client client)
        {
            if (client.IsPremium)
            {
                return Price * 0.8;
            }
            return Price;
        }

        public double GetPrice(IClient client)
        {
            if (client.IsPremium)
            {
                return Price * 0.8;
            }
            return Price;
        }
    }
}
