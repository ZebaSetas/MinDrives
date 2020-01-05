using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HardDriveMarked
    {
        public HardDrive HardDrive { get; set; }
        public bool IsMarked { get; set; }

        public HardDriveMarked()
        {
            IsMarked = false;
        }

        public int GetFreeSpace()
        {
            return HardDrive.GetFreeSpace();
        }

        public int GetUsedSpace()
        {
            return HardDrive.UsedSpace;
        }

        public void AddData(int amountData)
        {
            HardDrive.AddData(amountData);
        }
    }
}
