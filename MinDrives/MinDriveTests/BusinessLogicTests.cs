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
            controller.MinDrives(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithNullFirstListTest()
        {
            ICalculatorLogic controller = new CalculatorLogic();
            int[] total = { 4, 5 };
            controller.MinDrives(null,total);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithNullSecondListTest()
        {
            ICalculatorLogic controller = new CalculatorLogic();
            int[] used = { 4, 5 };
            controller.MinDrives(used,null);
        }
    }
}
