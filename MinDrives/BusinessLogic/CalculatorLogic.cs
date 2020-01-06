using BusinessLogic.Interface;
using System;

namespace BusinessLogic
{
    public class CalculatorLogic : ICalculatorLogic
    {
        public int MinDrives(int[]used, int[]total)
        {
            ThrowExceptionIfIsInvalid(used,total);
            return 0;
        }

        private void ThrowExceptionIfIsInvalid(int[] used, int[] total)
        {
            bool thereIsListNull = used == null || total == null;
            if(thereIsListNull) throw new BusinessLogicException("Error! List of used or total is null");
            bool theListsAreNotSameSize = used.Length != total.Length;
            if(theListsAreNotSameSize) throw new BusinessLogicException("Error! List of used or total are not the same size");
        }
    }
}
