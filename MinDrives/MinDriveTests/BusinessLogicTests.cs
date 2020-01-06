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

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithOneInvalidHarDriveTest()
        {
            int[] used = {11};
            int[] total = {10};
            ICalculatorLogic controller = new CalculatorLogic();
            controller.MinDrives(used, total);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithInvalidHarDriveTwoTest()
        {
            
            int[] used = { 10, 10, 10, 10, 10, 10, 12, 10, 10, 10 };
            int[] total = { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 };
            ICalculatorLogic controller = new CalculatorLogic();
            controller.MinDrives(used, total);
        }
    }
}
