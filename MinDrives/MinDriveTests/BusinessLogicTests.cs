using System;
using BusinessLogic;
using BusinessLogic.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategies;
using Strategies.Interface;

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
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.MinDrives(null, null, strategy);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithNullFirstListTest()
        {
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            int[] total = { 4, 5 };
            controller.MinDrives(null,total,strategy);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithNullSecondListTest()
        {
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            int[] used = { 4, 5 };
            controller.MinDrives(used,null,strategy);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithOneInvalidHarDriveTest()
        {
            int[] used = {11};
            int[] total = {10};
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.MinDrives(used, total,strategy);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithInvalidHarDriveTwoTest()
        {
            
            int[] used = { 10, 10, 10, 10, 10, 10, 12, 10, 10, 10 };
            int[] total = { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 };
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.MinDrives(used, total,strategy);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveFirstTest()
        {
            int[] used = { 9, 9 };
            int[] total = { 10, 10 };
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            int result = controller.MinDrives(used, total,strategy);
            Assert.AreEqual(result, 2);
        }




    }
}
