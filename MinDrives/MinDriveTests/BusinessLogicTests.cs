using System;
using BusinessLogic;
using BusinessLogic.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinDriveTests
{
    [TestClass]
    public class BusinessLogicTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithNullListTest()
        {
            ICalculatorLogic controller = new CalculatorLogic();
            controller.Calculate(null, null);
        }
    }
}
