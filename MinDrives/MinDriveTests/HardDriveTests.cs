using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinDriveTests
{
    [TestClass]
    public class HardDriveTests
    {
        [TestMethod]
        public void CreateEmptyHardDriveTest()
        {
            HardDrive hardrive = new HardDrive();
            Assert.AreEqual(hardrive.MaxSpace, 0);
            Assert.AreEqual(hardrive.UsedSpace, 0);
        }

        [TestMethod]
        public void CreateEntityWithDataTest()
        {
            HardDrive hardrive = new HardDrive()
            {
                MaxSpace = 10,
                UsedSpace = 1
            };
            Assert.AreEqual(hardrive.MaxSpace, 10);
            Assert.AreEqual(hardrive.UsedSpace, 1);
            Assert.AreEqual(hardrive.GetFreeSpace(), 9);
        }

        [TestMethod]
        public void IsValidEntityTest()
        {
            HardDrive hardrive = new HardDrive()
            {
                MaxSpace = 10,
                UsedSpace = 1
            };
            Assert.AreEqual(hardrive.IsValid(), true);
        }

        [TestMethod]
        public void IsNotValidEntityTest()
        {
            HardDrive hardrive = new HardDrive()
            {
                MaxSpace = 10,
                UsedSpace = 11
            };
            Assert.AreEqual(hardrive.IsValid(), false);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void ExceededAddDataTest()
        {
            HardDrive hardrive = new HardDrive()
            {
                MaxSpace = 10,
                UsedSpace = 9
            };
            hardrive.AddData(2);
        }

    }
}
