using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApp
{    
    public class OperationXUnitTest
    {
        [Fact]
        public void SumNumber_InputTwoNumbers_GetCorrectValue()
        {
            // arrange - inicialiacion de los valores que ejecutan el test
            Operation op = new();
            int num1test = 50;
            int num2test = 40;

            // act - Represanta la ejecucion de la operacion
            int result = op.SumNumber(num1test, num2test);

            // assert - evaluacion del resultado
            Assert.Equal(90, result);
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void IsEvenValue_InputOddNumber_ReturnFalse(int oddNumber, bool expectedResult)
        {
            Operation op = new();
            var result = op.IsEvenValue(oddNumber);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(20)]
        //[TestCase(12,10)]
        public void IsEvenValue_InputEvenNumber_ReturnTrue(int evenNumber)
        {
            Operation op = new();

            bool isEvenNumber = op.IsEvenValue(evenNumber);

            Assert.True(isEvenNumber);            
        }

        /* Nomenclatura del test:
         * nombreDeLaFuncion_input_NombreDelTest
         */

        [Theory]
        [InlineData(2.2, 1.2)] // result 3.4
        [InlineData(2.23, 1.24)] // result 3.47
        public void SumDouble_InputTwoDouble_GetCorrectValue(double dec1Test, double dec2Test)
        {
            // arrange - inicialiacion de los valores que ejecutan el test
            Operation op = new();

            // act - Represanta la ejecucion de la operacion
            double result = op.SumDouble(dec1Test, dec2Test);

            //la suma es 3.47
            // resultado esperado es 3.4

            // agregamos un intervalo
            // 3.3      3.5


            // assert - evaluacion del resultado
            Assert.Equal(3.4, result, 0);
        }

        [Fact]
        public void GetListOddNumbers_InputMinMaxInterval_ReturnsListOddNumbers()
        {
            //arrange
            Operation op = new();
            List<int> oddNumbersEspects = new() { 5, 7, 9 };

            //act
            List<int> results = op.GetListOddNumbers(5, 10);

            //assert
            Assert.Equal(oddNumbersEspects, results);
            
            //Contains
            Assert.Contains(5, results);            

            //not empty
            Assert.NotEmpty(results);

            // elements quantity
            Assert.Equal(3, results.Count);

            //find elements
            Assert.DoesNotContain(100,results);

            // valid order by
            Assert.Equal(results.OrderBy(x => x), results);

        }


    }
}
