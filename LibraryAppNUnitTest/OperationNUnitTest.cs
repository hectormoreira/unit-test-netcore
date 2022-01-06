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
        public bool IsValuePair_InputNoPairNumber_ReturnFalse(int numberNoPair)
        {
            Operation op = new();

            return op.IsValuePair(numberNoPair);

            //Assert.IsFalse(isPair);
            ////or
            //Assert.That(isPair, Is.EqualTo(false));
        }

        [Test]
        [TestCase(8)]
        [TestCase(4)]
        [TestCase(20)]
        //[TestCase(12,10)]
        public void IsValuePair_InputPairNumber_ReturnTrue(int numberPair)
        {
            Operation op = new();

            bool isPair = op.IsValuePair(numberPair);

            Assert.IsTrue(isPair);
            //or
            Assert.That(isPair, Is.EqualTo(true));
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


    }
}
