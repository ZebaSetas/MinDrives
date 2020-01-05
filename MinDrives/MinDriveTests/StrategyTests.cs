using System;
using System.Collections.Generic;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategies;
using Strategies.Interface;

namespace MinDriveTests
{
    [TestClass]
    public class StrategyTests
    {
        [TestMethod]
        public void CreateEmptyStrategyTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            Assert.AreNotEqual(calculator, null);
        }

        [TestMethod]
        [ExpectedException(typeof(StrategyException))]
        public void CalculateWithNullListTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int result = calculator.Calculate(null);
        }

        [TestMethod]
        [ExpectedException(typeof(StrategyException))]
        public void CalculateWithEmptyListTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int result = calculator.Calculate(new List<HardDrive>());
        }
    }
}
