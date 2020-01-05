using System;

namespace Domain
{
    public class HardDrive
    {
        public int MaxSpace { get; set; }
        public int UsedSpace { get; set; }

        public bool IsValid()
        {
            return MaxSpace >= UsedSpace;
        }

        public int GetFreeSpace()
        {
            return MaxSpace - UsedSpace;
        }

        public void AddData(int amountData)
        {
            int newUsedSpace = UsedSpace + amountData;
            bool spaceWasExceeded = newUsedSpace > MaxSpace;
            if (!spaceWasExceeded) UsedSpace = newUsedSpace;
            else throw new DomainException("Quantity was exceeded");
        }

    }

   
}
