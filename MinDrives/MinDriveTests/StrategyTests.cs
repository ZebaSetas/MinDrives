﻿using System;
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
            int result = calculator.CalculateMinDrives(null);
        }

        [TestMethod]
        [ExpectedException(typeof(StrategyException))]
        public void CalculateWithEmptyListTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int result = calculator.CalculateMinDrives(new List<HardDrive>());
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
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(StrategyException))]
        public void CalculateWithOneInvalidHarDriveTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            HardDrive hardrive = new HardDrive()
            {
                MaxSpace = 10,
                UsedSpace = 11//used space invalid
            };
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(hardrive);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(StrategyException))]
        public void CalculateWithInvalidHarDriveTwoTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 10, 10, 10, 10, 10, 10, 12, 10, 10, 10 };
            int[] total = { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveFirstTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 9, 9 };
            int[] total = { 10, 10 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveSecondTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 1, 1 };
            int[] total = { 10, 10 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveThirdTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 9, 1 };
            int[] total = { 10, 10 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CalculateWithTwoHardDriveFourthTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 1, 9 };
            int[] total = { 10, 10 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 1);
        }

       [TestMethod]
        public void CalculateTenHardDriveTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            int[] total = { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void CalculateTenHardDriveSecondTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            int[] total = { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 9);
        }


        [TestMethod]
        public void CalculateExampleZeroTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 300, 525, 110 };
            int[] total = { 350, 600, 115 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(result, 2);
        }
       

        [TestMethod]
        public void CalculateExampleThreeTestWithFirstFull()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] useda = { 50, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49 };
            int[] total = { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            List<HardDrive> hardDrives = BuildHardDrives(useda, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(hardDrives.Count, 50);
            Assert.AreEqual(result, 50);
        }

        [TestMethod]
        public void CalculateExampleThreeTestWithLastFull()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 50 };
            int[] total = { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.CalculateMinDrives(hardDrives);
            Assert.AreEqual(hardDrives.Count, 50);
            Assert.AreEqual(result, 50);
        }

        private List<HardDrive> BuildHardDrives(int[] used, int[] total)
        {
            List<HardDrive> hardDrives = new List<HardDrive>();
            int nextId = 0;
            for (int i = 0; i < used.Length; i++)
            {
                HardDrive hardDrive = new HardDrive()
                {
                    UsedSpace = used[i],
                    MaxSpace = total[i],
                    Id = nextId
                };
                hardDrives.Add(hardDrive);
                nextId++;
            }
            return hardDrives;
        }
    }
}
