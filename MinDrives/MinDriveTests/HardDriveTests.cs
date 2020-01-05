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
    }
}
