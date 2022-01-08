using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Client
    {
        public string ClientName { get; set; }
        public int Discount = 10;


        public string CreateFullName(string firstname, string lastname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentException("FirstName is null or empty");
            }

            Discount = 30;
            ClientName = $"{firstname} {lastname}";
            return ClientName;
        }
    }
}
