using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategies;

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
    }
}
