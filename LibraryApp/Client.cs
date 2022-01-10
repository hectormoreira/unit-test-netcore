using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public interface IClient
    {
        string ClientName { get; set; }
        bool IsPremium { get; set; }
        int TotalOrder { get; set; }
        int Discount { get; set; }

        string CreateFullName(string firstname, string lastname);
        TypeCLient GetClientDetail();
    }

    public class Client : IClient
    {
        public string ClientName { get; set; }
        public int TotalOrder { get; set; }
        public bool IsPremium { get; set; }

        public int Discount { get; set; }

        public Client()
        {
            IsPremium = false;
            Discount = 10;
        }

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

        public TypeCLient GetClientDetail()
        {
            if (TotalOrder < 500)
            {
                return new BasicCLient();
            }
            else
            {
                return new PremiumClient();
            }
        }
    }

    public class TypeCLient
    {

    }

    public class BasicCLient : TypeCLient
    {

    }

    public class PremiumClient : TypeCLient
    {

    }
}
