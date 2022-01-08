using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    [TestFixture]
    public class OperationNUnitTest
    {
        [Test]
        public void SumNumber_InputTwoNumbers_GetCorrectValue()
        {
            // arrange - inicialiacion de los valores que ejecutan el test
            Operation op = new();
            int num1test = 50;
            int num2test = 40;

            // act - Represanta la ejecucion de la operacion
            int result = op.SumNumber(num1test, num2test);

            // assert - evaluacion del resultado
            Assert.AreEqual(90, result);
        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsEvenValue_InputOddNumber_ReturnFalse(int oddNumber)
        {
            Operation op = new();

            return op.IsEvenValue(oddNumber);

            //Assert.IsFalse(isEvenNumber);
            ////or
            //Assert.That(isEvenNumber, Is.EqualTo(false));
        }

        [Test]
        [TestCase(8)]
        [TestCase(4)]
        [TestCase(20)]
        //[TestCase(12,10)]
        public void IsEvenValue_InputEvenNumber_ReturnTrue(int evenNumber)
        {
            Operation op = new();

            bool isEvenNumber = op.IsEvenValue(evenNumber);

            Assert.IsTrue(isEvenNumber);
            //or
            Assert.That(isEvenNumber, Is.EqualTo(true));
        }

        /* Nomenclatura del test:
         * nombreDeLaFuncion_input_NombreDelTest
         */

        [Test]
        [TestCase(2.2, 1.2)] // result 3.4
        [TestCase(2.23, 1.24)] // result 3.47
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
            Assert.AreEqual(3.4, result, 0.1);
        }

        [Test]
        public void GetListOddNumbers_InputMinMaxInterval_ReturnsListOddNumbers()
        {
            //arrange
            Operation op = new();
            List<int> oddNumbersEspects = new() { 5, 7, 9 };

            //act
            List<int> results = op.GetListOddNumbers(5, 10);

            //assert
            Assert.That(results, Is.EquivalentTo(oddNumbersEspects));
            Assert.AreEqual(oddNumbersEspects, results);
            
            //Contains
            Assert.That(results, Does.Contain(7));
            //forma clasica
            Assert.Contains(5, results);

            //not empty
            Assert.That(results, Is.Not.Empty);

            // elements quantity
            Assert.That(results.Count, Is.EqualTo(3));

            //find elements
            Assert.That(results, Has.No.Member(100));

            // valid order by
            Assert.That(results, Is.Ordered.Ascending);

            // valores no duplicados
            Assert.That(results, Is.Unique);

        }


    }
}
