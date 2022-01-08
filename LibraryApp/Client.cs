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

        public string CreateFullName(string firstname, string lastname)
        {
            ClientName = $"{firstname} {lastname}";
            return ClientName;
        }
    }
}
