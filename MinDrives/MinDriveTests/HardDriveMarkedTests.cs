using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinDriveTests
{
    [TestClass]
    public class HardDriveMarkedTests
    {
        [TestMethod]
        public void CreateEmptyEntityTest()
        {
            HardDriveMarked adapter = new HardDriveMarked();
            Assert.AreEqual(adapter.HardDrive, null);
            Assert.AreEqual(adapter.IsMarked, false);
        }

        [TestMethod]
        public void CreateEntityWithDataTest()
        {
            HardDrive hardrive = new HardDrive()
            {
                MaxSpace = 10,
                UsedSpace = 1
            };
            HardDriveMarked adapter = new HardDriveMarked()
            {
                HardDrive = hardrive
            };
            Assert.AreEqual(adapter.IsMarked, false);
            Assert.AreEqual(adapter.GetUsedSpace(), 1);
            Assert.AreEqual(adapter.GetFreeSpace(), 9);
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
