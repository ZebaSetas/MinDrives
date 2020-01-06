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
            controller.SetStrategy(strategy);
            controller.MinDrives(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithNullFirstListTest()
        {
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.SetStrategy(strategy);
            int[] total = { 4, 5 };
            controller.MinDrives(null,total);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithNullSecondListTest()
        {
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.SetStrategy(strategy);
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
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.SetStrategy(strategy);
            controller.MinDrives(used, total);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CalculateWithInvalidHarDriveTwoTest()
        {
            
            int[] used = { 10, 10, 10, 10, 10, 10, 12, 10, 10, 10 };
            int[] total = { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 };
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.SetStrategy(strategy);
            controller.MinDrives(used, total);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveFirstTest()
        {
            int[] used = { 9, 9 };
            int[] total = { 10, 10 };
            ICalculatorLogic controller = new CalculatorLogic();
            IStrategy strategy = new BacktrackingCalculatorMinDrives();
            controller.SetStrategy(strategy);
            int result = controller.MinDrives(used, total);
            Assert.AreEqual(result, 2);
        }


    }
}
