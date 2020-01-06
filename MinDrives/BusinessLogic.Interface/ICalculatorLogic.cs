using System;
using Strategies.Interface;

namespace BusinessLogic.Interface
{
    public interface ICalculatorLogic
    {
        int MinDrives(int[] used, int[] total);
        void SetStrategy(IStrategy strategy);
    }
}
