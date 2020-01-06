using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategies.Interface
{
    public abstract class StrategyThemplate
    {
        public abstract int CalculateMinDrives(List<HardDrive> hardDrives);
    }
}
