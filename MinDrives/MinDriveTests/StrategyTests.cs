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

        [TestMethod]
        public void CalculateWithOneHardDriveTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            HardDrive hardrive = new HardDrive()
            {
                MaxSpace = 10,
                UsedSpace = 1
            };
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(hardrive);
            int result = calculator.Calculate(hardDrives);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveFirstTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 9, 9 };
            int[] total = { 10, 10 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.Calculate(hardDrives);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveSecondTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 1, 1 };
            int[] total = { 10, 10 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.Calculate(hardDrives);
            Assert.AreEqual(result, 1);
        }

        private List<HardDrive> BuildHardDrives(int[] used, int[] total)
        {
            List<HardDrive> hardDrives = new List<HardDrive>();
            for (int i = 0; i < used.Length; i++)
            {
                HardDrive hardDrive = new HardDrive()
                {
                    UsedSpace = used[i],
                    MaxSpace = total[i]
                };
                hardDrives.Add(hardDrive);
            }
            return hardDrives;
        }
    }
}
