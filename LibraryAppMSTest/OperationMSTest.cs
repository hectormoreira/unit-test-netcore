using LibraryApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppMSTest
{
    [TestClass]
    public class OperationMSTest
    {
        [TestMethod]
        public void SumNumber_InputTwoNumbers_GetCorrectValue()
        {
            // arrange - inicialiacion de los valores que ejecutan el test
            Operation op = new();
            int num1test = 50;
            int num2test = 40;

            // act - Represanta la ejecucion de la operacion
            int result = op.SumNumber(num1test, num2test);

            // assert - evaluacion del resultado
            Assert.AreEqual(90,result);
        }
    }
}
