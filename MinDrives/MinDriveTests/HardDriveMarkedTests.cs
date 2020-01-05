using System;
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

    }
}
