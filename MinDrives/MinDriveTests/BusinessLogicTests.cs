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
        public void CalculateWithNullListTest()
        {
            ICalculatorLogic logic = new CalculatorLogic();
        }
    }
}
