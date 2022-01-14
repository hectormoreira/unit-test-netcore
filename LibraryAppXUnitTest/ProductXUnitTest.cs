using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApp
{
    public class ProductXUnitTest
    {
        [Fact]
        public void GetPrice_PremiumClient_ReturnsPrice80()
        {
            Product product = new Product
            {
                Price = 50
            };

            var result = product.GetPrice(new Client { IsPremium = true });

            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void GetPrice_PremiumClientMoq_ReturnsPrice80()
        {
            Product product = new Product
            {
                Price = 50
            };

            var client = new Mock<IClient>();
            client.Setup(x => x.IsPremium).Returns(true);

            var result = product.GetPrice(client.Object);

            //assert
            Assert.Equal(40, result);
        }
    }
}
