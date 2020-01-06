using System;

namespace Domain
{
    public class HardDrive:IComparable
    {
        public int Id { get; set; }
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

        public override bool Equals(object otherHardDrive)
        {
            HardDrive other = (HardDrive) otherHardDrive;
            return this.Id == other.Id;
        }

        public int CompareTo(object otherHardDrive)
        {
            HardDrive other = (HardDrive)otherHardDrive;
            return this.UsedSpace.CompareTo(other.UsedSpace);
        }
    }

   
}
