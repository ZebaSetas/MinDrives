using Domain;
using Strategies.Interface;
using System;
using System.Collections.Generic;

namespace Strategies
{
    public class BacktrackingCalculatorMinDrives
    {

        public int Calculate(List<HardDrive> hardDrives)
        {
            bool thereIsAHardDrive = hardDrives != null && hardDrives.Count > 0;
            if (!thereIsAHardDrive) throw new StrategyException("There is no HardDrive");
            bool thereIsOnlyHardDrive = hardDrives.Count == 1;
            if (thereIsOnlyHardDrive) return 1;
            else throw new StrategyException("");
        }
    }
}
