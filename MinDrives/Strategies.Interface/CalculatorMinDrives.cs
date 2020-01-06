using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategies.Interface
{
    public abstract class CalculatorMinDrives
    {
        public abstract int Calculate(List<HardDrive> hardDrives);
    }
}
