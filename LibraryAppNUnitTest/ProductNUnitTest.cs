using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    [TestFixture]
    public class ProductNUnitTest
    {
        [Test]
        public void GetPrice_PremiumClient_ReturnsPrice80()
        {
            Product product = new Product
            {
                Price = 50
            };

            var result = product.GetPrice(new Client { IsPremium = true });

            //assert
            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetPrice_PremiumClientMoq_ReturnsPrice80()
        {
            Product product = new Product
            {
                Price = 50
            };

            var client = new Mock<IClient>();
            client.Setup(x=>x.IsPremium).Returns(true);

            var result = product.GetPrice(client.Object);

            //assert
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
