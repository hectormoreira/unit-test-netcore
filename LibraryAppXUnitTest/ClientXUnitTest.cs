using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApp
{
    public class ClientXUnitTest
    {
        private Client client;        

        public ClientXUnitTest()
        {
            client = new Client();
        }


        [Fact]
        public void CreateFullName_InputFirstNameLastName_ReturnFullName()
        {
            //arrange
            //Client client = new();

            //act
            client.CreateFullName("Gold", "Roger");

            //assert
            // Show all errors
            Assert.Equal("Gold Roger",client.ClientName);
            
            Assert.Contains("Roger", client.ClientName);
            
            Assert.StartsWith("Gold",client.ClientName);
            Assert.EndsWith("Roger", client.ClientName);
        }

        [Fact]
        public void ClientName_NoValues_ReturnsNull()
        {
            //assert
            Assert.Null(client.ClientName);
        }

        [Fact]
        public void DiscountEvaluation_DefaultClient_ReturnsIntervalDiscount()
        {
            int discount = client.Discount;

            // verify interval range
            Assert.InRange(discount,5,24);
        }

        [Fact]
        public void CreateFullName_InputFirstName_ReturnsNotNull()
        {
            client.CreateFullName("Gold", "");

            Assert.NotNull(client.ClientName);
            Assert.False(string.IsNullOrEmpty(client.ClientName));
        }

        [Fact]
        public void ClientName_InputFirstNameEmpty_ThrowException()
        {
            // verify ArgumentException message
            var exceptionDetail = Assert.Throws<ArgumentException>(() => client.CreateFullName("", "Roger"));
            Assert.Equal("FirstName is null or empty", exceptionDetail.Message);

            //not support
            //Assert.That(() => client.CreateFullName("", "Roger"), Throws.ArgumentException.With.Message.EqualTo("FirstName is null or empty"));
            //Assert.That(() => client.CreateFullName("", "Roger"), Throws.ArgumentException);

            Assert.Throws<ArgumentException>(() => client.CreateFullName("", "Roger"));            
        }

        [Fact]
        public void GetClientDetail_CreateClientWithMinor500TotalOrder_ReturnsBasicClient()
        {
            client.TotalOrder = 400;
            var result = client.GetClientDetail();

            Assert.IsType<BasicCLient>(result);
        }


        [Fact]
        public void GetClientDetail_CreateClientWithMore500TotalOrder_ReturnsBasicClient()
        {
            client.TotalOrder = 700;
            var result = client.GetClientDetail();
            Assert.IsType<PremiumClient>(result);
        }
    }
}
