using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    [TestFixture]
    public class ClientNUnitTest
    {
        private Client client;
        [SetUp]
        public void Setup()
        {
            client = new Client();
        }


        [Test]
        public void CreateFullName_InputFirstNameLastName_ReturnFullName()
        {
            //arrange
            //Client client = new();

            //act
            client.CreateFullName("Gold", "Roger");

            //assert
            // Show all errors
            Assert.Multiple(() =>
            {
                Assert.That(client.ClientName, Is.EqualTo("Gold Roger"));
                Assert.AreEqual(client.ClientName, "Gold Roger");
                Assert.That(client.ClientName, Does.Contain("Roger"));
                Assert.That(client.ClientName, Does.Contain("roger").IgnoreCase);
                Assert.That(client.ClientName, Does.StartWith("Gold"));
                Assert.That(client.ClientName, Does.EndWith("Roger"));
            });

        }

        [Test]
        public void ClientName_NoValues_ReturnsNull()
        {
            //arrange
            //Client cl = new();

            //assert
            Assert.IsNull(client.ClientName);
        }

        [Test]
        public void DiscountEvaluation_DefaultClient_ReturnsIntervalDiscount()
        {
            int discount = client.Discount;

            // verify interval range
            Assert.That(discount, Is.InRange(5, 25));
        }

        [Test]
        public void CreateFullName_InputFirstName_ReturnsNotNull()
        {
            client.CreateFullName("Gold", "");

            Assert.IsNotNull(client.ClientName);
            Assert.IsFalse(string.IsNullOrEmpty(client.ClientName));
        }

        [Test]
        public void ClientName_InputFirstNameEmpty_ThrowException()
        {
            // verify ArgumentException message
            var exceptionDetail = Assert.Throws<ArgumentException>(() => client.CreateFullName("", "Roger"));
            Assert.AreEqual("FirstName is null or empty", exceptionDetail.Message);
            Assert.That(() => client.CreateFullName("", "Roger"), Throws.ArgumentException.With.Message.EqualTo("FirstName is null or empty"));

            Assert.Throws<ArgumentException>(() => client.CreateFullName("", "Roger"));
            Assert.That(() => client.CreateFullName("", "Roger"), Throws.ArgumentException);
        }
    }
}
