using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Solution
    {
        public List<HardDrive> HardDrives { get; set; }

        public Solution(List<HardDrive> hardDrives)
        {
            HardDrives = new List<HardDrive>();
            HardDrives.AddRange(hardDrives);
        }

    }
}
