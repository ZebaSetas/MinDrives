using System;
using System.Collections.Generic;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategies;

namespace MinDriveTests
{
    [TestClass]
    public class GreyconExampleTests
    {
      [TestMethod]
        public void CalculateExampleOneTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 1, 200, 200, 199, 200, 200 };
            int[] total = { 1000, 200, 200, 200, 200, 200 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.Calculate(hardDrives);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CalculateExampleTwoTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used = { 750, 800, 850, 900, 950 };
            int[] total = { 800, 850, 900, 950, 1000 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.Calculate(hardDrives);
            Assert.AreEqual(result, 5);
        }
        
        [TestMethod]
        public void CalculateExampleThreeTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();

            int[] used = { 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49 };
            int[] total = { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.Calculate(hardDrives);
            Assert.AreEqual(hardDrives.Count, 50);
            Assert.AreEqual(result, 49);
        }
        
        [TestMethod]
        public void CalculateExampleFouthTest()
        {
            BacktrackingCalculatorMinDrives calculator = new BacktrackingCalculatorMinDrives();
            int[] used =  { 331, 242, 384, 366, 428, 114, 145, 89, 381, 170, 329, 190, 482, 246, 2,  38, 220, 290, 402, 385};
            int[] total = { 992, 509, 997, 946, 976, 873, 771, 565,693, 714, 755, 878, 897, 789, 969,727,765, 521, 961, 906};
            List<HardDrive> hardDrives = BuildHardDrives(used, total);
            int result = calculator.Calculate(hardDrives);            
            Assert.AreEqual(result, 6);
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
