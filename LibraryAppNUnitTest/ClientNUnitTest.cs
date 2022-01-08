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
            Assert.That(client.ClientName, Is.EqualTo("Gold Roger"));
            Assert.AreEqual(client.ClientName, "Gold Roger");
            Assert.That(client.ClientName, Does.Contain("Roger"));
            Assert.That(client.ClientName, Does.Contain("roger").IgnoreCase);
            Assert.That(client.ClientName, Does.StartWith("Gold"));
            Assert.That(client.ClientName, Does.EndWith("Roger"));
        }

        [Test]
        public void ClientName_NoValues_ReturnsNull()
        {
            //arrange
            //Client cl = new();

            //assert
            Assert.IsNull(client.ClientName);
        }
    }
}
